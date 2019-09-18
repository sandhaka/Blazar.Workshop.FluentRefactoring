using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SolarSystemsFactory.Initial;
using SolarSystemsFactory.Refactored;

namespace SolarSystemsFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var method = ParseArguments.Method(args);
            var factoryType = ParseArguments.Factory(args);
            Console.WriteLine($"Create new model with method: {method}.");
            var model = ExecuteFactoryMethod.Call(method, factoryType) as SolarSystemModel;
            Console.WriteLine($"Model: {model}");

            File.WriteAllText("../../../../model.json", model?.ToString());
        }
    }

    internal static class ExecuteFactoryMethod
    {
        public static object Call(string method, Type factoryType)
        {
            var factory = Activator.CreateInstance(factoryType);
            var model = factoryType.GetMethod(method)?.Invoke(factory, null);
            return model;
        }
    }

    internal class ParseArguments
    {
        public static string Method(string[] args)
        {
            foreach (var arg in args)
            {
                if (Regex.Match(arg.ToLower(), "--use:.*").Success)
                {
                    return arg.Split(':').Last();
                }
            }

            return string.Empty;
        }

        public static Type Factory(string[] args)
        {
            foreach (var arg in args)
            {
                if (Regex.Match(arg.ToLower(), "--factory:.*").Success)
                {
                    var typeName = arg.Split(':').Last();
                    switch (typeName)
                    {
                        case "Factory": return typeof(Factory);
                        case "Factory2": return typeof(Factory2);
                    }
                }
            }

            throw new ArgumentException("--factory:");
        }
    }
}