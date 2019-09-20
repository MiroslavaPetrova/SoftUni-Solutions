using MyApp.Core.Commands.Contracts;
using MyApp.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace MyApp.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] inputArgs)
        {
            string commandName = inputArgs[0].ToLower() + Suffix;
            string[] commandArgs = inputArgs.Skip(1).ToArray(); // should go to CI.Execute(commandArgs);

            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(c => c.Name.ToLower() == commandName);

            if (type == null)
            {
                throw new ArgumentNullException("Command not found!");
            }

            // we must have only ONE ctor and we are searching for it
            var constructor = type.GetConstructors()
                .FirstOrDefault();

            //params here are: context and mapper coming from the serviceProvider
            var constructorParams = constructor.GetParameters()
                .Select(c => c.ParameterType)
                .ToArray();

            var services = constructorParams
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var command = (ICommand)Activator.CreateInstance(type,services);

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
