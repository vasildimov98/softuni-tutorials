let { assert } = require('chai');
let Warehouse = require('./Warehouse');

//Maybe there is a possibility to test TypeError Cannot read property 'hasOwnProperty' of undefined;
describe('Tests for Warehouse class', () => {
    const INVALID_CAPACITY_MSG = 'Invalid given warehouse space';
    const NOT_ENOUGH_CAPACITY_MSG = 'There is not enough space or the warehouse is already full';
    const EMPTY_WAREHOUSE_MSG = 'The warehouse is empty';

    const VALID_CAPACITY = 55;
    const FOOD_KEY = 'Food';
    const DRINK_KEY = 'Drink';
    const TEST_FOOD_PRODUCT = 'Strawberry';
    const TEST_DRINK_PRODUCT = 'Juice';
    const TEST_QUANTITY = 10;

    let warehouse;
    beforeEach(() => {
        warehouse = new Warehouse(VALID_CAPACITY);
    });

    describe('Tests for getter and setter of the capacity property', () => {
        it('Should throw a string message if type of capacity is different than number', () => {
            //Arrange
            let invalidCapacity = { capacity: VALID_CAPACITY };

            //Act and Assert
            assert.throws(() => new Warehouse(invalidCapacity), INVALID_CAPACITY_MSG)
        });

        it('Should throw a string message if capacity is less than zero', () => {
            //Arrange
            let invalidCapacity = -20;

            //Act and Assert
            assert.throws(() => new Warehouse(invalidCapacity), INVALID_CAPACITY_MSG)
        });

        it('Should throw a string message if capacity equal to zero', () => {
            //Arrange
            let invalidCapacity = 0;

            //Act and Assert
            assert.throws(() => new Warehouse(invalidCapacity), INVALID_CAPACITY_MSG)
        });

        it('Should set the capacity correctly if given value is valid', () => {
            //Act
            let actualCapacity = warehouse.capacity;

            //Assert
            assert.equal(actualCapacity, VALID_CAPACITY);
        });
    });

    describe('Test for the class constructor', () => {
        it('Should instantiate an object with given and default values for properties', () => {
            //Arrange
            let expectedKeys = [FOOD_KEY, DRINK_KEY];

            //Act
            let actualCapacity = warehouse.capacity;
            let actualAvailableProducts = warehouse.availableProducts;
            let foodsObject = actualAvailableProducts[FOOD_KEY];
            let drinksObject = actualAvailableProducts[DRINK_KEY];

            //Assert
            assert.isObject(warehouse);
            assert.equal(actualCapacity, VALID_CAPACITY);
            assert.isObject(actualAvailableProducts);
            assert.hasAllKeys(actualAvailableProducts, expectedKeys);
            assert.isObject(foodsObject);
            assert.isEmpty(foodsObject);
            assert.isObject(drinksObject);
            assert.isEmpty(drinksObject);
        });
    });

    describe('Tests for the addProduct() method', () => {
        it('Should throw a string if there is not enough capacity in the warehouse', () => {
            //Arrange
            let greaterQuantityThanCapacity = VALID_CAPACITY * 2;

            //Act and Assert
            assert.throws(() => warehouse.addProduct(FOOD_KEY, TEST_FOOD_PRODUCT, greaterQuantityThanCapacity), NOT_ENOUGH_CAPACITY_MSG)
        });

        it('Should return an object with added food and all other available if type is food', () => {
            //Arrange
            let expectedKey = [TEST_FOOD_PRODUCT];
            let unexpectedKey = [FOOD_KEY, DRINK_KEY];

            //Act
            let actualResult = warehouse.addProduct(FOOD_KEY, TEST_FOOD_PRODUCT, TEST_QUANTITY);

            //Assert
            assert.isObject(actualResult);
            assert.hasAllKeys(actualResult, expectedKey);
            assert.doesNotHaveAllKeys(actualResult, unexpectedKey);
        });

        it('Should return an object with added drink and all other available if type is drink', () => {
            //Arrange
            let expectedKey = [TEST_DRINK_PRODUCT];
            let unexpectedKey = [FOOD_KEY, DRINK_KEY];

            //Act
            let actualResult = warehouse.addProduct(DRINK_KEY, TEST_DRINK_PRODUCT, TEST_QUANTITY);

            //Assert
            assert.isObject(actualResult);
            assert.hasAllKeys(actualResult, expectedKey);
            assert.doesNotHaveAllKeys(actualResult, unexpectedKey);
        });

        it('Should increase the quantity of the product if this product already exists', () => {
            //Arrange
            let expectedQuantityFirstTime = 10;
            let expectedQuantitySecondTime = 20;

            //Act
            let { [`${TEST_DRINK_PRODUCT}`]: firstTimeQuantity } = warehouse.addProduct(DRINK_KEY, TEST_DRINK_PRODUCT, TEST_QUANTITY);
            let { [`${TEST_DRINK_PRODUCT}`]: secondTimeQuantity } = warehouse.addProduct(DRINK_KEY, TEST_DRINK_PRODUCT, TEST_QUANTITY);

            //Assert
            assert.equal(firstTimeQuantity, expectedQuantityFirstTime);
            assert.equal(secondTimeQuantity, expectedQuantitySecondTime);
        });
    });

    describe('Tests for orderProduct() method', () => {
        it('Should order the foods in descending order by quantity if type is food', () => {
            //Arrange
            let countOfProductsToAdd = 10;
            let addedFoods = _addMultipleProducts(FOOD_KEY, TEST_FOOD_PRODUCT, countOfProductsToAdd);

            let expectedOrderOfFoodKeys = Object.keys(addedFoods)
                .sort((a, b) => {
                    return addedFoods[b] - addedFoods[a];
                });

            //Act
            let foodOrder = warehouse.orderProducts(FOOD_KEY);
            let actualOrderOfFoodKeys = Object.keys(foodOrder);

            //Assert
            assert.deepEqual(actualOrderOfFoodKeys, expectedOrderOfFoodKeys)
        });

        it('Should order the drinks in descending order by quantity if type is drink', () => {
            //Arrange
            let countOfProductsToAdd = 10;
            let addedDrinks = _addMultipleProducts(DRINK_KEY, TEST_DRINK_PRODUCT, countOfProductsToAdd);

            let expectedOrderOfDrinkKeys = Object.keys(addedDrinks)
                .sort((a, b) => {
                    return addedDrinks[b] - addedDrinks[a];
                });

            //Act
            let drinkOrder = warehouse.orderProducts(DRINK_KEY);
            let actualOrderOfDrinkKeys = Object.keys(drinkOrder);

            //Assert
            assert.deepEqual(actualOrderOfDrinkKeys, expectedOrderOfDrinkKeys)
        });
    });

    describe('Tests for occupiedCapacity() method', () => {
        it('Should return zero if their is no products in the warehous', () => {
            //Arrange
            let expectedOccupation = 0;

            //Act
            let actualOccupation = warehouse.occupiedCapacity();

            //Assert
            assert.equal(actualOccupation, expectedOccupation);
        });

        it('Should return the correct occupation number when the function is called and there are available products', () => {
            //Arrange
            let countOfProductsToAdd = 10;
            let addedDrinks = _addMultipleProducts(DRINK_KEY, TEST_DRINK_PRODUCT, countOfProductsToAdd);

            let expectedOccupation = Object.keys(addedDrinks)
                .reduce((occupation, drink) => {
                    return occupation += addedDrinks[drink]
                }, 0);

            //Act
            let actualOccupation = warehouse.occupiedCapacity();

            //Assert
            assert.equal(actualOccupation, expectedOccupation);
        });
    });

    describe('Tests for revision() method', () => {
        it('Should return correct message if their are no products in the warehouse', () => {
            //Act
            let actualMessage = warehouse.revision();

            //Assert
            assert.equal(actualMessage, EMPTY_WAREHOUSE_MSG);
        });

        it('Should return the correct revision string with information of all products', () => {
            //Arrange
            let countOfFoodsToAdd = 5;
            let countOfDrinksToAdd = 5;

            _addMultipleProducts(FOOD_KEY, TEST_FOOD_PRODUCT, countOfFoodsToAdd);
            _addMultipleProducts(DRINK_KEY, TEST_DRINK_PRODUCT, countOfDrinksToAdd);

            let expectedRevision = _createTestRevision();

            //Act
            let actualRevision = warehouse.revision();

            //Assert
            assert.equal(actualRevision, expectedRevision);
        });
    });

    describe('Tests for scrapeAProduct() method', () => {
        it('Should return correct message if their are no products in the warehouse', () => {
            //Arrange
            let expectedMsg = `${TEST_FOOD_PRODUCT} do not exists`

            //Act and Assert
            assert.throws(() => warehouse.scrapeAProduct(TEST_FOOD_PRODUCT, TEST_QUANTITY), expectedMsg);
        });

        it('Should decrease product quantity if the method is successful', () => {
            //Arrange
            warehouse.addProduct(FOOD_KEY, TEST_FOOD_PRODUCT, TEST_QUANTITY);
            let quantityToDecreaseWith = 5;
            let expectedQuantity = TEST_QUANTITY - quantityToDecreaseWith;

            //Act
            let {[`${TEST_FOOD_PRODUCT}`]: actualQuantity} = warehouse.scrapeAProduct(TEST_FOOD_PRODUCT, quantityToDecreaseWith);

            //Assert
            assert.equal(actualQuantity, expectedQuantity);
        });

        it('Should reset the product if given quantity is bigger than the product\'s quantity', () => {
            //Arrange
            warehouse.addProduct(FOOD_KEY, TEST_FOOD_PRODUCT, TEST_QUANTITY);
            let quantityToDecreaseWith = 15;
            let expectedQuantity = 0;

            //Act
            let {[`${TEST_FOOD_PRODUCT}`]: actualQuantity} = warehouse.scrapeAProduct(TEST_FOOD_PRODUCT, quantityToDecreaseWith);

            //Assert
            assert.equal(actualQuantity, expectedQuantity);
        });
    });

    function _createTestRevision() {
        let output = '';

        for (let type of Object.keys(warehouse.availableProducts)) {
            output += `Product type - [${type}]\n`;
            for (let product of Object.keys(warehouse.availableProducts[type])) {
                output += `- ${product} ${warehouse.availableProducts[type][product]}\n`;
            }
        }

        return output
            .trim();
    }

    function _addMultipleProducts(type, product, count) {
        let addedProducts;
        for (let index = 1; index <= count; index++) {
            addedProducts = warehouse.addProduct(type, `${product}${index}`, index)
        }

        return addedProducts;
    }
});