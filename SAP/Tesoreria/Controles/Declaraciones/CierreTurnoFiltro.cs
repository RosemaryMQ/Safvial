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
    public partial class CierreTurnoFiltro : Form
    {
        public CierreTurnoFiltro()
        {
            InitializeComponent();
        }

        private void CierreTurnoFiltro_Load(object sender, EventArgs e)
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
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Reporte Diario (24 Horas)");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                else if (SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno == 11)
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Turno", "Reporte Diario por Turno (24 Horas)");
                    this.reportViewer1.LocalReport.SetParameters(frm);
                }
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString("G"));
                this.reportViewer1.LocalReport.SetParameters(frm1);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS);
                this.reportViewer1.LocalReport.SetParameters(frm3);
                
                Microsoft.Reporting.WinForms.ReportParameter frm4 = new Microsoft.Reporting.WinForms.ReportParameter("FechaPrimeraTabulacion", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacion);
                this.reportViewer1.LocalReport.SetParameters(frm4);
                Microsoft.Reporting.WinForms.ReportParameter frm5 = new Microsoft.Reporting.WinForms.ReportParameter("FechaUltimaTabulacion", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacion);
                this.reportViewer1.LocalReport.SetParameters(frm5);
                //Microsoft.Reporting.WinForms.ReportParameter frm6 = new Microsoft.Reporting.WinForms.ReportParameter("FechaSolicitud", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaSolicitud);
                //this.reportViewer1.LocalReport.SetParameters(frm6);
                //Microsoft.Reporting.WinForms.ReportParameter frm7 = new Microsoft.Reporting.WinForms.ReportParameter("FechaPrimerAvance", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerAvance);
                //this.reportViewer1.LocalReport.SetParameters(frm7);
                Microsoft.Reporting.WinForms.ReportParameter frm8 = new Microsoft.Reporting.WinForms.ReportParameter("FechaUltimoAvance", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance);
                this.reportViewer1.LocalReport.SetParameters(frm8);
                
                this.cierreTurnoFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreTurnoFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaInicio), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierreEfectivoFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreEfectivoFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacion), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPivoteD), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPivoteN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacion), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierrePDVFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierrePDVFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacion), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaFinal), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaInicio), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacion), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierrePINCFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierrePINCFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacion), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaFinal), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaInicio), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacion), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierreTransfFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreTransfFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacion), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaFinal), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaInicio), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacion), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierreBiopagoFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreBiopagoFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacion), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaFinal), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaInicio), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacion), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierreBuzonFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreBuzonFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaInicio), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.tarjetaExpressReporte1TableAdapter.Fill(this.tarjetaExpressDataSet.TarjetaExpressReporte1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Inicio.sede);

                // Limpiamos cualquier basura anterior
                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTurno", (System.Data.DataTable)this.sAPDataSetLocal.CierreTurnoFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePDV", (System.Data.DataTable)this.sAPDataSetLocal.CierrePDVFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreEfectivo", (System.Data.DataTable)this.sAPDataSetLocal.CierreEfectivoFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePINC", (System.Data.DataTable)this.sAPDataSetLocal.CierrePINCFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTransf", (System.Data.DataTable)this.sAPDataSetLocal.CierreTransfFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBuzon", (System.Data.DataTable)this.sAPDataSetLocal.CierreBuzonFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBiopago", (System.Data.DataTable)this.sAPDataSetLocal.CierreBiopagoFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TarjetaExpress", (System.Data.DataTable)this.tarjetaExpressDataSet.TarjetaExpressReporte1));

                this.reportViewer1.RefreshReport();


            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar el reporte.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
                throw;
            }

            this.reportViewer1.RefreshReport();
        }


    }
}
