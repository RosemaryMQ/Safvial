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
    public partial class ConsolidadoCliente : Form
    {
        public ConsolidadoCliente()
        {
            InitializeComponent();
        }

        private void ConsolidadoCliente_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Cliente", SAP.Recaudadores.Controles.Consulta.nombre);
            this.reportViewer1.LocalReport.SetParameters(frm);
            this.consumoClienteTableAdapter.Fill(this.prepagadoDataSet.ConsumoCliente, Convert.ToInt32(SAP.Recaudadores.Controles.Consulta.ID_Cliente));
            this.cobrosGlobalCTableAdapter.Fill(this.prepagadoDataSet.CobrosGlobalC, Convert.ToInt32(SAP.Recaudadores.Controles.Consulta.ID_Cliente));
            this.cobrosVehiculosCTableAdapter.Fill(this.prepagadoDataSet.CobrosVehiculosC, Convert.ToInt32(SAP.Recaudadores.Controles.Consulta.ID_Cliente));
            this.operacionesCTableAdapter.Fill(this.prepagadoDataSet.OperacionesC, Convert.ToInt32(SAP.Recaudadores.Controles.Consulta.ID_Cliente));
            this.reportViewer1.RefreshReport();
        }
    }
}
