namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        //Arrange
        private const string FIRST_PRODUCT_LABEL = "First Test Label";
        private const decimal FIRST_PRODUCT_PRICE = 20m;
        private const int FIRST_PRODUCT_QUANTITY = 5;

        private const string SECOND_PRODUCT_LABEL = "Second Test Label";
        private const decimal SECOND_PRODUCT_PRICE = 10m;
        private const int SECOND_PRODUCT_QUANTITY = 10;

        private IProductStock productStock;
        private Product firstProduct;
        private Product secondProduct;

        [SetUp]
        public void SetUpClass()
        {
            this.productStock = new ProducktStock();
            this.firstProduct 
                = new Product(FIRST_PRODUCT_LABEL, FIRST_PRODUCT_PRICE, FIRST_PRODUCT_QUANTITY);
            this.secondProduct
                = new Product(SECOND_PRODUCT_LABEL, SECOND_PRODUCT_PRICE, SECOND_PRODUCT_QUANTITY);
        }

        [Test]
        public void AddMethodShouldNotAddDubblicateLebalsProduct()
        {
            //Arrange
            this.productStock.Add(this.firstProduct); 
            var anotherProduct = new Product(FIRST_PRODUCT_LABEL, FIRST_PRODUCT_PRICE / 2, FIRST_PRODUCT_QUANTITY - 2);

            //Act & Assert
            Assert.That(() => this.productStock.Add(anotherProduct),
                Throws.ArgumentException
                .With.Message.EqualTo("Cannot add products with duplicate label in stock!"));
        }

        [Test]
        public void AddMethodShouldIncreaceCountWhenSuccessful()
        {
            //Act
            this.productStock.Add(this.firstProduct);
            var foundProductByLabel = this.productStock.FindByLabel(FIRST_PRODUCT_LABEL);
            //Assert
            Assert.That(foundProductByLabel, Is.Not.Null);
            Assert.That(foundProductByLabel.Label, Is.EqualTo(FIRST_PRODUCT_LABEL));
            Assert.That(foundProductByLabel.Price, Is.EqualTo(FIRST_PRODUCT_PRICE));
            Assert.That(foundProductByLabel.Quantity, Is.EqualTo(FIRST_PRODUCT_QUANTITY));
        }

        [Test]
        public void RemoveMethodShouldReturnFalseElementNotFound()
        {
            //Arrange
            this.productStock.Add(this.firstProduct);

            //Act
            var isFound = this.productStock.Remove(this.secondProduct);

            //Assert
            Assert.That(isFound, Is.False);
        }

        [Test]
        public void RemoveMethodShouldReturnTrueIfElementRemoved()
        {
            //Arrange
            this.productStock.Add(this.firstProduct);

            //Act
            var isFound = this.productStock.Remove(this.firstProduct);

            //Assert
            Assert.That(isFound, Is.True);
        }


        [Test]
        public void ContainsMethodShouldThrowExceptionIfProductIsNull()
        {
            //Act
            Assert.That(() => this.productStock.Contains(null),
                //Assert
                Throws.ArgumentException
                .With.Message.EqualTo("Value cannot be null!"));
        }

        [Test]
        public void ContainsMethodShouldReturnFalseElementNotFound()
        {
            //Arrange
            this.productStock.Add(this.firstProduct);

            //Act
            var isFound = this.productStock.Contains(this.secondProduct);

            //Assert
            Assert.That(isFound, Is.False);
        }

        [Test]
        public void ContainsMethodShouldReturnTrueIfElementFound()
        {
            //Arrange
            this.productStock.Add(this.firstProduct);

            //Act
            var isFound = this.productStock.Contains(this.firstProduct);

            //Assert
            Assert.That(isFound, Is.True);
        }

        [Test]
        public void CountPropertyShouldReturnTheCurrentCountOfStock()
        {
            //Arrange
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            //Act
            var count = this.productStock.Count;

            //Assert
            Assert.That(count, Is.EqualTo(2));
        }

        [TestCase(-12)]
        [TestCase(2)]
        public void FindMethodShouldThrowExeptionIfIntIsOutOfRange(int index)
        {
            //Arrange
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            //Act & Assert
            Assert.That(() => this.productStock.Find(index),
                Throws.ArgumentException
                .With.Message.EqualTo("Index is out of range"));
        }

        [Test]
        public void FindMethodShouldReturnTheProductThatIsFound()
        {
            //Arrange
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            //Act
            var foundProduct = this.productStock.Find(0);

            //Assert
            Assert.That(foundProduct, Is.Not.Null);
            Assert.That(foundProduct.Label, Is.EqualTo(FIRST_PRODUCT_LABEL));
            Assert.That(foundProduct.Price, Is.EqualTo(FIRST_PRODUCT_PRICE));
            Assert.That(foundProduct.Quantity, Is.EqualTo(FIRST_PRODUCT_QUANTITY));
        }

        [Test]
        public void FindByLabelMethodShouldThrowExceptionIfValueIsNull()
        {
            //Act
            Assert.That(() => this.productStock.FindByLabel(null),
                //Assert
                Throws.ArgumentException
                .With.Message.EqualTo("Argument cannot be null!"));
        }

        [Test]
        public void FindByLabelMethodShouldThrowExceptionifStockIsEmptyOrNotFound()
        {
            //Arrange
            this.productStock.Add(this.secondProduct);

            //Act
            Assert.That(() => this.productStock.FindByLabel(FIRST_PRODUCT_LABEL),
                //Assert
                Throws.ArgumentException
                .With.Message.EqualTo("Product not found!"));
        }

        [Test]
        public void FindByLabelMethodShoudlReturnTheProductWhenIsFound()
        {
            //Arrange
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            //Act
            var foundProduct = this.productStock.FindByLabel(FIRST_PRODUCT_LABEL);

            //Assert
            Assert.That(foundProduct, Is.Not.Null);
            Assert.That(foundProduct.Label, Is.EqualTo(FIRST_PRODUCT_LABEL));
            Assert.That(foundProduct.Price, Is.EqualTo(FIRST_PRODUCT_PRICE));
            Assert.That(foundProduct.Quantity, Is.EqualTo(FIRST_PRODUCT_QUANTITY));
        }

        [Test]
        public void FindAllInPriceRangeMethodShouldThrowExceptionIfValuesAreZeroOrNegative()
        {
            //Act & Assert
            Assert.That(() => this.productStock.FindAllInRange(-12, 0),
                Throws.ArgumentException
                .With.Message.EqualTo("Price cannot be zero or negative!"));
        }

        [Test]
        public void FindAllInPriceRangeMethodShouldReturnEmptyCollection()
        {
            //Arrange
            this.MultipleAddElementsInStock();

            //Act
            var emptyCollectionOfElements = this.productStock.FindAllInRange(41, 70);

            //Assert
            Assert.That(emptyCollectionOfElements, Is.Empty);
        }

        [Test]
        public void FindAllInPriceRangeMethodShouldReturnCollectionInDescendingOrder()
        {
            //Arrange
            this.MultipleAddElementsInStock();

            //Act
            var collectionInDescendingOrder = this.productStock
                .FindAllInRange(10, 20)
                .ToList();

            //Assert
            Assert.That(collectionInDescendingOrder.Count, Is.EqualTo(3));
            Assert.That(collectionInDescendingOrder[0].Price, Is.EqualTo(20));
            Assert.That(collectionInDescendingOrder[1].Price, Is.EqualTo(15));
            Assert.That(collectionInDescendingOrder[2].Price, Is.EqualTo(10));
        }

        [TestCase(0)]
        [TestCase(-12)]
        public void FindAllByPriceMethodShouldThrowExceptionIfValuesAreZeroOrNegative(decimal price)
        {
            //Act & Assert
            Assert.That(() => this.productStock.FindAllByPrice((double)price),
                Throws.ArgumentException
                .With.Message.EqualTo("Price cannot be zero or negative!"));
        }

        [Test]
        public void FindAllByPriceMethodShouldReturnEmptyCollectionIfNothingFound()
        {
            //Arrange
            this.MultipleAddElementsInStock();

            //Act
            var emptyCollectionOfElements = this.productStock.FindAllByPrice(50);

            //Assert
            Assert.That(emptyCollectionOfElements, Is.Empty);
        }

        [Test]
        public void FindAllByPriceMethodShouldReturnCollectionInDescendingOrder()
        {
            //Arrange
            this.MultipleAddElementsInStock();

            //Act
            var collectionInDescendingOrder = this.productStock
                .FindAllByPrice(25)
                .ToList();

            //Assert
            Assert.That(collectionInDescendingOrder.Count, Is.EqualTo(2));
            Assert.That(collectionInDescendingOrder[0].Label, Is.EqualTo("4"));
            Assert.That(collectionInDescendingOrder[1].Label, Is.EqualTo("5"));
        }

        [Test]
        public void FindTheMostExpensiveProductShouldThrowExceptionIfNothingFound()
        {
            //Act
            Assert.That(() => this.productStock.FindMostExpensiveProduct(),
                //Assert
                Throws.ArgumentException
                .With.Message.EqualTo("Product could not be found!"));
        }

        [Test]
        public void FindTheMostExpensiveProductShouldReturnMostExpensiveOneFromAll()
        {
            //Arrange
            this.MultipleAddElementsInStock();

            //Act
            var mostExpensiveProduct = this.productStock.FindMostExpensiveProduct();

            //Assert
            Assert.That(mostExpensiveProduct.Price, Is.EqualTo(40));
        }

        [Test]
        public void FindAllByQuantityMethodShouldThrowExceptionIfValuesAreZeroOrNegative()
        {
            //Act & Assert
            Assert.That(() => this.productStock.FindAllByQuantity(-100),
                Throws.ArgumentException
                .With.Message.EqualTo("Quantity cannot be zero or negative!"));
        }

        [Test]
        public void FindAllByQuantityMethodShouldReturnEmptyCollection()
        {
            //Arrange
            this.MultipleAddElementsInStock();

            //Act
            var emptyCollectionOfElements = this.productStock.FindAllByQuantity(100);

            //Assert
            Assert.That(emptyCollectionOfElements, Is.Empty);
        }

        [Test]
        public void FindAllByQuantityMethodShouldReturnCollectionInDescendingOrder()
        {
            //Arrange
            this.MultipleAddElementsInStock();

            //Act
            var collectionInDescendingOrder = this.productStock
                .FindAllByQuantity(20)
                .ToList();

            //Assert
            Assert.That(collectionInDescendingOrder.Count, Is.EqualTo(3));
            Assert.That(collectionInDescendingOrder[0].Label, Is.EqualTo("4"));
            Assert.That(collectionInDescendingOrder[1].Label, Is.EqualTo("5"));
            Assert.That(collectionInDescendingOrder[2].Label, Is.EqualTo("6"));
        }

        [Test]
        public void GetEnumeratorGenericMethodShouldReturnAllProductsInStock()
        {
            //Arrange
            this.MultipleAddElementsInStock();

            //Act
            var collection = this.productStock
                .ToList();

            //Assert
            Assert.That(collection.Count, Is.EqualTo(6));
            Assert.That(collection[0].Label, Is.EqualTo("1"));
            Assert.That(collection[1].Label, Is.EqualTo("2"));
            Assert.That(collection[2].Label, Is.EqualTo("3"));
            Assert.That(collection[3].Label, Is.EqualTo("4"));
            Assert.That(collection[4].Label, Is.EqualTo("5"));
            Assert.That(collection[5].Label, Is.EqualTo("6"));
        }

        [Test]
        public void GetIndexShouldBePossibleToAccessByIndex()
        {
            //Arrange
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            //Act
            var foundProduct = this.productStock[0];

            //Assert
            Assert.That(foundProduct, Is.Not.Null);
            Assert.That(foundProduct.Label, Is.EqualTo(FIRST_PRODUCT_LABEL));
            Assert.That(foundProduct.Price, Is.EqualTo(FIRST_PRODUCT_PRICE));
            Assert.That(foundProduct.Quantity, Is.EqualTo(FIRST_PRODUCT_QUANTITY));
        }

        [Test]
        public void SetIndexShouldThrowExcetionIfValueIsNull()
        {
            //Arrange
            this.productStock.Add(this.firstProduct);

            //Assert
            Assert.That(() => this.productStock[0] = null,
                Throws.ArgumentException
                .With.Message.EqualTo("Value cannot be null!"));
        }

        [Test]
        public void SetIndexShouldBePossibleToBeSetByIndex()
        {
            //Arrange
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            //Act
            this.productStock[0] = new Product("1", 12, 20);
            var foundProduct = this.productStock.Find(0);

            //Assert
            Assert.That(foundProduct, Is.Not.Null);
            Assert.That(foundProduct.Label, Is.EqualTo("1"));
            Assert.That(foundProduct.Price, Is.EqualTo(12));
            Assert.That(foundProduct.Quantity, Is.EqualTo(20));
        }


        private void MultipleAddElementsInStock()
        {
            this.productStock.Add(new Product("1", 10, 5));
            this.productStock.Add(new Product("2", 15, 10));
            this.productStock.Add(new Product("3", 20, 15));
            this.productStock.Add(new Product("4", 25, 20));
            this.productStock.Add(new Product("5", 25, 20));
            this.productStock.Add(new Product("6", 40, 20));
        }
    }
}
