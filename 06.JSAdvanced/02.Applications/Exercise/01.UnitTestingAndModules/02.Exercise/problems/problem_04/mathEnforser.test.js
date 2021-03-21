let assert = require('chai').assert;
let { addFive, subtractTen, sum } = require('./mathEnforcer');

describe('Tests for mathEnforecer object', () => {
    describe('Tests for addFive function', () => {
        it('Should return undefined value if passed parameter is not a number', () => {
            //Arrange
            let non_numberParameter = 'not a number';

            //Act
            let funcResult = addFive(non_numberParameter);

            //Assert
            assert.isUndefined(funcResult);
        });

        it('Should return correct result with positive number', () => {
            //Arrange
            let positiveNumber = 10;
            let expectedResult = positiveNumber + 5;

            //Act
            let actualResult = addFive(positiveNumber);

            //Assert
            assert.equal(actualResult, expectedResult);
        });

        it('Should return correct result with negative number', () => {
            //Arrange
            let negativeNumber = -10;
            let expectedResult = negativeNumber + 5;

            //Act
            let actualResult = addFive(negativeNumber);

            //Assert
            assert.equal(actualResult, expectedResult);
        });

        it('Should return correct result with floating number', () => {
            //Arrange
            let floatingNumber = 10.10;
            let delta = 0.01;
            let expectedResult = floatingNumber + 5;

            //Act
            let actualResult = addFive(floatingNumber);

            //Assert
            assert.closeTo(actualResult, expectedResult, delta);
        });
    });

    describe('Tests for subtractTen function', () => {
        it('Should return undefined value if passed parameter is not a number', () => {
            //Arrange
            let non_numberParameter = 'not a number';

            //Act
            let funcResult = subtractTen(non_numberParameter);

            //Assert
            assert.isUndefined(funcResult);
        });

        it('Should return correct result with positive number', () => {
            //Arrange
            let positiveNumber = 10;
            let expectedResult = positiveNumber - 10;

            //Act
            let actualResult = subtractTen(positiveNumber);

            //Assert
            assert.equal(actualResult, expectedResult);
        });

        it('Should return correct result with negative number', () => {
            //Arrange
            let negativeNumber = -10;
            let expectedResult = negativeNumber - 10;

            //Act
            let actualResult = subtractTen(negativeNumber);

            //Assert
            assert.equal(actualResult, expectedResult);
        });

        it('Should return correct result with floating number', () => {
            //Arrange
            let floatingNumber = 10.10;
            let delta = 0.01;
            let expectedResult = floatingNumber - 10;

            //Act
            let actualResult = subtractTen(floatingNumber);

            //Assert
            assert.closeTo(actualResult, expectedResult, delta);
        });
    });

    describe('Tests for sum function', () => {
        it('Should return undefined value if first parameter is not a number', () => {
            //Arrange
            let firstNon_numberParameter = 'not a number';
            let secondNumber = 10;

            //Act
            let funcResult = sum(firstNon_numberParameter, secondNumber);

            //Assert
            assert.isUndefined(funcResult);
        });

        it('Should return undefined value if second parameter is not a number', () => {
            //Arrange
            let firstNum = 10;
            let secondNon_numberParameter = 'not a number';

            //Act
            let funcResult = sum(firstNum, secondNon_numberParameter);

            //Assert
            assert.isUndefined(funcResult);
        });

        it('Should return correct result with positive numbers', () => {
            //Arrange
            let firstPositiveNumber = 42;
            let secondPositiveNumber = 12;
            let expectedResult = firstPositiveNumber + secondPositiveNumber;

            //Act
            let actualResult = sum(firstPositiveNumber, secondPositiveNumber);

            //Assert
            assert.equal(actualResult, expectedResult);
        });

        it('Should return correct result with negative numbers', () => {
            //Arrange
            let firstNegativeNumber = -42;
            let secondNegativeNumber = -12;
            let expectedResult = firstNegativeNumber + secondNegativeNumber;

            //Act
            let actualResult = sum(firstNegativeNumber, secondNegativeNumber);

            //Assert
            assert.equal(actualResult, expectedResult);
        });

        it('Should return correct result with floating numbers', () => {
            //Arrange
            let firstFloatingNumber = 42.123;
            let secondFloatingNumber = -12.3123;
            let delta = 0.01;
            let expectedResult = firstFloatingNumber + secondFloatingNumber;

            //Act
            let actualResult = sum(firstFloatingNumber, secondFloatingNumber);

            //Assert
            assert.closeTo(actualResult, expectedResult, delta);
        });
    });
});