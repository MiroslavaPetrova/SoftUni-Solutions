using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using System.Linq;

namespace MyApp.Core.Commands
{
    public class SetAddressCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetAddressCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            //•	SetAddress <employeeId> <address> 

            int employeeId = int.Parse(args[0]);
            string employeeAddress = args[1];

            var targetEmployee = context.Employees
                .FirstOrDefault(e => e.Id == employeeId);

            var oldAddress = targetEmployee.Address;

            targetEmployee.Address = employeeAddress;

            context.SaveChanges();

            //todo create dto
            string result = $"Address {oldAddress} was successfully changed to {employeeAddress}";

            return result;
        }
    }
}
