using Microsoft.EntityFrameworkCore;
using StoreMovie_ApiRest.Models;

namespace StoreMovie_ApiRest.Data
{
    public class StoreMovieDbContext:DbContext
    {
        public StoreMovieDbContext(DbContextOptions<StoreMovieDbContext> options)
    : base(options)
        { 
        }

        public DbSet<MovieGender> MovieGenders { get; set; }
        public DbSet<MoviesStore> moviesStores { get; set; }
        public DbSet<UserStore> UserStores { get; set; }
    }
}
