using SAP.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Recaudadores.Controles.Reportes
{
    public partial class ReporteTarjetaExpress : Form
    {
        string nombresede = "";
        public ReporteTarjetaExpress()
        {
            InitializeComponent();
        }

        private async void ReporteTarjetaExpress_Load(object sender, EventArgs e)
        {
            await this.Sedes(SAP.Recaudadores.Controles.Reporte.sede);
            Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Sede", nombresede.ToUpper());
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString());
                this.reportViewer1.LocalReport.SetParameters(frm3);
                this.tarjetaExpressReporteTableAdapter.Fill(this.tarjetaExpressDataSet.TarjetaExpressReporte, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Recaudadores.Controles.Reporte.sede);
                this.reportViewer1.RefreshReport();

        }

        private void button5_Click(object sender, EventArgs e)
        {
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Sede", nombresede.ToUpper());
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString());
                this.reportViewer1.LocalReport.SetParameters(frm3);
                this.tarjetaExpressReporteTableAdapter.Fill(this.tarjetaExpressDataSet.TarjetaExpressReporte, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Recaudadores.Controles.Reporte.sede);
                this.reportViewer1.RefreshReport();
        }
        private async Task Sedes(int sede)
        {
            string sql = "SELECT Nombre FROM Sede Where ID_Sede = @sede;";
            using (SqlConnection cn = new SqlConnection((string)Settings.Default["Prepagado"]))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("sede", sede);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    if (dr["Nombre"].ToString() != "")
                    {
                        nombresede = dr["Nombre"].ToString();
                    }
                }
                cn.Close();
                return;
            }
        }
    }
}
