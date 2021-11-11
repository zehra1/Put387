using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Put387.Models.ViewModels
{
    public class MedaljeKategorijeVM
    {
        public int Id { get; set; }
        public byte[] Slika { get; set; }
        public string nazivKategorije { get; set; }
        public string brojAkcija { get; set; }
    }
}
