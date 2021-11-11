using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.Medalja
{
    public class MedaljaSearchRequest
    {
        public string Naziv { get; set; }
        public byte[] Ikonica { get; set; }
        public int BrojAkcija { get; set; }
        public string Opis { get; set; }
        public string nazivKategorije { get; set; }
        public int kategorijaId { get; set; }
    }
}
