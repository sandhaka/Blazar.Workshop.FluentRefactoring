using System.Collections.Generic;
using Newtonsoft.Json;

namespace SolarSystemsFactory
{
    public class SolarSystemModel
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
            return JsonConvert.SerializeObject(this, Formatting.Indented);
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