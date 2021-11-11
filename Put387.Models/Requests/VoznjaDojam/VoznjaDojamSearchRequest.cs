using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Put387.Model.Requests.VoznjaDojam
{
    public class VoznjaDojamSearchRequest
    {
        public string vozacIme { get; set; }
        public string KorisnikIme { get; set; }
        public int voznjaId { get; set; }
        public int vozacId { get; set; }
    }
}
