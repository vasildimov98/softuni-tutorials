const assert = require('chai').assert;
const isSymmetric = require('./index');

describe('Test for isSymmetric function', () => {
    // it('Func should take array as an argument', () => {
    //     //Assert
    //     assert.isArray(isSymmetric.arguments[0]);
    // });

    it('Non-arrays values should be classified as non-symmetric', () => {
        //Arrange
        let non_array = '1, 2, 3, 4, 5, 5, 4, 3, 2, 1';

        //Act
        let actualResult = isSymmetric(non_array);

        //Assert
        assert.isFalse(actualResult);
    });

    it('Func with non-symmetrical arrays should return false!', () => {
        //Arrange
        let non_symmetricalArr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        //Act
        let actualResult = isSymmetric(non_symmetricalArr);

        //Assert
        assert.isFalse(actualResult);
    });

    it('Func with symmetrical arrays should return true!', () => {
        //Arrange
        let symmetricalArr = [1, 2, 3, 4, 5, 5, 4, 3, 2, 1];

        //Act
        let actualResult = isSymmetric(symmetricalArr);

        //Assert
        assert.isTrue(actualResult);
    });
});