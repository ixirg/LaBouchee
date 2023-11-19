using LaBouchee.Models;
using Microsoft.EntityFrameworkCore;

namespace LaBouchee.DAL
{
    public class IngredientsDbContext : DbContext
    {
        public IngredientsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Ingredients> Ingredients { get; set; }

    }
}
