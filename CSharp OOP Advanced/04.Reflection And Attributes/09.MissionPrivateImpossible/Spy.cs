using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        var type = Type.GetType(className);
        var privateMethodsInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {type}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in privateMethodsInfo)
        {
            sb.AppendLine($"{method.Name}");
        }

        return sb.ToString().TrimEnd();
    }
}

