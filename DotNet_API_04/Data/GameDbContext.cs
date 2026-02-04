using DotNet_API_04.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_API_04.Data
{
    public class GameDbContext(DbContextOptions<GameDbContext> options) : DbContext(options)
    {
        //private readonly GameDbContext _context;

        public DbSet<Game> Games => Set<Game>();
    }

      
}
