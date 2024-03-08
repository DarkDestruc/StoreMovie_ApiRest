using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreMovie_ApiRest.Data;
using StoreMovie_ApiRest.Models;

namespace StoreMovie_ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGendersController : ControllerBase
    {
        private readonly StoreMovieDbContext _context;

        public MovieGendersController(StoreMovieDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieGenders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieGender>>> GetMovieGenders()
        {
          if (_context.MovieGenders == null)
          {
              return NotFound();
          }
            return await _context.MovieGenders.ToListAsync();
        }

        // GET: api/MovieGenders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieGender>> GetMovieGender(int id)
        {
          if (_context.MovieGenders == null)
          {
              return NotFound();
          }
            var movieGender = await _context.MovieGenders.FindAsync(id);

            if (movieGender == null)
            {
                return NotFound();
            }

            return movieGender;
        }

        // PUT: api/MovieGenders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieGender(int id, MovieGender movieGender)
        {
            if (id != movieGender.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieGender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieGenderExists(id))
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

        // POST: api/MovieGenders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieGender>> PostMovieGender(MovieGender movieGender)
        {
          if (_context.MovieGenders == null)
          {
              return Problem("Entity set 'StoreMovieDbContext.MovieGenders'  is null.");
          }
            _context.MovieGenders.Add(movieGender);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieGender", new { id = movieGender.Id }, movieGender);
        }

        // DELETE: api/MovieGenders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieGender(int id)
        {
            if (_context.MovieGenders == null)
            {
                return NotFound();
            }
            var movieGender = await _context.MovieGenders.FindAsync(id);
            if (movieGender == null)
            {
                return NotFound();
            }

            _context.MovieGenders.Remove(movieGender);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieGenderExists(int id)
        {
            return (_context.MovieGenders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
