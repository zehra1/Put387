using System;

namespace Put387.Database
{
    public class Zahtjev
    {
        public int Id { get; set; }
        public int voznjaId { get; set; }
        public Voznja voznja { get; set; }
        public int korisnikId { get; set; }
        public Korisnik korisnik { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public int BrojMjesta { get; set; }
        public bool Status { get; set; }
        public bool isReviewed { get; set; }
        public bool isPaid { get; set; }
    }
}