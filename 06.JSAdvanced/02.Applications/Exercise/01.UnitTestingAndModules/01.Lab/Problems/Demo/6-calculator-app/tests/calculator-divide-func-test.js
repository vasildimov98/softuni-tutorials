const assert = require('chai').assert;
const divide = require('../calculator').divide;

describe('Test divide func of calculator object', () => {
    it('Two positive numbers should have posite result', () => {
        // Arrange
        let divisable = 12;
        let diviser = 6;
        let expectedPrivately = 2;
        // Act
        let actualPrivately = divide(divisable, diviser);

        // Assert
        assert.equal(actualPrivately, expectedPrivately, `Expected ${actualPrivately} to be equal to ${expectedPrivately}`);
    });

    it('Devide by zero should throw exception', () => {
        // Arrange
        let divisable = 12;
        let diviser = 0;

        // Act and Assert
        assert.throws(() => divide(divisable, diviser), Error, 'Cannot divide by zero!!!');
    });

    it('With two undefined numbers the function should throw TypeError', () => {
        //Arrange
        let firstNum = undefined;
        let secondNum = undefined;
        let errorMsg = `Numbers should be defined!`;

        //Act and Assert
        assert.throws(() => divide(firstNum, secondNum), TypeError, errorMsg);
    });
});