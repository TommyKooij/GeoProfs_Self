﻿using GeoProfs.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using GeoProfs.Models;

namespace GeoProfs.Areas.Identity.Data
{
    public class GeoProfsContext : IdentityDbContext<ApplicationUser>
    {
        public GeoProfsContext(DbContextOptions<GeoProfsContext> options)
            : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<AbsenceProposal> AbsenceProposals { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Worker>().ToTable("Worker");
            modelBuilder.Entity<AbsenceProposal>().ToTable("Absence Proposal");
            modelBuilder.Entity<Absence>().ToTable("Absence");
            modelBuilder.Entity<CalendarEvent>().ToTable("Calendar");*/
            base.OnModelCreating(modelBuilder);
        }
    }
}