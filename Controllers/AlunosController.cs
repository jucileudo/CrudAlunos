#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudAlunos;
using CrudAlunos.Models;

namespace CrudAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AlunosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alunos>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alunos>> GetAlunos(Guid id)
        {
            var alunos = await _context.Alunos.FindAsync(id);

            if (alunos == null)
            {
                return NotFound();
            }

            return alunos;
        }

        // PUT: api/Alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlunos(Guid id, Alunos alunos)
        {
            if (id != alunos.Id)
            {
                return BadRequest();
            }

            _context.Entry(alunos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunosExists(id))
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

        // POST: api/Alunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alunos>> Casdastrar(Alunos alunos)
        {
            var id = new Guid();
            alunos.Id = id;
            _context.Alunos.Add(alunos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlunos", new { id = alunos.Id }, alunos);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlunos(Guid id)
        {
            var alunos = await _context.Alunos.FindAsync(id);
            if (alunos == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(alunos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunosExists(Guid id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
