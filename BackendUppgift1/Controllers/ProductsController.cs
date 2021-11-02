using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendProjekt1;
using BackendProjekt1.Models;
using BackendUppgift1.Models;

namespace BackendUppgift1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SqlContext _context;

        public ProductsController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }





        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(CreateProduct model)
        {
            if(!string.IsNullOrEmpty(model.ProductName) && model.SubCategoryId > 0 && model.ProductPrice > 0) //om produktnamnet inte är noll, kategoriId är större än noll och att det finns ett pris som är större än noll
            {
                var _product = await _context.Products.Where(x => x.ProductName.ToLower() == model.ProductName.ToLower()).FirstOrDefaultAsync();
                if(_product == null)
                {
                    var product = new Product
                    {
                        ProductName = model.ProductName,
                        ProductDescription = model.ProductDescription,
                        ProductPrice = model.ProductPrice,
                        ProductImageLink = model.ProductImageLink,
                        SubCategoryId = model.SubCategoryId
                    };
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
                }
                return new BadRequestObjectResult(new { message = "product already exists!" });
            }
            return new BadRequestObjectResult(new { message = "The product must contain all the required values" });
        }





        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
