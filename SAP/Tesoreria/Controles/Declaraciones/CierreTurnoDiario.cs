using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Tesoreria.Controles.Declaraciones
{
    public partial class CierreTurnoDiario : Form
    {
        public CierreTurnoDiario()
        {
            InitializeComponent();
        }


        private void CierreTurnoDiario_Load(object sender, EventArgs e)
        {

            try
            {
                if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 1)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Diurno");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                else if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 2)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Nocturno");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                else if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 3)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Completo Grupo 1");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                else if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 4)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Completo Grupo 2");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                else if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 5)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Turno 1");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                else if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 6)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Turno 2");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                else if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 7)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Turno 3");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                else if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 8)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Turno 12h 00:00 - 12:00");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                else if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 9)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Turno 12h 12:00 - 23:59");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                else if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 10)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Turno 24h  00:00 - 23:59");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString("G"));
                this.reportViewer1.LocalReport.SetParameters(frm1);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS);
                this.reportViewer1.LocalReport.SetParameters(frm3);
                Microsoft.Reporting.WinForms.ReportParameter frm4 = new Microsoft.Reporting.WinForms.ReportParameter("PrimeraTabulacion", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacion);
                this.reportViewer1.LocalReport.SetParameters(frm4);
                Microsoft.Reporting.WinForms.ReportParameter frm5 = new Microsoft.Reporting.WinForms.ReportParameter("UltimaTabulacion", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacion);
                this.reportViewer1.LocalReport.SetParameters(frm5);
                Microsoft.Reporting.WinForms.ReportParameter frm6 = new Microsoft.Reporting.WinForms.ReportParameter("FechaSolicitud", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaSolicitud);
                this.reportViewer1.LocalReport.SetParameters(frm6);

                this.cierreTurnoV1DiarioTableAdapter.Fill(this.sAPDataSet2.CierreTurnoV1Diario, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.cierreEfectivo1TableAdapter.Fill(this.sAPDataSet2.CierreEfectivo1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.cierrePDV1TableAdapter.Fill(this.sAPDataSet2.CierrePDV1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.cierrePINC1TableAdapter.Fill(this.sAPDataSet2.CierrePINC1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.cierreTransf1TableAdapter.Fill(this.sAPDataSet2.CierreTransf1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.cierreBiopago1TableAdapter.Fill(this.sAPDataSet2.CierreBiopago1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.buzonTurno1TableAdapter.Fill(this.sAPDataSet2.BuzonTurno1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.tarjetaExpressReporte1TableAdapter.Fill(this.tarjetaExpressDataSet.TarjetaExpressReporte1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Inicio.sede);

                // Limpiamos cualquier basura anterior
                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTurno", (System.Data.DataTable)this.sAPDataSet2.CierreTurnoV1Diario));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePDV", (System.Data.DataTable)this.sAPDataSet2.CierrePDV1));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreEfectivo", (System.Data.DataTable)this.sAPDataSet2.CierreEfectivo1));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePINC", (System.Data.DataTable)this.sAPDataSet2.CierrePINC1));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTransf", (System.Data.DataTable)this.sAPDataSet2.CierreTransf1));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBuzon", (System.Data.DataTable)this.sAPDataSet2.BuzonTurno1));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBiopago", (System.Data.DataTable)this.sAPDataSet2.CierreBiopago1));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TarjetaExpress", (System.Data.DataTable)this.sAPDataSet2.CierreTarjetaExpress));



                this.reportViewer1.RefreshReport();


            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar el reporte.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                //throw;
            }


            //this.reportViewer1.RefreshReport();
        }
    }
}
