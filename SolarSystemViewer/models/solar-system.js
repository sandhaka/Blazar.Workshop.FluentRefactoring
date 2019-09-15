class SolarSystem {
    planetSize = 26;
    totalPlanets = 0;
    planets = [];
    textStyle = {};

    constructor(json) {
        if (json != null && json.constructor.name === 'Object') {
            this.planets = json.planets;
            this.textStyle = json.textStyle;
            this.totalPlanets = this.planets.length;
            return;
        }
        alert("Valid json has to be supplied in ./../model.json file");
    }
}