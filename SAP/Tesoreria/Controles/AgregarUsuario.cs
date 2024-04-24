using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using SAP.Properties;

namespace SAP.Tesoreria.Controles
{
    public partial class AgregarUsuario : Form
    {
        public AgregarUsuario()
        {
            InitializeComponent();
        }
        private void Usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
            //if (e.KeyCode == Keys.Enter)
            //{
            //    try
            //    {
            //        if (Nombre.Text != "" && Apellido.Text != "" && DNI.Text != "" && TipoUsuario.Text != "" && Peaje.Text != "" && Turno.Text != "" && NickName.Text != "" && Contraseña.Text != "")
            //        {
            //            if (!EsValido(NickName.Text))
            //            {
            //                    this.NuevoUsuario(TipoUsuario.Text, NickName.Text, Contraseña.Text, 1, Nombre.Text, Apellido.Text, Turno.Text);
            //                    MessageBox.Show("Nuevo usuario registrado correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    this.Close();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Cedula ya registrada en el sistema por favor verifique e intente de nuevo.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                DNI.Text = "";
            //                NickName.Text = "";
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Disculpe todos los campos deben ser llenados para aperturar un nuevo usuario.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Disculpe ocurrio un error al intentar crear un nuevo usuario por favor intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
               
            //}
        }
        private void NuevoUsuario(string perfil, string nickname, string contrasena, int peaje,string nombre, string apellido, string turno)
        {
            string sql = "Insert into Usuarios (Perfil,Nickname,Contrasena,ID_Peaje,Nombre,Apellido,Estado,Turno,Canal,Clave) Values (@perfil,@Nickname,@Contrasena,@Peaje,@Nombre,@Apellido,'No Conectado',@Turno,'0','')";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("Perfil", perfil);
                cmd.Parameters.AddWithValue("Nickname", nickname);
                cmd.Parameters.AddWithValue("Contrasena", contrasena);
                cmd.Parameters.AddWithValue("Peaje", peaje);
                cmd.Parameters.AddWithValue("Nombre", nombre);
                cmd.Parameters.AddWithValue("Apellido", apellido);
                cmd.Parameters.AddWithValue("Turno", turno);
                cmd.ExecuteReader();
                return;
            }
        }
        private bool EsValido(string usuario)
        {
            string sql = "SELECT * FROM Usuarios WHERE Nickname = @usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13) && (e.KeyChar != (char)32))

            {
                e.Handled = true;
                return;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nombre.Text != "" && Apellido.Text != "" && DNI.Text != "" && TipoUsuario.Text != "" && Turno.Text != "" && NickName.Text != "" && Contraseña.Text != "")
                {
                    if (!EsValido(NickName.Text))
                    {
                            this.NuevoUsuario(TipoUsuario.Text, NickName.Text, Contraseña.Text, 1, Nombre.Text, Apellido.Text, Turno.Text);
                            MessageBox.Show("Nuevo usuario registrado correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cedula ya registrada en el sistema por favor verifique e intente de nuevo.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DNI.Text = "";
                        NickName.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Disculpe todos los campos deben ser llenados para aperturar un nuevo usuario.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Disculpe ocurrio un error al intentar crear un nuevo usuario por favor intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DNI_KeyUp(object sender, KeyEventArgs e)
        {
            NickName.Text = DNI.Text;
        }

        private void DNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void TipoUsuario_Click(object sender, EventArgs e)
        {

        }

        private void NickName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
