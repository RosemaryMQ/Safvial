using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SAP.Properties;

namespace SAP.Configurador
{
    public partial class Contraseñas : Form
    {
        public static string IDClave = "";
        public static string CodigoOperacion = "";
        public Contraseñas()
        {
            InitializeComponent();
            this.ActualizarGrid1();
        }
        public void ActualizarGrid1()
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Operaciones", cn);
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                Usuario.Rows.Add(dr["ID"].ToString(), dr["Password"].ToString(), "Editar","Eliminar");
            }
            dr.Close();
        }

        private void Usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Usuario.Rows[e.RowIndex];
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "Editar" && e.RowIndex >= 0)
            {
              
                IDClave = Convert.ToString(row.Cells[0].Value);
                CodigoOperacion = Convert.ToString(row.Cells[1].Value);
                SAP.Configurador.OperacionesContraseña.EditarContraseña frm = new SAP.Configurador.OperacionesContraseña.EditarContraseña();
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
                        EliminarContraseña(Convert.ToInt32(row.Cells[0].Value));
                        this.ActualizarGrid1();
                    }
                    catch
                    {
                        MessageBox.Show("ocurrio un error al cargar la informacion.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                SAP.Configurador.OperacionesContraseña.AgregarContraseña frm = new SAP.Configurador.OperacionesContraseña.AgregarContraseña();
                frm.ShowDialog();
                this.ActualizarGrid1();
            }
            catch
            {
                MessageBox.Show("ocurrio un error al cargar la informacion.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarContraseña(int id)
        {
            string sql = "Delete From Operaciones Where ID=@id";
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
