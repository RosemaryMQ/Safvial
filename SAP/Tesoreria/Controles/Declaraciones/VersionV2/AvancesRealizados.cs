using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class AvancesRealizados : Form
    {

        public static string fechab1 = "";
        public static string fechab2 = "";
        public static string canalb1 = "";
        public AvancesRealizados()
        {
            InitializeComponent();
            label1.Text = SAP.Tesoreria.Controles.ListaDeclaraciones.nombreusuario;
            this.ActualizarGrid1();
            
        }
        public async void ActualizarGrid1()
        {
            try
            {
                List<string> list = new List<string>(await ConsultaC(ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal, ListaDeclaraciones.ID_Usuario));
                int count = list.Count();
                int counts = 0;
                string fecha = "";
                string fecha1 = "";
                string canal = "";
                for (int i = 0; i < count; i++)
                {
                    fecha = list[i].ToString();
                    i++;
                    canal = list[i].ToString();
                    i++;
                    fecha1 = list[i].ToString();
                    Usuario.Rows.Add(counts, fecha, fecha1, canal, "ver");
                    counts++;
                    i++;
                    canal = list[i].ToString();
                    i++;
                    fecha = list[i].ToString();
                    Usuario.Rows.Add(counts, fecha1, fecha, canal, "ver");
                    counts++;
                    i = i - 1;

                };
            }
            catch
            {

            }

            //SqlConnection cn = new SqlConnection(Inicio.conexion);
            //cn.Open();
            //SqlDataReader dr;
            //SqlCommand cmd = new SqlCommand("SELECT ID_Avance,Canal,Fecha FROM Avances Where Fecha between @fecha and @fecha1", cn);
            //cmd.Parameters.AddWithValue("fecha", SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial);
            //cmd.Parameters.AddWithValue("fecha1", SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
            //dr = cmd.ExecuteReader();
            //Usuario.Rows.Clear();
            //while (dr.Read())
            //{
            //    Usuario.Rows.Add(dr["ID_Avance"].ToString(), dr["Fecha"].ToString(), dr["Canal"].ToString());
            //}
            //dr.Close();
        }
        private async Task<List<string>> ConsultaC(string fecha, string fecha1, int user)
        {
            List<string> list = new List<string>();
            //list.Add(SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial);
            //list.Add(await Canales(fecha, fecha1, user));
            SqlConnection cn = new SqlConnection(Inicio.conexion);
            await cn.OpenAsync();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT Fecha,Canal FROM Avances Where Fecha between @fecha and @fecha1 and ID_Usuario=@user Order by Fecha ASC", cn);
            cmd.Parameters.AddWithValue("fecha", fecha);
            cmd.Parameters.AddWithValue("fecha1", fecha1);
            cmd.Parameters.AddWithValue("user", user);
            dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                list.Add(dr["Fecha"].ToString());
                list.Add(dr["Canal"].ToString());
            }
            cn.Close();
            //list.Add(SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
            //list.Add(await Canales1(fecha, fecha1, user));
            return list;
        }
        private void Usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Usuario.Rows[e.RowIndex];
            fechab1 = Convert.ToString(row.Cells[1].Value);
            fechab2 = Convert.ToString(row.Cells[2].Value);
            canalb1  = Convert.ToString(row.Cells[3].Value);
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvanceReport frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvanceReport();
            frm.ShowDialog();

        }

        private void Usuario_Click(object sender, EventArgs e)
        {

        }

        private void Usuario_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            
        }
        private async Task<string> Canales(string fecha, string fecha1, int user)
        {
            string canal = "";
            string sql = "SELECT Canal FROM Avances Where Fecha between @fecha and @fecha1 and ID_Usuario=@user Order by Fecha DESC";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("user", user);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    canal = dr["Canal"].ToString();
                }
                cn.Close();
                return canal;
            }
        }
        private async Task<string> Canales1(string fecha, string fecha1, int user)
        {
            string canal = "";
            string sql = "SELECT Canal FROM Avances Where Fecha between @fecha and @fecha1 and ID_Usuario=@user Order by Fecha ASC";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("user", user);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    canal = dr["Canal"].ToString();
                }
                cn.Close();
                return canal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
