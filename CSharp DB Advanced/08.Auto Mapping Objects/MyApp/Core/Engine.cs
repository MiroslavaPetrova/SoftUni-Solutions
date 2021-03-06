﻿using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Contracts;
using System;

namespace MyApp.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider provider;

        public Engine(IServiceProvider provider) // provider contains CommandInterpreter
        {
            this.provider = provider;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var commandInterpreter = this.provider.GetService<ICommandInterpreter>();
                    string result = commandInterpreter.Read(inputArgs);

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
