using System;
using SolarSystemsFactory.Refactored.Fluent;
using SolarSystemsFactory.Refactored.Utils;

namespace SolarSystemsFactory.Refactored
{
    public class Factory2
    {
        private ISolarSystemBuilder _builder = new SolarSystemBuilder();

        /// <summary>
        /// Simple builder
        /// </summary>
        public SolarSystemModel CreateSmallSolarSystem()
        {
            _builder.SetTextStyle();
            _builder.SetTitle("Zero planets");
            _builder.AddPlanet("Alfa", 142, "rgb(1,192,255,0.5)", 15000);
            _builder.AddPlanet("Beta", 180, "rgb(1,192,255,0.5)", 16000);

            return _builder.Model;
        }

        /// <summary>
        /// Use builder fluently
        /// </summary>
        public SolarSystemModel CreateSmallSolarSystemFluently()
        {
            var model = FluentSolarSystemBuilder.Create(_builder)
                .Init("A small one")
                .AddPlanet("Alfa", 142, "rgb(1,192,255,0.5)", 15000)
                .AddPlanet("Beta", 180, "rgb(1,192,255,0.5)", 16000)
                .GetModel();

            return model;
        }

        /// <summary>
        /// Use reusable builder fluently
        /// </summary>
        public SolarSystemModel CreateSmallSolarSystemFluentlyWithReusableBuilder()
        {
            var builder = FluentSolarSystemBuilder.Create(_builder).Init("System from two");

            var model1 = builder
                .AddPlanet("Alfa", 142, "rgb(1,192,255,0.5)", 15000)
                .AddPlanet("Beta", 180, "rgb(1,192,255,0.5)", 16000)
                .GetModelAndReset();

            var model2 = builder
                .AddPlanet("Gamma", 192, "rgb(1,192,255,0.5)", 18000)
                .AddPlanet("Teta", 220, "rgb(1,192,255,0.5)", 20000)
                .AddPlanet("Beta", 180, "rgb(1,192,255,0.5)", 16000)
                .GetModel();

            return model1 - model2;
        }

        public SolarSystemModel CreateLargeSolarSystemFluently()
        {
            return FluentSolarSystemBuilder.Create(_builder)
                .Init("Large one")
                .HandleEception(e =>
                {
                    if (e is SolarSystemBuilderException solarSystemBuilderException)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();
                        Console.WriteLine($"=========== BuilderException {e.TargetSite.Name} occurred ===========");
                        Console.WriteLine(solarSystemBuilderException.ComposedMessage);
                        Console.WriteLine("=================================================");
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine($"=========== Exception {e.TargetSite.Name} occurred ===========");
                        Console.WriteLine(e.Message);
                        Console.WriteLine("==========================================");
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                })
                .AddPlanet("Selene", 90, "rgb(1, 192, 255, 0.5)", 20000)
                .AddPlanet("Mimas", 116, "rgb(1, 192, 255, 0.5)", 20000)
                .AddPlanet("Ares", 142, "rgb(1, 192, 255, 0.5)", 20000)
                .AddPlanet("Enceladus", 168, "rgb(1, 192, 255, 0.5)", 23000)
                .AddPlanet("Tethys", 194, "rgb(1, 192, 255, 0.5)", 14000)
                .AddPlanet("Dione", 220, "rgb(1, 192, 255, 0.5)", 10000)
                .AddPlanet("Zeus", 246, "rgb(1, 192, 255, 0.5)", 53000)
                .AddPlanet("Rhea", 272, "rgb(1, 192, 255, 0.5)", 15000)
                .AddPlanet("Titan", 298, "rgb(1, 192, 255, 0.5)", 30000)
                .AddPlanet("Hyperion", 324, "rgb(1, 192, 255, 0.5)", 28000)
                .AddPlanet("Iapetus", 350, "rgb(1, 192, 255, 0.5)", 22000)
                .AddPlanet("Janus", 376, "rgb(1, 192, 255, 0.5)", 24000)
                .GetModel();
        }
    }
}