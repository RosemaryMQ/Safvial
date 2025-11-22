using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Windows.Forms;
using SAP.Properties;

namespace SAP
{
    public partial class Inicio : Form
    {
        public static String conexion;
        public static String conexion2;
        public static String conexion4;
        public static String WEB;
        public static String conexion3;
        public static String guacara;
        public static String entrada;
        public static String PeajeNombre = "";
        public static String Membrete = "";
        public static String PiePagina = "";
        public static String Logo = "";
        public static String User = "";
        public static String Tipo = "";
        public static String Apellido = "";
        public static String Perfil = "";
        public static String ID = "";
        public static String Turno = "";
        public static String Canal = "";
        public static String Apertura = "";
        public static String Estado = "Operativo";
        public static int op = 0;
        public static string fecha;
        public static String peaje;
        public static String apertura;
        public static int sede = (int)Settings.Default["Sede"];
        DateTime system;
        DateTime system1;
        string hora;
        String Estacion = Convert.ToString((int)Settings.Default["Canal"]);
        public static int acceso = 0;
        public static string clave;
        public static string master;
        public static string interfaz = (string)Settings.Default["Tipo"];
        public static string barrera = "";
        public static string fechaaperturaS = "";
        int canalUser = 0;
        public Inicio()
        {
            ObtenerConfiguracion();
        }
        private void ObtenerConfiguracion()
        {
            bool cambios = false;
            try
            {
                //Validar si existe el archivo de configuracion
                if (File.Exists(Directory.GetCurrentDirectory() + @"/AutoConfig.txt"))
                {
                    var line = File.ReadAllText(Directory.GetCurrentDirectory() + @"/AutoConfig.txt");
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                    var campos = new List<string>() { "(URLSAP)", "(DBOSAP)", "(USERSAP)", "(PASSSAP)", "(URLPREPAGADO)", "(DBOPREPAGADO)", "(USERPREPAGADO)", "(PASSPREPAGADO)", "(URLWEB)", "(DBOWEB)", "(USERWEB)", "(PASSWEB)", "(URLSEDE1)", "(DBOSEDE1)", "(USERSEDE1)", "(PASSSEDE1)", "(URLSEDE2)", "(DBOSEDE2)", "(USERSEDE2)", "(PASSSEDE2)", "(CANAL)", "(INTERFACE)", "(SEDE)", "(ARDUINO)", "(LOGO)" };
                    foreach (var item in campos)
                    {
                        int StartIndex = line.IndexOf(item, 0) + item.Length;
                        int EndIndex = line.Substring(StartIndex).IndexOf("(");
                        switch (item)
                        {
                            case "(URLSAP)":
                                Settings.Default["IP1"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(DBOSAP)":
                                Settings.Default["dbo1"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(USERSAP)":
                                Settings.Default["User1"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(PASSSAP)":
                                Settings.Default["Pass1"] = line.Substring(StartIndex, EndIndex).Trim();
                                config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = "Data Source =" + Settings.Default["IP1"] + "; Initial Catalog = " + Settings.Default["dbo1"] + "; User ID =" + Settings.Default["User1"] + "; Persist Security Info=True; Password =" + Settings.Default["Pass1"] + ";Connect Timeout=15;";
                                if (config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString != (string)Settings.Default["SAP"])
                                {
                                    cambios = true;
                                }
                               
                                break;
                            case "(URLPREPAGADO)":
                                Settings.Default["IP2"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(DBOPREPAGADO)":
                                Settings.Default["dbo2"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(USERPREPAGADO)":
                                Settings.Default["User2"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(PASSPREPAGADO)":
                                Settings.Default["Pass2"] = line.Substring(StartIndex, EndIndex).Trim();
                                config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.Prepagado"].ConnectionString = "Data Source =" + Settings.Default["IP2"] + "; Initial Catalog = " + Settings.Default["dbo2"] + "; User ID =" + Settings.Default["User2"] + ";  Persist Security Info=True; Password =" + Settings.Default["Pass2"] + ";Connect Timeout=15;";
                                config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.ConexionPSC"].ConnectionString = "Data Source =" + Settings.Default["IP1"] + "; Initial Catalog = " + Settings.Default["dbo2"] + "; User ID =" + Settings.Default["User1"] + "; Persist Security Info=True; Password =" + Settings.Default["Pass1"] + ";Connect Timeout=15;";
                                if (config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.Prepagado"].ConnectionString != (string)Settings.Default["Prepagado"])
                                {
                                    cambios = true;
                                }
                                break;
                            case "(URLWEB)":
                                Settings.Default["IP3"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(DBOWEB)":
                                Settings.Default["dbo3"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(USERWEB)":
                                Settings.Default["User3"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(PASSWEB)":
                                Settings.Default["Pass3"] = line.Substring(StartIndex, EndIndex).Trim();
                                config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SafvialWeb"].ConnectionString = "Data Source =" + Settings.Default["IP3"] + "; Initial Catalog = " + Settings.Default["dbo3"] + "; User ID =" + Settings.Default["User3"] + ";  Persist Security Info=True; Password =" + Settings.Default["Pass3"] + ";Connect Timeout=15";
                                if (config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SafvialWeb"].ConnectionString != (string)Settings.Default["SafvialWeb"])
                                {
                                    cambios = true;
                                }
                                break;
                            case "(URLSEDE1)":
                                Settings.Default["IP5"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(DBOSEDE1)":
                                Settings.Default["dbo5"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(USERSEDE1)":
                                Settings.Default["User5"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(PASSSEDE1)":
                                Settings.Default["Pass5"] = line.Substring(StartIndex, EndIndex).Trim();
                                config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.Sede1"].ConnectionString = "Data Source =" + Settings.Default["IP5"] + "; Initial Catalog = " + Settings.Default["dbo5"] + "; User ID =" + Settings.Default["User5"] + ";  Persist Security Info=True; Password =" + Settings.Default["Pass5"] + ";Connect Timeout=15;";
                                if (config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.Sede1"].ConnectionString != (string)Settings.Default["Sede1"])
                                {
                                    cambios = true;
                                }
                                break;
                            case "(URLSEDE2)":
                                Settings.Default["IP4"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(DBOSEDE2)":
                                Settings.Default["dbo4"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(USERSEDE2)":
                                Settings.Default["User4"] = line.Substring(StartIndex, EndIndex).Trim();
                                break;
                            case "(PASSSEDE2)":
                                Settings.Default["Pass4"] = line.Substring(StartIndex, EndIndex).Trim();
                                config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP2"].ConnectionString = "Data Source =" + Settings.Default["IP4"] + "; Initial Catalog = " + Settings.Default["dbo4"] + "; User ID =" + Settings.Default["User4"] + ";  Persist Security Info=True; Password =" + Settings.Default["Pass4"] + ";Connect Timeout=15;";
                                config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP2P"].ConnectionString = "Data Source =" + Settings.Default["IP4"] + "; Initial Catalog = " + Settings.Default["dbo4"] + "; User ID =" + Settings.Default["User4"] + ";  Persist Security Info=True; Password =" + Settings.Default["Pass4"] + ";Connect Timeout=15;";
                                if (config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP2"].ConnectionString != (string)Settings.Default["SAP2"])
                                {
                                    cambios = true;
                                }
                                if (config.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP2P"].ConnectionString != (string)Settings.Default["SAP2P"])
                                {
                                    cambios = true;
                                }
                                break;
                            case "(CANAL)":
                                Settings.Default["Canal"] = Convert.ToInt32(line.Substring(StartIndex, EndIndex).Trim());
                                if (Convert.ToInt32(line.Substring(StartIndex, EndIndex).Trim()) != (int)Settings.Default["Canal"])
                                {
                                    cambios = true;
                                }
                                break;
                            case "(INTERFACE)":
                                Settings.Default["Tipo"] = line.Substring(StartIndex, EndIndex).Trim();
                                if (line.Substring(StartIndex, EndIndex).Trim() != (string)Settings.Default["Tipo"])
                                {
                                    cambios = true;
                                }
                                break;
                            case "(SEDE)":
                                Settings.Default["Sede"] = Convert.ToInt32(line.Substring(StartIndex, EndIndex).Trim());
                                if (Convert.ToInt32(line.Substring(StartIndex, EndIndex).Trim()) != (int)Settings.Default["Sede"])
                                {
                                    cambios = true;
                                }
                                break;
                            case "(ARDUINO)":
                                Settings.Default["Arduino"] = line.Substring(StartIndex, EndIndex).Trim();
                                if (line.Substring(StartIndex, EndIndex).Trim() != (string)Settings.Default["Arduino"])
                                {
                                    cambios = true;
                                }
                                break;
                            case "(LOGO)":
                                Settings.Default["Logo"] = line.Substring(StartIndex, EndIndex).Trim();
                                if (line.Substring(StartIndex, EndIndex).Trim() != (string)Settings.Default["Logo"])
                                {
                                    cambios = true;
                                }
                                break;
                        }
                    }
                    config.Save(ConfigurationSaveMode.Modified, true);
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
                else
                {
                   DialogResult result =  MessageBox.Show("El archivo de configuración no se encuentra en los directorios base:"+ Directory.GetCurrentDirectory(), "Configurador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        Environment.Exit(0);
                        Application.Exit();
                    }
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "TXT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cambios == false)
            {               
                InitializeComponent();
                conexion = (string)Settings.Default["SAP"];
                conexion2 = (string)Settings.Default["Prepagado"];
                conexion4 = (string)Settings.Default["SAP2P"];
                WEB = (string)Settings.Default["SafvialWeb"];
                conexion3 = (string)Settings.Default["SAP2"];
                guacara = (string)Settings.Default["Sede1"];
                entrada = (string)Settings.Default["SAP2"];
                Version.Text = "Version del SAP: " + Application.ProductVersion;
                try
                {
                    timer2.Enabled = true;
                    ConexionConSedePrincipal(1);
                    Contrasena(6);
                    if (clave == "Desconectar")
                    {
                        estatus.Text = "Sistema en Mantenimiento";
                    }
                    else if (clave != "Desconectar")
                    {
                        estatus.Text = "En Linea";
                    }
                    else
                    {
                        estatus.Text = "Sin Conexion";
                    }
                    Settings.Default["Factura"] = 0;
                    Settings.Default.Save();
                    
                }
                catch
                {
                    timer2.Enabled = false;
                    estatus.Text = "Sin Conexion";
                }
            }
            else
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private bool EsValido(string usuario, string password)
        {
            string sql = "SELECT * FROM Usuarios WHERE Nickname = @usuario AND Contrasena = @clave";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("clave", password);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void Usuarioinfo(string usuario)
        {
            string sql = "Select TOP 1 Usuarios.ID_Usuario,Usuarios.Perfil,Usuarios.Nombre,Usuarios.Apellido,Usuarios.ID_Peaje,Turno.Turno,Turno.Fecha From Usuarios INNER JOIN Turno ON Usuarios.ID_Usuario=Turno.ID_Usuario Where Nickname=@usuario AND Finalizado=0  ORDER BY Turno.ID DESC";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ID = dr["ID_Usuario"].ToString();
                    Tipo = dr["Perfil"].ToString();
                    User = dr["Nombre"].ToString();
                    Apellido = dr["Apellido"].ToString();
                    Turno = dr["Turno"].ToString();
                    peaje = dr["ID_Peaje"].ToString();
                    fechaaperturaS = dr["Fecha"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void Usuarioinfo1(string usuario)
        {
            string sql = "Select TOP 1 Usuarios.ID_Usuario,Usuarios.Perfil,Usuarios.Nombre,Usuarios.Apellido,Usuarios.ID_Peaje,Usuarios.Turno From Usuarios Where Nickname=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ID = dr["ID_Usuario"].ToString();
                    Tipo = dr["Perfil"].ToString();
                    User = dr["Nombre"].ToString();
                    Apellido = dr["Apellido"].ToString();
                    Turno = dr["Turno"].ToString();
                    peaje = dr["ID_Peaje"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void Contrasena(int id)
        {
            string sql = "Select Operaciones.Password From Operaciones Where Operaciones.ID=@id";
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
                return;
            }
        }
        private void ConexionConSedePrincipal(int id)
        {
            string sql = "Select Nombre From Peaje Where ID_Peaje=@id";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {  
                   PeajeNombre = dr["Nombre"].ToString();
                   SedeConexion.Text = "Conectado a la sede: "+dr["Nombre"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void Barreras(int id)
        {
            string sql = "Select Operaciones.Password From Operaciones Where Operaciones.ID=@id";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    barrera = dr["Password"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void FechaSistema()
        {
            string sql = "SELECT SYSDATETIME() as Fecha;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    system = Convert.ToDateTime(dr["Fecha"]);
                }
                dr.Close();
                return;
            }
        }
        private void Recaudadorinfo(string usuario,int canal)
        {
            string sql = "Select MontoApertura,Estado,Fecha From ControlRecaudadores Where ID_Usuario=@Id AND Canal=@canal";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("Id", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Apertura = dr["MontoApertura"].ToString();
                    Estado = dr["Estado"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void HoraConexion(string usuario)
        {
            string sql = "Update Usuarios Set Estado='Conectado' Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.ExecuteReader();
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
                return;
            }
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                interfaz = (string)Settings.Default["Tipo"];
                conexion = (string)Settings.Default["SAP"];
                conexion2 = (string)Settings.Default["Prepagado"];
                conexion4 = (string)Settings.Default["SAP2"];
                WEB = (string)Settings.Default["SafvialWeb"];
                conexion3 = (string)Settings.Default["SAP2"];
                guacara = (string)Settings.Default["SAP"];
                entrada = (string)Settings.Default["SAP2"];
                sede = (int)Settings.Default["Sede"];
                Estacion = Convert.ToString((int)Settings.Default["Canal"]);
                Canal = Convert.ToString((int)Settings.Default["Canal"]);
                Contrasena(6);
                this.FechaSistema();
                system1 = system;
                if (DateTime.Now > system.AddMinutes(-5) && DateTime.Now < system1.AddHours(8))
                { 
                if (clave != "Desconectar")
                {
                    timer2.Enabled = false;
                    if (nickname.Text != "" && contrasena.Text != "")
                    {
                        try
                        {
                            if (EsValido(nickname.Text, contrasena.Text))
                            {
                                InfoPeaje(1);
                                Usuarioinfo1(nickname.Text);
                                HoraConexion(ID);
                                ControlUser(ID, hora);
                                    if (interfaz=="Administrador" && Tipo == "Administrador")
                                    {
                                        this.Contrasena(4);
                                        MessageBox.Show("Bienvenido a Sistemas SAFVIAL: " + User + " " + Apellido, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        nickname.Text = "";
                                        contrasena.Text = "";
                                        SAP.Tesoreria.TesoreriaV2 frm = new SAP.Tesoreria.TesoreriaV2();
                                        frm.Show();
                                    }
                                    else if (interfaz == "Recaudador" && Tipo == "Recaudador")
                                    {
                                        Usuarioinfo(nickname.Text);
                                        this.Contrasena(3);
                                        this.IngresoUserC(ID);
                                        if (ValidarIngresos(ID))
                                        {
                                            if (!ValidarCanal(ID))
                                            {
                                                if (ID != "")
                                                {
                                                    this.avances(Convert.ToInt32(ID), Convert.ToInt32(Canal));
                                                    this.IngresoCanal(ID, "0", Convert.ToDateTime(fechaaperturaS), Estacion, DateTime.Now, Convert.ToInt32(Turno));
                                                    IngresoCanal1(ID, "0", DateTime.Now, Convert.ToInt32(peaje), Estacion);
                                                    MessageBox.Show("Bienvenido a Sistemas SAFVIAL: " + User + " " + Apellido, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    nickname.Text = "";
                                                    contrasena.Text = "";
                                                    Cobradores.RecaudacionV2 frm2 = new Cobradores.RecaudacionV2();
                                                    frm2.Show();
                                                    this.Hide();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Error interno!,intente nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else if (canalUser == Convert.ToInt32(Estacion))
                                            {
                                                IngresoCanal1(ID, "0", DateTime.Now, Convert.ToInt32(peaje), Estacion);
                                                MessageBox.Show("Bienvenido a Sistemas SAFVIAL: " + User + " " + Apellido, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                nickname.Text = "";
                                                contrasena.Text = "";
                                                Cobradores.RecaudacionV2 frm2 = new Cobradores.RecaudacionV2();
                                                frm2.Show();
                                                this.Hide();
                                            }
                                            else
                                            {
                                                MessageBox.Show("El usuario que esta intentando ingresar esta siendo usado en el canal:"+canalUser+".", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                nickname.Text = "";
                                                contrasena.Text = "";
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("El usuario que esta intentando ingresar no esta aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            nickname.Text = "";
                                            contrasena.Text = "";
                                        }


                                    }
                                    else if (interfaz=="Cobrador" && Tipo == "Cobrador")
                                    {
                                        this.Contrasena(2);
                                        MessageBox.Show("Bienvenido a Sistemas SAFVIAL: " + User + " " + Apellido, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        nickname.Text = "";
                                        contrasena.Text = "";
                                        SAP.Recaudadores.PrepagadoV2 frm = new SAP.Recaudadores.PrepagadoV2();
                                        frm.Show();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Disculpe no puede entrar en esta interfaz desde esta estacion de trabajo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        nickname.Text = "";
                                        contrasena.Text = "";
                                    }
                            }
                            else
                            {
                                MessageBox.Show("Credenciales no válidas, vuelva a ingresar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                nickname.Text = "";
                                contrasena.Text = "";

                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error, al intentar ingresar al sistema por favor intente nuevamente  o verifique su conexion a internet", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Disculpe, para poder ingresar debe introducir el Usuario y Contrasena", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nickname.Text = "";
                        contrasena.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Los sistemas Safvial estan en mantenimiento en este momento.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                }
                else
                {
                    MessageBox.Show("Por favor, verifique la hora y fecha del computador.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                nickname.Select();
                nickname.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hora = DateTime.Now.ToString("G");
        }

        private void nickname_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                Contrasena(6);
                if (clave == "Desconectar")
                {
                    estatus.Text = "Sistema en Mantenimiento";
                }
                else
                {
                    estatus.Text = "En Linea";
                }
            }
            catch
            {
                timer2.Enabled = false;
                estatus.Text = "Sin Conexion";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            interfaz = (string)Settings.Default["Tipo"];
            conexion = (string)Settings.Default["SAP"];
            conexion2 = (string)Settings.Default["Prepagado"];
            conexion4 = (string)Settings.Default["SAP2"];
            WEB = (string)Settings.Default["SafvialWeb"];
            conexion3 = (string)Settings.Default["SAP2"];
            guacara = (string)Settings.Default["SAP"];
            entrada = (string)Settings.Default["SAP2"];
            sede = (int)Settings.Default["Sede"];
            Estacion = Convert.ToString((int)Settings.Default["Canal"]);
            Canal = Convert.ToString((int)Settings.Default["Canal"]);
            Contrasena(6);
            this.FechaSistema();
            system1 = system;
            if (DateTime.Now > system.AddMinutes(-5) && DateTime.Now < system1.AddHours(8))
            {
                if (clave != "Desconectar")
                {
                    timer2.Enabled = false;
                    if (nickname.Text != "" && contrasena.Text != "")
                    {
                        try
                        {
                            if (EsValido(nickname.Text, contrasena.Text))
                            {
                                InfoPeaje(1);
                                Usuarioinfo1(nickname.Text);
                                HoraConexion(ID);
                                ControlUser(ID, hora);
                                if (interfaz == "Administrador" && Tipo == "Administrador")
                                {
                                    this.Contrasena(4);
                                    MessageBox.Show("Bienvenido a Sistemas SAFVIAL: " + User + " " + Apellido, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Hide();
                                    nickname.Text = "";
                                    contrasena.Text = "";
                                    SAP.Tesoreria.TesoreriaV2 frm = new SAP.Tesoreria.TesoreriaV2();
                                    frm.Show();
                                }
                                else if (interfaz == "Recaudador" && Tipo == "Recaudador")
                                {
                                    Usuarioinfo(nickname.Text);
                                    this.Contrasena(3);
                                    this.IngresoUserC(ID);
                                    if (ValidarIngresos(ID))
                                    {
                                        if (!ValidarCanal(ID))
                                        {
                                            if (ID != "")
                                            {
                                                this.avances(Convert.ToInt32(ID), Convert.ToInt32(Canal));
                                                this.IngresoCanal(ID, "0", Convert.ToDateTime(fechaaperturaS), Estacion, DateTime.Now, Convert.ToInt32(Turno));
                                                IngresoCanal1(ID, "0", DateTime.Now, Convert.ToInt32(peaje), Estacion);
                                                MessageBox.Show("Bienvenido a Sistemas SAFVIAL: " + User + " " + Apellido, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                nickname.Text = "";
                                                contrasena.Text = "";
                                                Cobradores.RecaudacionV2 frm2 = new Cobradores.RecaudacionV2();
                                                frm2.Show();
                                                this.Hide();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Error interno!,intente nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else if (canalUser == Convert.ToInt32(Estacion))
                                        {
                                            IngresoCanal1(ID, "0", DateTime.Now, Convert.ToInt32(peaje), Estacion);
                                            MessageBox.Show("Bienvenido a Sistemas SAFVIAL: " + User + " " + Apellido, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            nickname.Text = "";
                                            contrasena.Text = "";
                                            Cobradores.RecaudacionV2 frm2 = new Cobradores.RecaudacionV2();
                                            frm2.Show();
                                            this.Hide();
                                        }
                                        else
                                        {
                                            MessageBox.Show("El usuario que esta intentando ingresar esta siendo usado en el canal:" + canalUser + ".", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            nickname.Text = "";
                                            contrasena.Text = "";
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("El usuario que esta intentando ingresar no esta aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        nickname.Text = "";
                                        contrasena.Text = "";
                                    }


                                }
                                else if (interfaz == "Cobrador" && Tipo == "Cobrador")
                                {
                                    this.Contrasena(2);
                                    MessageBox.Show("Bienvenido a Sistemas SAFVIAL: " + User + " " + Apellido, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Hide();
                                    nickname.Text = "";
                                    contrasena.Text = "";
                                    SAP.Recaudadores.PrepagadoV2 frm = new SAP.Recaudadores.PrepagadoV2();
                                    frm.Show();

                                }
                                else
                                {
                                    MessageBox.Show("Disculpe no puede entrar en esta interfaz desde esta estacion de trabajo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    nickname.Text = "";
                                    contrasena.Text = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Credenciales no válidas, vuelva a ingresar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                nickname.Text = "";
                                contrasena.Text = "";

                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error, al intentar ingresar al sistema por favor intente nuevamente  o verifique su conexion a internet", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Disculpe, para poder ingresar debe introducir el Usuario y Contrasena", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nickname.Text = "";
                        contrasena.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Los sistemas Safvial estan en mantenimiento en este momento.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, verifique la hora y fecha del computador.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            nickname.Select();
            nickname.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 19;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
        }

        //Aperturas de usuarios
        private void IngresoUserC(string usuario)
        {
            string sql = "Select ControlRecaudadores.Canal From ControlRecaudadores Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    canalUser = Convert.ToInt32(dr["Canal"]);
                }
                dr.Close();
                return;
            }
        }
        private bool ValidarCanal(string usuario)
        {
            string sql = "Select ControlRecaudadores.Canal From ControlRecaudadores Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void InfoPeaje(int sede)
        {
            string sql = "Select * From Peaje Where ID_Peaje = @sede";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("sede", sede);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Membrete = dr["Membrete"].ToString();
                    Logo = dr["Logo"].ToString();
                    PeajeNombre = dr["Nombre"].ToString();
                    //PiePagina = dr["PiePagina"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private bool ValidarCanal(string usuario, string canal)
        {
            string sql = "Select ControlRecaudadores.Canal From ControlRecaudadores Where ID_Usuario=@usuario and Canal=@canal";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }

        
        private bool ValidarIngresos(string usuario)
        {
            string sql = "Select TOP 1 * From Turno Where ID_Usuario=@usuario AND Finalizado=0";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void IngresoCanal(string id, string monto, DateTime fecha, string canals, DateTime fecha2, int turno)
        {
            string sql = "Insert into Recaudadore (ID_Usuario,Canal,Fecha,MontoApertura,ID_Peaje,FechaFin,Estatus,Turno) Values (@id,@canals,@fecha,@monto,@peaje,@fecha2,'Pendiente',@turno)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", Convert.ToInt32(id));
                cmd.Parameters.AddWithValue("canals", Convert.ToInt32(canals));
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("monto", monto);
                cmd.Parameters.AddWithValue("peaje", Convert.ToInt32(SAP.Inicio.peaje));
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.ExecuteReader();
                return;
            }
        }
        private void IngresoCanal1(string id, string monto, DateTime fecha, int numero, string canals)
        {
            string sql = "Update ControlRecaudadores Set ID_Usuario=@id, Fecha=@fecha, MontoApertura=@monto, Estado='Operativo',PDV=@numero Where Canal=@canals and ID_Peaje=@peaje";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", Convert.ToInt32(id));
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("monto", monto);
                cmd.Parameters.AddWithValue("numero", numero);
                cmd.Parameters.AddWithValue("canals", Convert.ToInt32(canals));
                cmd.Parameters.AddWithValue("peaje", Convert.ToInt32(SAP.Inicio.peaje));
                cmd.ExecuteReader();
                return;
            }
        }
        private void avances(int usuario, int canal)
        {
            string sql = "Insert into Avances (ID_Usuario,Canal,Fecha) Values (@usuario,@canal,SYSDATETIME())";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.ExecuteReader();
                return;
            }
        }

        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
        }
    }
}
