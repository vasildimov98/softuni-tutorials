using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace P03.ShoppingSpree.Modules
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bagOfProducts;

        private Person()
        {
            this.bagOfProducts = new List<Product>();
        }
        public Person(string name, int money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
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
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> BagOfProducts => this.bagOfProducts;

        public string AddProduct([AllowNull]Product product)
        {
            if (product == null || this.Money - product.Cost < 0)
            {
                throw new ArgumentException($"{this.Name} can't afford {product.ToString()}");
            }
            this.Money -= product.Cost;

            this.bagOfProducts.Add(product);

            return $"{this.Name} bought {product}";
        }

        public override string ToString()
        {
            var products = this.BagOfProducts.Count > 0 
                ? string.Join(", ", this.bagOfProducts)
                : "Nothing bought";

            return $"{this.Name} - {products}";
        }
    }
}
