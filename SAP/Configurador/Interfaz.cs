using System;
using System.Windows.Forms;
using SAP.Properties;
using System.Configuration;

namespace SAP.Configurador
{
    public partial class Interfaz : Form
    {
        public Interfaz()
        {
            InitializeComponent();
            modalidad.SelectedItem = (string)Settings.Default["Tipo"];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modalidad.Text =="Recaudador")
            {
                Canal.Enabled = true;
                Canal.SelectedItem = Convert.ToString((int)Settings.Default["Canal"]);
            }
            else
            {
                Canal.SelectedIndex = -1;
                Canal.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (modalidad.Text == "Recaudador")
            {
               Settings.Default["Tipo"] = modalidad.Text;
               Settings.Default["Canal"]=Convert.ToInt32(Canal.Text);
               Settings.Default.Save();
               ConfigurationManager.RefreshSection("connectionStrings");
               Properties.Settings.Default.Reload();
                MessageBox.Show("Configuracion realizada exitosamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                Settings.Default["Tipo"] = modalidad.Text;
                Settings.Default.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
                Properties.Settings.Default.Reload();
                MessageBox.Show("Configuracion realizada exitosamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
