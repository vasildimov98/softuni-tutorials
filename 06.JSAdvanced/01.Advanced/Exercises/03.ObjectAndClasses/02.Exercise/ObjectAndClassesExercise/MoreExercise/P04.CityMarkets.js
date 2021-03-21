function showCitiesMarketData(cityInfo) {
    let cityWithProducts = {};
    cityInfo
        .forEach(args => {
            let [town, product, productArgs] = args
                .split(' -> ');

            let [amountOfSales, priceForOneUnit] = productArgs
                .split(' : ')
                .map(x => Number(x));

            let productPrice = amountOfSales * priceForOneUnit;

            if (!cityWithProducts[town]) {
                cityWithProducts[town] = {};
            }

            if (!cityWithProducts[town][product]) {
                cityWithProducts[town][product] = productPrice;
            }
        });

    Object
        .keys(cityWithProducts)
        .forEach(c => {
            console.log(`Town - ${c}`);

            Object
                .keys(cityWithProducts[c])
                .forEach(p => {
                    console.log(`$$$${p} : ${cityWithProducts[c][p]}`);
                });
        });
}

showCitiesMarketData([
    'Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3'
]
);
