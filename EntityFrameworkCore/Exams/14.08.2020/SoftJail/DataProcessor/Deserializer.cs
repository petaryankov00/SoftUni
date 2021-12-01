namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var departmentsDto = JsonConvert.DeserializeObject<IEnumerable<DepartmentImportModel>>(jsonString);

            var departments = new List<Department>();

            foreach (var department in departmentsDto)
            {
                if (!IsValid(department))
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }
                var departmentDb = context.Departments.FirstOrDefault(x => x.Name == department.Name);

                if (departmentDb == null)
                {
                    departmentDb = new Department
                    {
                        Name = department.Name,
                    };
                }

                bool isCellValid = true;

                foreach (var cell in department.Cells)
                {
                    if (!IsValid(cell))
                    {
                        isCellValid = false;
                        break;
                    }
                    var cellDb = context.Cells.FirstOrDefault(x => x.CellNumber == cell.CellNumber);

                    if (cellDb is null)
                    {
                        cellDb = new Cell
                        {
                            CellNumber = cell.CellNumber,
                            HasWindow = cell.HasWindow,
                        };
                    }

                    departmentDb.Cells.Add(cellDb);
                }
                if (!isCellValid)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                sb.AppendLine(String.Format(GlobalConstants.SuccesfullDepartment, departmentDb.Name, departmentDb.Cells.Count));
                departments.Add(departmentDb);
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var prisonersDto = JsonConvert.DeserializeObject<IEnumerable<PrisonerImportModel>>(jsonString);

            var prisoners = new List<Prisoner>();

            foreach (var prisoner in prisonersDto)
            {
                if (!IsValid(prisoner))
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                if (prisoner.Mails.Length <= 0)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                DateTime releaseDate;
                bool isValidDate = DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                var prisonerDb = context.Prisoners
                    .FirstOrDefault(x => x.FullName == prisoner.FullName && x.Nickname == prisoner.Nickname);

                if (prisonerDb == null)
                {
                    prisonerDb = new Prisoner
                    {
                        FullName = prisoner.FullName,
                        Nickname = prisoner.Nickname,
                        IncarcerationDate = DateTime
                        .ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ReleaseDate = isValidDate ? (DateTime?)releaseDate : null,
                        Age = prisoner.Age,
                        Bail = prisoner.Bail,
                        CellId = prisoner.CellId
                    };
                }

                bool isMailValid = true;
                foreach (var mail in prisoner.Mails)
                {
                    if (!IsValid(mail))
                    {
                        sb.AppendLine(GlobalConstants.ErrorMessage);
                        isMailValid = false;
                        break;
                    }

                    var mailDb = context.Mails.FirstOrDefault(x => x.Description == mail.Description);

                    if (mailDb == null)
                    {
                        mailDb = new Mail
                        {
                            Description = mail.Description,
                            Sender = mail.Sender,
                            Address = mail.Address
                        };
                    }
                    prisonerDb.Mails.Add(mailDb);
                }
                if (!isMailValid)
                {
                    continue;
                }

                sb.AppendLine(String.Format(GlobalConstants.SuccesfullPrisoner, prisonerDb.FullName, prisonerDb.Age));
                prisoners.Add(prisonerDb);
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Officers";
            var serializer = new XmlSerializer(typeof(List<OfficerImportModel>), xRoot);
            var officersDto = (List<OfficerImportModel>)serializer.Deserialize(new StringReader(xmlString));

            var officers = new List<Officer>();
            var departmentsIds = context.Departments.Select(x => x.Id).ToList();

            foreach (var officer in officersDto)
            {
                if (!IsValid(officer) || !officer.Prisoners.All(IsValid))
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                if (!departmentsIds.Contains(officer.DepartmentId))
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                object position;
                var isValidPosition = Enum.TryParse(typeof(Position), officer.Position, out position);

                if (!isValidPosition)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                object weapon;
                var isValidWeapon = Enum.TryParse(typeof(Weapon), officer.Weapon, out weapon);

                if (!isValidWeapon)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                var officerDb = new Officer
                {
                    FullName = officer.Name,
                    Salary = officer.Money,
                    Position = (Position)position,
                    Weapon = (Weapon)weapon,
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.Prisoners.Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.PrisonerId

                    }).ToArray()
                };

                officers.Add(officerDb);
                sb.AppendLine(String.Format(GlobalConstants.SuccesfullOfficer, officerDb.FullName, officerDb.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}