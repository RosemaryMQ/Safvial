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
                this.cierreTurnoFiltroTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreEfectivoFiltroTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierrePDVFiltroTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierrePINCFiltroTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreTransfFiltroTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreBiopagoFiltroTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreBuzonFiltroTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;

                this.cierreEfectivoDiaAnteriorTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierrePDVDiaAnteriorTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierrePINCDiaAnteriorTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreTransfDiaAnteriorTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreBiopagoDiaAnteriorTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;

                this.cierreEfectivoDiaSiguienteTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierrePDVDiaSiguienteTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierrePINCDiaSiguienteTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreTransfDiaSiguienteTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreBiopagoDiaSiguienteTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;

                this.cierreEfectivoDiaSiguientehoyTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierrePDVDiaSiguientehoyTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierrePINCDiaSiguientehoyTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreTransfDiaSiguientehoyTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreBiopagoDiaSiguientehoyTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;


                /**********************************/
                                

                /**************************/

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
                
                Microsoft.Reporting.WinForms.ReportParameter frm4 = new Microsoft.Reporting.WinForms.ReportParameter("FechaPrimeraTabulacionD", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacionD);
                this.reportViewer1.LocalReport.SetParameters(frm4);
                Microsoft.Reporting.WinForms.ReportParameter frm5 = new Microsoft.Reporting.WinForms.ReportParameter("FechaUltimaTabulacionD", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacionD);
                this.reportViewer1.LocalReport.SetParameters(frm5);
                Microsoft.Reporting.WinForms.ReportParameter frm6 = new Microsoft.Reporting.WinForms.ReportParameter("FechaPrimeraTabulacionN", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacionN);
                this.reportViewer1.LocalReport.SetParameters(frm6);
                Microsoft.Reporting.WinForms.ReportParameter frm7 = new Microsoft.Reporting.WinForms.ReportParameter("FechaUltimaTabulacionN", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacionN);
                this.reportViewer1.LocalReport.SetParameters(frm7);
                Microsoft.Reporting.WinForms.ReportParameter frm8 = new Microsoft.Reporting.WinForms.ReportParameter("FechaPrimerTurno", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno);
                this.reportViewer1.LocalReport.SetParameters(frm8);
                Microsoft.Reporting.WinForms.ReportParameter frm9 = new Microsoft.Reporting.WinForms.ReportParameter("FechaUltimoTurno", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoTurno);
                this.reportViewer1.LocalReport.SetParameters(frm9);
                Microsoft.Reporting.WinForms.ReportParameter frm10 = new Microsoft.Reporting.WinForms.ReportParameter("FechaPrimerAvance", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerAvance);
                this.reportViewer1.LocalReport.SetParameters(frm10);
                Microsoft.Reporting.WinForms.ReportParameter frm11 = new Microsoft.Reporting.WinForms.ReportParameter("FechaUltimoAvance", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance);
                this.reportViewer1.LocalReport.SetParameters(frm11);
                Microsoft.Reporting.WinForms.ReportParameter frm12 = new Microsoft.Reporting.WinForms.ReportParameter("FechaPivoteM", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPivoteM);
                this.reportViewer1.LocalReport.SetParameters(frm12);
                Microsoft.Reporting.WinForms.ReportParameter frm13 = new Microsoft.Reporting.WinForms.ReportParameter("FechaPivoteD", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPivoteD);
                this.reportViewer1.LocalReport.SetParameters(frm13);
                Microsoft.Reporting.WinForms.ReportParameter frm14 = new Microsoft.Reporting.WinForms.ReportParameter("FechaPivoteN", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPivoteN);
                this.reportViewer1.LocalReport.SetParameters(frm14);
                Microsoft.Reporting.WinForms.ReportParameter frm15 = new Microsoft.Reporting.WinForms.ReportParameter("FechaDiaAnterior", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaDiaAnterior);
                this.reportViewer1.LocalReport.SetParameters(frm15);
                Microsoft.Reporting.WinForms.ReportParameter frm16 = new Microsoft.Reporting.WinForms.ReportParameter("FechaDiaSiguiente", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaDiaSiguiente);
                this.reportViewer1.LocalReport.SetParameters(frm16);

                //para el reporte completo
                //this.cierreTurnoFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreTurnoFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerAvance), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierreTurnoFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreTurnoFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoTurno));
                this.cierreEfectivoFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreEfectivoFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacionN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierrePDVFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierrePDVFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacionN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierrePINCFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierrePINCFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacionN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierreTransfFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreTransfFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacionN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierreBiopagoFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreBiopagoFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimeraTabulacionN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierreBuzonFiltroTableAdapter.Fill(this.sAPDataSetLocal.CierreBuzonFiltro, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimoAvance), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaInicio), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.tarjetaExpressReporte1TableAdapter.Fill(this.tarjetaExpressDataSet.TarjetaExpressReporte1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Inicio.sede);

                //para el dia anterior
                this.cierreEfectivoDiaAnteriorTableAdapter.Fill(this.sAPDataSetLocal.CierreEfectivoDiaAnterior, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA));
                this.cierrePDVDiaAnteriorTableAdapter.Fill(this.sAPDataSetLocal.CierrePDVDiaAnterior, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA));
                this.cierrePINCDiaAnteriorTableAdapter.Fill(this.sAPDataSetLocal.CierrePINCDiaAnterior, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA));
                this.cierreTransfDiaAnteriorTableAdapter.Fill(this.sAPDataSetLocal.CierreTransfDiaAnterior, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA));
                this.cierreBiopagoDiaAnteriorTableAdapter.Fill(this.sAPDataSetLocal.CierreBiopagoDiaAnterior, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPrimerTurno), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA));

                //para el dia siguiente
                this.cierreEfectivoDiaSiguienteTableAdapter.Fill(this.sAPDataSetLocal.CierreEfectivoDiaSiguiente, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPivoteN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA));
                this.cierrePDVDiaSiguienteTableAdapter.Fill(this.sAPDataSetLocal.CierrePDVDiaSiguiente, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPivoteN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA));
                this.cierrePINCDiaSiguienteTableAdapter.Fill(this.sAPDataSetLocal.CierrePINCDiaSiguiente, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPivoteN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA));
                this.cierreTransfDiaSiguienteTableAdapter.Fill(this.sAPDataSetLocal.CierreTransfDiaSiguiente, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPivoteN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA));
                this.cierreBiopagoDiaSiguienteTableAdapter.Fill(this.sAPDataSetLocal.CierreBiopagoDiaSiguiente, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaPivoteN), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoA));

                //para el dia siguiente HOY
                this.cierreEfectivoDiaSiguientehoyTableAdapter.Fill(this.sAPDataSetLocal.CierreEfectivoDiaSiguientehoy, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacionN), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierrePDVDiaSiguientehoyTableAdapter.Fill(this.sAPDataSetLocal.CierrePDVDiaSiguientehoy, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacionN), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierrePINCDiaSiguientehoyTableAdapter.Fill(this.sAPDataSetLocal.CierrePINCDiaSiguientehoy, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacionN), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierreTransfDiaSiguientehoyTableAdapter.Fill(this.sAPDataSetLocal.CierreTransfDiaSiguientehoy, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacionN), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));
                this.cierreBiopagoDiaSiguientehoyTableAdapter.Fill(this.sAPDataSetLocal.CierreBiopagoDiaSiguientehoy, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaUltimaTabulacionN), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turnoB));

                // Limpiamos cualquier basura anterior
                this.reportViewer1.LocalReport.DataSources.Clear();

                //para el reporte completo
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTurno", (System.Data.DataTable)this.sAPDataSetLocal.CierreTurnoFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePDV", (System.Data.DataTable)this.sAPDataSetLocal.CierrePDVFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreEfectivo", (System.Data.DataTable)this.sAPDataSetLocal.CierreEfectivoFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePINC", (System.Data.DataTable)this.sAPDataSetLocal.CierrePINCFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTransf", (System.Data.DataTable)this.sAPDataSetLocal.CierreTransfFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBuzon", (System.Data.DataTable)this.sAPDataSetLocal.CierreBuzonFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBiopago", (System.Data.DataTable)this.sAPDataSetLocal.CierreBiopagoFiltro));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TarjetaExpress", (System.Data.DataTable)this.tarjetaExpressDataSet.TarjetaExpressReporte1));

                //para el dia anterior
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePDVDiaAnterior", (System.Data.DataTable)this.sAPDataSetLocal.CierrePDVDiaAnterior));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreEfectivoDiaAnterior", (System.Data.DataTable)this.sAPDataSetLocal.CierreEfectivoDiaAnterior));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePINCDiaAnterior", (System.Data.DataTable)this.sAPDataSetLocal.CierrePINCDiaAnterior));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTransfDiaAnterior", (System.Data.DataTable)this.sAPDataSetLocal.CierreTransfDiaAnterior));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBiopagoDiaAnterior", (System.Data.DataTable)this.sAPDataSetLocal.CierreBiopagoDiaAnterior));

                //para el dia siguiente
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePDVDiaSiguiente", (System.Data.DataTable)this.sAPDataSetLocal.CierrePDVDiaSiguiente));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreEfectivoDiaSiguiente", (System.Data.DataTable)this.sAPDataSetLocal.CierreEfectivoDiaSiguiente));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePINCDiaSiguiente", (System.Data.DataTable)this.sAPDataSetLocal.CierrePINCDiaSiguiente));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTransfDiaSiguiente", (System.Data.DataTable)this.sAPDataSetLocal.CierreTransfDiaSiguiente));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBiopagoDiaSiguiente", (System.Data.DataTable)this.sAPDataSetLocal.CierreBiopagoDiaSiguiente));

                //para el dia siguiente HOY
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePDVDiaSiguientehoy", (System.Data.DataTable)this.sAPDataSetLocal.CierrePDVDiaSiguientehoy));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreEfectivoDiaSiguientehoy", (System.Data.DataTable)this.sAPDataSetLocal.CierreEfectivoDiaSiguientehoy));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePINCDiaSiguientehoy", (System.Data.DataTable)this.sAPDataSetLocal.CierrePINCDiaSiguientehoy));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTransfDiaSiguientehoy", (System.Data.DataTable)this.sAPDataSetLocal.CierreTransfDiaSiguientehoy));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBiopagoDiaSiguientehoy", (System.Data.DataTable)this.sAPDataSetLocal.CierreBiopagoDiaSiguientehoy));

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

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

    }
}
