using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GeoProfs.Data
{
    public class GeoProfsContext : IdentityDbContext
    {
        public GeoProfsContext(DbContextOptions<GeoProfsContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AbsenceProposal> AbsenceProposals { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<AbsenceProposal>().ToTable("Absence Proposal");
            modelBuilder.Entity<Absence>().ToTable("Absence");
            modelBuilder.Entity<CalendarEvent>().ToTable("Calendar");
            modelBuilder.Entity<Manager>().ToTable("Manager");*/
            base.OnModelCreating(modelBuilder);
        }
    }
}