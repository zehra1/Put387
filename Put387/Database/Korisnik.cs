using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Database
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Telefon { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public byte[] Slika { get; set; }
        public bool Aktivan { get; set; }
        public int ulogaId { get; set; }
        public Uloga uloga { get; set; }
        public int gradId { get; set; }
        public Grad grad { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public List<MedaljaKorisnik> medaljeKorisnici{ get; set; }
        public List<Poruka> poruke{ get; set; }
        public List<Voznja> voznje { get; set; }
        public List<VoznjaKorisnici> voznjePutnik { get; set; }
        public List<VoznjaDojam> voznjaDojmovi { get; set; }
        public List<Zahtjev> zahtjevi { get; set; }
    }
}
