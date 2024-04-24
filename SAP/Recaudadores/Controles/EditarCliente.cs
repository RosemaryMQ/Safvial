using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SAP.Recaudadores.Controles
{
    public partial class EditarCliente : Form
    {
        String nic = SAP.Recaudadores.Controles.Buscador.DNI;
        public EditarCliente()
        {
            InitializeComponent();
            Nombre.Text = SAP.Recaudadores.Controles.Consulta.nombre;
            ID.Text = SAP.Recaudadores.Controles.Consulta.ID_Cliente;
            prefijo.SelectedValue = nic.Substring(0);
            Cedula.Text = nic.Substring(1);
            Telefono.Text = SAP.Recaudadores.Controles.Consulta.telefono;
            Direccion.Text = SAP.Recaudadores.Controles.Consulta.direccion;
            Tipo.SelectedValue = SAP.Recaudadores.Controles.Consulta.tipo;
            Correo.Text = SAP.Recaudadores.Controles.Consulta.correo;

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
 
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nombre.Text != "" && prefijo.Text!="" && Cedula.Text != "" && Telefono.Text != "" && Direccion.Text != "" && Tipo.Text != "" && Correo.Text != "")
                {
                    ActualizarUsuario(prefijo.Text+Cedula.Text, Nombre.Text, Direccion.Text, Telefono.Text, Correo.Text, Tipo.Text, Convert.ToInt32(ID.Text));
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
                MessageBox.Show("Ocurrio un error al intentar editar al cliente intente de nuevo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
           
        }
        private void ActualizarUsuario(string CI, string Nombre, string direccion, string telefono, string correo, string tipo, int usuario)
        {
            string sql = "Update Cliente Set  CI=@ci, Nombre=@nombre, Direccion=@direccion, Telefono=@telefono, Correo=@correo, TipoVehiculo=@tipo Where ID_Cliente=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("ci", CI);
                cmd.Parameters.AddWithValue("nombre", Nombre);
                cmd.Parameters.AddWithValue("direccion", direccion);
                cmd.Parameters.AddWithValue("telefono", telefono);
                cmd.Parameters.AddWithValue("correo", correo);
                cmd.Parameters.AddWithValue("tipo", tipo);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.ExecuteReader();
                return;
            }
        }

    }
}
