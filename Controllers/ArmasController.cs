using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _context;

        public ArmasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Armas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arma>>> GetArmas()
        {
            return await _context.Armas.ToListAsync();
        }

        // GET: api/Armas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arma>> GetArma(int id)
        {
            var arma = await _context.Armas.FindAsync(id);

            if (arma == null)
            {
                return NotFound();
            }

            return arma;
        }

        // POST: api/Armas
        [HttpPost]
        public async Task<ActionResult<Arma>> PostArma(Arma arma)
        {
            _context.Armas.Add(arma);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetArma),
                new { id = arma.Id },
                arma
            );
        }

        // PUT: api/Armas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArma(int id, Arma arma)
        {
            if (id != arma.Id)
            {
                return BadRequest();
            }

            _context.Entry(arma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmaExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Armas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArma(int id)
        {
            var arma = await _context.Armas.FindAsync(id);

            if (arma == null)
            {
                return NotFound();
            }

            _context.Armas.Remove(arma);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArmaExists(int id)
        {
            return _context.Armas.Any(e => e.Id == id);
        }
    }
}
