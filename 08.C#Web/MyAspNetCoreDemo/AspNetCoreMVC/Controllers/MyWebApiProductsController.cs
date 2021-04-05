namespace AspNetCoreMVC.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Data.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class MyWebApiProductsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public MyWebApiProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = this.dbContext.Products.ToList();

            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = this.dbContext.Products.Find(id);

            if (product == null)
            {
                return this.NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await this.dbContext.AddAsync(product);
            await this.dbContext.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int? id, Product product)
        {
            if (id == null) return this.BadRequest();

            this.dbContext.Attach(product);

            await this.dbContext.SaveChangesAsync();

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null) return this.NotFound();

            var product = this.dbContext.Products.Find((int)id);

            this.dbContext.Products.Remove(product);

            this.dbContext.SaveChanges();

            return this.NoContent();
        }
    }
}
