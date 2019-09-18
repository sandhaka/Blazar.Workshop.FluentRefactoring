using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace SolarSystemsFactory
{
    public class SolarSystemModel : ICloneable
    {
        public SolarSystemModel()
        {
            Planets = new List<Planet>();
            TextStyle = new TextStyle();
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("planets")]
        public List<Planet> Planets { get; }
        [JsonProperty("textStyle")]
        public TextStyle TextStyle { get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Cloneable support
        public object Clone()
        {
            var serializedData = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<SolarSystemModel>(serializedData);
        }

        // Summable model support
        public static SolarSystemModel operator +(SolarSystemModel a, SolarSystemModel b)
        {
            var planetsToAdd = b.Planets.Where(pB =>
                !a.Planets.Any(pA =>
                    pA.Name.ToLower().Equals(pB.Name.ToLower())))
                .ToList();

            a.Planets.AddRange(planetsToAdd);
            return a;
        }

        // Sub model support
        public static SolarSystemModel operator -(SolarSystemModel a, SolarSystemModel b)
        {
            var planetsToRemove = a.Planets.Where(pB =>
                b.Planets.Any(pA =>
                    pA.Name.ToLower().Equals(pB.Name.ToLower())))
                .ToList();

            foreach (var planet in planetsToRemove)
            {
                a.Planets.Remove(planet);
            }

            return a;
        }
    }

    public class Planet
    {
        [JsonProperty("rotationDuration")]
        public long RotationDuration { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("orbitRadius")]
        public int OrbitRadius { get; set; }
        [JsonProperty("orbitStroke")]
        public string OrbitStroke { get; set; }
    }

    public class TextStyle
    {
        [JsonProperty("fontFamily")]
        public string FontFamily { get; set; }
        [JsonProperty("fontSize")]
        public int FontSize { get; set; }
        [JsonProperty("bgrColor")]
        public string BgrColor { get; set; }
        [JsonProperty("fillColor")]
        public string FillColor { get; set; }
    }
}