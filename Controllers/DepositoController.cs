using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using banco_api.Models;

namespace banco_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositoController : ControllerBase
    {
        private readonly banco_idatContext _context;

        public DepositoController(banco_idatContext context)
        {
            _context = context;
        }

        // GET: api/Deposito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deposito>>> GetDepositos()
        {
            return await _context.Depositos.Include(c => c.ClienteNavigation).ToListAsync();
        }

        // GET: api/Deposito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deposito>> GetDeposito(int id)
        {
            var deposito = await _context.Depositos.Include(c => c.ClienteNavigation).FirstOrDefaultAsync(d => d.Cliente == id);

            if (deposito == null)
            {
                return NotFound();
            }

            return deposito;
        }

        // PUT: api/Deposito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeposito(int id, Deposito deposito)
        {
            if (id != deposito.Id)
            {
                return BadRequest();
            }

            _context.Entry(deposito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositoExists(id))
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

        // POST: api/Deposito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deposito>> PostDeposito(Deposito deposito)
        {
            _context.Depositos.Add(deposito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeposito", new { id = deposito.Id }, deposito);
        }

        // DELETE: api/Deposito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeposito(int id)
        {
            var deposito = await _context.Depositos.FindAsync(id);
            if (deposito == null)
            {
                return NotFound();
            }

            _context.Depositos.Remove(deposito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepositoExists(int id)
        {
            return _context.Depositos.Any(e => e.Id == id);
        }
    }
}
