using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using DataAccess.Entities;

namespace DataAccess
{
    public class FrankoMapsDbContext : DbContext
    {
        public FrankoMapsDbContext(): base() { }
        public DbSet<Distance> Distances { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Point> Points { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Map>()
                .HasMany(m => m.Points)
                .WithOne(p => p.Map)
                .OnDelete(DeleteBehavior.Restrict);
            
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FrankoMapsDataBase;Trusted_Connection=True;");
        }
    }
}
