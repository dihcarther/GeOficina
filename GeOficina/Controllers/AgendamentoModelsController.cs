#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeOficina.Models;

namespace GeOficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoModelsController : ControllerBase
    {
        private readonly ContextoDb _context;

        public AgendamentoModelsController(ContextoDb context)
        {
            _context = context;
        }

        // GET: api/AgendamentoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoModel>>> GetAgendamentoModel()
        {
            return await _context.AgendamentoModel.ToListAsync();
        }

        // GET: api/AgendamentoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoModel>> GetAgendamentoModel(int id)
        {
            var agendamentoModel = await _context.AgendamentoModel.FindAsync(id);

            if (agendamentoModel == null)
            {
                return NotFound();
            }

            return agendamentoModel;
        }

        // PUT: api/AgendamentoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamentoModel(int id, AgendamentoModel agendamentoModel)
        {
            if (id != agendamentoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(agendamentoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoModelExists(id))
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

        // POST: api/AgendamentoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgendamentoModel>> PostAgendamentoModel(AgendamentoModel agendamentoModel)
        {
            _context.AgendamentoModel.Add(agendamentoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgendamentoModel", new { id = agendamentoModel.Id }, agendamentoModel);
        }

        // DELETE: api/AgendamentoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamentoModel(int id)
        {
            var agendamentoModel = await _context.AgendamentoModel.FindAsync(id);
            if (agendamentoModel == null)
            {
                return NotFound();
            }

            _context.AgendamentoModel.Remove(agendamentoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgendamentoModelExists(int id)
        {
            return _context.AgendamentoModel.Any(e => e.Id == id);
        }
    }
}
