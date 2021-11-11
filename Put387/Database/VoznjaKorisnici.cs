using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Database
{
    public class VoznjaKorisnici
    {
        public int Id { get; set; }
        public int korisnikId { get; set; }
        public Korisnik korisnik { get; set; }
        public int voznjaId { get; set; }
        public Voznja voznja { get; set; }
    }
}
