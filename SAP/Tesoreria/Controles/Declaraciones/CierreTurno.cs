using System;
using System.Windows.Forms;

namespace SAP.Tesoreria.Controles.Declaraciones
{
    public partial class CierreTurno : Form
    {
        public CierreTurno()
        {
            InitializeComponent();
        }

        private void CierreTurno_Load(object sender, EventArgs e)
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
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString("G"));
                this.reportViewer1.LocalReport.SetParameters(frm1);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS);
                this.reportViewer1.LocalReport.SetParameters(frm3);
                cierreTurnoV1TableAdapter.Fill(this.sAPDataSet2.CierreTurnoV1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno);
                cierreEfectivoTableAdapter.Fill(this.sAPDataSet2.CierreEfectivo, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno);
                cierrePDVTableAdapter.Fill(this.sAPDataSet2.CierrePDV, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno);
                cierrePINCTableAdapter.Fill(this.sAPDataSet2.CierrePINC, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno);
                cierreTransfTableAdapter.Fill(this.sAPDataSet2.CierreTransf, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno);
                buzonTurnoTableAdapter.Fill(this.sAPDataSet2.BuzonTurno, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.turno);
                this.tarjetaExpressReporte1TableAdapter.Fill(this.tarjetaExpressDataSet.TarjetaExpressReporte1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Inicio.sede);
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            

        }
    }
}
