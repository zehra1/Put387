using Put387.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Put387.WinUI.Korisnik
{
    public partial class frmKorisnikDetalji : Form
    {
        protected APIService _service = new APIService("Korisnik");
        protected APIService _Gradservice = new APIService("Grad");
        protected APIService _Voznjeservice = new APIService("Voznja");

        private int korisnikId;
        private int activeTab;
        private Model.Models.Korisnik korisnik;
        public frmKorisnikDetalji()
        {
            InitializeComponent();
        }
        public frmKorisnikDetalji(int kor,int tabIndex=0) : this()
        {
            korisnikId = kor;
            activeTab = tabIndex;
        }
        private async void GetGradovi()
        {
            var gradovi = await _Gradservice.Get<List<Model.Models.Grad>>();
            cbGrad.DataSource = gradovi;
            cbGrad.DisplayMember = "Naziv";
            cbGrad.ValueMember = "Id";
            cbGrad.SelectedValue = korisnik.gradId;
        }
        private async void frmKorisnikDetalji_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = activeTab;
            korisnik = await _service.GetById<Model.Models.Korisnik>(korisnikId);
            if (korisnik.Slika != null)
                editKorisnik.Slika = korisnik.Slika;
            txtIme.Text = korisnik.Ime;
            txtPrezime.Text = korisnik.Prezime;
            txtEmail.Text = korisnik.Email;
            chbAktivan.Checked = korisnik.Aktivan;
            lblIme.Text = korisnik.Ime+' '+korisnik.Prezime;
            if (korisnik.Slika.Length > 0)
                pbSlika.Image = GetImage(korisnik.Slika);
         
            GetGradovi();
            ChartData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validate(Control obj)
        {
            if (obj is ComboBox && int.Parse((obj as ComboBox).SelectedValue.ToString()) == 0)
            {
                err.SetError(obj, "This field is required!");
                obj.Focus();
                return false;
            }
            else if (obj is TextBox && string.IsNullOrWhiteSpace((obj as TextBox).Text))
            {
                err.SetError(obj, "This field is required!");
                return false;
            }
            err.Clear();
            return true;
        }

        Model.Requests.Korisnik.KorisnikUpsertRequest editKorisnik = new Model.Requests.Korisnik.KorisnikUpsertRequest();
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate(txtEmail) && Validate(txtIme) && Validate(txtPrezime))
                {
                    editKorisnik.Aktivan = chbAktivan.Checked;
                    editKorisnik.Email = txtEmail.Text;
                    editKorisnik.gradId = int.Parse(cbGrad.SelectedValue.ToString());
                    editKorisnik.Ime = txtIme.Text;
                    editKorisnik.Prezime = txtPrezime.Text;
                    editKorisnik.ulogaId = korisnik.ulogaId;
                    editKorisnik.Telefon = korisnik.Telefon;
                    editKorisnik.Username = korisnik.Username;
                }
                else
                {
                    MessageBox.Show("Provjeri unos!");
                    return;
                }
                await _service.Put<Model.Models.Korisnik>(korisnikId, editKorisnik);
                var msg = MessageBox.Show("Uspjesno izmjenjeni podaci!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (msg == DialogResult.OK)
                    this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void pbSlika_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog open = new OpenFileDialog();

        //    if (open.ShowDialog() == DialogResult.OK)
        //    {
        //        pbSlika.Image = new Bitmap(open.FileName);
        //        var fileName = open.FileName;
        //        var file = File.ReadAllBytes(fileName);
        //        editKorisnik.Slika = file;

        //        Image img = Image.FromFile(fileName);
        //        pbSlika.Image = img;
        //        //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //    }
        //}

        private static Image GetImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return (Image.FromStream(ms));
            }
        }

        private async void ChartData()
        {
            chartStat.Legends[0].Docking = Docking.Bottom;
            chartStat.Legends[0].Alignment = StringAlignment.Center;
            var voznje = await _Voznjeservice.Get<List<Model.Models.Voznja>>();
            List<StatistikaVM> kor = new List<StatistikaVM>();
            var trenutniMjesec = DateTime.Now.Date.Month;
            for (int i = 0; i < 5; i++)
            {
                StatistikaVM item = new StatistikaVM()
                {
                    Mjesec = trenutniMjesec - i,
                    BrojVoznji = voznje.Where(x => x.DatumObjave.Month == trenutniMjesec - i && x.vozacId== korisnikId).Count(),
                    Zarada = voznje.Where(x => x.DatumObjave.Month == trenutniMjesec - i && x.vozacId== korisnikId).Sum(x=>x.Cijena)
                };
                kor.Add(item);
            }
            chartStat.DataSource = kor;
            chartStat.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            chartStat.Series["Broj voznji"].XValueMember = "Mjesec";
            chartStat.Series["Broj voznji"].XValueType = ChartValueType.Int32;
            chartStat.Series["Broj voznji"].YValueMembers = "BrojVoznji";
            chartStat.Series["Broj voznji"].YValueType = ChartValueType.Int32;
            if (korisnik.ulogaId == 2)
            {
                chartStat.Series.Add("Zarada");
                chartStat.Series[1].ChartType = SeriesChartType.Spline;
                chartStat.Series["Zarada"].XValueMember = "Mjesec";
                chartStat.Series["Zarada"].XValueType = ChartValueType.Int32;
                chartStat.Series["Zarada"].YValueMembers = "Zarada";
                chartStat.Series["Zarada"].YValueType = ChartValueType.Int32;
            }
        }

        private void pbSlika_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                pbSlika.Image = new Bitmap(open.FileName);
                var fileName = open.FileName;
                var file = File.ReadAllBytes(fileName);
                editKorisnik.Slika = file;

                Image img = Image.FromFile(fileName);
                pbSlika.Image = img;
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
