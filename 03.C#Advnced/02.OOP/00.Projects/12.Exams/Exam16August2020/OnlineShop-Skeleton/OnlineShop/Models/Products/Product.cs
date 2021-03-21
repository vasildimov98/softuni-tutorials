namespace OnlineShop.Models.Products
{
    using System;

    using Common.Constants;

    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        protected Product(int id,
            string manufacturer,
            string model, 
            decimal price,
            double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => this.id;
            private set
            {
                if (value <= 0)
                {
                    var msg = ExceptionMessages.InvalidProductId;
                    this.ThrowArgumentExceptions(msg);
                }
                
                this.id = value;
            }
        }

        public string Manufacturer
        {
            get => this.manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var msg = ExceptionMessages.InvalidManufacturer;
                    this.ThrowArgumentExceptions(msg);
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var msg = ExceptionMessages.InvalidModel;
                    this.ThrowArgumentExceptions(msg);
                }

                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    var msg = ExceptionMessages.InvalidPrice;
                    this.ThrowArgumentExceptions(msg);
                }

                this.price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => this.overallPerformance;
            private set
            {
                if (value <= 0)
                {
                    var msg = ExceptionMessages.InvalidOverallPerformance;
                    this.ThrowArgumentExceptions(msg);
                }

                this.overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance:F2}. Price: {this.Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }

        private void ThrowArgumentExceptions(string msg)
        {
            throw new ArgumentException(msg);
        }
    }
}
