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
    public partial class ConsumoTarjeta : Form
    {
        public ConsumoTarjeta()
        {
            InitializeComponent();
        }

        private void ConsumoTarjeta_Load(object sender, EventArgs e)
        {
            try
            {
                if (SAP.Recaudadores.Controles.TarjetasCliente.codigo1 == "")
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToShortDateString());
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Cliente", SAP.Recaudadores.Controles.Consulta.nombre);
                    Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Tarjeta", SAP.Recaudadores.Controles.TarjetasCliente.codigo);
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    this.reportViewer1.LocalReport.SetParameters(frm2);
                    this.consumoTarjetaTableAdapter.Fill(this.prepagadoDataSet.ConsumoTarjeta, SAP.Recaudadores.Controles.TarjetasCliente.codigo);
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToShortDateString());
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Cliente", SAP.Recaudadores.Controles.Consulta.nombre);
                    Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Tarjeta", SAP.Recaudadores.Controles.TarjetasCliente.codigo1);
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    this.reportViewer1.LocalReport.SetParameters(frm2);
                    this.consumoTarjetaTableAdapter.Fill(this.prepagadoDataSet.ConsumoTarjeta, SAP.Recaudadores.Controles.TarjetasCliente.codigo);
                    this.reportViewer1.RefreshReport();
                }
           
            }
            catch
            {
                MessageBox.Show("Error al cargar el reporte, por favor reintente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
