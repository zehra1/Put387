using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Database
{
    public class Mjesto
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<Voznja> polazista { get; set; }
        public List<Voznja> odredista { get; set; }
    }
}
