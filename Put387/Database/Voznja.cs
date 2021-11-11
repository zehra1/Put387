using System;
using System.Collections.Generic;

namespace Put387.Database
{
    public class Voznja
    {
        public int Id { get; set; }
        public int polazisteId { get; set; }
        public Mjesto polaziste { get; set; }
        public int odredisteId { get; set; }
        public Mjesto odrediste { get; set; }
        public int vozacId { get; set; }
        public Korisnik vozac { get; set; }
        public List<VoznjaKorisnici> putnici { get; set; }
        public List<VoznjaDojam> dojmovi { get; set; }
        public int tipVoznjeId { get; set; }
        public TipVoznje tipVoznje { get; set; }
        public DateTime DatumVrijemePolaska { get; set; }
        public int BrojMjesta { get; set; }
        public int BrojSlobodnihMjesta { get; set; }
        public string Napomena { get; set; }
        public bool Aktivna { get; set; }
        public List<Poruka> poruke { get; set; }
        public List<Zahtjev> zahtjevi { get; set; }
        public int Cijena { get; set; }
        public DateTime DatumObjave { get; set; }
    }
}