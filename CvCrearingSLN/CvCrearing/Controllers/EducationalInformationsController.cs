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
    public class EducationalInformationsController : ControllerBase
    {
        private readonly CvDBContext _context;

        public EducationalInformationsController(CvDBContext context)
        {
            _context = context;
        }

        // GET: api/EducationalInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationalInformation>>> GetEducationalInformation()
        {
            return await _context.EducationalInformation.ToListAsync();
        }

        // GET: api/EducationalInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationalInformation>> GetEducationalInformation(int id)
        {
            var educationalInformation = await _context.EducationalInformation.FindAsync(id);

            if (educationalInformation == null)
            {
                return NotFound();
            }

            return educationalInformation;
        }

        // PUT: api/EducationalInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationalInformation(int id, EducationalInformation educationalInformation)
        {
            if (id != educationalInformation.ID)
            {
                return BadRequest();
            }

            _context.Entry(educationalInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationalInformationExists(id))
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

        // POST: api/EducationalInformations
        [HttpPost]
        public async Task<ActionResult<EducationalInformation>> PostEducationalInformation(EducationalInformation educationalInformation)
        {
            _context.EducationalInformation.Add(educationalInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationalInformation", new { id = educationalInformation.ID }, educationalInformation);
        }

        // DELETE: api/EducationalInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EducationalInformation>> DeleteEducationalInformation(int id)
        {
            var educationalInformation = await _context.EducationalInformation.FindAsync(id);
            if (educationalInformation == null)
            {
                return NotFound();
            }

            _context.EducationalInformation.Remove(educationalInformation);
            await _context.SaveChangesAsync();

            return educationalInformation;
        }

        private bool EducationalInformationExists(int id)
        {
            return _context.EducationalInformation.Any(e => e.ID == id);
        }
    }
}
