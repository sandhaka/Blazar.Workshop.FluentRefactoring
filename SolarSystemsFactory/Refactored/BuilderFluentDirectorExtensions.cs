using System;
using Newtonsoft.Json;

namespace SolarSystemsFactory.Refactored
{
    public interface ISsBuilderCreated
    {
    }

    public interface ISsBuilderInitialized
    {
    }

    public class FluentSolarSystemBuilder : SolarSystemBuilder,
        ISsBuilderCreated,
        ISsBuilderInitialized
    {
        public static ISsBuilderCreated Create()
        {
            return new FluentSolarSystemBuilder();
        }

        public void Init(string title, string bgrColor = "#002244", string fillColor = "#fff", int fontSize = 16,
            string fontFamily = "Open Sans")
        {
            SetTextStyle(bgrColor, fillColor, fontSize, fontFamily);
            SetTitle(title);
        }
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