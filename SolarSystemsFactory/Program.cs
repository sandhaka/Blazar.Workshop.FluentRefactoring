using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SolarSystemsFactory
{
    internal class Factory
    {
        public SolarSystemModel CreateSmallSolarSystem()
        {
            var model = new SolarSystemModel
            {
                Name = "Zero planets",
                TextStyle =
                {
                    BgrColor = "#002244",
                    FillColor = "#fff",
                    FontSize = 16,
                    FontFamily = "Open Sans"
                }
            };

            model.Planets.Add(new Planet
            {
                Name = "Alfa",
                OrbitRadius = 142,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 15000
            });

            model.Planets.Add(new Planet
            {
                Name = "Beta",
                OrbitRadius = 180,
                OrbitStroke = "rgb(1, 200, 255, 0.7)",
                RotationDuration = 16000
            });

            return model;
        }

        public SolarSystemModel CreateLargeSolarSystem()
        {
            var model = new SolarSystemModel
            {
                Name = "Zero planets",
                TextStyle =
                {
                    BgrColor = "#002244",
                    FillColor = "#fff",
                    FontSize = 16,
                    FontFamily = "Open Sans"
                }
            };

            return model;
        }

        public SolarSystemModel CreateSolarSystemWithZeroPlanets()
        {
            var model = new SolarSystemModel
            {
                Name = "Zero planets",
                TextStyle =
                {
                    BgrColor = "#002244",
                    FillColor = "#fff",
                    FontSize = 16,
                    FontFamily = "Open Sans"
                }
            };

            return model;
        }
    }

    #region Program startup

    class Program
    {
        static void Main(string[] args)
        {
            var method = ParseArguments.Method(args);
            Console.WriteLine($"Create new model with method: {method}.");
            var model = ExecuteFactoryMethod.Call(method) as SolarSystemModel;
            Console.WriteLine($"Model: {model}");

            File.WriteAllText("../../../../model.json", model?.ToString());
        }
    }

    internal static class ExecuteFactoryMethod
    {
        public static object Call(string method)
        {
            var fType = typeof(Factory);
            var factory = Activator.CreateInstance(fType);
            var model = fType.GetMethod(method)?.Invoke(factory, null);
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
    }

    #endregion
}