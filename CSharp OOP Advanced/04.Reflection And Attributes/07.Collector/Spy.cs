using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        var type = Type.GetType(className);
        var methodsInfo = type.GetMethods((BindingFlags)62);

        StringBuilder sb = new StringBuilder();

        foreach (var method in methodsInfo.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methodsInfo.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of" +
                $" {method.GetParameters().FirstOrDefault().ParameterType}");
        }                  // check it out

        return sb.ToString().TrimEnd();
    }
}

