let assert = require('chai').assert;
let StringBuilder = require('./string-builder');

describe('Tests for StringBuilder class', () => {
    const strindToInstantiateWith = 'Hello';
    let sb;
    beforeEach(() => {
        sb = new StringBuilder(strindToInstantiateWith);
    });

    describe('Test for invalid arguments', () => {
        it('Should throw argument exeption if the argument is not a string', () => {
            //Arrange
            let non_stringParameter = { test: 'Not a string' };
            let expectedMsg = 'Argument must be string';

            //Act and Assert
            assert.throws(() => new StringBuilder(non_stringParameter), TypeError, expectedMsg)
        });
    });

    describe('Test for class constructor', () => {
        it('Should be able to instantiate an object without a parameter', () => {
           //Act 
           sb = new StringBuilder();
           let actualResult = sb.toString();

           //Assert
           assert.isObject(sb);
           assert.isEmpty(actualResult);
        });

        it('Should be able to instantiate an object with a parameter of type string', () => {
            //Arrange
            let expectedResult = 'Hello';

            //Act 
            let actualResult = sb.toString();

            //Assert
            assert.isObject(sb);
            assert.equal(actualResult, expectedResult);
        });
    });

    describe('Tests for the append function in the class', () => {
        it('Should append the string to the end of the internal class arr', () => {
            //Arrange
            let stringToAppend = ' World!';
            let expectedResult = `Hello${stringToAppend}`;

            //Act 
            sb.append(stringToAppend);
            let actualResult = sb.toString();

            //Assert
            assert.equal(actualResult, expectedResult);
            assert.include(actualResult, stringToAppend);
        });
    });

    describe('Tests for the prepend function in the class', () => {
        it('Should prepend the string at the beginning of the internal class arr', () => {
            //Arrange
            let stringToPrepend = 'World! ';
            let expectedResult = `${stringToPrepend}Hello`;

            //Act 
            sb.prepend(stringToPrepend);
            let actualResult = sb.toString();

            //Assert
            assert.equal(actualResult, expectedResult);
            assert.include(actualResult, stringToPrepend);
        });
    });

    describe('Tests for the insertAt function in the class', () => {
        it('Should insert the string at the given index of the internal class arr even if the index is less than zero', () => {
            //Arrange
            let stringToInsert = 'World! ';
            let startIndex = -2;
            let expectedResult = `Hel${stringToInsert}lo`;

            //Act 
            sb.insertAt(stringToInsert, startIndex);
            let actualResult = sb.toString();

            //Assert
            assert.equal(actualResult, expectedResult);
            assert.include(actualResult, stringToInsert);
        });

        it('Should insert the string at the given index of the internal class arr even if the index is greater than the length', () => {
            //Arrange
            let stringToInsert = 'World! ';
            let startIndex = 6;
            let expectedResult = `Hello${stringToInsert}`;

            //Act 
            sb.insertAt(stringToInsert, startIndex);
            let actualResult = sb.toString();

            //Assert
            assert.equal(actualResult, expectedResult);
            assert.include(actualResult, stringToInsert);
        });

        it('Should insert the string at the given index of the internal class arr', () => {
            //Arrange
            let stringToInsert = 'World! ';
            let startIndex = 1;
            let expectedResult = `H${stringToInsert}ello`;

            //Act 
            sb.insertAt(stringToInsert, startIndex);
            let actualResult = sb.toString();

            //Assert
            assert.equal(actualResult, expectedResult);
            assert.include(actualResult, stringToInsert);
        });
    });

    describe('Tests for the remove function in the class', () => {
        it('Should not remove characters even if the given index is less than zero', () => {
            //Arrange
            let startIndex = -2;
            let deleteCount = 2;
            let expectedResult = `Hel`;

            //Act 
            sb.remove(startIndex, deleteCount);
            let actualResult = sb.toString();

            //Assert
            assert.equal(actualResult, expectedResult);
        });

        it('Should not remove anything if startIndex is bigger than internal arr length', () => {
            //Arrange
            let startIndex = 5;
            let deleteCount = 5;
            let expectedResult = `Hello`;

            //Act 
            sb.remove(startIndex, deleteCount);
            let actualResult = sb.toString();

            //Assert
            assert.equal(actualResult, expectedResult);
        });

        it('Should remove everything if startIndex is equal to 0 and deleteCount equal to the length of internal arr', () => {
            //Arrange
            let startIndex = 0;
            let deleteCount = 5;

            //Act 
            sb.remove(startIndex, deleteCount);
            let actualResult = sb.toString();

            //Assert
            assert.isEmpty(actualResult);
        });

        it('Should remove n count of characters from startIndex', () => {
             //Arrange
             let startIndex = 1;
             let deleteCount = 2;
             let expectedResult = `Hlo`;
 
             //Act 
             sb.remove(startIndex, deleteCount);
             let actualResult = sb.toString();
 
             //Assert
             assert.equal(actualResult, expectedResult);
        });
    });

    describe('Tests for toString method', () => {
        it('Should return empty string if the internal arr is empty', () => {
            //Arrange
            let sb1 = new StringBuilder();

            //Act
            let actualResult = sb1.toString();

            //Assert
            assert.isEmpty(actualResult);
        });

        it('Should return all save characters in the internal arr as a string join by empty string', () => {
            //Arrange
            let stringToAppend = ' World!';
            let stringToPrepend = 'From Bulgaria: ';
            let stringToInsert = ' To the';
            let startIndex = stringToPrepend.length + 5;
            let expectedResult = `${stringToPrepend}Hello${stringToInsert}${stringToAppend}`;

            //Act
            sb.append(stringToAppend);
            sb.prepend(stringToPrepend);
            sb.insertAt(stringToInsert, startIndex);
            let actualResult = sb.toString();

            //Assert
            assert.equal(actualResult, expectedResult);
        });
    });
});