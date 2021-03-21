function createCars(carCommandArgs) {
    let carsFactory = (function () {
        let cars = {};
        return {
            create: (name, parentName) => {
                cars[name] = {};
                if (cars[parentName]) {
                    let parent = cars[parentName];

                    cars[name] = Object.create(parent);
                }
            },
            set: (name, key, value) => {
                cars[name][key] = value;
            },
            print: name => {
                let carKeyValuePairs = [];
                let currCar = cars[name];

                Object
                    .keys(currCar)
                    .forEach(k => carKeyValuePairs
                        .push(`${k}:${currCar[k]}`));
                let carPrototypeObject = Object
                    .getPrototypeOf(currCar);

                while (carPrototypeObject) {
                    Object
                        .keys(carPrototypeObject)
                        .forEach(k => carKeyValuePairs
                            .push(`${k}:${currCar[k]}`));
                    carPrototypeObject = Object.getPrototypeOf(carPrototypeObject);
                }

                console.log(carKeyValuePairs.join(', '));
            }
        }
    })();

    carCommandArgs
        .forEach(args => {
            let [command, name, ...others] = args.split(' ');
            if (command == 'create') {
                let parentName = others[1];
                carsFactory.create(name, parentName);
            } else if (command == 'set') {
                let key = others[0];
                let value = others[1];
                carsFactory.set(name, key, value);
            } else {
                carsFactory.print(name);
            }
        });
}

// createCars([
//     'create c1',
//     'create c2 inherit c1',
//     'set c1 color red',
//     'set c2 model new',
//     'print c1',
//     'print c2'
// ]
// );

let commands = ['create pesho', 'create gosho inherit pesho', 'create stamat inherit gosho', 'set pesho rank number1', 'set gosho nick goshko', 'print stamat'];

createCars(commands);
