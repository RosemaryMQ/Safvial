using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Configurador.TarjetasSupervisores
{
    public partial class EditarTarjeta : Form
    {
        public EditarTarjeta()
        {
            InitializeComponent();
            id.Text = SAP.Configurador.ClaveSupervisores.IDE;
            nombre.Text = SAP.Configurador.ClaveSupervisores.Nombre;
            codigo.Text = SAP.Configurador.ClaveSupervisores.Codigo;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!Supervisores(codigo.Text))
            {
                ActualizarTarjeta(Convert.ToInt32(id.Text), Convert.ToDouble(codigo.Text), nombre.Text);
                MessageBox.Show("Los datos fueron actualizado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("El codigo ingresado a existe por favor verifique.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void ActualizarTarjeta(int id, double codigo, string nombre)
        {
            string sql = "Update Supervisor Set  Autorizado=@codigo, Nombre=@nombre Where ID=@id";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.ExecuteReader();
                return;
            }
        }

        private void codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }
        private bool Supervisores(string password)
        {
            string sql = "SELECT * FROM Supervisor WHERE Autorizado = @clave";
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
