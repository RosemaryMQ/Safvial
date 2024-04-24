using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Tesoreria.Controles
{
    public partial class RecaudacionTiposSC : Form
    {
        String fecha = DateTime.Now.ToShortDateString();
        String fechas;
        public RecaudacionTiposSC()
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
        private void button5_Click(object sender, EventArgs e)
        {
            if (hora1.Text != "" && min1.Text != "" && hora2.Text != "" && min2.Text != "")
            {
                try
                {
                    //Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                    //Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", date2.Value.ToShortDateString());
                    //this.reportViewer1.LocalReport.SetParameters(frm);
                    //this.reportViewer1.LocalReport.SetParameters(frm1);
                    //this.pagoIncompletoTableAdapter.Fill(this.sAPDataSet2.PagoIncompleto, "Pago Incompleto", Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    //this.efectivoTableAdapter.Fill(this.sAPDataSet2.Efectivo, "Efectivo", Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    //this.pDVTableAdapter.Fill(this.sAPDataSet2.PDV, Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    //this.ticketsTableAdapter.Fill(this.sAPDataSet2.Tickets, "Ticket", Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    //this.tesoreriaTableAdapter.Fill(this.sAPDataSet2.Tesoreria, Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    //this.reporteTableAdapter.Fill(this.sAPDataSet2.reporte, Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    //this.reportViewer1.RefreshReport();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar el reporte"+ex, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Para poder realizar la consulta debe llenar todos los campos correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RecaudacionTiposSC_Load(object sender, EventArgs e)
        {
            try
            {
                //Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Value.ToShortDateString());
                //Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", date2.Value.ToShortDateString());
                //this.reportViewer1.LocalReport.SetParameters(frm);
                //this.reportViewer1.LocalReport.SetParameters(frm1);
                //this.pagoIncompletoTableAdapter.Fill(this.sAPDataSet2.PagoIncompleto, "Pago Incompleto", Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 23:59:59"));
                //this.efectivoTableAdapter.Fill(this.sAPDataSet2.Efectivo, "Efectivo", Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 23:59:59"));
                //this.pDVTableAdapter.Fill(this.sAPDataSet2.PDV, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 23:59:59"));
                //this.ticketsTableAdapter.Fill(this.sAPDataSet2.Tickets, "Ticket", Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 23:59:59"));
                //this.tesoreriaTableAdapter.Fill(this.sAPDataSet2.Tesoreria, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 23:59:59"));
                //this.reporteTableAdapter.Fill(this.sAPDataSet2.reporte, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 23:59:59"));
                //this.reportViewer1.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error al cargar el reporte", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
    }
}
