function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}

let calculator = createCalculator();

let totalValue = calculator.get();

totalValue += 21;

console.log(totalValue);

console.log(calculator.get());

module.exports = createCalculator;