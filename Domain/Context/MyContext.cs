using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Context
{
    public class MyContext : DbContext
    {
        public MyContext([NotNull] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> Person {  get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<HomeType> HomeType { get; set; }

        public DbSet<Person> AdultView { get; set; }
        public DbSet<Person> SmederevciView { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>().ToTable("Person");
            builder.Entity<City>().ToTable("City");
            builder.Entity<Address>().ToTable("Address");
            builder.Entity<HomeType>().ToTable("HomeType");

            //builder.Entity<Osoba>().HasOne(o => o.MestoRodjenja).WithMany(m => m.Rodjeni).HasForeignKey(o => o.MestoRodjenjaId);
            //builder.Entity<Osoba>().HasOne(o => o.Prebivaliste).WithMany(m => m.Zive).HasForeignKey(o => o.PrebivalisteId);

        }
    }
}
