using System;

namespace SolarSystemsFactory.Refactored.Fluent
{
    public interface ISsBuilderCreated
    {
    }

    public interface ISsBuilderInitialized
    {
    }

    // Use composition to add features
    public class FluentSolarSystemBuilder :
        ISsBuilderCreated,
        ISsBuilderInitialized,
        ISolarSystemBuilder
    {
        private readonly ISolarSystemBuilder _solarSystemBuilder;

        public Action<Exception> ExceptionHandler { get; set; } = exception => throw exception;

        public static ISsBuilderCreated Create(ISolarSystemBuilder builder)
        {
            return new FluentSolarSystemBuilder(builder);
        }

        private FluentSolarSystemBuilder(ISolarSystemBuilder builder)
        {
            _solarSystemBuilder = builder;
        }

        public void Init(string title, string bgrColor = "#002244", string fillColor = "#fff", int fontSize = 16,
            string fontFamily = "Open Sans")
        {
            _solarSystemBuilder.SetTextStyle(bgrColor, fillColor, fontSize, fontFamily);
            _solarSystemBuilder.SetTitle(title);
        }

        /* Wrapped methods */

        public void SetTitle(string title)
        {
            _solarSystemBuilder.SetTitle(title);
        }

        public void SetTextStyle(string bgrColor = "#002244", string fillColor = "#fff", int fontSize = 16,
            string fontFamily = "Open Sans")
        {
            _solarSystemBuilder.SetTextStyle(bgrColor, fillColor, fontSize, fontFamily);
        }

        public void AddPlanet(string name, int orbitRadius, string orbitStroke, long rotationDuration)
        {
            try
            {
                _solarSystemBuilder.AddPlanet(name, orbitRadius, orbitStroke, rotationDuration);
            }
            catch (Exception e)
            {
                ExceptionHandler.Invoke(e);
            }
        }

        public void Reset()
        {
            _solarSystemBuilder.Reset();
        }

        public SolarSystemModel Model => _solarSystemBuilder.Model;
    }

    public static class BuilderFluentDirectorExtensions
    {
        public static ISsBuilderInitialized Init(
            this ISsBuilderCreated builder,
            string title,
            string bgrColor = "#002244",
            string fillColor = "#fff",
            int fontSize = 16,
            string fontFamily = "Open Sans")
        {
            var myBuilder = (FluentSolarSystemBuilder)builder;
            myBuilder.Init(title, bgrColor, fillColor, fontSize, fontFamily);
            return myBuilder;
        }

        public static ISsBuilderInitialized AddPlanet(
            this ISsBuilderInitialized builder,
            string name,
            int orbitRadius,
            string orbitStroke,
            long rotationDuration)
        {
            var myBuilder = (FluentSolarSystemBuilder)builder;
            myBuilder.AddPlanet(name, orbitRadius, orbitStroke, rotationDuration);
            return myBuilder;
        }

        public static ISsBuilderInitialized HandleEception(
            this ISsBuilderInitialized builder,
            Action<Exception> handler)
        {
            var myBuilder = (FluentSolarSystemBuilder)builder;
            myBuilder.ExceptionHandler = handler;
            return myBuilder;
        }

        public static SolarSystemModel GetModel(this ISsBuilderInitialized builder)
        {
            var myBuilder = (FluentSolarSystemBuilder)builder;
            return myBuilder.Model;
        }

        public static SolarSystemModel GetModelAndReset(this ISsBuilderInitialized builder)
        {
            var myBuilder = (FluentSolarSystemBuilder)builder;
            var model = myBuilder.Model;
            myBuilder.Reset();
            return model;
        }
    }
}