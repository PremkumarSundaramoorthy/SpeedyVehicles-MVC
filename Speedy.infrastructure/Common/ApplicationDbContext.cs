using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Speedy.Domain.Models;

namespace Speedy.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<VehicleType> VehicleType { get; set; }

        public DbSet<Post> Post { get; set; }
    }
}
