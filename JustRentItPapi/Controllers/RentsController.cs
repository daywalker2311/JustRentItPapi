using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustRentItPapi.Entities;

namespace JustRentItPapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly projectContext _context;

        public RentsController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Rents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rents>>> GetRents()
        {
            return await _context.Rents.ToListAsync();
        }

        // GET: api/Rents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rents>> GetRents(string id)
        {
            var rents = await _context.Rents.FindAsync(id);

            if (rents == null)
            {
                return NotFound();
            }

            return rents;
        }

        // PUT: api/Rents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRents(string id, Rents rents)
        {
            if (id != rents.Id)
            {
                return BadRequest();
            }

            _context.Entry(rents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentsExists(id))
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

        // POST: api/Rents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rents>> PostRents(Rents rents)
        {
            _context.Rents.Add(rents);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RentsExists(rents.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRents", new { id = rents.Id }, rents);
        }

        // DELETE: api/Rents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rents>> DeleteRents(string id)
        {
            var rents = await _context.Rents.FindAsync(id);
            if (rents == null)
            {
                return NotFound();
            }

            _context.Rents.Remove(rents);
            await _context.SaveChangesAsync();

            return rents;
        }

        private bool RentsExists(string id)
        {
            return _context.Rents.Any(e => e.Id == id);
        }
    }
}
