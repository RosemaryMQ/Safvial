using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using SAP.Properties;
using System.Threading.Tasks;

namespace SAP.Cobradores.Controles.V2
{
    public partial class Prepagado : Form
    {
        string ID="";
        public static double Saldo=0;
        string Cliente;
        public static string Exonerado="";
        bool procesando = false;
        Boolean Activa;
        Boolean Bloqueada;
        Boolean Reportada;
        Boolean Validor;
        double monto=0;
        public static double total = 0;
        public Prepagado()
        {
            InitializeComponent();
            Tipo.Text = SAP.Cobradores.RecaudacionV2.TipoVehiculo;
            Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Controles.V2.FormaPago.Costo)) + " Bs.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task<string> Conectar()
        {
            using (SqlConnection cn = new SqlConnection(SAP.Inicio.conexion2))
            {
                try
                {
                    await cn.OpenAsync();
                    var sql = "select 0";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    return ("Conectado");
                }
                catch
                {
                    return ("Desconectado");
                }
            }
        }
        private async Task<Boolean> ConsultaCOA()
        {
            Boolean resultado = false;
            string sql = "SELECT Conexion from COA WHERE ID = 1";
            using (SqlConnection cn = new SqlConnection(SAP.Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = await cmd.ExecuteReaderAsync();
                while (dr.Read())
                {
                    resultado = Convert.ToBoolean(dr["Conexion"]);
                }
                cn.Close();
                return resultado;
            }
        }
        private async void Recibido_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter && procesando == false)
            {
                await CobrarPase();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private async Task CobrarPase()
        {
            try
            {
                Accion.Text = "Conectando al COA...";
                Tarjeta.Enabled = false;
                procesando = true;
                Exonerado = "";
                Validor = await ConsultaCOA();
                if (Validor != false)
                {
                    Accion.Text = "Conectando al Servicio Prepagado...";
                    var validar = await Conectar();
                    if (validar == "Conectado")
                    {
                        Accion.Text = "Conectado...";
                        Accion.Text = "Validando Informacion...";
                        if (Tarjeta.Text != "" && Tarjeta.Text.Length >= 9)
                        {
                            Accion.Text = "Validando Tarjeta..";
                            var validarT = await EsValido(Tarjeta.Text);
                            if (validarT)
                            {
                                Accion.Text = "Obteniendo cliente...";
                                ID = await ConsultarCliente(Tarjeta.Text);
                                Accion.Text = "Obteniendo Saldo del Cliente...";
                                Saldo = await ConsultaC(ID);
                                Accion.Text = "Validando pase...";
                                if (Activa == true)
                                {
                                    Accion.Text = "Cobrando Pase...";
                                    if (Saldo < 0)
                                    {
                                        if (Reportada == true)
                                        {
                                            procesando = false;
                                            Tarjeta.Enabled = true;
                                            Tarjeta.Text = "";
                                            Accion.Text = "";
                                            SAP.Cobradores.Controles.SaldoPrepagado.Reportada frm = new SAP.Cobradores.Controles.SaldoPrepagado.Reportada();
                                            frm.ShowDialog();

                                        }
                                        else
                                        {
                                            procesando = false;
                                            Tarjeta.Enabled = true;
                                            Tarjeta.Text = "";
                                            Accion.Text = "";
                                            BloquearTarjeta(ID);
                                            SAP.Cobradores.Controles.SaldoPrepagado.AvisoSaldo frm = new SAP.Cobradores.Controles.SaldoPrepagado.AvisoSaldo();
                                            frm.ShowDialog();
                                        }
                                    }
                                    else
                                    {
                                        if (Bloqueada == false)
                                        {
                                            if (Reportada == false)
                                            {
                                                if (Exonerado == "No")
                                                {
                                                    monto = Convert.ToDouble(SAP.Cobradores.Controles.V2.FormaPago.Costo);
                                                    if (Saldo >= monto)
                                                    {
                                                        Accion.Text = "Cobrando pase...";
                                                        total = Saldo - monto;


                                                        if (await CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), Tarjeta.Text, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(ID), SAP.Inicio.sede) == true)
                                                        {
                                                            Accion.Text = "Imprimiendo ticket...";
                                                            SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada();
                                                            frm1.Show();
                                                            this.Close();
                                                        }

                                                    }
                                                    else
                                                    {
                                                        procesando = false;
                                                        SAP.Cobradores.Controles.SaldoPrepagado.Aviso frm = new SAP.Cobradores.Controles.SaldoPrepagado.Aviso();
                                                        frm.ShowDialog();
                                                        Tarjeta.Enabled = true;
                                                        Tarjeta.Text = "";
                                                        Accion.Text = "";
                                                    }
                                                }
                                                else
                                                {
                                                    Accion.Text = "Cobrando pase...";
                                                    total = 0;
                                                    var cobrar = await CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), Tarjeta.Text, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(ID), SAP.Inicio.sede);
                                                    if (cobrar)
                                                    {
                                                        await Control(true);
                                                        Accion.Text = "Imprimiendo ticket...";
                                                        SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada();
                                                        frm1.Show();
                                                        this.Close();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                procesando = false;
                                                SAP.Cobradores.Controles.SaldoPrepagado.Reportada frm = new SAP.Cobradores.Controles.SaldoPrepagado.Reportada();
                                                frm.ShowDialog();
                                                Tarjeta.Enabled = true;
                                                Tarjeta.Text = "";
                                                Accion.Text = "";
                                            }
                                        }
                                        else
                                        {
                                            if (Reportada == true)
                                            {
                                                procesando = false;
                                                SAP.Cobradores.Controles.SaldoPrepagado.Reportada frm = new SAP.Cobradores.Controles.SaldoPrepagado.Reportada();
                                                frm.ShowDialog();
                                                Tarjeta.Enabled = true;
                                                Tarjeta.Text = "";
                                                Accion.Text = "";
                                            }
                                            else
                                            {
                                                procesando = false;
                                                SAP.Cobradores.Controles.SaldoPrepagado.Bloqueada frm = new SAP.Cobradores.Controles.SaldoPrepagado.Bloqueada();
                                                frm.ShowDialog();
                                                Tarjeta.Enabled = true;
                                                Tarjeta.Text = "";
                                                Accion.Text = "";
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    procesando = false;
                                    SAP.Cobradores.Controles.SaldoPrepagado.AvisoError frm = new SAP.Cobradores.Controles.SaldoPrepagado.AvisoError();
                                    frm.ShowDialog();
                                    Tarjeta.Enabled = true;
                                    Tarjeta.Text = "";
                                    Accion.Text = "";
                                }
                            }
                            else
                            {
                                procesando = false;
                                SAP.Cobradores.Controles.SaldoPrepagado.Invalida frm = new SAP.Cobradores.Controles.SaldoPrepagado.Invalida();
                                frm.ShowDialog();
                                Tarjeta.Enabled = true;
                                Tarjeta.Text = "";
                                Accion.Text = "";
                            }
                        }
                        else
                        {
                            procesando = false;
                            MessageBox.Show("El codigo de cliente no puede estar vacio y no puede ser tan corto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Tarjeta.Enabled = true;
                            Tarjeta.Text = "";
                            Accion.Text = "";
                        }
                    }
                    else
                    {
                        Accion.Text = "Obteniendo Informacion de Cliente...";
                        await Control(false);
                        if (Tarjeta.Text.Length >= 9 && Tarjeta.Text != "")
                        {
                            Accion.Text = "Validando informacion...";
                            var validart2 = await EsValido2(Tarjeta.Text);
                            if (validart2)
                            {
                                Accion.Text = "Enviando pase...";

                                if (await PagoSinConexion(Tarjeta.Text, Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Inicio.sede, Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal)) == true)
                                {

                                    Accion.Text = "Imprimiendo ticket...";
                                    SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar();
                                    frm1.Show();
                                    this.Close();
                                }
                            }
                            else
                            {
                                procesando = false;
                                SAP.Cobradores.Controles.SaldoPrepagado.Invalida frm = new SAP.Cobradores.Controles.SaldoPrepagado.Invalida();
                                frm.ShowDialog();
                                Tarjeta.Enabled = true;
                                Tarjeta.Text = "";
                                Accion.Text = "";
                            }
                        }
                        else
                        {
                            procesando = false;
                            MessageBox.Show("El codigo de cliente no puede estar vacio!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Accion.Text = "";
                            Tarjeta.Enabled = true;
                        }
                    }

                }
                else
                {
                    Accion.Text = "Obteniendo Informacion de Cliente...";
                    await Control(false);
                    if (Tarjeta.Text.Length >= 9 && Tarjeta.Text != "")
                    {
                        Accion.Text = "Validando informacion...";
                        var validart3 = await EsValido2(Tarjeta.Text);
                        if (validart3)
                        {
                            Accion.Text = "Enviando pase...";

                            if (await PagoSinConexion(Tarjeta.Text, Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Inicio.sede, Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal)) == true)
                            {

                                Accion.Text = "Imprimiendo ticket...";
                                SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar();
                                frm1.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            procesando = false;
                            SAP.Cobradores.Controles.SaldoPrepagado.Invalida frm = new SAP.Cobradores.Controles.SaldoPrepagado.Invalida();
                            frm.ShowDialog();
                            Tarjeta.Enabled = true;
                            Tarjeta.Text = "";
                            Accion.Text = "";
                        }
                    }
                    else
                    {
                        procesando = false;
                        MessageBox.Show("El codigo de cliente no puede estar vacio!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Accion.Text = "";
                        Tarjeta.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    Accion.Text = "Obteniendo Informacion de Cliente...";
                    if (Tarjeta.Text.Length >= 9 && Tarjeta.Text != "")
                    {
                        Accion.Text = "Validando informacion...";
                        var valida = await EsValido2(Tarjeta.Text);
                        if (valida)
                        {
                            Accion.Text = "Enviando pase...";
                            var result = await PagoSinConexion(Tarjeta.Text, Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Inicio.sede, Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal));
                            if (result)
                            {
                                Accion.Text = "Imprimiendo ticket...";
                                SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar();
                                frm1.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            procesando = false;
                            SAP.Cobradores.Controles.SaldoPrepagado.Invalida frm = new SAP.Cobradores.Controles.SaldoPrepagado.Invalida();
                            frm.ShowDialog();
                            Tarjeta.Enabled = true;
                            Tarjeta.Text = "";
                            Accion.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("El codigo de cliente no puede estar vacio!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        procesando = false;
                        Tarjeta.Enabled = true;
                        Accion.Text = "";
                    }
                }
                catch
                {
                    MessageBox.Show("OCurrio un error en el sistema, por favor notifique a soporte.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Tarjeta.Enabled = true;
                    Tarjeta.Text = "";
                    Accion.Text = "";
                    procesando = false;
                }
            }

        }
        private async Task Control(Boolean estatus)
        {
            string sql = "UPDATE COA SET Conexion=@estatus where ID=1";
            using (SqlConnection cn = new SqlConnection(SAP.Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("estatus", estatus);
                await cmd.ExecuteNonQueryAsync();
                return;
            }
        }
        private async Task<bool> EsValido(string tarjerta)
        {
            string sql = "SELECT TarjetasCliente.CodigoCliente From TarjetasCliente Where TarjetasCliente.CodigoCliente=@tarjeta";
            using (SqlConnection cn = new SqlConnection(SAP.Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("tarjeta", tarjerta);
                double val = Convert.ToDouble(await cmd.ExecuteScalarAsync());
                return !(val == 0);
            }
        }
        private async Task<bool> EsValido2(string tarjerta)
        {
            string sql = "SELECT CodigoCliente From ControlTarjeta Where CodigoCliente=@tarjeta";
            using (SqlConnection cn = new SqlConnection((string)Settings.Default["ConexionPSC"]))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("tarjeta", tarjerta);
                double val = Convert.ToDouble(await cmd.ExecuteScalarAsync());
                return !(val == 0);
            }
        }
        private async Task<Boolean> CargarPago(int id_user, int id_vehiculo, string referencia, int canal, int cliente, int sede)
        {
            Boolean resultado = false;
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal,Sede,ID_Cliente) Values (@iduser,@idvehiculo,SYSDATETIME(),'Saldo Pre-pagado',@referencia,@canal,@sede,@id)";
            using (SqlConnection cn = new SqlConnection(SAP.Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("referencia", referencia);
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.Parameters.AddWithValue("id", cliente);
                await cmd.ExecuteNonQueryAsync();
                cn.Close();
                resultado = true;
                return resultado;
            }
        }
        private async Task<Boolean> PagoSinConexion(String Codigo, int Vehiculo, int sede, int usuario, int canal)
        {
            Boolean resultado = false;
            string sql = "Insert into PorCobrar (CodigoTarjeta,ID_Vehiculo,Fecha,Sede,Estatus,ID_Usuario,Canal) Values (@codigo,@vehiculo,SYSDATETIME(),@sede,'Pendiente',@usuario,@canal)";
            using (SqlConnection cn = new SqlConnection(SAP.Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("codigo", Codigo);
                cmd.Parameters.AddWithValue("vehiculo", Vehiculo);
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                await cmd.ExecuteNonQueryAsync();
                cn.Close();
                resultado = true;
                return resultado;
            }
        }
        private async void BloquearTarjeta(String Cliente)
        {
            string sql = "Update TarjetasCliente Set Bloqueada=1 Where ID_Cliente=@Cliente";
            using (SqlConnection cn = new SqlConnection(SAP.Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("Cliente", Convert.ToInt32(Cliente));
                await cmd.ExecuteNonQueryAsync();
                return;
            }
        }
        private async Task<string> ConsultarCliente(string referencia)
        {
            string cliente="";
            string sql = "select Cliente.ID_Cliente,Cliente.Exonerado,TarjetasCliente.Activa,TarjetasCliente.Bloqueada,TarjetasCliente.Reportada from Cliente inner join TarjetasCliente on Cliente.ID_Cliente= TarjetasCliente.ID_Cliente where TarjetasCliente.CodigoCliente=@referencia";
            using (SqlConnection cn = new SqlConnection(SAP.Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("referencia", referencia);
                dr = await cmd.ExecuteReaderAsync();    
                while (await dr.ReadAsync())
                {
                    cliente = dr["ID_Cliente"].ToString();
                    Exonerado = dr["Exonerado"].ToString();
                    Activa = Convert.ToBoolean(dr["Activa"].ToString());
                    Bloqueada = Convert.ToBoolean(dr["Bloqueada"].ToString());
                    Reportada = Convert.ToBoolean(dr["Reportada"].ToString());
                }
                cn.Close();
                return cliente;
            }
        }
        private async Task<double> ConsultaC(string cliente)
        {
            double saldo = 0;
            SqlConnection cn = new SqlConnection(SAP.Inicio.conexion2);
            await cn.OpenAsync();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT (SUM(ABONADO)-SUM(CONSUMIDO)) AS Saldo,SUM(ABONADO) as Recargado,SUM(CONSUMIDO)as Consumido,ID_Cliente FROM (SELECT (Tarifa) AS CONSUMIDO,0 AS ABONADO,Pagos.ID_Cliente FROM Pagos INNER JOIN TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo UNION ALL SELECT 0 AS CONSUMIDO, (Monto)AS ABONADO, V.ID_Cliente FROM Ventas V WHERE FormaPago IN('Recarga PDV', 'Recarga Transf', 'Recarga WEB', 'Exonerada', 'Recarga OP','Reintegro','Promo','Recarga OPE','Recarga Efectivo')) AS T WHERE ID_Cliente = @cliente GROUP BY ID_Cliente;", cn);
            cmd.Parameters.AddWithValue("cliente", cliente);
            dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                saldo = Convert.ToDouble(dr["Saldo"]);
            }
            cn.Close();
            return saldo;
        }

    }
}
