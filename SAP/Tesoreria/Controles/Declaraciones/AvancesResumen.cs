using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Declaraciones
{
    public partial class AvancesResumen : Form
    {
        String Recaudador1 = SAP.Tesoreria.Controles.Declaraciones.MenuAvance.Recaudador;
        string fecha4 = SAP.Tesoreria.Controles.Declaraciones.MenuAvance.Fecha;
        String fecha5 = DateTime.Now.ToString("d");
        String Fecha;
        String Fecha3 = DateTime.Now.ToString("G"); 
        string id = SAP.Tesoreria.TesoreriaV2.id;
        string cavances;
        string efectivos;
        string pdvs;
        string tickets;
        string incidencias;
        string efectivosS;
        string pdvsS;
        string ticketsS;
        string incidenciasS;
        double efectivos1 = 0;
        double pdvs1 = 0;
        double tickets1 = 0;
        double incidencias1 = 0;
        double efectivos2 = 0;
        double pdvs2 = 0;
        double tickets2 = 0;
        double incidencias2 = 0;
        double efectivos1S = 0;
        double pdvs1S = 0;
        double tickets1S = 0;
        double incidencias1S = 0;
        double totales = 0;
        double totalesS = 0;
        double reconversion = 0;
        double general = 0;
        public AvancesResumen()
        {
            try
            {
                string fecha4 = DateTime.Now.AddDays(-1).ToString("d");
                String fecha5 = DateTime.Now.ToString("d");
                String Fecha3 = DateTime.Now.ToString("G");
                ConsultaEspecial(Convert.ToInt32(id), fecha4, fecha5);
                InitializeComponent();
                label2.Text = "AVANCES CARGADOS - RECAUDADOR: " + Recaudador1;
            }
            catch
            {

            }
            try
            {    
                ConsultaEspecial2(Convert.ToInt32(id), Fecha, Fecha3);
               
            }
            catch
            {
                dos.Text = "0";
                cinco.Text = "0";
                diez.Text = "0";
                veinte.Text = "0";
                cincuenta.Text = "0";
                cien.Text = "0";
                quinientos.Text = "0";
                mil.Text = "0";
                dosmil.Text = "0";
                cincomil.Text = "0";
                diezmil.Text = "0";
                veintemil.Text = "0";
                cienmil.Text = "0";
                efectivos = "0";
                tickets = "0";
                pdvs = "0";
                incidencias = "0";
                efectivos1 = Convert.ToDouble(efectivos);
                tickets1 = Convert.ToDouble(tickets);
                pdvs1 = Convert.ToDouble(pdvs);
                incidencias1 = Convert.ToDouble(incidencias);
                totales = (efectivos1 + tickets1 + pdvs1) - incidencias1;
            }
            try
            {
                ConsultaEspecial3(Convert.ToInt32(id), Fecha, Fecha3);
            }
            catch
            {
                Centimos.Text = "0";
                unoS.Text = "0";
                dosS.Text = "0";
                cincoS.Text = "0";
                diezS.Text = "0";
                veinteS.Text = "0";
                CincuentaS.Text = "0";
                cienS.Text = "0";
                doscientoS.Text = "0";
                quinientosS.Text = "0";
                efectivosS = "0";
                ticketsS = "0";
                pdvsS = "0";
                incidenciasS = "0";
                efectivos1S = Convert.ToDouble(efectivosS);
                tickets1S = Convert.ToDouble(ticketsS);
                pdvs1S = Convert.ToDouble(pdvsS);
                incidencias1S = Convert.ToDouble(incidenciasS);
                totalesS = (efectivos1S + tickets1S + pdvs1S) - incidencias1S;
                efectivos2 = (efectivos1 / 100000) + efectivos1S;
                pdvs2 = (pdvs1 / 100000) + pdvs1S;
                tickets2 = (tickets1 / 100000) + tickets1S;
                incidencias2 = (incidencias1 / 100000) + incidencias1S;
                reconversion = totales / 100000;
                general = totalesS + reconversion;
                efectivo.Text = string.Format("{0:n}", efectivos2) + " Bs.S";
                pdv.Text = string.Format("{0:n}", pdvs2) + " Bs.S";
                ticket.Text = string.Format("{0:n}", tickets2) + " Bs.S";
                incidencia.Text = string.Format("{0:n}", incidencias2) + " Bs.S";
                Total.Text = string.Format("{0:n}", general) + " Bs.S";
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
        private void ConsultaEspecial2(int usuario, string fecha1, string fecha2)
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
                    dos.Text = dr["Billete2"].ToString();
                    cinco.Text = dr["Billete5"].ToString();
                    diez.Text = dr["Billete10"].ToString();
                    veinte.Text = dr["Billete20"].ToString();
                    cincuenta.Text = dr["Billete50"].ToString();
                    cien.Text = dr["Billete100"].ToString();
                    quinientos.Text = dr["Billete500"].ToString();
                    mil.Text = dr["Billete1000"].ToString();
                    dosmil.Text = dr["Billete2000"].ToString();
                    cincomil.Text= dr["Billete5000"].ToString();
                    diezmil.Text = dr["Billete10000"].ToString();
                    veintemil.Text = dr["Billete20000"].ToString();
                    cienmil.Text = dr["Billete100000"].ToString();
                    efectivos = dr["Efectivo"].ToString();
                    tickets = dr["Tickets"].ToString();
                    pdvs = dr["PDV"].ToString();
                    incidencias = dr["Incidencia"].ToString();
                    efectivos1 = Convert.ToDouble(efectivos);
                    tickets1 = Convert.ToDouble(tickets);
                    pdvs1 = Convert.ToDouble(pdvs);
                    incidencias1 = Convert.ToDouble(incidencias);
                    totales = (efectivos1 + tickets1 + pdvs1) - incidencias1;
                }
                dr.Close();
                return;
            }
        }
        private void ConsultaEspecial3(int usuario, string fecha1, string fecha2)
        {
            string sql = "select SUM(CierreBalanceV2.BilleteS05) as Centimos,SUM(CierreBalanceV2.BilleteS1) as Uno,SUM(CierreBalanceV2.BilleteS2) as Dos,SUM(CierreBalanceV2.BilleteS5) as Cinco,SUM(CierreBalanceV2.BilleteS10) as Diez,SUM(CierreBalanceV2.BilleteS20) as Veinte,SUM(CierreBalanceV2.BilleteS50) as Cincuenta,SUM(CierreBalanceV2.BilleteS100) as Cien,SUM(CierreBalanceV2.BilleteS200) as Doscientos,SUM(CierreBalanceV2.BilleteS500) as Quinientos,SUM(CierreBalanceV2.Efectivo) as Efectivo,SUM(CierreBalanceV2.PDV) as PDV,SUM(CierreBalanceV2.Tickets) as Tickets,SUM(CierreBalanceV2.Incidencia) as Incidencia from CierreBalanceV2 Where CierreBalanceV2.ID_Usuario = @usuario AND CierreBalanceV2.Fecha between @fecha1 and @fecha2";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(fecha1));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fecha2));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Centimos.Text = dr["Centimos"].ToString();
                    unoS.Text = dr["Uno"].ToString();
                    dosS.Text = dr["Dos"].ToString();
                    cincoS.Text = dr["Cinco"].ToString();
                    diezS.Text = dr["Diez"].ToString();
                    veinteS.Text = dr["Veinte"].ToString();
                    CincuentaS.Text = dr["Cincuenta"].ToString();
                    cienS.Text = dr["Cien"].ToString();
                    doscientoS.Text = dr["Doscientos"].ToString();
                    quinientosS.Text = dr["Quinientos"].ToString();
                    efectivosS = dr["Efectivo"].ToString();
                    ticketsS = dr["Tickets"].ToString();
                    pdvsS = dr["PDV"].ToString();
                    incidenciasS = dr["Incidencia"].ToString();
                    efectivos1S = Convert.ToDouble(efectivosS);
                    tickets1S = Convert.ToDouble(ticketsS);
                    pdvs1S = Convert.ToDouble(pdvsS);
                    incidencias1S = Convert.ToDouble(incidenciasS);
                    totalesS = (efectivos1S + tickets1S + pdvs1S) - incidencias1S;
                    efectivos2 = (efectivos1 / 100000) + efectivos1S;
                    pdvs2 = (pdvs1 / 100000) + pdvs1S;
                    tickets2 = (tickets1 / 100000) + tickets1S;
                    incidencias2 = (incidencias1 / 100000) + incidencias1S; 
                    reconversion = totales / 100000;
                    general = totalesS + reconversion;
                    efectivo.Text = string.Format("{0:n}", efectivos2) + " Bs.S";
                    pdv.Text = string.Format("{0:n}", pdvs2) + " Bs.S";
                    ticket.Text = string.Format("{0:n}", tickets2) + " Bs.S";
                    incidencia.Text = string.Format("{0:n}", incidencias2) + " Bs.S";
                    Total.Text = string.Format("{0:n}", general) + " Bs.S";
                }
                dr.Close();
                return;
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
