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
        string control;
        public static string fechaS;
        public static string fechaS1;
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
            }
            else if (control == "Turno 12h 12:00 - 23:59")
            {
                turno = 9;
                date2.Enabled = true;
                hora = " 10:00:00";
                hora1 = " 09:59:00";
            }
            else if(control==""){
                date2.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fechaS = "";
            fechaS1 = "";
            try
            {
                this.Control2(turno);//FECHA INICIO
                this.Control(turno);//FECHA FIN
            }
            catch
            {
                MessageBox.Show("La fecha ingresada no posee registros detectados", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SAP.Tesoreria.Controles.Declaraciones.CierreTurno frm = new SAP.Tesoreria.Controles.Declaraciones.CierreTurno();
            frm.ShowDialog();
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
    }
}
