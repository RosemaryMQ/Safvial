using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.SafvialWeb
{
    public partial class RecargasAnuladas : Form
    {
        public static int id;
        public RecargasAnuladas()
        {
            InitializeComponent();
            this.ActualizarGrid1(date1.Value.ToShortDateString(), date2.Value.ToShortDateString());
        }
        public void ActualizarGrid1(string fecha, string fecha1)
        {
            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT RecargasWEB.ID_Operacion,Cliente.Nombre,Cliente.CI,RecargasWEB.Monto,RecargasWEB.Banco,RecargasWEB.Referencia,RecargasWEB.Condicion,RecargasWEB.FechaSubida,RecargasWEB.Observacion,RecargasWEB.DNI,RecargasWEB.NombreReal FROM RecargasWEB INNER JOIN Cliente ON RecargasWEB.DNI = Cliente.ID_Cliente WHERE RecargasWEB.Condicion = 'Anulada' AND RecargasWEB.FechaSubida BETWEEN @fecha + ' 00:00:00' and @fecha1 + ' 23:59:59' Order by RecargasWEB.Fecha ASC", cn);
            cmd.Parameters.AddWithValue("fecha", fecha);
            cmd.Parameters.AddWithValue("fecha1", fecha1);
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), dr["Referencia"].ToString(), dr["Condicion"].ToString(), dr["FechaSubida"].ToString(), "Ver Operacion", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString(), "Reactivar");
            }
            dr.Close();
            cn.Dispose();
        }

        private void Usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "Aprobar" && e.RowIndex >= 0)
            {
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.adjunto = "";
                DataGridViewRow row = Usuario.Rows[e.RowIndex];
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.id = Convert.ToInt32(row.Cells[0].Value);
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.nombre = Convert.ToString(row.Cells[1].Value);
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.dni = Convert.ToString(row.Cells[10].Value);
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.monto = Convert.ToString(row.Cells[3].Value);
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.banco = Convert.ToString(row.Cells[4].Value);
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.referencia = Convert.ToString(row.Cells[5].Value);
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.fecha = Convert.ToString(row.Cells[7].Value);
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.observacio = Convert.ToString(row.Cells[9].Value);
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.adjunto = Convert.ToString(row.Cells[11].Value);
                SAP.Recaudadores.SafvialWeb.VerOperacion frm = new SAP.Recaudadores.SafvialWeb.VerOperacion();
                frm.ShowDialog();
            }
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "Reactivar" && e.RowIndex >= 0)
            {
                id = 0;
                SAP.Recaudadores.SafvialWeb.RecargasAprobadas.adjunto = "";
                DataGridViewRow row = Usuario.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells[0].Value);
                SAP.Inicio.acceso = 18;
                SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
                frm.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActualizarGrid1(date1.Value.ToShortDateString(), date2.Value.ToShortDateString());
            }
            catch
            {
                MessageBox.Show("Error al generar la consulta, reintente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
