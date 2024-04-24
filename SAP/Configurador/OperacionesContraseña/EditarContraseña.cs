using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAP.Configurador.OperacionesContraseña
{
    public partial class EditarContraseña : Form
    {
        public EditarContraseña()
        {
            InitializeComponent();
            id.Text = SAP.Configurador.Contraseñas.IDClave;
            codigo.Text = SAP.Configurador.Contraseñas.CodigoOperacion;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Contraseña(codigo.Text) && codigo.Text.Length > 0) 
                {
                    ActualizarContraseña(Convert.ToInt32(id.Text),codigo.Text);
                    MessageBox.Show("Contraseña actualizada correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña a ingresar ya existe por favor verifique.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    codigo.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error por favor reintente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarContraseña(int id, string codigo)
        {
            string sql = "Update Operaciones Set  Password=@codigo Where ID=@id";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.ExecuteReader();
                return;
            }
        }
        private bool Contraseña(string password)
        {
            string sql = "SELECT * FROM Operaciones WHERE Password = @clave";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("clave", password);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
    }
}
