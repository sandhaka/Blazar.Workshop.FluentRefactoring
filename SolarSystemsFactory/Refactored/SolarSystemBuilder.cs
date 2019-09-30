using System;
using SolarSystemsFactory.Refactored.Utils;

namespace SolarSystemsFactory.Refactored
{
    public class SolarSystemBuilder : ISolarSystemBuilder
    {
        private SolarSystemModel _model = new SolarSystemModel();

        public void SetTitle(string title)
        {
            _model.Name = title;
        }

        public void SetTextStyle(string bgrColor = "#002244", string fillColor = "#fff", int fontSize = 16, string fontFamily = "Open Sans")
        {
            _model.TextStyle.BgrColor = "#002244";
            _model.TextStyle.FillColor = "#fff";
            _model.TextStyle.FontSize = 16;
            _model.TextStyle.FontFamily = fontFamily;
        }

        public void AddPlanet(string name, int orbitRadius, string orbitStroke, long rotationDuration)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new SolarSystemBuilderException("A planet name must be supplied");
            }

            if (orbitRadius <= 0)
            {
                throw new SolarSystemBuilderException("Orbit radius must be greater then 0");
            }

            if (string.IsNullOrEmpty(orbitStroke))
            {
                throw new SolarSystemBuilderException("A orbit stroke must be supplied");
            }

            if (rotationDuration <= 5000 || rotationDuration >= 30000)
            {
                throw new SolarSystemBuilderException("Rotation duration must be from 5000 to 30000");
            }

            _model.Planets.Add(new Planet
            {
                Name = name,
                OrbitRadius = orbitRadius,
                OrbitStroke = orbitStroke,
                RotationDuration = rotationDuration
            });
        }

        public void Reset()
        {
            _model = new SolarSystemModel();
        }

        public SolarSystemModel Model => _model.Clone() as SolarSystemModel;
    }
}