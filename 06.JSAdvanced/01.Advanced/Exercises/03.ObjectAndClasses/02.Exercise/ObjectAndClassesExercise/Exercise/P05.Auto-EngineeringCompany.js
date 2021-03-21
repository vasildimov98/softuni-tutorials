function showCarBrandAndModel(carsInfo) {
    let brands = {};
    carsInfo.forEach(carArgs => {
        let [brand, model, quantity] = carArgs
            .split(' | ');

        quantity = Number(quantity);

        let car = {model, quantity}

        if (!brands.hasOwnProperty(brand)) {
            brands[brand] = [];
        }

        if(brands[brand].some(c => c.model == model)) {
            let thisCar = brands[brand].find(c => c.model == model);

            thisCar.quantity += quantity;
        } else {
            brands[brand].push(car);
        }
    });

    Object.keys(brands).forEach(brand => {
        console.log(brand);

        brands[brand].forEach(car => {
            console.log(`###${car.model} -> ${car.quantity}`);
        })
    })
}

showCarBrandAndModel([
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
]
);