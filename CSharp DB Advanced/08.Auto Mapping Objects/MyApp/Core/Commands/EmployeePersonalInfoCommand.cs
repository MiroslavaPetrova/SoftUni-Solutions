using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            //•	EmployeePersonalInfo <employeeId> 

            int employeeId = int.Parse(args[0]);

            Employee targetEmployee = context.Employees
                .FirstOrDefault(e => e.Id == employeeId);

            if (targetEmployee == null)
            {
                throw new ArgumentNullException($"Employee with ID: {employeeId} not found!");
            }

            var employeePersonalInfoDto =
                mapper.CreateMappedObject<EmployeePersonalInfoDto>(targetEmployee);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {employeePersonalInfoDto.Id} - {employeePersonalInfoDto.FirstName} " +
                $"{employeePersonalInfoDto.LastName} - ${employeePersonalInfoDto.Salary:F2}");

            sb.AppendLine($"Birthday: {employeePersonalInfoDto.Birthday.Value}");
            sb.AppendLine($"Address: {employeePersonalInfoDto.Address}");

            return sb.ToString().TrimEnd();
        }
    }
}
