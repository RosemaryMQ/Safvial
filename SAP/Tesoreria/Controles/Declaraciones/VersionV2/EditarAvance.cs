using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class EditarAvance : Form
    {
        double efectivo;
        int turno;
        public static int validador = 0;
        DateTime fecha;
        int idnew;
        int idope;
        Boolean buzon = false;
        public EditarAvance()
        {
            InitializeComponent();
            turno = 0;
            BuscarAvance(Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.declaracion));
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13) && e.KeyChar != (char)Keys.Oemcomma)
            {
                e.Handled = true;
                return;
            }
        }
        private void BuscarAvance(int codigo)
        {
            string sql = "SELECT  ID_Cierre, BilleteS05, BilleteS1, BilleteS2, BilleteS5, BilleteS10, BilleteS20, BilleteS50, BilleteS100, BilleteS200, BilleteS500, BilleteS10000, BilleteS20000, BilleteS50000,BilleteS200000,BilleteS500000,BilleteS1000000, Tickets, PDV, Incidencia,Transferencia, Turno,Fecha, Buzon, BilleteBD1,BilleteBD5,BilleteBD10,BilleteBD20,BilleteBD50,BilleteBD100,BilleteBD025,BilleteBD05 FROM  CierreBalanceV2 WHERE (ID_Cierre = @Codigo);";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("Codigo", codigo);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bt1.Text= dr["BilleteS05"].ToString();
                    bt2.Text = dr["BilleteS1"].ToString();
                    bt3.Text = dr["BilleteS2"].ToString();
                    bt4.Text = dr["BilleteS5"].ToString();
                    bt5.Text = dr["BilleteS10"].ToString();
                    bt6.Text = dr["BilleteS20"].ToString();
                    bt7.Text = dr["BilleteS50"].ToString();
                    bt8.Text = dr["BilleteS100"].ToString();
                    bt9.Text = dr["BilleteS200"].ToString();
                    bt10.Text = dr["BilleteS500"].ToString();
                    bt11.Text = dr["BilleteS10000"].ToString();
                    bt12.Text = dr["BilleteS20000"].ToString();
                    bt13.Text = dr["BilleteS50000"].ToString();
                    bt14.Text = dr["BilleteS200000"].ToString();
                    bt15.Text = dr["BilleteS500000"].ToString();
                    bt16.Text = dr["BilleteS1000000"].ToString();
                    bt17.Text = dr["BilleteBD1"].ToString();
                    bt18.Text = dr["BilleteBD5"].ToString();
                    bt19.Text = dr["BilleteBD10"].ToString();
                    bt20.Text = dr["BilleteBD20"].ToString();
                    bt21.Text = dr["BilleteBD50"].ToString();
                    bt22.Text = dr["BilleteBD100"].ToString();
                    bt23.Text = dr["BilleteBD025"].ToString();
                    bt24.Text = dr["BilleteBD05"].ToString();
                    PDV.Text = dr["PDV"].ToString();
                    ticket.Text = dr["Tickets"].ToString();
                    Transferencia.Text = dr["Transferencia"].ToString();
                    turno = Convert.ToInt32(dr["Turno"]);
                    fecha= Convert.ToDateTime(dr["Fecha"]).AddMilliseconds(5);
                    buzon = Convert.ToBoolean(dr["Buzon"]);
                }
                dr.Close();
                return;
            }
        }
        private void ActualizarEstatus(string codigo)
        {
            string sql = "UPDATE CierreBalanceV2 SET Eliminado=1 WHERE ID_Cierre = @Codigo;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("Codigo", codigo);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CargaAvance(DateTime fecha, int turno, bool buzon)
        {
            string sql = "Insert into CierreBalanceV2 (BilleteS05,BilleteS1,BilleteS2,BilleteS5,BilleteS10,BilleteS20,BilleteS50,BilleteS100,BilleteS200,BilleteS500,Tickets,Efectivo,PDV,Incidencia,ID_Usuario,Fecha,Responsable,TesoreroC,Turno,BilleteS10000,BilleteS20000,BilleteS50000,Transferencia,Eliminado,buzon,BilleteS200000,BilleteS500000,BilleteS1000000,BilleteBD1,BilleteBD5,BilleteBD10,BilleteBD20,BilleteBD50,BilleteBD100,BilleteBD05,BilleteBD02,BilleteBD025) Values (@bt1,@bt2,@bt3,@bt4,@bt5,@bt6,@bt7,@bt8,@bt9,@bt10,@tickets,@efectivo,@pdv,@incidencia,@id,@fecha,@id2,@tesorero,@turno,@bt11,@bt12,@bt13,@transf,0,@buzon,@bt14,@bt15,@bt16,@bt17,@bt18,@bt19,@bt20,@bt21,@bt22,@bt24,0,@bt23)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("bt1", bt1.Text);
                cmd.Parameters.AddWithValue("bt2", bt2.Text);
                cmd.Parameters.AddWithValue("bt3", bt3.Text);
                cmd.Parameters.AddWithValue("bt4", bt4.Text);
                cmd.Parameters.AddWithValue("bt5", bt5.Text);
                cmd.Parameters.AddWithValue("bt6", bt6.Text);
                cmd.Parameters.AddWithValue("bt7", bt7.Text);
                cmd.Parameters.AddWithValue("bt8", bt8.Text);
                cmd.Parameters.AddWithValue("bt9", bt9.Text);
                cmd.Parameters.AddWithValue("bt10", bt10.Text);
                cmd.Parameters.AddWithValue("bt11", bt11.Text);
                cmd.Parameters.AddWithValue("bt12", bt12.Text);
                cmd.Parameters.AddWithValue("bt13", bt13.Text);
                cmd.Parameters.AddWithValue("bt14", bt14.Text);
                cmd.Parameters.AddWithValue("bt15", bt15.Text);
                cmd.Parameters.AddWithValue("bt16", bt16.Text);
                cmd.Parameters.AddWithValue("tickets", ticket.Text);
                cmd.Parameters.AddWithValue("pdv", Convert.ToDouble(PDV.Text));
                cmd.Parameters.AddWithValue("incidencia", 0);
                cmd.Parameters.AddWithValue("efectivo", efectivo);
                cmd.Parameters.AddWithValue("transf", Convert.ToDouble(Transferencia.Text));
                cmd.Parameters.AddWithValue("id", SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("id2", SAP.Inicio.ID);
                cmd.Parameters.AddWithValue("tesorero", SAP.Inicio.ID);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("buzon", buzon);
                cmd.Parameters.AddWithValue("bt17", bt17.Text);
                cmd.Parameters.AddWithValue("bt18", bt18.Text);
                cmd.Parameters.AddWithValue("bt19", bt19.Text);
                cmd.Parameters.AddWithValue("bt20", bt20.Text);
                cmd.Parameters.AddWithValue("bt21", bt21.Text);
                cmd.Parameters.AddWithValue("bt22", bt22.Text);
                cmd.Parameters.AddWithValue("bt23", bt23.Text);
                cmd.Parameters.AddWithValue("bt24", bt24.Text);
                cmd.ExecuteReader();
                return;
            }
        }
      
        private void CargarModificacion(int operacion, string cierre, int cierren, int cataporte)
        {
            string sql = "Insert into Cambios (ID_Operacion,ID_Cierre,ID_CierreN,ID_Cataporte) Values (@bt1,@bt2,@bt3,@bt4)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("bt1", operacion);
                cmd.Parameters.AddWithValue("bt2", cierre);
                cmd.Parameters.AddWithValue("bt3", cierren);
                cmd.Parameters.AddWithValue("bt4", cataporte);
                cmd.ExecuteReader();
                return;
            }
        }
        private void BuscarNuevo(int usuario, DateTime fecha, int turno)
        {
            string sql = "SELECT  ID_Cierre FROM  CierreBalanceV2 WHERE (Fecha = @fecha) AND (Turno=@turno) AND (ID_Usuario=@user);";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("user", usuario);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    idnew = Convert.ToInt32(dr["ID_Cierre"]);
                }
                dr.Close();
                return;
            }
        }
        private void BuscarOperacion(string usuario, string cierre)
        {
            string sql = "SELECT  ID_Operacion FROM  Operacion WHERE (ID_Usuario=@usuario) AND (ID_Cierre=@cierre);";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("cierre", cierre);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    idope = Convert.ToInt32(dr["ID_Operacion"]);
                }
                dr.Close();
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bt1.Text != "" && bt2.Text != "" && bt3.Text != "" && bt4.Text != "" && bt5.Text != "" && bt6.Text != "" && bt7.Text != "" && bt8.Text != "" && bt9.Text != "" && bt10.Text != "" && bt11.Text != "" && bt12.Text != "" && bt13.Text != "" && bt14.Text != "" && bt15.Text != "" && bt16.Text != "" && bt17.Text != "" && bt18.Text != "" && bt19.Text != "" && bt20.Text != "" && bt21.Text != "" && bt22.Text != "" && PDV.Text != "" && ticket.Text != "" && Transferencia.Text != "")
                {
                    SAP.Tesoreria.Controles.Declaraciones.VersionV2.Motivo frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Motivo();
                    frm.ShowDialog();
                    if (validador > 0)
                    {
                        validador = 0;
                        efectivo = ((0.50 * Convert.ToDouble(bt1.Text)) / 1000000) + ((1 * Convert.ToDouble(bt2.Text)) / 1000000) + ((2 * Convert.ToDouble(bt3.Text)) / 1000000) + ((5 * Convert.ToDouble(bt4.Text)) / 1000000) + ((10 * Convert.ToDouble(bt5.Text)) / 1000000) + ((20 * Convert.ToDouble(bt6.Text)) / 1000000) + ((50 * Convert.ToDouble(bt7.Text)) / 1000000) + ((100 * Convert.ToDouble(bt8.Text)) / 1000000) + ((200 * Convert.ToDouble(bt9.Text)) / 1000000) + ((500 * Convert.ToDouble(bt10.Text)) / 1000000) + ((10000 * Convert.ToDouble(bt11.Text)) / 1000000) + ((20000 * Convert.ToDouble(bt12.Text)) / 1000000) + ((50000 * Convert.ToDouble(bt13.Text)) / 1000000) + ((200000 * Convert.ToDouble(bt14.Text)) / 1000000) + ((500000 * Convert.ToDouble(bt15.Text)) / 1000000) + ((1000000 * Convert.ToDouble(bt16.Text)) / 1000000) + (1 * Convert.ToDouble(bt17.Text)) + (5 * Convert.ToDouble(bt18.Text)) + (10 * Convert.ToDouble(bt19.Text)) + (20 * Convert.ToDouble(bt20.Text)) + (50 * Convert.ToDouble(bt21.Text)) + (100 * Convert.ToDouble(bt22.Text)) + (0.25 * Convert.ToDouble(bt23.Text)) + (0.50 * Convert.ToDouble(bt24.Text));
                        CargaAvance(fecha, turno, buzon);
                        BuscarNuevo(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, fecha, turno);
                        BuscarOperacion(SAP.Inicio.ID, SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.declaracion);
                        ActualizarEstatus(SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.declaracion);
                        CargarModificacion(idope, SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.declaracion, idnew, SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta);
                        MessageBox.Show("Avance editado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("No se puede editar si los campos estan vacios por favor verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error al intentar editar el campo por favor reintente"+ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void bt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
    }
}
