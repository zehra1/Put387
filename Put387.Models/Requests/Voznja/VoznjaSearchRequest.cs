using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Requests.Voznja
{
    public class VoznjaSearchRequest
    {
        public int polazisteId { get; set; }
        public string NazivPolazista { get; set; }
        public int odredisteId { get; set; }
        public string odredisteNaziv { get; set; }
        public int vozacId { get; set; }
        public string vozacIme { get; set; }
        public int tipVoznjeId { get; set; }
        public string tipVoznjeNaziv { get; set; }
        public DateTime? OdDatuma { get; set; }
        public DateTime? DoDatuma { get; set; }
        public int BrojSlobodnihMjesta { get; set; }
        public bool Aktivna { get; set; }
        public bool Cijena { get; set; }
        public string searchBy { get; set; }
        public bool desc { get; set; }
    }
}
