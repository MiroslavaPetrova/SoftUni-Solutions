using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using System;
using System.Linq;
using System.Text;

namespace MyApp.Core.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeeInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            //•	EmployeeInfo <employeeId> 
            int employeeId = int.Parse(args[0]);

            var targetEmployee = context.Employees
                .FirstOrDefault(e => e.Id == employeeId);

            if (targetEmployee == null)
            {
                throw new ArgumentNullException($"Employee with id {employeeId} not found!");
            }

            //todo create dto & export the info from it
            StringBuilder sb = new StringBuilder();
            //ID: {employeeId} - {firstName} {lastName} -  ${salary:f2}
            sb.AppendLine($"ID: {targetEmployee.Id} - {targetEmployee.FirstName} {targetEmployee.LastName}" +
                $" - ${targetEmployee.Salary:F2}");
            return sb.ToString().TrimEnd();
        }
    }
}
