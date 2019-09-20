using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Linq;

namespace MyApp.Core.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public AddEmployeeCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            //this.context.Database.EnsureDeleted();
            //this.context.Database.EnsureCreated();

            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            Employee employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            // todo IsValidMethod() = required props
            // do not add it if it already exists in db
            string employeeFullName = firstName + " " + lastName;

            if (context.Employees.Any(e => e.FirstName == employee.FirstName
            && e.LastName == employee.LastName))
            {
                throw new InvalidOperationException($"Employee with name {employeeFullName} already exists!");
            }

            context.Employees.Add(employee);
            context.SaveChanges();

            var employeeDto = mapper.CreateMappedObject<EmployeeDto>(employee);

            string result = $"Successfully registered {employeeDto.FirstName} {employeeDto.LastName}" +
                $" - {employeeDto.Salary}!";

            return result.ToString().TrimEnd();
        }
    }
}
