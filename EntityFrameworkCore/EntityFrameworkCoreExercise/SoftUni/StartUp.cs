using SoftUni.Data;
using System;
using System.Linq;
using System.Text;
using SoftUni.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            using(db)
            {
                Console.WriteLine(GetLatestProjects(db));
            }
        }

        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.OrderBy(x => x.EmployeeId).ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.
                Where(x => x.Salary > 50000).
                OrderBy(x => x.FirstName).
                ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.
                Where(x => x.Department.Name == "Research and Development").
                Select(x=> new
                {
                    x.FirstName,
                    x.LastName,
                    x.Department.Name,
                    x.Salary
                }).
                OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.Name} - ${emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 06 
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var nakov = context.Employees.Where(x => x.LastName == "Nakov").FirstOrDefault();

            nakov.AddressId = address.AddressId;

            context.SaveChanges();

            var output = context.Employees.OrderByDescending(x => x.AddressId).Select(x => new
            {
                x.Address.AddressText
            }).Take(10).ToList();

            var sb = new StringBuilder();

            foreach (var item in output)
            {
                sb.AppendLine(item.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees.
                Include(x=>x.EmployeesProjects).
                ThenInclude(x=>x.Project).
                Where(x=>x.EmployeesProjects.Any(y => y.Project.StartDate.Year >= 2001 && y.Project.StartDate.Year <= 2003)).
                Select(x => new
            {
                x.FirstName,
                x.LastName,
                ManagerFirstName = x.Manager.FirstName,
                MangareLastName = x.Manager.LastName,
                Projects = x.EmployeesProjects.Select(y => new
                {
                    Name = y.Project.Name,
                    StartDate = y.Project.StartDate,
                    EndDate = y.Project.EndDate
                }).
                ToList()
            }).
            Take(10).
            ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.MangareLastName}");
                foreach (var project in employee.Projects)
                {
                    var endDate = project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";

                    sb.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");

                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses.Select(x => new
            {
                x.AddressText,
                x.Town.Name,
                EmployeeCount = x.Employees.Count()
            }).
            OrderByDescending(x => x.EmployeeCount).
            ThenBy(x => x.Name).
            ThenBy(x => x.AddressText).
            Take(10).ToList();
           

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 09
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees.
                Where(x => x.EmployeeId == 147).
                Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects.
                    Select(y => new
                    {
                        y.Project.Name
                    }).
                    OrderBy(x=>x.Name).
                    ToList()
                }).
                FirstOrDefault();

            var sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments.
                Where(x => x.Employees.Count > 5).
                OrderBy(x => x.Employees.Count).
                ThenBy(x => x.Name).
                Select(x => new
                {
                    x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Emplooyees = x.Employees.Select(y => new
                    {
                        y.FirstName,
                        y.LastName,
                        y.JobTitle

                    }).
                    OrderBy(y => y.FirstName).
                    ThenBy(y => y.LastName).
                    ToList()
                }).
                ToList();

            var sb = new StringBuilder();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");
                foreach (var e in d.Emplooyees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} = {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        
        }

        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects.
                OrderByDescending(x => x.StartDate).
                Take(10).Select(x=> new
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                }).
                OrderBy(x => x.Name).
                ToList();

            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }


    }
}
