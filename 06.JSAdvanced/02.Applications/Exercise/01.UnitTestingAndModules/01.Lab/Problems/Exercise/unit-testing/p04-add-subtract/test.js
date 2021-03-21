const assert = require('chai').assert;
const createCalculator = require('./index');

describe('Tests for createCalculator function', () => {
    it('Check if the return value is an object, containing three function', () => {
        //Arrange
        let addKey = 'add';
        let subtractKey = 'subtract';
        let getKey = 'get';

        //Act
        let calculator = createCalculator();
        //Assert
        assert.isObject(calculator);
        assert.containsAllKeys(calculator, [addKey, subtractKey, getKey]);
    });

    it('Check if the internal value cannot be modified from outside', () => {
        //Arrange
        let calculator = createCalculator();
        let internalValue = calculator.get();
        let defaultValue = 0;
        assert.equal(internalValue, defaultValue);

        //Act
        internalValue += 100;

        //Assert
        assert.notEqual(calculator.get(), internalValue);
    });

    it('Check if the internal func add works correctly with number', () => {
        //Arrange
        let calculator = createCalculator();
        let add = calculator.add;
        let numberToAdd = 100;
        let expectedValue = 100;

        //Act
        add(numberToAdd);

        //Assert
        assert.equal(calculator.get(), expectedValue);
    });

    it('Check if the internal func add works correctly with string containing number', () => {
        //Arrange
        let calculator = createCalculator();
        let add = calculator.add;
        let stringWithNumberToAdd = '100';
        let expectedValue = 100;

        //Act
        add(stringWithNumberToAdd);

        //Assert
        assert.equal(calculator.get(), expectedValue);
    });

    it('Check if the internal func subtract works correctly with number', () => {
        //Arrange
        let calculator = createCalculator();
        let subtract = calculator.subtract;
        let numberToSubtract = 100;
        let expectedValue = -100;

        //Act
        subtract(numberToSubtract);

        //Assert
        assert.equal(calculator.get(), expectedValue);
    });

    it('Check if the internal func subtract works correctly with string containing number', () => {
        //Arrange
        let calculator = createCalculator();
        let subtract = calculator.subtract;
        let stringWithNumberToSubtract = '100';
        let expectedValue = -100;

        //Act
        subtract(stringWithNumberToSubtract);

        //Assert
        assert.equal(calculator.get(), expectedValue);
    });

    it('Check if the internal func gets returns the the value of the internal sum', () => {
        //Arrange
        let calculator = createCalculator();
        let subtract = calculator.subtract;
        let add = calculator.add;
        let stringWithNumberToSubtract = '100';
        let stringWithNumberToAdd = '50';
        let expectedValue = -50;

        //Act
        add(stringWithNumberToAdd);
        subtract(stringWithNumberToSubtract);

        //Assert
        assert.equal(calculator.get(), expectedValue);
        assert.isNumber(calculator.get());
    });
});