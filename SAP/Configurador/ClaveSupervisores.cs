using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Configurador
{
    public partial class ClaveSupervisores : Form
    {
        public static string IDE = "";
        public static string Codigo = "";
        public static string Nombre = "";
        public ClaveSupervisores()
        {
            InitializeComponent();
            this.ActualizarGrid1();
        }
        public void ActualizarGrid1()
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT ID,Autorizado,Nombre FROM Supervisor", cn);
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                Usuario.Rows.Add(dr["ID"].ToString(), dr["Autorizado"].ToString(), dr["Nombre"].ToString(), "Editar","Eliminar");
            }
            dr.Close();
        }

        private void Usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Usuario.Rows[e.RowIndex];
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "Editar" && e.RowIndex >= 0)
            {
               
                IDE = Convert.ToString(row.Cells[0].Value);
                Codigo = Convert.ToString(row.Cells[1].Value);
                Nombre = Convert.ToString(row.Cells[2].Value);
                SAP.Configurador.TarjetasSupervisores.EditarTarjeta frm = new SAP.Configurador.TarjetasSupervisores.EditarTarjeta();
                frm.ShowDialog();
                this.ActualizarGrid1();
            }
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "eliminar" && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("¿Seguro, que desea eliminar la contraseña seleccionada?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        EliminarTarjeta(Convert.ToInt32(row.Cells[0].Value));
                        this.ActualizarGrid1();
                    }
                    catch
                    {
                        MessageBox.Show("ocurrio un error al cargar la informacion.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAP.Configurador.TarjetasSupervisores.AgregarTarjeta frm = new SAP.Configurador.TarjetasSupervisores.AgregarTarjeta();
            frm.ShowDialog();
            this.ActualizarGrid1();
        }
        private void EliminarTarjeta(int id)
        {
            string sql = "Delete From Supervisor Where ID=@id";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteReader();
                return;
            }
        }
    }
}
