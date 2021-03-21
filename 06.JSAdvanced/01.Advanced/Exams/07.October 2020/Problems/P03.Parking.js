class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
        this.countOfCars = 0;
        //TODO more ??
    }

    addCar(carModel, carNumber) {
        if (this.countOfCars + 1 > this.capacity) {
            throw new Error('Not enough parking space.');
        }


        let car = {
            carModel,
            carNumber,
            payed: false,
        };

        this.vehicles
            .push(car);

        this.countOfCars++;
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let car = this
            .vehicles
            .find(c => c.carNumber == carNumber);

        if (!car) {
            throw new Error('The car, you\'re looking for, is not found.');
        }

        if (!car.payed) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }

        this.vehicles
            .splice(this.vehicles.indexOf(car), 1);
        this.countOfCars--;
        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        let car = this
            .vehicles
            .find(c => c.carNumber == carNumber);

        if (!car) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        if (car.payed) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        car.payed = true;
        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        if (carNumber) {
            let c = this
                .vehicles
                .find(c => c.carNumber == carNumber);

            return `${c.carModel} == ${c.carNumber} - ${c.payed ?
                'Has payed' :
                'Not payed'}`;
        }

        let result = [];

        result
            .push(`The Parking Lot has ${this.capacity - this.countOfCars} empty spots left.`);

        this
            .vehicles
            .sort((c1, c2) => {
                return c1.carModel
                    .localeCompare(c2.carModel);
            }).forEach(c => {
                result.push(`${c.carModel} == ${c.carNumber} - ${c.payed ?
                    'Has payed' :
                    'Not payed'}`);
            });

        return result
            .join('\n');
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));


// Corresponding output
// The Volvo t600, with a registration number TX3691CA, parked.
// The Parking Lot has 11 empty spots left.
// Volvo t600 == TX3691CA - Not payed
// TX3691CA's driver successfully payed for his stay.
// TX3691CA left the parking lot.