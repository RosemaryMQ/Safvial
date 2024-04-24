using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAP.Recaudadores.SafvialWeb
{
    public partial class MenuWeb : Form
    {
        public MenuWeb()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.SafvialWeb.Transferencias frm = new SAP.Recaudadores.SafvialWeb.Transferencias();
            frm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.SafvialWeb.RecargasAprobadas frm = new SAP.Recaudadores.SafvialWeb.RecargasAprobadas();
            frm.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.SafvialWeb.RecargasAnuladas frm = new SAP.Recaudadores.SafvialWeb.RecargasAnuladas();
            frm.ShowDialog();
            this.Close();
        }
    }
}
