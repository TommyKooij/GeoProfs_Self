using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Models;

namespace GeoProfs.Data
{
    public class GeoProfsContext : DbContext
    {
        public GeoProfsContext (DbContextOptions<GeoProfsContext> options)
            : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Worker>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
        }
    }
}
