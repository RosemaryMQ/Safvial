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
        int indice = 0;
        double bt1, bt2, bt3, bt4, bt5, bt6, bt7, bt8, bt9, bt10, bt11, bt12, bt13, bt14, bt15, bt16, bt17, bt18, bt19, bt20, bt21, bt22, bt23, bt24, bt25, bt26, bt27;

        private void Avance_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        double bio = 0, pd = 0, credito = 0, debito = 0, efectiv = 0, incidenci = 0, Transferencia = 0, total = 0;
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

        private void Denominaciones()
        {

            BolivaresSS.Rows.Add("10.000", "0");
            BolivaresSS.Rows.Add("20.000", "0");
            BolivaresSS.Rows.Add("50.000", "0");
            BolivaresSS.Rows.Add("200.000", "0");
            BolivaresSS.Rows.Add("500.000", "0");
            BolivaresSS.Rows.Add("1.000.000", "0");
            Avance.Rows.Add("0,25", "0");
            Avance.Rows.Add("0,50", "0");
            Avance.Rows.Add("1,00", "0");
            Avance.Rows.Add("5,00", "0");
            Avance.Rows.Add("10,00", "0");
            Avance.Rows.Add("20,00", "0");
            Avance.Rows.Add("50,00", "0");
            Avance.Rows.Add("100,00", "0");
            Avance.Rows.Add("200,00", "0");
            Avance.Rows.Add("500,00", "0");
            Avance.Rows.Add("Credito", "0");
            Avance.Rows.Add("Debito", "0");
            Avance.Rows.Add("Transferencia", "0");
            Avance.Rows.Add("Biopago", "0");
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
            string sql = "SELECT  ID_Cierre, BilleteS05, BilleteS1, BilleteS2, BilleteS5, BilleteS10, BilleteS20, BilleteS50, BilleteS100, BilleteS200, BilleteS500, BilleteS10000, BilleteS20000, BilleteS50000,BilleteS200000,BilleteS500000,BilleteS1000000, Tickets, PDV, Incidencia,Transferencia, Turno,Fecha, Buzon, BilleteBD1,BilleteBD5,BilleteBD10,BilleteBD20,BilleteBD50,BilleteBD100,BilleteBD025,BilleteBD05,BilleteBD200, BilleteBD500, BIO  FROM  CierreBalanceV2 WHERE (ID_Cierre = @Codigo);";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("Codigo", codigo);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    BolivaresSS.Rows.Add("0,50", dr["BilleteS05"].ToString());
                    BolivaresSS.Rows.Add("1,00", dr["BilleteS1"].ToString());
                    BolivaresSS.Rows.Add("2,00", dr["BilleteS2"].ToString());
                    BolivaresSS.Rows.Add("5,00", dr["BilleteS5"].ToString());
                    BolivaresSS.Rows.Add("10,00", dr["BilleteS10"].ToString());
                    BolivaresSS.Rows.Add("20,00", dr["BilleteS20"].ToString());
                    BolivaresSS.Rows.Add("50,00", dr["BilleteS50"].ToString());
                    BolivaresSS.Rows.Add("100,00", dr["BilleteS100"].ToString());
                    BolivaresSS.Rows.Add("200,00", dr["BilleteS200"].ToString());
                    BolivaresSS.Rows.Add("500,00", dr["BilleteS500"].ToString());
                    BolivaresSS.Rows.Add("10.000", dr["BilleteS10000"].ToString());
                    BolivaresSS.Rows.Add("20.000", dr["BilleteS20000"].ToString());
                    BolivaresSS.Rows.Add("50.000", dr["BilleteS50000"].ToString());
                    BolivaresSS.Rows.Add("200.000", dr["BilleteS200000"].ToString());
                    BolivaresSS.Rows.Add("500.000", dr["BilleteS500000"].ToString());
                    BolivaresSS.Rows.Add("1.000.000", dr["BilleteS1000000"].ToString());
                    Avance.Rows.Add("0,25", dr["BilleteBD025"].ToString());
                    Avance.Rows.Add("0,50", dr["BilleteBD05"].ToString());
                    Avance.Rows.Add("1,00", dr["BilleteBD1"].ToString());
                    Avance.Rows.Add("5,00", dr["BilleteBD5"].ToString());
                    Avance.Rows.Add("10,00", dr["BilleteBD10"].ToString());
                    Avance.Rows.Add("20,00", dr["BilleteBD20"].ToString());
                    Avance.Rows.Add("50,00", dr["BilleteBD50"].ToString());
                    Avance.Rows.Add("100,00", dr["BilleteBD100"].ToString());
                    Avance.Rows.Add("200,00", dr["BilleteBD200"].ToString());
                    Avance.Rows.Add("500,00", dr["BilleteBD500"].ToString());
                    Avance.Rows.Add("PDV", dr["PDV"].ToString());
                    Avance.Rows.Add("Transferencia", dr["Transferencia"].ToString());
                    Avance.Rows.Add("Biopago", dr["BIO"].ToString());
                    turno = Convert.ToInt32(dr["Turno"]);
                    fecha= Convert.ToDateTime(dr["Fecha"]).AddMilliseconds(5);
                    buzon = Convert.ToBoolean(dr["Buzon"]);
                    indice = 1;
                }
                dr.Close();
                return;
            }
        }

        private void Avance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (indice == 1)
            {
                foreach (DataGridViewRow row in Avance.Rows)
                {
                    double Cantidad = Convert.ToDouble(row.Cells[1].Value.ToString());
                    string Denominacion = row.Cells[0].Value.ToString();
                    switch (Denominacion)
                    {
                        case "0,25":
                            bt25 = Cantidad;
                            break;
                        case "0,50":
                            bt24 = Cantidad;
                            break;
                        case "1,00":
                            bt17 = Cantidad;
                            break;
                        case "5,00":
                            bt18 = Cantidad;
                            break;
                        case "10,00":
                            bt19 = Cantidad;
                            break;
                        case "20,00":
                            bt20 = Cantidad;
                            break;
                        case "50,00":
                            bt21 = Cantidad;
                            break;
                        case "100,00":
                            bt22 = Cantidad;
                            break;
                        case "200,00":
                            bt26 = Cantidad;
                            break;
                        case "500,00":
                            bt27 = Cantidad;
                            break;
                        case "PDV":
                            credito = Cantidad;
                            break;
                        case "Transferencia":
                            Transferencia = Cantidad;
                            break;
                        case "Biopago":
                            bio = Cantidad;
                            break;
                        case "Buzon":
                            incidenci = Cantidad;
                            break;
                        default:
                            break;
                    }
                }
                foreach (DataGridViewRow row in BolivaresSS.Rows)
                {
                    double Cantidad = Convert.ToDouble(row.Cells[1].Value.ToString());
                    string Denominacion = row.Cells[0].Value.ToString();
                    switch (Denominacion)
                    {
                        case "0,50":
                            bt1 = Cantidad;
                            break;
                        case "1,00":
                            bt2 = Cantidad;
                            break;
                        case "2,00":
                            bt3 = Cantidad;
                            break;
                        case "5,00":
                            bt4 = Cantidad;
                            break;
                        case "10,00":
                            bt5 = Cantidad;
                            break;
                        case "20,00":
                            bt6 = Cantidad;
                            break;
                        case "50,00":
                            bt7 = Cantidad;
                            break;
                        case "100,00":
                            bt8 = Cantidad;
                            break;
                        case "200,00":
                            bt9 = Cantidad;
                            break;
                        case "500,00":
                            bt10 = Cantidad;
                            break;
                        case "10.000":
                            bt11 = Cantidad;
                            break;
                        case "20.000":
                            bt12 = Cantidad;
                            break;
                        case "50.000":
                            bt13 = Cantidad;
                            break;
                        case "200.000":
                            bt14 = Cantidad;
                            break;
                        case "500.000":
                            bt15 = Cantidad;
                            break;
                        case "1.000.000":
                            bt16 = Cantidad;
                            break;
                        default:
                            break;
                    }
                }
                total = 0;
                pd = 0;
                efectiv = 0;
                efectiv = ((0.50 * bt1) / 1000000) + ((1 * bt2) / 1000000) + ((2 * bt3) / 1000000) + ((5 * bt4) / 1000000) + ((10 * bt5) / 1000000) + ((20 * bt6) / 1000000) + ((50 * bt7) / 1000000) + ((100 * bt8) / 1000000) + ((200 * bt9) / 1000000) + ((500 * bt10) / 1000000) + ((10000 * bt11) / 1000000) + ((20000 * bt12) / 1000000) + ((50000 * bt13) / 1000000) + ((200000 * bt14) / 1000000) + ((500000 * bt15) / 1000000) + ((1000000 * bt16) / 1000000) + (1 * bt17) + (5 * bt18) + (10 * bt19) + (20 * bt20) + (50 * bt21) + (100 * bt22) + (0.20 * bt23) + (0.50 * bt24) + (0.25 * bt25) + (200 * bt26) + (500 * bt27);
                pd = credito;
                total = (efectiv + pd + bio + Transferencia);
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
        //private void CargaAvance(DateTime fecha, int turno, bool buzon)
        //{
        //    string sql = "Insert into CierreBalanceV2 (BilleteS05,BilleteS1,BilleteS2,BilleteS5,BilleteS10,BilleteS20,BilleteS50,BilleteS100,BilleteS200,BilleteS500,Tickets,Efectivo,PDV,Incidencia,ID_Usuario,Fecha,Responsable,TesoreroC,Turno,BilleteS10000,BilleteS20000,BilleteS50000,Transferencia,Eliminado,buzon,BilleteS200000,BilleteS500000,BilleteS1000000,BilleteBD1,BilleteBD5,BilleteBD10,BilleteBD20,BilleteBD50,BilleteBD100,BilleteBD05,BilleteBD02,BilleteBD025) Values (@bt1,@bt2,@bt3,@bt4,@bt5,@bt6,@bt7,@bt8,@bt9,@bt10,@tickets,@efectivo,@pdv,@incidencia,@id,@fecha,@id2,@tesorero,@turno,@bt11,@bt12,@bt13,@transf,0,@buzon,@bt14,@bt15,@bt16,@bt17,@bt18,@bt19,@bt20,@bt21,@bt22,@bt24,0,@bt23)";
        //    using (SqlConnection cn = new SqlConnection(Inicio.conexion))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand(sql, cn);
        //        cmd.Parameters.AddWithValue("bt1", bt1.Text);
        //        cmd.Parameters.AddWithValue("bt2", bt2.Text);
        //        cmd.Parameters.AddWithValue("bt3", bt3.Text);
        //        cmd.Parameters.AddWithValue("bt4", bt4.Text);
        //        cmd.Parameters.AddWithValue("bt5", bt5.Text);
        //        cmd.Parameters.AddWithValue("bt6", bt6.Text);
        //        cmd.Parameters.AddWithValue("bt7", bt7.Text);
        //        cmd.Parameters.AddWithValue("bt8", bt8.Text);
        //        cmd.Parameters.AddWithValue("bt9", bt9.Text);
        //        cmd.Parameters.AddWithValue("bt10", bt10.Text);
        //        cmd.Parameters.AddWithValue("bt11", bt11.Text);
        //        cmd.Parameters.AddWithValue("bt12", bt12.Text);
        //        cmd.Parameters.AddWithValue("bt13", bt13.Text);
        //        cmd.Parameters.AddWithValue("bt14", bt14.Text);
        //        cmd.Parameters.AddWithValue("bt15", bt15.Text);
        //        cmd.Parameters.AddWithValue("bt16", bt16.Text);
        //        cmd.Parameters.AddWithValue("tickets", ticket.Text);
        //        cmd.Parameters.AddWithValue("pdv", Convert.ToDouble(PDV.Text));
        //        cmd.Parameters.AddWithValue("incidencia", 0);
        //        cmd.Parameters.AddWithValue("efectivo", efectivo);
        //        cmd.Parameters.AddWithValue("transf", Convert.ToDouble(Transferencia.Text));
        //        cmd.Parameters.AddWithValue("id", SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1);
        //        cmd.Parameters.AddWithValue("fecha", fecha);
        //        cmd.Parameters.AddWithValue("id2", SAP.Inicio.ID);
        //        cmd.Parameters.AddWithValue("tesorero", SAP.Inicio.ID);
        //        cmd.Parameters.AddWithValue("turno", turno);
        //        cmd.Parameters.AddWithValue("buzon", buzon);
        //        cmd.Parameters.AddWithValue("bt17", bt17.Text);
        //        cmd.Parameters.AddWithValue("bt18", bt18.Text);
        //        cmd.Parameters.AddWithValue("bt19", bt19.Text);
        //        cmd.Parameters.AddWithValue("bt20", bt20.Text);
        //        cmd.Parameters.AddWithValue("bt21", bt21.Text);
        //        cmd.Parameters.AddWithValue("bt22", bt22.Text);
        //        cmd.Parameters.AddWithValue("bt23", bt23.Text);
        //        cmd.Parameters.AddWithValue("bt24", bt24.Text);
        //        cmd.ExecuteReader();
        //        return;
        //    }
        //}

        private void CargaAvance(double centimos, double uno, double dos, double cinco, double diez, double veinte, double cincuenta, double cien, double doscientos, double quinientos, double tickets, double efectivo2, double pdv, double incidencia, int id, int id2, int tesorero, int turno, double diezmil1, double veintemil1, double cincuentamil1, double transf, double docientosmil, double quinientosmil, double unmillion, Boolean Buzon, double bd1, double bd5, double bd10, double bd20, double bd50, double bd100, double bd02, double bd05, double bd025, double bd200, double bd500, DateTime fecha, double bio)
        {
            string sql = "Insert into CierreBalanceV2 (BilleteS05,BilleteS1,BilleteS2,BilleteS5,BilleteS10,BilleteS20,BilleteS50,BilleteS100,BilleteS200,BilleteS500,Tickets,Efectivo,PDV,Incidencia,ID_Usuario,Fecha,Responsable,TesoreroC,Turno,BilleteS10000,BilleteS20000,BilleteS50000,Transferencia,Eliminado,Buzon,BilleteS200000,BilleteS500000,BilleteS1000000,BilleteBD1,BilleteBD5,BilleteBD10,BilleteBD20,BilleteBD50,BilleteBD100,BilleteBD05,BilleteBD02,BilleteBD025,BilleteBD200,BilleteBD500,BIO) Values (@centimos,@uno,@dos,@cinco,@diez,@veinte,@cincuenta,@cien,@doscientos,@quinientos,@tickets,@efectivo,@pdv,@incidencia,@id,@fecha,@id2,@tesorero,@turno,@diezmil,@veintemil,@cincuentamil,@transf,0,@buzon,@docientosmil,@quinientosmil, @unmillon, @bd1,@bd5,@bd10,@bd20,@bd50,@bd100,@bd05,@bd02,@bd025,@bd200,@bd500,@bio)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("centimos", centimos);
                cmd.Parameters.AddWithValue("uno", uno);
                cmd.Parameters.AddWithValue("dos", dos);
                cmd.Parameters.AddWithValue("cinco", cinco);
                cmd.Parameters.AddWithValue("diez", diez);
                cmd.Parameters.AddWithValue("veinte", veinte);
                cmd.Parameters.AddWithValue("cincuenta", cincuenta);
                cmd.Parameters.AddWithValue("cien", cien);
                cmd.Parameters.AddWithValue("doscientos", doscientos);
                cmd.Parameters.AddWithValue("quinientos", quinientos);
                cmd.Parameters.AddWithValue("tickets", tickets);
                cmd.Parameters.AddWithValue("efectivo", efectivo2);
                cmd.Parameters.AddWithValue("pdv", pdv);
                cmd.Parameters.AddWithValue("incidencia", incidencia);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("id2", id2);
                cmd.Parameters.AddWithValue("tesorero", tesorero);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("diezmil", diezmil1);
                cmd.Parameters.AddWithValue("veintemil", veintemil1);
                cmd.Parameters.AddWithValue("cincuentamil", cincuentamil1);
                cmd.Parameters.AddWithValue("transf", transf);
                cmd.Parameters.AddWithValue("docientosmil", docientosmil);
                cmd.Parameters.AddWithValue("quinientosmil", quinientosmil);
                cmd.Parameters.AddWithValue("unmillon", unmillion);
                cmd.Parameters.AddWithValue("buzon", Buzon);
                cmd.Parameters.AddWithValue("bd1", bd1);
                cmd.Parameters.AddWithValue("bd5", bd5);
                cmd.Parameters.AddWithValue("bd10", bd10);
                cmd.Parameters.AddWithValue("bd20", bd20);
                cmd.Parameters.AddWithValue("bd50", bd50);
                cmd.Parameters.AddWithValue("bd100", bd100);
                cmd.Parameters.AddWithValue("bd02", bd02);
                cmd.Parameters.AddWithValue("bd05", bd05);
                cmd.Parameters.AddWithValue("bd025", bd025);
                cmd.Parameters.AddWithValue("bd200", bd200);
                cmd.Parameters.AddWithValue("bd500", bd500);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("bio", bio);
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
                SAP.Tesoreria.Controles.Declaraciones.VersionV2.Motivo frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Motivo();
                frm.ShowDialog();
                if (validador > 0)
                {
                    DialogResult result = MessageBox.Show("¿Seguro, que la informacion suministrada es correcta?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        efectiv = 0;
                        efectiv = ((0.50 * bt1) / 1000000) + ((1 * bt2) / 1000000) + ((2 * bt3) / 1000000) + ((5 * bt4) / 1000000) + ((10 * bt5) / 1000000) + ((20 * bt6) / 1000000) + ((50 * bt7) / 1000000) + ((100 * bt8) / 1000000) + ((200 * bt9) / 1000000) + ((500 * bt10) / 1000000) + ((10000 * bt11) / 1000000) + ((20000 * bt12) / 1000000) + ((50000 * bt13) / 1000000) + ((200000 * bt14) / 1000000) + ((500000 * bt15) / 1000000) + ((1000000 * bt16) / 1000000) + (1 * bt17) + (5 * bt18) + (10 * bt19) + (20 * bt20) + (50 * bt21) + (100 * bt22) + (0.20 * bt23) + (0.50 * bt24) + (0.25 * bt25) + (200 * bt26) + (500 * bt27);
                        CargaAvance(bt1, bt2, bt3, bt4, bt5, bt6, bt7, bt8, bt9, bt10, 0, efectiv, pd, incidenci, Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.ID), turno, bt11, bt12, bt13, Transferencia, bt14, bt15, bt16, false, bt17, bt18, bt19, bt20, bt21, bt22, bt23, bt24, bt25, bt26, bt27, fecha, bio);
                        BuscarNuevo(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, fecha, turno);
                        BuscarOperacion(SAP.Inicio.ID, SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.declaracion);
                        ActualizarEstatus(SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.declaracion);
                        CargarModificacion(idope, SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.declaracion, idnew, SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta);
                        MessageBox.Show("Avance editado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
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
        private void Avance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)

            {

                TextBox tb = e.Control as TextBox;

                tb.KeyPress += new KeyPressEventHandler(Avance_KeyPress);

            }
        }
        private void PDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void EditarAvance_Load(object sender, EventArgs e)
        {

        }
    }
}
