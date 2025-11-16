using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles
{
    public partial class AperturaV2 : Form
    {
        String CedulaAux;
        String ID_Usuario;
        String Fecha;
        String EstadoCanal;
        String Perfil;
        String ID2;
        String canal1;
        String Apertura;
        String Fecha2;
        String CanalP="";
        string fecha4 = DateTime.Now.AddDays(-1).ToString("d") + " 00:00:00";
        int turnos=0;
        int idUser = 0;
        string control;
        public AperturaV2()
        {
            InitializeComponent();
        }

        private void MontoApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Canal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }
        private void AperturaUser(int usuario, int turno)
        {
            string sql = "Insert into Turno (ID_Usuario,Turno,Finalizado,Fecha) Values (@usuario,@turno,0,CONVERT(DATETIME2(0),SYSDATETIME()))";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.ExecuteReader();
                return;
            }
        }


        public int NewAperturaUser(int usuario, int turno)
        {
            // 1. Modificar la consulta SQL:
            //    Agregar "; SELECT SCOPE_IDENTITY();" al final
            //    Esto hará que la consulta devuelva el ID recién insertado.
            string sql = "INSERT INTO Turno (ID_Usuario, Turno, Finalizado, Fecha) " +
                         "VALUES (@usuario, @turno, 0, CONVERT(DATETIME2(0), SYSDATETIME()));" +
                         "SELECT SCOPE_IDENTITY();";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@turno", turno);

                // 2. Usar ExecuteScalar() en lugar de ExecuteReader():
                //    ExecuteScalar() es ideal cuando se espera un solo valor (como un ID).
                //    Devuelve el valor de la primera columna de la primera fila.
                object result = cmd.ExecuteScalar();

                // 3. Verificar el resultado y convertirlo a entero (int):
                if (result != null && result != DBNull.Value)
                {
                    // SCOPE_IDENTITY() devuelve un tipo decimal, así que lo convertimos a int.
                    return Convert.ToInt32(result);
                }
                else
                {
                    // En caso de que el insert falle o no se obtenga el ID
                    throw new Exception("No se pudo obtener el ID de la fila insertada.");
                    // O puedes retornar 0 o -1 si prefieres un valor que indique error/falla.
                    // return -1;
                }
            }
        }





        private bool ValidarApertura(int usuario, int turno)
        {
            string sql = "SELECT * FROM Turno WHERE ID_Usuario = @usuario AND Turno=@turno AND Finalizado=0";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("turno", turno);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void Canal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (NombreOperador.Text != "" && NombreOperador.Text != "Recaudador No Registrado" && PDV.Text!="" && turnos>0)
                {
                    if (Perfil== "Recaudador" || Perfil =="RECAUDADOR")
                    {
                        try
                        {
                            if (!ValidarApertura(Convert.ToInt32(ID_Usuario), turnos))
                            {
                                int idUser = NewAperturaUser(Convert.ToInt32(ID_Usuario), turnos);
                                CargarDeclaracion(Convert.ToInt32(ID_Usuario), turnos,idUser);
                                MessageBox.Show("Usuario Aperturado Satisfactoriamente,", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("El usuario a aperturar ya se encuentra autorizado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error, al aperturar por favor intente de nuevo mas tarde ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al intentar aperturar el canal el usuario "+NombreOperador.Text+" es no es un recaudador por favor verifique e intente de nuevo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
                else
                {
                    MessageBox.Show("Disculpe, para poder aperturar un canal deben estar todos los campos llenos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error, al ejecutar la apertura del canal por favor intente de nuevo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CerrarCanal(string fecha, int usuario, int canal)
        {
            string sql = "Update Recaudadore Set FechaFin=@fechacierre, Estatus='Pendiente' Where ID_Usuario=@usuario and Canal=@canal and Estatus='Activo' or Estatus='Pendiente'";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechacierre", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.ExecuteReader();
                cn.Close();
                return;
            }
        }
        private void ActualizarTurno(string turno,int usuario)
        {
            string sql = "Update Usuarios Set Turno=@turno Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.ExecuteReader();
                cn.Close();
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
        private void button3_Click(object sender, EventArgs e)
        {
            if (Cedula.Text != "")
            {              
                         try
                        {
                            this.NombreOperador.Text = "";
                            SqlConnection cn = new SqlConnection(Inicio.conexion);
                            cn.Open();
                            SqlDataReader dr;
                            SqlCommand cmd = new SqlCommand("SELECT Perfil,ID_Usuario,Nombre,Apellido FROM Usuarios Where Nickname='" + Cedula.Text + "'", cn);
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                Perfil = dr["Perfil"].ToString();
                                NombreOperador.Text = dr["Nombre"].ToString()+" "+ dr["Apellido"].ToString();
                                ID_Usuario = dr["ID_Usuario"].ToString();
                            }
                        if (NombreOperador.Text=="")
                        {
                        MessageBox.Show("Recaudador No Registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NombreOperador.Text = "";
                            ID_Usuario = "";
                        }
                    else if (Perfil != "Recaudador" || Perfil == "RECAUDADOR")
                    {
                        MessageBox.Show("El usuario que esta intentando aperturar no es recaudador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NombreOperador.Text = "";
                        ID_Usuario = "";
                        Cedula.Text = "";
                    }
                    CedulaAux = Cedula.Text;
                }
                        catch
                        {
                            MessageBox.Show("No pudimos verificar el numero de DNI ingresado, por favor verifique su conexion a internet", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    
            }
            else
            {
                MessageBox.Show("Disculpe, el campo de cedula no puede estar vacio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AperturarCanal(string canal,string cedula)
        {
            string sql = "Update Usuarios Set Canal=@canal Where ID_Usuario=@cedula";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("canal", Convert.ToInt32(canal));
                cmd.Parameters.AddWithValue("cedula", Convert.ToInt32(cedula));
                cmd.ExecuteReader();
                return;
            }
        }
        private void AperturarCanal2(string id, string monto,int numero,string canals)
        {
            string sql = "Update ControlRecaudadores Set ID_Usuario=@id, Fecha=SYSDATETIME(), MontoApertura=@monto, Estado='Operativo',PDV=@numero Where Canal=@canals and ID_Peaje=@peaje";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", Convert.ToInt32(id));
                cmd.Parameters.AddWithValue("monto", monto);
                cmd.Parameters.AddWithValue("numero", numero);
                cmd.Parameters.AddWithValue("canals", Convert.ToInt32(canals));
                cmd.Parameters.AddWithValue("peaje", Convert.ToInt32(SAP.Inicio.peaje));
                cmd.ExecuteReader();
                return;
            }
        }
        private void Control(string canal)
        {
            string sql = "Select Fecha,Estado,ID_Usuario,Canal From ControlRecaudadores Where Canal=@canal and ID_Peaje=@peaje";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("canal", Convert.ToInt32(canal));
                cmd.Parameters.AddWithValue("peaje", Convert.ToInt32(SAP.Inicio.peaje));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EstadoCanal = dr["Estado"].ToString();
                    ID2 = dr["ID_Usuario"].ToString();
                    canal1 = dr["Canal"].ToString();
                    Apertura = dr["Fecha"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void Validar(string usuario)
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
                    CanalP = dr["Canal"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void Control1(string fecha,int id,int canal)
        {
            string sql = "Select FechaFin From Recaudadore Where Fecha=@canal and ID_Usuario=@usuario and Canal=@canals";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("canal", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("usuario", id);
                cmd.Parameters.AddWithValue("canals", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Fecha2 = dr["FechaFin"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void AperturarCanal3(string id, string monto, string canals,int turno)
        {
            string sql = "Insert into Recaudadore (ID_Usuario,Canal,Fecha,MontoApertura,ID_Peaje,FechaFin,Estatus,Turno) Values (@id,@canals,SYSDATETIME(),@monto,@peaje,SYSDATETIME(),'Pendiente',@turno)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", Convert.ToInt32(id));
                cmd.Parameters.AddWithValue("canals", Convert.ToInt32(canals));
                cmd.Parameters.AddWithValue("monto", monto);
                cmd.Parameters.AddWithValue("peaje", Convert.ToInt32(SAP.Inicio.peaje));
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CargarDeclaracion(int usuario, int turno, int idUser)
        {
            //rm-->string sql = "Insert into Declaraciones(FechaInicial,FechaFinal,ID_Usuario,Responsable) Values (DATEADD(HOUR, -2,GETDATE()),SYSDATETIME(),@usuario,0)";
            string sql = "Insert into Declaraciones(FechaInicial,FechaFinal,ID_Usuario,Responsable,Turno,IDUser) Values (SYSDATETIME(),SYSDATETIME(),@usuario,0,@turno,@idUser)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("idUser", idUser);
                cmd.ExecuteReader();
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AperturaV2_Load(object sender, EventArgs e)
        {

        }

        private void PDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            control = PDV.Text;
            if (control == "Diurno")
            {
                turnos = 1;
            }
            else if (control == "Nocturno")
            {
                turnos = 2;
            }
            else if (control == "Completo Grupo 1")
            {
                turnos = 3;
            }
            else if (control == "Completo Grupo 2")
            {
                turnos = 4;
            }
            else if (control == "Turno 1")
            {
                turnos = 5;
            }
            else if (control == "Turno 2")
            {
                turnos = 6;
            }
            else if (control == "Turno 3")
            {
                turnos = 7;
            }
            else if (control == "Turno 12h 00:00 - 12:00")
            {
                turnos = 8;
            }
            else if (control == "Turno 12h 12:00 - 23:59") {
                turnos = 9;
            }
        }
    }
    }
