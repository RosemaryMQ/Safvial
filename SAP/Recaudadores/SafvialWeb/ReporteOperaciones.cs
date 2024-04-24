using System;
using System.Windows.Forms;

namespace SAP.Recaudadores.SafvialWeb
{
    public partial class ReporteOperaciones : Form
    {
        public ReporteOperaciones()
        {
            InitializeComponent();
        }

        private void ReporteOperaciones_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'safvialWeb.Pendientes' Puede moverla o quitarla según sea necesario.
                this.pendientes2TableAdapter.Fill(this.safvialWeb.Pendientes2);
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte "+ex, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
    }
}
