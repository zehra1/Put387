using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.Korisnik
{
    public class KorisnikSearchRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int UlogaId { get; set; }
        public int GradId { get; set; }
    }
}
