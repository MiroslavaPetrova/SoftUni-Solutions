namespace ListyIterator
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] createCommand = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();
            ListyIterator<string> list = new ListyIterator<string>(createCommand);

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException ie)
                        {
                            Console.WriteLine(ie.Message);
                        }
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
