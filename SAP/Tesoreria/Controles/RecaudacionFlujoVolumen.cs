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

namespace SAP.Tesoreria.Controles
{
    public partial class RecaudacionFlujoVolumen : Form
    {
        String fecha = DateTime.Now.ToShortDateString();
        String fechas;
        string NombreSede = "";
        public RecaudacionFlujoVolumen()
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
        private async void button5_Click(object sender, EventArgs e)
        {
            if (hora1.Text != "" && min1.Text != "" && hora2.Text != "" && min2.Text != "")
            {
                try
                {
                    NombreSede = await Sede(SAP.Recaudadores.Controles.Reporte.sede);
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", date2.Value.ToShortDateString());
                    Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Peaje", NombreSede.ToUpper());
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    this.reportViewer1.LocalReport.SetParameters(frm2);
                    this.tipoVehiculosTarifasTableAdapter.Fill(this.sAPDataSet2.TipoVehiculosTarifas, Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    this.flujoVehicularV10TableAdapter.Fill(this.sAPDataSet2.FlujoVehicularV10, Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    this.flujoVehicularV10TableAdapter1.Fill(this.prepagadoDataSet.FlujoVehicularV10, Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"), SAP.Recaudadores.Controles.Reporte.sede);
                    this.flujoVehicularV10ExoneradoTableAdapter.Fill(this.sAPDataSet2.FlujoVehicularV10Exonerado, Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    this.reportViewer1.RefreshReport();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar el reporte", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Para poder realizar la consulta debe llenar todos los campos correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void RecaudacionTiposSC_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sAPDataSet2.TipoVehiculosTarifas' Puede moverla o quitarla según sea necesario.
            hora1.SelectedIndex = 0;
            min1.SelectedIndex = 0;
            hora2.SelectedIndex = 23;
            min2.SelectedIndex = 59;
            if (hora1.Text != "" && min1.Text != "" && hora2.Text != "" && min2.Text != "")
            {
                try
                {
                    NombreSede = await Sede(SAP.Recaudadores.Controles.Reporte.sede);
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", date2.Value.ToShortDateString());
                    Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Peaje", NombreSede.ToUpper());
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    this.reportViewer1.LocalReport.SetParameters(frm2);
                    this.tipoVehiculosTarifasTableAdapter.Fill(this.sAPDataSet2.TipoVehiculosTarifas, Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    this.flujoVehicularV10ExoneradoTableAdapter.Fill(this.sAPDataSet2.FlujoVehicularV10Exonerado, Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    this.flujoVehicularV10TableAdapter.Fill(this.sAPDataSet2.FlujoVehicularV10, Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    this.flujoVehicularV10TableAdapter1.Fill(this.prepagadoDataSet.FlujoVehicularV10, Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"), SAP.Recaudadores.Controles.Reporte.sede);
                    this.reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el reporte" + ex, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Para poder realizar la consulta debe llenar todos los campos correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.reportViewer1.RefreshReport();
        }
        private async Task<string> Sede(int id)
        {
            string sql = "SELECT TOP 1 Nombre FROM Sede Where ID_Sede = @id;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                string resultado = "";
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id",id);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    if (dr["Nombre"].ToString() != "")
                    {
                        resultado = dr["Nombre"].ToString();
                    }
                    else
                    {
                        resultado = "";
                    }
                }
                cn.Close();
                return resultado;
            }
        }
    }
}
