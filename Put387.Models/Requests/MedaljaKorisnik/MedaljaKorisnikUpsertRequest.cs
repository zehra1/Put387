using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.MedaljaKorisnik
{
    public class MedaljaKorisnikUpsertRequest
    {
        public int medaljaId { get; set; }
        public int korisnikId { get; set; }
    }
}
