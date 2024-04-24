using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class EditarUsuario : Form
    {
        public EditarUsuario()
        {
            try
            {
                InitializeComponent();
                ID.Text = SAP.Recaudadores.Controles.ControlUsuarios.ID_Usuario1;
                this.infUsuario(Convert.ToInt32(ID.Text));
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al iniciar el modulo intente nuevamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private void infUsuario(int usuario)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select Usuarios.Nombre,Usuarios.Apellido,Usuarios.Nickname,Usuarios.Contrasena,Usuarios.Perfil,Usuarios.Turno,Usuarios.ID_Peaje From Usuarios where ID_Usuario=@usuario", cn);
            cmd.Parameters.AddWithValue("usuario", usuario);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Nombre.Text = dr["Nombre"].ToString();
                Apellido.Text = dr["Apellido"].ToString();
                Nickname.Text = dr["Nickname"].ToString();
                Contrasena.Text = dr["Contrasena"].ToString();
                Tipo.Text = dr["Perfil"].ToString();
                Turnos.Text = dr["Turno"].ToString();
            }
            dr.Close();

        }

        private void PEAJE_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection cn = new SqlConnection(Inicio.conexion);
            //    cn.Open();
            //    SqlDataReader dr;
            //    SqlCommand cmd = new SqlCommand("Select Nombre,Ubicacion from Peaje where ID_Peaje=@peaje", cn);
            //    cmd.Parameters.AddWithValue("peaje", Convert.ToInt32(PEAJE.Text));
            //    dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        PeajeNombre.Text = dr["Nombre"].ToString() + " - " + dr["Ubicacion"].ToString();
            //    }
            //    dr.Close();
            //}
            //catch
            //{
            //    SqlConnection cn = new SqlConnection(Inicio.conexion);
            //    cn.Open();
            //    SqlDataReader dr;
            //    SqlCommand cmd = new SqlCommand("Select Nombre,Ubicacion from Peaje ID_Peaje=@peaje", cn);
            //    cmd.Parameters.AddWithValue("peaje", Convert.ToInt32(PEAJE.Text));
            //    dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        PeajeNombre.Text = dr["Nombre"].ToString() + " - " + dr["Ubicacion"].ToString();
            //    }
            //    dr.Close();
            //}
        }

        private void ActualizarUsuario(string perfil, string Nickname, string contrasena, int peaje, string nombre, string apellido, string turno, int usuario)
        {
            string sql = "Update Usuarios Set  Perfil=@perfil, Nickname=@nickname, Contrasena=@contrasena, ID_Peaje=@peaje, Nombre=@nombre, Apellido=@apellido, Turno=@turno Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("perfil", perfil);
                cmd.Parameters.AddWithValue("nickname", Nickname);
                cmd.Parameters.AddWithValue("contrasena", contrasena);
                cmd.Parameters.AddWithValue("peaje", peaje);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("apellido", apellido);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.ExecuteReader();
                return;
            }
        }

        private void Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13) && (e.KeyChar != (char)32))

            {
                e.Handled = true;
                return;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Tipo.Text != "" && Nickname.Text != "" && Contrasena.Text != "" && Nombre.Text != "" && Apellido.Text != "" && Turnos.Text != "" && ID.Text != "")
                {
                    ActualizarUsuario(Tipo.Text, Nickname.Text, Contrasena.Text, Convert.ToInt32(SAP.Inicio.sede), Nombre.Text, Apellido.Text, Turnos.Text, Convert.ToInt32(ID.Text));
                    MessageBox.Show("Los datos fueron actualizado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Para modificar debe estar llenos todos los campo, verifique e intente de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al intentar editar al usuario intente de nuevo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
