using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using goPlayApi;
using goPlayApi.Models;

namespace goPlayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamificationsController : ControllerBase
    {
        private readonly GoPlayDBContext _context;

        public GamificationsController(GoPlayDBContext context)
        {
            _context = context;
        }

        // GET: api/Gamifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gamification>>> GetGamification()
        {
            return await _context.Gamification.Include(u=>u.User).ToListAsync();
        }

        // GET: api/Gamifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gamification>> GetGamification(int id)
        {
            var gamification = await _context.Gamification.FindAsync(id);

            if (gamification == null)
            {
                return NotFound();
            }

            return gamification;
        }

        // PUT: api/Gamifications/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamification(int id, Gamification gamification)
        {
            if (id != gamification.GamificationId)
            {
                return BadRequest();
            }

            _context.Entry(gamification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpPut("UpdatePoints/{userId}")]
        public async Task<IActionResult> UpdatePoints(int userId)
        {
            var gamification = await _context.Gamification.Where(g => g.UserId == userId).FirstOrDefaultAsync();

            if(gamification != null)
            {
                gamification.Points += 10;

                return Ok(gamification);
            }
            return BadRequest();
        }

        // POST: api/Gamifications
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Gamification>> PostGamification(Gamification gamification)
        {
            _context.Gamification.Add(gamification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamification", new { id = gamification.GamificationId }, gamification.GamificationId);
        }

        // DELETE: api/Gamifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gamification>> DeleteGamification(int id)
        {
            var gamification = await _context.Gamification.FindAsync(id);
            if (gamification == null)
            {
                return NotFound();
            }

            _context.Gamification.Remove(gamification);
            await _context.SaveChangesAsync();

            return gamification;
        }

        private bool GamificationExists(int id)
        {
            return _context.Gamification.Any(e => e.GamificationId == id);
        }
    }
}
