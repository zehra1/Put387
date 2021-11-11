using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Put387.WinUI.Korisnik
{
    public partial class frmKorisnikDetalji : Form
    {
        protected APIService _service = new APIService("Korisnik");
        protected APIService _Gradservice = new APIService("Grad");

        private int korisnikId;
        private Model.Models.Korisnik korisnik;
        public frmKorisnikDetalji()
        {
            InitializeComponent();
        }
        public frmKorisnikDetalji(int kor) : this()
        {
            korisnikId = kor;
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
            korisnik = await _service.GetById<Model.Models.Korisnik>(korisnikId);
            txtIme.Text = korisnik.Ime;
            txtPrezime.Text = korisnik.Prezime;
            txtEmail.Text = korisnik.Email;
            chbAktivan.Checked = korisnik.Aktivan;
            lblIme.Text = korisnik.Ime+' '+korisnik.Prezime;
            if (korisnik.Slika.Length > 0)
                pbSlika.Image = GetImage(korisnik.Slika);
         
            GetGradovi();
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
                if (Validate(txtEmail) || Validate(txtIme) || Validate(txtPrezime))
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
                throw;
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
                editKorisnik.Slika = file;

                Image img = Image.FromFile(fileName);
                pbSlika.Image = img;
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private static Image GetImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return (Image.FromStream(ms));
            }
        }
    }
}
