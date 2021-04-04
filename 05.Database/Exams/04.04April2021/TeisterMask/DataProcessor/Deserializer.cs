namespace TeisterMask.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Data;
    using XmlHelper;
    using ImportDto;
    using Data.Models;
    using Data.Models.Enums;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var projectsDtosToExport = XmlConvert
                .Deserialize<ProjectXmlImportDto[]>("Projects", xmlString);

            foreach (var projectDto in projectsDtosToExport)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var openDate = DateTime
                    .ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = openDate,
                };


                var isDueDateValid = DateTime
                   .TryParseExact(projectDto.DueDate,
                   "dd/MM/yyyy",
                   CultureInfo.InvariantCulture,
                   DateTimeStyles.None,
                   out var dueDate);

                if (isDueDateValid)
                {
                    project.DueDate = dueDate;
                }
                else
                {
                    projectDto.DueDate = null;
                }


                context.Projects.Add(project);
                context.SaveChanges();

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto)
                        || !Enum.IsDefined(typeof(ExecutionType), taskDto.ExecutionType)
                        || !Enum.IsDefined(typeof(LabelType), taskDto.LabelType))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var executionType = (ExecutionType)taskDto.ExecutionType;
                    var labelType = (LabelType)taskDto.LabelType;

                    var openDateTask = DateTime
                        .ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var dueDateTask = DateTime
                        .ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (openDateTask < openDate
                        || (isDueDateValid && dueDateTask > dueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        ExecutionType = executionType,
                        LabelType = labelType,
                        ProjectId = project.Id
                    };

                    context.Tasks.Add(task);
                }

                context.SaveChanges();

                sb.AppendLine(string.Format(
                    SuccessfullyImportedProject,
                    project.Name,
                    project.Tasks.Count));
            }


            var output = sb.ToString();

            return output;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var employeesDtosToExport = JsonConvert
                .DeserializeObject<IEnumerable<EmployeeJsonImportDto>>(jsonString);

            foreach (var employeeDto in employeesDtosToExport)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    var task = context.Tasks
                        .FirstOrDefault(x => x.Id == taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask { TaskId = task.Id });
                }

                context.Employees.Add(employee);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedEmployee,
                    employee.Username,
                    employee.EmployeesTasks.Count));
            }

            context.SaveChanges();

            var output = sb.ToString();

            return output;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}