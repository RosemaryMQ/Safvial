using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using SAP.Properties;
using System.Threading.Tasks;

namespace SAP.Tesoreria
{
    public partial class TesoreriaV2 : Form
    {
        string hora = "";
        string hora2 = "";
        Double Resultado = 0;
        Double Acumulado = 0;
        String Valores = "";
        String Estatus;
        String canal;
        String canal2;
        String valor = "";
        Double acumulador = 0;
        String pagos;
        Double pagos2;
        public static Boolean Validor;
        int sede = SAP.Inicio.sede;
        String fecha1 = DateTime.Now.ToString("d");
        String fecha2 = DateTime.Now.AddDays(1).ToString("d");
        public static string Nombre;
        public static string Identificador;
        public static string CanalUser;
        public static string Apertura;
        public static string id;
        public static string turno="0";

        public TesoreriaV2()
        {
            InitializeComponent();
            Valores = "";
            Acumulado = 0;
            sed.Text = SAP.Inicio.PeajeNombre.ToUpper();
            hora = DateTime.Now.ToString("d");
            hora2 = DateTime.Now.AddDays(1).ToString("d");
            date1.Text = hora;
            date2.Text = hora2;
            try
            {
                ConsultaCOA();
                this.Recaudador(fecha1, hora2);
                this.Operadores();
                this.Efectivo(fecha1, hora2);
                this.PDV(fecha1, hora2);
                this.Biopago(fecha1, hora2);
                this.Transferencia(fecha1, hora2);
                this.Tickets(fecha1, hora2);
                this.Incompletos(fecha1, hora2);
                this.Total(fecha1, hora2);
                this.UsuariosAperturados();
                try
                {
                    if (Validor != false)
                    {
                        this.Prepagado(fecha1, hora2, sede);
                    }
                    else
                    {
                        Balance15.Text = "No Disponible";
                    }
                }
                catch
                {

                }

            }
            catch
            {
                SAP.Tesoreria.TesoreriaV2 frm = new SAP.Tesoreria.TesoreriaV2();
                this.Close();
                frm.Show();
            }
        }
        public async void UsuariosAperturados()
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            await cn.OpenAsync();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT ID,Nombre,Apellido,Turno.Turno,Fecha FROM Turno Inner Join Usuarios ON Usuarios.ID_Usuario = Turno.ID_Usuario Where Finalizado=0", cn);
            dr = await cmd.ExecuteReaderAsync();
            Usuario.Rows.Clear();
            while (await dr.ReadAsync())
            {

                Usuario.Rows.Add(dr["ID"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), "TURNO " + dr["Turno"].ToString(), dr["Fecha"].ToString());
            }
            dr.Close();
        }

        private async void ConsultaCOA()
        {

            string sql = "SELECT Conexion from COA WHERE ID = 1";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandTimeout = 1;
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Validor = Convert.ToBoolean(dr["Conexion"]);
                }
                dr.Close();
                return;
            }
        }
        private async void Efectivo(String fechas, String fechas2)
        {
            string sql = "SELECT SUM(TipoVehiculos.Tarifa) as Efectivo from Pagos inner join TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo where Pagos.FormaPago='Efectivo' and Pagos.Fecha between @fecha+' 00:00:00.000' AND  @fecha2 +' 23:59:59.000';";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fechas2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    pagos = "";
                    pagos2 = 0;
                    pagos = dr["Efectivo"].ToString();
                    if (pagos != "")
                    {
                        pagos2 = Convert.ToDouble(pagos);
                        Balance16.Text = string.Format("{0:n}", pagos2) + " Bs.";
                    }
                    else
                    {
                        Balance16.Text = string.Format("{0:n}", pagos) + " Bs.";
                    }
                }
                dr.Close();
                cn.Close();
                return;
            }
        }
        private async void PDV(String fechas, String fechas2)
        {
            string sql = "SELECT SUM(TipoVehiculos.Tarifa) as PDV from Pagos inner join TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo where Pagos.FormaPago='Punto de Venta' and Pagos.Fecha between @fecha+' 00:00:00.000' AND  @fecha2 +' 23:59:59.000';";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fechas2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    pagos = "";
                    pagos2 = 0;
                    pagos = dr["PDV"].ToString();
                    if (pagos != "")
                    {
                        pagos2 = Convert.ToDouble(pagos);
                        Balance17.Text = string.Format("{0:n}", pagos2) + " Bs.";
                    }
                    else
                    {
                        Balance17.Text = string.Format("{0:n}", pagos) + " Bs.";
                    }
                }
                dr.Close();
                cn.Close();
                return;
            }
        }


        private async void Biopago(String fechas, String fechas2)
        {
            string sql = "SELECT SUM(TipoVehiculos.Tarifa) as Biopago from Pagos inner join TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo where Pagos.FormaPago='Biopago' and Pagos.Fecha between @fecha+' 00:00:00.000' AND  @fecha2 +' 23:59:59.000';";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fechas2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    pagos = "";
                    pagos2 = 0;
                    pagos = dr["Biopago"].ToString();
                    if (pagos != "")
                    {
                        pagos2 = Convert.ToDouble(pagos);
                        Balance21.Text = string.Format("{0:n}", pagos2) + " Bs.";
                    }
                    else
                    {
                        Balance21.Text = string.Format("{0:n}", pagos) + " Bs.";
                    }
                }
                dr.Close();
                cn.Close();
                return;
            }
        }


        private async void Transferencia(String fechas, String fechas2)
        {
            string sql = "SELECT SUM(TipoVehiculos.Tarifa) as Transferencia from Pagos inner join TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo where Pagos.FormaPago='Transferencia' and Pagos.Fecha between @fecha+' 00:00:00.000' AND  @fecha2 +' 23:59:59.000';";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fechas2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    pagos = "";
                    pagos2 = 0;
                    pagos = dr["Transferencia"].ToString();
                    if (pagos != "")
                    {
                        pagos2 = Convert.ToDouble(pagos);
                        Balance22.Text = string.Format("{0:n}", pagos2) + " Bs.";
                    }
                    else
                    {
                        Balance22.Text = string.Format("{0:n}", pagos) + " Bs.";
                    }
                }
                dr.Close();
                cn.Close();
                return;
            }
        }

        private async void Tickets(String fechas, String fechas2)
        {
            string sql = "SELECT SUM(SaldoInicial) AS Acumulado FROM PrepagadoCanales WHERE(Fecha BETWEEN  @fecha+' 00:00:00.000' AND  @fecha2 +' 23:59:59.000')";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fechas2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    pagos = "";
                    pagos2 = 0;
                    pagos = dr["Acumulado"].ToString();
                    if (pagos != "")
                    {
                        pagos2 = Convert.ToDouble(pagos);
                        Balance18.Text = string.Format("{0:n}", pagos2) + " Bs.";
                    }
                    else
                    {
                        Balance18.Text = string.Format("{0:n}", pagos) + " Bs.";
                    }
                }
                dr.Close();
                cn.Close();
                return;
            }
        }
        private async void Incompletos(String fechas, String fechas2)
        {
            string sql = "SELECT SUM(TipoVehiculos.Tarifa) as Incompletos from Pagos inner join TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo where Pagos.FormaPago='Pago Incompleto' and Pagos.Fecha between @fecha+' 00:00:00.000' AND  @fecha2 +' 23:59:59.000';";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fechas2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    pagos = "";
                    pagos2 = 0;
                    pagos = dr["Incompletos"].ToString();
                    if (pagos != "")
                    {
                        pagos2 = Convert.ToDouble(pagos);
                        Balance19.Text = string.Format("{0:n}", pagos2) + " Bs.";
                    }
                    else
                    {
                        Balance19.Text = string.Format("{0:n}", pagos) + " Bs.";
                    }
                }
                dr.Close();
                cn.Close();
                return;
            }
        }
        private async void Total(String fechas, String fechas2)
        {
            string sql = "SELECT SUM(TipoVehiculos.Tarifa) as Total from Pagos inner join TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo where Pagos.Fecha between @fecha+' 00:00:00.000' AND  @fecha2 +' 23:59:59.000';";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fechas2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    pagos = "";
                    pagos2 = 0;
                    pagos = dr["Total"].ToString();
                    if (pagos != "")
                    {
                        pagos2 = Convert.ToDouble(pagos);
                        Balance20.Text = string.Format("{0:n}", pagos2) + " Bs.";
                    }
                    else
                    {
                        Balance20.Text = string.Format("{0:n}", pagos) + " Bs.";
                    }
                }
                dr.Close();
                cn.Close();
                return;
            }
        }
        private async void Prepagado(String fechas, String fechas2, int sede)
        {
            string sql = "Select Sum(TipoVehiculos.Tarifa) as Tarifa FROM Pagos inner join TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo Where Pagos.Fecha BETWEEN @fecha+' 00:00:00.000' AND  @fecha2 +' 23:59:59.000' AND Pagos.Sede=@sede";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fechas2));
                cmd.Parameters.AddWithValue("sede", sede);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    pagos2 = 0;
                    pagos = dr["Tarifa"].ToString();
                    if (pagos != "")
                    {
                        pagos2 = Convert.ToDouble(pagos);
                        Balance15.Text = string.Format("{0:n}", pagos2) + " Bs.";
                    }
                    else
                    {
                        Balance15.Text = string.Format("{0:n}", pagos) + " Bs.";
                    }
                }
                dr.Close();
                cn.Close();
                return;
            }
        }
        private async void Operadores()
        {
            string sql = "Select ControlRecaudadores.Canal,Usuarios.Nombre,Usuarios.Apellido from Usuarios inner join ControlRecaudadores ON Usuarios.ID_Usuario = ControlRecaudadores.ID_Usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    canal2 = dr["Canal"].ToString();
                    if (canal2=="1")
                    {
                        operador1.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador1.Text=="Alexis Jose Espejo Delgado" || operador1.Text=="ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador1.Text = "";
                        }
                    }
                    else if (canal2 == "2")
                    {
                        operador2.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador2.Text == "Alexis Jose Espejo Delgado" || operador2.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador2.Text = "";
                        }
                    }
                    else if (canal2 == "3")
                    {
                        operador3.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador3.Text == "Alexis Jose Espejo Delgado" || operador3.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador3.Text = "";
                        }
                    }
                    else if (canal2 == "4")
                    {
                        operador4.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador4.Text == "Alexis Jose Espejo Delgado" || operador4.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador4.Text = "";
                        }
                    }
                    else if (canal2 == "5")
                    {
                        operador5.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador5.Text == "Alexis Jose Espejo Delgado" || operador5.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador5.Text = "";
                        }
                    }
                    else if (canal2 == "6")
                    {
                        operador6.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador6.Text == "Alexis Jose Espejo Delgado" || operador6.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador6.Text = "";
                        }
                    }
                    else if (canal2 == "7")
                    {
                        operador7.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador7.Text == "Alexis Jose Espejo Delgado" || operador7.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador7.Text = "";
                        }
                    }
                    else if (canal2 == "8")
                    {
                        operador8.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador8.Text == "Alexis Jose Espejo Delgado" || operador8.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador8.Text = "";
                        }
                    }
                    else if (canal2 == "9")
                    {
                        operador9.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador9.Text == "Alexis Jose Espejo Delgado" || operador9.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador9.Text = "";
                        }
                    }
                    else if (canal2 == "10")
                    {
                        operador10.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador10.Text == "Alexis Jose Espejo Delgado" || operador10.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador10.Text = "";
                        }
                    }
                    else if (canal2 == "11")
                    {
                        operador11.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador11.Text == "Alexis Jose Espejo Delgado" || operador11.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador11.Text = "";
                        }
                    }
                    else if (canal2 == "12")
                    {
                        operador12.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador12.Text == "Alexis Jose Espejo Delgado" || operador12.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador12.Text = "";
                        }
                    }
                    else if (canal2 == "13")
                    {
                        operador13.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador13.Text == "Alexis Jose Espejo Delgado" || operador13.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador13.Text = "";
                        }
                    }
                    else if (canal2 == "14")
                    {
                        operador14.Text = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                        if (operador14.Text == "Alexis Jose Espejo Delgado" || operador14.Text == "ALEXIS JOSE ESPEJO DELGADO")
                        {
                            operador14.Text = "";
                        }
                    }

                }
                dr.Close();
                cn.Close();
                return;
            }
        }

        private async void Recaudador(String fechas, String fechas2)
        {
            //string sql = "Select Pagos.Canal,Sum(TipoVehiculos.Tarifa)as Tarifa,ControlRecaudadores.Estado FROM Pagos inner join TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo inner join Usuarios ON Pagos.ID_Usuario = Usuarios.ID_Usuario inner join ControlRecaudadores ON Pagos.Canal=ControlRecaudadores.Canal Where Pagos.Fecha BETWEEN @fecha+' 00:00:00.000' AND  @fecha2 +' 23:59:59.000' AND Usuarios.ID_Peaje='1' AND Pagos.FormaPago<>'Pago Incompleto' AND Pagos.FormaPago<>'Ticket' Group By Pagos.Canal, ControlRecaudadores.Estado";
            string sql = "SELECT Pagos.Canal, SUM(TipoVehiculos.Tarifa) as Tarifa, CR_Filtered.Estado FROM Pagos INNER JOIN TipoVehiculos ON Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo INNER JOIN Usuarios ON Pagos.ID_Usuario = Usuarios.ID_Usuario OUTER APPLY(SELECT TOP 1 Estado FROM ControlRecaudadores CR WHERE CR.Canal = Pagos.Canal AND CR.ID_Usuario = Pagos.ID_Usuario ORDER BY CR.ID DESC) CR_Filtered Where Pagos.Fecha BETWEEN @fecha+' 00:00:00.000' AND  @fecha2 +' 23:59:59.000' AND Usuarios.ID_Peaje='1' AND Pagos.FormaPago<>'Pago Incompleto' AND Pagos.FormaPago<>'Ticket' Group BY Pagos.Canal, CR_Filtered.Estado ";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fechas2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Valores = "";
                    Acumulado = 0;
                    canal = dr["Canal"].ToString();
                    if (canal == "1")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance1.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus1.Text = Estatus;
                            (Estatus1).BackColor = Color.MediumTurquoise;
                            (Estatus1).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus1.Text = Estatus;
                            (Estatus1).BackColor = Color.Red;
                            (Estatus1).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus1.Text = Estatus;
                            (Estatus1).BackColor = Color.GreenYellow;
                            (Estatus1).ForeColor = Color.Black;
                        }

                    }
                    else if (canal == "2")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance2.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus2.Text = Estatus;
                            (Estatus2).BackColor = Color.MediumTurquoise;
                            (Estatus2).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus2.Text = Estatus;
                            (Estatus2).BackColor = Color.Red;
                            (Estatus2).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus2.Text = Estatus;
                            (Estatus2).BackColor = Color.GreenYellow;
                            (Estatus2).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "3")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance3.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus3.Text = Estatus;
                            (Estatus3).BackColor = Color.MediumTurquoise;
                            (Estatus3).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus3.Text = Estatus;
                            (Estatus3).BackColor = Color.Red;
                            (Estatus3).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus3.Text = Estatus;
                            (Estatus3).BackColor = Color.GreenYellow;
                            (Estatus3).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "4")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance4.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus4.Text = Estatus;
                            (Estatus4).BackColor = Color.MediumTurquoise;
                            (Estatus4).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus4.Text = Estatus;
                            (Estatus4).BackColor = Color.Red;
                            (Estatus4).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus4.Text = Estatus;
                            (Estatus4).BackColor = Color.GreenYellow;
                            (Estatus4).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "5")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance5.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus5.Text = Estatus;
                            (Estatus5).BackColor = Color.MediumTurquoise;
                            (Estatus5).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus5.Text = Estatus;
                            (Estatus5).BackColor = Color.Red;
                            (Estatus5).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus5.Text = Estatus;
                            (Estatus5).BackColor = Color.GreenYellow;
                            (Estatus5).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "6")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance6.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus6.Text = Estatus;
                            (Estatus6).BackColor = Color.MediumTurquoise;
                            (Estatus6).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus6.Text = Estatus;
                            (Estatus6).BackColor = Color.Red;
                            (Estatus6).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus6.Text = Estatus;
                            (Estatus6).BackColor = Color.GreenYellow;
                            (Estatus6).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "7")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance7.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus7.Text = Estatus;
                            (Estatus7).BackColor = Color.MediumTurquoise;
                            (Estatus7).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus7.Text = Estatus;
                            (Estatus7).BackColor = Color.Red;
                            (Estatus7).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus7.Text = Estatus;
                            (Estatus7).BackColor = Color.GreenYellow;
                            (Estatus7).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "8")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance8.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus8.Text = Estatus;
                            (Estatus8).BackColor = Color.MediumTurquoise;
                            (Estatus8).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus8.Text = Estatus;
                            (Estatus8).BackColor = Color.Red;
                            (Estatus8).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus8.Text = Estatus;
                            (Estatus8).BackColor = Color.GreenYellow;
                            (Estatus8).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "9")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance9.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus9.Text = Estatus;
                            (Estatus9).BackColor = Color.MediumTurquoise;
                            (Estatus9).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus9.Text = Estatus;
                            (Estatus9).BackColor = Color.Red;
                            (Estatus9).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus9.Text = Estatus;
                            (Estatus9).BackColor = Color.GreenYellow;
                            (Estatus9).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "10")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance10.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus10.Text = Estatus;
                            (Estatus10).BackColor = Color.MediumTurquoise;
                            (Estatus10).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus10.Text = Estatus;
                            (Estatus10).BackColor = Color.Red;
                            (Estatus10).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus10.Text = Estatus;
                            (Estatus10).BackColor = Color.GreenYellow;
                            (Estatus10).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "11")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance11.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus11.Text = Estatus;
                            (Estatus11).BackColor = Color.MediumTurquoise;
                            (Estatus11).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus11.Text = Estatus;
                            (Estatus11).BackColor = Color.Red;
                            (Estatus11).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus11.Text = Estatus;
                            (Estatus11).BackColor = Color.GreenYellow;
                            (Estatus11).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "12")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance12.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus12.Text = Estatus;
                            (Estatus12).BackColor = Color.MediumTurquoise;
                            (Estatus12).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus12.Text = Estatus;
                            (Estatus12).BackColor = Color.Red;
                            (Estatus12).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus12.Text = Estatus;
                            (Estatus12).BackColor = Color.GreenYellow;
                            (Estatus12).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "13")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance13.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus13.Text = Estatus;
                            (Estatus13).BackColor = Color.MediumTurquoise;
                            (Estatus13).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus13.Text = Estatus;
                            (Estatus13).BackColor = Color.Red;
                            (Estatus13).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus13.Text = Estatus;
                            (Estatus13).BackColor = Color.GreenYellow;
                            (Estatus13).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "14")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance14.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus14.Text = Estatus;
                            (Estatus14).BackColor = Color.MediumTurquoise;
                            (Estatus14).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus14.Text = Estatus;
                            (Estatus14).BackColor = Color.Red;
                            (Estatus14).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus14.Text = Estatus;
                            (Estatus14).BackColor = Color.GreenYellow;
                            (Estatus14).ForeColor = Color.Black;
                        }
                    }

                    valor = dr["Tarifa"].ToString();
                    acumulador = Convert.ToDouble(valor);
                    Resultado = Resultado + acumulador;
                    acumulador = 0;
                    Recaudado.Text = string.Format("{0:n}", Resultado) + " Bs.";
                }
                dr.Close();
                cn.Close();
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ConsultaCOA();
            hora = DateTime.Now.ToString("d");
            hora2 = DateTime.Now.AddDays(1).ToString("d");
            try
            {
                Resultado = 0;
                Valores = "";
                Acumulado = 0;
                this.Recaudador(fecha1, hora2);
                this.Operadores();
                this.UsuariosAperturados();
                try
                {
                    if (Validor != false)
                    {
                        this.Prepagado(fecha1, hora2, sede);
                    }
                    else
                    {
                        Balance15.Text = "No Disponible";
                    }
                    
                }
                catch
                {
                  
                }
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Seguro, que desea cerrar sesión?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    FinSession(Inicio.ID);
                    ControlUser(Inicio.ID, hora);
                    this.Hide();
                    SAP.Inicio frm = new SAP.Inicio();
                    frm.Show();
                }
            }
            catch
            {
                MessageBox.Show("¡Error,al intentar desconectarte del sistema por favor reintente de nuevo!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void FinSession(string usuario)
        {
            string sql = "Update Usuarios Set Estado='No Conectado' Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                await cmd.ExecuteReaderAsync();
                return;
            }
        }
        private async void ControlUser(string usuario, string fecha)
        {
            string sql = "Insert into ControlUsuario (ID_Usuario,Conexiones) values (@usuario,@fecha)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                await cmd.ExecuteReaderAsync();
                return;
            }
        }

        private async void RecaudadorParametrizado(String fechas, String fechas2)
        {
            string sql = "Select Pagos.Canal,Sum(TipoVehiculos.Tarifa)as Tarifa,ControlRecaudadores.Estado FROM Pagos inner join TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo inner join Usuarios ON Pagos.ID_Usuario = Usuarios.ID_Usuario inner join ControlRecaudadores ON Pagos.Canal=ControlRecaudadores.Canal Where Pagos.Fecha BETWEEN @fecha AND @fecha2 AND Usuarios.ID_Peaje='1' AND Pagos.FormaPago<>'Pago Incompleto' AND Pagos.FormaPago<>'Ticket' Group By Pagos.Canal, ControlRecaudadores.Estado";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fechas2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Valores = "";
                    Acumulado = 0;

                    canal = dr["Canal"].ToString();
                    if (canal == "1")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance1.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus1.Text = Estatus;
                            (Estatus1).BackColor = Color.MediumTurquoise;
                            (Estatus1).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus1.Text = Estatus;
                            (Estatus1).BackColor = Color.Red;
                            (Estatus1).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus1.Text = Estatus;
                            (Estatus1).BackColor = Color.GreenYellow;
                            (Estatus1).ForeColor = Color.Black;
                        }

                    }
                    else if (canal == "2")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance2.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus2.Text = Estatus;
                            (Estatus2).BackColor = Color.MediumTurquoise;
                            (Estatus2).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus2.Text = Estatus;
                            (Estatus2).BackColor = Color.Red;
                            (Estatus2).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus2.Text = Estatus;
                            (Estatus2).BackColor = Color.GreenYellow;
                            (Estatus2).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "3")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance3.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus3.Text = Estatus;
                            (Estatus3).BackColor = Color.MediumTurquoise;
                            (Estatus3).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus3.Text = Estatus;
                            (Estatus3).BackColor = Color.Red;
                            (Estatus3).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus3.Text = Estatus;
                            (Estatus3).BackColor = Color.GreenYellow;
                            (Estatus3).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "4")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance4.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus4.Text = Estatus;
                            (Estatus4).BackColor = Color.MediumTurquoise;
                            (Estatus4).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus4.Text = Estatus;
                            (Estatus4).BackColor = Color.Red;
                            (Estatus4).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus4.Text = Estatus;
                            (Estatus4).BackColor = Color.GreenYellow;
                            (Estatus4).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "5")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance5.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus5.Text = Estatus;
                            (Estatus5).BackColor = Color.MediumTurquoise;
                            (Estatus5).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus5.Text = Estatus;
                            (Estatus5).BackColor = Color.Red;
                            (Estatus5).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus5.Text = Estatus;
                            (Estatus5).BackColor = Color.GreenYellow;
                            (Estatus5).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "6")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance6.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus6.Text = Estatus;
                            (Estatus6).BackColor = Color.MediumTurquoise;
                            (Estatus6).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus6.Text = Estatus;
                            (Estatus6).BackColor = Color.Red;
                            (Estatus6).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus6.Text = Estatus;
                            (Estatus6).BackColor = Color.GreenYellow;
                            (Estatus6).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "7")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance7.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus7.Text = Estatus;
                            (Estatus7).BackColor = Color.MediumTurquoise;
                            (Estatus7).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus7.Text = Estatus;
                            (Estatus7).BackColor = Color.Red;
                            (Estatus7).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus7.Text = Estatus;
                            (Estatus7).BackColor = Color.GreenYellow;
                            (Estatus7).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "8")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance8.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus8.Text = Estatus;
                            (Estatus8).BackColor = Color.MediumTurquoise;
                            (Estatus8).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus8.Text = Estatus;
                            (Estatus8).BackColor = Color.Red;
                            (Estatus8).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus8.Text = Estatus;
                            (Estatus8).BackColor = Color.GreenYellow;
                            (Estatus8).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "9")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance9.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus9.Text = Estatus;
                            (Estatus9).BackColor = Color.MediumTurquoise;
                            (Estatus9).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus9.Text = Estatus;
                            (Estatus9).BackColor = Color.Red;
                            (Estatus9).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus9.Text = Estatus;
                            (Estatus9).BackColor = Color.GreenYellow;
                            (Estatus9).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "10")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance10.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus10.Text = Estatus;
                            (Estatus10).BackColor = Color.MediumTurquoise;
                            (Estatus10).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus10.Text = Estatus;
                            (Estatus10).BackColor = Color.Red;
                            (Estatus10).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus10.Text = Estatus;
                            (Estatus10).BackColor = Color.GreenYellow;
                            (Estatus10).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "11")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance11.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus11.Text = Estatus;
                            (Estatus11).BackColor = Color.MediumTurquoise;
                            (Estatus11).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus11.Text = Estatus;
                            (Estatus11).BackColor = Color.Red;
                            (Estatus11).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus11.Text = Estatus;
                            (Estatus11).BackColor = Color.GreenYellow;
                            (Estatus11).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "12")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance12.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus12.Text = Estatus;
                            (Estatus12).BackColor = Color.MediumTurquoise;
                            (Estatus12).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus12.Text = Estatus;
                            (Estatus12).BackColor = Color.Red;
                            (Estatus12).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus12.Text = Estatus;
                            (Estatus12).BackColor = Color.GreenYellow;
                            (Estatus12).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "13")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance13.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus13.Text = Estatus;
                            (Estatus13).BackColor = Color.MediumTurquoise;
                            (Estatus13).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus13.Text = Estatus;
                            (Estatus13).BackColor = Color.Red;
                            (Estatus13).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus13.Text = Estatus;
                            (Estatus13).BackColor = Color.GreenYellow;
                            (Estatus13).ForeColor = Color.Black;
                        }
                    }
                    else if (canal == "14")
                    {
                        Valores = dr["Tarifa"].ToString();
                        Acumulado = Convert.ToDouble(Valores);
                        Balance14.Text = string.Format("{0:n}", Acumulado) + " Bs.";
                        Estatus = dr["Estado"].ToString();
                        if (Estatus == "Operativo")
                        {
                            Estatus14.Text = Estatus;
                            (Estatus14).BackColor = Color.MediumTurquoise;
                            (Estatus14).ForeColor = Color.Black;
                        }
                        if (Estatus == "Avance")
                        {
                            Estatus14.Text = Estatus;
                            (Estatus14).BackColor = Color.Red;
                            (Estatus14).ForeColor = Color.White;
                        }
                        if (Estatus == "Libre")
                        {
                            Estatus14.Text = Estatus;
                            (Estatus14).BackColor = Color.GreenYellow;
                            (Estatus14).ForeColor = Color.Black;
                        }
                    }

                    valor = dr["Tarifa"].ToString();
                    acumulador = Convert.ToDouble(valor);
                    Resultado = Resultado + acumulador;
                    acumulador = 0;
                    Recaudado.Text = string.Format("{0:n}", Resultado) + " Bs.";
                }
                dr.Close();
                cn.Close();
                return;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                ConsultaCOA();
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = true;
                Resultado = 0;
                Valores = "";
                Acumulado = 0;
                this.Operadores();
                this.UsuariosAperturados();
                RecaudadorParametrizado(fecha1 + " 19:00:01", hora2 + " 07:00:00");
                if (Validor != false)
                {
                    this.Prepagado(fecha1 + " 19:00:01", hora2 + " 07:00:00", sede);
                }
                else
                {
                    Balance15.Text = "No Disponible";
                }
                
            }
            catch
            {

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                ConsultaCOA();
                timer1.Enabled = false;
                timer2.Enabled = true;
                timer3.Enabled = false;
                Resultado = 0;
                Valores = "";
                Acumulado = 0;
                this.Operadores();
                this.UsuariosAperturados();
                RecaudadorParametrizado(fecha1 + " 07:00:00", hora2 + " 19:00:00");
                if (Validor != false)
                {
                    this.Prepagado(fecha1 + " 07:00:00", hora2 + " 19:00:00", sede);
                }
                else
                {
                    Balance15.Text = "No Disponible";
                }
               
            }
            catch
            {

            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                ConsultaCOA();
                this.Efectivo(fecha1, hora2);
                this.PDV(fecha1, hora2);
                this.Biopago(fecha1, hora2);
                this.Transferencia(fecha1, hora2);
                this.Tickets(fecha1, hora2);
                this.Incompletos(fecha1, hora2);
                this.Total(fecha1, hora2);
            }
            catch
            {

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                this.Efectivo(date1.Text, date2.Text);
                this.PDV(date1.Text, date2.Text);
                this.Biopago(date1.Text, date2.Text);
                this.Transferencia(fecha1, hora2);
                this.Tickets(date1.Text, date2.Text);
                this.Incompletos(date1.Text, date2.Text);
                this.Total(date1.Text, date2.Text);
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            SAP.Tesoreria.Controles.AperturaV2 frm = new SAP.Tesoreria.Controles.AperturaV2();
            frm.ShowDialog();
            timer1.Enabled = true;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 3;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.conexion;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            SAP.Tesoreria.Controles.Cierre frm = new SAP.Tesoreria.Controles.Cierre();
            frm.ShowDialog();
            timer1.Enabled = true;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.conexion;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            SAP.Inicio.acceso = 1;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
            timer1.Enabled = true;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.conexion;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            SAP.Inicio.acceso = 2;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
            timer1.Enabled = true;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = true;
        }
        private void buscar(int canal)
        {
            string sql = "Select ID_Usuario,Fecha,PDV From ControlRecaudadores where Canal=@canal;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("canal", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Identificador = dr["ID_Usuario"].ToString();
                    Apertura = dr["Fecha"].ToString();
                    turno = dr["PDV"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (operador1.Text != "")
            {
                CanalUser = "1";
                buscar(1);
                Nombre = operador1.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (operador2.Text != "")
            {
                CanalUser = "2";
                buscar(2);
                Nombre = operador2.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (operador3.Text != "")
            {
                CanalUser = "3";
                buscar(3);
                Nombre = operador3.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (operador4.Text != "")
            {
                CanalUser = "4";
                buscar(4);
                Nombre = operador4.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (operador5.Text != "")
            {
                CanalUser = "5";
                buscar(5);
                Nombre = operador5.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (operador6.Text != "")
            {
                CanalUser = "6";
                buscar(6);
                Nombre = operador6.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (operador7.Text != "")
            {
                CanalUser = "7";
                buscar(7);
                Nombre = operador7.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (operador8.Text != "")
            {
                CanalUser = "8";
                buscar(8);
                Nombre = operador8.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (operador9.Text != "")
            {
                CanalUser = "9";
                buscar(9);
                Nombre = operador9.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (operador10.Text != "")
            {
                CanalUser = "10";
                buscar(10);
                Nombre = operador10.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void button24_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config1.ConnectionStrings.ConnectionStrings["SAP.Properties.Settings.SAP"].ConnectionString = Inicio.conexion;
            config1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            //SAP.Inicio.acceso = 15;
            //SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            //frm.ShowDialog();
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre frm15 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre();
            frm15.ShowDialog();
            timer1.Enabled = true;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = true;
        }

        // FECHA FIN
        private async Task<string> Control(int turno, string horas1, string horas2)
        {
            string fechaS1 = "";
            string sql = "SELECT TOP 1 Fecha FROM CierreBalanceV2 WHERE CierreBalanceV2.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha DESC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(date1.Value.ToShortDateString() + horas1));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(date2.Value.ToShortDateString() + horas2));
                cmd.Parameters.AddWithValue("turno", turno);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    fechaS1 = Convert.ToString(Convert.ToDateTime(dr["Fecha"]).AddMinutes(1)); //FIN DEL TURNO
                }
                dr.Close();
                return fechaS1;
            }
        }
        // FECHA DE INICIO
        private async Task<string> Control2(int turno, string horas1, string horas2)
        {
            string fechaS1="";
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Turno.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha ASC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(date1.Value.ToShortDateString() + horas1));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(date2.Value.ToShortDateString() + horas2));
                cmd.Parameters.AddWithValue("turno", turno);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    fechaS1 = dr["Fecha"].ToString(); //INICIO DEL TURNO
                }
                dr.Close();
                return fechaS1;
            }
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            if (operador11.Text != "")
            {
                CanalUser = "11";
                buscar(11);
                Nombre = operador11.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (operador12.Text != "")
            {
                CanalUser = "12";
                buscar(12);
                Nombre = operador12.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (operador13.Text != "")
            {
                CanalUser = "13";
                buscar(13);
                Nombre = operador13.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (operador14.Text != "")
            {
                CanalUser = "14";
                buscar(14);
                Nombre = operador13.Text;
                SAP.Tesoreria.Controles.AuditorUsuario frm = new SAP.Tesoreria.Controles.AuditorUsuario();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El canal no tiene usuario aperturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TesoreriaV2_FormClosed(object sender, FormClosedEventArgs e)
        {
            var result = MessageBox.Show("Se cerrara la sesión y aplicacion ¿Desea Continuar?", "SAFVIAL", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


    }
}
