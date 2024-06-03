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
        
        public DbSet<Doktor> Doktori { get; set; }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Bolnica> Bolnice { get; set; }
        public DbSet<Recenzija> Recenzije { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Specijalizacija> Specijalizacije { get; set; }
        public DataManagerDbContext(DbContextOptions<DataManagerDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 1, Naziv = "Zagreb" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 2, Naziv = "Velika Gorica" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 3, Naziv = "Karlovac" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 4, Naziv = "Rijeka" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 5, Naziv = "Split" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 6, Naziv = "Osijek" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 7, Naziv = "Zadar" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 8, Naziv = "Dubrovnik" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 9, Naziv = "Pula" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 10, Naziv = "Varaždin" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 11, Naziv = "Čakovec" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 12, Naziv = "Koprivnica" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 13, Naziv = "Sisak" });
            modelBuilder.Entity<Grad>().HasData(new Grad { ID = 14, Naziv = "Vrbovsko" });

            modelBuilder.Entity<Bolnica>().HasData(new Bolnica { ID = 1, Naziv = "KBC Zagreb", Adresa = "Kišpatićeva 12", GradID = 1 });
            modelBuilder.Entity<Bolnica>().HasData(new Bolnica { ID = 2, Naziv = "KBC Rijeka", Adresa = "Krešimirova 42", GradID = 4 });
            modelBuilder.Entity<Bolnica>().HasData(new Bolnica { ID = 3, Naziv = "KBC Split", Adresa = "Firule 12", GradID = 5 });
            modelBuilder.Entity<Bolnica>().HasData(new Bolnica { ID = 4, Naziv = "KBC Osijek", Adresa = "Josipa Huttlera 4", GradID = 6 });
            modelBuilder.Entity<Bolnica>().HasData(new Bolnica { ID = 5, Naziv = "OB Zadar", Adresa = "Bože Peričića 5", GradID = 7 });
            modelBuilder.Entity<Bolnica>().HasData(new Bolnica { ID = 6, Naziv = "OB Dubrovnik", Adresa = "Dr. Roka Mišetića 2", GradID = 8 });
            modelBuilder.Entity<Bolnica>().HasData(new Bolnica { ID = 7, Naziv = "OB Pula", Adresa = "Santoriova 24", GradID = 9 });
            modelBuilder.Entity<Bolnica>().HasData(new Bolnica { ID = 8, Naziv = "OB Varaždin", Adresa = "Ivana Meštrovića 1", GradID = 10 });
            modelBuilder.Entity<Bolnica>().HasData(new Bolnica { ID = 9, Naziv = "ŽB Čakovec", Adresa = "Ivana Gorana Kovačića 1E", GradID = 11 });
            modelBuilder.Entity<Bolnica>().HasData(new Bolnica { ID = 10, Naziv = "OB Karlovac", Adresa = "Andrije Štampara 3", GradID = 3 });

            modelBuilder.Entity<Specijalizacija>().HasData(new Specijalizacija { ID = 1, NazivSpecijalizacije = "Opća medicina" });
            modelBuilder.Entity<Specijalizacija>().HasData(new Specijalizacija { ID = 2, NazivSpecijalizacije = "Dermatologija" });
            modelBuilder.Entity<Specijalizacija>().HasData(new Specijalizacija { ID = 3, NazivSpecijalizacije = "Oftalmologija" });
            modelBuilder.Entity<Specijalizacija>().HasData(new Specijalizacija { ID = 4, NazivSpecijalizacije = "Ortopedija" });
            modelBuilder.Entity<Specijalizacija>().HasData(new Specijalizacija { ID = 5, NazivSpecijalizacije = "Ginekologija" });
            modelBuilder.Entity<Specijalizacija>().HasData(new Specijalizacija { ID = 6, NazivSpecijalizacije = "Pedijatrija" });
            modelBuilder.Entity<Specijalizacija>().HasData(new Specijalizacija { ID = 7, NazivSpecijalizacije = "Kardiologija" });
            modelBuilder.Entity<Specijalizacija>().HasData(new Specijalizacija { ID = 8, NazivSpecijalizacije = "Neurologija" });
            modelBuilder.Entity<Specijalizacija>().HasData(new Specijalizacija { ID = 9, NazivSpecijalizacije = "Psihijatrija" });
            modelBuilder.Entity<Specijalizacija>().HasData(new Specijalizacija { ID = 10, NazivSpecijalizacije = "Radiologija" });
        }

    }
}
