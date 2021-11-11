using System;
using System.Collections.Generic;

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
