function getInfoForBuyingFruit(fruit, weight, pricePerKg) {
    let weightInKg = Number(weight) / 1000;
    let money = weightInKg * pricePerKg;

    console.log(`I need $${money.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}

getInfoForBuyingFruit('orange', 2500, 1.80);
getInfoForBuyingFruit('apple', 1563, 2.35);