using
    System;
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
    public partial class FlujoVehicularV2 : Form
    {
        String fecha = DateTime.Now.ToShortDateString();
        String fechas;
        public FlujoVehicularV2()
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
        private void FlujoVehicularV2_Load(object sender, EventArgs e)
        {
            try
            {

                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", fecha2.Value.ToShortDateString());
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Peaje", SAP.Tesoreria.Reportes.Peaje);
                this.reportViewer1.LocalReport.SetParameters(frm);
                this.reportViewer1.LocalReport.SetParameters(frm1);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                this.flujoVehicularV6TableAdapter.Fill(this.sAPDataSet2.FlujoVehicularV6, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()));
                this.flujoVehicularV6TableAdapter1.Fill(this.prepagadoDataSet.FlujoVehicularV6, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()), SAP.Tesoreria.Reportes.sede);
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error de conexion, por favor reintente mas tarde."+ex, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 8000;
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", fecha2.Value.ToShortDateString());
                    Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Peaje", SAP.Tesoreria.Reportes.Peaje);
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    this.reportViewer1.LocalReport.SetParameters(frm2);
                    this.flujoVehicularV6TableAdapter1.Fill(this.prepagadoDataSet.FlujoVehicularV6, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()), SAP.Tesoreria.Reportes.sede);
                    this.flujoVehicularV6TableAdapter.Fill(this.sAPDataSet2.FlujoVehicularV6, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()));
                    this.reportViewer1.RefreshReport();
                }
             
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error de conexion, por favor reintente mas tarde.   "+ex, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FlujoVehicularV2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
