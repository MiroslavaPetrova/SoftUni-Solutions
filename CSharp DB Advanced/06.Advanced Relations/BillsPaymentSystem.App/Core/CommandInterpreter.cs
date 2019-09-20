using BillsPaymentSystem.App.Core.Commands.Contracts;
using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using System;
using System.Linq;
using System.Reflection;

namespace BillsPaymentSystem.App.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";

        public string Read(string[] inputArgs, BillsPaymentSystemContext context)
        {
            //UserInfo + Command 1
            //Deposit + Command 1 200lw

            string command = inputArgs[0];
            string [] args = inputArgs.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == command + Suffix);   // ToLower() !!!

            if (type == null)
            {
                throw new ArgumentNullException("Command not found!");
            }

            var typeInstance = Activator.CreateInstance(type, context);

            var result = ((ICommand)typeInstance).Execute(args);

            return result;
        }
    }
}
