using Put387.Model.Models;
using Put387.Models.ViewModels;
using Put387.WinUI;
using Put387.WinUI.Korisnik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Put387.Win.Pocetna
{
    public partial class frmHomeScreen : Form
    {
        protected APIService _KorisnikService = new APIService("Korisnik");
        protected APIService _Voznjeservice = new APIService("Voznja");

        public frmHomeScreen()
        {
            InitializeComponent();
            
        }

        public async void ChartData()
        {
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            var korisnici = await _KorisnikService.Get<List<Model.Models.Korisnik>>();
            var voznje = await _Voznjeservice.Get<List<Model.Models.Voznja>>();

            List<StatistikaVM> kor = new List<StatistikaVM>();
            var trenutniMjesec = DateTime.Now.Date.Month;
            chart1.Series.Add("Broj vozaca");
            chart1.Series.Add("Broj voznji");
            for (int i = 0; i < 5; i++)
            {
                StatistikaVM item = new StatistikaVM()
                {
                    Mjesec = trenutniMjesec - i,
                    BrojKorisnika = korisnici.Where(x => x.DatumRegistracije.Month == trenutniMjesec - i).Count(),
                    BrojVozaca = korisnici.Where(x => x.DatumRegistracije.Month == trenutniMjesec - i && x.ulogaId == 2).Count(),
                    BrojVoznji = voznje.Where(x => x.DatumObjave.Month == trenutniMjesec - i).Count()
                };
                kor.Add(item);
            }
            chart1.DataSource = kor;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            chart1.Series["Broj korisnika"].XValueMember = "Mjesec";
            chart1.Series["Broj korisnika"].XValueType = ChartValueType.Int32;
            chart1.Series["Broj korisnika"].YValueMembers = "BrojKorisnika";
            chart1.Series["Broj korisnika"].YValueType = ChartValueType.Int32;

            chart1.Series["Broj voznji"].XValueMember = "Mjesec";
            chart1.Series["Broj voznji"].XValueType = ChartValueType.Int32;
            chart1.Series["Broj voznji"].YValueMembers = "BrojVoznji";
            chart1.Series["Broj voznji"].YValueType = ChartValueType.Int32;

            chart1.Series["Broj vozaca"].XValueMember = "Mjesec";
            chart1.Series["Broj vozaca"].XValueType = ChartValueType.Int32;
            chart1.Series["Broj vozaca"].YValueMembers = "BrojVozaca";
            chart1.Series["Broj vozaca"].YValueType = ChartValueType.Int32;

            chart1.ChartAreas[0].AxisY.Title = "Broj";
            chart1.ChartAreas[0].AxisX.Title = "Mjesec";

            chart1.Series[0].ChartType = SeriesChartType.Spline;
            chart1.Series[1].ChartType = SeriesChartType.Spline;
            chart1.Series[2].ChartType = SeriesChartType.Spline;

        }

        public async void DgvData()
        {
            if (dgvTopTri.Columns.Contains("btnDetails"))
                dgvTopTri.Columns.Remove("btnDetails");
            var data = await _Voznjeservice.Get<List<Voznja>>();
            List<StatistikaVozacaVM> statVozaca = new List<StatistikaVozacaVM>();
            var trenutniDatum = DateTime.Now.Date.Month;
            foreach (var item in data)
            {
                StatistikaVozacaVM k = new StatistikaVozacaVM()
                {
                    Id=item.vozacId,
                    BrojVoznji = data.Where(x => x.vozacId == item.vozacId && trenutniDatum - 1 == x.DatumObjave.Date.Month).Count(),
                    ImePrezime = item.vozac.Ime + " " + item.vozac.Prezime,
                    ProsjecnaOcjena = item.Ocjena
                };
                statVozaca.Add(k);
            }
            statVozaca = statVozaca.OrderByDescending(x => x.BrojVoznji).ToList();
            dgvTopTri.DataSource = statVozaca;
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Akcija";
            bcol.Text = "Detalji";
            bcol.Name = "btnDetails";
            bcol.UseColumnTextForButtonValue = true;
            if (!dgvTopTri.Columns.Contains("btnDetails"))
                dgvTopTri.Columns.Add(bcol);
        }

        private  void frmHomeScreen_Load(object sender, EventArgs e)
        {
            ChartData();
            DgvData();
        }

        private void dgvTopTri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    int result = int.Parse(dgvTopTri.Rows[e.RowIndex].Cells[0].Value.ToString());
                    frmKorisnikDetalji frmAdd = new frmKorisnikDetalji(result,1);
                    frmAdd.ShowDialog();
                }
            }
        }
    }
}
