namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
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

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Projects";
            var serializer = new XmlSerializer(typeof(List<ProjcetInputModel>), xRoot);
            var projcetsDto = (List<ProjcetInputModel>)serializer.Deserialize(new StringReader(xmlString));

            var projects = new List<Project>();

            foreach (var project in projcetsDto)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                var isValidOpenDate = DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!isValidOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;

                if (!String.IsNullOrWhiteSpace(project.DueDate))
                {
                    DateTime dueDateWithValue;
                    var isValidDueDate = DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateWithValue);

                    if (!isValidDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateWithValue;
                }

                Project p = new Project()
                {
                    Name = project.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                foreach (var task in project.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    var isValidTaskOpenDate = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    if (!isValidOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    var isValidTaskDueDate = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isValidTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDate.HasValue && taskDueDate > dueDate.Value)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task t = new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType,
                    };

                    p.Tasks.Add(t);

                }

                projects.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, p.Name, p.Tasks.Count));
            
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();         
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var employeesDto = JsonConvert.DeserializeObject <EmployeeInputModel[]>(jsonString);
            var employees = new List<Employee>();

            var tasksIds = context.Tasks.Select(t => t.Id).ToList();
            foreach (EmployeeInputModel emp in employeesDto)
            {
                if (!IsValid(emp))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;                     
                }

                var employee = new Employee
                {
                    Username = emp.Username,
                    Email = emp.Email,
                    Phone = emp.Phone
                };

                foreach (var task in emp.Tasks.Distinct())
                {
                    if (!tasksIds.Contains(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var t = new EmployeeTask
                    {
                        TaskId = task
                    };
                    employee.EmployeesTasks.Add(t);
                }

                employees.Add(employee);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee,employee.Username,employee.EmployeesTasks.Count()));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}