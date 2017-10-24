using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GRRoWmvc.Models;

namespace GRRoWmvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Dog>()
                .HasIndex(d => d.DogId);
        }

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogUpdate> DogUpdates { get; set; }
        public DbSet<DogImage> DogImages { get; set; }
        public DbSet<ITRequest> ITRequests { get; set; }
        public DbSet<ITRequestFile> ITRequestFiles { get; set; }
        public DbSet<DogProfileImage> DogProfileImages { get; set; }
    }
}
