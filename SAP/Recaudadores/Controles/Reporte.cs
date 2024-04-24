using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAP.Recaudadores.Controles
{
    public partial class Reporte : Form
    {
        public static int sede = 0;
        public Reporte()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.conexion;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            SAP.Recaudadores.Controles.ReporteDiaro frm = new SAP.Recaudadores.Controles.ReporteDiaro();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (SAP.Inicio.sede == 1)
            {
                Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.guacara;
                config1.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                Properties.Settings.Default.Reload();
                this.Close();
            }
            else
            {
                Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.entrada;
                config1.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                Properties.Settings.Default.Reload();
                this.Close();
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

                Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.conexion;
                config1.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                Properties.Settings.Default.Reload();
                SAP.Recaudadores.Controles.ReporteSaldosN frm = new SAP.Recaudadores.Controles.ReporteSaldosN();
                frm.ShowDialog();     
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.guacara;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            sede = 1;
            SAP.Recaudadores.Controles.Reportes.ReporteTarjetaExpress frm = new SAP.Recaudadores.Controles.Reportes.ReporteTarjetaExpress();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.conexion;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            SAP.Recaudadores.Controles.Operaciones frm = new SAP.Recaudadores.Controles.Operaciones();
            frm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Configuration config2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config2.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.conexion;
            config2.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            sede = SAP.Inicio.sede;
            SAP.Recaudadores.Controles.Reportes.ReporteTarjetaExpress frm = new SAP.Recaudadores.Controles.Reportes.ReporteTarjetaExpress();
            frm.ShowDialog();
        }
    }
}
