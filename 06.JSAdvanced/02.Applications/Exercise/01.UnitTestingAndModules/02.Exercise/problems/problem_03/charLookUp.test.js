let { assert } = require('chai');
let charLookUp = require('./charLookUp');

describe('Tests for charLookUp function', () => {
    const expectedIncorectIndexMsg = 'Incorrect index';

    it('Should return undefined if first parameter is not a string', () => {
        //Arrange
        let non_stringParameter = { string: 'Test' };
        let index = 0;
        //Act
        let funcResult = charLookUp(non_stringParameter, index);

        //Assert
        assert.isUndefined(funcResult);
    });

    it('Should return undefined if second parameter is not a number', () => {
        //Arrange
        let stringParameter = 'Test';
        let stringIndex = '0';

        //Act
        let funcResult = charLookUp(stringParameter, stringIndex);

        //Assert
        assert.isUndefined(funcResult);
    });

    it('Should return undefined if second parameter is a floating type number', () => {
        //Arrange
        let stringParameter = 'Test';
        let floatingIndex = 0.012;

        //Act
        let funcResult = charLookUp(stringParameter, floatingIndex);

        //Assert
        assert.isUndefined(funcResult);
    });

    it('Should return incorrect msg if index is greater or equal to string length', () => {
        //Arrange
        let stringParameter = 'Test';
        let indexParameter = 4;

        //Act
        let funcResult = charLookUp(stringParameter, indexParameter);

        //Assert
        assert.equal(expectedIncorectIndexMsg, funcResult);
    });

    it('Should return incorrect msg if index is less than zero', () => {
        //Arrange
        let stringParameter = 'Test';
        let indexParameter = -4;

        //Act
        let actualResult = charLookUp(stringParameter, indexParameter);

        //Assert
        assert.equal(actualResult, expectedIncorectIndexMsg);
    });

    it('Should return correct char depending on the called index', () => {
        //Arrange
        let stringParameter = 'Test';
        let indexParameter = 0;
        let indexParameter1 = 1;
        let indexParameter2 = 2;

        let expectedChar = 'T';
        let expectedChar1 = 'e';
        let expectedChar2 = 's';

        //Act
        let actualChar = charLookUp(stringParameter, indexParameter);
        let actualChar1 = charLookUp(stringParameter, indexParameter1);
        let actualChar2 = charLookUp(stringParameter, indexParameter2);

        //Assert
        assert.equal(actualChar, expectedChar);
        assert.equal(actualChar1, expectedChar1);
        assert.equal(actualChar2, expectedChar2);
    });
});