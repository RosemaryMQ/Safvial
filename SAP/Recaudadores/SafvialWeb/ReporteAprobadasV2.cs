using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Recaudadores.SafvialWeb
{
    public partial class ReporteAprobadasV2 : Form
    {
        public ReporteAprobadasV2()
        {
            InitializeComponent();
        }


        private void ReporteAprobadasV2_Load(object sender, EventArgs e)
        {
            try
            {
                this.solicitudesWEB2TableAdapter.Fill(this.safvialWeb.SolicitudesWEB2, Convert.ToDateTime(RecargasAprobadas.dates1), Convert.ToDateTime(RecargasAprobadas.dates2));
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte"+ex.ToString(), "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
