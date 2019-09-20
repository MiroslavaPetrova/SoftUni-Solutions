using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MyApp.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetBirthdayCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //•	SetBirthday <employeeId> <date: "dd-MM-yyyy">

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            string inputDate = args[1];

            DateTime date = DateTime.ParseExact(inputDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var targetEmployee = context.Employees
                .FirstOrDefault(e => e.Id == employeeId);

            targetEmployee.Birthday = date;
            context.SaveChanges();

            var employeeDtoBirthday = mapper.CreateMappedObject<EmployeeDtoBirthday>(targetEmployee);

            string result = $"Birthdate {employeeDtoBirthday.Birthday} was successfully set " +
                $"to employee with ID {employeeDtoBirthday.Id}.";

            return result;
        }
    }
}
