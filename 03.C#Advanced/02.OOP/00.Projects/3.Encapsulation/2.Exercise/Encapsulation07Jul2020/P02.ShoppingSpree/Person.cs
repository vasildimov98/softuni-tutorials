namespace P02.ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private int money;
        private ICollection<Product> products;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;

            this.products = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }
        public int Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            if (this.Money - product.Cost < 0)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.products.Add(product);

            this.Money -= product.Cost;

            return $"{this.Name} bought {product}";
        }
        public override string ToString()
        {
            var products = this.products.Count > 0 ?
                string.Join(", ", this.products) :
                "Nothing bought";

            return $"{this.Name} - {products}";
        }
    }
}
