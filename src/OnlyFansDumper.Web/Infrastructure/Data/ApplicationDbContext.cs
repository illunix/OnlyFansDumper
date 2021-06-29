using Microsoft.EntityFrameworkCore;
using OnlyFansDumper.Web.Features.Miners.Models;

namespace OnlyFansDumper.Web.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Miner> Miners { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}