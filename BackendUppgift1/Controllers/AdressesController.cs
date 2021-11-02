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
    public class AdressesController : ControllerBase
    {
        private readonly SqlContext _context;

        public AdressesController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Adresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adress>>> GetAdresses()
        {
            return await _context.Adresses.ToListAsync();
        }

        // GET: api/Adresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adress>> GetAdress(int id)
        {
            var adress = await _context.Adresses.FindAsync(id);

            if (adress == null)
            {
                return NotFound();
            }

            return adress;
        }

        // PUT: api/Adresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdress(int id, Adress adress)
        {
            if (id != adress.Id)
            {
                return BadRequest();
            }

            _context.Entry(adress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdressExists(id))
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

        // POST: api/Adresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adress>> PostAdress(CreateAdress model)
        {
            if (!string.IsNullOrEmpty(model.AdressLine) && model.ZipCode > 0 && !string.IsNullOrEmpty(model.City)) { 
            var _adress = await _context.Adresses.Where(x => x.AdressLine.ToLower() == model.AdressLine.ToLower()).FirstOrDefaultAsync();
            if(_adress == null)
            {
                    var adress = new Adress
                    {
                        AdressLine = model.AdressLine,
                        ZipCode = model.ZipCode,
                        City = model.City
                    };
                    _context.Adresses.Add(adress);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetAdress", new { id = adress.Id }, adress);
                }
                return new BadRequestObjectResult(new { message = "The adress already exists!" });

            }
            return new BadRequestObjectResult(new { message = "The Adress must contain all values to be saved" });
        }
        // DELETE: api/Adresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            var adress = await _context.Adresses.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }

            _context.Adresses.Remove(adress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdressExists(int id)
        {
            return _context.Adresses.Any(e => e.Id == id);
        }
    }
}
