using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.Korisnik
{
    public class KorisnikUpsertRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Telefon { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public int ulogaId { get; set; }
        public int gradId { get; set; }
        public bool Aktivan { get; set; }
        public byte[] Slika { get; set; }
        public bool userEdit { get; set; }
    }
}
