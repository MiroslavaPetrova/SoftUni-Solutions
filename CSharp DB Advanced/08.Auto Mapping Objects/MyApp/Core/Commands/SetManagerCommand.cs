using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using System;

namespace MyApp.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly MyAppContext context;

        public SetManagerCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            //•	SetManager <employeeId> <managerId> 

            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            var employee = this.context.Employees.Find(employeeId);
            var manager = this.context.Employees.Find(managerId);

            if (employee == null)
            {
                throw new ArgumentNullException($"Employee with ID: {employeeId} not found!");
            }

            if (manager == null)
            {
                throw new ArgumentNullException($"Manager with ID: {managerId} not found!");
            }

            employee.Manager = manager;
            this.context.SaveChanges();

            return "Command completed successfully!";
        }
    }
}
