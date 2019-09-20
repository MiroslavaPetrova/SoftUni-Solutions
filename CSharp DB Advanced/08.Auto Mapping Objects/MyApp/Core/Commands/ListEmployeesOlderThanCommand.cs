using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ListEmployeesOlderThanCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            //ListEmployeesOlderThan <age>

            int age = int.Parse(args[0]);

            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Birthday.HasValue && e.Birthday.Value.AddYears(age) <= DateTime.Now)
                .OrderByDescending(e => e.Salary)
                .ToList();

            var empByAgeDto = this.mapper.CreateMappedObject<EmployeesByAgeDto>(employees);

            foreach (var employee in employees)
            {
                var manager = employee.Manager;

                var managerStr = manager == null ? "[no manager]" : $"{manager.FirstName} {manager.LastName}";

                sb.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary} - Manager: {managerStr}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
