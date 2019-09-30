namespace SolarSystemsFactory.Refactored
{
    public interface ISolarSystemBuilder
    {
        void SetTitle(string title);
        void SetTextStyle(string bgrColor = "#002244", string fillColor = "#fff", int fontSize = 16, string fontFamily = "Open Sans");
        void AddPlanet(string name, int orbitRadius, string orbitStroke, long rotationDuration);
        void Reset();
        SolarSystemModel Model { get; }
    }
}