using System.Linq;

namespace SolarSystemsFactory.Initial
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
                Name = "Large Solar System",
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
                Name = "Selene",
                OrbitRadius = 90,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 20000
            });
            model.Planets.Add(new Planet
            {
                Name = "Mimas",
                OrbitRadius = 116,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 20000
            });
            model.Planets.Add(new Planet
            {
                Name = "Ares",
                OrbitRadius = 142,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 20000
            });
            model.Planets.Add(new Planet
            {
                Name = "Enceladus",
                OrbitRadius = 168,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 23000
            });
            model.Planets.Add(new Planet
            {
                Name = "Tethys",
                OrbitRadius = 194,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 14000
            });
            model.Planets.Add(new Planet
            {
                Name = "Dione",
                OrbitRadius = 220,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 10000
            });
            model.Planets.Add(new Planet
            {
                Name = "Zeus",
                OrbitRadius = 246,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 53000
            });
            model.Planets.Add(new Planet
            {
                Name = "Rhea",
                OrbitRadius = 272,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 15000
            });
            model.Planets.Add(new Planet
            {
                Name = "Titan",
                OrbitRadius = 298,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 30000
            });
            model.Planets.Add(new Planet
            {
                Name = "Hyperion",
                OrbitRadius = 324,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 28000
            });
            model.Planets.Add(new Planet
            {
                Name = "Iapetus",
                OrbitRadius = 350,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 22000
            });
            model.Planets.Add(new Planet
            {
                Name = "Janus",
                OrbitRadius = 376,
                OrbitStroke = "rgb(1, 192, 255, 0.5)",
                RotationDuration = 24000
            });

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

        public SolarSystemModel CreateSolarSystemFromTwo()
        {
            var ssModel1 = CreateSmallSolarSystem();
            var ssModel2 = CreateSolarSystemWithZeroPlanets();

            foreach (var planet in ssModel1.Planets)
            {
                if (ssModel2.Planets.Any(p => !p.Name.ToLower().Equals(planet.Name.ToLower())))
                {
                    ssModel2.Planets.Add(planet);
                }
            }

            return ssModel2;
        }
    }
}q