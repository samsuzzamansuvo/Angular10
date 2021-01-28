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
    public class PersonalInfoTabsController : ControllerBase
    {
        private readonly CvDBContext _context;

        public PersonalInfoTabsController(CvDBContext context)
        {
            _context = context;
        }

        // GET: api/PersonalInfoTabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalInfoTab>>> GetPersonalInfoTabs()
        {
            return await _context.PersonalInfoTabs.ToListAsync();
        }

        // GET: api/PersonalInfoTabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalInfoTab>> GetPersonalInfoTab(int id)
        {
            var personalInfoTab = await _context.PersonalInfoTabs.FindAsync(id);

            if (personalInfoTab == null)
            {
                return NotFound();
            }

            return personalInfoTab;
        }

        // PUT: api/PersonalInfoTabs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalInfoTab(int id, PersonalInfoTab personalInfoTab)
        {
            if (id != personalInfoTab.ID)
            {
                return BadRequest();
            }

            _context.Entry(personalInfoTab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInfoTabExists(id))
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

        // POST: api/PersonalInfoTabs
        [HttpPost]
        public async Task<ActionResult<PersonalInfoTab>> PostPersonalInfoTab(PersonalInfoTab personalInfoTab)
        {
            _context.PersonalInfoTabs.Add(personalInfoTab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalInfoTab", new { id = personalInfoTab.ID }, personalInfoTab);
        }

        // DELETE: api/PersonalInfoTabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonalInfoTab>> DeletePersonalInfoTab(int id)
        {
            var personalInfoTab = await _context.PersonalInfoTabs.FindAsync(id);
            if (personalInfoTab == null)
            {
                return NotFound();
            }

            _context.PersonalInfoTabs.Remove(personalInfoTab);
            await _context.SaveChangesAsync();

            return personalInfoTab;
        }

        private bool PersonalInfoTabExists(int id)
        {
            return _context.PersonalInfoTabs.Any(e => e.ID == id);
        }
    }
}
