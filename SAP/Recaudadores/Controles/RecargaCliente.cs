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
    public partial class RecargaCliente : Form
    {
        public RecargaCliente()
        {
            InitializeComponent();
        }

        private void RecargaCliente_Load(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToShortDateString());
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Cliente", SAP.Recaudadores.Controles.Consulta.nombre);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("DNI", SAP.Recaudadores.Controles.Buscador.DNI);
                this.reportViewer1.LocalReport.SetParameters(frm);
                this.reportViewer1.LocalReport.SetParameters(frm1);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                this.recargasTableAdapter.Fill(this.prepagadoDataSet.Recargas, Convert.ToInt32(SAP.Recaudadores.Controles.Consulta.ID_Cliente));
                this.reportViewer1.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error al cargar el reporte, por favor reintente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
