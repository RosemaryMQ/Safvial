using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero
{
    public partial class AvanceUser : Form
    {
        int indice = 0;
        double bt1, bt2, bt3, bt4, bt5, bt6, bt7, bt8, bt9, bt10, bt11, bt12, bt13, bt14, bt15, bt16, bt17, bt18, bt19, bt20, bt21, bt22, bt23, bt24, bt25, bt26, bt27;
        double BIOPAGO = 0,pd = 0,credito = 0,debito = 0, efectiv = 0, incidenci = 0, Transferencia = 0,total = 0;

        private void Avance_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AvanceUser_Load(object sender, EventArgs e)
        {

        }

        public static DateTime fechaActual = DateTime.Now;
        public static DateTime Fecha;
        public static String fecha2 = DateTime.Now.ToString("d");
        public static String fecha3;
        public static int idacta;

        public static int turno;
        string hora;
        string hora1;
        string hora2;
        string hora3;
        public static string fechaS;
        public static string fechaS1;
        public static string fechaPrimeraTabulacion;
        public static string fechaUltimaTabulacion;



        public AvanceUser()
        {
            InitializeComponent();
            idacta = 0;
            buscarCataporte(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno));
            BuscarTurno(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno));
            Denominaciones();
            indice = 1;
            Recaudador.Text = "Recaudador: " + SAP.Tesoreria.TesoreriaV2.Nombre + " (Turno:" + SAP.Tesoreria.TesoreriaV2.turno + ")";
            Recaudador1.Text = "Recaudador: " + SAP.Tesoreria.TesoreriaV2.Nombre + " (Turno:" + SAP.Tesoreria.TesoreriaV2.turno + ")";
            CargarAvances();
        }
        private void buscarCataporte(int usuario, int turno)
        {
            string sql = "SELECT ID_Declaracion FROM Declaraciones A INNER JOIN Turno B ON  CONVERT(DATETIME2(0), A.FechaInicial) = CONVERT(DATETIME2(0), B.Fecha) and A.ID_Usuario = B.ID_Usuario " +
                "WHERE (A.ID_Usuario = @usuario) AND (B.Turno = @turno) AND (Responsable = 0)";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("turno", turno);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta = Convert.ToInt32(dr["ID_Declaracion"]);
                    idacta = Convert.ToInt32(dr["ID_Declaracion"]);

                }
                dr.Close();
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvanceBuzon frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvanceBuzon();
            frm.ShowDialog();
        }



        private void BuscarTurno(int turno)
        {
            if (turno == 1)
            {
                hora = " 04:00:00";
                hora1 = " 23:59:59";
            }
            else if (turno == 2)
            {
                hora = " 16:00:00";
                hora1 = " 12:00:00";
            }
            else if (turno == 3)
            {
                hora = " 00:00:00";
                hora1 = " 16:00:00";
            }
            else if (turno == 4)
            {
                hora = " 00:00:00";
                hora1 = " 16:00:00";
            }
            else if (turno == 5)
            {
                hora = " 04:00:00";
                hora1 = " 16:00:00";
            }
            else if (turno == 6)
            {
                hora = " 10:00:00";
                hora1 = " 09:00:00";
            }
            else if (turno == 7)
            {
                hora = " 20:00:00";
                hora1 = " 19:00:00";
            }
            else if (turno == 8)
            {
                hora = " 00:00:00";
                hora1 = " 11:59:59";
                hora2 = " 12:00:00";
                hora3 = " 23:59:59";
            }
            else if (turno == 9)
            {
                hora = " 12:00:00";
                hora1 = " 23:59:59";
                hora2 = " 00:00:00";
                hora3 = " 11:59:59";
            }
            else if (turno == 0)
            {
            }

        }


        private void Avance_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Avance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private bool EsValido(string usuario)
        {
            string sql = "SELECT * FROM Usuarios WHERE ID_Usuario = @usuario AND Perfil='Administrador' AND Perfil='ADMINISTRADOR'";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesReporte frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesReporte();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Codigo.Text != "" && EsValido(Codigo.Text))
            {
                DialogResult result = MessageBox.Show("¿Seguro, que la informacion suministrada es correcta?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    
                    efectiv = 0;
                    efectiv = ((0.50 * bt1) / 1000000) + ((1 * bt2) / 1000000) + ((2 * bt3) / 1000000) + ((5 * bt4) / 1000000) + ((10 * bt5) / 1000000) + ((20 * bt6) / 1000000) + ((50 * bt7) / 1000000) + ((100 * bt8) / 1000000) + ((200 * bt9) / 1000000) + ((500 * bt10) / 1000000) + ((10000 * bt11) / 1000000) + ((20000 * bt12) / 1000000) + ((50000 * bt13) / 1000000) + ((200000 * bt14) / 1000000) + ((500000 * bt15) / 1000000) + ((1000000 * bt16) / 1000000) + (1 * bt17) + (5 * bt18) + (10 * bt19) + (20 * bt20) + (50 * bt21) + (100 * bt22) + (200 * bt26) + (200 * bt27) + (0.20 * bt23) + (0.50 * bt24) + (0.25 * bt25);
                    AgregarDeclaracion1(bt1, bt2, bt3, bt4, bt5, bt6, bt7, bt8, bt9, bt10, 0, efectiv, pd, incidenci, Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(Codigo.Text), Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno),bt11,bt12,bt13,Transferencia, bt14, bt15, bt16,bt17,bt18,bt19,bt20,bt21,bt22,bt23,bt24,bt25, bt26, bt27, BIOPAGO, Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.IDTurnoUsuario));
                    Avance.Rows.Clear();
                    BolivaresSS.Rows.Clear();
                    BDLista.Rows.Clear();
                    Denominaciones();
                    Codigo.Text = "";
                    bt1 = 0;bt2 = 0; bt3 = 0; bt4 = 0; bt5 = 0; bt6 = 0; bt7 = 0; bt8 = 0; bt9 = 0; bt10 = 0; bt11 = 0; bt12 = 0; bt13 = 0; bt26 = 0; bt27 = 0; debito = 0; credito = 0; incidenci = 0; total = 0; pd = 0; Transferencia = 0; BIOPAGO = 0;
                    Cargar.Text = string.Format("{0:n}", total) + " Bs.";
                    MessageBox.Show("Avance cargado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAvances();
                }
            }
            else
            {
                MessageBox.Show("El codigo de tesorero no es valido por favor verifique.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Codigo.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro, que desea emitir el reporte de cierre?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    fechaS = "";
                    fechaS1 = "";
                    fechaPrimeraTabulacion = "";
                    fechaUltimaTabulacion = "";
                    try
                    {
                        //***************************************************NO OLVIDAR VALIDAR FECHAS SI FALLA ALGUNA DE LAS 4 NECESARIAS PARA EL REPORTE
                        this.InicioTurno(turno);//FECHA INICIO
                        if (fechaS1 == "")
                        {
                            //this.InicioTurnoAlt(turno);//FECHA INICIO

                        }
                        this.FinTurno(turno);//FECHA FIN
                        if (fechaS == "")
                        {
                            //this.InicioTurnoAlt(turno);//FECHA INICIO

                        }
                        this.PrimeraTabulacion(turno, fechaS1, fechaS, Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador));
                        if (fechaPrimeraTabulacion == "")
                        {
                            //this.InicioTurnoAlt(turno);//FECHA INICIO

                        }
                        this.UltimaTabulacion(turno, fechaS1, fechaS, Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador));
                        if (fechaUltimaTabulacion == "")
                        {
                            //this.InicioTurnoAlt(turno);//FECHA INICIO

                        }

                    }
                    catch
                    {
                        MessageBox.Show("La fecha ingresada no posee registros detectados", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    AgregarDeclaracion1(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.IDTurnoUsuario));
                    //AgregarDeclaracion1(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    FinJornada(Convert.ToString(SAP.Tesoreria.TesoreriaV2.Identificador), Convert.ToString(SAP.Tesoreria.TesoreriaV2.turno));
                    FinJornada1(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno));
                    buscarCataporte(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno));
                    BuscarActa(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno));
                    CargarDeclaracion(SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta, Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno));
                    MessageBox.Show("Declaracion cargado correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SAP.Tesoreria.Controles.Declaraciones.Declaracion frm = new SAP.Tesoreria.Controles.Declaraciones.Declaracion();
                    frm.ShowDialog();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error, al intentar cargar el cierre intente nuevamente." , "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BuscarActa(int usuario, int turno)
        {
            //string sql = "Update Turno Set Finalizado=1 Where ID_Usuario=@usuario and turno=@turno and Finalizado=0 AND ID_Usuario=@usuario";
            string sql = "SELECT ID_Declaracion FROM Declaraciones A INNER JOIN Turno B ON  CONVERT(DATETIME2(0), A.FechaFinal) = CONVERT(DATETIME2(0), B.Fecha) and " +
                "A.ID_Usuario = B.ID_Usuario WHERE (A.ID_Usuario=@usuario) AND (B.Turno=@turno) AND (Responsable=0)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("turno", turno);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    idacta = Convert.ToInt32(dr["ID_Declaracion"]);
                }
                dr.Close();
                return;
            }
        }

        private void FinJornada1(int usuario, int turno)
        {
            string sql = "Update Turno Set Finalizado=1 Where ID_Usuario=@usuario and turno=@turno and Finalizado=0 AND ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.ExecuteReader();
                return;
            }
        }
        private void FinJornada(string usuario, string turno)
        {
            string sql = "Update Recaudadore Set FechaFin=SYSDATETIME(),Estatus='Finalizado' Where (Fecha=@fechaS1) AND (ID_Usuario=@usuario) and (turno=@turno) and (Estatus='Pendiente' or Estatus='Activo')";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", Convert.ToInt32(usuario));
                cmd.Parameters.AddWithValue("turno", Convert.ToInt32(turno));
                cmd.Parameters.AddWithValue("fechaS1", fechaS1);
                cmd.ExecuteReader();
                return;
            }
        }
        private void ConsultaEspecial(int usuario, string fecha, string fecha1)
        {
            string sql = "Select Top 1 Recaudadore.Fecha From Recaudadore Where ID_Usuario=@usuario and Estatus='Pendiente' or Estatus='Activo' AND Recaudadore.Fecha Between @fecha + ' 00:00:00' AND @fecha1 + ' 23:59:59' order by Fecha ASC";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(fecha1));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Fecha = Convert.ToDateTime(dr["Fecha"]);
                }
                dr.Close();
                return;
            }
        }
        private void CargarDeclaracion(int declaracion, int responsable, int turno)
        {
            //string sql = "UPDATE Declaraciones SET FechaInicial=@fecha,FechaFinal=DATEADD(HOUR, 2,GETDATE()), Responsable=@tesorero, Turno=@turno, IdTurnoUsuario=@id WHERE ID_Declaracion=@declaracion";
            string sql = "UPDATE Declaraciones SET FechaFinal=GETDATE(), Responsable=@tesorero, Turno=@turno  WHERE ID_Declaracion=@declaracion";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(SAP.Tesoreria.TesoreriaV2.Apertura));
                cmd.Parameters.AddWithValue("declaracion", declaracion);
                cmd.Parameters.AddWithValue("tesorero", responsable);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.ExecuteReader();
                return;
            }
        }

        private void Avance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)

            {

                TextBox tb = e.Control as TextBox;

                tb.KeyPress += new KeyPressEventHandler(Avance_KeyPress);

            }
        }
        private void Denominaciones()
        {
            BolivaresSS.Rows.Add("200,00", "0");
            BolivaresSS.Rows.Add("500,00", "0");
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
            Avance.Rows.Add("200,00", "0"); //nuevo cono
            Avance.Rows.Add("500,00", "0"); //nuevo cono
            Avance.Rows.Add("Credito", "0");
            Avance.Rows.Add("Debito", "0");
            Avance.Rows.Add("Transferencia", "0");
            Avance.Rows.Add("BIOPAGO", "0");
        }

        private void AgregarDeclaracion1(double centimos, double uno, double dos, double cinco, double diez, double veinte, double cincuenta, double cien, double doscientos, double quinientos, double tickets, double efectivo2, double pdv, double incidencia, int id, int id2, int tesorero, int turno, double diezmil1, double veintemil1, double cincuentamil1, double transf, double docientosmil, double quinientosmil, double unmillion, double bd1, double bd5, double bd10, double bd20, double bd50, double bd100, double bd02, double bd05, double bd025, double bd200, double bd500, double BIOPAGO, int idTurnoUsuario)
        {
            string sql = "Insert into CierreBalanceV2 (BilleteS05,BilleteS1,BilleteS2,BilleteS5,BilleteS10,BilleteS20,BilleteS50,BilleteS100,BilleteS200,BilleteS500,Tickets,Efectivo,PDV,Incidencia,ID_Usuario,Fecha,Responsable,TesoreroC,Turno,BilleteS10000,BilleteS20000,BilleteS50000,Transferencia,Eliminado,Buzon,BilleteS200000,BilleteS500000,BilleteS1000000,BilleteBD1,BilleteBD5,BilleteBD10,BilleteBD20,BilleteBD50,BilleteBD100,BilleteBD05,BilleteBD02,BilleteBD025,BilleteBD200,BilleteBD500, BIO, IdTurnoUsuario) Values (@centimos,@uno,@dos,@cinco,@diez,@veinte,@cincuenta,@cien,@doscientos,@quinientos,@tickets,@efectivo,@pdv,@incidencia,@id,SYSDATETIME(),@id2,@tesorero,@turno,@diezmil,@veintemil,@cincuentamil,@transf,0,0,@docientosmil,@quinientosmil, @unmillon, @bd1,@bd5,@bd10,@bd20,@bd50,@bd100,@bd05,@bd02,@bd025,@bd200,@bd500,@BIOPAGO,@idTurnoUsuario)";
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
                cmd.Parameters.AddWithValue("BIOPAGO", BIOPAGO);
                cmd.Parameters.AddWithValue("idTurnoUsuario", idTurnoUsuario);
                
                cmd.ExecuteReader();
                return;
            }
        }
        public void CargarAvances()
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT  ID_Cierre, BilleteS05, BilleteS1, BilleteS2, BilleteS5, BilleteS10, BilleteS20, BilleteS50, BilleteS100, BilleteS200, BilleteS500, BilleteS10000, BilleteS20000, BilleteS50000, BilleteS200000,BilleteS500000,BilleteS1000000, Tickets, Efectivo, PDV, Incidencia, Transferencia, Eliminado,BilleteBD1,BilleteBD5,BilleteBD10,BilleteBD20,BilleteBD50,BilleteBD100,BilleteBD05,BilleteBD02,BilleteBD025,BilleteBD200,BilleteBD500, BIO FROM CierreBalanceV2 " +
                "WHERE (ID_Usuario = @usuario) AND (Turno = @turno) AND (Fecha BETWEEN @fecha AND @fecha2) AND (Buzon = 0)", cn);

            cmd.Parameters.AddWithValue("usuario", Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador));
            cmd.Parameters.AddWithValue("turno", Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno));
            cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(SAP.Tesoreria.TesoreriaV2.Apertura));
            cmd.Parameters.AddWithValue("fecha2", DateTime.Now.AddMinutes(50));
            dr = cmd.ExecuteReader();
            AvancesUser.Rows.Clear();
            BDLista.Rows.Clear();
            while (dr.Read())
            {
                AvancesUser.Rows.Add(dr["ID_Cierre"].ToString(), dr["BilleteS05"].ToString(), dr["BilleteS1"].ToString(), dr["BilleteS2"].ToString(), dr["BilleteS5"].ToString(), dr["BilleteS10"].ToString(), dr["BilleteS20"].ToString(), dr["BilleteS50"].ToString(), dr["BilleteS100"].ToString(), dr["BilleteS200"].ToString(), dr["BilleteS500"].ToString(), dr["BilleteS10000"].ToString(), dr["BilleteS20000"].ToString(), dr["BilleteS50000"].ToString(), dr["BilleteS200000"].ToString(), dr["BilleteS500000"].ToString(), dr["BilleteS1000000"].ToString(), dr["Eliminado"].ToString(), "EDITAR");
                BDLista.Rows.Add(dr["ID_Cierre"].ToString(), dr["BilleteBD025"].ToString(), dr["BilleteBD05"].ToString(), dr["BilleteBD1"].ToString(), dr["BilleteBD5"].ToString(), dr["BilleteBD10"].ToString(), dr["BilleteBD20"].ToString(), dr["BilleteBD50"].ToString(), dr["BilleteBD100"].ToString(), dr["BilleteBD200"].ToString(), dr["BilleteBD500"].ToString(), dr["PDV"].ToString(), dr["BIO"].ToString(), dr["Transferencia"].ToString(), dr["Eliminado"].ToString(), "EDITAR");
            }
            dr.Close();
            foreach (DataGridViewRow row in AvancesUser.Rows)
            {

                if (row.Cells["Eliminado"].Value.ToString() == "True")
                {

                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 98, 98);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }

            }
            foreach (DataGridViewRow row in BDLista.Rows)
            {

                if (row.Cells["Eliminado2"].Value.ToString() == "True")
                {

                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 98, 98);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }

            }
        }

        private void AvancesUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = AvancesUser.Rows[e.RowIndex];
            if (row.Cells["Eliminado"].Value.ToString() == "False")
            {
                SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.declaracion = Convert.ToString(row.Cells[0].Value);
                SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario = Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador);
                SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal = SAP.Tesoreria.TesoreriaV2.Apertura;
                SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1 = SAP.Tesoreria.TesoreriaV2.Identificador;
                SAP.Inicio.acceso = 14;
                SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
                frm.ShowDialog();
                CargarAvances();
            }
            else
            {
                MessageBox.Show("El avance que intenta modificar ha sido eliminado anteriormente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } 
        }


        // FECHA FIN
        private void FinTurno(int turno)
        {
            //string sql = "SELECT TOP 1 Fecha FROM CierreBalanceV2 WHERE CierreBalanceV2.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha DESC;";
            string sql = "SELECT TOP 1 Fecha FROM CierreBalanceV2 WHERE (CierreBalanceV2.Fecha >= @fechaS1) AND (CierreBalanceV2.Turno = @turno) AND (CierreBalanceV2.IdTurnoUsuario=@id) Order by Fecha DESC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaS1", fechaS1);
                cmd.Parameters.AddWithValue("id", Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.IDTurnoUsuario));
                cmd.Parameters.AddWithValue("turno", turno);

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


        // FECHA DE INICIO
        private void InicioTurno(int turno)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Turno.ID = @id AND Turno.Turno=@turno AND Turno.Finalizado=0 Order by Fecha ASC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("id", Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.IDTurnoUsuario));

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

        private void InicioTurnoAlt(int turno)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Turno.Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha ASC;";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", Fecha.Date.AddHours(-1));
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(fechaActual + hora1));
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
                    //fechaS1 = Convert.ToDateTime(fechaActual.AddHours(-1).ToString());
                }
            }
        }


        private void PrimeraTabulacion(int turno, string fechaS1, string fechaS, int usuario)
        {
            string sql = "SELECT Top 1 A.Fecha from Pagos A INNER JOIN TipoVehiculos B ON A.ID_Vehiculo=B.ID_Vehiculo WHERE (A.fecha BETWEEN @fechaS1 and @fechaS) and (A.Turno = @turno) and (A.ID_Usuario = @usuario) order by A.fecha ASC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaS1", fechaS1);
                cmd.Parameters.AddWithValue("fechaS", fechaS);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("usuario", usuario);

                object resultado = cmd.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    // SI ENCONTRÓ DATO
                    fechaPrimeraTabulacion = Convert.ToString(Convert.ToDateTime(resultado));
                }
                else
                {
                    // NO ENCONTRÓ DATO (resultado es null)
                    fechaPrimeraTabulacion = "";
                }
            }
        }

        private void UltimaTabulacion(int turno, string fechaS1, string fechaS, int usuario)
        {
            string sql = "SELECT Top 1 A.Fecha from Pagos A INNER JOIN TipoVehiculos B ON A.ID_Vehiculo=B.ID_Vehiculo WHERE (A.fecha BETWEEN @fechaS1 and @fechaS) and (A.Turno = @turno) and (A.ID_Usuario = @usuario) order by A.fecha DESC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fechaS1", fechaS1);
                cmd.Parameters.AddWithValue("fechaS", fechaS);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("usuario", usuario);

                object resultado = cmd.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    // SI ENCONTRÓ DATO
                    fechaUltimaTabulacion = Convert.ToString(Convert.ToDateTime(resultado));
                }
                else
                {
                    // NO ENCONTRÓ DATO (resultado es null)
                    fechaUltimaTabulacion = "";
                }
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
                        case "Credito":
                            credito = Cantidad;
                            break;
                        case "Debito":
                            debito = Cantidad;
                            break;
                        case "BIOPAGO":
                            BIOPAGO = Cantidad;
                            break;
                        case "Transferencia":
                            Transferencia = Cantidad;
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
                efectiv = ((0.50 * bt1) / 1000000) + ((1 * bt2) / 1000000) + ((2 * bt3) / 1000000) + ((5 * bt4) / 1000000) + ((10 * bt5) / 1000000) + ((20 * bt6) / 1000000) + ((50 * bt7) / 1000000) + ((100 * bt8) / 1000000) + ((200 * bt9) / 1000000) + ((500 * bt10) / 1000000) + ((10000 * bt11) / 1000000) + ((20000 * bt12) / 1000000) + ((50000 * bt13) / 1000000) + ((200000 * bt14) / 1000000) + ((500000 * bt15) / 1000000) + ((1000000 * bt16) / 1000000) + (1 * bt17) + (5 * bt18) + (10 * bt19) + (20 * bt20) + (50 * bt21) + (100 * bt22) + (200 * bt26) + (500 * bt27) + (0.20 * bt23) + (0.50 * bt24) + (0.25 * bt25);
                pd = credito + debito;
                total = (efectiv + pd + BIOPAGO + Transferencia);
                Cargar.Text = total.ToString("N6") + " Bs.";
            }
        }
        private void BolivaresSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
        private void Codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
        private void BolivaresSS_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)

            {

                TextBox tb = e.Control as TextBox;

                tb.KeyPress += new KeyPressEventHandler(BolivaresSS_KeyPress);

            }
        }
        private void BDLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = BDLista.Rows[e.RowIndex];
            if (row.Cells["Eliminado2"].Value.ToString() == "False")
            {
                SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.declaracion = Convert.ToString(row.Cells[0].Value);
                SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario = Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador);
                SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal = SAP.Tesoreria.TesoreriaV2.Apertura;
                SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1 = SAP.Tesoreria.TesoreriaV2.Identificador;
                SAP.Inicio.acceso = 14;
                SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
                frm.ShowDialog();
                CargarAvances();
            }
            else
            {
                MessageBox.Show("El avcance que intenta modificar ha sido eliminado anteriormente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }




    }
}
