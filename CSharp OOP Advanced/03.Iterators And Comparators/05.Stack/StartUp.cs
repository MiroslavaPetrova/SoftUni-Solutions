namespace Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string action = command.Split()[0];

                switch (action)
                {
                    case "Push":
                        int[] nums = command
                            .Split(new string[] {" ", "," },StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1).Select(int.Parse)
                            .ToArray();
                        stack.Push(nums);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            for (int i = 0; i < 2; i++)
            {
                // Console.WriteLine(string.Join("\n", stack)); or this way instead of foreach
                foreach (var element in stack)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
