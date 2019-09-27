namespace BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);

            var classInstance = (BlackBoxInteger)Activator.CreateInstance(type, true);
            
            string info = Console.ReadLine();

            while (info != "END")
            {
                string command = info.Split("_")[0];
                int objectValue = int.Parse(info.Split("_")[1]);

                var methodName = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(m => m.Name == command);

                methodName.Invoke(classInstance, new object[] { objectValue });

                var result = type
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(f => f.Name == "innerValue")
                    .GetValue(classInstance);

                Console.WriteLine(result);

                info = Console.ReadLine();
            }
        }
    }
}
