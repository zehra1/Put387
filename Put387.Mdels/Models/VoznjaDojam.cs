using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Models
{
    public class VoznjaDojam
    {
        public int Id { get; set; }
        public int voznjaId { get; set; }
        public Voznja voznja { get; set; }
        public int Ocjena { get; set; }
        public string Komentar { get; set; }
        public int korisnikId { get; set; }
        public Korisnik korisnik { get; set; }
        public DateTime DatumKreiranja { get; set; }
    }
}
