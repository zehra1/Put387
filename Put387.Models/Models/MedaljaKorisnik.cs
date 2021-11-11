using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Models
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
