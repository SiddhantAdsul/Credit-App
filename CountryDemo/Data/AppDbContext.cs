using CountryDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
            
        }
        public DbSet<Loan> Loans { get; set; }
    }
}
