using SAP.Properties;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Recaudadores.Controles
{
    public partial class ReporteDiaro : Form
    {
        String fecha = DateTime.Now.ToShortDateString();
        String fechas;
        public ReporteDiaro()
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
        private async void ReporteDiaro_Load(object sender, EventArgs e)
        {
            try
            {
                await Sedes();
                fechas = Convert.ToString(date2.Value.ToShortDateString());
                var afiliacionEfectivo = await FindTotal("A.Efectivo", date1.Value.ToShortDateString(), date2.Value.ToShortDateString(), SAP.Inicio.sede);
                var afiliacionTarjetaEfectivo = await FindTotal("Tarjeta Efectivo", date1.Value.ToShortDateString(), date2.Value.ToShortDateString(), SAP.Inicio.sede);
                var recargaEfectivo = await FindTotal("Recarga Efectivo", date1.Value.ToShortDateString(), date2.Value.ToShortDateString(), SAP.Inicio.sede);
                var totalAfiliaciones = afiliacionTarjetaEfectivo + afiliacionEfectivo;
                this.sedeTableAdapter.Fill(this.prepagadoDataSet.Sede, SAP.Inicio.sede);
                this.vendidasTableAdapter.Fill(this.prepagadoDataSet.Vendidas, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.afiliacionPDVTableAdapter.Fill(this.prepagadoDataSet.AfiliacionPDV, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.afiliacionTransfTableAdapter.Fill(this.prepagadoDataSet.AfiliacionTransf, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.recargaPDVTableAdapter.Fill(this.prepagadoDataSet.RecargaPDV, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.recargaTransfTableAdapter.Fill(this.prepagadoDataSet.RecargaTransf, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.recargasWebTableAdapter.Fill(this.prepagadoDataSet.RecargasWeb, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.tarjetasExoneradaTableAdapter.Fill(this.prepagadoDataSet.TarjetasExonerada, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.recargaExoneradaTableAdapter.Fill(this.prepagadoDataSet.RecargaExonerada, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.tarjetasExpressActTableAdapter.Fill(this.prepagadoDataSet.TarjetasExpressAct, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.recargaExpressTableAdapter.Fill(this.prepagadoDataSet.RecargaExpress, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.tarjetaExpressVentasTableAdapter.Fill(this.prepagadoDataSet.TarjetaExpressVentas, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.tarjetaReintegroTableAdapter.Fill(this.prepagadoDataSet.TarjetaReintegro, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.recargaReintegroTableAdapter.Fill(this.prepagadoDataSet.RecargaReintegro, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.afiliacionesOPETableAdapter.Fill(this.prepagadoDataSet.AfiliacionesOPE, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                this.recargaOPETableAdapter.Fill(this.prepagadoDataSet.RecargaOPE, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), SAP.Inicio.sede);
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFinal", date2.Value.ToShortDateString());
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Sede", SAP.Inicio.PeajeNombre.ToUpper());
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("RecargaEfectivo", recargaEfectivo.ToString());
                Microsoft.Reporting.WinForms.ReportParameter frm4 = new Microsoft.Reporting.WinForms.ReportParameter("TarjetasEfectivo", totalAfiliaciones.ToString());
                this.reportViewer1.LocalReport.SetParameters(frm);
                this.reportViewer1.LocalReport.SetParameters(frm1);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                this.reportViewer1.LocalReport.SetParameters(frm3);
                this.reportViewer1.LocalReport.SetParameters(frm4);
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.reportViewer1.RefreshReport();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
               if(Sede.SelectedIndex != -1)
                {
                    int val = Sede.SelectedIndex + 1;
                    fechas = Convert.ToString(date2.Value.ToShortDateString());
                    var afiliacionEfectivo = await FindTotal("A.Efectivo", date1.Value.ToShortDateString(), date2.Value.ToShortDateString(), val);
                    var afiliacionTarjetaEfectivo = await FindTotal("Tarjeta Efectivo", date1.Value.ToShortDateString(), date2.Value.ToShortDateString(), val);
                    var recargaEfectivo = await FindTotal("Recarga Efectivo", date1.Value.ToShortDateString(), date2.Value.ToShortDateString(), val);
                    var totalAfiliaciones = afiliacionTarjetaEfectivo + afiliacionEfectivo;
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFinal", date2.Value.ToShortDateString());
                    Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Sede", Sede.Text.ToUpper());
                    Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("RecargaEfectivo", recargaEfectivo.ToString());
                    Microsoft.Reporting.WinForms.ReportParameter frm4 = new Microsoft.Reporting.WinForms.ReportParameter("TarjetasEfectivo", totalAfiliaciones.ToString());
                    this.reportViewer1.LocalReport.SetParameters(frm2);
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    this.reportViewer1.LocalReport.SetParameters(frm3);
                    this.reportViewer1.LocalReport.SetParameters(frm4);
                    this.sedeTableAdapter.Fill(this.prepagadoDataSet.Sede, SAP.Inicio.sede);
                    this.vendidasTableAdapter.Fill(this.prepagadoDataSet.Vendidas, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.afiliacionPDVTableAdapter.Fill(this.prepagadoDataSet.AfiliacionPDV, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.afiliacionTransfTableAdapter.Fill(this.prepagadoDataSet.AfiliacionTransf, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.recargaPDVTableAdapter.Fill(this.prepagadoDataSet.RecargaPDV, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.recargaTransfTableAdapter.Fill(this.prepagadoDataSet.RecargaTransf, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.recargasWebTableAdapter.Fill(this.prepagadoDataSet.RecargasWeb, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.tarjetasExoneradaTableAdapter.Fill(this.prepagadoDataSet.TarjetasExonerada, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.recargaExoneradaTableAdapter.Fill(this.prepagadoDataSet.RecargaExonerada, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.tarjetasExpressActTableAdapter.Fill(this.prepagadoDataSet.TarjetasExpressAct, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.recargaExpressTableAdapter.Fill(this.prepagadoDataSet.RecargaExpress, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.tarjetaExpressVentasTableAdapter.Fill(this.prepagadoDataSet.TarjetaExpressVentas, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.recargaReintegroTableAdapter.Fill(this.prepagadoDataSet.RecargaReintegro, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.tarjetaReintegroTableAdapter.Fill(this.prepagadoDataSet.TarjetaReintegro, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.afiliacionesOPETableAdapter.Fill(this.prepagadoDataSet.AfiliacionesOPE, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
                    this.recargaOPETableAdapter.Fill(this.prepagadoDataSet.RecargaOPE, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(date2.Value.ToShortDateString()), val);
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
        private async Task<decimal> FindTotal(string forma, string fecha1, string fecha2, int sede)
        {
            decimal total = 0;
            string sql = "SELECT SUM(Ventas.Monto)AS Total FROM Ventas Where Ventas.Fecha BETWEEN @fecha1+' 00:00:00' and @fecha2+' 23:59:59' and Ventas.Sede=@sede and Ventas.FormaPago = @forma;";
            using (SqlConnection cn = new SqlConnection((string)Settings.Default["Prepagado"]))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.Parameters.AddWithValue("forma", forma);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {

                    total = dr["Total"].ToString() != "" ? Convert.ToDecimal(dr["Total"]) : 0;
                }
                cn.Close();
                return total;
            }
        }
    }
}
