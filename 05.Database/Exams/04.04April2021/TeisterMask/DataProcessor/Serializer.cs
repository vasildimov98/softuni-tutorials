namespace TeisterMask.DataProcessor
{
    using System;
    using System.Linq;
    using System.Globalization;

    using Newtonsoft.Json;

    using Data;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.XmlHelper;

    public class Serializer
    {
        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employeesToExport = context.Employees
               .Where(x => x.EmployeesTasks.Any(x => x.Task.OpenDate >= date))
               .AsEnumerable()
               .Select(x => new
               {
                   x.Username,
                   Tasks = x.EmployeesTasks
                    .Where(x => x.Task.OpenDate >= date)
                    .OrderByDescending(y => y.Task.DueDate)
                    .ThenBy(y => y.Task.Name)
                    .AsEnumerable()
                    .Select(y => new
                    {
                        TaskName = y.Task.Name,
                        OpenDate = y.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = y.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = y.Task.LabelType.ToString(),
                        ExecutionType = y.Task.ExecutionType.ToString()
                    })
               })
               .OrderByDescending(x => x.Tasks.Count())
               .ThenBy(x => x.Username)
               .Take(10)
               .AsEnumerable();

            var jsonOutput = JsonConvert.SerializeObject(employeesToExport, Formatting.Indented);

            return jsonOutput;
        }

        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projectsToEmport = context.Projects
                .Where(x => x.Tasks.Count != 0)
                .AsEnumerable()
                .Select(x => new ExportXmlProjectDto
                {
                    TasksCount = x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks
                        .AsEnumerable()
                        .Select(y => new TaskXmlEmportDto
                        {
                            Name = y.Name,
                            Label = y.LabelType.ToString()
                        })
                        .OrderBy(x => x.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var xmlOutput = XmlConvert.Serialize("Projects", projectsToEmport);

            return xmlOutput;
        }

    }
}