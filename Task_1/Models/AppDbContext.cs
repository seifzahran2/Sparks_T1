using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Sparks_Task_1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Transaction> transactions { get; set; }
    }
}
