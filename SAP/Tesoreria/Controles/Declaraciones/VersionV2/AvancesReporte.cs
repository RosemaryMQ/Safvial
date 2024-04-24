using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class AvancesReporte : Form
    {
        public AvancesReporte()
        {
            InitializeComponent();
        }

        private void AvancesReporte_Load(object sender, EventArgs e)
        {
            if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.validador==1) {
                SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.validador = 0;
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Recaudador", SAP.Tesoreria.Controles.ListaDeclaraciones.nombreusuario);
                this.EfectivoS.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString("G"));
                this.EfectivoS.LocalReport.SetParameters(frm1);
                this.cierresParcialesTableAdapter.Fill(sAPDataSet2.CierresParciales, Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), Convert.ToDateTime(SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial), Convert.ToDateTime(SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal));
                this.EfectivoS.RefreshReport();

            }
            else
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Recaudador", SAP.Tesoreria.TesoreriaV2.Nombre);
                this.EfectivoS.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString("G"));
                this.EfectivoS.LocalReport.SetParameters(frm1);
                this.cierresParcialesTableAdapter.Fill(sAPDataSet2.CierresParciales, Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), Convert.ToDateTime(SAP.Tesoreria.TesoreriaV2.Apertura), DateTime.Now);
                this.EfectivoS.RefreshReport();
            }
        }
    }
}
