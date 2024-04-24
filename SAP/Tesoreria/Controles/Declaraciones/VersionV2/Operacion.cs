using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class Operacion : Form
    {
        int antes = 0;
        int despues = 0;
        public Operacion()
        {
            try
            {
                InitializeComponent();
                OperacionCambio(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta), Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.Bitacora.operacion));
                CargarAntes(antes);
                CargarDespues(despues);
                motivo.Text = SAP.Tesoreria.Controles.Declaraciones.VersionV2.Bitacora.observacion;
            }
            catch
            {
                MessageBox.Show("Error al intentar consultar la informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
           
        }
        public void CargarAntes(int cierre)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT  ID_Cierre, BilleteS05, BilleteS1, BilleteS2, BilleteS5, BilleteS10, BilleteS20, BilleteS50, BilleteS100, BilleteS200, BilleteS500, BilleteS10000, BilleteS20000, BilleteS50000,BilleteS200000,BilleteS500000,BilleteS1000000,Tickets, Efectivo, PDV, Incidencia, ID_Usuario,Transferencia,BilleteBD1,BilleteBD5,BilleteBD10,BilleteBD20,BilleteBD50,BilleteBD100,BilleteBD025,BilleteBD05 FROM CierreBalanceV2 WHERE ID_Cierre=@cierre", cn);
            cmd.Parameters.AddWithValue("cierre", cierre);
            dr = cmd.ExecuteReader();
            AntesV.Rows.Clear();
            while (dr.Read())
            {
                AntesV.Rows.Add(dr["ID_Cierre"].ToString(), dr["BilleteS05"].ToString(), dr["BilleteS1"].ToString(), dr["BilleteS2"].ToString(), dr["BilleteS5"].ToString(), dr["BilleteS10"].ToString(), dr["BilleteS20"].ToString(), dr["BilleteS50"].ToString(), dr["BilleteS100"].ToString(), dr["BilleteS200"].ToString(), dr["BilleteS500"].ToString(), dr["BilleteS10000"].ToString(), dr["BilleteS20000"].ToString(), dr["BilleteS50000"].ToString(), dr["BilleteS200000"].ToString(), dr["BilleteS500000"].ToString(), dr["BilleteS1000000"].ToString(), dr["BilleteBD025"].ToString(), dr["BilleteBD05"].ToString(), dr["BilleteBD1"].ToString(), dr["BilleteBD5"].ToString(), dr["BilleteBD10"].ToString(), dr["BilleteBD20"].ToString(), dr["BilleteBD50"].ToString(), dr["BilleteBD100"].ToString(), dr["PDV"].ToString(), dr["Incidencia"].ToString(), dr["Transferencia"].ToString());
            }
            dr.Close();
        }
        public void CargarDespues(int cierre)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT  ID_Cierre, BilleteS05, BilleteS1, BilleteS2, BilleteS5, BilleteS10, BilleteS20, BilleteS50, BilleteS100, BilleteS200, BilleteS500, BilleteS10000, BilleteS20000, BilleteS50000,BilleteS50000,BilleteS200000,BilleteS500000,BilleteS1000000,Tickets, Efectivo, PDV, Incidencia, ID_Usuario,Transferencia,BilleteBD1,BilleteBD5,BilleteBD10,BilleteBD20,BilleteBD50,BilleteBD100,BilleteBD025,BilleteBD05 FROM CierreBalanceV2 WHERE ID_Cierre=@cierre", cn);
            cmd.Parameters.AddWithValue("cierre", cierre);
            dr = cmd.ExecuteReader();
            Despues.Rows.Clear();
            while (dr.Read())
            {
                Despues.Rows.Add(dr["ID_Cierre"].ToString(), dr["BilleteS05"].ToString(), dr["BilleteS1"].ToString(), dr["BilleteS2"].ToString(), dr["BilleteS5"].ToString(), dr["BilleteS10"].ToString(), dr["BilleteS20"].ToString(), dr["BilleteS50"].ToString(), dr["BilleteS100"].ToString(), dr["BilleteS200"].ToString(), dr["BilleteS500"].ToString(), dr["BilleteS10000"].ToString(), dr["BilleteS20000"].ToString(), dr["BilleteS50000"].ToString(), dr["BilleteS200000"].ToString(), dr["BilleteS500000"].ToString(), dr["BilleteS1000000"].ToString(), dr["BilleteBD025"].ToString(), dr["BilleteBD05"].ToString(), dr["BilleteBD1"].ToString(), dr["BilleteBD5"].ToString(), dr["BilleteBD10"].ToString(), dr["BilleteBD20"].ToString(), dr["BilleteBD50"].ToString(), dr["BilleteBD100"].ToString(), dr["PDV"].ToString(), dr["Incidencia"].ToString(), dr["Transferencia"].ToString());
            }
            dr.Close();
        }
        private void OperacionCambio(int cataporte, int operacion)
        {
            string sql = "SELECT ID_Cierre,ID_CierreN FROM Cambios Where ID_Cataporte= @cataporte AND ID_Operacion=@operacion;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cataporte", cataporte);
                cmd.Parameters.AddWithValue("operacion", operacion);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                        antes = Convert.ToInt32(dr["ID_Cierre"]);
                        despues = Convert.ToInt32(dr["ID_CierreN"]);
                }
                dr.Close();
                return;
            }
        }
    }
}
