using System.Collections.Generic;

namespace Put387.Database
{
    public class Kategorija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public byte[] Slika { get; set; }
        public List<Medalja> medalje { get; set; }
    }
}