using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Database
{
    public class Vozilo
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int KorisnikId { get; set; }
        public Korisnik korisnik { get; set; }
        public string Proizvodjac { get; set; }
        public string TipGoriva { get; set; }
        public string BrojRegistracije { get; set; }
        public List<VoziloDetalji> voziloDetalji { get; set; }
    }
}
