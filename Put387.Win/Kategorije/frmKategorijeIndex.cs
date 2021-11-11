using Put387.Models.ViewModels;
using Put387.Win.Medalje;
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

namespace Put387.Win.Kategorije
{
    public partial class frmKategorijeIndex : Form
    {
        protected APIService _KategorijaService = new APIService("Kategorija");
        protected APIService _MedaljaService = new APIService("Medalja");

        public frmKategorijeIndex()
        {
            InitializeComponent();
        }
        private async void GetData()
        {
            var kategorije = await _KategorijaService.Get<List<Model.Models.Kategorija>>();
            var medalje = await _MedaljaService.Get<List<Model.Models.Medalja>>();
            if (dgvKategorije.Columns.Contains("btnDetails"))
                dgvKategorije.Columns.Remove("btnDetails");
            List<MedaljeKategorijeVM> newKat = new List<MedaljeKategorijeVM>();
            foreach (var kategorija in kategorije)
            {
                int min=0, max=0;
                if (medalje.Where(x => x.kategorijaId == kategorija.Id).Count() > 0)
                {
                    min = medalje.Where(x => x.kategorijaId == kategorija.Id).Min(x => x.MinBrojAkcija);
                    max = medalje.Where(x => x.kategorijaId == kategorija.Id).Max(x => x.MaxBrojAkcija);
                }

                MedaljeKategorijeVM item = new MedaljeKategorijeVM()
                {
                    nazivKategorije = kategorija.Naziv,
                    Id = kategorija.Id,
                    Slika = kategorija.Slika,
                    brojAkcija = medalje.Where(x => x.kategorijaId == kategorija.Id).Count() > 0 ? min.ToString() + " - " + max.ToString() : "Nema medalja!"
                };
                newKat.Add(item);
            }
            dgvKategorije.DataSource = newKat; 
            dgvKategorije.Columns[0].Visible = false;
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Akcija";
            bcol.Text = "Detalji";
            bcol.Name = "btnDetails";
            bcol.UseColumnTextForButtonValue = true;
            if (!dgvKategorije.Columns.Contains("btnDetails"))
                dgvKategorije.Columns.Add(bcol);
        }
        private void frmKategorijeIndex_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void dgvKategorije_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 4)
                {
                    int result = int.Parse(dgvKategorije.Rows[e.RowIndex].Cells[0].Value.ToString());
                    frmMedaljeIndex frmAdd = new frmMedaljeIndex(result);
                    frmAdd.FormClosed += async delegate
                    {
                        GetData();
                    };
                    frmAdd.ShowDialog();
                }
            }
        }

        private void btnDodajKategoriju_Click(object sender, EventArgs e)
        {
            frmKategorijaDodaj frm = new frmKategorijaDodaj();
            frm.ShowDialog();
        }

        private void dgvKategorije_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
