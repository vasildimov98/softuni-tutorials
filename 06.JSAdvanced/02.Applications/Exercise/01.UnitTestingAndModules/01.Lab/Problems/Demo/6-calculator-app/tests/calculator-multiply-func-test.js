require('chai').should();
const calculator = require('../calculator');

let multiply = calculator.multiply;

describe('TestMultFunction', () => {
    it('Two positive numbers should return a posite product', () => {
        //Arrange
        let firstNum = 5;
        let secondNum = 6;
        let expectedResult = 30;

        //Act
        let product = multiply(firstNum, secondNum);
        let errorMsg = `Incorrect result. Expexted ${product} to be equal to ${expectedResult}`;

        //Assert
        //assert.equal(product, expectedResult, errorMsg);
        product.should.equal(expectedResult, errorMsg);
    });

    it('A number multiply by zero should equal zero', () => {
        //Arrange
        let firstNum = 0;
        let secondNum = -6;
        let expectedResult = 0;

        //Act
        let product = multiply(firstNum, secondNum);
        let errorMsg = `Incorrect result. Expexted ${product} to be equal to ${expectedResult}`;

        //Assert
        //assert.equal(product, expectedResult, errorMsg);
        product.should.equal(expectedResult, errorMsg);
    });

    it('With two undefined numbers the function should throw TypeError', () => {
        //Arrange
        let firstNum = undefined;
        let secondNum = undefined;
        let errorMsg = `Numbers should be defined!`;

        //Act and Assert
        //assert.throws(() => multiply(firstNum, secondNum), TypeError, errorMsg);
        () => multiply(firstNum, secondNum).should.throw(TypeError, errorMsg);
    });
});
