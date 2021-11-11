using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Database
{
    public class VoziloDetalji
    {
        public int Id { get; set; }
        public int voziloId { get; set; }
        public Vozilo vozilo { get; set; }
        public int detaljiId { get; set; }
        public Detalji detalji { get; set; }
    }
}
