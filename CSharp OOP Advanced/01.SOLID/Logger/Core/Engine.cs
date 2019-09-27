namespace Logger.Core
{
    using Logger.Core.Interfaces;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                this.commandInterpreter.AddAppender(info);
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string [] inputArgs = input.Split('|');

                this.commandInterpreter.AddMessage(inputArgs);

                input = Console.ReadLine();
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
