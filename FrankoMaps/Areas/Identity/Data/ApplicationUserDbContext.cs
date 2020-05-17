using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrankoMaps.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FrankoMaps.Data
{
    public class ApplicationUserDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserDbContext() : base() { }
        public ApplicationUserDbContext(DbContextOptions<ApplicationUserDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FrankoMapsDataBase;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
