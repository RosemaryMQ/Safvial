using System;
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
            /*
            try
            {
                string cadena = "Data Source=safvialcentercorp.ddns.net;Initial Catalog=SAP;User ID=sap;Password=sap1234;";
                using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(cadena))
                {
                    con.Open();
                    MessageBox.Show("¡Conexión Exitosa! El problema es el TableAdapter.");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo en conexión cruda: " + ex.Message);
            }
            */

            try
            {
                /*
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.DataSource = "safvialcentercorp.ddns.net"; // Ojo: Si es local usa "localhost" o ".\SQLEXPRESS"
                builder.InitialCatalog = "SAP";
                builder.UserID = "sap";
                builder.Password = "sap1234";
                builder.IntegratedSecurity = false;
                builder.PersistSecurityInfo = true;
                */

                this.cierreTurnoV1TableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreTurnoV1TableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreEfectivoTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierrePDVTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierrePINCTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreBiopagoTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.cierreTransfTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                this.buzonTurnoTableAdapter.Connection.ConnectionString = SAP.Inicio.conexion;
                //this.tarjetaExpressReporte1TableAdapter.Connection.ConnectionString = builder.ConnectionString;


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
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString("G"));
                this.reportViewer1.LocalReport.SetParameters(frm1);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS);
                this.reportViewer1.LocalReport.SetParameters(frm3);

               
                this.cierreTurnoV1TableAdapter.Fill(this.sAPDataSetLocal.CierreTurnoV1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.cierreEfectivoTableAdapter.Fill(this.sAPDataSetLocal.CierreEfectivo, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.cierrePDVTableAdapter.Fill(this.sAPDataSetLocal.CierrePDV, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.cierrePINCTableAdapter.Fill(this.sAPDataSetLocal.CierrePINC, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.cierreTransfTableAdapter.Fill(this.sAPDataSetLocal.CierreTransf, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.cierreBiopagoTableAdapter.Fill(this.sAPDataSetLocal.CierreBiopago, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.buzonTurnoTableAdapter.Fill(this.sAPDataSetLocal.BuzonTurno, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS));
                this.tarjetaExpressReporte1TableAdapter.Fill(this.tarjetaExpressDataSet.TarjetaExpressReporte1, Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS1), Convert.ToDateTime(SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre.fechaS), SAP.Inicio.sede);

                // Limpiamos cualquier basura anterior
                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTurno", (System.Data.DataTable)this.sAPDataSetLocal.CierreTurnoV1));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePDV", (System.Data.DataTable)this.sAPDataSetLocal.CierrePDV));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreEfectivo", (System.Data.DataTable)this.sAPDataSetLocal.CierreEfectivo));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierrePINC", (System.Data.DataTable)this.sAPDataSetLocal.CierrePINC));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreTransf", (System.Data.DataTable)this.sAPDataSetLocal.CierreTransf));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBuzon", (System.Data.DataTable)this.sAPDataSetLocal.BuzonTurno));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CierreBiopago", (System.Data.DataTable)this.sAPDataSetLocal.CierreBiopago));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TarjetaExpress", (System.Data.DataTable)this.tarjetaExpressDataSet.TarjetaExpressReporte1));



                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Error detallado: " + ex.Message);
                //this.Close();
                throw;
            }


            //this.reportViewer1.RefreshReport();
        }


    }
}
