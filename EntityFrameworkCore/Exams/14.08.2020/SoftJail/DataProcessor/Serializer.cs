namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using static SoftJail.DataProcessor.ExportDto.ExportPrisonerDto;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .ToArray()
                .Select(x=> new ExportPrisonerDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(o=> new OfficerDto
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(o=>o.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(s=>s.Officer.Salary)
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new DefaultNamingStrategy()
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var prisonersJson = JsonConvert.SerializeObject(prisoners, options);

            return prisonersJson;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var namesArray = prisonersNames.Split(",").ToArray();

            var prisoners = context.Prisoners
                .Where(x => namesArray.Contains(x.FullName))
                .ToArray()
                .Select(x => new ExportPrisonersInbox
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = x.Mails.Select(m => new MessagesExportModel
                    {
                        Description = new string(m.Description.ToCharArray().Reverse().ToArray())

                    }).ToArray()
                })
                .OrderBy(x=>x.Name)
                .ThenBy(x=>x.Id)
                .ToArray();

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Prisoners";
            var serializer = new XmlSerializer(typeof(ExportPrisonersInbox[]), xRoot);


            serializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            return sb.ToString().TrimEnd();


        }
    }
}