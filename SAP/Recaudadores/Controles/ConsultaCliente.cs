using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class ConsultaCliente : Form
    {
        String codigot = SAP.Recaudadores.PrepagadoV2.codigo;
        String valor;
        Double Acumulado;
        public static string ID_Cliente;
        public static string nombre;
        public static double monto;
        public ConsultaCliente()
        {
            InitializeComponent();
            try
            {
                infUsuario(codigot);
            }
            catch
            {
               DialogResult resultado = MessageBox.Show("Error, al intentar consultar el usuario ¿desea reintentarlo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (resultado == DialogResult.Yes)
                {
                    infUsuario(codigot);
                }
                else
                {
                    this.Close();
                }
            }
            
        }
        private void infUsuario(string codigo)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select ClienteTarjeta.CodigoCliente,Cliente.ID_Cliente,Cliente.CI,Cliente.Nombre,Cliente.Direccion,Cliente.Telefono,Cliente.TipoVehiculo,Cliente.Correo,Cliente.SaldoDisponible From Cliente Inner Join ClienteTarjeta ON ClienteTarjeta.ID_Cliente=Cliente.ID_Cliente WHERE ClienteTarjeta.CodigoCliente=@tarjeta", cn);
            cmd.Parameters.AddWithValue("tarjeta", codigot);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Nombre.Text = dr["Nombre"].ToString();
                ID_Cliente = dr["ID_Cliente"].ToString();
                Cedula.Text = dr["CI"].ToString();
                Telefono.Text = dr["Telefono"].ToString();
                Direccion.Text = dr["Direccion"].ToString();
                Tipo.Text = dr["TipoVehiculo"].ToString();
                Correo.Text = dr["Correo"].ToString();
                valor = dr["SaldoDisponible"].ToString();
                Acumulado = Convert.ToDouble(valor);
                Saldo.Text = string.Format("{0:n}", Acumulado) + " Bs.S";
            }
            dr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
