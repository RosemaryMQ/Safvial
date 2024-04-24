using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Recaudadores.Controles
{
    public partial class ReporteSaldosN : Form
    {
        public ReporteSaldosN()
        {
            InitializeComponent();
        }

        private void ReporteSaldosN_Load(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToShortDateString());
                this.reportViewer1.LocalReport.SetParameters(frm);
                // TODO: esta línea de código carga datos en la tabla 'prepagadoDataSet.SaldosNegativos' Puede moverla o quitarla según sea necesario.
                this.saldosNegativosTableAdapter.Fill(this.prepagadoDataSet.SaldosNegativos);

                this.reportViewer1.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error al cargar el reporte", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
