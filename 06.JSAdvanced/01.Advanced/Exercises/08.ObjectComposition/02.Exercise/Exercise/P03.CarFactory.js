function createCar({model, power, color, carriage: carriageType, wheelsize}) {
    let engine;
    if (power <= 90) {
        engine = { power: 90, volume: 1800 }
    } else if (power <= 120) {
        engine = { power: 120, volume: 2400 };
    } else {
        engine = { power: 200, volume: 3500 };
    }

    let carriage;
    if (carriageType === 'hatchback') {
        carriage = {
            type: 'hatchback',
            color,
        }
    } else {
        carriage = {
            type: 'coupe',
            color,
        }
    }

    let wheels;
    wheelsize = Math.floor(wheelsize);
    if (wheelsize % 2 != 0) {
        wheels = [wheelsize, wheelsize, wheelsize, wheelsize];
    } else {
        wheelsize--;
        wheels = [wheelsize, wheelsize, wheelsize, wheelsize];
    }

    let car = {
        model,
        engine,
        carriage,
        wheels,
    }

    return car;
}


let firstCar = createCar({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 16.89
}
);

let secondCar = createCar({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
);

console.log(firstCar);
console.log(secondCar);