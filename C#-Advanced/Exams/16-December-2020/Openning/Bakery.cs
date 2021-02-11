using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BakeryOpenning
{
    class Bakery
    {
        private List<Employee> data;

        public Bakery(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>(capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public string Remove(string name)
        {
            Employee searchedEmployee = data.FirstOrDefault(x => x.Name == name);
            if (searchedEmployee == null)
            {
                return false.ToString();
            }
            else
            {
                data.Remove(searchedEmployee);
                return true.ToString();
            }
        }

        public Employee GetOldestEmployee()
        {
            Employee oldest = default(Employee);
            int oldestAge = int.MinValue;
            foreach (var employee in data)
            {
                if (employee.Age > oldestAge)
                {
                    oldest = employee;
                }
            }

            return oldest;
        }

        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var person in data)
            {
                sb.AppendLine($"{person}");
            }

            string report = sb.ToString();
            return report;
        }
    }
}
