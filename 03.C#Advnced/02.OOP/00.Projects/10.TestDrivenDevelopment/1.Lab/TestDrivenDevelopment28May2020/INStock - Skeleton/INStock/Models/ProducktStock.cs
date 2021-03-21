namespace INStock.Models
{
    using INStock.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Xml.Serialization;

    public class ProducktStock : IProductStock
    {
        private readonly List<IProduct> productsByIndex;
        private readonly HashSet<string> productLabels;
        private readonly Dictionary<string, IProduct> productsByLabel;
        private readonly SortedDictionary<decimal, List<IProduct>> sortedProductsByPrice;
        private readonly Dictionary<int, List<IProduct>> productsByQuantity;
        public ProducktStock()
        {
            this.productLabels = new HashSet<string>();
            this.productsByIndex = new List<IProduct>();
            this.productsByLabel = new Dictionary<string, IProduct>();
            this.sortedProductsByPrice = new SortedDictionary<decimal, List<IProduct>>(
                Comparer<decimal>.Create((first, second) => second.CompareTo(first)));
            this.productsByQuantity = new Dictionary<int, List<IProduct>>();
        }
        public int Count => this.productsByIndex.Count;

        public void Add(IProduct product)
        {
            if (this.productLabels.Contains(product.Label))
            {
                throw new
                    ArgumentException("Cannot add products with duplicate label in stock!");
            }

            var label = product.Label;
            var price = product.Price;
            var quantity = product.Quantity;

            this.IntializeCollection(product);

            this.productLabels.Add(label);
            this.productsByIndex.Add(product);
            this.productsByLabel[label] = product;
            this.sortedProductsByPrice[price].Add(product);
            this.productsByQuantity[quantity].Add(product);
        }

        public bool Remove(IProduct product)
        {
            if (!this.productLabels.Contains(product.Label))
            {
                return false;
            }

            var label = product.Label;

            this.productsByIndex.RemoveAll(pr => pr.Label == label);

            this.RemoveCollections(product);

            return true;
        }

        public bool Contains(IProduct product)
        {
            this.ValidateNullException(product);

            return this.productLabels.Contains(product.Label);
        }


        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentException("Index is out of range");
            }

            return this.productsByIndex[index];
        }
        public IProduct FindByLabel(string label)
        {
            if (label == null)
            {
                throw new ArgumentException("Argument cannot be null!");
            }

            if (!productLabels.Contains(label))
            {
                throw new ArgumentException("Product not found!");
            }

            return productsByLabel[label];
        }
        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            if (lo <= 0 || hi <= 0)
            {
                throw new ArgumentException("Price cannot be zero or negative!");
            }

            var list = new List<IProduct>();

            foreach (var (price, products) in this.sortedProductsByPrice)
            {
                var priceAsDouble = (double)price;
                if (lo <= priceAsDouble && priceAsDouble <= hi)
                {
                    list.AddRange(products);
                }

                if (priceAsDouble < lo)
                {
                    break;
                }
            }

            return list;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Price cannot be zero or negative!");
            }
            var priceAsDecimal = (decimal)price;
            return !this.sortedProductsByPrice.ContainsKey(priceAsDecimal)
                ? Enumerable.Empty<IProduct>()
                : this.sortedProductsByPrice[priceAsDecimal];
        }
        public IProduct FindMostExpensiveProduct()
        {
            if (!productLabels.Any())
            {
                throw new ArgumentException("Product could not be found!");
            }

            var mostExpensiveProducts = this.sortedProductsByPrice.Values.First();
            var mostExpensiveProduct = mostExpensiveProducts.First();

            return mostExpensiveProduct;
        }
        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be zero or negative!");
            }

            return !productsByQuantity.ContainsKey(quantity)
                ? Enumerable.Empty<IProduct>()
                : productsByQuantity[quantity];
        }

        public IProduct this[int index]
        {
            get => this.Find(index);
            set 
            {
                this.ValidateNullException(value);

                this.RemoveCollections(this.Find(index));

                this.IntializeCollection(value);

                this.productsByIndex[index] = value;
            }
        }
        public IEnumerator<IProduct> GetEnumerator() => this.productsByIndex.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ValidateNullException(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentException("Value cannot be null!");
            }
        }
        private void IntializeCollection(IProduct product)
        {
            var price = product.Price;
            var quantity = product.Quantity;

            if (!this.sortedProductsByPrice.ContainsKey(price))
            {
                this.sortedProductsByPrice[price] = new List<IProduct>();
            }
            if (!this.productsByQuantity.ContainsKey(quantity))
            {
                this.productsByQuantity[quantity] = new List<IProduct>();
            }
        }

        private void RemoveCollections(IProduct product)
        {
            var label = product.Label;

            this.productLabels.Remove(label);
            this.productsByLabel.Remove(label);

            var productsByPrices = this.sortedProductsByPrice[product.Price];
            productsByPrices.RemoveAll(pr => pr.Price == product.Price);

            var productsByQuantities = this.productsByQuantity[product.Quantity];
            productsByQuantities.RemoveAll(pr => pr.Quantity == product.Quantity);
        }
    }
}
