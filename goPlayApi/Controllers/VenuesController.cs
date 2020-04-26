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
    public class VenuesController : ControllerBase
    {
        private readonly GoPlayDBContext _context;

        public VenuesController(GoPlayDBContext context)
        {
            _context = context;
        }

        // GET: api/Venues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
        {
            return await _context.Venues.Include(f=>f.VenueImages).ToListAsync();
        }

        // GET: api/Venues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venue>> GetVenue(int id)
        {
            var venue = await _context.Venues.Include(v=>v.VenueImages).Where(v=>v.VenueId==id).FirstOrDefaultAsync();

            if (venue == null)
            {
                return NotFound();
            }

            return venue;
        }

        // PUT: api/Venues/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenue(int id, Venue venue)
        {
            if (id != venue.VenueId)
            {
                return BadRequest();
            }

            _context.Entry(venue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(venue);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Venues
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Venue>> PostVenue(Venue venue)
        {
            _context.Venues.Add(venue);
            _context.VenuesImages.AddRange(venue.VenueImages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenue", new { id = venue.VenueId }, venue.VenueId);
        }

        // DELETE: api/Venues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Venue>> DeleteVenue(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }

            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();

            return venue;
        }

        [HttpPut("UpdateRatings/{id}")]
        public async Task<ActionResult<Venue>> UpdateRatings(int id, Venue venue)
        {
            var _venue = await _context.Venues.FindAsync(id);

            if(_venue == null)
            {
                return NotFound();
            }

            _venue.RatingCount++;
            var calculateRatings = (_venue.Ratings + venue.Ratings) / _venue.RatingCount;
            _venue.Ratings = calculateRatings;

            return _venue;
        }

        private bool VenueExists(int id)
        {
            return _context.Venues.Any(e => e.VenueId == id);
        }
    }
}
