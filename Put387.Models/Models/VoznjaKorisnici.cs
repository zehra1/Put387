using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Models
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
