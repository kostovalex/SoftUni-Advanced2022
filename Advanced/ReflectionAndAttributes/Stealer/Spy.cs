using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
        {
            Type type = Type.GetType(className);

            FieldInfo[] fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                .Where(f => fieldsToInvestigate.Contains(f.Name)).ToArray();

            object classInstance = Activator.CreateInstance(type, new object[] { });

            StringBuilder result = new StringBuilder();

            result.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in fieldInfo)
            {
                result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return result.ToString();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name.StartsWith("set")).ToArray();
            MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(m => m.Name.StartsWith("get")).ToArray();

            StringBuilder result = new StringBuilder();

            foreach (FieldInfo field in fields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in nonPublicMethods)
            {
                result.AppendLine($"{method.Name} have to be public");
            }
            foreach (var method in publicMethods)
            {
                result.AppendLine($"{method.Name} have to be private!");
            }

            return result.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}")
                .AppendLine($"Base Class: {type.BaseType}");
            foreach (var method in methods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] getters = methods.Where(m => m.Name.StartsWith("get")).ToArray();
            MethodInfo[] setters = methods.Where(m => m.Name.StartsWith("set")).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var item in getters)
            {
                sb.AppendLine($"{item.Name} will return {item.ReturnType}");
            }
            foreach (var item in setters)
            {             
                sb.AppendLine($"{item.Name} will set field of {item.GetParameters().First().ParameterType}");
            }

            return sb.ToString();
        }

    }
}
