using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Database
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
