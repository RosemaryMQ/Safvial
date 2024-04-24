using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using SAP.Properties;
using System.Threading.Tasks;

namespace SAP.Cobradores
{
    public partial class RecaudacionV2 : Form
    {
        public static String Estado = SAP.Inicio.Estado;
        public static String TipoVehiculo;
        public static String Liviano;
        public static String IDLiviano;
        public static String Microbus;
        public static String IDMicrobus;
        public static String Autobus;
        public static String IDAutobus;
        public static String CargaLiviana;
        public static String IDCargaliviana;
        public static String ejes2;
        public static String IDejes2;
        public static String ejes3;
        public static String IDejes3;
        public static String ejes4;
        public static String IDejes4;
        public static String ejes5;
        public static String IDejes5;
        public static String ejes6;
        public static String IDejes6;
        public static double PromoTarjeta;
        public static double Tarjeta;
        public static double PromoAdicional;
        public static int vehiculo = 0;
        public static string com = (string)Settings.Default["Arduino"];
        public static int TipoTabulacion = 0;
        public bool ActualizarTarifas = false;
        public DateTime? FechaActualizacion = null;
        public RecaudacionV2()
        {
            InitializeComponent();
            this.Usuario.Text = SAP.Inicio.User + " " + SAP.Inicio.Apellido;
            label6.Text = Settings.Default["Factura"].ToString();
            if (SAP.Inicio.Turno == "1")
            {
                this.Turno.Text = "Diurno";
            }
            else if(SAP.Inicio.Turno == "2")
            {
                this.Turno.Text = "Nocturno";
            }
            else if (SAP.Inicio.Turno == "3")
            {
                this.Turno.Text = "Completo 1";
            }
            else if (SAP.Inicio.Turno == "4")
            {
                this.Turno.Text = "Completo 2";
            }
            else if (SAP.Inicio.Turno == "5")
            {
                this.Turno.Text = "Turno 1";
            }
            else if (SAP.Inicio.Turno == "6")
            {
                this.Turno.Text = "Turno 2";
            }
            else if (SAP.Inicio.Turno == "7")
            {
                this.Turno.Text = "Turno 3";
            }
            else if (SAP.Inicio.Turno == "8")
            {
                this.Turno.Text = "Turno 12h 00:00 - 12:00";
            }
            else if (SAP.Inicio.Turno == "9")
            {
                this.Turno.Text = "Turno 12h 12:00 - 23:59";
            }
            else
            {
                this.Turno.Text = "Turno No Detectado";
            }
            if (com!="0")
            {
                button12.Enabled = true;
                button13.Enabled = true;
            }
            this.Canal.Text = SAP.Inicio.Canal;
            this.Estatus.Text = "Operativo";
            this.InformacionTarifas();
        }
        private void InformacionTarifas()
        {
            string Nombre;
            string Tarifa;
            string Identificador;
            string sql = "Select ID_Vehiculo,Nombre,Tarifa,FechaVigencia,Disabled From TipoVehiculos Where Disabled <> 1 and FechaVigencia=(SELECT MAX(FechaVigencia) FROM TipoVehiculos WHERE Disabled <> 1)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Identificador = dr["ID_Vehiculo"].ToString();
                    Nombre = dr["Nombre"].ToString();
                    Tarifa = dr["Tarifa"].ToString();
                    if (Nombre == "Liviano")
                    {
                        Liviano = Tarifa;
                        IDLiviano = Identificador;
                    }
                    if (Nombre == "Microbus")
                    {
                        Microbus = Tarifa;
                        IDMicrobus = Identificador;
                    }
                    if (Nombre == "Autobus")
                    {
                        Autobus = Tarifa;
                        IDAutobus = Identificador;
                    }
                    if (Nombre == "Carga Liviana")
                    {
                        CargaLiviana = Tarifa;
                        IDCargaliviana = Identificador;
                    }
                    if (Nombre == "2 Ejes")
                    {
                        ejes2 = Tarifa;
                        IDejes2 = Identificador;
                    }
                    if (Nombre == "3 Ejes")
                    {
                        ejes3 = Tarifa;
                        IDejes3 = Identificador;
                    }
                    if (Nombre == "4 Ejes")
                    {
                        ejes4 = Tarifa;
                        IDejes4 = Identificador;
                    }
                    if (Nombre == "5 Ejes")
                    {
                        ejes5 = Tarifa;
                        IDejes5 = Identificador;
                    }
                    if (Nombre == "6 Ejes o Mas")
                    {
                        ejes6 = Tarifa;
                        IDejes6 = Identificador;
                    }
                    if (Nombre == "TarjetaPromo")
                    {
                        PromoTarjeta = Convert.ToDouble(Tarifa);
                    }
                    if (Nombre == "PrepagadaPromo")
                    {
                        Tarjeta = Convert.ToDouble(Tarifa);
                    }
                    if (Nombre == "Promo")
                    {
                        PromoAdicional = Convert.ToDouble(Tarifa);
                    }
                }
                dr.Close();
                cn.Close();
                return;
            }
        }
        private void FinSession(string usuario)
        {
            string sql = "Update Usuarios Set Estado='No Conectado' Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.ExecuteReader();
                cn.Close();
                return;
            }
        }
        private void ControlUser(string usuario, string fecha)
        {
            string sql = "Insert into ControlUsuario (ID_Usuario,Conexiones) values (@usuario,@fecha)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.ExecuteReader();
                cn.Close();
                return;
            }
        }

        private void button10_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0)
            {
                SAP.Cobradores.Controles.V2.TarjetaElectronica frm = new SAP.Cobradores.Controles.V2.TarjetaElectronica();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                TipoVehiculo = "Liviano";
                vehiculo = 1;
                SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                TipoVehiculo = "Microbus";
                vehiculo = 2;
                SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                TipoVehiculo = "Autobus";
                vehiculo = 3;
                SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                TipoVehiculo = "Carga Liviana";
                vehiculo = 4;
                SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                TipoVehiculo = "2 Ejes";
                vehiculo = 5;
                SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                TipoVehiculo = "3 Ejes";
                vehiculo = 6;
                SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                TipoVehiculo = "4 Ejes";
                vehiculo = 7;
                SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                TipoVehiculo = "5 Ejes";
                vehiculo = 8;
                SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                TipoVehiculo = "6 Ejes o Mas";
                vehiculo = 9;
                SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.L)
            {
                try
                {
                    DialogResult result = MessageBox.Show("Confirmacion, para la solicitud de vaciado de caja", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        cajallena(Inicio.ID);
                        Estatus.Text = "Avance";
                        MessageBox.Show("Solicitud enviada correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Autorizar.Enabled=true;
                    }
                }
                catch
                {
                    MessageBox.Show("¡Error, del sistema por favor intente de nuevo!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.KeyCode == Keys.R)
            {
                SAP.Inicio.acceso = 9;
                SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
                frm.Show();
            }
        }
        private void cajallena(string usuario)
        {
            string sql = "Update ControlRecaudadores Set Estado='Avance' Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.ExecuteReader();
                cn.Close();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "Liviano";
            vehiculo = 1;
            SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "Microbus";
            vehiculo = 2;
            SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "Autobus";
            vehiculo = 3;
            SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "Carga Liviana";
            vehiculo = 4;
            SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "2 Ejes";
            vehiculo = 5;
            SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "3 Ejes";
            vehiculo = 6;
            SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "4 Ejes";
            vehiculo = 7;
            SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
            frm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "5 Ejes";
            vehiculo = 8;
            SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
            frm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "6 Ejes o Mas";
            vehiculo = 9;
            SAP.Cobradores.Controles.V2.FormaPago frm = new SAP.Cobradores.Controles.V2.FormaPago();
            frm.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Seguro, que desea cerrar sesión Temporalmente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    FinSession(Inicio.ID);
                    ControlUser(Inicio.ID, DateTime.Now.ToString("G"));
                    this.Close();
                    SAP.Inicio frm = new SAP.Inicio();
                    frm.Show();
                }
            }
            catch
            {
                MessageBox.Show("¡Error,al intentar desconectarte del sistema por favor reintente de nuevo!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Confirmacion, para la solicitud de vaciado de caja", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    cajallena(Inicio.ID);
                    //CargarSolicitud(Estado, DateTime.Now.ToString("G"), Convert.ToInt32(SAP.Inicio.ID));
                    SAP.Inicio.Estado = "Avance Solicitado";
                    Estatus.Text = SAP.Inicio.Estado;
                    Autorizar.Enabled = true;
                    MessageBox.Show("Solicitud enviada correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("¡Error, del sistema por favor intente de nuevo!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarSolicitud(string operacion, string fecha, int id_user)
        {
            string sql = "Insert into Solicitudes (Operacion,Fecha,ID_Usuario) Values (@operacion,@fecha,@usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("operacion", operacion);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("usuario", id_user);
                cmd.ExecuteReader();
                cn.Close();
                return;
            }
        }

        private void Autorizar_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 9;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Seguro, que desea terminar su jornada?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    if (EsValido(SAP.Inicio.ID))
                    {
                        CanalLibre(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal));
                        CerrarCanal(DateTime.Now.AddMinutes(30).ToString(), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), SAP.Inicio.fechaaperturaS);
                        FinSession(SAP.Inicio.ID);
                        ControlUser(Inicio.ID, DateTime.Now.ToString("G"));
                        this.Close();
                        SAP.Inicio frm = new SAP.Inicio();
                        frm.Show();
                    }
                    else
                    {
                        CerrarCanal(DateTime.Now.AddMinutes(30).ToString(), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), SAP.Inicio.fechaaperturaS);
                        FinSession(SAP.Inicio.ID);
                        ControlUser(Inicio.ID, DateTime.Now.ToString("G"));
                        this.Close();
                        SAP.Inicio frm = new SAP.Inicio();
                        frm.Show();
                    }

                }
            }
            catch
            {
                MessageBox.Show("¡Error,al intentar desconectarte del sistema por favor reintente de nuevo!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool EsValido(string usuario)
        {
            string sql = "Select ID_Usuario From ControlRecaudadores Where ID_Usuario = @usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
       
        private void CerrarCanal(string fecha, int usuario, int canal, string fecha1)
        {
            string sql = "Update Recaudadore Set FechaFin=@fechacierre,Estatus='Pendiente' Where ID_Usuario=@usuario and Canal=@canal AND Fecha Between @fecha AND @fecha1";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechacierre", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha1));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(fecha));
                cmd.ExecuteReader();
                cn.Close();
                return;
            }
        }
        private void CanalLibre(int usuario, int canal)
        {
            string sql = "Update ControlRecaudadores Set Estado='Libre', ID_Usuario='1' Where ID_Usuario=@usuario and Canal=@canal";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.ExecuteReader();
                cn.Close();
                return;
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            Estatus.Text = SAP.Inicio.Estado;
            try
            {
                FechaActualizacion = await ValidarTarifas();
                if(FechaActualizacion != null)
                {
                   await ActualizarTarifasNuevas();
                }
            }
            catch
            {

            }
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                label6.Text = Settings.Default["Factura"].ToString();
                Hora.Text = DateTime.Now.ToString("G");
            }
            catch
            {

            }
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
           SAP.Cobradores.Controles.V2.TarjetaElectronica frm = new SAP.Cobradores.Controles.V2.TarjetaElectronica();
           frm.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 22;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 23;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
        }
        private void CargarPago2(int id_user, int id_vehiculo, string fecha, int canal, int turno)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal,Turno) Values (@iduser,@idvehiculo,@fecha,'Exonerado','NULL',@canal,@turno)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.ExecuteReader();
                cn.Close();
                return;
            }
        }

        private async void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!await ValidarEstado(SAP.Inicio.ID))
                {
               
                    MessageBox.Show("La sesion ha sido finalizada por tesoreria", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("La sesion se cerrara a continuación, gracias por usar sistemas SAFVIAL.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CanalLibre(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal));
                    CerrarCanal(DateTime.Now.AddMinutes(30).ToString(), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), SAP.Inicio.fechaaperturaS);
                    FinSession(SAP.Inicio.ID);
                    ControlUser(Inicio.ID, DateTime.Now.ToString("G"));
                    SAP.Inicio frm = new SAP.Inicio();
                    frm.Show();
                    this.Close();
                }
            }
            catch
            {

            }
        }
        private async Task<bool> ValidarEstado(string usuario)
        {
            string sql = "Select * From Turno Where ID_Usuario=@usuario AND Finalizado=0";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                int val = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                return !(val == 0);
            }
        }
        private async Task<DateTime?> ValidarTarifas()
        {
            DateTime? fecha = null;
            string sql = "Select ID_Vehiculo,Nombre,Tarifa,FechaVigencia,Disabled From TipoVehiculos Where FechaVigencia=(SELECT MIN(FechaVigencia) FROM TipoVehiculos WHERE Disabled = 1);";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var data = dr["FechaVigencia"].ToString();
                    if (data != "" && data != null)
                    {
                        fecha = Convert.ToDateTime(data);
                    }
                    
                }
            }
            return fecha;
        }

        private async Task ActualizarTarifasNuevas()
        {
            DateTime? fechaDbo = null;
            string sql = "select sysdatetime() as Fecha";
          
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    fechaDbo = Convert.ToDateTime(dr["Fecha"]);
                }
                cn.Close();
                if (fechaDbo >= FechaActualizacion)
                {
                    await this.ProcesarActualizacion();
                }
            }
         
        }

        private async Task ProcesarActualizacion()
        {
            string sql2 = "update TipoVehiculos set Disabled = 0 where FechaVigencia = @fecha";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd2 = new SqlCommand(sql2, cn);
                cmd2.Parameters.AddWithValue("fecha", FechaActualizacion);
                await cmd2.ExecuteNonQueryAsync();
                cn.Close();
                this.InformacionTarifas();
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 25;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.Show();
        }
    }
}
