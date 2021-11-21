namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            var projects = context.Projects
                .Where(x => x.Tasks.Count >= 1)
                .ToArray()
                .Select(x => new ExportProjcetDto
                {
                    TasksCount = x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                    Tasks = x.Tasks.
                    ToArray().
                    Select(t => new TaskExportDtoModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToList();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Projects";
            var serializer = new XmlSerializer(typeof(List<ExportProjcetDto>), xRoot);


            serializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .ToArray()
                .Select(x => new ExportEmployeeDto
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(t => t.Task.OpenDate >= date)
                    .ToArray()
                    .OrderByDescending(t => t.Task.DueDate)
                    .ThenBy(t => t.Task.Name)
                    .Select(t => new TaskExportDto
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        ExecutionType = t.Task.ExecutionType.ToString(),
                        LabelType = t.Task.LabelType.ToString()

                    }).ToArray()
                })
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new DefaultNamingStrategy()
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var employeesJson = JsonConvert.SerializeObject(employees, options);

            return employeesJson;
        }
    }
}