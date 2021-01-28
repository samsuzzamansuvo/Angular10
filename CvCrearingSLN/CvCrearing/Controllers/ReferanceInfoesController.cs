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
    public class ReferanceInfoesController : ControllerBase
    {
        private readonly CvDBContext _context;

        public ReferanceInfoesController(CvDBContext context)
        {
            _context = context;
        }

        // GET: api/ReferanceInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReferanceInfo>>> GetReferanceInfos()
        {
            return await _context.ReferanceInfos.ToListAsync();
        }

        // GET: api/ReferanceInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferanceInfo>> GetReferanceInfo(int id)
        {
            var referanceInfo = await _context.ReferanceInfos.FindAsync(id);

            if (referanceInfo == null)
            {
                return NotFound();
            }

            return referanceInfo;
        }

        // PUT: api/ReferanceInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferanceInfo(int id, ReferanceInfo referanceInfo)
        {
            if (id != referanceInfo.ID)
            {
                return BadRequest();
            }

            _context.Entry(referanceInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferanceInfoExists(id))
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

        // POST: api/ReferanceInfoes
        [HttpPost]
        public async Task<ActionResult<ReferanceInfo>> PostReferanceInfo(ReferanceInfo referanceInfo)
        {
            _context.ReferanceInfos.Add(referanceInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReferanceInfo", new { id = referanceInfo.ID }, referanceInfo);
        }

        // DELETE: api/ReferanceInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReferanceInfo>> DeleteReferanceInfo(int id)
        {
            var referanceInfo = await _context.ReferanceInfos.FindAsync(id);
            if (referanceInfo == null)
            {
                return NotFound();
            }

            _context.ReferanceInfos.Remove(referanceInfo);
            await _context.SaveChangesAsync();

            return referanceInfo;
        }

        private bool ReferanceInfoExists(int id)
        {
            return _context.ReferanceInfos.Any(e => e.ID == id);
        }
    }
}
