using System;
using System.Windows.Forms;
using SAP.Properties;
using System.Configuration;

namespace SAP.Configurador
{
    public partial class Configurador : Form
    {
        public Configurador()
        {
            InitializeComponent();
            ip1.Text=(string)Settings.Default["IP1"];
            ip2.Text = (string)Settings.Default["IP2"];
            ip3.Text = (string)Settings.Default["IP3"];
            ip4.Text = (string)Settings.Default["IP4"];
            ip5.Text = (string)Settings.Default["IP5"];
            dbo1.SelectedItem = (string)Settings.Default["dbo1"];
            dbo2.SelectedItem = (string)Settings.Default["dbo2"];
            dbo3.SelectedItem = (string)Settings.Default["dbo3"];
            dbo4.SelectedItem = (string)Settings.Default["dbo4"];
            dbo5.SelectedItem = (string)Settings.Default["dbo5"];
            user1.Text = (string)Settings.Default["User1"];
            user2.Text = (string)Settings.Default["User2"];
            user3.Text = (string)Settings.Default["User3"];
            user4.Text = (string)Settings.Default["User4"];
            user5.Text = (string)Settings.Default["User5"];
            pass1.Text = (string)Settings.Default["Pass1"];
            pass2.Text = (string)Settings.Default["Pass2"];
            pass3.Text = (string)Settings.Default["Pass3"];
            pass4.Text = (string)Settings.Default["Pass4"];
            pass5.Text = (string)Settings.Default["Pass5"];
            sede.Text = Convert.ToString((int)Settings.Default["Sede"]);
            Arduino.Text = (string)Settings.Default["Arduino"];
            Logo.Text = (string)Settings.Default["Logo"];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Settings.Default["IP1"] = ip1.Text;
            Settings.Default["IP2"] = ip2.Text;
            Settings.Default["IP3"] = ip3.Text;
            Settings.Default["IP4"] = ip4.Text;
            Settings.Default["IP5"] = ip5.Text;
            Settings.Default["dbo1"] = dbo1.Text;
            Settings.Default["dbo2"] = dbo2.Text;
            Settings.Default["dbo3"] = dbo3.Text;
            Settings.Default["dbo4"] = dbo4.Text;
            Settings.Default["dbo5"] = dbo5.Text;
            Settings.Default["User1"] = user1.Text;
            Settings.Default["User2"] = user2.Text;
            Settings.Default["User3"] = user3.Text;
            Settings.Default["User4"] = user4.Text;
            Settings.Default["User5"] = user5.Text;
            Settings.Default["Pass1"] = pass1.Text;
            Settings.Default["Pass2"] = pass2.Text;
            Settings.Default["Pass3"] = pass3.Text;
            Settings.Default["Pass4"] = pass4.Text;
            Settings.Default["Pass5"] = pass5.Text;
            Settings.Default["Arduino"] = Arduino.Text;
            Settings.Default["Logo"] = Logo.Text;
            Settings.Default["Sede"] = Convert.ToInt32(sede.Text);
            Settings.Default.Save();
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = "Data Source =" + ip1.Text + "; Initial Catalog = " + dbo1.Text + "; User ID =" + user1.Text + "; Persist Security Info=True; Password =" + pass1.Text + ";Connect Timeout=15;";
            config.Save(ConfigurationSaveMode.Modified);
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.Prepagado"].ConnectionString = "Data Source =" + ip2.Text + "; Initial Catalog = " + dbo2.Text + "; User ID =" + user2.Text + ";  Persist Security Info=True; Password =" + pass2.Text + ";Connect Timeout=15;";
            config1.Save(ConfigurationSaveMode.Modified);
            Configuration config2 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config2.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SafvialWeb"].ConnectionString = "Data Source =" + ip3.Text + "; Initial Catalog = " + dbo3.Text + "; User ID =" + user3.Text + ";  Persist Security Info=True; Password =" + pass3.Text + ";Connect Timeout=15";
            config2.Save(ConfigurationSaveMode.Modified);
            //Configuration config9 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            //config9.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SafvialWebEntities"].ConnectionString = "metadata=res://*/Recaudadores.SafvialWeb.Model.DbWeb.csdl|res://*/Recaudadores.SafvialWeb.Model.DbWeb.ssdl|res://*/Recaudadores.SafvialWeb.Model.DbWeb.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source =" + ip3.Text + "; Initial Catalog = " + dbo3.Text + "; Persist Security Info=True; User ID =" + user3.Text + ";  Password =" + pass3.Text + ";MultipleActiveResultSets=True;App=EntityFramework&quot;";
            //config9.Save(ConfigurationSaveMode.Modified);
            Configuration config3 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config3.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP2"].ConnectionString = "Data Source =" + ip4.Text + "; Initial Catalog = " + dbo4.Text + "; User ID =" + user4.Text + ";  Persist Security Info=True; Password =" + pass4.Text + ";Connect Timeout=15;";
            config3.Save(ConfigurationSaveMode.Modified);
            Configuration config4 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config4.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.Sede1"].ConnectionString = "Data Source =" + ip5.Text + "; Initial Catalog = " + dbo5.Text + "; User ID =" + user5.Text + ";  Persist Security Info=True; Password =" + pass5.Text + ";Connect Timeout=15;";
            config4.Save(ConfigurationSaveMode.Modified);
            Configuration config5 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config5.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP2P"].ConnectionString = "Data Source =" + ip4.Text + "; Initial Catalog = SafvialPrepago; User ID =" + user4.Text + ";  Persist Security Info=True; Password =" + pass4.Text + ";Connect Timeout=15;";
            config5.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Configuration config6 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config6.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.ConexionPSC"].ConnectionString = "Data Source =" + ip1.Text + "; Initial Catalog = SafvialPrepago; User ID =" + user1.Text + ";  Persist Security Info=True; Password =" + pass1.Text + ";Connect Timeout=15;";
            config6.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Reload();
            MessageBox.Show("La aplicacion se cerrara para aplicar los cambios, inicie nuevamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void dbo1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ip1.Text = "safvialcentercorp.ddns.net";
            ip2.Text = "safvialcentercorp.ddns.net";
            ip3.Text = "safvialcentercorp.ddns.net";
            ip4.Text = "safvialcenter2.ddns.net";
            ip5.Text = "safvialcentercorp.ddns.net";
            sede.Text = "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ip1.Text = "192.168.0.110";
            ip2.Text = "192.168.0.110";
            ip3.Text = "192.168.0.110";
            ip4.Text = "safvialcenter2.ddns.net";
            ip5.Text = "192.168.0.110";
            sede.Text = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ip1.Text = "192.168.6.100";
            ip2.Text = "safvialcentercorp.ddns.net";
            ip3.Text = "safvialcentercorp.ddns.net";
            ip4.Text = "192.168.6.100";
            ip5.Text = "safvialcentercorp.ddns.net";
            sede.Text = "2";
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                Logo.Text = choofdlog.FileName;
            }
        }
    }
}
