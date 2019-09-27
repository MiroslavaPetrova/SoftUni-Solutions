namespace HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var className = typeof(HarvestingFields);
            var allFields = className.GetFields(BindingFlags.Public
                | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            string command = Console.ReadLine();

            while (command != "HARVEST")
            {
                var filteredFields = allFields      //use reflection instead of switch
                   .Where(f => f.Attributes.ToString()
                   .ToLower()
                   .Replace("family", "protected") == command)
                   .ToArray();

                if (command != "all")
                {
                    foreach (var field in filteredFields)
                    {
                        Console.WriteLine
                            ($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} " +
                             $"{field.FieldType.Name} " +
                             $"{field.Name}");
                    }
                }
                else
                {
                    foreach (var field in allFields)
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} " +
                            $"{field.FieldType.Name} " +
                            $"{field.Name}");
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
