using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.Poruka
{
    public class PorukaInsertRequest
    {
        public string Sadrzaj { get; set; }
        public int korisnikId { get; set; }
        public int voznjaId { get; set; }
    }
}
