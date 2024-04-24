using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Cobradores.Controles
{
    public partial class Contraseña : Form
    {
        String PDV;
        String Efectivo;
        String Tickets;
        String Prepagado;
        String NoPagados;
        String Estado = "Operativo";
        String boton1 = "Desactivar";
        string master = SAP.Inicio.master;
        string clave = SAP.Inicio.clave;
        public Contraseña()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                    this.cajallena(SAP.Inicio.ID);
                    this.ContadorPDV(DateTime.Now.ToString("d"), Convert.ToInt32(SAP.Inicio.ID));
                    this.ContadorEfectivo(DateTime.Now.ToString("d"), Convert.ToInt32(SAP.Inicio.ID));
                    this.ContadorTickets(DateTime.Now.ToString("d"), Convert.ToInt32(SAP.Inicio.ID));
                    this.ContadorPrepagado(DateTime.Now.ToString("d"), Convert.ToInt32(SAP.Inicio.ID));
                    this.ContadorNoPagado(DateTime.Now.ToString("d"), Convert.ToInt32(SAP.Inicio.ID));
                    this.reportecaja(SAP.Inicio.ID, SAP.Inicio.Canal, DateTime.Now.ToString("G"), Convert.ToString(SAP.Cobradores.Recaudadores.recaudacion), Convert.ToInt32(Efectivo), Convert.ToInt32(PDV), Convert.ToInt32(Tickets), Convert.ToInt32(Prepagado), Convert.ToInt32(NoPagados));
                    MessageBox.Show("Autorizacion concendida cierre parcial cargado exitosamente.", "Notifacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SAP.Cobradores.Recaudadores.Estado = Estado;
                    SAP.Cobradores.Recaudadores.Boton1 = boton1;
                    SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
                    frm.Show();
                    SAP.Cobradores.Controles.Avance frm2 = new SAP.Cobradores.Controles.Avance();
                    frm2.Show();
                    this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
            frm.Show();
            this.Close();
        }
        private void cajallena(string usuario)
        {
            string sql = "Update ControlRecaudadores Set Estado='Operativo' Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.ExecuteReader();
                return;
            }
        }
        private void reportecaja(string usuario,string canal,string fecha,string monto,int efectivo,int pdv,int tickets,int prepagado,int nopagados)
        {
            string sql = "Insert into CierreCajas (Usuario,Canal,Fecha,MontoVaciado,Efectivo,PDV,Tickets,Prepagado,NoPagados) values (@usuario,@canal,@fecha,@monto,@efectivo,@pdv,@tickets,@prepagado,@nopagados)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", Convert.ToInt32(usuario));
                cmd.Parameters.AddWithValue("canal", Convert.ToInt32(canal));
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("monto", Convert.ToDouble(monto));
                cmd.Parameters.AddWithValue("efectivo", efectivo);
                cmd.Parameters.AddWithValue("pdv", pdv);
                cmd.Parameters.AddWithValue("tickets", tickets);
                cmd.Parameters.AddWithValue("prepagado", prepagado);
                cmd.Parameters.AddWithValue("nopagados", nopagados);
                cmd.ExecuteReader();
                return;
            }
        }
        private void ContadorPDV(String fechas, int canal)
        {
            string sql = " SELECT COUNT(FormaPago) AS PDV FROM Pagos WHERE(FormaPago = 'Punto de Venta') AND(Fecha BETWEEN @parametro + '00:00:00' AND @parametro + '23:59:59') AND(ID_Usuario = @usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("parametro", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("usuario", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PDV = dr["PDV"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void ContadorTickets(String fechas,  int canal)
        {
            string sql = " SELECT COUNT(FormaPago) AS Tickets FROM Pagos WHERE(FormaPago = 'Ticket') AND(Fecha BETWEEN @parametro + '00:00:00' AND @parametro + '23:59:59') AND(ID_Usuario = @usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("parametro", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("usuario", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Tickets = dr["Tickets"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void ContadorEfectivo(String fechas, int canal)
        {
            string sql = " SELECT COUNT(FormaPago) AS Efectivo FROM Pagos WHERE(FormaPago = 'Efectivo') AND(Fecha BETWEEN @parametro + '00:00:00' AND @parametro + '23:59:59') AND(ID_Usuario = @usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("parametro", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("usuario", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Efectivo = dr["Efectivo"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void ContadorPrepagado(String fechas, int canal)
        {
            string sql = " SELECT COUNT(FormaPago) AS Prepagado FROM Pagos WHERE(FormaPago = 'Saldo Pre-pagado') AND(Fecha BETWEEN @parametro + '00:00:00' AND @parametro + '23:59:59') AND(ID_Usuario = @usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("parametro", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("usuario", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Prepagado = dr["Prepagado"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void ContadorNoPagado(String fechas, int canal)
        {
            string sql = " SELECT COUNT(FormaPago) AS NoPagos FROM Pagos WHERE(FormaPago = 'No Pago') AND(Fecha BETWEEN @parametro + '00:00:00' AND @parametro + '23:59:59') AND(ID_Usuario = @usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("parametro", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("usuario", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    NoPagados = dr["NoPagos"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                       
    
            }
            if (e.KeyCode == Keys.Escape)
            {
                SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
                frm.Show();
                this.Close();
            }
        }
    }
}
