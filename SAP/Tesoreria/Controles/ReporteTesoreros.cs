using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Tesoreria.Controles
{
    public partial class ReporteTesoreros : Form
    {
        public ReporteTesoreros()
        {
            InitializeComponent();
        }

        private void ReporteTesoreros_Load(object sender, EventArgs e)
        {
            this.reporteUserTableAdapter.Fill(this.sAPDataSet2.ReporteUser, "Administrador");
            this.reportViewer1.RefreshReport();
        }
    }
}
