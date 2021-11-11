using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Telefon { get; set; }
        public byte[] Slika { get; set; }
        public bool Aktivan { get; set; }
        public int ulogaId { get; set; }
        public int gradId { get; set; }
        public Uloga uloga { get; set; }
        public Grad grad { get; set; }
        public DateTime DatumRegistracije { get; set; }
    }
}
