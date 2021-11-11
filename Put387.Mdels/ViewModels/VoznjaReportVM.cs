using Put387.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Put387.Models.ViewModels
{
    public class VoznjaReportVM
    {
        public Voznja Vozac { get; set; }
        public List<VoznjaDojam> Dojmovi { get; set; }
        public double ProsjecnaOcjena { get; set; }
    }
}
