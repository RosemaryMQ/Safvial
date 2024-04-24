using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Configurador.TarjetasSupervisores
{
    public partial class AgregarTarjeta : Form
    {
        public AgregarTarjeta()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!Supervisores(codigo.Text))
            { 
            nuevatarjeta(nombre.Text,Convert.ToDouble(codigo.Text));
            MessageBox.Show("Tarjeta agregada correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            }
            else
            {
                MessageBox.Show("La tarjeta a ingresar a existe por favor verifique.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                codigo.Text = "";
            }
        }
        private void nuevatarjeta(string nombre, double codigo)
        {
            string sql = "Insert into Supervisor (Autorizado,Nombre) Values (@codigo,@nombre)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.Parameters.AddWithValue("Nombre", nombre);
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
