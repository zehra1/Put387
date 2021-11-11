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
    public partial class frmLogin : Form
    {
        protected APIService _service = new APIService("Korisnik/Login");
        public frmLogin()
        {
            InitializeComponent();
        }



        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!InputHelper.Validate(txtUsername))
            {
                err.SetError(txtUsername, "This field is required!");
                txtUsername.Focus();
            }
            else
                err.Clear();

            if (!InputHelper.Validate(txtPw))
            {
                err.SetError(txtPw, "This field is required!");
                txtPw.Focus();
            }
            else
            {
                err.Clear();
                try
                {
                    var req = new KorisnikLoginRequest()
                    {
                        Username = txtUsername.Text,
                        Password = txtPw.Text
                    };
                    var user = await _service.Post<Model.Models.Korisnik>(req);
                    //MessageBox.Show("Uspjesno");
                    APIService.username = txtUsername.Text;
                    APIService.password= txtPw.Text;
                    this.Hide();
                    frmHomePage frm = new frmHomePage();
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();

                }
                catch (Exception)
                {
                    MessageBox.Show("Ne valja pw ili user");
                }
            }
        }

        private void lblRegistracija_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistracija frm = new frmRegistracija();
            frm.ShowDialog();
        }
    }
}
