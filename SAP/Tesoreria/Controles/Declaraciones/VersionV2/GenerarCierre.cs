using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class GenerarCierre : Form
    {
        public static int turno;
        string hora;
        string hora1;
        string hora2;
        string hora3;
        string control;
        public static string fechaS;
        public static string fechaS1;
        public static string fechaPrimeraTabulacion;
        public static string fechaUltimaTabulacion;
        public static string fechaSolicitud;
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
                date2.Enabled = false;
                //hora = " 21:00:00";
                //hora1 = " 20:59:59";
                hora = " 00:00:00";
                hora1 = " 11:59:59";
                hora2 = " 12:00:00";
                hora3 = " 23:59:59";
            }
            else if (control == "Turno 12h 12:00 - 23:59")
            {
                turno = 9;
                date2.Enabled = false;
                //hora = " 10:00:00";
                //hora1 = " 09:59:00";
                hora = " 12:00:00";
                hora1 = " 23:59:59";
                hora2 = " 00:00:00";
                hora3 = " 11:59:59";
            }
            else if (control == "Diario (24 Horas)")
            {
                turno = 10;
                date2.Enabled = false;
                hora = " 00:00:00";
                hora1 = " 23:59:59";
            }
            else if(control==""){
                date2.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fechaS = "";
            fechaS1 = "";
            fechaSolicitud = "";
            fechaPrimeraTabulacion = "";
            fechaUltimaTabulacion = "";
            try
            {
                fechaSolicitud = date1.Value.ToString("dd/MM/yyyy");
                if (turno == 10)
                {
                    fechaS1 = date1.Value.ToString("dd/MM/yyyy") + hora;
                    fechaS = date1.Value.ToString("dd/MM/yyyy") + hora1;
                    this.PrimeraTabulacionDiaria(fechaS1, fechaS);
                    this.UltimaTabulacionDiaria(fechaS1, fechaS);
                }
                else
                {
                    this.Control2(turno);//FECHA INICIO
                    if (fechaS1 == "")
                    {
                        this.Control2Alt(turno);//FECHA INICIO

                    }
                    this.Control(turno);//FECHA FIN
                    if (fechaS == "")
                    {
                        this.ControlAlt(turno);//FECHA INICIO

                    }
                    this.PrimeraTabulacion(turno, fechaS1, fechaS);
                    this.UltimaTabulacion(turno, fechaS1, fechaS);
                }
            }
            catch
            {
                MessageBox.Show("La fecha ingresada no posee registros detectados", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (turno == 10)
            {
                SAP.Tesoreria.Controles.Declaraciones.CierreTurnoDiario frm = new SAP.Tesoreria.Controles.Declaraciones.CierreTurnoDiario();
                frm.ShowDialog();
            }
            else
            {
                SAP.Tesoreria.Controles.Declaraciones.CierreTurno frm = new SAP.Tesoreria.Controles.Declaraciones.CierreTurno();
                frm.ShowDialog();
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
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", fechaS1);
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(date1.Value.ToShortDateString() + hora1).AddHours(2));
                cmd.Parameters.AddWithValue("turno", turno);

                // ExecuteScalar devuelve un 'object' directamente
                object resultado = cmd.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    // SI ENCONTRÓ DATO
                    fechaS = Convert.ToString(Convert.ToDateTime(resultado));
                }
                else
                {
                    // NO ENCONTRÓ DATO (resultado es null)
                    fechaS = "";
                }
            }
        }

        private void ControlAlt(int turno)
        {
            string sql = "SELECT TOP 1 Fecha FROM CierreBalanceV2 WHERE CierreBalanceV2.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha DESC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(date1.Value.ToShortDateString() + hora2));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(date1.Value.ToShortDateString() + hora3));
                cmd.Parameters.AddWithValue("turno", turno);

                // ExecuteScalar devuelve un 'object' directamente
                object resultado = cmd.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    // SI ENCONTRÓ DATO
                    fechaS = Convert.ToString(Convert.ToDateTime(resultado));
                }
                else
                {
                    // NO ENCONTRÓ DATO (resultado es null)
                    fechaS = date1.Value.Date.AddDays(1).ToString();
                }
            }
        }

        // FECHA DE INICIO
        private void Control2(int turno)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Turno.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha ASC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(date1.Value.ToShortDateString() + hora).AddHours(-4));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(date2.Value.ToShortDateString() + hora1));
                cmd.Parameters.AddWithValue("turno", turno);

                // ExecuteScalar devuelve un 'object' directamente
                object resultado = cmd.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    // SI ENCONTRÓ DATO
                    fechaS1 = Convert.ToString(Convert.ToDateTime(resultado));
                }
                else
                {
                    // NO ENCONTRÓ DATO (resultado es null)
                    fechaS1 = "";
                }
            }
        }

        private void Control2Alt(int turno)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Turno.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha ASC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(date1.Value.Date.AddDays(-1).ToShortDateString() + hora2));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(date2.Value.ToShortDateString() + hora3));
                cmd.Parameters.AddWithValue("turno", turno);

                // ExecuteScalar devuelve un 'object' directamente
                object resultado = cmd.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    // SI ENCONTRÓ DATO
                    fechaS1 = Convert.ToString(Convert.ToDateTime(resultado));
                }
                else
                {
                    // NO ENCONTRÓ DATO (resultado es null)
                    fechaS1 = date1.Value.Date.AddHours(-1).ToString();
                }
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

            if (turno == 8)
            {
                date2.Text = date1.Value.Date.AddDays(1).ToString();
            }
            else if (turno == 9)
            {
                date2.Text = date1.Value.Date.AddDays(1).ToString();
            }


        }


        private void PrimeraTabulacion(int turno, string fechaS1, string fechaS)
        {
            string sql = "SELECT Top 1 A.Fecha from Pagos A INNER JOIN Turno C ON A.ID_Usuario = C.ID_Usuario and A.Turno = C.Turno where A.fecha BETWEEN @fechaS1 and @fechaS and A.Turno = @turno and C.fecha BETWEEN @fechaS1 and @fechaS order by A.fecha ASC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaS1", fechaS1);
                cmd.Parameters.AddWithValue("fechaS", fechaS);
                cmd.Parameters.AddWithValue("turno", turno);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fechaPrimeraTabulacion = Convert.ToString(Convert.ToDateTime(dr["Fecha"])); //Primera Tabulacion del turno
                }
                dr.Close();
                return;
            }
        }

        private void UltimaTabulacion(int turno, string fechaS1, string fechaS)
        {
            string sql = "SELECT Top 1 A.Fecha from Pagos A INNER JOIN Turno C ON A.ID_Usuario = C.ID_Usuario and A.Turno = C.Turno where A.fecha BETWEEN @fechaS1 and @fechaS and A.Turno = @turno and C.fecha BETWEEN @fechaS1 and @fechaS order by A.fecha DESC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaS1", fechaS1);
                cmd.Parameters.AddWithValue("fechaS", fechaS);
                cmd.Parameters.AddWithValue("turno", turno);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fechaUltimaTabulacion = Convert.ToString(Convert.ToDateTime(dr["Fecha"])); //Primera Tabulacion del turno
                }
                dr.Close();
                return;
            }
        }

        private void PrimeraTabulacionDiaria(string fechaS1, string fechaS)
        {
            string sql = "SELECT Top 1 A.Fecha from Pagos A INNER JOIN Turno C ON A.ID_Usuario = C.ID_Usuario and A.Turno = C.Turno where A.fecha BETWEEN @fechaS1 and @fechaS and C.fecha BETWEEN @fechaS1 and @fechaS order by A.fecha ASC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaS1", fechaS1);
                cmd.Parameters.AddWithValue("fechaS", fechaS);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fechaPrimeraTabulacion = Convert.ToString(Convert.ToDateTime(dr["Fecha"])); //Primera Tabulacion del turno
                }
                dr.Close();
                return;
            }
        }

        private void UltimaTabulacionDiaria(string fechaS1, string fechaS)
        {
            string sql = "SELECT Top 1 A.Fecha from Pagos A INNER JOIN Turno C ON A.ID_Usuario = C.ID_Usuario and A.Turno = C.Turno where A.fecha BETWEEN @fechaS1 and @fechaS and C.fecha BETWEEN @fechaS1 and @fechaS order by A.fecha DESC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaS1", fechaS1);
                cmd.Parameters.AddWithValue("fechaS", fechaS);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fechaUltimaTabulacion = Convert.ToString(Convert.ToDateTime(dr["Fecha"])); //Primera Tabulacion del turno
                }
                dr.Close();
                return;
            }
        }


    }
}
