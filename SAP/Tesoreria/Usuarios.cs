using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria
{
    public partial class Usuarios : Form
    {

        public Usuarios()
        {
            InitializeComponent();
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.AgregarUsuario frm = new SAP.Tesoreria.Controles.AgregarUsuario();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.Lista frm = new SAP.Tesoreria.Controles.Lista();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.ReporteTesoreros frm = new SAP.Tesoreria.Controles.ReporteTesoreros();
            frm.ShowDialog();
        }
    }
}
