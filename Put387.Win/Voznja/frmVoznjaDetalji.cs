using Put387.Model.ViewModels;
using Put387.Models.ViewModels;
using Put387.Win.Izvjestaji;
using Put387.WinUI.Korisnik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Put387.WinUI.Voznja
{
    public partial class frmVoznjaDetalji : Form
    {
        private int voznjaId = 0;
        private int vozacId = 0;
        private List<Model.Models.VoznjaDojam> dojmovi;
        private Model.Models.Voznja voznja;
        protected APIService _voznjaService = new APIService("Voznja");
        protected APIService _dojmoviService = new APIService("VoznjaDojam");
        protected APIService _korisniciService = new APIService("VoznjaKorisnici");

        public frmVoznjaDetalji()
        {
            InitializeComponent();
        }
        public frmVoznjaDetalji(int id):this()
        {
            voznjaId = id;
        }

        private async void frmVoznjaDetalji_Load(object sender, EventArgs e)
        {
            voznja = await _voznjaService.GetById<Model.Models.Voznja>(voznjaId);
            Model.Requests.VoznjaDojam.VoznjaDojamSearchRequest dojamReq = new Model.Requests.VoznjaDojam.VoznjaDojamSearchRequest()
            {
                voznjaId = voznjaId
            };
            dojmovi = await _dojmoviService.Get<List<Model.Models.VoznjaDojam>>(dojamReq);
            Model.Requests.VoznjaKorisnici.VoznjaKorisniciSearchRequest korisniciReq = new Model.Requests.VoznjaKorisnici.VoznjaKorisniciSearchRequest()
            {
                voznjaId = voznjaId
            };
            var korisnici = await _korisniciService.Get<List<Model.Models.VoznjaKorisnici>>(korisniciReq);
            foreach (var item in korisnici)
            {
                lbKorisnici.Items.Add(item.korisnik.Ime + " " + item.korisnik.Prezime + " " + item.korisnik.Telefon);
            }
            vozacId = voznja.vozacId;
            txtImeVoz.Text = voznja.vozac.Ime + " " + voznja.vozac.Prezime;
            txtPolaziste.Text = voznja.polaziste.Naziv;
            txtOdrediste.Text = voznja.odrediste.Naziv;
            lblTipVoznje.Text += " " + voznja.tipVoznje.Naziv;
            lblOcjena.Text = voznja.Ocjena.ToString();

            List<voznjaDojmoviVM> vdVm = new List<voznjaDojmoviVM>();
            foreach (var item in dojmovi)
            {
                voznjaDojmoviVM o = new voznjaDojmoviVM()
                {
                    datumObjave = item.DatumKreiranja.Date,
                    komentar = item.Komentar,
                    korisnik = item.korisnik.Username,
                    ocjena = item.Ocjena
                };
                vdVm.Add(o);
            }
            dgvDojmovi.DataSource = vdVm;
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            frmKorisnikDetalji frmDetalji = new frmKorisnikDetalji(vozacId);
            frmDetalji.ShowDialog();
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            VoznjaReportVM reportData = new VoznjaReportVM()
            {
                Dojmovi = dojmovi,
                ProsjecnaOcjena = voznja.Ocjena,
                Vozac = voznja
            };
            frmVoznjaDetaljiRPT frm = new frmVoznjaDetaljiRPT(reportData);
            frm.ShowDialog();
        }
    }
}
