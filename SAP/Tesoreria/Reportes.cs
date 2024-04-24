using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using SAP.Properties;

namespace SAP.Tesoreria
{
    public partial class Reportes : Form
    {
        Boolean Validor;
        public static String Peaje;
        public static int sede;
        public Reportes()
        {
            InitializeComponent();
            ConsultaCOA();
            button1.Text = "REPORTE PEAJE "+SAP.Inicio.PeajeNombre.ToUpper();
            button5.Text = "FLUJO VEHICULAR PEAJE DE " + SAP.Inicio.PeajeNombre.ToUpper();
            button8.Text = "REPORTE DE REMESAS PEAJE " + SAP.Inicio.PeajeNombre.ToUpper();
            button12.Text = "TARJETAS EXPRESS " + SAP.Inicio.PeajeNombre.ToUpper();
        }
        private void ConsultaCOA()
        {
            string sql = "SELECT Conexion from COA WHERE ID = 1";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Validor = Convert.ToBoolean(dr["Conexion"]);
                }
                dr.Close();
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.guacara;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            Peaje = SAP.Inicio.PeajeNombre.ToUpper();
            sede = SAP.Inicio.sede;
            SAP.Recaudadores.Controles.ReporteDiaro frm = new SAP.Recaudadores.Controles.ReporteDiaro();
            frm.ShowDialog();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = (string)Settings.Default["SAP"];
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            SAP.Tesoreria.Controles.ListaDeclaraciones frm = new SAP.Tesoreria.Controles.ListaDeclaraciones();
            frm.ShowDialog();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.guacara;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            Peaje = SAP.Inicio.PeajeNombre.ToUpper();
            sede = SAP.Inicio.sede;
            SAP.Tesoreria.Controles.FlujoVehicularV2 frm = new SAP.Tesoreria.Controles.FlujoVehicularV2();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.RecaudacionPeajes frm = new SAP.Tesoreria.Controles.RecaudacionPeajes();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
                Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.guacara;
                config1.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.guacara;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            Peaje = SAP.Inicio.PeajeNombre.ToUpper();
            sede = SAP.Inicio.sede;
            SAP.Tesoreria.Controles.RecaudacionTipoPago frm = new SAP.Tesoreria.Controles.RecaudacionTipoPago();
            frm.ShowDialog();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.guacara;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            Peaje = SAP.Inicio.PeajeNombre.ToUpper();
            sede = SAP.Inicio.sede;
            SAP.Tesoreria.RemesasTipos frm = new SAP.Tesoreria.RemesasTipos();
            frm.ShowDialog();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.entrada;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            Peaje = "DE LA ENTRADA";
            sede = 2;
            SAP.Tesoreria.Controles.FlujoVehicularV2 frm = new SAP.Tesoreria.Controles.FlujoVehicularV2();
            frm.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.entrada;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            Peaje = "DE LA ENTRADA";
            sede = 2;
            SAP.Tesoreria.Controles.RecaudacionTipoPago frm = new SAP.Tesoreria.Controles.RecaudacionTipoPago();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.entrada;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            Peaje = "DE LA ENTRADA";
            sede = 2;
            SAP.Tesoreria.RemesasTipos frm = new SAP.Tesoreria.RemesasTipos();
            frm.ShowDialog();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.entrada;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            SAP.Tesoreria.Controles.ListaDeclaraciones frm = new SAP.Tesoreria.Controles.ListaDeclaraciones();
            frm.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.conexion;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            SAP.Recaudadores.Controles.Reporte.sede = SAP.Inicio.sede;
            SAP.Recaudadores.Controles.Reportes.ReporteTarjetaExpress frm = new SAP.Recaudadores.Controles.Reportes.ReporteTarjetaExpress();
            frm.ShowDialog();

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Configuration config2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config2.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.entrada;
            config2.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            SAP.Recaudadores.Controles.Reporte.sede = 2;
            SAP.Recaudadores.Controles.Reportes.ReporteTarjetaExpress frm = new SAP.Recaudadores.Controles.Reportes.ReporteTarjetaExpress();
            frm.ShowDialog();

            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.conexion;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            SAP.Tesoreria.Controles.Auditoria.ListaDeclaracionesV1 frm = new SAP.Tesoreria.Controles.Auditoria.ListaDeclaracionesV1();
            frm.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.guacara;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            SAP.Tesoreria.Controles.ReportePeajes.RecaudacionPeajesMensual frm = new SAP.Tesoreria.Controles.ReportePeajes.RecaudacionPeajesMensual();
            frm.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.guacara;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            SAP.Recaudadores.Controles.Reporte.sede = SAP.Inicio.sede;
            SAP.Tesoreria.Controles.RecaudacionFlujoVolumen frm = new SAP.Tesoreria.Controles.RecaudacionFlujoVolumen();
            frm.ShowDialog();
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            Configuration config2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config2.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.entrada;
            config2.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            SAP.Recaudadores.Controles.Reporte.sede = 2;
            SAP.Tesoreria.Controles.RecaudacionFlujoVolumen frm = new SAP.Tesoreria.Controles.RecaudacionFlujoVolumen();
            frm.ShowDialog();
        }
    }
}