using System;
using System.Windows.Forms;

namespace SAP.Tesoreria
{
    public partial class RemesasTipos : Form
    {
        String fecha = DateTime.Now.ToShortDateString();
        String fechas;
        public RemesasTipos()
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
        private void RemesasTipos_Load(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", fecha2.Value.ToShortDateString());
                this.reportViewer1.LocalReport.SetParameters(frm);
                this.reportViewer1.LocalReport.SetParameters(frm1);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Sede", SAP.Tesoreria.Reportes.Peaje);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                this.bolivaresFuertesTableAdapter.Fill(this.sAPDataSet2.BolivaresFuertes, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()));
                this.bolivaresSoberanosTableAdapter.Fill(this.sAPDataSet2.BolivaresSoberanos, Convert.ToDateTime(date1.Value.ToShortDateString() +" 09:30:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 09:30:00"));
                this.reportViewer1.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error de conexion, por favor reintente mas tarde.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", fecha2.Value.ToShortDateString());
                this.reportViewer1.LocalReport.SetParameters(frm);
                this.reportViewer1.LocalReport.SetParameters(frm1);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Sede", SAP.Tesoreria.Reportes.Peaje);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                this.bolivaresFuertesTableAdapter.Fill(this.sAPDataSet2.BolivaresFuertes, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()));
                this.bolivaresSoberanosTableAdapter.Fill(this.sAPDataSet2.BolivaresSoberanos, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()));
                this.reportViewer1.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error de conexion, por favor reintente mas tarde.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
