using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Database
{
    public class TipVoznje
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<Voznja> voznje { get; set; }
    }
}
