using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.Medalja
{
    public class MedaljaInsertRequest
    {
        public string Naziv { get; set; }
        public int kategorijaId { get; set; }
        public byte[] Ikonica { get; set; }
        public int MinBrojAkcija { get; set; }
        public int MaxBrojAkcija { get; set; }
        public string Opis { get; set; }
    }
}
