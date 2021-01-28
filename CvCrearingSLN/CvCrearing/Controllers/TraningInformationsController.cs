using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CvCrearing.Models;

namespace CvCrearing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraningInformationsController : ControllerBase
    {
        private readonly CvDBContext _context;

        public TraningInformationsController(CvDBContext context)
        {
            _context = context;
        }

        // GET: api/TraningInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraningInformation>>> GetTraningInformation()
        {
            return await _context.TraningInformation.ToListAsync();
        }

        // GET: api/TraningInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraningInformation>> GetTraningInformation(int id)
        {
            var traningInformation = await _context.TraningInformation.FindAsync(id);

            if (traningInformation == null)
            {
                return NotFound();
            }

            return traningInformation;
        }

        // PUT: api/TraningInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraningInformation(int id, TraningInformation traningInformation)
        {
            if (id != traningInformation.ID)
            {
                return BadRequest();
            }

            _context.Entry(traningInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraningInformationExists(id))
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

        // POST: api/TraningInformations
        [HttpPost]
        public async Task<ActionResult<TraningInformation>> PostTraningInformation(TraningInformation traningInformation)
        {
            _context.TraningInformation.Add(traningInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraningInformation", new { id = traningInformation.ID }, traningInformation);
        }

        // DELETE: api/TraningInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TraningInformation>> DeleteTraningInformation(int id)
        {
            var traningInformation = await _context.TraningInformation.FindAsync(id);
            if (traningInformation == null)
            {
                return NotFound();
            }

            _context.TraningInformation.Remove(traningInformation);
            await _context.SaveChangesAsync();

            return traningInformation;
        }

        private bool TraningInformationExists(int id)
        {
            return _context.TraningInformation.Any(e => e.ID == id);
        }
    }
}
