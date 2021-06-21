namespace INStock.Tests
{
    using INStock.Models;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        //Arrange
        private const string FIRST_PRODUCT_LABEL = "First Test Label";
        private const decimal FIRST_PRODUCT_PRICE = 20m;
        private const int FIRST_PRODUCT_QUANTITY = 5;

        private Product product;

        [SetUp]
        public void SetUpClass()
        {
            this.product = new Product(FIRST_PRODUCT_LABEL, FIRST_PRODUCT_PRICE, FIRST_PRODUCT_QUANTITY);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void LebelPropertyCannotBeNullOrEmpty(string productLabel)
        {
            Assert
                //Act
                .That(() => new Product(productLabel, FIRST_PRODUCT_PRICE, FIRST_PRODUCT_QUANTITY),
                //Assert
                Throws.ArgumentException
                .With.Message.EqualTo("Label cannot be null or empty!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void PricePropertyCannotBeZeroOrNegative(decimal productPrice)
        {
            Assert
                //Act
                .That(() => new Product(FIRST_PRODUCT_LABEL, productPrice, FIRST_PRODUCT_QUANTITY),
                //Assert
                Throws.ArgumentException
                .With.Message.EqualTo("Price cannot be zero or negative!"));
        }

        [Test]
        public void QuantityPropertyCannotBeLessThanZero()
        {
            Assert
               //Act
               .That(() => new Product(FIRST_PRODUCT_LABEL, FIRST_PRODUCT_PRICE, -FIRST_PRODUCT_QUANTITY),
               //Assert
               Throws.ArgumentException
               .With.Message.EqualTo("Quantity cannot be negative!"));
        }

        [Test]
        public void ConstructorShoudlGetAndSetValuesOnProperties()
        {
            //Assert
            Assert.That(this.product.Label, Is.EqualTo(FIRST_PRODUCT_LABEL));
            Assert.That(this.product.Price, Is.EqualTo(FIRST_PRODUCT_PRICE));
            Assert.That(this.product.Quantity, Is.EqualTo(FIRST_PRODUCT_QUANTITY));
        }

        [Test]
        public void ProductShouldCompareByPriceWhenOrderIsIncorrenct()
        {
            //Arrange
            var smallerProduct = new Product($"{FIRST_PRODUCT_LABEL}1", FIRST_PRODUCT_PRICE / 2, FIRST_PRODUCT_QUANTITY);

            //Act
            var result = smallerProduct.CompareTo(product);

            //Assert
            Assert.That(result < 0, Is.True);
        }

        [Test]
        public void ProductShouldCompareByPriceWhenOrderIsEqual()
        {
            //Arrange
            var euqalProduct = new Product($"{FIRST_PRODUCT_LABEL}1", FIRST_PRODUCT_PRICE, FIRST_PRODUCT_QUANTITY);

            //Act
            var result = euqalProduct.CompareTo(product);

            //Assert
            Assert.That(result == 0, Is.True);
        }

        [Test]
        public void ProductShouldCompareByPriceWhenOrderIsCorrenct()
        {
            //Arrange
            var biggerProduct = new Product($"{FIRST_PRODUCT_LABEL}1", FIRST_PRODUCT_PRICE * 2, FIRST_PRODUCT_QUANTITY);

            //Act
            var result = biggerProduct.CompareTo(product);

            //Assert
            Assert.That(result > 0, Is.True);
        }
    }
}