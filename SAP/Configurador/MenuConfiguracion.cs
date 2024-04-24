using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Configurador
{
    public partial class MenuConfiguracion : Form
    {
        public MenuConfiguracion()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SAP.Configurador.Configurador frm = new SAP.Configurador.Configurador();
            frm.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAP.Configurador.Interfaz frm = new SAP.Configurador.Interfaz();
            frm.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SAP.Configurador.Contraseñas frm = new SAP.Configurador.Contraseñas();
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SAP.Configurador.ClaveSupervisores frm = new SAP.Configurador.ClaveSupervisores();
            frm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
