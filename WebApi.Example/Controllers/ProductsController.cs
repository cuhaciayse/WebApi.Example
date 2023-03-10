using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using WebApi.Example.Entities;

namespace WebApi.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Context _context;

        public ProductsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_context.Products.FirstOrDefault(x => x.Id == id));
        }

        [HttpPut("{id}")]   
        public IActionResult UpdateProduct(int id, Product product)
        {
            var updatedProduct = _context.Products.FirstOrDefault(x => x.Id == id);
            updatedProduct.Name=product.Name;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deletedProduct = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Remove(deletedProduct);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return Created("",product);
        }
    }
}
