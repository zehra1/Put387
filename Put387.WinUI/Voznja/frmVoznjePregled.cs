using Put387.Model.Requests.Voznja;
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
    public partial class frmVoznjePregled : Form
    {
        protected APIService _service = new APIService("Voznja");

        public frmVoznjePregled()
        {
            InitializeComponent();
        }

        private async void GetData(List<Model.Models.Voznja> listaPodataka=null)
        {
            if (dgvVoznjeLista.Columns.Contains("btnDetails"))
                dgvVoznjeLista.Columns.Remove("btnDetails");

            List<Model.Models.Voznja> voznje;
            if (listaPodataka != null)
            {
                voznje = listaPodataka;
            }else
            {
                voznje = await _service.Get<List<Model.Models.Voznja>>();
            }
            List<VoznjaVM> voznjeVM = new List<VoznjaVM>();
            foreach (var voznja in voznje)
            {
                VoznjaVM item = new VoznjaVM()
                {
                    datumPolaska = voznja.DatumVrijemePolaska.Date,
                    ocjena = voznja.Ocjena,
                    odrediste = voznja.odrediste.Naziv,
                    polaziste = voznja.polaziste.Naziv,
                    voznjaId = voznja.Id
                };
                voznjeVM.Add(item);
            }
            dgvVoznjeLista.DataSource = voznjeVM;
            dgvVoznjeLista.Columns[0].Visible = false;
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Akcija";
            bcol.Text = "Detalji";
            bcol.Name = "btnDetails";
            bcol.UseColumnTextForButtonValue = true;
            if (!dgvVoznjeLista.Columns.Contains("btnDetails"))
                dgvVoznjeLista.Columns.Add(bcol);
        }
        private void frmVoznjePregled_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            var datumOd = dtpOd.Value;
            var datumDo = dtpDo.Value;

            if (datumOd > datumDo)
            {
                err.SetError(dtpDo, "Provjeri datume!");
                return;
            }
            else
                err.Clear();

            VoznjaSearchRequest req = new VoznjaSearchRequest()
            {
                OdDatuma = datumOd,
                DoDatuma = datumDo
            };
            var data =await _service.Get<List<Model.Models.Voznja>>(req);
            GetData(data);
        }

        private void dgvVoznjeLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 5)
                {
                    int result = int.Parse(dgvVoznjeLista.Rows[e.RowIndex].Cells[0].Value.ToString());
                    frmVoznjaDetalji frmAdd = new frmVoznjaDetalji(result);
                    frmAdd.ShowDialog();
                }
            }
        }
    }
}
