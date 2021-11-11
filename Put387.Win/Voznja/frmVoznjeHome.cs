using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Put387.WinUI.Voznja
{
    public partial class frmVoznjeHome : Form
    {
        Form forma;
        public frmVoznjeHome()
        {
            InitializeComponent();
        }
        public frmVoznjeHome(Form frm):this()
        {
            forma = frm;
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            frmHomePage frm = new frmHomePage(this,"historija");
            forma.Hide();
            frm.Closed += (s, args) => forma.Close();
            frm.ShowDialog();
        }

        private void btnNadolazece_Click(object sender, EventArgs e)
        {
            frmHomePage frm = new frmHomePage(this, "nadolazece");
            forma.Hide();
            frm.Closed += (s, args) => forma.Close();
            frm.ShowDialog();
        }
    }
}
