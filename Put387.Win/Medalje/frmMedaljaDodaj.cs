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
    public partial class frmMedaljaDodaj : Form
    {
        protected APIService _MedaljaService = new APIService("Medalja");
        protected APIService _KategorijaService = new APIService("Kategorija");
        int katId = 0;
        Model.Models.Kategorija kategorija = new Model.Models.Kategorija();
        List<Model.Models.Medalja> medalje = new List<Model.Models.Medalja>();
        Model.Requests.Medalja.MedaljaInsertRequest dodaj = new Model.Requests.Medalja.MedaljaInsertRequest();

        public frmMedaljaDodaj()
        {
            InitializeComponent();
        }

        public frmMedaljaDodaj(int id):this()
        {
            katId = id;
        }

        private void GetData()
        {

        }

        private async void frmMedaljaDodaj_Load(object sender, EventArgs e)
        {
            kategorija =await _KategorijaService.GetById<Model.Models.Kategorija>(katId);
            medalje = await _MedaljaService.Get<List<Model.Models.Medalja>>();
        }
        private bool Validate(string value,string hint)
        {
            int i;
            if (hint != null)
            {
                if (!int.TryParse(txtMinBr.Text, out i))
                {
                    err.SetError(txtMinBr, "Mora biti broj");
                    return false;
                }
                else
                    err.Clear();

                if (!int.TryParse(txtMaxBr.Text, out i))
                {
                    err.SetError(txtMaxBr, "Mora biti broj");
                    return false;
                }
                else
                    err.Clear();
            }
            else
            {
                if (string.IsNullOrEmpty(txtNaziv.Text))
                {
                    err.SetError(txtNaziv, "Obavezno polje");
                    return false;
                }
            }
            if (medalje.Count > 0)
            {
            if (hint == "min" && (int.Parse(value) < medalje.Min(x => x.MinBrojAkcija)))
                return false;
            if (hint == "max" && (int.Parse(value) < medalje.Max(x => x.MaxBrojAkcija)))
                return false;

            if (hint != null && medalje.Max(x => x.MaxBrojAkcija) >= int.Parse(value))
                return false;
            }
            return true;

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            
            if (Validate(txtMinBr.Text,"min") && Validate(txtMaxBr.Text, "max") && Validate(txtNaziv.Text,null))
            {
                if (int.Parse(txtMinBr.Text) >= int.Parse(txtMaxBr.Text))
                {
                    err.SetError(txtMinBr, "Minimalan broj mora biti manji od makismalnog");
                    err.SetError(txtMaxBr, "Max mora biti veci od minimalnog");
                    return;

                }
                else
                    err.Clear();


                dodaj.MaxBrojAkcija = int.Parse(txtMaxBr.Text);
                dodaj.MinBrojAkcija = int.Parse(txtMinBr.Text);
                dodaj.kategorijaId = katId;
                dodaj.Naziv = txtNaziv.Text;
                dodaj.Opis = txtBox.Text;
                if (dodaj.Ikonica == null)
                {
                    dodaj.Ikonica = FromImageToByte(pbIcon.Image);
                }
               await _MedaljaService.Post<Model.Models.Medalja>(dodaj);
                MessageBox.Show("Uspjesno!");
                Close();
            }
            else
            {
                MessageBox.Show("Provjeri input");
            }
        }

        private void pbIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                pbIcon.Image = new Bitmap(open.FileName);
                var fileName = open.FileName;
                var file = File.ReadAllBytes(fileName);
                dodaj.Ikonica = file;

                Image img = Image.FromFile(fileName);
                pbIcon.Image = img;
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        public static byte[] FromImageToByte(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
