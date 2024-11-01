using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Botas.Models;
using BotasApi.Data;

namespace BotasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BotasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Botas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bota>>> GetBota()
        {
            return await _context.Bota.ToListAsync();
        }

        // GET: api/Botas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bota>> GetBota(Guid id)
        {
            var bota = await _context.Bota.FindAsync(id);

            if (bota == null)
            {
                return NotFound();
            }

            return bota;
        }

        // PUT: api/Botas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBota(Guid id, Bota bota)
        {
            if (id != bota.Id)
            {
                return BadRequest();
            }

            _context.Entry(bota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BotaExists(id))
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

        // POST: api/Botas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bota>> PostBota(Bota bota)
        {
            _context.Bota.Add(bota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBota", new { id = bota.Id }, bota);
        }

        // DELETE: api/Botas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBota(Guid id)
        {
            var bota = await _context.Bota.FindAsync(id);
            if (bota == null)
            {
                return NotFound();
            }

            _context.Bota.Remove(bota);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BotaExists(Guid id)
        {
            return _context.Bota.Any(e => e.Id == id);
        }
    }
}
