const expect = require('chai').expect;
const calculator = require('../calculator');

let subtract = calculator.subtract;

describe('TestSubtractFunction', () => {
    it('Two positive numbers should return a correct subtraction', () => {
        //Arrange
        let firstNum = 5;
        let secondNum = 6;
        let expectedResult = -1;
        
        //Act
        let subtraction = subtract(firstNum, secondNum);
        let errorMsg = `Incorrect result. Expexted ${subtraction} to be equal to ${expectedResult}`;

        //Assert
        //assert.equal(subtraction, expectedResult, errorMsg);
        expect(subtraction).to.be.equal(expectedResult);
    });

    it('Two negative numbers should return a correct subtraction', () => {
        //Arrange
        let firstNum = -5;
        let secondNum = -6;
        let expectedResult = 1;
        
        //Act
        let subtraction = subtract(firstNum, secondNum);
        let errorMsg = `Incorrect result. Expexted ${subtraction} to be equal to ${expectedResult}`;

        //Assert
        //assert.equal(subtraction, expectedResult, errorMsg);
        expect(subtraction).to.be.equal(expectedResult);
    });

    it('With two undefined numbers the function should throw TypeError', () => {
        //Arrange
        let firstNum = undefined;
        let secondNum = undefined;
        let errorMsg = `Numbers should be defined!`;

        //Act and Assert
        //assert.throws(() => subtract(firstNum, secondNum), TypeError, errorMsg);
        expect(() => subtract(firstNum, secondNum)).to.throw(TypeError, errorMsg);
    });
});