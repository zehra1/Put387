using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Models
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
