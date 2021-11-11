using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.ViewModels
{
    public class KorisnikVM
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        public string Grad { get; set; }
        public string Status { get; set; }
    }
}
