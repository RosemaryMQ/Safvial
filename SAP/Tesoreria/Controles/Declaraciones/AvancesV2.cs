using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Declaraciones
{
    public partial class AvancesV2 : Form
    {
        string id = SAP.Tesoreria.TesoreriaV2.id;
        public static String Fecha;
        public static String fecha2 = DateTime.Now.ToString("d");
        String fecha3;
        string fecha4 = DateTime.Now.AddDays(-1).ToString("d");
        double resultado;
        double resultadoparcial = 0;
        int cincuentacentimos;
        int uno1;
        int dos1;
        int cinco1;
        int diez1;
        int veinte1;
        int cincuenta1;
        int cien1;
        int doscientos1;
        int quinientos1;
        int diezmil1, veintemil1, cincuentamil1;
        float tickets2;
        float pdv;
        float menos;
        double resultadototal;
        String calculado;
        String calculado2;
        public AvancesV2()
        {
            InitializeComponent();
            ConsultaEspecial(Convert.ToInt32(id), fecha4, fecha2);
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            SAP.Tesoreria.Controles.Declaraciones.MenuAvance frm = new SAP.Tesoreria.Controles.Declaraciones.MenuAvance();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro, que la informacion suministrada es correcta?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                if (cien.Text != "" && centimos.Text != "" && quinientos.Text != "" && uno.Text != "" && Tickets.Text != "" && PDV.Text != "" && cincuenta.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && Incidencias.Text != "" && dos.Text != "" && diezmil.Text!="" && veintemil.Text!="" && cincuentamil.Text!="")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    resultado = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    fecha3 = DateTime.Now.ToString("G");
                    AgregarDeclaracion(cincuentacentimos,uno1,dos1,cinco1,diez1,veinte1,cincuenta1,cien1,doscientos1,quinientos1,tickets2,Convert.ToSingle(resultado),pdv,menos, Convert.ToInt32(id), fecha3, Convert.ToInt32(SAP.Inicio.ID),diezmil1,veintemil1,cincuentamil1);
                    MessageBox.Show("Avance cargado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al procesar la solicitud", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AgregarDeclaracion(int centimos, int uno, int dos, int cinco, int diez, int veinte,int cincuenta, int cien,int doscientos, int quinientos, float tickets, float efectivo2, float pdv, float incidencia, int id, string fecha, int id2, int diezmil, int veintemil,int cincuentamil)
        {
            string sql = "Insert into CierreBalanceV2 (BilleteS05,BilleteS1,BilleteS2,BilleteS5,BilleteS10,BilleteS20,BilleteS50,BilleteS100,BilleteS200,BilleteS500,Tickets,Efectivo,PDV,Incidencia,ID_Usuario,Fecha,Responsable,BilleteS10000,BilleteS20000,BilleteS50000) Values (@centimos,@uno,@dos,@cinco,@diez,@veinte,@cincuenta,@cien,@doscientos,@quinientos,@tickets,@efectivo,@pdv,@incidencia,@id,@fecha,@id2,@diezmil,@veintemil,@cincuentamil)";
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
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("id2", id2);
                cmd.Parameters.AddWithValue("diezmil", diezmil);
                cmd.Parameters.AddWithValue("veintemil", veintemil);
                cmd.Parameters.AddWithValue("cincuentamil", cincuentamil);
                cmd.ExecuteReader();
                return;
            }
        }

        private void centimos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13) && e.KeyChar != (char)Keys.Oemcomma)
            {
                e.Handled = true;
                return;
            }
        }

        private void centimos_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text !="" && uno.Text !="" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (centimos.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = 0;
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                centimos.Text = "0";
            }
        }

        private void uno_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (uno.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = 0;
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                uno.Text = "0";
            }
        }

        private void dos_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (dos.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = 0;
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                dos.Text = "0";
            }
        }

        private void cinco_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (cinco.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = 0;
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                cinco.Text = "0";
            }
        }

        private void diez_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (diez.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = 0;
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                diez.Text = "0";
            }
        }

        private void veinte_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (veinte.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = 0;
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                veinte.Text = "0";
            }
        }

        private void cincuenta_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (cincuenta.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = 0;
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                cincuenta.Text = "0";
            }
        }

        private void cien_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (cien.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = 0;
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                cien.Text = "0";
            }
        }

        private void quinientos_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (quinientos.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = 0;
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                quinientos.Text = "0";
            }
        }

        private void Tickets_TextChanged(object sender, EventArgs e)
        {
            if (Tickets.Text != "" && PDV.Text != "" && Incidencias.Text != "")
            {
                if (Tickets.Text != "")
                {
                    pdv = Convert.ToSingle(PDV.Text);
                    tickets2 = Convert.ToSingle(Tickets.Text);
                    menos = Convert.ToSingle(Incidencias.Text);
                    resultadototal = (tickets2 + pdv + resultadoparcial) - menos;
                    Total.Text = string.Format("{0:n}", resultadototal) + " Bs.S";
                }
                else
                {
                    pdv = Convert.ToSingle(PDV.Text);
                    tickets2 = 0;
                    menos = Convert.ToSingle(Incidencias.Text);
                    resultadototal = (tickets2 + pdv + resultadoparcial) - menos;
                    Total.Text = string.Format("{0:n}", resultadototal) + " Bs.S";
                }
            }
            else
            {

                Tickets.Text = "0";
            }
        }

        private void PDV_TextChanged(object sender, EventArgs e)
        {
            if (Tickets.Text != "" && PDV.Text != "" && Incidencias.Text != "")
            {
                if (PDV.Text != "")
                {
                    pdv = Convert.ToSingle(PDV.Text);
                    tickets2 = Convert.ToSingle(Tickets.Text);
                    menos = Convert.ToSingle(Incidencias.Text);
                    resultadototal = (tickets2 + pdv + resultadoparcial) - menos;
                    Total.Text = string.Format("{0:n}", resultadototal) + " Bs.S";
                }
                else
                {
                    pdv = 0;
                    tickets2 = Convert.ToSingle(Tickets.Text);
                    menos = Convert.ToSingle(Incidencias.Text);
                    resultadototal = (tickets2 + pdv + resultadoparcial) - menos;
                    Total.Text = string.Format("{0:n}", resultadototal) + " Bs.S";
                }
            }
            else
            {

                PDV.Text = "0";
            }
        }

        private void Incidencias_TextChanged(object sender, EventArgs e)
        {
            if (Tickets.Text != "" && PDV.Text != "" && Incidencias.Text != "")
            {
                if (Incidencias.Text != "")
                {
                    pdv = Convert.ToSingle(PDV.Text);
                    tickets2 = Convert.ToSingle(Tickets.Text);
                    menos = Convert.ToSingle(Incidencias.Text);
                    resultadototal = (tickets2 + pdv + resultadoparcial) - menos;
                    Total.Text = string.Format("{0:n}", resultadototal) + " Bs.S";
                }
                else
                {
                    pdv = Convert.ToSingle(PDV.Text);
                    tickets2 = Convert.ToSingle(Tickets.Text);
                    menos = 0;
                    resultadototal = (tickets2 + pdv + resultadoparcial) - menos;
                    calculado2 = Convert.ToString(resultadototal);
                    Total.Text = string.Format("{0:n}", resultadototal) + " Bs.S";
                }
            }
            else
            {

                Incidencias.Text = "0";
            }
        }

        private void doscientos_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text!="" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (cien.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = 0;
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                doscientos.Text = "0";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void diezmil_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (quinientos.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = 0;
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                diezmil.Text = "0";
            }
        }

        private void veintemil_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (quinientos.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = 0;
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                veintemil.Text = "0";
            }
        }

        private void cincuentamil_TextChanged(object sender, EventArgs e)
        {
            if (centimos.Text != "" && uno.Text != "" && dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && doscientos.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cincuentamil.Text != "")
            {
                if (quinientos.Text != "")
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = Convert.ToInt32(cincuentamil.Text);
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
                else
                {
                    cincuentacentimos = Convert.ToInt32(centimos.Text);
                    uno1 = Convert.ToInt32(uno.Text);
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    doscientos1 = Convert.ToInt32(doscientos.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = veintemil1 = Convert.ToInt32(veintemil.Text);
                    cincuentamil1 = 0;
                    resultadoparcial = (cincuentacentimos * 0.5) + (uno1 * 1) + (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (doscientos1 * 200) + (quinientos1 * 500) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cincuentamil1 * 50000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.S";
                }
            }
            else
            {

                cincuentamil.Text = "0";
            }
        }

        private void Tickets_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13) && e.KeyChar != (char)44)
            {
                e.Handled = true;
                return;
            }
        }

        private void AvancesV2_Load(object sender, EventArgs e)
        {

        }
    }
    }
