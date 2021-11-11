using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.VoznjaDojam
{
    public class VoznjeDojamInsertRequest
    {
        public int voznjaId { get; set; }
        public int Ocjena { get; set; }
        public string Komentar { get; set; }
        public int korisnikId { get; set; }
        public int zahtjevId { get; set; }
    }
}
