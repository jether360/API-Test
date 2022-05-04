using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public MedicinesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Medicines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DMedicines>>> GetDMedicine()
        {
            return await _context.DMedicine.ToListAsync();
        }

        // GET: api/Medicines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DMedicines>> GetDMedicines(long id)
        {
            var dMedicines = await _context.DMedicine.FindAsync(id);

            if (dMedicines == null)
            {
                return NotFound();
            }

            return dMedicines;
        }

        // PUT: api/Medicines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDMedicines(long id, DMedicines dMedicines)
        {
            if (id != dMedicines.Id)
            {
                return BadRequest();
            }

            _context.Entry(dMedicines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DMedicinesExists(id))
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

        // POST: api/Medicines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DMedicines>> PostDMedicines(DMedicines dMedicines)
        {
            _context.DMedicine.Add(dMedicines);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDMedicines", new { id = dMedicines.Id }, dMedicines);
        }

        // DELETE: api/Medicines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDMedicines(long id)
        {
            var dMedicines = await _context.DMedicine.FindAsync(id);
            if (dMedicines == null)
            {
                return NotFound();
            }

            _context.DMedicine.Remove(dMedicines);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DMedicinesExists(long id)
        {
            return _context.DMedicine.Any(e => e.Id == id);
        }
    }
}
