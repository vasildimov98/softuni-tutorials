namespace AspNetCoreMVC.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using ViewModels;

    public class RazorController : Controller
    {
        public IActionResult RazorDemo()
        {
            var products = new List<Product>
            {
               new Product { Name = "keyboard", Price = 21.98M },
               new Product { Name = "mouse", Price = 14.98M },
               new Product { Name = "camera", Price = 30.59M },
               new Product { Name = "monitor", Price = 100.99M },
            };

            var model = new RazorViewModel
            {
                SomeText = "Sorry no products! :(",
                Products = products
            };

            return this.View(model);
        }
    }
}
