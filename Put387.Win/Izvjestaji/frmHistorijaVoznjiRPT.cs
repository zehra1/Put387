using Microsoft.Reporting.WinForms;
using Put387.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Put387.Win.Izvjestaji
{
    public partial class frmHistorijaVoznjiRPT : Form
    {
        private List<VoznjaVM> _data;

        public frmHistorijaVoznjiRPT()
        {
            InitializeComponent();
        }

        public frmHistorijaVoznjiRPT(List<VoznjaVM> data) : this()
        {
            _data = data;
        }

        private void frmHistorijaVoznjiRPT_Load(object sender, EventArgs e)
        {

            int i = 0;
            List<object> listaPodataka = new List<object>();
            foreach (var item in _data)
            {
                listaPodataka.Add(new
                {
                    Rb=++i,
                    Odrediste=item.odrediste.ToString(),
                    Polaziste=item.polaziste,
                    Datum=item.datumPolaska,
                    Ocjena=item.ocjena
                });
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet";
            rds.Value = listaPodataka;

            rptViewer.LocalReport.DataSources.Add(rds);
            this.rptViewer.RefreshReport();
        }
    }
}
