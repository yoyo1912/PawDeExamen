using Microsoft.EntityFrameworkCore;
using RedoPawProj.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RedoPawProj.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CompanieModel> Companii { get; set; }
        public DbSet<DomeniuActivitateModel> DomeniiActivitate { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<DomeniuActivitateModel>()
            //            .HasMany(d => d.Companii)
            //            .WithOne(c => c.DomeniuActivitate)
            //            .HasForeignKey(c => c.DomeniuActivitateId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DomeniuActivitateModel>().HasData(
                new DomeniuActivitateModel { Id = 1, Nume = "IT", Descriere = "Information Technology" },
                new DomeniuActivitateModel { Id = 2, Nume = "HR", Descriere = "Human Resources" }
            );

            modelBuilder.Entity<CompanieModel>().HasData(
                new CompanieModel { Id = 1, Nume = "Company A", Adresa = "123 Main St", NumarTelefon = "123456789", DataInfiintarii = DateTime.Now, DomeniuActivitateId = 1 },
                new CompanieModel { Id = 2, Nume = "Company B", Adresa = "456 Side St", NumarTelefon = "987654321", DataInfiintarii = DateTime.Now, DomeniuActivitateId = 2 }
            );
        }
    }
}
