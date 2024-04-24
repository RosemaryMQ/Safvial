using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Cobradores.Controles.V2
{
    public partial class Confirmacion : Form
    {
        public static string iduser="";
        double sumar=0;
        string DNI;
        int conteo = 0;
        public static double saldoadd;
        public Confirmacion()
        {
            InitializeComponent();
            iduser = "";
            sumar = Convert.ToDouble(SAP.Cobradores.Controles.V2.TarjetaElectronica.suma);
            Tarjeta.Text = SAP.Cobradores.Controles.V2.TarjetaElectronica.codigocontrol;
            DNI = SAP.Cobradores.Controles.V2.TarjetaElectronica.DNI;
            Saldo.Text = string.Format("{0:n}", sumar) + " Bs.S";
            Promo.Text = Convert.ToString(SAP.Cobradores.RecaudacionV2.PromoAdicional)+"% +";
            conteo = 0;
            saldoadd = 0;
            saldoadd = sumar * (SAP.Cobradores.RecaudacionV2.PromoAdicional/100);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void tableLayoutPanel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (conteo == 0 && iduser == "")
                    {
                        Loading.Visible = true;
                        Panel.Visible = false;
                        Accion.Text = "Conectando con el servicio prepagado...";
                        conteo = 1;
                        if (await CargarCliente("V998877", "RELLENAR", SAP.Cobradores.Controles.V2.TarjetaElectronica.saldo, Convert.ToInt32(SAP.Inicio.ID), "RELLENAR", "RELLENAR", "RELLENAR", "Mixto"))
                        {
                            DNI = "V998877";
                            Accion.Text = "Agregando nuevo usuario.";
                            iduser = await Usuarioinfo(DNI);
                            if (iduser!="")
                            {
                                Accion.Text = "Agregando nuevo usuario...";
                                if(await ActualizarDNI(iduser, "V" + Convert.ToString(iduser)) == true)
                                {
                                    Accion.Text = "Anexando saldo promo...";
                                    if(await CargarPago1(Convert.ToInt32(SAP.Inicio.ID), "A.OP", Convert.ToSingle(SAP.Cobradores.RecaudacionV2.Tarjeta), SAP.Inicio.sede, Convert.ToInt32(iduser), "Canal " + SAP.Inicio.Canal) == true)
                                    {
                                        if (await CargarPago1(Convert.ToInt32(SAP.Inicio.ID), "Recarga OP", Convert.ToSingle(SAP.Cobradores.RecaudacionV2.PromoTarjeta), SAP.Inicio.sede, Convert.ToInt32(iduser), "Canal " + SAP.Inicio.Canal) == true)
                                        {
                                            if (SAP.Cobradores.RecaudacionV2.PromoAdicional > 0)
                                            {
                                                Accion.Text = "Anexando saldo especial...";
                                                await CargarPago1(Convert.ToInt32(SAP.Inicio.ID), "Promo", Convert.ToSingle(saldoadd), SAP.Inicio.sede, Convert.ToInt32(iduser), "Promocion de saldo adicional");
                                            }
                                            Accion.Text = "Anexando saldo tarjeta...";
                                            SqlConnection cn = new SqlConnection(Inicio.conexion2);
                                            string sql = "Update TarjetasCliente Set ID_Cliente='" + iduser + "', ID_Usuario='" + SAP.Inicio.ID + "', Apertura=SYSDATETIME(),Sede='" + SAP.Inicio.sede + "', Activa=1 Where CodigoCliente='" + SAP.Cobradores.Controles.V2.TarjetaElectronica.tarjeta + "'";
                                            SqlConnection cn1 = new SqlConnection(Inicio.conexion2);
                                            await cn1.OpenAsync();
                                            SqlCommand cmd1 = new SqlCommand(sql, cn1);
                                            await cmd1.ExecuteReaderAsync();
                                            Accion.Text = "completando operacion.";
                                            if (await CargarPago5(DNI, SAP.Cobradores.Controles.V2.TarjetaElectronica.tarjeta, SAP.Cobradores.Controles.V2.TarjetaElectronica.codigocontrol, Convert.ToInt32(SAP.Inicio.Canal), SAP.Inicio.ID, Convert.ToInt32(iduser), Convert.ToDouble(SAP.Cobradores.RecaudacionV2.PromoTarjeta), SAP.Inicio.sede, Convert.ToDouble(SAP.Cobradores.RecaudacionV2.Tarjeta)) == true)
                                            {
                                                Accion.Text = "Completando operacion..";
                                                if ( await CargarPago6(DNI, SAP.Cobradores.Controles.V2.TarjetaElectronica.tarjeta, SAP.Cobradores.Controles.V2.TarjetaElectronica.codigocontrol, Convert.ToInt32(SAP.Inicio.Canal), SAP.Inicio.ID, Convert.ToInt32(iduser), Convert.ToDouble(SAP.Cobradores.RecaudacionV2.PromoTarjeta), SAP.Inicio.sede, Convert.ToDouble(SAP.Cobradores.RecaudacionV2.Tarjeta)) == true)
                                                {
                                                    Accion.Text = "Imprimiendo ticket...";
                                                    SAP.Cobradores.Controles.V2.FacturaPromo frm1 = new SAP.Cobradores.Controles.V2.FacturaPromo();
                                                    frm1.Show();
                                                    this.Close();
                                                }
                                                else
                                                {
                                                    Panel.Visible = true;
                                                    Loading.Visible = false;
                                                    MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                }
                                            }
                                            else
                                            {
                                                Panel.Visible = true;
                                                Loading.Visible = false;
                                                MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            }
                                           
                                          
                                        }
                                        else
                                        {
                                            Panel.Visible = true;
                                            Loading.Visible = false;
                                            MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                    }
                                    
                                  
                                }
                                else
                                {
                                    Panel.Visible = true;
                                    Loading.Visible = false;
                                    MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }

                               
                            }
                            else
                            {
                                Panel.Visible = true;
                                Loading.Visible = false;
                                MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }

                        }
                        else
                        {
                            Panel.Visible = true;
                            Loading.Visible = false;
                            MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                      
                }
                catch
                {
                    Panel.Visible = true;
                    Loading.Visible = false;
                    MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conteo == 0 && iduser == "")
                {
                    Loading.Visible = true;
                    Panel.Visible = false;
                    Accion.Text = "Conectando con el servicio prepagado...";
                    conteo = 1;
                    if (await CargarCliente("V998877", "RELLENAR", SAP.Cobradores.Controles.V2.TarjetaElectronica.saldo, Convert.ToInt32(SAP.Inicio.ID), "RELLENAR", "RELLENAR", "RELLENAR", "Mixto"))
                    {
                        DNI = "V998877";
                        Accion.Text = "Agregando nuevo usuario.";
                        iduser = await Usuarioinfo(DNI);
                        if (iduser != "")
                        {
                            Accion.Text = "Agregando nuevo usuario...";
                            if (await ActualizarDNI(iduser, "V" + Convert.ToString(iduser)) == true)
                            {
                                Accion.Text = "Anexando saldo promo...";
                                if (await CargarPago1(Convert.ToInt32(SAP.Inicio.ID), "A.OP", Convert.ToSingle(SAP.Cobradores.RecaudacionV2.Tarjeta), SAP.Inicio.sede, Convert.ToInt32(iduser), "Canal " + SAP.Inicio.Canal) == true)
                                {
                                    if (await CargarPago1(Convert.ToInt32(SAP.Inicio.ID), "Recarga OP", Convert.ToSingle(SAP.Cobradores.RecaudacionV2.PromoTarjeta), SAP.Inicio.sede, Convert.ToInt32(iduser), "Canal " + SAP.Inicio.Canal) == true)
                                    {
                                        if (SAP.Cobradores.RecaudacionV2.PromoAdicional > 0)
                                        {
                                            Accion.Text = "Anexando saldo especial...";
                                            await CargarPago1(Convert.ToInt32(SAP.Inicio.ID), "Promo", Convert.ToSingle(saldoadd), SAP.Inicio.sede, Convert.ToInt32(iduser), "Promocion de saldo adicional");
                                        }
                                        Accion.Text = "Anexando saldo tarjeta...";
                                        SqlConnection cn = new SqlConnection(Inicio.conexion2);
                                        string sql = "Update TarjetasCliente Set ID_Cliente='" + iduser + "', ID_Usuario='" + SAP.Inicio.ID + "', Apertura=SYSDATETIME(),Sede='" + SAP.Inicio.sede + "', Activa=1 Where CodigoCliente='" + SAP.Cobradores.Controles.V2.TarjetaElectronica.tarjeta + "'";
                                        SqlConnection cn1 = new SqlConnection(Inicio.conexion2);
                                        await cn1.OpenAsync();
                                        SqlCommand cmd1 = new SqlCommand(sql, cn1);
                                        await cmd1.ExecuteReaderAsync();
                                        Accion.Text = "completando operacion.";
                                        if (await CargarPago5(DNI, SAP.Cobradores.Controles.V2.TarjetaElectronica.tarjeta, SAP.Cobradores.Controles.V2.TarjetaElectronica.codigocontrol, Convert.ToInt32(SAP.Inicio.Canal), SAP.Inicio.ID, Convert.ToInt32(iduser), Convert.ToDouble(SAP.Cobradores.RecaudacionV2.PromoTarjeta), SAP.Inicio.sede, Convert.ToDouble(SAP.Cobradores.RecaudacionV2.Tarjeta)) == true)
                                        {
                                            Accion.Text = "completando operacion..";
                                            if (await CargarPago6(DNI, SAP.Cobradores.Controles.V2.TarjetaElectronica.tarjeta, SAP.Cobradores.Controles.V2.TarjetaElectronica.codigocontrol, Convert.ToInt32(SAP.Inicio.Canal), SAP.Inicio.ID, Convert.ToInt32(iduser), Convert.ToDouble(SAP.Cobradores.RecaudacionV2.PromoTarjeta), SAP.Inicio.sede, Convert.ToDouble(SAP.Cobradores.RecaudacionV2.Tarjeta)) == true)
                                            {
                                                Accion.Text = "Imprimiendo ticket...";
                                                SAP.Cobradores.Controles.V2.FacturaPromo frm1 = new SAP.Cobradores.Controles.V2.FacturaPromo();
                                                frm1.Show();
                                                this.Close();
                                            }
                                            else
                                            {
                                                Panel.Visible = true;
                                                Loading.Visible = false;
                                                MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            }
                                        }
                                        else
                                        {
                                            Panel.Visible = true;
                                            Loading.Visible = false;
                                            MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }


                                    }
                                    else
                                    {
                                        Panel.Visible = true;
                                        Loading.Visible = false;
                                        MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                }


                            }
                            else
                            {
                                Panel.Visible = true;
                                Loading.Visible = false;
                                MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }


                        }
                        else
                        {
                            Panel.Visible = true;
                            Loading.Visible = false;
                            MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    }
                    else
                    {
                        Panel.Visible = true;
                        Loading.Visible = false;
                        MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

            }
            catch
            {
                Panel.Visible = true;
                Loading.Visible = false;
                MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private async Task<Boolean> ActualizarDNI(string id_user, string codigo)
        {
            string sql = "UPDATE Cliente SET CI=@codigo Where ID_Cliente=@cliente";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.Parameters.AddWithValue("cliente", id_user);
                await cmd.ExecuteReaderAsync();
                return true;
            }
        }
        private async Task<Boolean> CargarPago1(int id_user, string Forma, float monto, int sede, int cliente, string referencia)
        {
            string sql = "Insert into Ventas (ID_Usuario,ID_Cliente,FormaPago,Monto,Referencia,Sede,Fecha) Values (@iduser,@cliente,@forma,@monto,@referencia,@sede,SYSDATETIME())";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.Parameters.AddWithValue("forma", Forma);
                cmd.Parameters.AddWithValue("monto", monto);
                cmd.Parameters.AddWithValue("referencia", referencia);
                cmd.Parameters.AddWithValue("sede", sede);
                await cmd.ExecuteReaderAsync();
                return true;
            }
        }
        private async Task<string> Usuarioinfo(string cedula)
        {
            string code="";
            string sql = "Select ID_Cliente From Cliente Where CI=@cedula";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cedula", cedula);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    code = dr["ID_Cliente"].ToString();
                }
                dr.Close();
                return code;
            }
        }
        private void CargarPago2(string Tarjeta, string forma, string referencia, int usuario, string fecha, int cliente, int sede)
        {
            string sql = "Insert into PagoV2(CodigoTarjeta,FormaPago,Referencia,ID_Usuario,ID_Cliente,Fecha,ID_Sede) Values (@tarjeta,@forma,@referencia,@usuario,@cliente,@fecha,@sede);";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("tarjeta", Tarjeta);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("referencia", referencia);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.ExecuteReader();
                return;
            }
        }
        private async Task<Boolean> CargarCliente(string ci, string nombre, string saldo, int usuario, string direccion, string telefono, string correo, string tipo)
        {
            string sql = "Insert into Cliente(CI,Nombre,SaldoDisponible,ID_Usuario,Direccion,Telefono,FechaIngreso,Correo,TipoVehiculo,Exonerado) Values (@ci,@nombre,@saldo,@usuario,@direccion,@telefono,SYSDATETIME(),@correo,@tipo,'No')";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("ci", ci);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("saldo", saldo);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("direccion", direccion);
                cmd.Parameters.AddWithValue("telefono", telefono);
                cmd.Parameters.AddWithValue("correo", correo);
                cmd.Parameters.AddWithValue("tipo", tipo);
                await cmd.ExecuteReaderAsync();
                return true;
            }

        }
        private async Task<Boolean> CargarPago5(string cedula,string tarjeta,string control,int canal, string usuario, int cliente, double saldo, int sede, double costot)
        {
            string sql = "Insert into PrepagadoCanales (CI,NroTarjeta,NroControl,Fecha,Canal,ID_Usuario,ID_Cliente,Finalizado,SaldoInicial,Sede,CostoTarjeta) Values (@cedula,@tarjeta,@control,SYSDATETIME(),@canal,@usuario,@cliente,0,@saldo,@sede,@costot)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cedula", cedula);
                cmd.Parameters.AddWithValue("tarjeta", tarjeta);
                cmd.Parameters.AddWithValue("control", control);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.Parameters.AddWithValue("saldo", saldo);
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.Parameters.AddWithValue("costot", costot);
                await cmd.ExecuteReaderAsync();
                return true;
            }
        }
        private async Task<Boolean> CargarPago6(string cedula, string tarjeta, string control, int canal, string usuario, int cliente, double saldo, int sede, double costot)
        {
            string sql = "Insert into PrepagadoCanales (CI,NroTarjeta,NroControl,Fecha,Canal,ID_Usuario,ID_Cliente,Finalizado,SaldoInicial,Sede,CostoTarjeta) Values (@cedula,@tarjeta,@control,SYSDATETIME(),@canal,@usuario,@cliente,0,@saldo,@sede,@costot)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cedula", cedula);
                cmd.Parameters.AddWithValue("tarjeta", tarjeta);
                cmd.Parameters.AddWithValue("control", control);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.Parameters.AddWithValue("saldo", saldo);
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.Parameters.AddWithValue("costot", costot);
                await cmd.ExecuteReaderAsync();
                return true;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Confirmacion_Load(object sender, EventArgs e)
        {

        }
    }
}
