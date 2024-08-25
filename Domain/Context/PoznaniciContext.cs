using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context
{
    public class PoznaniciContext : DbContext
    {
        public PoznaniciContext([NotNull] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Osoba> Osoba {  get; set; }
        public DbSet<Mesto> Mesto { get; set; }

        public DbSet<Osoba> PunoletniView { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Osoba>().ToTable("Osoba");
            builder.Entity<Mesto>().ToTable("Mesto");

            //builder.Entity<Osoba>().HasOne(o => o.MestoRodjenja).WithMany(m => m.Rodjeni).HasForeignKey(o => o.MestoRodjenjaId);
            //builder.Entity<Osoba>().HasOne(o => o.Prebivaliste).WithMany(m => m.Zive).HasForeignKey(o => o.PrebivalisteId);

        }
    }
}
