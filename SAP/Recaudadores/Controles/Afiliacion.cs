using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class Afiliacion : Form
    {
        public static string nombre;
        public static string cedula;
        public static string tlf;
        public static string direccion;
        public static string tipov;
        public static string email;
        public static string exonerado="No";
        public Afiliacion()
        {
            InitializeComponent();
        }
        private bool EsValido(string cedula)
        {
            string sql = "SELECT * FROM Cliente WHERE CI=@cedula ";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cedula", cedula);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Nombre.Text != "" && DNI.Text != "" && tlf != "" && Direccion.Text != "" && TipoVehiculo.Text != "" && correo.Text != "")
            {
                cedula = prefijo.Text + "" + DNI.Text;
                if (EsValido(cedula))
                {
                    MessageBox.Show("La cedula ingresada ya esta registrada en sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    nombre = Nombre.Text;
                    tlf = telefono.Text;
                    direccion = Direccion.Text;
                    tipov = TipoVehiculo.Text;
                    email = correo.Text;
                    SAP.Recaudadores.Controles.AfiliacionV3 frm = new SAP.Recaudadores.Controles.AfiliacionV3();
                    frm.Show();
                    this.Hide();
                    
                }
                
            }
            else
            {
                MessageBox.Show("Por favor rellene todos los campos para poder continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }

        private void prefijo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DNI_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
