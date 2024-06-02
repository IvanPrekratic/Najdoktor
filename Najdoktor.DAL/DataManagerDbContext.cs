using Microsoft.EntityFrameworkCore;
using Najdoktor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najdoktor.DAL
{
    public class DataManagerDbContext : DbContext
    {
        public DataManagerDbContext(DbContextOptions<DataManagerDbContext> options)
            : base(options)
        {

        }
        public DbSet<Doktor> Doktori { get; set; }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Bolnica> Bolnice { get; set; }
        public DbSet<Recenzija> Recenzije { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 1, Naziv = "Zagreb" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 2, Naziv = "Velika Gorica" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 3, Naziv = "Vrbovsko" });
        }

        protected
    }
}
