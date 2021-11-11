using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Database
{
    public class Medalja
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int kategorijaId { get; set; }
        public Kategorija kategorija { get; set; }
        public byte[] Ikonica { get; set; }
        public int MinBrojAkcija { get; set; }
        public int MaxBrojAkcija { get; set; }
        public string Opis { get; set; }
        public List<MedaljaKorisnik> medaljeKorisnici { get; set; }
    }
}
