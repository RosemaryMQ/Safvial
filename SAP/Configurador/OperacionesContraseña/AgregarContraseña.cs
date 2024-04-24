using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SAP.Configurador.OperacionesContraseña
{
    public partial class AgregarContraseña : Form
    {
        public AgregarContraseña()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Contraseña(codigo.Text) && codigo.Text.Length > 0)
                {
                    nuevacontraseña(codigo.Text);
                    MessageBox.Show("Contraseña agregada correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void nuevacontraseña(string codigo)
        {
            string sql = "Insert into Operaciones (Password) Values (@codigo)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
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
