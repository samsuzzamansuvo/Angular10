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
    public class CareerinformationsController : ControllerBase
    {
        private readonly CvDBContext _context;

        public CareerinformationsController(CvDBContext context)
        {
            _context = context;
        }

        // GET: api/Careerinformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Careerinformation>>> GetCareerinformations()
        {
            return await _context.Careerinformations.ToListAsync();
        }

        // GET: api/Careerinformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Careerinformation>> GetCareerinformation(int id)
        {
            var careerinformation = await _context.Careerinformations.FindAsync(id);

            if (careerinformation == null)
            {
                return NotFound();
            }

            return careerinformation;
        }

        // PUT: api/Careerinformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareerinformation(int id, Careerinformation careerinformation)
        {
            if (id != careerinformation.ID)
            {
                return BadRequest();
            }

            _context.Entry(careerinformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerinformationExists(id))
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

        // POST: api/Careerinformations
        [HttpPost]
        public async Task<ActionResult<Careerinformation>> PostCareerinformation(Careerinformation careerinformation)
        {
            _context.Careerinformations.Add(careerinformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCareerinformation", new { id = careerinformation.ID }, careerinformation);
        }

        // DELETE: api/Careerinformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Careerinformation>> DeleteCareerinformation(int id)
        {
            var careerinformation = await _context.Careerinformations.FindAsync(id);
            if (careerinformation == null)
            {
                return NotFound();
            }

            _context.Careerinformations.Remove(careerinformation);
            await _context.SaveChangesAsync();

            return careerinformation;
        }

        private bool CareerinformationExists(int id)
        {
            return _context.Careerinformations.Any(e => e.ID == id);
        }
    }
}
