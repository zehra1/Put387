using Microsoft.Reporting.WinForms;
using Put387.Model.Requests.Vozilo;
using Put387.Model.Requests.VoznjaKorisnici;
using Put387.Models.ViewModels;
using Put387.WinUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Put387.Win.Izvjestaji
{
    public partial class frmVoznjaDetaljiRPT : Form
    {
        private VoznjaReportVM _data;
        protected APIService _voziloService = new APIService("Vozilo");
        protected APIService _vService = new APIService("VoznjaKorisnici");
        protected APIService _korisniciService = new APIService("Korisnik");

        public frmVoznjaDetaljiRPT()
        {
            InitializeComponent();
        }

        public frmVoznjaDetaljiRPT(VoznjaReportVM data) : this()
        {
            _data=data;
        }

        private async void frmVoznjaDetaljiRPT_Load(object sender, EventArgs e)
        {
            VoziloSearchRequest req = new VoziloSearchRequest()
            {
                vozacId = _data.Vozac.vozacId
            };
            var vozilo =await _voziloService.Get<List<Model.Models.Vozilo>>(req);

            VoznjaKorisniciSearchRequest reqK = new VoznjaKorisniciSearchRequest()
            {
                voznjaId=_data.Vozac.Id
            };
            var korisnici = await _vService.Get<List<Model.Models.VoznjaKorisnici>>(reqK);
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ImeVozaca", $"{_data.Vozac.vozac.Ime} {_data.Vozac.vozac.Prezime}"));
            rpc.Add(new ReportParameter("destinacija", $"{_data.Vozac.polaziste.Naziv} - {_data.Vozac.odrediste.Naziv}"));
            rpc.Add(new ReportParameter("Datum", DateTime.Now.ToString("dd.MM.yyyy")));
            rpc.Add(new ReportParameter("Prosjecna", _data.Vozac.Ocjena.ToString()));
            rpc.Add(new ReportParameter("Vozilo", vozilo.Count==0?"Nema": vozilo[0].Proizvodjac));
            

            List<object> data = new List<object>();
            int i = 0;

            foreach (var k in korisnici)
            {
                var sadrzaj = "";
                var datum = "";
                var ocjena = "";
                var korisnik = k.korisnik.Username;

                foreach (var d in _data.Dojmovi)
                {
                    if (k.korisnikId == d.korisnikId)
                    {
                        sadrzaj = d.Komentar;
                        datum = d.DatumKreiranja.ToString();
                        ocjena = d.Ocjena.ToString();
                        korisnik = d.korisnik.Username;
                    }
                }
                data.Add(new
                {
                    Rb = ++i,
                    DatumObjave = datum.Length==0?"N/A":datum,
                    Username = korisnik,
                    Ocjena = string.IsNullOrEmpty(ocjena) ? "N/A" : ocjena,
                    Komentar = string.IsNullOrEmpty(sadrzaj) ? "Nije ostavio komentar" : sadrzaj
                });
            }


            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = data;

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);

            this.reportViewer1.RefreshReport();
        }
    }
}
