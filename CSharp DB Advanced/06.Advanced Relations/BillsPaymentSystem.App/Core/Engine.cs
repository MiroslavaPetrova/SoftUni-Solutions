using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using System;

namespace BillsPaymentSystem.App.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine().ToLower()          // ToLower() the input
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
                    {
                        string result = this.commandInterpreter.Read(inputArgs, context);

                        Console.WriteLine(result);
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
            }
        }
    }
}
