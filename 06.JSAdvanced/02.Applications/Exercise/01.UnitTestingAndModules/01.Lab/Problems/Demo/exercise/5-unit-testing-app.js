var calculator = {
    sum: (a, b) => {
        if (a == undefined
            || b == undefined) {
            return 'Incorrect result!';
        }

        return a + b;
    },
    subtract: (a, b) => {
        if (a == undefined
            || b == undefined) {
            return 'Incorrect result!';
        }

        return a - b;
    },
    divide: (a, b) => a / b,
    multiply: (a, b) => a * b,
    pow: (a, b) => a ** b,
};

module.exports = calculator;