using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.ViewModels
{
    public class VoznjaVM
    {
        public int voznjaId { get; set; }
        public string polaziste { get; set; }
        public string odrediste { get; set; }
        public DateTime datumPolaska { get; set; }
        public double ocjena { get; set; }
    }
}
