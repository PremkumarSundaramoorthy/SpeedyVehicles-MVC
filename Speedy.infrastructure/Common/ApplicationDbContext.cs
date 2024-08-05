﻿using Microsoft.EntityFrameworkCore;
using Speedy.Domain.Models;

namespace Speedy.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<VehicleType> VehicleType { get; set; }

        public DbSet<Post> Post { get; set; }
    }
}
