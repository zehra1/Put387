using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.Zahtjev
{
    public class ZahtjevUpsertRequest
    {
        public int voznjaId { get; set; }
        public int korisnikId { get; set; }
        public int BrojMjesta { get; set; }
        public bool Status { get; set; }
        public bool isPaid { get; set; }
        public bool onlyPay { get; set; }
    }
}
