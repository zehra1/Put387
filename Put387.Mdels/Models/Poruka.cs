using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Models
{
    public class Poruka
    {
        public int Id { get; set; }
        public string Sadrzaj { get; set; }
        public int korisnikId { get; set; }
        public Korisnik korisnik { get; set; }
        public int voznjaId { get; set; }
        public Voznja voznja { get; set; }
        public string DatumVrijemeKreiranja { get; set; }
        public IEnumerable<string> usernames { get; set; }
        public IEnumerable<string> voznjes { get; set; }
        public IEnumerable<string> usernameIds { get; set; }

    }
}
