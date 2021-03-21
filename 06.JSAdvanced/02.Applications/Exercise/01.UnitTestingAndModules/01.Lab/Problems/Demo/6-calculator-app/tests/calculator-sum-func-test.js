const assert = require('chai').assert;
const calculator = require('../calculator');

let sum = calculator.sum;

describe('TestSumFunction', () => {
    it('Two positive numbers should return a posite collectible', () => {
        //Arrange
        let firstNum = 5;
        let secondNum = 6;
        let expectedResult = 11;
        
        //Act
        let collectible = sum(firstNum, secondNum);
        let errorMsg = `Incorrect result. Expexted ${collectible} to be equal to ${expectedResult}`;

        //Assert
        assert.equal(collectible, expectedResult, errorMsg);
    });

    it('Two negative numbers should return a negative collectible', () => {
        //Arrange
        let firstNum = -5;
        let secondNum = -6;
        let expectedResult = -11;
        
        //Act
        let collectible = sum(firstNum, secondNum);
        let errorMsg = `Incorrect result. Expexted ${collectible} to be equal to ${expectedResult}`;

        //Assert
        assert.equal(collectible, expectedResult, errorMsg);
    });

    it('With two undefined numbers the function should throw TypeError', () => {
        //Arrange
        let firstNum = undefined;
        let secondNum = undefined;
        let errorMsg = `Numbers should be defined!`;

        //Act and Assert
        assert.throws(() => sum(firstNum, secondNum), TypeError, errorMsg);
    });
});
