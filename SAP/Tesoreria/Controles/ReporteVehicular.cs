using System;
using System.Windows.Forms;

namespace SAP.Tesoreria.Controles
{
    public partial class ReporteVehicular : Form
    {
        String fecha = "31/12/" + DateTime.Now.Year.ToString() + " 23:59:59";
        String fecha2 = "01/01/" + DateTime.Now.Year.ToString() + " 00:00:00";
        public ReporteVehicular()
        {
            InitializeComponent();
            date1.Value.ToShortDateString();
            date2.Value.ToShortDateString();
        }

        private void ReporteVehicular_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sAPDataSet.Grafico' Puede moverla o quitarla según sea necesario.
            Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", fecha2);
            Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", fecha);
            this.reportViewer1.LocalReport.SetParameters(frm);
            this.reportViewer1.LocalReport.SetParameters(frm1);
            this.graficoTableAdapter1.Grafico(this.sAPDataSet2.Grafico,Convert.ToDateTime(fecha2), Convert.ToDateTime(fecha));
            this.reportViewer1.RefreshReport();
        }

        private void button5_Click(object sender, EventArgs e)
        {

                if (hora1.Text != "" && min1.Text != "" && hora2.Text != "" && min2.Text != "")
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", date1.Text);
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", date2.Text);
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    this.graficoTableAdapter1.Grafico(this.sAPDataSet2.Grafico, Convert.ToDateTime(date1.Value.ToShortDateString()+" "+hora1.Text+":"+min1.Text+":00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"));
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Para poder realizar la consulta debe llenar todos los campos correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

        }

        private void hora1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13) && e.KeyChar != ':')
            {
                e.Handled = true;
                return;
            }
        }
    }
}
