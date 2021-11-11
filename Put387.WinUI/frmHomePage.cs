using Put387.WinUI.Korisnik;
using Put387.WinUI.Voznja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Put387.WinUI
{
    public partial class frmHomePage : Form
    {
        Form forma;
        string nazivForme;
        public frmHomePage()
        {
            InitializeComponent();
        }

        public frmHomePage(Form frm,string naziv):this()
        {
            forma = frm;
            nazivForme = naziv;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmKorisniciPregled userList = new frmKorisniciPregled();
            userList.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(userList);
            userList.Show();
        }

        private void btnRides_Click(object sender, EventArgs e)
        {
            frmVoznjeHome frmVoznje = new frmVoznjeHome(this);
            frmVoznje.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frmVoznje);
            frmVoznje.Show();
        }

        private void frmHomePage_Load(object sender, EventArgs e)
        {
            if (forma != null)
            {
                if (nazivForme == "historija")
                {
                    frmVoznjePregled frmVoznje = new frmVoznjePregled();
                    frmVoznje.TopLevel = false;
                    pnlContent.Controls.Clear();
                    pnlContent.Controls.Add(frmVoznje);
                    frmVoznje.Show();
                }
                else
                {
                    frmNadolazeceVoznje frmVoznje = new frmNadolazeceVoznje();
                    frmVoznje.TopLevel = false;
                    pnlContent.Controls.Clear();
                    pnlContent.Controls.Add(frmVoznje);
                    frmVoznje.Show();
                }

            }
        }
    }
}
