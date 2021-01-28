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
    public class CandidateTabsController : ControllerBase
    {
        private readonly CvDBContext _context;

        public CandidateTabsController(CvDBContext context)
        {
            _context = context;
        }

        // GET: api/CandidateTabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateTab>>> GetCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        // GET: api/CandidateTabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateTab>> GetCandidateTab(int id)
        {
            var candidateTab = await _context.Candidates.FindAsync(id);

            if (candidateTab == null)
            {
                return NotFound();
            }

            return candidateTab;
        }

        // PUT: api/CandidateTabs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidateTab(int id, CandidateTab candidateTab)
        {
            if (id != candidateTab.CandidateID)
            {
                return BadRequest();
            }

            _context.Entry(candidateTab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateTabExists(id))
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

        // POST: api/CandidateTabs
        [HttpPost]
        public async Task<ActionResult<CandidateTab>> PostCandidateTab(CandidateTab candidateTab)
        {
            _context.Candidates.Add(candidateTab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidateTab", new { id = candidateTab.CandidateID }, candidateTab);
        }

        // DELETE: api/CandidateTabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CandidateTab>> DeleteCandidateTab(int id)
        {
            var candidateTab = await _context.Candidates.FindAsync(id);
            if (candidateTab == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidateTab);
            await _context.SaveChangesAsync();

            return candidateTab;
        }

        private bool CandidateTabExists(int id)
        {
            return _context.Candidates.Any(e => e.CandidateID == id);
        }
    }
}
