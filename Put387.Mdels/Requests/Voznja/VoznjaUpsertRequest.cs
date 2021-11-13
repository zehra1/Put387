using System;
using System.Collections.Generic;
using System.Text;
namespace Put387.Model.Requests.Voznja
{
    public class VoznjaUpsertRequest
    {
        public int polazisteId { get; set; }
        public int odredisteId { get; set; }
        public int vozacId { get; set; }
        public int tipVoznjeId { get; set; }
        public string DatumVrijemePolaska { get; set; }
        public int BrojMjesta { get; set; }
        public int BrojSlobodnihMjesta { get; set; }
        public string Napomena { get; set; }
        public bool Aktivna { get; set; }
        public int Cijena { get; set; }
        public string editBrojMjesta { get; set; }
    }
}
