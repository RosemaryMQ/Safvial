using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Auditoria
{
    public partial class HistorialCanal : Form
    {
        string mes;
        string year;
        string fecha;
        string finicial;
        string ffinal;
        string id;
        public HistorialCanal()
        {
            InitializeComponent();
            mes = DateTime.Now.Month.ToString();
            year = DateTime.Now.Year.ToString();
            fecha = "01/" + mes + "/" + year + " 00:00:00";
            ActualizarGrid1(SAP.Tesoreria.TesoreriaV2.CanalUser,fecha,DateTime.Now.ToString("G"));
            Titulos.Text = "CANAL: "+SAP.Tesoreria.TesoreriaV2.CanalUser;
        }
        public void ActualizarGrid1(string canal,string fecha,string fecha2)
        {
            int contador = 0;
            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT Distinct Pagos.Canal,Recaudadore.ID_Usuario,Usuarios.Nombre,Usuarios.Apellido,Usuarios.Nickname,CONVERT(DATE, Recaudadore.FechaFin, 103) AS Fecha,Recaudadore.ID FROM Recaudadore INNER JOIN Pagos ON Recaudadore.Canal = Pagos.Canal INNER JOIN Usuarios ON Recaudadore.ID_Usuario = Usuarios.ID_Usuario WHERE Pagos.Canal=@canal AND Recaudadore.Fecha BETWEEN @fecha AND @fecha2 AND day(Pagos.Fecha)=day(Recaudadore.FechaFin) AND Recaudadore.Estatus='Finalizado' GROUP BY Pagos.Canal,Recaudadore.ID_Usuario,Recaudadore.FechaFin,Usuarios.Nombre,Usuarios.Apellido,Usuarios.Nickname,Recaudadore.ID ORDER BY CONVERT(DATE, Recaudadore.FechaFin, 103) DESC;", cn);
            cmd.Parameters.AddWithValue("canal", canal);
            cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
            cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fecha2));
            dr = cmd.ExecuteReader();
            Declaraciones.Rows.Clear();
            while (dr.Read())
            {  
                contador = contador+1;
                Declaraciones.Rows.Add(contador, dr["ID_Usuario"].ToString(), dr["Nombre"].ToString()+" "+ dr["Apellido"].ToString(), "V-" + string.Format("{0:n0}", dr["Nickname"].ToString()),Convert.ToDateTime(dr["Fecha"].ToString()), "VER");
            }
            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActualizarGrid1(SAP.Tesoreria.TesoreriaV2.CanalUser,date1.Value.ToShortDateString() + " 00:00:00",date2.Value.ToShortDateString() + " 23:59:59");
        }

        private void Declaraciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ffinal = "";
            finicial = "";
            DataGridViewRow row = Declaraciones.Rows[e.RowIndex];
            ConsultaEspecial(Convert.ToString(row.Cells[1].Value), Convert.ToString(row.Cells[4].Value).Substring(0, 10) + " 00:00:00", Convert.ToString(row.Cells[4].Value).Substring(0, 10) + " 23:59:59");
            if (finicial!= "" && ffinal!= "")
            {
                SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta = Convert.ToInt32(id);
                SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1 = Convert.ToString(row.Cells[1].Value);
                SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial = Convert.ToString(finicial);
                SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal = Convert.ToString(ffinal);
                SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario = Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1);
                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado frm = new SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario Aperturado sin registro en sistema.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ffinal = "";
                finicial = "";
            }
            
        }
        private void ConsultaEspecial(string usuario,string fecha,string fecha2)
        {
            string sql = "SELECT distinct  ID,Fecha,FechaFin FROM Recaudadore WHERE ID_Usuario=@usuario AND FechaFin BETWEEN @fecha AND @fecha2";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha",Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fecha2));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    finicial = dr["Fecha"].ToString();
                    ffinal = dr["FechaFin"].ToString();
                    id = dr["ID"].ToString();
                }
                dr.Close();
                return;
            }
        }
    }
}
