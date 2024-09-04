using System;
using System.Windows.Forms;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class AvanceReport : Form
    {
        public AvanceReport()
        {
            InitializeComponent();
        }

        private void AvanceReport_Load(object sender, EventArgs e)
        {

            try
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Canal", Convert.ToString(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.canalb1));
                this.reportViewer1.LocalReport.SetParameters(frm);
                this.efectivoCierreTableAdapter.Efectivo(this.sAPDataSet.EfectivoCierre, SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.fechab1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.fechab2), "Efectivo");
                this.pDVCierreTableAdapter.PDV(this.sAPDataSet.PDVCierre, SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.fechab1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.fechab2), "Punto de Venta");
                //this.ticketCierreTableAdapter.Tickets(this.sAPDataSet.TicketCierre, Convert.ToInt32(SAP.Inicio.ID), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma4);
                this.noPagoCierreTableAdapter.NoPago(this.sAPDataSet.NoPagoCierre, SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.fechab1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.fechab2), "Pago Incompleto");
                //this.exoneradosCierreTableAdapter.Exonerados(this.sAPDataSet.ExoneradosCierre, Convert.ToInt32(SAP.Inicio.ID), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma6);
                this.resumenTransfTableAdapter.Fill(this.sAPDataSet2.ResumenTransf, SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.fechab1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.fechab2), "Transferencia");
                this.tarjetaExpressReporte11TableAdapter.Fill(this.tarjetaExpressDataSet.TarjetaExpressReporte11, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.fechab1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados.fechab2), SAP.Inicio.sede, Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario));
                this.usuariosTableAdapter.Usuario(this.sAPDataSet2.Usuarios, SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario);
                this.reportViewer1.RefreshReport();
            }
            catch
            {
                MessageBox.Show("¡Error al generar el reporte!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
