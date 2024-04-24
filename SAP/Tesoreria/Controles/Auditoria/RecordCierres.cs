using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Auditoria
{
    public partial class RecordCierres : Form
    {
        string acumulador;
        double sumar;
        double conversor;
        double totales;
        double totales1;
        double record;
        double sistema1;
        double comparar;
        string resultados;
        string mes;
        string year;
        public RecordCierres()
        {
            InitializeComponent();
            mes = DateTime.Now.Month.ToString();
            year = DateTime.Now.Month.ToString();
            Titulos.Text ="RERCORD DE CIERRES: - "+SAP.Tesoreria.TesoreriaV2.Nombre;
            this.ActualizarGrid2(SAP.Tesoreria.TesoreriaV2.Identificador, date1.Value.ToShortDateString() + " 00:00:00", date2.Value.ToShortDateString() + " 23:59:59");
        }

        public void ActualizarGrid2(string usuario, string fecha, string fecha2)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select Recaudadore.ID,Recaudadore.Fecha,Recaudadore.FechaFin,Recaudadore.ID_Usuario from Recaudadore WHERE Recaudadore.ID_Usuario=@usuario and Recaudadore.FechaFin Between @fecha and @fecha2 order by ID DESC", cn);
            cmd.Parameters.AddWithValue("usuario", usuario);
            cmd.Parameters.AddWithValue("fecha", fecha);
            cmd.Parameters.AddWithValue("fecha2", fecha2);
            dr = cmd.ExecuteReader();
            Declaraciones.Rows.Clear();
            while (dr.Read())
            {
                totales = 0;
                totales1 = 0;
                record = 0;
                comparar = 0;
                Cierres(SAP.Tesoreria.TesoreriaV2.Identificador, dr["Fecha"].ToString(), dr["FechaFin"].ToString());
                totales = conversor;
                CierresV2(SAP.Tesoreria.TesoreriaV2.Identificador, dr["Fecha"].ToString(), dr["FechaFin"].ToString());
                totales1 = sumar;
                record = totales + totales1;
                sistemas(SAP.Tesoreria.TesoreriaV2.Identificador, dr["Fecha"].ToString(), dr["FechaFin"].ToString());
                comparar = record - sistema1;
                resultados = string.Format("{0:n}", comparar) + " Bs.S";
                Declaraciones.Rows.Add(dr["ID"].ToString(), dr["Fecha"].ToString(), dr["FechaFin"].ToString(), dr["ID_Usuario"].ToString(), Convert.ToString(resultados), "VER");


            }
            dr.Close();

        }
        private void Cierres(string usuario, string fecha,string fecha2)
        {
            string sql = "Select (CierreBalance.Efectivo+CierreBalance.PDV-CierreBalance.Incidencia) as Fuertes FROM CierreBalance Where CierreBalance.Fecha Between @fecha and @fecha2 AND CierreBalance.ID_Usuario=@usuario;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                dr = cmd.ExecuteReader();
                sumar = 0;
                conversor = 0;
                acumulador = "";
                while (dr.Read())
                {
                    acumulador = dr["Fuertes"].ToString();
                    sumar = sumar + Convert.ToDouble(acumulador);
                    
                }
                conversor = sumar / 10000;
                dr.Close();
                return;
            }
        }
        private void sistemas(string usuario, string fecha, string fecha2)
        {
            string sql = "SELECT TipoVehiculos.Tarifa FROM Pagos INNER JOIN TipoVehiculos ON Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo WHERE Pagos.ID_Usuario=@usuario and Pagos.Fecha Between @fecha and @fecha2 AND Pagos.FormaPago<>'Pago Incompleto';";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                dr = cmd.ExecuteReader();
                sistema1 = 0;
                conversor = 0;
                acumulador = "";
                while (dr.Read())
                {
                    acumulador = dr["Tarifa"].ToString();
                    sistema1 = sistema1 + Convert.ToDouble(acumulador);
                    //if (sistema1 > 100000)
                    //{
                    //    sistema1 = 0;
                    //    conversor = (conversor + sistema1) / 10000;
                    //    sistema1 = conversor;
                    //}
                    
                }
                dr.Close();
                return;
            }
        }
        private void CierresV2(string usuario, string fecha, string fecha2)
        {
            string sql = "Select (CierreBalanceV2.Efectivo+CierreBalanceV2.PDV-CierreBalanceV2.Incidencia) as Soberanos FROM CierreBalanceV2 Where CierreBalanceV2.Fecha Between @fecha and @fecha2 AND CierreBalanceV2.ID_Usuario=@usuario;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                dr = cmd.ExecuteReader();
                sumar = 0;
                acumulador = "";
                while (dr.Read())
                {
                    acumulador = dr["Soberanos"].ToString();
                    sumar = sumar + Convert.ToDouble(acumulador);
                }
                dr.Close();
                return;
            }
        }
        private void Declaraciones_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Declaraciones.Rows[e.RowIndex];
            SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta = Convert.ToInt32(row.Cells[0].Value);
            SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1 = Convert.ToString(row.Cells[3].Value);
            SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial = Convert.ToString(row.Cells[1].Value);
            SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal = Convert.ToString(row.Cells[2].Value);
            SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario = Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1);
            SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado frm = new SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActualizarGrid2(SAP.Tesoreria.TesoreriaV2.Identificador, date1.Value.ToShortDateString() + " 00:00:00", date2.Value.ToShortDateString() + " 23:59:59");
        }
    }
}
