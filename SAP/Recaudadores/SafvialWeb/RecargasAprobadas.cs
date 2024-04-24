using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.SafvialWeb
{
    public partial class RecargasAprobadas : Form
    {
        public static int id;
        public static string nombre;
        public static string dni;
        public static string monto;
        public static string banco;
        public static string referencia;
        public static string fecha;
        public static string observacio;
        public static string adjunto;
        public static string dates1;
        public static string dates2;
        public RecargasAprobadas()
        {
            InitializeComponent();
            this.ActualizarGrid1(date1.Value.ToShortDateString(), date2.Value.ToShortDateString());
        }
        public void ActualizarGrid1(string fecha, string fecha1)
        {
            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT RecargasWEB.ID_Operacion,Cliente.Nombre,Cliente.CI,RecargasWEB.Monto,RecargasWEB.Banco,RecargasWEB.Referencia,RecargasWEB.Condicion,RecargasWEB.FechaSubida,RecargasWEB.Observacion,RecargasWEB.DNI,RecargasWEB.NombreReal,RecargasWEB.FechaEmision FROM RecargasWEB INNER JOIN Cliente ON RecargasWEB.DNI = Cliente.ID_Cliente WHERE RecargasWEB.Condicion = 'Recargada' AND RecargasWEB.FechaSubida BETWEEN @fecha + ' 00:00:00' and @fecha1 + ' 23:59:59' Order by RecargasWEB.Fecha ASC", cn);
            cmd.Parameters.AddWithValue("fecha", fecha);
            cmd.Parameters.AddWithValue("fecha1", fecha1);
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), dr["Referencia"].ToString(), dr["Condicion"].ToString(), dr["FechaSubida"].ToString(), dr["FechaEmision"].ToString(), "Ver Operacion", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
            }
            dr.Close();
            cn.Dispose();
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

        private void Usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "Aprobar" && e.RowIndex >= 0)
            {
                adjunto = "";
                DataGridViewRow row = Usuario.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells[0].Value);
                nombre = Convert.ToString(row.Cells[1].Value);
                dni = Convert.ToString(row.Cells[10].Value);
                monto = Convert.ToString(row.Cells[3].Value);
                banco = Convert.ToString(row.Cells[4].Value);
                referencia = Convert.ToString(row.Cells[5].Value);
                fecha = Convert.ToString(row.Cells[7].Value);
                observacio = Convert.ToString(row.Cells[10].Value);
                adjunto = Convert.ToString(row.Cells[12].Value);
                SAP.Recaudadores.SafvialWeb.VerOperacion frm = new SAP.Recaudadores.SafvialWeb.VerOperacion();
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dates1 = date1.Value.ToShortDateString();
            dates2 = date2.Value.ToShortDateString();
            SAP.Recaudadores.SafvialWeb.ReporteAprobadasV2 frm = new SAP.Recaudadores.SafvialWeb.ReporteAprobadasV2();
            frm.ShowDialog();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
