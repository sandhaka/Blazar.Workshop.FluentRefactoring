namespace SolarSystemsFactory.Refactored
{
    public class Factory2
    {
        /// <summary>
        /// Simple builder
        /// </summary>
        /// <returns></returns>
        public SolarSystemModel CreateSmallSolarSystem()
        {
            var ssBuilder = new SolarSystemBuilder();

            ssBuilder.SetTextStyle();
            ssBuilder.SetTitle("Zero planets");
            ssBuilder.AddPlanet("Alfa", 142, "rgb(1,192,255,0.5)", 15000);
            ssBuilder.AddPlanet("Beta", 180, "rgb(1,192,255,0.5)", 16000);

            return ssBuilder.Model;
        }

        /// <summary>
        /// Use builder fluently
        /// </summary>
        /// <returns></returns>
        public SolarSystemModel CreateSmallSolarSystemFluently()
        {
            var model = FluentSolarSystemBuilder.Create()
                .Init("A small one")
                .AddPlanet("Alfa", 142, "rgb(1,192,255,0.5)", 15000)
                .AddPlanet("Beta", 180, "rgb(1,192,255,0.5)", 16000)
                .GetModel();

            return model;
        }

        /// <summary>
        /// Use reusable builder fluently
        /// </summary>
        /// <returns></returns>
        public SolarSystemModel CreateSmallSolarSystemFluentlyWithReusableBuilder()
        {
            var builder = FluentSolarSystemBuilder.Create().Init("System from two");

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
    }
}