using Microsoft.EntityFrameworkCore;
using Web.CW._19248.Models;

namespace Web.CW._19248.Data
{
    public class GeneralDbContext : DbContext
    {
        public GeneralDbContext(DbContextOptions<GeneralDbContext> opts) : base(opts) { }
        public DbSet<Contact> ContactDatabase { get; set; }
        public DbSet<Category> CategoryDatabase { get; set; }
    }
}
