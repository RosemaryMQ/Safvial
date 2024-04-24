using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Declaraciones
{
    public partial class MenuAvance : Form
    {
        string id = SAP.Tesoreria.TesoreriaV2.id;
        public static String Fecha;
        public static String fecha2 = DateTime.Now.ToString("d");
        public static String fecha3;
        string fecha4 = DateTime.Now.AddDays(-1).ToString("d");
        public static String Recaudador;
        String fecha5 = DateTime.Now.ToString("d");
        string efectivos;
        string pdvs;
        string tickets;
        string incidencias;
        string dos;
        string cinco;
        string diez;
        string veinte;
        string cincuenta;
        string cien;
        string quinientos;
        string mil;
        string dosmil;
        string cincomil;
        string diezmil;
        string veintemil;
        string cienmil;
        public MenuAvance()
        {
            InitializeComponent();
            this.ConsultaUsuario(Convert.ToInt32(id));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SAP.Tesoreria.Controles.Declaraciones.Avances frm = new SAP.Tesoreria.Controles.Declaraciones.Avances();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SAP.Tesoreria.Controles.Declaraciones.AvancesResumen frm = new SAP.Tesoreria.Controles.Declaraciones.AvancesResumen();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro, que desea emitir el reporte de cierre?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {

                    fecha3 = DateTime.Now.ToString("G");
                    ConsultaEspecial(Convert.ToInt32(id), fecha4, fecha5);                        
                    ConsultaEspecia3(Convert.ToInt32(id), Fecha, fecha3);
                    if (dos !="" && cinco !="" && diez !="" && veinte != "" && cincuenta !="" && cien !="" && quinientos !="" && mil !="" && dosmil !="" && cincomil !="" && diezmil !="" && veintemil !="" && cienmil != "" && efectivos!="" && pdvs !="" && tickets !="" && incidencias !="")
                    {
                        AgregarDeclaracion(Convert.ToInt32(cincuenta), Convert.ToInt32(cien), Convert.ToInt32(quinientos), Convert.ToInt32(mil), Convert.ToInt32(dosmil), Convert.ToInt32(cincomil), Convert.ToInt32(diezmil), Convert.ToInt32(veintemil), Convert.ToInt32(cienmil), Convert.ToSingle(pdvs), Convert.ToSingle(efectivos), Convert.ToInt32(id), fecha3, Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(dos), Convert.ToInt32(cinco), Convert.ToInt32(diez), Convert.ToInt32(veinte), Convert.ToSingle(incidencias), Convert.ToSingle(tickets));
                        FinJornada(Convert.ToString(id));
                        CargarDeclaracion(Fecha, fecha3, Convert.ToInt32(id), Convert.ToInt32(SAP.Inicio.ID));
                        MessageBox.Show("Declaracion cargado correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SAP.Tesoreria.Controles.Declaraciones.Declaracion frm = new SAP.Tesoreria.Controles.Declaraciones.Declaracion();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        AgregarDeclaracion(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(id), fecha3, Convert.ToInt32(SAP.Inicio.ID), 0, 0, 0, 0, 0, 0);
                        FinJornada(Convert.ToString(id));
                        CargarDeclaracion(Fecha, fecha3, Convert.ToInt32(id), Convert.ToInt32(SAP.Inicio.ID));
                        MessageBox.Show("Declaracion cargado correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SAP.Tesoreria.Controles.Declaraciones.Declaracion frm = new SAP.Tesoreria.Controles.Declaraciones.Declaracion();
                        frm.Show();
                        this.Close();
                    }          
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ocurrio un error, al intentar cargar el cierre intente nuevamente."+ex, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void ConsultaEspecia3(int usuario, string fecha1, string fecha2)
        {
            string sql = "select SUM(CierreParcial.Billete2) AS Billete2,SUM(CierreParcial.Billete5) AS Billete5,SUM(CierreParcial.Billete10) AS Billete10,SUM(CierreParcial.Billete20) AS Billete20,SUM(CierreParcial.Billete50) AS Billete50,SUM(CierreParcial.Billete100) AS Billete100,SUM(CierreParcial.Billete500) AS Billete500,SUM(CierreParcial.Billete1000) AS Billete1000, SUM (CierreParcial.Billete2000)AS Billete2000, SUM(CierreParcial.Billete5000) AS Billete5000, SUM (CierreParcial.Billete10000) AS Billete10000, SUM (CierreParcial.Billete20000) AS Billete20000, SUM (CierreParcial.Billete100000) AS Billete100000, SUM(CierreParcial.PDV) AS PDV, SUM(CierreParcial.Efectivo) AS Efectivo, SUM(CierreParcial.Tickets)AS Tickets, SUM(CierreParcial.Incidencia)AS Incidencia from CierreParcial Where CierreParcial.ID_Usuario = @usuario AND CierreParcial.Fecha between @fecha and @fecha2";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha1));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fecha2));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dos= dr["Billete2"].ToString();
                    cinco = dr["Billete5"].ToString();
                    diez = dr["Billete10"].ToString();
                    veinte = dr["Billete20"].ToString();
                    cincuenta = dr["Billete50"].ToString();
                    cien = dr["Billete100"].ToString();
                    quinientos= dr["Billete500"].ToString();
                    mil = dr["Billete1000"].ToString();
                    dosmil = dr["Billete2000"].ToString();
                    cincomil = dr["Billete5000"].ToString();
                    diezmil = dr["Billete10000"].ToString();
                    veintemil = dr["Billete20000"].ToString();
                    cienmil = dr["Billete100000"].ToString();
                    efectivos = dr["Efectivo"].ToString();
                    tickets = dr["Tickets"].ToString();
                    pdvs = dr["PDV"].ToString();
                    incidencias = dr["Incidencia"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void FinJornada(string usuario)
        {
            string sql = "Update Recaudadore Set Estatus='Finalizado' Where ID_Usuario=@usuario and Estatus='Pendiente' or Estatus='Activo'";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", Convert.ToInt32(usuario));
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
                    Fecha = dr["Fecha"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void CargarDeclaracion(string fecha1, string fecha10, int usuario, int responsable)
        {
            string sql = "Insert into Declaraciones(FechaInicial,FechaFinal,ID_Usuario,Responsable) Values (@fecha1,@fecha2,@usuario,@responsable)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(fecha1));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fecha10));
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("responsable", responsable);
                cmd.ExecuteReader();
                return;
            }
        }
        private void AgregarDeclaracion(int cincuenta, int cien, int quinientos, int mil, int dosmil, int cincomil, int diezmil, int veintemil, int cienmil, float pdv, float efectivo2, int id, string fecha, int id2, int dos, int cinco, int diez, int veinte, float incidencia, float tickets)
        {
            string sql = "Insert into CierreBalance (Billete50,Billete100,Billete500,Billete1000,Billete2000,Billete5000,Billete10000,Billete20000,Billete100000,PDV,Ticket,Efectivo,ID_Usuario,Fecha,Responsable,Billete2,Billete5,Billete10,Billete20,Incidencia,Tickets) Values (@cincuenta,@cien,@quinientos,@mil,@dosmil,@cincomil,@diezmil,@veintemil,@cienmil,@pdv,'0',@efectivo,@id,@fecha,@id2,@dos,@cinco,@diez,@veinte,@incidencia,@tickets)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cincuenta", cincuenta);
                cmd.Parameters.AddWithValue("cien", cien);
                cmd.Parameters.AddWithValue("quinientos", quinientos);
                cmd.Parameters.AddWithValue("mil", mil);
                cmd.Parameters.AddWithValue("dosmil", dosmil);
                cmd.Parameters.AddWithValue("cincomil", cincomil);
                cmd.Parameters.AddWithValue("diezmil", diezmil);
                cmd.Parameters.AddWithValue("veintemil", veintemil);
                cmd.Parameters.AddWithValue("cienmil", cienmil);
                cmd.Parameters.AddWithValue("pdv", pdv);
                cmd.Parameters.AddWithValue("efectivo", efectivo2);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("id2", id2);
                cmd.Parameters.AddWithValue("dos", dos);
                cmd.Parameters.AddWithValue("cinco", cinco);
                cmd.Parameters.AddWithValue("diez", diez);
                cmd.Parameters.AddWithValue("veinte", veinte);
                cmd.Parameters.AddWithValue("incidencia", incidencia);
                cmd.Parameters.AddWithValue("tickets", tickets);
                cmd.ExecuteReader();
                return;
            }
        }

        private void ConsultaUsuario(int user)
        {
            string sql = "Select Nombre,Apellido from Usuarios Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario",user);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario.Text =dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                    Recaudador = Usuario.Text;
                }
                dr.Close();
                return;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.Declaraciones.AvancesV2 frm = new SAP.Tesoreria.Controles.Declaraciones.AvancesV2();
            frm.ShowDialog();
        }
    }
}
