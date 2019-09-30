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