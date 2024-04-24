using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Cobradores.Controles.SaldoPrepagado
{
    public partial class SaldoPrepagado : Form
    {
        String RecibeDato;
        public static String Valor;
        public static String monto;
        public static double Resultado = 0;
        String ID;
        String Fecha;
        String Saldo = "";
        String Exonerado;
        double saldodisponible = 0;
        double costo = 0;
        String Cliente;
        int Identificador = Convert.ToInt32(SAP.Cobradores.Controles.Pagos.Identificador);
        String Estatus;
        String Validor;
        public static int Sede = SAP.Inicio.sede;
        public SaldoPrepagado()
        {
            InitializeComponent();
            ConsultaCOA();
            RecibeDato = SAP.Cobradores.Recaudadores.TipoVehiculo;
            if (RecibeDato == "Liviano")
            {
                Tipo.Text = SAP.Cobradores.Recaudadores.TipoVehiculo;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.Liviano)) + " Bs.S";
                Valor = SAP.Cobradores.Recaudadores.Liviano;

            }
            if (RecibeDato == "Carga Liviana")
            {
                Tipo.Text = SAP.Cobradores.Recaudadores.TipoVehiculo;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.CargaLiviana)) + " Bs.S";
                Valor = SAP.Cobradores.Recaudadores.CargaLiviana;
            }
            if (RecibeDato == "Microbus")
            {
                Tipo.Text = SAP.Cobradores.Recaudadores.TipoVehiculo;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.Microbus)) + " Bs.S";
                Valor = SAP.Cobradores.Recaudadores.Microbus;
            }
            if (RecibeDato == "Autobus")
            {
                Tipo.Text = SAP.Cobradores.Recaudadores.TipoVehiculo;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.Autobus)) + " Bs.S";
                Valor = SAP.Cobradores.Recaudadores.Autobus;
            }
            if (RecibeDato == "2 Ejes")
            {
                Tipo.Text = SAP.Cobradores.Recaudadores.TipoVehiculo;
                Tarifa.Text = string.Format("{0:n}", SAP.Cobradores.Recaudadores.ejes2) + " Bs.S";
                Valor = SAP.Cobradores.Recaudadores.ejes2;

            }
            if (RecibeDato == "3 Ejes")
            {
                Tipo.Text = SAP.Cobradores.Recaudadores.TipoVehiculo;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.ejes3)) + " Bs.S";
                Valor = SAP.Cobradores.Recaudadores.ejes3;
            }
            if (RecibeDato == "4 Ejes")
            {
                Tipo.Text = SAP.Cobradores.Recaudadores.TipoVehiculo;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.ejes4)) + " Bs.S";
                Valor =SAP.Cobradores.Recaudadores.ejes4;
            }
            if (RecibeDato == "5 Ejes")
            {
                Tipo.Text = SAP.Cobradores.Recaudadores.TipoVehiculo;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.ejes5)) + " Bs.S";
                Valor =SAP.Cobradores.Recaudadores.ejes5;
            }
            if (RecibeDato == "6 Ejes o Mas")
            {
                Tipo.Text = SAP.Cobradores.Recaudadores.TipoVehiculo;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.ejes6)) + " Bs.S";
                Valor = SAP.Cobradores.Recaudadores.ejes6;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
            frm.ShowDialog();
            this.Close();
        }
        private void CargarPago(int id_user, int id_vehiculo, DateTime fecha, string referencia, int canal,int cliente,int sede)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal,Sede,ID_Cliente) Values (@iduser,@idvehiculo,@fecha,'Saldo Pre-pagado',@referencia,@canal,@sede,@id)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("referencia", referencia);
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.Parameters.AddWithValue("id", cliente);
                cmd.ExecuteReader();
                return;
            }
        }
        private void PagoSinConexion(String Codigo, int Vehiculo, string fecha,int sede,int usuario,int canal)
        {
            string sql = "Insert into PorCobrar (CodigoTarjeta,ID_Vehiculo,Fecha,Sede,Estatus,ID_Usuario,Canal) Values (@codigo,@vehiculo,@fecha,@sede,'Pendiente',@usuario,@canal)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("codigo", Codigo);
                cmd.Parameters.AddWithValue("vehiculo", Vehiculo);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.ExecuteReader();
                return;
            }
        }
        private void ActualizarBalance(String balance,String Cliente)
        {
            string sql = "Update Cliente Set SaldoDisponible=@balance Where ID_Cliente=@Cliente";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("balance", balance);
                cmd.Parameters.AddWithValue("Cliente", Convert.ToInt32(Cliente));
                cmd.ExecuteReader();
                return;
            }
        }
        private void ConsultarCliente(string referencia)
        {
            string sql = "select Cliente.ID_Cliente, Cliente.Nombre, Cliente.SaldoDisponible, ClienteTarjeta.Estatus,Cliente.Exonerado from Cliente inner join ClienteTarjeta on Cliente.ID_Cliente= ClienteTarjeta.ID_Cliente where ClienteTarjeta.CodigoCliente=@referencia";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("referencia", referencia);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ID = dr["ID_Cliente"].ToString();
                    Saldo = dr["SaldoDisponible"].ToString();
                    Cliente = dr["Nombre"].ToString();
                    Estatus = dr["Estatus"].ToString();
                    Exonerado = dr["Exonerado"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void ConsultaCOA()
        {

            string sql = "SELECT Password from Operaciones WHERE ID = 5";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Validor = dr["Password"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void tableLayoutPanel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(Validor != "Desconectado")
                {
                    if (Recibido.Text != "0" && Recibido.Text != "")
                    {
                        if (Recibido.Text.Length >= 9)
                        {
                            ConsultarCliente(Recibido.Text);
                            
                            if (Estatus != "Inactivo    " && Estatus != "")
                            {
                                if (Exonerado != "Si")
                                {
                                    if (Saldo != "" && ID != "")
                                    {
                                        saldodisponible = Convert.ToDouble(Saldo);
                                        costo = Convert.ToDouble(Valor);
                                        monto = Tarifa.Text;
                                        if (saldodisponible >= costo)
                                        {
                                            Resultado = saldodisponible - costo;
                                            if (Resultado == 0)
                                            {
                                                try
                                                {
                                                    ActualizarBalance(Convert.ToString(Resultado), ID);
                                                    this.Fecha = DateTime.Now.ToString("G");
                                                    CargarPago(Convert.ToInt32(SAP.Inicio.ID), Identificador, Convert.ToDateTime(Fecha), Recibido.Text, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(ID), Sede);
                                                    SAP.Cobradores.Recaudadores.recaudacion = SAP.Cobradores.Recaudadores.ConsultaRecaudacion(SAP.Inicio.ID);
                                                    SAP.Cobradores.Controles.SaldoPrepagado.FacturaSaldo frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaSaldo();
                                                    frm1.Show();
                                                    SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
                                                    frm.Show();
                                                    this.Close();
                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Error,al cargar pago intente de nuevo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    Recibido.Text = "";
                                                }

                                            }
                                            else
                                            {
                                                try
                                                {
                                                              
                                                    ActualizarBalance(Convert.ToString(Resultado), ID);
                                                    this.Fecha = DateTime.Now.ToString("G");
                                                    CargarPago(Convert.ToInt32(SAP.Inicio.ID), Identificador, Convert.ToDateTime(Fecha), Recibido.Text, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(ID), Sede);
                                                    SAP.Cobradores.Recaudadores.recaudacion = SAP.Cobradores.Recaudadores.ConsultaRecaudacion(SAP.Inicio.ID);
                                                    SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada();
                                                    frm1.Show();
                                                    SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
                                                    frm.Show();
                                                    this.Close();
                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Error,al cargar pago intente de nuevo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    Recibido.Text = "";
                                                }

                                            }

                                        }
                                        else
                                        {
                                            SAP.Cobradores.Controles.SaldoPrepagado.AvisoSaldo frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.AvisoSaldo();
                                            frm1.ShowDialog();
                                            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                                            frm.ShowDialog();
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        SAP.Cobradores.Controles.SaldoPrepagado.AvisoError frm2 = new SAP.Cobradores.Controles.SaldoPrepagado.AvisoError();
                                        frm2.ShowDialog();
                                        SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                                        frm.ShowDialog();
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                            else
                            {
                                SAP.Cobradores.Controles.SaldoPrepagado.AvisoError frm2 = new SAP.Cobradores.Controles.SaldoPrepagado.AvisoError();
                                frm2.ShowDialog();
                                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                                frm.ShowDialog();
                                this.Close();
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("El codigo de cliente no puede estar vacio!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                    }
                else
                {
                    if (Recibido.Text != "0" && Recibido.Text != "")
                    {
                        if (Recibido.Text.Length >= 9)
                        {
                            PagoSinConexion(Recibido.Text, Identificador, DateTime.Now.ToString("G"), Sede, Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal));
                            SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar();
                            frm1.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El codigo de cliente no puede estar vacio!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
             
            }
            if (e.KeyCode == Keys.Escape)
            {

                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
