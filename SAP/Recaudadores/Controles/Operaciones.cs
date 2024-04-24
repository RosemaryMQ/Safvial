using SAP.Properties;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Recaudadores.Controles
{
    public partial class Operaciones : Form
    {
        String fecha = DateTime.Now.ToShortDateString();
        String fechas;
        public Operaciones()
        {
            InitializeComponent();
            fechas = Convert.ToString(this.LastDayOfMonthFromDateTime(DateTime.Now));
            date1.Value.ToShortDateString();
            date2.Value.ToShortDateString();
        }
        public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
        private async void Operaciones_Load(object sender, EventArgs e)
        {
            try
            {
                await this.Sedes();
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", date1.Value.ToShortDateString());
                this.reportViewer1.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Sede", SAP.Inicio.PeajeNombre.ToUpper());
                this.reportViewer1.LocalReport.SetParameters(frm1);
                // TODO: esta línea de código carga datos en la tabla 'prepagadoDataSet.operacionesVentas' Puede moverla o quitarla según sea necesario.
                this.operacionesV2TableAdapter.Fill(this.prepagadoDataSet.OperacionesV2, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.reportViewer1.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error al cargar el reporte", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sede.SelectedIndex != -1)
                {
                    int val = Sede.SelectedIndex + 1;
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", date1.Value.ToShortDateString());
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Sede", Sede.Text.ToUpper());
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    // TODO: esta línea de código carga datos en la tabla 'prepagadoDataSet.operacionesVentas' Puede moverla o quitarla según sea necesario.
                    this.operacionesV2TableAdapter.Fill(this.prepagadoDataSet.OperacionesV2, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Por favor seleccione la sede a consultar", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Error al cargar el reporte", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private async Task Sedes()
        {
            string sql = "SELECT Nombre FROM Sede ORDER BY ID_Sede ASC;";
            using (SqlConnection cn = new SqlConnection((string)Settings.Default["Prepagado"]))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    if (dr["Nombre"].ToString() != "")
                    {
                        Sede.Items.Add(dr["Nombre"].ToString().ToUpper());
                    }
                }
                cn.Close();
                return;
            }
        }
    }
}
