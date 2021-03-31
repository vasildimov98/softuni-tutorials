namespace SoftJail.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Data;
    using ExportDto;
    using Data.Models;
    using SoftJail.XmlHelper;
    using System.Globalization;
    using SoftJail.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string ImportDepartmentCellsMessage = "Imported {0} with {1} cells";
        private const string ImportPrisonerMailsMessage = "Imported {0} {1} years old";
        private const string ImportOfficerPrisonerMessage = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var departments = new List<Department>();

            var departmentsCells = JsonConvert.DeserializeObject<IEnumerable<DepartmetCellsDto>>(jsonString);

            foreach (var departmentCells in departmentsCells)
            {
                if (!IsValid(departmentCells)
                    || departmentCells.Cells.Count() == 0
                    || !departmentCells.Cells.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var department = new Department
                {
                    Name = departmentCells.Name,
                    Cells = departmentCells.Cells
                        .Select(x => new Cell
                        {
                            CellNumber = x.CellNumber,
                            HasWindow = x.HasWindow
                        }).ToList()
                };

                departments.Add(department);

                sb.AppendLine(string.Format(
                    ImportDepartmentCellsMessage,
                    department.Name,
                    department.Cells.Count));
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var output = sb.ToString().TrimEnd();

            return output;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var prisoners = new List<Prisoner>();

            var prisonersMails = JsonConvert.DeserializeObject<IEnumerable<PrisonerMailsDto>>(jsonString);

            foreach (var prisonerMails in prisonersMails)
            {
                if (!IsValid(prisonerMails)
                    || !prisonerMails.Mails.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var incarcerationDate = DateTime.ParseExact(
                        prisonerMails.IncarcerationDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);

                var isReleaseDateValid = DateTime.TryParseExact(
                    prisonerMails.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate);

                prisoners.Add(new Prisoner
                {
                    FullName = prisonerMails.FullName,
                    Nickname = prisonerMails.Nickname,
                    Age = prisonerMails.Age,
                    Bail = prisonerMails.Bail,
                    CellId = prisonerMails.CellId,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = isReleaseDateValid ? (DateTime?)releaseDate : null,
                    Mails = prisonerMails.Mails
                        .Select(x => new Mail
                        {
                            Description = x.Description,
                            Sender = x.Sender,
                            Address = x.Address
                        }).ToList()
                }); 


                sb.AppendLine(string.Format(
                    ImportPrisonerMailsMessage,
                    prisonerMails.FullName,
                    prisonerMails.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            var output = sb.ToString().TrimEnd();

            return output;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var officers = new List<Officer>(); 

            var officerPrisonerDtos = XmlConvert.Deserialize<OfficerPrisonerDto[]>(xmlString);

            foreach (var officerPrisonerDto in officerPrisonerDtos)
            {
                if (!IsValid(officerPrisonerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var position = Enum.Parse<Position>(officerPrisonerDto.Position, true);
                var weopen = Enum.Parse<Weapon>(officerPrisonerDto.Weapon, true);

                var officer = new Officer
                {
                    FullName = officerPrisonerDto.FullName,
                    Salary = officerPrisonerDto.Salary,
                    DepartmentId = officerPrisonerDto.DepartmentId,
                    Position = position,
                    Weapon = weopen
                };

                var officerPrisoners = officerPrisonerDto.Prisoners
                    .Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.Id,
                        Officer = officer
                    })
                    .ToList();

                officer.OfficerPrisoners = officerPrisoners;

                officers.Add(officer);

                sb.AppendLine(string.Format(
                    ImportOfficerPrisonerMessage,
                    officerPrisonerDto.FullName,
                    officerPrisonerDto.Prisoners.Count()
                    ));
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            var output = sb.ToString().TrimEnd();

            return output;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}