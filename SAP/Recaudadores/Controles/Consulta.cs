using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class Consulta : Form
    {
        String DNI = SAP.Recaudadores.Controles.Buscador.DNI;
        public static string ID_Cliente;
        public static string nombre;
        public static double monto;
        public static string telefono;
        public static string direccion;
        public static string tipo;
        public static string correo;
        string Exonerado ="";
        Boolean Activa;
        Boolean Bloqueada;
        double SaldoReal;
        public Consulta()
        {
            InitializeComponent();
                
                try
                {
                    infUsuario(DNI);
                    EstatusUser(ID_Cliente);
                    ConsultaC(ID_Cliente);
                if (Exonerado == "No")
                    Saldo.Text = SaldoReal.ToString("N6") + " Bs.";
                else
                    Saldo.Text = "Disponible";

                if (Nombre.Text.Trim() == "RELLENAR" && Correo.Text.Trim() == "RELLENAR" && Direccion.Text.Trim() == "RELLENAR")
                {
                    DialogResult resultado = MessageBox.Show("Cliente afiliado fue aperturado desde cabina debe llenar campos obligatorios.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultado == DialogResult.Yes)
                    {
                        this.Close();
                        SAP.Recaudadores.Controles.EditarCliente frm3 = new SAP.Recaudadores.Controles.EditarCliente();
                        frm3.ShowDialog();
                    }
                }
                if (Activa == true)
                {
                    if (Bloqueada == true)
                    {
                        Estado.Text = "Bloqueado";
                    }
                    else
                    {
                        Estado.Text = "Activa";
                    }
                    
                }
                else
                {
                    Estado.Text = "Inactiva";
                }
                }
                catch
                {
                    DialogResult resultado = MessageBox.Show("Error, al intentar consultar el usuario ¿desea reintentarlo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (resultado == DialogResult.Yes)
                    {
                        infUsuario(DNI);
                    }
                    else
                    {
                        this.Close();
                    }
                }
        }
        private void infUsuario(string dni)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select Cliente.ID_Cliente,Cliente.CI,Cliente.Nombre,Cliente.Direccion,Cliente.Telefono,Cliente.Correo,Cliente.Exonerado From Cliente WHERE Cliente.CI=@dni", cn);
            cmd.Parameters.AddWithValue("dni", dni);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Nombre.Text = dr["Nombre"].ToString();
                ID_Cliente = dr["ID_Cliente"].ToString();
                Cedula.Text = dr["CI"].ToString();
                Telefono.Text = dr["Telefono"].ToString();
                Direccion.Text = dr["Direccion"].ToString();
                Correo.Text = dr["Correo"].ToString();
                Exonerado = dr["Exonerado"].ToString();

            }
            dr.Close();
            nombre = Nombre.Text;
            telefono = Telefono.Text;
            direccion = Direccion.Text;
            correo = Correo.Text;
        }
        private void EstatusUser(string cliente)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select Activa,Bloqueada,Operador From TarjetasCliente Where ID_Cliente=@cliente", cn);
            cmd.Parameters.AddWithValue("cliente", cliente);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Activa = Convert.ToBoolean(dr["Activa"].ToString());
                Bloqueada = Convert.ToBoolean(dr["Bloqueada"].ToString());
                Operador.Text = dr["Operador"].ToString();
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 4;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
            this.Close();
            SAP.Recaudadores.Controles.Consulta frm2 = new SAP.Recaudadores.Controles.Consulta();
            frm2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.RecargaV2.ID = ID_Cliente;
            SAP.Recaudadores.RecargaV2.Nombre = Nombre.Text;
            SAP.Recaudadores.RecargaV2.Correo = Correo.Text;
            SAP.Recaudadores.RecargaV2.DNI = Cedula.Text;
            SAP.Recaudadores.RecargaV2.saldo = SaldoReal.ToString();
            SAP.Recaudadores.Controles.RecargaV2 frm = new SAP.Recaudadores.Controles.RecargaV2();
            frm.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.TarjetasCliente frm = new SAP.Recaudadores.Controles.TarjetasCliente();
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.RecargaCliente frm = new SAP.Recaudadores.Controles.RecargaCliente();
            frm.ShowDialog();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 16;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 17;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.ConsolidadoCliente frm = new SAP.Recaudadores.Controles.ConsolidadoCliente();
            frm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.ConsultaC(ID_Cliente);
            DialogResult result = MessageBox.Show("El saldo real del cliente es: "+ string.Format("{0:n}", SaldoReal) + " Bs.S ¿Desea Actualizarlo?" , "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                this.ActualizarSaldo(ID_Cliente,Convert.ToString(SaldoReal));
                MessageBox.Show("Saldo Actualizado Correctamente.","Exitoso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                SAP.Recaudadores.Controles.Consulta frm = new SAP.Recaudadores.Controles.Consulta();
                this.Hide();
                frm.ShowDialog();
            }
        }
        private void ActualizarSaldo(string codigo, string saldo)
        {
            string sql = "Update Cliente Set SaldoDisponible=@saldo Where ID_Cliente=@codigo";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.Parameters.AddWithValue("saldo", saldo);
                cmd.ExecuteReader();
                return;
            }
        }
        private void ConsultaC(string cliente)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT (SUM(ABONADO)-SUM(CONSUMIDO)) AS Saldo,SUM(ABONADO) as Recargado,SUM(CONSUMIDO)as Consumido,ID_Cliente FROM (SELECT (Tarifa) AS CONSUMIDO,0 AS ABONADO,Pagos.ID_Cliente FROM Pagos INNER JOIN TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo UNION ALL SELECT 0 AS CONSUMIDO, (Monto)AS ABONADO, V.ID_Cliente FROM Ventas V WHERE FormaPago IN('Recarga PDV', 'Recarga Transf', 'Recarga WEB', 'Exonerada', 'Recarga OP','Reintegro','Promo','Recarga OPE','Recarga Efectivo')) AS T WHERE ID_Cliente = @cliente GROUP BY ID_Cliente; ", cn);
            cmd.Parameters.AddWithValue("cliente", cliente);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SaldoReal = Convert.ToDouble(dr["Saldo"].ToString());
            }
            dr.Close();
        }
    }
}
