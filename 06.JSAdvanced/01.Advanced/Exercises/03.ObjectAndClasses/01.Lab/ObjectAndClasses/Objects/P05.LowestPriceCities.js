function showTheLowestPriceForProduct(input) {
    let townsWithProducts = [];

    input.forEach(str => {
        let productArgs = str
            .split(' | ');

        let town = productArgs[0];
        let product = productArgs[1];
        let price = Number(productArgs[2]);

        if (townsWithProducts.some(t => t['town'] == town
            && t['product'] == product)) {
            let sameTown = townsWithProducts.find((t) => t['town'] == town
                && t['product'] == product);

                sameTown['price'] = price;
        } else {
            townInfo = {
                'town': town,
                'product': product,
                'price': price,
            }

            townsWithProducts.push(townInfo);
        }
    });

    let finalResult = {};

    townsWithProducts.forEach(t => {
        let currTown = t['town'];
        let currProduct = t['product'];
        let currPrice = t['price'];

        if (!finalResult.hasOwnProperty(currProduct)) {
            finalResult[currProduct] = {
                'price': currPrice,
                'town': currTown,
            }
        } else if (currPrice < finalResult[currProduct]['price']) {
            finalResult[currProduct] = {
                'price': currPrice,
                'town': currTown,
            }
        }
    });

    Object.keys(finalResult).forEach(pr => {
        console.log(`${pr} -> ${finalResult[pr]['price']} (${finalResult[pr]['town']})`);
    })
}

showTheLowestPriceForProduct([
    'Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'
]
);

showTheLowestPriceForProduct([
    'Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'New York City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Mexico City | Audi | 100000',
    'Washington City | Mercedes | 1000'
])