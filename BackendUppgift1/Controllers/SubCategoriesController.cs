
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
    public class SubCategoriesController : ControllerBase
    {
        private readonly SqlContext _context;

        public SubCategoriesController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/SubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategories()
        {
            return await _context.SubCategories.ToListAsync();
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategory>> GetSubCategory(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);

            if (subCategory == null)
            {
                return NotFound();
            }

            return subCategory;
        }

        // PUT: api/SubCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategory(int id, SubCategory subCategory)
        {
            if (id != subCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(subCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(id))
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

        // POST: api/SubCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubCategory>> PostSubCategory(CreateSubCategory model)
        {


            if (string.IsNullOrEmpty(model.SubCategoryName) || model.CategoryId > 0) //kollar så att texten inte är tom och att Id är större än noll.
            {
                var _subCategory = await _context.SubCategories.Where(x => x.SubCategoryName.ToLower() == model.SubCategoryName.ToLower()).FirstOrDefaultAsync();

                if (_subCategory == null) //Om kategorin inte finns så skapas den
                {
                    var subCategory = new SubCategory
                    {
                        SubCategoryName = model.SubCategoryName,
                        CategoryId = model.CategoryId

                    };
                    _context.SubCategories.Add(subCategory);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetSubCategory", new { id = subCategory.Id }, subCategory);
                }

                return new BadRequestObjectResult(new { message = "The subcategory already exists in database" }); //om subkategorinamnet är samma, ger ett 400 meddelande
            }
            return new BadRequestObjectResult(new { message = "must contain a subcategory" }); //om texten är tom, ges ett meddelande att fylla i alla fält







        }

        // DELETE: api/SubCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubCategoryExists(int id)
        {
            return _context.SubCategories.Any(e => e.Id == id);
        }
    }
}
