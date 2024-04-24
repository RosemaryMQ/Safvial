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
    public partial class DeclaracionParametrizado : Form
    {
        String fecha = SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial;
        String fecha2 = SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal;
        String Forma1 = "Efectivo";
        String Forma2 = "Punto de Venta";
        //String Forma3 = "Saldo Pre-pagado";
        String Forma4 = "Ticket";
        String Forma5 = "Pago Incompleto";
        String id = SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1;
        int sede = SAP.Inicio.sede;
        public static string turno="";
        public static int turnocod = 0;
        public DeclaracionParametrizado()
        {
            InitializeComponent();
            turno = SAP.Tesoreria.Controles.ListaDeclaraciones.nombret;
            turnocod = Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.turno);
            Usuario.Text = "USUARIO: "+ SAP.Tesoreria.Controles.ListaDeclaraciones.nombreusuario;
            Turno.Text = "TURNO: " + SAP.Tesoreria.Controles.ListaDeclaraciones.nombret;
        }

        private void DeclaracionParametrizado_Load(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("acta", Convert.ToString(SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta));
                this.reportViewer1.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", Convert.ToString(fecha));
                this.reportViewer1.LocalReport.SetParameters(frm3);
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", Convert.ToString(fecha2));
                this.reportViewer1.LocalReport.SetParameters(frm1);
                this.tipoVehiculosTableAdapter.Recaudacion(this.sAPDataSet2.TipoVehiculos, Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(id));
                this.efectivoCierreTableAdapter.Efectivo(this.sAPDataSet.EfectivoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma1);
                this.pDVCierreTableAdapter.PDV(this.sAPDataSet.PDVCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma2);
                this.buzonRecaudadorTableAdapter.Fill(this.sAPDataSet2.BuzonRecaudador, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                //this.prepagadoCierreTableAdapter.Fill(this.prepagadoDataSet.PrepagadoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma3, sede);
                this.ticketCierreTableAdapter.Tickets(this.sAPDataSet.TicketCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma4);
                this.noPagoCierreTableAdapter.NoPago(this.sAPDataSet.NoPagoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma5);
                this.declaracionV3TableAdapter.Declaracion(this.sAPDataSet2.DeclaracionV3, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.usuariosTableAdapter.Usuario(this.sAPDataSet2.Usuarios, Convert.ToInt32(id));
                this.usuarioCanalTableAdapter.Fill(this.sAPDataSet2.UsuarioCanal, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreBalanceV2TableAdapter.Fill(this.sAPDataSet2.CierreBalanceV2, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.transferenciaCierreTableAdapter.Fill(this.sAPDataSet2.TransferenciaCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreTarjetaExpressTableAdapter.Fill(this.sAPDataSet2.CierreTarjetaExpress, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.reportViewer1.RefreshReport();

            }
            catch
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("acta", Convert.ToString(SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta));
                this.reportViewer1.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", Convert.ToString(fecha));
                this.reportViewer1.LocalReport.SetParameters(frm3);
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", Convert.ToString(fecha2));
                this.reportViewer1.LocalReport.SetParameters(frm1);
                this.tipoVehiculosTableAdapter.Recaudacion(this.sAPDataSet2.TipoVehiculos, Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(id));
                this.efectivoCierreTableAdapter.Efectivo(this.sAPDataSet.EfectivoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma1);
                this.pDVCierreTableAdapter.PDV(this.sAPDataSet.PDVCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma2);
                this.buzonRecaudadorTableAdapter.Fill(this.sAPDataSet2.BuzonRecaudador, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                //this.prepagadoCierreTableAdapter.Fill(this.prepagadoDataSet.PrepagadoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma3, sede);
                this.ticketCierreTableAdapter.Tickets(this.sAPDataSet.TicketCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma4);
                this.noPagoCierreTableAdapter.NoPago(this.sAPDataSet.NoPagoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma5);
                this.declaracionV3TableAdapter.Declaracion(this.sAPDataSet2.DeclaracionV3, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.usuarioCanalTableAdapter.Fill(this.sAPDataSet2.UsuarioCanal, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreBalanceV2TableAdapter.Fill(this.sAPDataSet2.CierreBalanceV2, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.transferenciaCierreTableAdapter.Fill(this.sAPDataSet2.TransferenciaCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreTarjetaExpressTableAdapter.Fill(this.sAPDataSet2.CierreTarjetaExpress, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.reportViewer1.RefreshReport();
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.TabulacionUsuario frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.TabulacionUsuario();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances();
            frm.ShowDialog();
            Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("acta", Convert.ToString(SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta));
            this.reportViewer1.LocalReport.SetParameters(frm1);
            Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", Convert.ToString(fecha2));
            this.reportViewer1.LocalReport.SetParameters(frm2);
            Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", Convert.ToString(fecha));
            this.reportViewer1.LocalReport.SetParameters(frm3);
            this.tipoVehiculosTableAdapter.Recaudacion(this.sAPDataSet2.TipoVehiculos, Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(id));
            this.efectivoCierreTableAdapter.Efectivo(this.sAPDataSet.EfectivoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma1);
            this.pDVCierreTableAdapter.PDV(this.sAPDataSet.PDVCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma2);
            this.buzonRecaudadorTableAdapter.Fill(this.sAPDataSet2.BuzonRecaudador, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
            //this.prepagadoCierreTableAdapter.Fill(this.prepagadoDataSet.PrepagadoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma3, sede);
            this.ticketCierreTableAdapter.Tickets(this.sAPDataSet.TicketCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma4);
            this.noPagoCierreTableAdapter.NoPago(this.sAPDataSet.NoPagoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma5);
            this.declaracionV3TableAdapter.Declaracion(this.sAPDataSet2.DeclaracionV3, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
            this.usuariosTableAdapter.Usuario(this.sAPDataSet2.Usuarios, Convert.ToInt32(id));
            this.usuarioCanalTableAdapter.Fill(this.sAPDataSet2.UsuarioCanal, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
            this.cierreBalanceV2TableAdapter.Fill(this.sAPDataSet2.CierreBalanceV2, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
            this.reportViewer1.RefreshReport();
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 20;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
            Turno.Text = "TURNO: " + turno;
            SAP.Tesoreria.Controles.ListaDeclaraciones.turno = Convert.ToString(turnocod);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.Bitacora frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Bitacora();
            frm.Show();
        }
    }
}
