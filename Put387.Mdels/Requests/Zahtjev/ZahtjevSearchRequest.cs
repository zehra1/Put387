using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.Zahtjev
{
    public class ZahtjevSearchRequest
    {
        public int VozacId { get; set; }
        public int KorisnikId { get; set; }
        public string ImeVozaca { get; set; }
    }
}
