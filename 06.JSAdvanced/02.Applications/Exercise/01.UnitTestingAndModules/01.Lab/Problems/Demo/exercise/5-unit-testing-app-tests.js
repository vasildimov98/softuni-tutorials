const calculator = require('./5-unit-testing-app');

let sum = calculator.sum;
let subtract = calculator.subtract;

// 1. Test for sum function 
function TestSumFunction() {
    // Arrange
    let firstNum = 5;
    let secondNum = 6;
    let expectedResult = 11;

    // Act
    let firstResult = sum(firstNum, secondNum); // 11

    // Assert
    console.log('Results from tests of sum funciton:');
    console.log('Test1:');
    if (firstResult == expectedResult) {
        console.log('The result is correct')
    } else {
        console.log(`Incorrect result. Expexted ${firstResult} to be equal to 11`);
    }

    //Arrange
    let expectedResult1 = 'Incorrect result!';

    //Act
    let secondResult = sum();

    //Assert
    console.log('Test2:');
    if (secondResult == expectedResult1) {
        console.log('The result is correct')
    } else {
        console.log(`Incorrect result. Expexted ${secondResult} to be equal to Incorrect result!`);
    }
}

TestSumFunction();

// 2. Test for subtract function 
function TestSubtractFunction() {
    let firstResult = subtract(5, 6); // 11

    console.log('Results from tests of subtract funciton:');
    console.log('Test1:');
    if (firstResult == -1) {
        console.log('The result is correct')
    } else {
        console.log(`Incorrect result. Expexted ${firstResult} to be equal to 11`);
    }

    let secondResult = subtract();
    console.log('Test2:');
    if (secondResult == 'Incorrect result!') {
        console.log('The result is correct')
    } else {
        console.log(`Incorrect result. Expexted ${secondResult} to be equal to Incorrect result!`);
    }
}

TestSubtractFunction();