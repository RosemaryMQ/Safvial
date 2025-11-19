using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Cobradores.Controles.Reporte
{
    public partial class AvanceCabina : Form
    {
        public AvanceCabina()
        {
            InitializeComponent();
        }

        private void AvanceCabina_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
