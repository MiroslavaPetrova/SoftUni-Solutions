namespace InfernoInfinity
{
    using InfernoInfinity.Core;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                engine.InterpretCommand(input);
            }
        }
    }
}
