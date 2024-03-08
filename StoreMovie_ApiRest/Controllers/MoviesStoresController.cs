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
    public class MoviesStoresController : ControllerBase
    {
        private readonly StoreMovieDbContext _context;

        public MoviesStoresController(StoreMovieDbContext context)
        {
            _context = context;
        }

        // GET: api/MoviesStores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoviesStore>>> GetmoviesStores()
        {
          if (_context.moviesStores == null)
          {
              return NotFound();
          }
            return await _context.moviesStores.ToListAsync();
        }

        // GET: api/MoviesStores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoviesStore>> GetMoviesStore(int id)
        {
          if (_context.moviesStores == null)
          {
              return NotFound();
          }
            var moviesStore = await _context.moviesStores.FindAsync(id);

            if (moviesStore == null)
            {
                return NotFound();
            }

            return moviesStore;
        }

        // PUT: api/MoviesStores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoviesStore(int id, MoviesStore moviesStore)
        {
            if (id != moviesStore.Id)
            {
                return BadRequest();
            }

            _context.Entry(moviesStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesStoreExists(id))
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

        // POST: api/MoviesStores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MoviesStore>> PostMoviesStore(MoviesStore moviesStore)
        {
          if (_context.moviesStores == null)
          {
              return Problem("Entity set 'StoreMovieDbContext.moviesStores'  is null.");
          }
            _context.moviesStores.Add(moviesStore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoviesStore", new { id = moviesStore.Id }, moviesStore);
        }

        // DELETE: api/MoviesStores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoviesStore(int id)
        {
            if (_context.moviesStores == null)
            {
                return NotFound();
            }
            var moviesStore = await _context.moviesStores.FindAsync(id);
            if (moviesStore == null)
            {
                return NotFound();
            }

            _context.moviesStores.Remove(moviesStore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoviesStoreExists(int id)
        {
            return (_context.moviesStores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
