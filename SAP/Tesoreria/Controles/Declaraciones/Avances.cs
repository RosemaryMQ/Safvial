using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Declaraciones
{
    public partial class Avances : Form
    {
        string id = SAP.Tesoreria.TesoreriaV2.id;
        public static String Fecha;
        public static String fecha2 = DateTime.Now.ToString("d");
        String fecha3;
        string fecha4 = DateTime.Now.AddDays(-1).ToString("d");
        float resultado;
        float resultadoparcial = 0;
        int cincuenta1;
        int cien1;
        int quinientos1;
        int mil1;
        int dosmil1;
        int cincomil1;
        int diezmil1;
        int veintemil1;
        int cienmil1;
        int dos1;
        int cinco1;
        int diez1;
        int veinte1;
        float tickets2;
        float pdv;
        float menos;
        float resultadototal;
        String calculado;
        String calculado2;
        public Avances()
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

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Seguro, que la informacion suministrada es correcta?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                if (cien.Text != "" && cienmil.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != ""  && cincuenta.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" &&  dos.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    fecha3 = DateTime.Now.ToString("G");
                    AgregarDeclaracion(cincuenta1, cien1, quinientos1, mil1, dosmil1, cincomil1, diezmil1, veintemil1, cienmil1, 0, resultadoparcial, Convert.ToInt32(id), fecha3, Convert.ToInt32(SAP.Inicio.ID), dos1, cinco1, diez1, veinte1, 0, 0);
                    MessageBox.Show("Avance cargado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al procesar la solicitud", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }

        private void AgregarDeclaracion(int cincuenta, int cien, int quinientos, int mil, int dosmil, int cincomil, int diezmil, int veintemil, int cienmil, float pdv, float efectivo2, int id, string fecha, int id2, int dos, int cinco, int diez, int veinte, float incidencia, float tickets)
        {
            string sql = "Insert into CierreParcial (Billete50,Billete100,Billete500,Billete1000,Billete2000,Billete5000,Billete10000,Billete20000,Billete100000,PDV,Efectivo,ID_Usuario,Fecha,Responsable,Billete2,Billete5,Billete10,Billete20,Incidencia,Tickets) Values (@cincuenta,@cien,@quinientos,@mil,@dosmil,@cincomil,@diezmil,@veintemil,@cienmil,@pdv,@efectivo,@id,@fecha,@id2,@dos,@cinco,@diez,@veinte,@incidencia,@tickets)";
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

        private void dos_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (dos.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = 0;
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dos.Text = "0";
            }
        }

        private void cinco_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (cinco.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = 0;
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cinco.Text = "0";
            }

        }

        private void diez_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (diez.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = 0;
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                diez.Text = "0";
            }

        }

        private void veinte_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (veinte.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = 0;
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                veinte.Text = "0";
            }
        }

        private void cincuenta_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (cincuenta.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = 0;
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cincuenta.Text = "0";
            }
        }

        private void cien_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (cien.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = 0;
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cien.Text = "0";
            }
        }

        private void quinientos_TextChanged(object sender, EventArgs e)
        {

            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (quinientos.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = 0;
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quinientos.Text = "0";
            }
        }

        private void mil_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (mil.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = 0;
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mil.Text = "0";
            }
        }

        private void dosmil_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (dosmil.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = 0;
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dosmil.Text = "0";
            }
        }

        private void cincomil_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (dosmil.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = 0;
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cincomil.Text = "0";
            }
        }

        private void diezmil_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (dosmil.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = 0;
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                diezmil.Text = "0";
            }
        }

        private void veintemil_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (veintemil.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = 0;
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                veintemil.Text = "0";
            }

        }

        private void cienmil_TextChanged(object sender, EventArgs e)
        {
            if (dos.Text != "" && cinco.Text != "" && diez.Text != "" && veinte.Text != "" && cincuenta.Text != "" && cien.Text != "" && quinientos.Text != "" && mil.Text != "" && dosmil.Text != "" && cincomil.Text != "" && diezmil.Text != "" && veintemil.Text != "" && cienmil.Text != "")
            {
                if (cienmil.Text != "")
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = Convert.ToInt32(cienmil.Text);
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";
                }
                else
                {
                    dos1 = Convert.ToInt32(dos.Text);
                    cinco1 = Convert.ToInt32(cinco.Text);
                    diez1 = Convert.ToInt32(diez.Text);
                    veinte1 = Convert.ToInt32(veinte.Text);
                    cincuenta1 = Convert.ToInt32(cincuenta.Text);
                    cien1 = Convert.ToInt32(cien.Text);
                    quinientos1 = Convert.ToInt32(quinientos.Text);
                    mil1 = Convert.ToInt32(mil.Text);
                    dosmil1 = Convert.ToInt32(dosmil.Text);
                    cincomil1 = Convert.ToInt32(cincomil.Text);
                    diezmil1 = Convert.ToInt32(diezmil.Text);
                    veintemil1 = Convert.ToInt32(veintemil.Text);
                    cienmil1 = 0;
                    resultadoparcial = (dos1 * 2) + (cinco1 * 5) + (diez1 * 10) + (veinte1 * 20) + (cincuenta1 * 50) + (cien1 * 100) + (quinientos1 * 500) + (mil1 * 1000) + (dosmil1 * 2000) + (cincomil1 * 5000) + (diezmil1 * 10000) + (veintemil1 * 20000) + (cienmil1 * 100000);
                    Recaudado.Text = string.Format("{0:n}", resultadoparcial) + " Bs.F";

                }
            }
            else
            {
                MessageBox.Show("No esta permitidos los campos vacios rellenar con 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cienmil.Text = "0";
            }

        }
    }
}
