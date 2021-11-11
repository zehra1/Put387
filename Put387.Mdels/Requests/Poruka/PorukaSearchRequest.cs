using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.Poruka
{
    public class PorukaSearchRequest
    {
        public int korisnikId { get; set; }
        public string korisnikUsername { get; set; }
        public int vozacId { get; set; }
        public int voznjaId { get; set; }
        public bool chatovi { get; set; }
    }
}
