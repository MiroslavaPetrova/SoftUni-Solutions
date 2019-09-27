using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                //Pesho 120.00 Dev Development pesho@abv.bg 28
                //Toncho 333.33 Manager Marketing 33

                string name = inputArgs[0];
                decimal salary = decimal.Parse(inputArgs[1]);
                string position = inputArgs[2];
                string department = inputArgs[3];

                Employee employee = new Employee(name, salary, position, department);

                if (inputArgs.Length == 5)
                {
                    if (int.TryParse(inputArgs[4], out int result))
                    {
                        employee.Age = result;
                    }
                    else
                    {
                        employee.Email = inputArgs[4];
                    }
                }
                else if (inputArgs.Length == 6)
                {
                    employee.Email = inputArgs[4];
                    employee.Age = int.Parse(inputArgs[5]);
                }

                employees.Add(employee);
            }

            IGrouping<string, Employee> topDepartment = employees
                                                        .GroupBy(e => e.Department)
                                                        .OrderByDescending(s => s.Average(e => e.Salary))
                                                        .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");

            foreach (Employee employee in topDepartment.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}
