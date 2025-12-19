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
        //String fecha2 = DateTime.Now.AddHours(2).ToString("G");
        String fecha2 = DateTime.Now.ToString("G");
        String Forma1 = "Efectivo";
        String Forma2 = "Punto de Venta";
        //String Forma3 = "Saldo Pre-pagado";
        String Forma4 = "Ticket";
        String Forma5 = "Pago Incompleto";
        string id = SAP.Tesoreria.TesoreriaV2.Identificador;
        int sede = SAP.Inicio.sede;
        int turnocod = SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvanceUser.turno;
        string idacta = "";
        public Declaracion()
        {
            InitializeComponent();
            //idacta = Convert.ToString(SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta);
            idacta = Convert.ToString(SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvanceUser.idacta);
        }
       
        private void Declaracion_Load(object sender, EventArgs e)
        {
            MessageBox.Show(idacta, "idacta");

            try
            {

                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("CodigoActa", idacta);
                this.reportViewer1.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", Convert.ToString(fecha2));
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", Convert.ToString(fecha));
                this.reportViewer1.LocalReport.SetParameters(frm3);

                this.tipoVehiculosTableAdapter1.Recaudacion(this.sAPDataSet2.TipoVehiculos, Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(id));
                this.efectivoCierreTableAdapter.Efectivo(this.sAPDataSet.EfectivoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma1, turnocod);
                this.pDVCierreTableAdapter.PDV(this.sAPDataSet.PDVCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma2, turnocod);
                this.buzonRecaudadorTableAdapter.Fill(this.sAPDataSet2.BuzonRecaudador, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                //this.prepagadoCierreTableAdapter.Fill(this.prepagadoDataSet.PrepagadoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma3, sede);
                this.ticketCierreTableAdapter.Tickets(this.sAPDataSet.TicketCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma4, turnocod);
                this.noPagoCierreTableAdapter.NoPago(this.sAPDataSet.NoPagoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma5, turnocod);
                this.declaracionV2TableAdapter.Declaracion(this.sAPDataSet2.DeclaracionV2, Convert.ToInt32(SAP.Inicio.ID));
                this.usuariosTableAdapter.Usuario(this.sAPDataSet2.Usuarios,Convert.ToInt32(id));             
                this.usuarioCanalTableAdapter.Fill(this.sAPDataSet2.UsuarioCanal, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreBalanceV2TableAdapter.Fill(this.sAPDataSet2.CierreBalanceV2, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.transferenciaCierreTableAdapter.Fill(this.sAPDataSet2.TransferenciaCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreTarjetaExpressTableAdapter.Fill(this.sAPDataSet2.CierreTarjetaExpress, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.biopagoCierreTableAdapter.Fill(this.sAPDataSet2.BiopagoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));


                Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource("Declaracion", (System.Data.DataTable)this.sAPDataSet2.DeclaracionV2);
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                Microsoft.Reporting.WinForms.ReportDataSource rdsPDVCierre = new Microsoft.Reporting.WinForms.ReportDataSource("PDVCierre", (System.Data.DataTable)this.sAPDataSet.PDVCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsPDVCierre);

                Microsoft.Reporting.WinForms.ReportDataSource rdsEfectivoCierre = new Microsoft.Reporting.WinForms.ReportDataSource("EfectivoCierre", (System.Data.DataTable)this.sAPDataSet.EfectivoCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsEfectivoCierre);

                Microsoft.Reporting.WinForms.ReportDataSource rdsTicketsCierre = new Microsoft.Reporting.WinForms.ReportDataSource("TicketsCierre", (System.Data.DataTable)this.sAPDataSet2.TicketCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsTicketsCierre);

                Microsoft.Reporting.WinForms.ReportDataSource rdsNoPagadoCierre = new Microsoft.Reporting.WinForms.ReportDataSource("NoPagadoCierre", (System.Data.DataTable)this.sAPDataSet2.NoPagoCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsNoPagadoCierre);

                Microsoft.Reporting.WinForms.ReportDataSource rdsRecaudadoTotal = new Microsoft.Reporting.WinForms.ReportDataSource("RecaudadoTotal", (System.Data.DataTable)this.sAPDataSet2.TipoVehiculos);
                this.reportViewer1.LocalReport.DataSources.Add(rdsRecaudadoTotal);

                Microsoft.Reporting.WinForms.ReportDataSource rdsUsuario = new Microsoft.Reporting.WinForms.ReportDataSource("Usuario", (System.Data.DataTable)this.sAPDataSet2.Usuarios);
                this.reportViewer1.LocalReport.DataSources.Add(rdsUsuario);

                Microsoft.Reporting.WinForms.ReportDataSource rdsCanales = new Microsoft.Reporting.WinForms.ReportDataSource("Canales", (System.Data.DataTable)this.sAPDataSet2.UsuarioCanal);
                this.reportViewer1.LocalReport.DataSources.Add(rdsCanales);

                Microsoft.Reporting.WinForms.ReportDataSource rdsReconversion = new Microsoft.Reporting.WinForms.ReportDataSource("reconversion", (System.Data.DataTable)this.sAPDataSet2.CierreBalanceV2);
                this.reportViewer1.LocalReport.DataSources.Add(rdsReconversion);

                Microsoft.Reporting.WinForms.ReportDataSource rdsTransferenciaCierre = new Microsoft.Reporting.WinForms.ReportDataSource("TransferenciaCierre", (System.Data.DataTable)this.sAPDataSet2.TransferenciaCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsTransferenciaCierre);

                Microsoft.Reporting.WinForms.ReportDataSource rdsTarjetaExpres = new Microsoft.Reporting.WinForms.ReportDataSource("TarjetaExpress", (System.Data.DataTable)this.sAPDataSet2.CierreTarjetaExpress);
                this.reportViewer1.LocalReport.DataSources.Add(rdsTarjetaExpres);

                Microsoft.Reporting.WinForms.ReportDataSource rdsBuzonRecaudador = new Microsoft.Reporting.WinForms.ReportDataSource("BuzonRecaudador", (System.Data.DataTable)this.sAPDataSet2.BuzonRecaudador);
                this.reportViewer1.LocalReport.DataSources.Add(rdsBuzonRecaudador);

                Microsoft.Reporting.WinForms.ReportDataSource rdsBiopagoCierre = new Microsoft.Reporting.WinForms.ReportDataSource("BiopagoCierre", (System.Data.DataTable)this.sAPDataSet2.BiopagoCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsBiopagoCierre);

                this.reportViewer1.RefreshReport();

            }
            catch
            {

                //Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("acta", Convert.ToString(SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvanceUser.idacta));
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("CodigoActa", Convert.ToString(SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvanceUser.idacta));
                this.reportViewer1.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", Convert.ToString(fecha2));
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", Convert.ToString(fecha));
                this.reportViewer1.LocalReport.SetParameters(frm3);
                this.tipoVehiculosTableAdapter1.Recaudacion(this.sAPDataSet2.TipoVehiculos, Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(id));
                this.efectivoCierreTableAdapter.Efectivo(this.sAPDataSet.EfectivoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma1, turnocod);
                this.pDVCierreTableAdapter.PDV(this.sAPDataSet.PDVCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma2, turnocod);
                this.buzonRecaudadorTableAdapter.Fill(this.sAPDataSet2.BuzonRecaudador, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                //this.prepagadoCierreTableAdapter.Fill(this.prepagadoDataSet.PrepagadoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma3, sede);
                this.ticketCierreTableAdapter.Tickets(this.sAPDataSet.TicketCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma4, turnocod);
                this.noPagoCierreTableAdapter.NoPago(this.sAPDataSet.NoPagoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma5, turnocod);
                this.declaracionV2TableAdapter.Declaracion(this.sAPDataSet2.DeclaracionV2, Convert.ToInt32(SAP.Inicio.ID));
                this.usuariosTableAdapter.Usuario(this.sAPDataSet2.Usuarios, Convert.ToInt32(id));
                this.usuarioCanalTableAdapter.Fill(this.sAPDataSet2.UsuarioCanal, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreBalanceV2TableAdapter.Fill(this.sAPDataSet2.CierreBalanceV2, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.transferenciaCierreTableAdapter.Fill(this.sAPDataSet2.TransferenciaCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.cierreTarjetaExpressTableAdapter.Fill(this.sAPDataSet2.CierreTarjetaExpress, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
                this.biopagoCierreTableAdapter.Fill(this.sAPDataSet2.BiopagoCierre, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));

                Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource("Declaracion", (System.Data.DataTable)this.sAPDataSet2.DeclaracionV2);
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                Microsoft.Reporting.WinForms.ReportDataSource rdsPDVCierre = new Microsoft.Reporting.WinForms.ReportDataSource("PDVCierre", (System.Data.DataTable)this.sAPDataSet.PDVCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsPDVCierre);

                Microsoft.Reporting.WinForms.ReportDataSource rdsEfectivoCierre = new Microsoft.Reporting.WinForms.ReportDataSource("EfectivoCierre", (System.Data.DataTable)this.sAPDataSet.EfectivoCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsEfectivoCierre);

                Microsoft.Reporting.WinForms.ReportDataSource rdsTicketsCierre = new Microsoft.Reporting.WinForms.ReportDataSource("TicketsCierre", (System.Data.DataTable)this.sAPDataSet2.TicketCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsTicketsCierre);

                Microsoft.Reporting.WinForms.ReportDataSource rdsNoPagadoCierre = new Microsoft.Reporting.WinForms.ReportDataSource("NoPagadoCierre", (System.Data.DataTable)this.sAPDataSet2.NoPagoCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsNoPagadoCierre);

                Microsoft.Reporting.WinForms.ReportDataSource rdsRecaudadoTotal = new Microsoft.Reporting.WinForms.ReportDataSource("RecaudadoTotal", (System.Data.DataTable)this.sAPDataSet2.TipoVehiculos);
                this.reportViewer1.LocalReport.DataSources.Add(rdsRecaudadoTotal);

                Microsoft.Reporting.WinForms.ReportDataSource rdsUsuario = new Microsoft.Reporting.WinForms.ReportDataSource("Usuario", (System.Data.DataTable)this.sAPDataSet2.Usuarios);
                this.reportViewer1.LocalReport.DataSources.Add(rdsUsuario);

                Microsoft.Reporting.WinForms.ReportDataSource rdsCanales = new Microsoft.Reporting.WinForms.ReportDataSource("Canales", (System.Data.DataTable)this.sAPDataSet2.UsuarioCanal);
                this.reportViewer1.LocalReport.DataSources.Add(rdsCanales);

                Microsoft.Reporting.WinForms.ReportDataSource rdsReconversion = new Microsoft.Reporting.WinForms.ReportDataSource("reconversion", (System.Data.DataTable)this.sAPDataSet2.CierreBalanceV2);
                this.reportViewer1.LocalReport.DataSources.Add(rdsReconversion);

                Microsoft.Reporting.WinForms.ReportDataSource rdsTransferenciaCierre = new Microsoft.Reporting.WinForms.ReportDataSource("TransferenciaCierre", (System.Data.DataTable)this.sAPDataSet2.TransferenciaCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsTransferenciaCierre);

                Microsoft.Reporting.WinForms.ReportDataSource rdsTarjetaExpres = new Microsoft.Reporting.WinForms.ReportDataSource("TarjetaExpress", (System.Data.DataTable)this.sAPDataSet2.CierreTarjetaExpress);
                this.reportViewer1.LocalReport.DataSources.Add(rdsTarjetaExpres);

                Microsoft.Reporting.WinForms.ReportDataSource rdsBuzonRecaudador = new Microsoft.Reporting.WinForms.ReportDataSource("BuzonRecaudador", (System.Data.DataTable)this.sAPDataSet2.BuzonRecaudador);
                this.reportViewer1.LocalReport.DataSources.Add(rdsBuzonRecaudador);

                Microsoft.Reporting.WinForms.ReportDataSource rdsBiopagoCierre = new Microsoft.Reporting.WinForms.ReportDataSource("BiopagoCierre", (System.Data.DataTable)this.sAPDataSet2.BiopagoCierre);
                this.reportViewer1.LocalReport.DataSources.Add(rdsBiopagoCierre);

                this.reportViewer1.RefreshReport();
            }
           
        }

    }
}
