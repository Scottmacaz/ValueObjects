using Microsoft.EntityFrameworkCore;
using System;
using ValueObjects.Domain;

namespace ValueObjects.SqlServer
{
    public class ValueObjectsContext : DbContext
    {
        public DbSet<Student> Students {get; set;}

        public string DbPath { get; }

        public ValueObjectsContext()
        {
            DbPath = $"c:\\misc\\valueobjects.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations
            modelBuilder.Entity<Student>(e =>
            {
                e.Property(p => p.Email)
                    .HasConversion(p => p.Value, p => Email.Create(p).Value);
                e.Property(p => p.Username)
                    .HasConversion(p => p.Value, p => Username.Create(p).Value);
                e.Property(p => p.GradeLevel)
                    .HasConversion<string>();
            });
            
        }
    }
}
