const assert = require('chai').assert;
const sum = require('./sum-func');

describe('TestSumFunction', () => {
    it('Function should return NaN if arr contains value different than number', () => {
        //Arrange
        let arr =[1, 'two', 3, 4, {five: 5}, 6, 7, 'tree', 9, 10];

        //Act
        let actualSum = sum(arr);

        //Assert
        assert.isNaN(actualSum);
    });

    it('Function should return the sum all the numbers in the arr', () => {
        //Arrange
        let arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        let expectedSum = arr
            .reduce((totalSum, num) => totalSum += Number(num), 0);

        //Act
        let actualSum = sum(arr);

        //Assert
        assert.equal(actualSum, expectedSum);
    });

    it('Function should work even if the numbers are string type', () => {
        //Arrange
        let arr = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10'];
        let expectedSum = arr
            .reduce((totalSum, num) => totalSum += Number(num), 0);

        //Act
        let actualSum = sum(arr);

        //Assert
        assert.equal(actualSum, expectedSum);
    });
});