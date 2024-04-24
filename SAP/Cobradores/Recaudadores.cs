using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Cobradores
{
    public partial class Recaudadores : Form
    {
        double aperturo = Convert.ToDouble(SAP.Inicio.Apertura);
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
        public static String TipoVehiculo;
        public static String Nombre;
        public static String Tarifa;
        public static String Identificador;
        public static double recaudacion;
        public static String Estado = SAP.Inicio.Estado;
        public static String Boton1= "Desactivar";
        string fecha4 = DateTime.Now.AddDays(-1).ToString("d")+" 00:00:00";
        string clave;
        public Recaudadores()
        {
            InitializeComponent();
            this.Usuario.Text = SAP.Inicio.User + " " + SAP.Inicio.Apellido;
            this.Turno.Text = SAP.Inicio.Turno;
            this.Canal.Text = SAP.Inicio.Canal;
            this.Apertura.Text = string.Format("{0:n}", aperturo)+ " Bs.S";
            this.ESTATUS.Text = Estado;
            try
            {
                this.InformacionTarifas();
                recaudacion = SAP.Cobradores.Recaudadores.ConsultaRecaudacion(SAP.Inicio.ID);
                if (Estado=="Avance")
                {
                    Boton1 = "Activado";
                }
            }
            catch
            {
                
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
        private void Apertura_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1)
            {
                TipoVehiculo = "Liviano";
                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                this.Close();
                frm.Show();
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                TipoVehiculo = "Microbus";
                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                this.Close();
                frm.Show();
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                TipoVehiculo = "Autobus";
                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                this.Close();
                frm.Show();
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                TipoVehiculo = "Carga Liviana";
                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                this.Close();
                frm.Show();
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                TipoVehiculo = "2 Ejes";
                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                this.Close();
                frm.Show();
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                TipoVehiculo = "3 Ejes";
                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                this.Close();
                frm.Show();
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                TipoVehiculo = "4 Ejes";
                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                this.Close();
                frm.Show();
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                TipoVehiculo = "5 Ejes";
                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                this.Close();
                frm.Show();
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                TipoVehiculo = "6 Ejes o Mas";
                SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
                this.Close();
                frm.Show();
            }
           if (e.KeyCode == Keys.NumPad0)
           {
              
             }
            if (e.KeyCode == Keys.L)
            {
                try
                {
                    DialogResult result = MessageBox.Show("Confirmacion, para la solicitud de vaciado de caja", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        cajallena(Inicio.ID);
                        Estado = "Avance";
                        MessageBox.Show("Solicitud enviada correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Boton1 = "Activado";
                    }
                }
                catch
                {
                    MessageBox.Show("¡Error, del sistema por favor intente de nuevo!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //if (e.KeyCode == Keys.F12)
            //{
            //    try
            //    {
            //        DialogResult result = MessageBox.Show("¿Seguro, que desea cerrar sesión?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //        if (result == DialogResult.Yes)
            //        {
            //            if (EsValido(SAP.Inicio.ID))
            //            {
            //                CanalLibre(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal));
            //                CerrarCanal(DateTime.Now.AddMinutes(30).ToString(), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal));
            //                FinSession(SAP.Inicio.ID);
            //                ControlUser(Inicio.ID, DateTime.Now.ToString("G"));
            //                this.Close();
            //                Application.Exit();
            //            }
            //            else
            //            {
            //                CerrarCanal(DateTime.Now.AddMinutes(30).ToString(), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal));
            //                FinSession(SAP.Inicio.ID);
            //                ControlUser(Inicio.ID, DateTime.Now.ToString("G"));
            //                this.Close();
            //                Application.Exit();
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("¡Error,al intentar desconectarte del sistema por favor reintente de nuevo!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            if (e.KeyCode == Keys.R && Boton1 == "Activado")
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
        private void InformacionTarifas()
        {
            string sql = "Select ID_Vehiculo,Nombre,Tarifa From TipoVehiculos";
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

                }
                dr.Close();
                cn.Close();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "Liviano";
            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
            this.Close();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Hora.Text = DateTime.Now.ToString("G");

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Recaudado.Text = string.Format("{0:n}", recaudacion) + " Bs.S";
        }

        public static double ConsultaRecaudacion(string usuario)
        {
            Double Recaudador;
            String Tarifas;
            Recaudador = 0;
            DateTime dd = DateTime.Now;
            String Fecha;
            String Fecha1;
            Fecha = dd.ToString("dd/MM/yyyy") + " 00:00:00.000";
            Fecha1 = dd.ToString("dd/MM/yyyy") + " 23:59:00.000";
            string sql = "Select TipoVehiculos.Tarifa from TipoVehiculos inner join Pagos on TipoVehiculos.ID_Vehiculo = Pagos.ID_Vehiculo where Pagos.ID_Usuario=@Usuario and Pagos.Fecha between @fecha1 and @fecha2";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(Fecha));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(Fecha1));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Tarifas = dr["Tarifa"].ToString();
                    Recaudador = Recaudador + Convert.ToDouble(Tarifas);
                }
                dr.Close();
                return Recaudador;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "Microbus";
            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
            this.Close();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "Autobus";
            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
            this.Close();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "Carga Liviana";
            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
            this.Close();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "2 Ejes";
            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
            this.Close();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "3 Ejes";
            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
            this.Close();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "4 Ejes";
            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
            this.Close();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "5 Ejes";
            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
            this.Close();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TipoVehiculo = "6 Ejes o Mas";
            SAP.Cobradores.Controles.Pagos frm = new SAP.Cobradores.Controles.Pagos();
            this.Close();
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 9;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Confirmacion, para la solicitud de vaciado de caja", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    cajallena(Inicio.ID);
                    Estado = "Avance";
                    CargarSolicitud(Estado, DateTime.Now.ToString("G"),Convert.ToInt32(SAP.Inicio.ID));
                    MessageBox.Show("Solicitud enviada correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Boton1 = "Activado";
                }
            }
            catch
            {
                MessageBox.Show("¡Error, del sistema por favor intente de nuevo!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void CerrarCanal(string fecha, int usuario,int canal,string fecha1)
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
        private void timer3_Tick(object sender, EventArgs e)
        {
            ESTATUS.Text = Estado;
            if (Boton1=="Desactivar")
            {
                Reinicio.Enabled = false;
            }
            else
            {
                Reinicio.Enabled = true;
            }
        }
        private void CargarPago(int id_user, int id_vehiculo, string fecha, int canal)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal) Values (@iduser,@idvehiculo,@fecha,'Exonerado','',@canal)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.ExecuteReader();
                cn.Close();
                return;
            }
        }
        private void CargarSolicitud( string operacion, string fecha, int id_user)
        {
            string sql = "Insert into Solicitudes (ID_Solicitud,Operacion,Fecha,ID_Usuario) Values ('',@operacion,@fecha,@usuario)";
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

        private void button10_Click(object sender, EventArgs e)
        {
            SAP.Cobradores.Controles.Exonerados frm = new SAP.Cobradores.Controles.Exonerados();
            frm.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Seguro, que desea cerrar sesión?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    if (EsValido(SAP.Inicio.ID))
                    {
                        CanalLibre(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal));
                        CerrarCanal(DateTime.Now.AddMinutes(30).ToString(), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal),fecha4);
                        FinSession(SAP.Inicio.ID);
                        ControlUser(Inicio.ID, DateTime.Now.ToString("G"));
                        this.Close();
                        Application.Exit();
                    }
                    else
                    {
                        CerrarCanal(DateTime.Now.AddMinutes(30).ToString(), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal),fecha4);
                        FinSession(SAP.Inicio.ID);
                        ControlUser(Inicio.ID, DateTime.Now.ToString("G"));
                        this.Close();
                        Application.Exit();
                    }

                }
            }
            catch
            {
                MessageBox.Show("¡Error,al intentar desconectarte del sistema por favor reintente de nuevo!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Contraseña(6);
            if (clave == "Desconectar")
            {
                MessageBox.Show("Los sistemas Safvial estan en mantenimiento en este momento.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SAP.Inicio frm = new SAP.Inicio();
                frm.Show();
                this.Close();
            }
        }
        private void Contraseña(int id)
        {
            string sql = "Select Password From Operaciones Where ID=@id";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clave = dr["Password"].ToString();
                }
                dr.Close();
                cn.Close();
                return;
            }
        }
    }
}
