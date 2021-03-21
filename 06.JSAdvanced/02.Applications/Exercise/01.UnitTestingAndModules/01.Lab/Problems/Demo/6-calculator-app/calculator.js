var calculator = {
    sum: (a, b) => {
        if (a == undefined
            || b == undefined) {
            throw new TypeError('Numbers should be defined!');
        }

        return a + b;
    },
    subtract: (a, b) => {
        if (a == undefined
            || b == undefined) {
            throw new TypeError('Numbers should be defined!');
        }

        return a - b;
    },
    divide: (a, b) => {
        if (a == undefined
            || b == undefined) {
            throw new TypeError('Numbers should be defined!');
        }

        if (b == 0) {
            throw new Error('Cannot divide by zero!!!');
        }

        return a / b;
    },
    multiply: (a, b) => {
        if (a == undefined
            || b == undefined) {
            throw new TypeError('Numbers should be defined!');
        }

        return a * b;
    },
    pow: (a, b) => {
        if (a == undefined
            || b == undefined) {
            throw new TypeError('Numbers should be defined!');
        }

        return a ** b;
    }
};

module.exports = calculator;