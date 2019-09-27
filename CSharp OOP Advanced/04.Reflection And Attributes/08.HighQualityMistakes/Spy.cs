using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        var type = Type.GetType(className);
        var privateFieldsInfo = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        var privateMethodsInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        var publicMethodsInfo = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();

        foreach (var field in privateFieldsInfo)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in privateMethodsInfo.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in publicMethodsInfo.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().TrimEnd(); 
    }
}

