using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Models
{
    public class Vozilo
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string TipGoriva { get; set; }
        public string BrojRegistracije { get; set; }
    }
}
