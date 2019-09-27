using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                decimal salary = decimal.Parse(info[1]);
                string position = info[2];
                string department = info[3];
                
                Employee employee = new Employee(name, salary,position,department);

                if (info.Length == 5)
                {
                    if (info[4].Contains('@'))
                    {
                        employee.Email = info[4];
                    }
                    else
                    {
                        employee.Age = int.Parse(info[4]);
                    }
                }
                else if(info.Length == 6)
                {
                    employee.Email = info[4];
                    employee.Age = int.Parse(info[5]);
                }

                employees.Add(employee);
            }
            // Creating an IGrouping w/ Key=> Department & Value => employees
            var leadingDepartment = employees
                .GroupBy(x => x.Department)
                .OrderByDescending(x => x.Average(s => s.Salary))
                .FirstOrDefault();
                 // returns OBJECT not collection

            Console.WriteLine();
            Console.WriteLine($"Highest Average Salary: {leadingDepartment.Key}");
            foreach (var employee in leadingDepartment.OrderByDescending(s => s.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
