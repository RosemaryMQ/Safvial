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

namespace SAP.Tesoreria.Controles.ReportePeajes
{
    public partial class RecaudacionPeajesMensual: Form
    {

        String fecha = DateTime.Now.ToShortDateString();
        String fechas;
        String acumulador;
        Double acumulador1;
        Double acumulador2;
        Double webg;
        Double webe;
        String Formato1;
        String Formato2;
        public RecaudacionPeajesMensual()
        {
            InitializeComponent();
            fechas = Convert.ToString(this.LastDayOfMonthFromDateTime(DateTime.Now));
            date1.Value.ToShortDateString();
            fecha2.Value.ToShortDateString();
        }
        public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
        private async Task<double> ConsultaEspecia(string forma, int sedes, DateTime fecha1, DateTime fecha2)
        {
            string sql = "SELECT Ventas.Monto AS Recaudado FROM Ventas INNER JOIN Sede ON Ventas.Sede = Sede.ID_Sede WHERE Ventas.FormaPago = @forma AND Ventas.Sede = @donde AND Ventas.Fecha BETWEEN @fecha1 AND @fecha2";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                acumulador = "";
                acumulador1 = 0;
                acumulador2 = 0;
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("donde", sedes);
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(fecha1));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fecha2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {

                    acumulador = dr["Recaudado"].ToString();
                    if (acumulador != "")
                    {
                        acumulador1 = Convert.ToDouble(acumulador);
                        acumulador2 = acumulador2 + acumulador1;
                    }

                }
                dr.Close();
                return acumulador2;
            }
        }
        private async void RecaudacionPeajes_Load(object sender, EventArgs e)
        {
            try
            {

                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", fecha2.Value.ToShortDateString());
                this.reportViewer1.LocalReport.SetParameters(frm);
                this.reportViewer1.LocalReport.SetParameters(frm1);
                this.efectivoMTableAdapter.Fill(this.sAPDataSet2.EfectivoM, "Efectivo", Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 23:59:59"));
                this.pDVMTableAdapter.Fill(this.sAPDataSet2.PDVM, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 23:59:59"));
                this.efectivoETableAdapter.Fill(this.sAPDataSet3.EfectivoE, "Efectivo", Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 23:59:59"));
                this.pDVETableAdapter.Fill(this.sAPDataSet3.PDVE, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 23:59:59"));
                webe = await ConsultaEspecia("Recarga WEB", 2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 23:59:59"));
                webg = await ConsultaEspecia("Recarga WEB", 1, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 23:59:59"));
                Microsoft.Reporting.WinForms.ReportParameter frm5 = new Microsoft.Reporting.WinForms.ReportParameter("RecargasWEBG", Convert.ToString(webg));
                Microsoft.Reporting.WinForms.ReportParameter frm6 = new Microsoft.Reporting.WinForms.ReportParameter("RecargasWEBE", Convert.ToString(webe));
                this.reportViewer1.LocalReport.SetParameters(frm5);
                this.reportViewer1.LocalReport.SetParameters(frm6);
                this.recargasPeajeTableAdapter.Fill(this.prepagadoDataSet.RecargasPeaje, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()), 1);
                this.recargasPeaje1TableAdapter.Fill(this.prepagadoDataSet.RecargasPeaje1, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()), 2);
                this.reportViewer1.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error de conexion, con alguna de las sedes, intente mas tarde.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string fechaInicialG = await Control(Convert.ToDateTime(date1.Value.ToShortDateString() + " 22:00:00").AddDays(-1), Convert.ToDateTime(date1.Value.ToShortDateString() + " 20:00:00"), (string)Settings.Default["Sede1"]);
                string fechaFinG = await Control1(Convert.ToDateTime(date1.Value.ToShortDateString() + " 16:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 03:00:00").AddDays(1), (string)Settings.Default["Sede1"]);
                string fechaInicialE = await Control(Convert.ToDateTime(date1.Value.ToShortDateString() + " 22:00:00").AddDays(-1), Convert.ToDateTime(date1.Value.ToShortDateString() + " 20:00:00"), (string)Settings.Default["SAP2"]);
                string fechaFinE = await Control1(Convert.ToDateTime(date1.Value.ToShortDateString() + " 16:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 03:00:00").AddDays(1), (string)Settings.Default["SAP2"]);
                if (fechaInicialG != "" && fechaFinG != ""  && fechaInicialE != "" && fechaFinE != "")
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", Convert.ToString(fechaInicialG));
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", Convert.ToString(fechaFinG));
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    this.efectivoMTableAdapter.Fill(this.sAPDataSet2.EfectivoM, "Efectivo", Convert.ToDateTime(fechaInicialG), Convert.ToDateTime(fechaFinG));
                    this.pDVMTableAdapter.Fill(this.sAPDataSet2.PDVM, Convert.ToDateTime(fechaInicialG), Convert.ToDateTime(fechaFinG));
                    this.efectivoETableAdapter.Fill(this.sAPDataSet3.EfectivoE, "Efectivo", Convert.ToDateTime(fechaInicialE), Convert.ToDateTime(fechaFinE));
                    this.pDVETableAdapter.Fill(this.sAPDataSet3.PDVE, Convert.ToDateTime(fechaInicialE), Convert.ToDateTime(fechaFinE));
                    webe = await ConsultaEspecia("Recarga WEB", 2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 23:59:59"));
                    webg = await ConsultaEspecia("Recarga WEB", 1, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 23:59:59"));
                    Microsoft.Reporting.WinForms.ReportParameter frm5 = new Microsoft.Reporting.WinForms.ReportParameter("RecargasWEBG", Convert.ToString(webg));
                    Microsoft.Reporting.WinForms.ReportParameter frm6 = new Microsoft.Reporting.WinForms.ReportParameter("RecargasWEBE", Convert.ToString(webe));
                    this.reportViewer1.LocalReport.SetParameters(frm5);
                    this.reportViewer1.LocalReport.SetParameters(frm6);
                    this.recargasPeajeTableAdapter.Fill(this.prepagadoDataSet.RecargasPeaje, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()), 1);
                    this.recargasPeaje1TableAdapter.Fill(this.prepagadoDataSet.RecargasPeaje1, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()), 2);
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("la fecha que desea consultar no tiene información disponible.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
            catch
            {
                MessageBox.Show("Error de conexion, por favor reintente mas tarde.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // FECHA FIN
        private async Task<string> Control1(DateTime hora1, DateTime hora2, string ruta)
        {
            string sql = "SELECT TOP 1 Fecha FROM Pagos WHERE Fecha BETWEEN @fecha AND @fecha1 Order by Fecha DESC;";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string resultado = "";
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", hora1);
                cmd.Parameters.AddWithValue("fecha1", hora2);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    if (dr["Fecha"].ToString() != "")
                    {
                        resultado = Convert.ToString(Convert.ToDateTime(dr["Fecha"]).AddHours(2));
                    }
                    else
                    {
                        resultado = "";
                    }
                }
                dr.Close();
                cn.Close();
                return resultado;
            }
        }
        // FECHA DE INICIO
        private async Task<String> Control(DateTime hora1, DateTime hora2, string ruta)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Fecha BETWEEN @fecha AND @fecha1 Order by Fecha ASC;";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string resultado = "";
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", hora1);
                cmd.Parameters.AddWithValue("fecha1", hora2);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    if (dr["Fecha"].ToString() != "")
                    {
                        resultado = Convert.ToString(Convert.ToDateTime(dr["Fecha"]));
                    }
                    else
                    {
                        resultado = "";
                    }
                }
                dr.Close();
                cn.Close();
                return resultado;
            }
        }
    }
}
