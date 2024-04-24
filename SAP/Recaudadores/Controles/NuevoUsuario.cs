using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class NuevoUsuario : Form
    {
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nombre.Text != "" && Apellido.Text != "" && DNI.Text != "" && TipoUsuario.Text != "" && Turno.Text != "" && NickName.Text != "" && Contraseña.Text != "")
                {
                    if (!EsValido(NickName.Text))
                    {
                        this.NuevoUsuario1(TipoUsuario.Text, NickName.Text, Contraseña.Text,SAP.Inicio.sede, Nombre.Text, Apellido.Text, Turno.Text);
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

        private void Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13) && (e.KeyChar != (char)32))

            {
                e.Handled = true;
                return;

            }
        }

        private void DNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }
        private void NuevoUsuario1(string perfil, string nickname, string contrasena, int peaje, string nombre, string apellido, string turno)
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

        private void DNI_KeyUp(object sender, KeyEventArgs e)
        {
            NickName.Text = DNI.Text;
        }
    }
}
