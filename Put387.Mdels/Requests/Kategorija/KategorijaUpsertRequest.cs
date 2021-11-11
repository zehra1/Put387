using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Put387.Models.Requests.Kategorija
{
    public class KategorijaUpsertRequest
    {
        public string Naziv { get; set; }
        public byte[] Slika { get; set; }
    }
}
