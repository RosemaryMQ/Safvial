using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class GenerarCierre : Form
    {
        public static int turno;
        public static int turnoA;
        public static int turnoB;
        string hora;
        string hora1;
        string hora2;
        string hora3;
        string control;
        public static string fechaS;
        public static string fechaS1;
        public static string fechaPrimerAvance;
        public static string fechaUltimoAvance;
        public static string fechaPrimeraTabulacionD;
        public static string fechaUltimaTabulacionD;
        public static string fechaPrimeraTabulacionN;
        public static string fechaUltimaTabulacionN;
        public static string fechaPrimerTurno;
        public static string fechaUltimoTurno;
        public static string fechaSolicitud;
        public static string fechaInicio;
        public static string fechaFinal;
        public static string fechaPivoteD;
        public static string fechaPivoteM;
        public static string fechaPivoteN;
        public static string fechaDiaAnterior;
        public static string fechaDiaSiguiente;

        public GenerarCierre()
        {
            InitializeComponent();
        }

        private void PDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            turno = 0;
            control = PDV.Text;
            if (control == "Diurno")
            {
                turno = 1;
                date2.Enabled = true;
                hora = " 04:00:00";
                hora1 = " 23:59:59";
            }
            else if (control == "Nocturno")
            {
                turno = 2;
                date2.Enabled = true;
                hora = " 16:00:00";
                hora1 = " 12:00:00";
            }
            else if (control == "Completo Grupo 1")
            {
                turno = 3;
                date2.Enabled = true;
                hora = " 00:00:00";
                hora1 = " 16:00:00";
            }
            else if (control == "Completo Grupo 2")
            {
                turno = 4;
                date2.Enabled = true;
                hora = " 00:00:00";
                hora1 = " 16:00:00";
            }
            else if (control == "Turno 1")
            {
                turno = 5;
                date2.Enabled = true;
                hora = " 04:00:00";
                hora1 = " 16:00:00";
            }
            else if (control == "Turno 2")
            {
                turno = 6;
                date2.Enabled = true;
                hora = " 10:00:00";
                hora1 = " 09:00:00";
            }
            else if (control == "Turno 3")
            {
                turno = 7;
                date2.Enabled = true;
                hora = " 20:00:00";
                hora1 = " 19:00:00";
            }
            else if (control == "Turno 12h 00:00 - 12:00")
            {
                turno = 8;
                date2.Enabled = true;
                hora = " 21:00:00";
                hora1 = " 20:59:59";
                /*hora = " 00:00:00";
                hora1 = " 11:59:59";
                hora2 = " 12:00:00";
                hora3 = " 23:59:59";*/
            }
            else if (control == "Turno 12h 12:00 - 23:59")
            {
                turno = 9;
                date2.Enabled = true;
                hora = " 10:00:00";
                hora1 = " 09:59:00";
                /*hora = " 12:00:00";
                hora1 = " 23:59:59";
                hora2 = " 00:00:00";
                hora3 = " 11:59:59";*/
            }
            else if (control == "Reporte Diario (24 Horas)")
            {
                turno = 10;
                date2.Enabled = false;
                hora = " 00:00:00.000";
                hora1 = " 23:59:59.999";
            }
            else if (control == "Reporte Diario por Turno (24 Horas)")
            {
                turno = 11;
                date2.Enabled = false;
                hora = " 00:00:00.000";
                hora1 = " 23:59:59.999";
                hora2 = " 12:00:00.000";
            }
            else if (control==""){
                date2.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fechaS = "";
            fechaS1 = "";
            fechaPrimerAvance = "";
            fechaUltimoAvance = "";
            fechaSolicitud = "";
            fechaPrimeraTabulacionD = "";
            fechaUltimaTabulacionD = "";
            fechaPrimeraTabulacionN = "";
            fechaUltimaTabulacionN = "";
            fechaPivoteM = "";
            fechaInicio = "";
            fechaDiaAnterior = Convert.ToDateTime(date1.Value.ToShortDateString()).AddDays(-1).ToString("dd-MM-yyyy");
            fechaDiaSiguiente = Convert.ToDateTime(date1.Value.ToShortDateString()).AddDays(1).ToString("dd-MM-yyyy");

            try
            {
                if (turno == 10)
                {
                    fechaS1 = date1.Value.ToString("dd/MM/yyyy") + hora;
                    fechaS = date1.Value.ToString("dd/MM/yyyy") + hora1;
                    SAP.Tesoreria.Controles.Declaraciones.CierreTurnoDiario frm = new SAP.Tesoreria.Controles.Declaraciones.CierreTurnoDiario();
                    frm.ShowDialog();
                }
                else if (turno == 11)
                {
                    fechaPivoteD = Convert.ToDateTime(date1.Value.ToShortDateString() + hora).AddHours(8).ToString("dd-MM-yyyy HH:mm:ss");
                    fechaPivoteN = Convert.ToDateTime(date1.Value.ToShortDateString() + hora1).AddHours(-4).ToString("dd-MM-yyyy HH:mm:ss");
                    fechaPivoteM = date1.Value.ToString("dd/MM/yyyy") + hora2;
                    fechaS1 = date1.Value.ToString("dd/MM/yyyy") + hora;
                    fechaS = date1.Value.ToString("dd/MM/yyyy") + hora1;
                    fechaInicio = Convert.ToDateTime(date1.Value.ToShortDateString() + hora).AddHours(-4).ToString("dd-MM-yyyy HH:mm:ss");
                    fechaFinal = Convert.ToDateTime(date1.Value.ToShortDateString() + hora1).AddHours(4).ToString("dd-MM-yyyy HH:mm:ss");
                    turnoA = 8;
                    turnoB = 9;
                    this.PrimerTurno(turnoA);
                    this.UltimoTurno(turnoB);
                    this.PrimerAvance(turnoA);
                    this.UltimoAvance(turnoB);
                     
                    this.PrimeraTabulacionD(turnoA, fechaPrimerTurno, fechaUltimoTurno);
                    this.UltimaTabulacionD(turnoB);
                    this.UltimaTabulacionN(turnoB);
                    this.PrimeraTabulacionN(turnoB, fechaPrimerTurno, fechaUltimoTurno);

                    SAP.Tesoreria.Controles.Declaraciones.CierreTurnoFiltro frm = new SAP.Tesoreria.Controles.Declaraciones.CierreTurnoFiltro();
                    frm.ShowDialog();

                }
                else
                {
                    this.Control2(turno);//FECHA INICIO
                    this.Control(turno);//FECHA FIN
                    SAP.Tesoreria.Controles.Declaraciones.CierreTurno frm = new SAP.Tesoreria.Controles.Declaraciones.CierreTurno();
                    frm.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("La fecha ingresada no posee registros detectados", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
           
        }


        // FECHA FIN
        private void Control(int turno)
        {
            string sql = "SELECT TOP 1 Fecha FROM CierreBalanceV2 WHERE CierreBalanceV2.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha DESC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(date1.Value.ToShortDateString() + hora));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(date2.Value.ToShortDateString() + hora1));
                cmd.Parameters.AddWithValue("turno", turno);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fechaS = Convert.ToString(Convert.ToDateTime(dr["Fecha"]).AddHours(1)); //FIN DEL TURNO
                }
                dr.Close();
                return;
            }
        }
        // FECHA DE INICIO
        private void Control2(int turno)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Turno.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha ASC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(date1.Value.ToShortDateString() + hora));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(date2.Value.ToShortDateString() + hora1));
                cmd.Parameters.AddWithValue("turno", turno);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fechaS1 = Convert.ToString(Convert.ToDateTime(dr["Fecha"]).AddHours(-1)); //INICIO DEL TURNO
                }
                dr.Close();
                return;
            }
        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            if (control == "Diurno")
            {
                date2.Text = date1.Text;
            }
            else if (control == "Turno 2")
            {
                date2.Text = date1.Text;
            }
            
        }


        // FECHA DE INICIO
        private void PrimerTurno(int turnoA)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Turno.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha ASC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(date1.Value.ToShortDateString() + hora).AddHours(-4));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(date1.Value.ToShortDateString() + hora1).AddHours(4));
                cmd.Parameters.AddWithValue("turno", turnoA);

                // ExecuteScalar devuelve un 'object' directamente
                object resultado = cmd.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    // SI ENCONTRÓ DATO
                    fechaPrimerTurno = Convert.ToString(Convert.ToDateTime(resultado));
                }
                else
                {
                    // NO ENCONTRÓ DATO (resultado es null)
                    fechaPrimerTurno = "";
                }
            }
        }

        private void PrimerAvance(int turnoB)
        {
            string sql = "SELECT TOP 1 C.Fecha from Declaraciones A INNER JOIN Turno B ON A.id_usuario = B.ID_Usuario AND A.FechaInicial = B.Fecha INNER JOIN CierreBalanceV2 C ON C.Fecha between A.FechaInicial and A.FechaFinal AND A.ID_Usuario = C.ID_Usuario and B.ID_Usuario = C.ID_Usuario and B.Turno = C.Turno  WHERE B.Fecha BETWEEN @fecha AND @fecha1 ORDER by C.fecha ASC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", fechaPrimerTurno);
                cmd.Parameters.AddWithValue("fecha1", fechaUltimoTurno);
                cmd.Parameters.AddWithValue("turno", turnoB);

                // ExecuteScalar devuelve un 'object' directamente
                object resultado = cmd.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    // SI ENCONTRÓ DATO
                    fechaPrimerAvance = Convert.ToString(Convert.ToDateTime(resultado));
                }
                else
                {
                    // NO ENCONTRÓ DATO (resultado es null)
                    fechaPrimerAvance = "";
                }
            }
        }

        private void UltimoAvance(int turnoB)
        {
            string sql = "SELECT TOP 1 C.Fecha from Declaraciones A INNER JOIN Turno B ON A.id_usuario = B.ID_Usuario AND A.FechaInicial = B.Fecha " +
                "INNER JOIN CierreBalanceV2 C ON C.Fecha between A.FechaInicial and A.FechaFinal AND A.ID_Usuario = C.ID_Usuario and B.ID_Usuario = C.ID_Usuario and B.Turno = C.Turno  " +
                "WHERE B.Fecha BETWEEN @fecha AND @fecha1 ORDER by C.fecha DESC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", fechaPrimerTurno);
                cmd.Parameters.AddWithValue("fecha1", fechaUltimoTurno);
                cmd.Parameters.AddWithValue("turno", turnoB);

                // ExecuteScalar devuelve un 'object' directamente
                object resultado = cmd.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    // SI ENCONTRÓ DATO
                    fechaUltimoAvance = Convert.ToString(Convert.ToDateTime(resultado).AddMinutes(15));
                }
                else
                {
                    // NO ENCONTRÓ DATO (resultado es null)
                    fechaUltimoAvance = "";
                }
            }
        }

        private void UltimoTurno(int turnoB)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Turno.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha DESC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(date1.Value.ToShortDateString() + hora).AddHours(-4));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(date1.Value.ToShortDateString() + hora1).AddHours(4));
                cmd.Parameters.AddWithValue("turno", turnoB);

                // ExecuteScalar devuelve un 'object' directamente
                object resultado = cmd.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    // SI ENCONTRÓ DATO
                    fechaUltimoTurno = Convert.ToString(Convert.ToDateTime(resultado));
                }
                else
                {
                    // NO ENCONTRÓ DATO (resultado es null)
                    fechaUltimoTurno = "";
                }
            }
        }

        private void PrimeraTabulacionD(int turnoA, string fechaPrimerTurno, string fechaUltimoTurno)
        {
            string sql = "SELECT Top 1 A.Fecha from Pagos A INNER JOIN Turno C ON A.ID_Usuario = C.ID_Usuario and A.Turno = C.Turno" +
                " where A.fecha BETWEEN @fechaA and @fechaB and A.Turno = @turno and C.fecha BETWEEN @fechaA and @fechaB order by A.fecha ASC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaA", fechaPrimerTurno);
                cmd.Parameters.AddWithValue("fechaB", fechaUltimoTurno);
                cmd.Parameters.AddWithValue("turno", turnoA);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fechaPrimeraTabulacionD = Convert.ToString(Convert.ToDateTime(dr["Fecha"])); //Primera Tabulacion del turno
                }
                dr.Close();
                return;
            }
        }

        private void PrimeraTabulacionN(int turnoB, string fechaPrimerTurno, string fechaUltimoTurno)
        {
            string sql = "SELECT Top 1 A.Fecha from Pagos A INNER JOIN Turno C ON A.ID_Usuario = C.ID_Usuario and A.Turno = C.Turno " +
                "where A.fecha BETWEEN @fechaA and @fechaB and A.Turno = @turno and C.fecha BETWEEN @fechaA and @fechaB order by A.fecha ASC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaA", fechaPrimerTurno);
                cmd.Parameters.AddWithValue("fechaB", fechaUltimoTurno);
                cmd.Parameters.AddWithValue("turno", turnoB);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fechaPrimeraTabulacionN = Convert.ToString(Convert.ToDateTime(dr["Fecha"])); //Primera Tabulacion del turno
                }
                dr.Close();
                return;
            }
        }

        private void UltimaTabulacionD(int turnoB)
        {
            string sql = "SELECT Top 1 A.Fecha from Pagos A INNER JOIN Turno C ON A.ID_Usuario = C.ID_Usuario and A.Turno = C.Turno " +
                "where A.fecha BETWEEN @fechaA and @fechaB and A.Turno = @turno and C.fecha BETWEEN @fechaA and @fechaC order by A.fecha DESC;";


            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaA", fechaPrimerTurno);
                cmd.Parameters.AddWithValue("fechaB", fechaUltimoAvance);
                cmd.Parameters.AddWithValue("fechaC", fechaUltimoTurno);
                cmd.Parameters.AddWithValue("turno", turnoB);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fechaUltimaTabulacionD = Convert.ToString(Convert.ToDateTime(dr["Fecha"])); //Primera Tabulacion del turno
                }
                dr.Close();
                return;
            }
        }

        private void UltimaTabulacionN(int turnoB)
        {
            string sql = "SELECT Top 1 A.Fecha from Pagos A INNER JOIN Turno C ON A.ID_Usuario = C.ID_Usuario and A.Turno = C.Turno " +
                "where A.fecha BETWEEN @fechaA and @fechaB and A.Turno = @turno and C.fecha BETWEEN @fechaA and @fechaC order by A.fecha DESC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaA", fechaPrimerTurno);
                cmd.Parameters.AddWithValue("fechaB", fechaUltimoAvance);
                cmd.Parameters.AddWithValue("fechaC", fechaUltimoTurno);
                cmd.Parameters.AddWithValue("turno", turnoB);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fechaUltimaTabulacionN = Convert.ToString(Convert.ToDateTime(dr["Fecha"]).AddMinutes(15)); //Ultima Tabulacion del turno
                }
                dr.Close();
                return;
            }
        }


    }
}
