using Put387.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Put387.WinUI.Voznja
{
    public partial class frmNadolazeceVoznje : Form
    {
        protected APIService _TipVoznjeservice = new APIService("TipVoznje");
        protected APIService _Voznjeservice = new APIService("Voznja");

        public frmNadolazeceVoznje()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Search();
        }

        private async void Search()
        {
            Model.Requests.Voznja.VoznjaSearchRequest req = new Model.Requests.Voznja.VoznjaSearchRequest()
            {
                BrojSlobodnihMjesta = trackBar1.Value,
                Cijena = checkBox1.Checked,
                NazivPolazista = txtPlace.Text,
                tipVoznjeId=int.Parse(cbTipVoznje.SelectedValue.ToString())  ,
                searchBy="nadolazece"
            };
            List<Model.Models.Voznja> podaci =await _Voznjeservice.Get<List<Model.Models.Voznja>>(req);
            GetData(podaci);
        }
        private async void frmNadolazeceVoznje_Load(object sender, EventArgs e)
        {
            var podaci = await _TipVoznjeservice.Get<List<Model.Models.TipVoznje>>();

            GetData(null);
            cbTipVoznje.DisplayMember = "Naziv";
            cbTipVoznje.ValueMember = "Id";
            podaci.Insert(0, new Model.Models.TipVoznje()
            {
                Id = 0,
                Naziv = "Odaberi tip"
            });
            cbTipVoznje.DataSource = podaci;
        }
        private async void GetData(List<Model.Models.Voznja> listaPodataka)
        {
            List<Model.Models.Voznja> voznje;
            if (listaPodataka != null)
            {
                voznje = listaPodataka;
            }
            else
            {
                voznje = await _Voznjeservice.Get<List<Model.Models.Voznja>>(new Model.Requests.Voznja.VoznjaSearchRequest() {searchBy="nadolazece"});
            }
            List<NadolazeceVoznjeVM> voznjeVM = new List<NadolazeceVoznjeVM>();
            foreach (var voznja in voznje)
            {
                NadolazeceVoznjeVM item = new NadolazeceVoznjeVM()
                {
                    DatumPolaska = voznja.DatumVrijemePolaska.Date,
                    Cijena = voznja.Cijena>0?voznja.Cijena.ToString():"Free",
                    Odrediste = voznja.odrediste.Naziv,
                    Polaziste = voznja.polaziste.Naziv,
                    BrojMjesta=voznja.BrojSlobodnihMjesta,
                    TipVoznje=voznja.tipVoznje.Naziv
                };
                voznjeVM.Add(item);
            }
            dgvVoznja.DataSource = voznjeVM;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtPlace_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void cbTipVoznje_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
