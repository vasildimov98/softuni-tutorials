let { assert } = require('chai');
let Console = require('./specialConsole');

describe('Tests for Console class', () => {
    const INVALID_FIRST_ARGUMENT_MSG = 'No string format given!';
    const INVALID_AMOUNT_OF_PARAMETERS_MSG = 'Incorrect amount of parameters given!';
    const INVALID_PLACEHOLDER_MSG = 'Incorrect placeholders given!';

    const TEST_STRING = 'Test';
    const TEST_OBJECT = { test: TEST_STRING };
    const TEST_MULTIPLE_ARGUMENTS = [5, 5, 10];
    const TEST_TAMPLATE_STRING = '{0} + {1} = {2}';

    describe('Tests for writeLine() method type', () => {
        it('Should be static type of method', () => {
            //Arrange
            let propertyToSearch = 'writeLine';

            //Act
            let actualReturnValue = Console.hasOwnProperty(propertyToSearch);

            //Assert
            assert.isTrue(actualReturnValue);
        });
    });

    describe('Tests for writeLine() method called with one argument', () => {
        it('Should return undefined if the passed argument is different from string or object', () => {
            //Arrange
            let testNumber = 10;

            //Act
            let actualUndefined = Console.writeLine(testNumber);

            //Assert
            assert.isUndefined(actualUndefined);
        });

        it('Should return same value that the method was called with if the passed argument is string', () => {
            //Act
            let actualReturnValue = Console.writeLine(TEST_STRING);

            //Assert
            assert.equal(actualReturnValue, TEST_STRING);
        });

        it('Should return JSON representation of the object if the passed argument is object', () => {
            //Arrange
            let expectedJSON = JSON.stringify(TEST_OBJECT);

            //Act
            let actaulJSON = Console.writeLine(TEST_OBJECT);

            //Assert
            assert.equal(actaulJSON, expectedJSON);
        });
    });

    describe('Tests for writeLine() method called with multiple arguments', () => {
        it('Should throw TypeError if multiple arguments are passed, but first one is not a string', () => {
            //Act and Assert
            assert.throws(() => Console.writeLine(TEST_OBJECT, ...TEST_MULTIPLE_ARGUMENTS), TypeError, INVALID_FIRST_ARGUMENT_MSG);
        });

        it('Should throw RangeError if the number of parameters does not correspond to the number of placeholders', () => {
            //Arrange
            let incorrectNumberofParameters = [...TEST_MULTIPLE_ARGUMENTS, ...TEST_MULTIPLE_ARGUMENTS];

            //Act and Assert
            assert.throws(() => Console.writeLine(TEST_TAMPLATE_STRING, ...incorrectNumberofParameters), RangeError, INVALID_AMOUNT_OF_PARAMETERS_MSG);
        });

        it('Should throw RangeError if the placeholders have indexes not within the parameters range', () => {
            //Arrange
            let taplateStringWithWronIndex = '{0} + {14} = {2}';

            //Act and Assert
            assert.throws(() => Console.writeLine(taplateStringWithWronIndex, ...TEST_MULTIPLE_ARGUMENTS), RangeError, INVALID_PLACEHOLDER_MSG);
        });

        it('Should throw RangeError if the placeholders have indexes not within the parameters range', () => {
            //Arrange
            let expectedString = '5 + 5 = 10';

            //Act
            let actualString = Console.writeLine(TEST_TAMPLATE_STRING, ...TEST_MULTIPLE_ARGUMENTS)

            //Assert
            assert.equal(actualString, expectedString);
        });
    });
});