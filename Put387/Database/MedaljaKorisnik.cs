using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Database
{
    public class MedaljaKorisnik
    {
        public int Id { get; set; }
        public int medaljaId { get; set; }
        public Medalja medalja { get; set; }
        public int korisnikId { get; set; }
        public Korisnik korisnik { get; set; }
        public DateTime DatumKreiranja { get; set; }
    }
}
