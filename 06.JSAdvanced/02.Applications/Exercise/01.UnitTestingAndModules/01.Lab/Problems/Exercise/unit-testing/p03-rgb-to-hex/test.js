const assert = require('chai').assert;
const rgbToHexColor = require('./index');

describe('Test rgbToHexColor function', () => {
    it('Test if func returns undefined if red value is not integer', () => {
        //Arrange
        let redNum = 12.2131;
        let greenNum = 14;
        let blueNum = 19;
        //Act
        let result = rgbToHexColor(redNum, greenNum, blueNum);

        //Assert
        assert.isUndefined(result);
    });

    it('Test if func returns undefined if green value is not integer', () => {
        //Arrange
        let redNum = 12;
        let greenNum = 14.3132;
        let blueNum = 19;
        //Act
        let result = rgbToHexColor(redNum, greenNum, blueNum);

        //Assert
        assert.isUndefined(result);
    });

    it('Test if func returns undefined if blue value is not integer', () => {
        //Arrange
        let redNum = 12;
        let greenNum = 14;
        let blueNum = 19.12312;
        //Act
        let result = rgbToHexColor(redNum, greenNum, blueNum);

        //Assert
        assert.isUndefined(result);
    });

    it('Test if func returns undefined if red value is less than zero', () => {
        //Arrange
        let redNum = -1;
        let greenNum = 14;
        let blueNum = 19;
        //Act
        let result = rgbToHexColor(redNum, greenNum, blueNum);

        //Assert
        assert.isUndefined(result);
    });

    it('Test if func returns undefined if green value is less than zero', () => {
        //Arrange
        let redNum = 12;
        let greenNum = -1;
        let blueNum = 19;
        //Act
        let result = rgbToHexColor(redNum, greenNum, blueNum);

        //Assert
        assert.isUndefined(result);
    });

    it('Test if func returns undefined if blue value is less than zero', () => {
        //Arrange
        let redNum = 12;
        let greenNum = 14;
        let blueNum = -1;
        //Act
        let result = rgbToHexColor(redNum, greenNum, blueNum);

        //Assert
        assert.isUndefined(result);
    });

    it('Test if func returns undefined if red value is bigger than 255', () => {
        //Arrange
        let redNum = 256;
        let greenNum = 14;
        let blueNum = 19;
        //Act
        let result = rgbToHexColor(redNum, greenNum, blueNum);

        //Assert
        assert.isUndefined(result);
    });

    it('Test if func returns undefined if green value is bigger than 255', () => {
        //Arrange
        let redNum = 0;
        let greenNum = 256;
        let blueNum = 19;
        //Act
        let result = rgbToHexColor(redNum, greenNum, blueNum);

        //Assert
        assert.isUndefined(result);
    });

    it('Test if func returns undefined if blue value is bigger than 255', () => {
        //Arrange
        let redNum = 0;
        let greenNum = 0;
        let blueNum = 256;
        //Act
        let result = rgbToHexColor(redNum, greenNum, blueNum);

        //Assert
        assert.isUndefined(result);
    });

    it('Test if func returns correct output if all the values are valid', () => {
        //Arrange
        let redNum = 0;
        let greenNum = 150;
        let blueNum = 255;

        let expectedResult = "#" +
        ("0" + redNum.toString(16).toUpperCase()).slice(-2) +
        ("0" + greenNum.toString(16).toUpperCase()).slice(-2) +
        ("0" + blueNum.toString(16).toUpperCase()).slice(-2);


        //Act
        let actualResult = rgbToHexColor(redNum, greenNum, blueNum);

        //Assert
        assert.include(actualResult, '#');
        assert.equal(actualResult, expectedResult);
    });
});