using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles
{
    public partial class Lista : Form
    {
        public static String ID_Usuario1;
        public static int ID_Usuario;
        public Lista()
        {
            InitializeComponent();
            this.ActualizarGrid1();
        }


        public void ActualizarGrid1()
        {
            
            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select Usuarios.ID_Usuario,Usuarios.Nombre,Usuarios.Apellido,Usuarios.Nickname,Usuarios.Contrasena,Usuarios.Perfil,Usuarios.Turno From Usuarios where ID_Peaje=@peaje", cn);
            cmd.Parameters.AddWithValue("peaje", Convert.ToInt32(SAP.Inicio.peaje));
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                Usuario.Rows.Add(dr["ID_Usuario"].ToString(), dr["Nombre"].ToString(), dr["Apellido"].ToString(), dr["Nickname"].ToString(), dr["Contrasena"].ToString(), dr["Perfil"].ToString(), dr["Turno"].ToString(), "Editar");
            }
            dr.Close();
        }

        private void Usuario_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Usuario.Rows[e.RowIndex];
            ID_Usuario1 = Convert.ToString(row.Cells[0].Value);
            ID_Usuario = Convert.ToInt32(ID_Usuario1);
            SAP.Tesoreria.Controles.EditarUsuario frm = new SAP.Tesoreria.Controles.EditarUsuario();
            frm.ShowDialog();
        }

        private void buscar(string name)
        {
            string sql = "Select Usuarios.ID_Usuario,Usuarios.Nombre,Usuarios.Apellido,Usuarios.Nickname,Usuarios.Contrasena,Usuarios.Perfil,Usuarios.Turno From Usuarios where Nickname=@cedula AND ID_Peaje=@peaje AND Perfil<>'Cobrador' AND Perfil<>'COBRADOR';";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cedula", name);
                cmd.Parameters.AddWithValue("peaje", Convert.ToInt32(SAP.Inicio.peaje));
                dr = cmd.ExecuteReader();
                Usuario.Rows.Clear();
                while (dr.Read())
                {
                    Usuario.Rows.Add(dr["ID_Usuario"].ToString(), dr["Nombre"].ToString(), dr["Apellido"].ToString(), dr["Nickname"].ToString(), dr["Contrasena"].ToString(), dr["Perfil"].ToString(), dr["Turno"].ToString(), "Editar");

                }
                dr.Close();
                return;
            }
        }

        private void user_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.buscar(user.Text);
                if (Usuario.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario No Encontrado.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActualizarGrid1();

                }
            }
            catch
            {
                MessageBox.Show("Error al intentar buscar al usuario por favor reintente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
