using Put387.Model.Requests.Korisnik;
using Put387.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Put387.WinUI.Korisnik
{
    public partial class frmKorisniciPregled : Form
    {
        protected APIService _service = new APIService("Korisnik");
        protected APIService _Gradservice = new APIService("Grad");
        protected APIService _Ulogeservices = new APIService("Uloga");
        public frmKorisniciPregled()
        {
            InitializeComponent();
        }

        private void frmKorisniciPregled_Load(object sender, EventArgs e)
        {
            LoadData(null);
        }

        public async void LoadData(List<Model.Models.Korisnik> kor)
        {
            if (dgvKorisnici.Columns.Contains("btnDetails"))
                dgvKorisnici.Columns.Remove("btnDetails");

            List<Model.Models.Korisnik> korisnici;
            if (kor != null)
                korisnici = kor;
            else
            {
                korisnici= await _service.Get<List<Model.Models.Korisnik>>();
                var gradovi = await _Gradservice.Get<List<Model.Models.Grad>>();
                gradovi.Insert(0, new Model.Models.Grad()
                {
                    Id = 0,
                    Naziv = "Izaberi grad"
                });
                cbGrad.DataSource = gradovi;
                cbGrad.DisplayMember = "Naziv";
                cbGrad.ValueMember = "Id";

                var uloge = await _Ulogeservices.Get<List<Model.Models.Uloga>>();
                uloge.Insert(0, new Model.Models.Uloga()
                {
                    Id = 0,
                    Naziv = "Izaberi ulogu"
                });
                cbUloga.DataSource = uloge;
                cbUloga.DisplayMember = "Naziv";
                cbUloga.ValueMember = "Id";
            }

            var korisnicivm = new List<KorisnikVM>();
            foreach (var item in korisnici)
            {
                KorisnikVM k = new KorisnikVM()
                {
                    Id = item.Id,
                    Email = item.Email,
                    Grad = item.grad.Naziv,
                    ImePrezime = item.Ime + ' ' + item.Prezime,
                    Status = item.Aktivan ? "Aktivan" : "Neaktivan"
                };
                korisnicivm.Add(k);
            }
            dgvKorisnici.DataSource = korisnicivm;
            dgvKorisnici.Columns[0].Visible = false;
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Akcija";
            bcol.Text = "Detalji";
            bcol.Name = "btnDetails";
            bcol.UseColumnTextForButtonValue = true;
            if (!dgvKorisnici.Columns.Contains("btnDetails"))
                dgvKorisnici.Columns.Add(bcol);


        }

        private async void Search()
        {
            KorisnikSearchRequest searchRequest = new KorisnikSearchRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtIme.Text,
                UlogaId = int.Parse(cbUloga.SelectedValue.ToString()),
                GradId = int.Parse(cbGrad.SelectedValue.ToString())
            };
            var korisnici = await _service.Get<List<Model.Models.Korisnik>>(searchRequest);
            LoadData(korisnici);

        }

        private  void btnPretraga_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dgvKorisnici_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 5)
                {
                    int result = int.Parse(dgvKorisnici.Rows[e.RowIndex].Cells[0].Value.ToString());
                    frmKorisnikDetalji frmAdd = new frmKorisnikDetalji(result);
                    frmAdd.FormClosed += async delegate
                    {
                        LoadData(null);
                    };
                    frmAdd.ShowDialog();
                }
            }
        }
    }
}
