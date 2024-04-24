using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SAP.Properties;

namespace SAP.Recaudadores.Controles
{
    public partial class OperacionesDiarias : Form
    {
        public static string monto;
        public static string referencia;
        public static string forma;
        public static string id;
        public static string dniuser;
        public OperacionesDiarias()
        {
            InitializeComponent();
        }
        private async Task Sedes()
        {
            string sql = "SELECT Nombre FROM Peaje ORDER BY ID_Peaje ASC;";
            using (SqlConnection cn = new SqlConnection((string)Settings.Default["Sede1"]))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    if (dr["Nombre"].ToString() != "")
                    {
                        Sede.Items.Add(dr["Nombre"].ToString().ToUpper());
                    }
                }
                cn.Close();
                return;
            }
        }
        public void ActualizarGrid1(DateTime fecha, DateTime fecha1, int sede)
        {
            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT   Ventas.ID_Venta, Cliente.Nombre, Cliente.CI, Ventas.FormaPago, Ventas.Monto, Ventas.Referencia, Ventas.ID_Usuario, Ventas.Fecha FROM Ventas INNER JOIN Sede ON Ventas.Sede = Sede.ID_Sede INNER JOIN Cliente ON Ventas.ID_Cliente = Cliente.ID_Cliente WHERE (Fecha BETWEEN CONVERT(DATETIME, @fecha+' 00:00:00', 102) AND CONVERT(DATETIME, @fecha1+' 23:59:59', 102)) AND (Ventas.Sede = @sede) AND (Ventas.FormaPago<>'A.PDV') AND (Ventas.FormaPago<>'A.Transferencia') AND (Ventas.FormaPago<>'Tarjeta PDV') AND (Ventas.FormaPago<>'Tarjeta Transf') AND (Ventas.FormaPago<>'A.OP') AND (Ventas.FormaPago<>'A.Efectivo') ORDER BY Ventas.Fecha", cn);
            cmd.Parameters.AddWithValue("fecha", fecha);
            cmd.Parameters.AddWithValue("fecha1", fecha1);
            cmd.Parameters.AddWithValue("sede", sede);
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                Usuario.Rows.Add(dr["ID_Venta"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["FormaPago"].ToString(), dr["Referencia"].ToString(), dr["ID_Usuario"].ToString(), dr["Fecha"].ToString(), "Editar", "Anular");
            }
            dr.Close();
            cn.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sede.SelectedIndex != -1)
                {
                    int val = Sede.SelectedIndex + 1;
                    this.ActualizarGrid1(date1.Value.Date, date2.Value.Date, Convert.ToInt32(val));

                }
                else
                {
                    MessageBox.Show("Por favor seleccione la sede a consultar", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Error al generar la consulta, reintente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "editar" && e.RowIndex >= 0)
            {
                DataGridViewRow row = Usuario.Rows[e.RowIndex];
                id = Convert.ToString(row.Cells[0].Value);
                dniuser = Convert.ToString(row.Cells[2].Value);
                monto = Convert.ToString(row.Cells[3].Value);
                referencia = Convert.ToString(row.Cells[5].Value);
                forma = Convert.ToString(row.Cells[4].Value);
                SAP.Recaudadores.Controles.EditarOperacion frm = new SAP.Recaudadores.Controles.EditarOperacion();
                frm.ShowDialog();
            }
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "Devolucion" && e.RowIndex >= 0)
            {
                DataGridViewRow row = Usuario.Rows[e.RowIndex];
                id = Convert.ToString(row.Cells[0].Value);
                dniuser = Convert.ToString(row.Cells[2].Value);
                monto = Convert.ToString(row.Cells[3].Value);
                referencia = Convert.ToString(row.Cells[5].Value);
                forma = Convert.ToString(row.Cells[4].Value);
                SAP.Recaudadores.Controles.AnularOperacion frm = new SAP.Recaudadores.Controles.AnularOperacion();
                frm.ShowDialog();

            }
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "DNI" && e.RowIndex >= 0)
            {
                DataGridViewRow row = Usuario.Rows[e.RowIndex];
                SAP.Recaudadores.Controles.Buscador.DNI = Convert.ToString(row.Cells[2].Value);
                SAP.Recaudadores.Controles.Consulta frm = new SAP.Recaudadores.Controles.Consulta();
                frm.ShowDialog();
            }
            int val = Sede.SelectedIndex + 1;
            this.ActualizarGrid1(date1.Value.Date, date2.Value.Date, Convert.ToInt32(val));
            }

        private async void OperacionesDiarias_Load(object sender, EventArgs e)
        {
            await this.Sedes();
            this.ActualizarGrid1(date1.Value.Date, date2.Value.Date, Convert.ToInt32(SAP.Inicio.sede));
        }
    }
}
