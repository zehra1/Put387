using Put387.Model.Requests.Medalja;
using Put387.WinUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Put387.Win.Medalje
{
    public partial class frmMedaljeIndex : Form
    {
        private int katId = 0;

        protected APIService _MedaljaService = new APIService("Medalja");
        protected APIService _katService = new APIService("Kategorija");
        List<Model.Models.Medalja> medalje;
        public frmMedaljeIndex()
        {
            InitializeComponent();
        }

        public frmMedaljeIndex(int id):this()
        {
            katId = id;
        }

        private async void GetData()
        {
            var nazivKat =await _katService.GetById<Model.Models.Kategorija>(katId);
            label1.Text = nazivKat.Naziv;
               MedaljaSearchRequest req = new MedaljaSearchRequest()
            {
                kategorijaId = katId
            };
           medalje = await _MedaljaService.Get<List<Model.Models.Medalja>>(req);
            
            dgvMedalje.DataSource = medalje;
            dgvMedalje.Columns[0].Visible = false;
            dgvMedalje.Columns[2].Visible = false;
        }


        private void frmMedaljeIndex_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnDodajMedalju_Click(object sender, EventArgs e)
        {
            frmMedaljaDodaj frm = new frmMedaljaDodaj(katId);
            frm.FormClosed += async delegate
            {
                GetData();
            };
            frm.ShowDialog();
        }
        private bool Validate(string value, string hint)
        {
            int i;
            if (hint != null)
            {
                if (!int.TryParse(value, out i))
                {
                    MessageBox.Show("Mora biti broj");
                    return false;
                }
                
            }
            else
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Obavezno polje");
                    return false;
                }
            }

            if (hint == "min" && (int.Parse(value) < medalje.Min(x => x.MinBrojAkcija)))
                return false;
            if (hint == "max" && (int.Parse(value) < medalje.Max(x => x.MaxBrojAkcija)))
                return false;

            if (hint != null && medalje.Max(x => x.MaxBrojAkcija) < int.Parse(value))
                return false;
            return true;

        }
        private async void dgvMedalje_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            var mxResponse = MessageBox.Show("Uredi","Da li ste sigurni?",MessageBoxButtons.YesNo);
            if (mxResponse == DialogResult.Yes)
            {
                var id = dgvMedalje.Rows[e.RowIndex].Cells[0].Value;
                var medalja = await _MedaljaService.GetById<Model.Models.Medalja>(id);

                var minBrojAkcija = dgvMedalje.Rows[e.RowIndex].Cells[4].Value.ToString();
                var maxBrojAkcija = dgvMedalje.Rows[e.RowIndex].Cells[5].Value.ToString();
                var naziv = dgvMedalje.Rows[e.RowIndex].Cells[1].Value != null ? dgvMedalje.Rows[e.RowIndex].Cells[1].Value.ToString(): null;

               
                if (Validate(minBrojAkcija,"min") && Validate(maxBrojAkcija, "max") && Validate(naziv, null))
                {
                    MedaljaInsertRequest req = new MedaljaInsertRequest()
                    {
                        Naziv = naziv,
                        Ikonica = medalja.Ikonica,
                        MinBrojAkcija = int.Parse(minBrojAkcija),
                        MaxBrojAkcija = int.Parse(maxBrojAkcija),
                        Opis = dgvMedalje.Rows[e.RowIndex].Cells[6].Value.ToString(),
                        kategorijaId = katId
                    };
                    try
                    {
                        var edit = await _MedaljaService.Put<Model.Models.Medalja>(id, req);
                        if (edit != null)
                        {
                            MessageBox.Show("Uspjesno izmjenjen zapis!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greska");
                    }
                }

            }

        }

        private void dgvMedalje_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Unijeli ste nepodrzan format");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            

            var mbx = MessageBox.Show("Da li ste sigurni da zelite izbrisati zapis?", "Upozorenje",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (mbx == DialogResult.Yes)
            {
                try
                {
                    await _katService.Delete(katId);
                    MessageBox.Show("Zapis uspjesno obrisan.");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Greska.");
                }
            }
        }
    }
}
