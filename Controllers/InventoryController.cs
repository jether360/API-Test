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
    public class InventoryController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public InventoryController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/Inventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories()
        {
            return await _context.Inventories.ToListAsync();
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(Guid id)
        {
            var inventory = await _context.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        // PUT: api/Inventory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(Guid id, Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/Inventory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { id = inventory.Id }, inventory);
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(Guid id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryExists(Guid id)
        {
            return _context.Inventories.Any(e => e.Id == id);
        }
    }
}
