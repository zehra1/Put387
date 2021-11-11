using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Put387.Models.ViewModels
{
   public class StatistikaVozacaVM
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public int BrojVoznji { get; set; }
        public double ProsjecnaOcjena { get; set; }
    }
}
