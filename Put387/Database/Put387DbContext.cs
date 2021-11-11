using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Put387.Database
{
    public partial class Put387DbContext : DbContext
    {
        public Put387DbContext()
        {

        }

        public Put387DbContext(DbContextOptions<Put387DbContext> options) : base(options)
        {

        }

        public DbSet<Detalji> Detalji { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Medalja> Medalja { get; set; }
        public DbSet<MedaljaKorisnik> MedaljaKorisnik { get; set; }
        public DbSet<Mjesto> Mjesto { get; set; }
        public DbSet<Poruka> Poruka { get; set; }
        public DbSet<TipVoznje> TipVoznje { get; set; }
        public DbSet<Vozilo> Vozilo { get; set; }
        public DbSet<VoziloDetalji> VoziloDetalji { get; set; }
        public DbSet<Voznja> Voznja { get; set; }
        public DbSet<VoznjaDojam> VoznjaDojam { get; set; }
        public DbSet<VoznjaKorisnici> VoznjaKorisnici { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Put387_DB;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detalji>(e =>
            {
                e.Property(p => p.Naziv).IsRequired();
                e.HasMany(x => x.voziloDetalji).WithOne(x => x.detalji).HasForeignKey(x => x.detaljiId);
            });


            modelBuilder.Entity<Kategorija>(e =>
            {
                e.Property(p => p.Naziv).IsRequired();
                e.HasMany(x => x.medalje).WithOne(x => x.kategorija).HasForeignKey(x => x.kategorijaId);
            });

            modelBuilder.Entity<Korisnik>(e =>
            {
                e.Property(p => p.Ime).IsRequired();
                e.Property(p => p.Prezime).IsRequired();
                e.Property(p => p.Telefon).IsRequired();
                e.Property(p => p.Email).IsRequired();
                e.Property(p => p.PasswordHash).IsRequired();
                e.Property(p => p.PasswordSalt).IsRequired();
                e.HasMany(x => x.medaljeKorisnici).WithOne(x => x.korisnik).HasForeignKey(x => x.korisnikId);
                e.HasMany(x => x.poruke).WithOne(x => x.korisnik).HasForeignKey(x => x.korisnikId);
                e.HasMany(x => x.voznje).WithOne(x => x.vozac).HasForeignKey(x => x.vozacId);
                e.HasMany(x => x.voznjePutnik).WithOne(x => x.korisnik).HasForeignKey(x => x.korisnikId);
                e.HasMany(x => x.voznjaDojmovi).WithOne(x => x.korisnik).HasForeignKey(x => x.korisnikId);
                e.HasMany(x => x.zahtjevi).WithOne(x => x.korisnik).HasForeignKey(x => x.korisnikId);


            });

            modelBuilder.Entity<Medalja>(e =>
            {
                e.Property(p => p.Naziv).IsRequired();
                e.Property(p => p.Opis).IsRequired();
                e.Property(p => p.MinBrojAkcija).IsRequired();
                e.Property(p => p.MaxBrojAkcija).IsRequired();
                e.HasOne(x => x.kategorija).WithMany(x => x.medalje).HasForeignKey(x => x.kategorijaId);
                e.HasMany(x => x.medaljeKorisnici).WithOne(x => x.medalja).HasForeignKey(x => x.medaljaId);
            });

            modelBuilder.Entity<MedaljaKorisnik>(e =>
            {
                e.Property(p => p.DatumKreiranja).IsRequired();
                e.HasOne(x => x.korisnik).WithMany(x => x.medaljeKorisnici).HasForeignKey(x => x.korisnikId);
                e.HasOne(x => x.medalja).WithMany(x => x.medaljeKorisnici).HasForeignKey(x => x.medaljaId);
            });

            modelBuilder.Entity<Mjesto>(e =>
            {
                e.Property(p => p.Naziv).IsRequired();
                e.HasMany(x => x.polazista).WithOne(x => x.polaziste).HasForeignKey(x => x.polazisteId);
                e.HasMany(x => x.odredista).WithOne(x => x.odrediste).HasForeignKey(x => x.odredisteId);
            });

            modelBuilder.Entity<Poruka>(e =>
            {
                e.Property(p => p.DatumVrijemeKreiranja).IsRequired();
                e.Property(p => p.Sadrzaj).IsRequired();
                e.HasOne(x => x.voznja).WithMany(x => x.poruke).HasForeignKey(x => x.voznjaId).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(x => x.korisnik).WithMany(x => x.poruke).HasForeignKey(x => x.korisnikId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TipVoznje>(e =>
            {
                e.Property(p => p.Naziv).IsRequired();
                e.HasMany(x => x.voznje).WithOne(x => x.tipVoznje).HasForeignKey(x => x.tipVoznjeId);
            });


            modelBuilder.Entity<Vozilo>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(p => p.Proizvodjac).IsRequired();
            });


            modelBuilder.Entity<VoziloDetalji>(e =>
            {
                e.HasOne(x => x.vozilo).WithMany(x => x.voziloDetalji).HasForeignKey(x => x.voziloId);
                e.HasOne(x => x.detalji).WithMany(x => x.voziloDetalji).HasForeignKey(x => x.detaljiId);
            });

            //added

            modelBuilder.Entity<Voznja>(e =>
            {
                e.Property(p => p.DatumVrijemePolaska).IsRequired();
                e.Property(p => p.BrojMjesta).IsRequired();
                e.Property(p => p.BrojSlobodnihMjesta).IsRequired();
                e.HasOne(x => x.polaziste).WithMany(x => x.polazista).HasForeignKey(x => x.polazisteId).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(x => x.odrediste).WithMany(x => x.odredista).HasForeignKey(x => x.odredisteId).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(x => x.vozac).WithMany(x => x.voznje).HasForeignKey(x => x.vozacId);
                e.HasMany(x => x.putnici).WithOne(x => x.voznja).HasForeignKey(x => x.voznjaId);
                e.HasMany(x => x.dojmovi).WithOne(x => x.voznja).HasForeignKey(x => x.voznjaId);
                e.HasOne(x => x.tipVoznje).WithMany(x => x.voznje).HasForeignKey(x => x.tipVoznjeId);
                e.HasMany(x => x.poruke).WithOne(x => x.voznja).HasForeignKey(x => x.voznjaId).OnDelete(DeleteBehavior.NoAction);
                e.HasMany(x => x.zahtjevi).WithOne(x => x.voznja).HasForeignKey(x => x.voznjaId);
            });

            modelBuilder.Entity<VoznjaDojam>(e =>
            {
                e.Property(p => p.DatumKreiranja).IsRequired();
                e.HasOne(x => x.voznja).WithMany(x => x.dojmovi).HasForeignKey(x => x.voznjaId).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(x => x.korisnik).WithMany(x => x.voznjaDojmovi).HasForeignKey(x => x.korisnikId).OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<VoznjaKorisnici>(e =>
            {
                e.HasOne(x => x.voznja).WithMany(x => x.putnici).HasForeignKey(x => x.voznjaId).OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Zahtjev>(e =>
            {
                e.Property(p => p.DatumKreiranja).IsRequired();
                e.Property(p => p.Status).IsRequired();
                e.HasOne(x => x.korisnik).WithMany(x => x.zahtjevi).HasForeignKey(x => x.korisnikId);
                e.HasOne(x => x.voznja).WithMany(x => x.zahtjevi).HasForeignKey(x => x.voznjaId).OnDelete(DeleteBehavior.NoAction);
            });

            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
