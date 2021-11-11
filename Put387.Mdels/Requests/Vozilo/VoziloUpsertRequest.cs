using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.Vozilo
{
    public class VoziloUpsertRequest
    {
        public int KorisnikId { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string TipGoriva { get; set; }
        public string BrojRegistracije { get; set; }
    }
}
