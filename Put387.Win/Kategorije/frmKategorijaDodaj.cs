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

namespace Put387.Win.Kategorije
{
    public partial class frmKategorijaDodaj : Form
    {
        protected APIService _KategorijaService = new APIService("Kategorija");
        byte[] dodajSlika;
        public frmKategorijaDodaj()
        {
            InitializeComponent();
        }

        public static byte[] FromImageToByte(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Models.Kategorija novaKat = new Model.Models.Kategorija()
                {
                    Naziv = txtNaziv.Text,
                    Slika = dodajSlika
                };
                await _KategorijaService.Post<Model.Models.Kategorija>(novaKat);
                MessageBox.Show("Uspjesno dodano!");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Greska");
            }
        }

        private void pbSlika_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                pbSlika.Image = new Bitmap(open.FileName);
                var fileName = open.FileName;
                var file = File.ReadAllBytes(fileName);
                dodajSlika = file;

                Image img = Image.FromFile(fileName);
                pbSlika.Image = img;
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
