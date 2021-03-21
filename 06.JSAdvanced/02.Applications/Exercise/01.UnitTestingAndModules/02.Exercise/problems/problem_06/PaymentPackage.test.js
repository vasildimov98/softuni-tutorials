let { assert } = require('chai');
let PaymentPackage = require('./PaymentPackage');

describe('Tests for PaymentPackage class', () => {
    const INVALID_NAME_MSG = 'Name must be a non-empty string';
    const INVALID_VALUE_MSG = 'Value must be a non-negative number';
    const INVALID_VAT_MSG = 'VAT must be a non-negative number';
    const INVALID_ACTIVE_MSG = 'Active status must be a boolean';

    const DEFAULT_VAT = 20;
    const DEFAULT_ACTIVE_STATUS = true;

    const VALID_TEST_NAME = 'Test Product Name'
    const VALID_TEST_VALUE = 10;
    const VALID_TEST_VAT = 10;
    const VALID_TEST_ACTIVE_STATUS = false;

    let paymentPackage

    beforeEach(() => {
        paymentPackage = new PaymentPackage(VALID_TEST_NAME, VALID_TEST_VALUE);
    });

    describe('Tests for the name property of the class', () => {
        it('Should throw error if the name to set is an object', () => {
            //Arrange
            let invalidName = { name: VALID_TEST_NAME };

            //Act and Assert
            assert.throws(() => new PaymentPackage(invalidName, VALID_TEST_VALUE), Error, INVALID_NAME_MSG);
        });

        it('Should throw error if the name to set is an empty string', () => {
            //Arrange
            let invalidName = '';

            //Act and Assert
            assert.throws(() => new PaymentPackage(invalidName, VALID_TEST_VALUE), Error, INVALID_NAME_MSG);
        });

        it('Should set the name correctly if it is valid', () => {
            //Act
            let actualName = paymentPackage.name;

            //Assert
            assert.equal(actualName, VALID_TEST_NAME);
        });
    });

    describe('Tests for the value property of the class', () => {
        it('Should throw error if the value to set is an object', () => {
            //Arrange
            let invalidValue = { value: VALID_TEST_VALUE };

            //Act and Assert
            assert.throws(() => new PaymentPackage(VALID_TEST_NAME, invalidValue), Error, INVALID_VALUE_MSG);
        });

        it('Should throw error if the value to set is less than zero', () => {
            //Arrange
            let invalidValue = -10;

            //Act and Assert
            assert.throws(() => new PaymentPackage(VALID_TEST_NAME, invalidValue), Error, INVALID_VALUE_MSG);
        });

        it('Should set the value correctly if it is valid', () => {
            //Act
            let actualValue = paymentPackage.value;

            //Assert
            assert.equal(actualValue, VALID_TEST_VALUE);
        });
    });

    describe('Tests for the VAT property of the class', () => {
        it('Should throw error if the VAT to set is an object', () => {
            //Arrange
            let invalidVAT = { value: VALID_TEST_VAT };

            //Act and Assert
            assert.throws(() => paymentPackage.VAT = invalidVAT, Error, INVALID_VAT_MSG);
        });

        it('Should throw error if the VAT to set is less than zero', () => {
            //Arrange
            let invalidVAT = -20;

            //Act and Assert
            assert.throws(() => paymentPackage.VAT = invalidVAT, Error, INVALID_VAT_MSG);
        });

        it('Should set the VAT correctly if it is valid', () => {
            //Act
            paymentPackage.VAT = VALID_TEST_VAT;
            let actualVAT = paymentPackage.VAT;

            //Assert
            assert.equal(actualVAT, VALID_TEST_VAT);
        });
    });

    describe('Tests for the active property of the class', () => {
        it('Should throw error if the active to set is an object', () => {
            //Arrange
            let invalidActive = { value: VALID_TEST_ACTIVE_STATUS };

            //Act and Assert
            assert.throws(() => paymentPackage.active = invalidActive, Error, INVALID_ACTIVE_MSG);
        });

        it('Should set the active status correctly if it is valid', () => {
            //Act
            paymentPackage.active = VALID_TEST_ACTIVE_STATUS;
            let actualActive = paymentPackage.active;

            //Assert
            assert.equal(actualActive, VALID_TEST_ACTIVE_STATUS);
        });
    });

    describe('Tests for the constructor', () => {
        it('should instantiate an object with given value and default values', () => {
            //Act
            let actualName = paymentPackage.name;
            let actualValue = paymentPackage.value;

            let actualDefaultVAT = paymentPackage.VAT;
            let actualDefaultActiveStatus = paymentPackage.active;

            //Assert
            assert.isObject(paymentPackage);
            assert.equal(actualName, VALID_TEST_NAME);
            assert.equal(actualValue, VALID_TEST_VALUE);
            assert.equal(actualDefaultVAT, DEFAULT_VAT);
            assert.equal(actualDefaultActiveStatus, DEFAULT_ACTIVE_STATUS);
        });
    });

    describe('Tests for the toSting() method of the class', () => {
        it('Should return overview of paymentPackage', () => {
            //Arrange
            let expectedOverview = [
                `Package: ${VALID_TEST_NAME}` + (DEFAULT_ACTIVE_STATUS === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${VALID_TEST_VALUE}`,
                `- Value (VAT ${DEFAULT_VAT}%): ${VALID_TEST_VALUE * (1 + DEFAULT_VAT / 100)}`
            ].join('\n');

            //Act
            let actualOverview = paymentPackage.toString();

            //Assert
            assert.equal(actualOverview, expectedOverview);
        });

        it('Should put inactive next to the name if active status is false', () => {
            //Arrange
            let expectedOverview = [
                `Package: ${VALID_TEST_NAME}` + (VALID_TEST_ACTIVE_STATUS === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${VALID_TEST_VALUE}`,
                `- Value (VAT ${DEFAULT_VAT}%): ${VALID_TEST_VALUE * (1 + DEFAULT_VAT / 100)}`
            ].join('\n');

            //Act
            paymentPackage.active = VALID_TEST_ACTIVE_STATUS;
            let actualOverview = paymentPackage.toString();

            //Assert
            assert.equal(actualOverview, expectedOverview);
        });
    });
});