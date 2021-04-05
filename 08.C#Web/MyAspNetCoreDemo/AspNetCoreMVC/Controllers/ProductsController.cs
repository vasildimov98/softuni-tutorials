namespace AspNetCoreMVC.Controllers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;

    using ViewModels.Products;

    public class ProductsController : Controller
    {
        private static int count;

        private readonly IWebHostEnvironment environment;

        public ProductsController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public IActionResult Add()
        {
            var model = new AddProductInputModel
            {
                IsAvailable = true,
                ArrivedOn = DateTime.UtcNow,
                Description = "Some random description",
                Type = Data.Enum.ProductType.Unknown
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductInputModel input)
        {
            if (!input.Image.FileName.EndsWith(".jpg"))
            {
                this.ModelState.AddModelError("Image", "Invalid image extensition. Only .jpg");
            }

            if (input.Image.Length >= 10 * 1024 * 1024)
            {
                this.ModelState.AddModelError("Image", "Image too big. Should be less than 10 GB");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var filePath = this.environment.WebRootPath + $"/dogHttp{++count}.jpg";
            using var fileStream = new FileStream(filePath, FileMode.Create);

            await input.Image.CopyToAsync(fileStream);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            var filePath = this.environment.WebRootPath + $"/dogHttp{count}.jpg";
            return this.PhysicalFile(filePath, "image/jpg");
        }
    }
}
