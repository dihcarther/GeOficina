#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeOficina.Models;
using Microsoft.AspNetCore.Authorization;
using Xunit;
using Xunit.Sdk;
 

namespace GeOficina.Controllers
{
    
    [Route("[controller]")]
    [ApiController]

    
    public class ServicosModelsController : ControllerBase
    {
        private readonly ContextoDb _context;

        public ServicosModelsController(ContextoDb context)
        {
            _context = context;
        }

        // GET: api/ServicosModels
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicosModel>>> GetServicosModel()
        {
            return await _context.ServicosModel.ToListAsync();
        }

        // GET: api/ServicosModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicosModel>> GetServicosModel(int id)
        {
            var servicosModel = await _context.ServicosModel.FindAsync(id);

            if (servicosModel == null)
            {
                return NotFound();
            }

            return servicosModel;
        }

        // PUT: api/ServicosModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicosModel(int id, ServicosModel servicosModel)
        {
            if (id != servicosModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicosModelExists(id))
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

        // POST: api/ServicosModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServicosModel>> PostServicosModel(ServicosModel servicosModel)
        {
            _context.ServicosModel.Add(servicosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicosModel", new { id = servicosModel.Id }, servicosModel);
        }

        // DELETE: api/ServicosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicosModel(int id)
        {
            var servicosModel = await _context.ServicosModel.FindAsync(id);
            if (servicosModel == null)
            {
                return NotFound();
            }

            _context.ServicosModel.Remove(servicosModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicosModelExists(int id)
        {
            return _context.ServicosModel.Any(e => e.Id == id);
        }
    }
}
