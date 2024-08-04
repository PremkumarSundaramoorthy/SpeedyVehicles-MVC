using Microsoft.EntityFrameworkCore;
using Speedy.Domain.Models;
using Speedy.Domain.Modles;

namespace Speedy.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<VehicleType> VehicleType { get; set; }
    }
}
