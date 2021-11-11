using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Models
{
    public class Medalja
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int kategorijaId { get; set; }
        public byte[] Ikonica { get; set; }
        public int MinBrojAkcija { get; set; }
        public int MaxBrojAkcija { get; set; }
        public string Opis { get; set; }
    }
}
