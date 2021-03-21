let {assert} = require('chai');
let isOddOrEven = require('./isOddOrEven');

describe('Test for isOddOrEven function', () => {
    it('Should return undefined if passed parameter is different from string', () => {
        //Arrange
        let wrongParameter = {string: 'EvenString'};

        //Act
        let funcResult = isOddOrEven(wrongParameter);

        //Assert
        assert.isUndefined(funcResult);
    });

    it('Should return even if passed parameter is a string and has even length', () => {
        //Arrange
        let evenLengthParameter = 'EvenString' // 10 length;
        let expectedResult = 'even';

        //Act
        let actualResult = isOddOrEven(evenLengthParameter);

        //Assert
        assert.equal(actualResult, expectedResult);
    });

    it('Should return odd if passed parameter is a string and has odd length', () => {
        //Arrange
        let oddLengthParameter = 'OddString' // 9 length;
        let expectedResult = 'odd';

        //Act
        let actualResult = isOddOrEven(oddLengthParameter);

        //Assert
        assert.equal(actualResult, expectedResult);
    });

    it('Should return odd or even depending on the string length', () => {
        //Arrange
        let evenLengthParameter = 'EvenString' // 10 length;
        let oddLengthParameter = 'OddString' // 9 length;
        let oddLengthParameter1 = 'Odd String ' // 11 length;
        let expectedResult = 'even';
        let expectedResult1 = 'odd';

        //Act
        let actualResult = isOddOrEven(evenLengthParameter);
        let actualResult1 = isOddOrEven(oddLengthParameter);
        let actualResult2 = isOddOrEven(oddLengthParameter1);

        //Assert
        assert.equal(actualResult, expectedResult);
        assert.equal(actualResult1, expectedResult1);
        assert.equal(actualResult2, expectedResult1);
    });
});