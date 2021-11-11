using Put387.Model.Models;
using Put387.Model.Requests.Korisnik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Put387.WinUI.Login
{
    public partial class frmRegistracija : Form
    {
        protected APIService _service = new APIService("Korisnik");

        public frmRegistracija()
        {
            InitializeComponent();
        }

        private void GetRoles()
        {
            List<Uloga> roles = new List<Uloga>()
             {
                 new Uloga
                 {
                    Id=0,
                    Naziv="Select role"
                 },

                new Uloga
                 {
                    Id=2,
                    Naziv="Driver"
                 },
                 new Uloga
                 {
                    Id=3,
                    Naziv="Passenger"
                 },

             };
            cbRole.DataSource = roles;
            cbRole.DisplayMember = "Naziv";
            cbRole.ValueMember = "Id";
        }

        private bool ValidateInputs()
        {
            if ((!string.IsNullOrEmpty(txtPw.Text) && !string.IsNullOrEmpty(txtPwCon.Text)) && txtPw.Text != txtPwCon.Text)
            {
                err.SetError(txtPw, "Passwords should match!");
                err.SetError(txtPwCon, "Passwords should match!");
                return false;
            }
            else
                err.Clear();
            if (!InputHelper.Validate(txtIme))
            {
                err.SetError(txtIme, "Required!");
                return false;
            }
            else
                err.Clear();
            if (!InputHelper.Validate(txtPrezime))
            {
                err.SetError(txtPrezime, "Required!");
                return false;
            }
            else
                err.Clear();
            if (!InputHelper.Validate(txtEmail))
            {
                err.SetError(txtEmail, "Required!");
                return false;
            }
            else
                err.Clear();
            if (!InputHelper.Validate(txtUsername))
            {
                err.SetError(txtUsername, "Required!");
                return false;
            }
            else
                err.Clear();
            if (!InputHelper.Validate(txtPw))
            {
                err.SetError(txtPw, "Required!");
                return false;
            }
            else
                err.Clear();
            if (!InputHelper.Validate(txtPwCon))
            {
                err.SetError(txtPwCon, "Required!");
                return false;
            }
            else
                err.Clear();
            if (!InputHelper.Validate(cbRole))
            {
                err.SetError(cbRole, "Required!");
                return false;
            }
            else
                err.Clear();
            return true;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if(!ValidateInputs())
                return;
            KorisnikUpsertRequest newUser = new KorisnikUpsertRequest()
            {
                Aktivan = true,
                Ime = txtIme.Text,
                Email = txtEmail.Text,
                Password = txtPw.Text,
                PasswordConfirmation = txtPwCon.Text,
                Prezime = txtPrezime.Text,
                Telefon = txtPhone.Text,
                ulogaId = (cbRole.SelectedItem as Uloga).Id,
                gradId=1,
                Username=txtUsername.Text
            };
            try
            {
                await _service.Post<Model.Models.Korisnik>(newUser);
                MessageBox.Show("USpjesno dodan");
            }
            catch (Exception)
            {
                MessageBox.Show("Greska");
            }
            Close();
        }

        private void frmRegistracija_Load(object sender, EventArgs e)
        {
            GetRoles();
        }
    }
}
