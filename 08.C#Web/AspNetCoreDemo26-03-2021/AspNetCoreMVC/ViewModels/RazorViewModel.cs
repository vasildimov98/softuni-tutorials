namespace AspNetCoreMVC.ViewModels
{
    using System.Collections.Generic;

    public class RazorViewModel
    {
        public string SomeText { get; set; }

        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
