namespace Store.Tests
{
    using NUnit.Framework;
    using System.Collections.ObjectModel;

    [TestFixture]
    public class StoreManagerTests
    {
        //Arrange
        private const string NotPositiveQuantityExceptionMessage = "Product count can't be below or equal to zero.";
        private const string NoSuchProductExceptionMessage = "There is no such product.";
        private const string NotEnoughQuantityExceptionMessage = "There is not enough quantity of this product.";

        private const string NAME = "TEST";
        private const int QUANTITY = 10;
        private const decimal PRICE = 5.60m;

        private Product product;
        private StoreManager storeManager;

        //Act
        [SetUp]
        public void Setup()
        {
            this.product = new Product(NAME, QUANTITY, PRICE);
            this.storeManager = new StoreManager();
        }

        [Test]
        public void ConstructorShouldSetTheCorrectValue()
        {
            //Arrange
            var storeManager = new StoreManager();
            var product = new Product(NAME, QUANTITY, PRICE);

            //Assert
            Assert.That(storeManager, Is.Not.Null);
            Assert.That(storeManager.Products, Is.Not.Null);
            Assert.That(storeManager.Products.GetType().Name, Is.EqualTo(typeof(ReadOnlyCollection<Product>).Name));
            Assert.That(product.Name, Is.EqualTo(NAME));
            Assert.That(product.Quantity, Is.EqualTo(QUANTITY));
            Assert.That(product.Price, Is.EqualTo(PRICE));
        }

        [Test]
        public void AddProductShouldThrowExceptionIfValueIsNull()
        {
            //Arrange
            var nullProduct = (Product)null;
            var msg = "Value cannot be null. (Parameter 'product')";

            //Arrange
            Assert.That(() => this.storeManager.AddProduct(nullProduct),
                Throws.ArgumentNullException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AddProductShouldThrowExceptionIfProductQuantityIsLessOrEqualToZero()
        {
            //Arrange
            var invalidQuantity = 0;
            var invalidProduct = new Product(NAME, invalidQuantity, PRICE);

            //Arrange
            Assert.That(() => this.storeManager.AddProduct(invalidProduct),
                Throws.ArgumentException.With.Message.EqualTo(NotPositiveQuantityExceptionMessage));
        }

        [Test]
        public void AddProductShouldIncreaseCountIfMethodIsSuccessfull()
        {
            //Assert
            var firstExpectedCount = 0;
            Assert.That(this.storeManager.Count, Is.EqualTo(firstExpectedCount));

            //Arrange
            var productsToAdd = 5;
            this.AddProductsToStoreManager(productsToAdd);
            var expectedCount = 5;

            //Assert
            Assert.That(this.storeManager.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void BuyProductShouldThrowExceptionIfProductQuantityIsLessOrEqualToZero()
        {
            //Arrange 
            var msg = $"{NoSuchProductExceptionMessage} (Parameter 'product')";


            //Arrange
            Assert.That(() => this.storeManager.BuyProduct(NAME, QUANTITY),
                Throws.ArgumentNullException.With.Message.EqualTo(msg));
        }

        [Test]
        public void BuyProductShouldThrowExceptionIfThereIsNotEnoughQuantity()
        {
            //Arrange
            this.storeManager.AddProduct(this.product);

            //Assert
            Assert.That(() => this.storeManager.BuyProduct(NAME, QUANTITY * 2),
                Throws.ArgumentException.With.Message.EqualTo(NotEnoughQuantityExceptionMessage));
        }

        [Test]
        public void BuyProductMethodShouldReturnCorrectPriceAndDecreaseTheQunatityOfProduct()
        {
            //Arrange
            this.storeManager.AddProduct(this.product);
            var quantityToBuy = QUANTITY / 2;
            var expectedQuantity = QUANTITY - quantityToBuy;
            var expectedPrice = quantityToBuy * PRICE;

            //Act
            var actualPrice = this.storeManager.BuyProduct(NAME, quantityToBuy);

            //Assert
            Assert.That(this.product.Quantity, Is.EqualTo(expectedQuantity));
            Assert.That(actualPrice, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void GetTheMostExpensiveProductShouldReturnNullValueIfThereIsNoPRoductInCollection()
        {
            //Act
            var actualProduct = this.storeManager.GetTheMostExpensiveProduct();

            //Assert
            Assert.That(actualProduct, Is.EqualTo(null));
        }

        [Test]
        public void GetTheMostExpensiveProductShouldReturnTheOneWithighestPrice()
        {
            //Arrange
            var expectedPrice = PRICE * 5;
            var mostExpesiveProduct = new Product(NAME, QUANTITY, expectedPrice);
            this.storeManager.AddProduct(mostExpesiveProduct);
            var productsToAdd = 5;
            this.AddProductsToStoreManager(productsToAdd);

            //Act
            var actualProduct = this.storeManager.GetTheMostExpensiveProduct();

            //Assert
            Assert.That(actualProduct, Is.EqualTo(mostExpesiveProduct));
            Assert.That(actualProduct.Name, Is.EqualTo(NAME));
            Assert.That(actualProduct.Quantity, Is.EqualTo(QUANTITY));
            Assert.That(actualProduct.Price, Is.EqualTo(expectedPrice));
        }

        private void AddProductsToStoreManager(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                this.storeManager.AddProduct(this.product);
            }
        }
    }
}