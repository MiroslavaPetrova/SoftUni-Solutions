    using System.Text;
    using System.Reflection;
    using System;
    using System.Linq;

    public class Spy
    {
        public string StealFieldInfo(string classType, params string [] fields)
        {
            StringBuilder sb = new StringBuilder();

            var className = Type.GetType(classType);
            sb.AppendLine($"Class under investigation: {className}");
            var hackerInstance = Activator.CreateInstance(className);
        var allFieldsInfo = className.GetFields(BindingFlags.Public
            | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        //var allFieldsInfo = className.GetFields((BindingFlags)62);
        foreach (var field in allFieldsInfo.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(hackerInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
