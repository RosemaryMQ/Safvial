using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAP.Tesoreria.Controles.Declaraciones
{
    public partial class Declaracion : Form
    {
        String fecha = SAP.Tesoreria.TesoreriaV2.Apertura;
        String fecha2 = DateTime.Now.AddHours(2).ToString("G");
        String Forma1 = "Efectivo";
        String Forma2 = "Punto de Venta";
        //String Forma3 = "Saldo Pre-pagado";
        String Forma4 = "Ticket";
        String Forma5 = "Pago Incompleto";
        string id = SAP.Tesoreria.TesoreriaV2.Identificador;
        int sede = SAP.Inicio.sede;
        string idacta = "";
        public Declaracion()
        {
            InitializeComponent();
            idacta = Convert.ToString(SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta);
        }
       
        private void Declaracion_Load(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("CodigoActa", idacta);
                this.reportViewer1.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", Convert.ToString(fecha2));
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", Convert.ToString(fecha));
                this.reportViewer1.LocalReport.SetParameters(frm3);
                this.tipoVehiculosTableAdapter1.Recaudacion(this.sAPDataSet2.TipoVehiculos, Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(id));
                this.efectivoCierreTableAdapter.Efectivo(this.sAPDataSet.EfectivoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma1);
                this.pDVCierreTableAdapter.PDV(this.sAPDataSet.PDVCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma2);
                this.buzonRecaudadorTableAdapter.Fill(this.sAPDataSet2.BuzonRecaudador, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                //this.prepagadoCierreTableAdapter.Fill(this.prepagadoDataSet.PrepagadoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma3, sede);
                this.ticketCierreTableAdapter.Tickets(this.sAPDataSet.TicketCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma4);
                this.noPagoCierreTableAdapter.NoPago(this.sAPDataSet.NoPagoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma5);
                this.declaracionV2TableAdapter.Declaracion(this.sAPDataSet2.DeclaracionV2, Convert.ToInt32(SAP.Inicio.ID));
                this.usuariosTableAdapter.Usuario(this.sAPDataSet2.Usuarios,Convert.ToInt32(id));
                this.usuarioCanalTableAdapter.Fill(this.sAPDataSet2.UsuarioCanal, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreBalanceV2TableAdapter.Fill(this.sAPDataSet2.CierreBalanceV2, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.transferenciaCierreTableAdapter.Fill(this.sAPDataSet2.TransferenciaCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreTarjetaExpressTableAdapter.Fill(this.sAPDataSet2.CierreTarjetaExpress, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.reportViewer1.RefreshReport();
            }
            catch
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("acta", Convert.ToString(SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvanceUser.idacta));
                this.reportViewer1.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", Convert.ToString(fecha2));
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", Convert.ToString(fecha));
                this.reportViewer1.LocalReport.SetParameters(frm3);
                this.tipoVehiculosTableAdapter1.Recaudacion(this.sAPDataSet2.TipoVehiculos, Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(id));
                this.efectivoCierreTableAdapter.Efectivo(this.sAPDataSet.EfectivoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma1);
                this.pDVCierreTableAdapter.PDV(this.sAPDataSet.PDVCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma2);
                this.buzonRecaudadorTableAdapter.Fill(this.sAPDataSet2.BuzonRecaudador, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                //this.prepagadoCierreTableAdapter.Fill(this.prepagadoDataSet.PrepagadoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma3, sede);
                this.ticketCierreTableAdapter.Tickets(this.sAPDataSet.TicketCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma4);
                this.noPagoCierreTableAdapter.NoPago(this.sAPDataSet.NoPagoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma5);
                this.declaracionV2TableAdapter.Declaracion(this.sAPDataSet2.DeclaracionV2, Convert.ToInt32(SAP.Inicio.ID));
                this.usuariosTableAdapter.Usuario(this.sAPDataSet2.Usuarios, Convert.ToInt32(id));
                this.usuarioCanalTableAdapter.Fill(this.sAPDataSet2.UsuarioCanal, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreBalanceV2TableAdapter.Fill(this.sAPDataSet2.CierreBalanceV2, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.transferenciaCierreTableAdapter.Fill(this.sAPDataSet2.TransferenciaCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreTarjetaExpressTableAdapter.Fill(this.sAPDataSet2.CierreTarjetaExpress, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.reportViewer1.RefreshReport();
            }
           
        }

    }
}
