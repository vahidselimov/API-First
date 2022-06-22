using AP204First.Models;
using Microsoft.EntityFrameworkCore;

namespace AP204First.DAL
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> option) : base(option)
        {


        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}

