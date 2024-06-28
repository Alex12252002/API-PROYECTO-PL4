using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba3Parcial.Modelo;

namespace Prueba3Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaMantenimientoesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TareaMantenimientoesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/TareaMantenimientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaMantenimiento>>> GettareaMantenimientos()
        {
            return await _context.tareaMantenimientos.ToListAsync();
        }

        // GET: api/TareaMantenimientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TareaMantenimiento>> GetTareaMantenimiento(int id)
        {
            var tareaMantenimiento = await _context.tareaMantenimientos.FindAsync(id);

            if (tareaMantenimiento == null)
            {
                return NotFound();
            }

            return tareaMantenimiento;
        }

        // PUT: api/TareaMantenimientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTareaMantenimiento(int id, TareaMantenimiento tareaMantenimiento)
        {
            if (id != tareaMantenimiento.idMantenimiento)
            {
                return BadRequest();
            }

            _context.Entry(tareaMantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaMantenimientoExists(id))
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

        // POST: api/TareaMantenimientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TareaMantenimiento>> PostTareaMantenimiento(TareaMantenimiento tareaMantenimiento)
        {
            _context.tareaMantenimientos.Add(tareaMantenimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTareaMantenimiento", new { id = tareaMantenimiento.idMantenimiento }, tareaMantenimiento);
        }

        // DELETE: api/TareaMantenimientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTareaMantenimiento(int id)
        {
            var tareaMantenimiento = await _context.tareaMantenimientos.FindAsync(id);
            if (tareaMantenimiento == null)
            {
                return NotFound();
            }

            _context.tareaMantenimientos.Remove(tareaMantenimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TareaMantenimientoExists(int id)
        {
            return _context.tareaMantenimientos.Any(e => e.idMantenimiento == id);
        }
    }
}
