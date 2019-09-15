/**
 * Solar System loader
 * @param jsonData
 */
function loadSolarSystem(jsonData) {

    solarSystemModel = new SolarSystem(jsonData);

    let orbits = [];
    let planets = [];

    let canvas = this.__canvas = new fabric.Canvas('c', {
        hoverCursor: 'pointer',
        selection: false,
        perPixelTargetFind: true,
        targetFindTolerance: 5
    });

    // load sun and center it
    fabric.Image.fromURL('./assets/sun.png', function(sunImg) {
        canvas.add(sunImg);
        sunImg.center();
    });

    let hoverCircle = new fabric.Circle({
        radius: 13,
        fill: '#000',
        stroke: 'rgb(0,192,255)',
        strokeWidth: 3,
        left: -100,
        top: -100
    });

    let planetLabel = new fabric.Text('', {
        fill: solarSystemModel.textStyle.fill,
        fontSize: solarSystemModel.textStyle.fontSize,
        fontFamily: solarSystemModel.textStyle.fontFamily,
        textBackgroundColor: solarSystemModel.textStyle.textBgColor
    });

    // load sprite with planets
    fabric.Image.fromURL('./assets/planets.png', (planetsImg) => {

        // temp canvas to generate planet images
        let tempCanvas = new fabric.StaticCanvas();

        // only to fit one planet onto temp canvas
        tempCanvas.setDimensions({
            width: solarSystemModel.planetSize,
            height: solarSystemModel.planetSize
        });

        // make sure image is drawn from left/top corner
        planetsImg.originX = 'left';
        planetsImg.originY = 'top';

        // add it onto temp canvas
        tempCanvas.add(planetsImg);

        for (let i = 0; i < solarSystemModel.totalPlanets; i++) {
            createOrbit(solarSystemModel.planets[i], i);
        }
        canvas.add(hoverCircle);

        for (let i = 0; i < solarSystemModel.totalPlanets; i++) {
            createPlanet(i, planetsImg, tempCanvas, solarSystemModel.planets[i].name);
        }

        canvas.add(planetLabel);
    });

    function createOrbit(planet, index) {
        let orbit = new fabric.Circle({
            radius: planet.orbitRadius,
            left: canvas.getWidth() / 2,
            top: canvas.getHeight() / 2,
            fill: '',
            stroke: planet.orbitStroke,
            hasBorders: false,
            hasControls: false,
            lockMovementX: true,
            lockMovementY: true,
            index: index
        });
        canvas.add(orbit);
        orbits.push(orbit);
    }

    function createPlanet(i, planetsImg, tempCanvas, planetName) {

        // offset planets sprite to fit each of the planets onto it
        planetsImg.left = - solarSystemModel.planetSize * i;

        planetsImg.setCoords();
        tempCanvas.renderAll();

        // get data url for that planet
        let img = new Image();
        img.onload = function() {
            // create image of a planet from data url
            let oImg = new fabric.Image(img, {

                name: planetName,
                index: i,
                scaleX: 1 / canvas.getRetinaScaling(),
                scaleY: 1 / canvas.getRetinaScaling(),
                // position planet 90px from canvas center and 26px from previous planet
                left: (canvas.getWidth() / 2) - 90 - (solarSystemModel.planetSize * i),
                top: canvas.getHeight() / 2,

                // remove borders and corners but leaving object available for events
                hasBorders: false,
                hasControls: false
            });
            canvas.add(oImg);
            planets.push(oImg);
            animatePlanet(oImg, i, solarSystemModel);
        };
        img.src = tempCanvas.toDataURL();
    }

    function animatePlanet(oImg, planetIndex, model) {

        let radius = model.planets[planetIndex].orbitRadius,

            // rotate around canvas center
            cx = canvas.getWidth() / 2,
            cy = canvas.getHeight() / 2,

            // speed of rotation slows down for further planets
            duration = (planetIndex + 1) * model.planets[planetIndex].rotationDuration,

            // randomize starting angle to avoid planets starting on one line
            startAngle = fabric.util.getRandomInt(-180, 0),
            endAngle = startAngle + 359;

        (function animate() {

            fabric.util.animate({
                startValue: startAngle,
                endValue: endAngle,
                duration: duration,

                // linear movement
                easing: function(t, b, c, d) { return c*t/d + b; },

                onChange: function(angle) {
                    angle = fabric.util.degreesToRadians(angle);

                    const x = cx + radius * Math.cos(angle);
                    const y = cy + radius * Math.sin(angle);

                    oImg.set({ left: x, top: y }).setCoords();

                    // only render once
                    if (planetIndex === model.totalPlanets - 1) {
                        canvas.renderAll();
                    }
                },
                onComplete: animate
            });
        })();
    }

    let hoverTarget, prevHoverTarget;

    canvas.on('mouse:over', function(options) {
        hoverTarget = options.target;
    });

    canvas.on('mouse:out', function(options) {
        hoverTarget = null;
        prevHoverTarget = options.target;
    });

    canvas.on('after:render', () => {
        orbits.forEach((orbit) => {
            orbit.set({
                strokeWidth: 1,
                stroke: 'rgb(0,192,255)'
            });
        });
        if (hoverTarget && hoverTarget.index >= 0) {

            const hoveredPlanet = planets[hoverTarget.index];
            const hoveredOrbit = orbits[hoveredPlanet.index];

            hoveredOrbit.set({
                strokeWidth: 3,
                stroke: 'rgb(0,192,255)'
            });

            hoverCircle.set({
                left: hoveredPlanet.left,
                top: hoveredPlanet.top
            });

            planetLabel.set({
                left: hoveredPlanet.left + 50,
                top: hoveredPlanet.top + 20,
                text: hoveredPlanet.name
            });
        }
        else {
            hoverCircle.set({ left: -100, top: -100 });
            planetLabel.set({ left: -100, top: -100 });
        }
    });
}

//#region Model loader

const fs = require('fs');
const jsonExists = fs.existsSync('./../model.json');
let jsonData = '';
let solarSystemModel = {};

if (jsonExists) {
    jsonData = require('./../model.json');
}

document.addEventListener('DOMContentLoaded', () => {
    fabric.Object.prototype.originX = fabric.Object.prototype.originY = 'center';
    loadSolarSystem(jsonData);
});

// // Debug only
// document.addEventListener('keydown', (eventData) => {
//     if (eventData.key === 'j') {
//         console.log("Model: ");
//         console.log(JSON.stringify(solarSystemModel));
//     }
// });

//#endregion