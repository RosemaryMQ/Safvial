using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles
{
    public partial class AuditorUsuario : Form
    {
        string Vehiculo;
        double recaudo;
        double contador = 0;
        public AuditorUsuario()
        {
            InitializeComponent();
            try
            {
                Recaudador.Text = SAP.Tesoreria.TesoreriaV2.Nombre;
                buscar(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador));
                Canal.Text = SAP.Tesoreria.TesoreriaV2.CanalUser;
                Apertura.Text = SAP.Tesoreria.TesoreriaV2.Apertura;
                Tabulacion(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), SAP.Tesoreria.TesoreriaV2.Apertura);
                TabulacionTipoPago(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), SAP.Tesoreria.TesoreriaV2.Apertura);
                
                toolStripStatusLabel1.Text = "Proxima Actualizacion en: 00:00:30";
                if (SAP.Tesoreria.TesoreriaV2.Validor != false)
                {
                    try
                    {
                        TabulacionPrepagado(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), SAP.Tesoreria.TesoreriaV2.Apertura);
                    }
                    catch
                    {
                        SAP.Tesoreria.TesoreriaV2.Validor = false;
                    }
                }
                else
                {
                    Prepagado.Text = "No Disponible";
                }
             }
            catch
            {
                MessageBox.Show("Error al intentar buscar al usuario por favor reintente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
          
        }

private void buscar(int name)
        {
            string sql = "Select Nickname,Perfil From Usuarios where ID_Usuario=@usuario;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", name);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    recaudo = Convert.ToDouble(dr["Nickname"].ToString());
                    Cedula.Text = "V-" + string.Format("{0:n0}", recaudo);
                    Perfil.Text = dr["Perfil"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void Tabulacion(int usuario,string fecha)
        {
            string sql = "SELECT   TipoVehiculos.Nombre,COUNT(TipoVehiculos.Nombre)as Conteo,SUM(TipoVehiculos.Tarifa)as Recaudado FROM TipoVehiculos INNER JOIN Pagos ON TipoVehiculos.ID_Vehiculo=Pagos.ID_Vehiculo Where Pagos.ID_Usuario=@usuario AND Pagos.Fecha between @fecha and @fecha1 GROUP BY TipoVehiculos.Nombre;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", DateTime.Now.ToString("G"));
                dr = cmd.ExecuteReader();
                contador = 0;
                while (dr.Read())
                {
                    Vehiculo = dr["Nombre"].ToString();
                    recaudo = Convert.ToDouble(dr["Recaudado"].ToString());
                    if (Vehiculo=="Liviano")
                    {
                        Liviano.Text = dr["Conteo"].ToString();
                        Liviano1.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    else if (Vehiculo == "Microbus")
                    {
                        Microbus.Text = dr["Conteo"].ToString();
                        Microbus1.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    else if (Vehiculo == "Autobus")
                    {
                        Autobus.Text = dr["Conteo"].ToString();
                        Autobus1.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    else if (Vehiculo == "Carga Liviana")
                    {
                        CargaLiviana.Text = dr["Conteo"].ToString();
                        CargaLiviana1.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    else if (Vehiculo == "2 Ejes")
                    {
                        Ejes2.Text = dr["Conteo"].ToString();
                        Ejes21.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    else if (Vehiculo == "3 Ejes")
                    {
                        Ejes3.Text = dr["Conteo"].ToString();
                        Ejes31.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    else if (Vehiculo == "4 Ejes")
                    {
                        Ejes4.Text = dr["Conteo"].ToString();
                        Ejes41.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    else if (Vehiculo == "5 Ejes")
                    {
                        Ejes5.Text = dr["Conteo"].ToString();
                        Ejes51.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    else if (Vehiculo == "6 Ejes o Mas")
                    {
                        Ejes6.Text = dr["Conteo"].ToString();
                        Ejes61.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                  
                }
                dr.Close();
                return;
            }
        }
        private void TabulacionTipoPago(int usuario, string fecha)
        {
            string sql = "SELECT Pagos.FormaPago,SUM(TipoVehiculos.Tarifa)as Recaudado FROM TipoVehiculos INNER JOIN Pagos ON TipoVehiculos.ID_Vehiculo=Pagos.ID_Vehiculo Where Pagos.ID_Usuario=@usuario AND Pagos.Fecha between @fecha and @fecha1 GROUP BY Pagos.FormaPago;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", DateTime.Now.ToString("G"));
                dr = cmd.ExecuteReader();
                contador = 0;
                while (dr.Read())
                {
                    Vehiculo = dr["FormaPago"].ToString();
                    recaudo = Convert.ToDouble(dr["Recaudado"].ToString());
                    contador = contador + Convert.ToDouble(recaudo);
                    if (Vehiculo == "Efectivo")
                    {
                        Efectivo.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    else if (Vehiculo == "Punto de Venta")
                    {
                        PDV.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    else if (Vehiculo == "Pago Incompleto")
                    {
                        PagoIncompleto.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                        contador = contador - Convert.ToDouble(recaudo);
                    }
                    Totales.Text = string.Format("{0:n}", contador) + " Bs.S";
                }
                dr.Close();
                return;
            }
        }
        private void TabulacionPrepagado(int usuario, string fecha)
        {
            string sql = "SELECT Pagos.FormaPago,SUM(TipoVehiculos.Tarifa)as Recaudado FROM TipoVehiculos INNER JOIN Pagos ON TipoVehiculos.ID_Vehiculo=Pagos.ID_Vehiculo Where Pagos.ID_Usuario=@usuario AND Sede=@sede AND Pagos.Fecha between @fecha and @fecha1 GROUP BY Pagos.FormaPago;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("sede", SAP.Inicio.sede);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", DateTime.Now.ToString("G"));
                dr = cmd.ExecuteReader();
                contador = 0;
                while (dr.Read())
                {
                    Vehiculo = dr["FormaPago"].ToString();
                    recaudo = Convert.ToDouble(dr["Recaudado"].ToString());
                    Prepagado.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                }
                dr.Close();
                return;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel1.Text = "Proxima Actualizacion en: 00:00:30";
                Tabulacion(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), SAP.Tesoreria.TesoreriaV2.Apertura);
                TabulacionTipoPago(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), SAP.Tesoreria.TesoreriaV2.Apertura);
                if (SAP.Tesoreria.TesoreriaV2.Validor != false)
                {
                    try
                    {
                        TabulacionPrepagado(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.Identificador), SAP.Tesoreria.TesoreriaV2.Apertura);
                    }
                    catch
                    {
                        SAP.Tesoreria.TesoreriaV2.Validor = false;
                    }
                }
                else
                {
                    Prepagado.Text = "No Disponible";
                }
            }
            catch
            {
                toolStripStatusLabel1.Text = "Reintentando Actualizacion...";
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 12;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.TesoreriaV2.id = SAP.Tesoreria.TesoreriaV2.Identificador;
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesReporte frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesReporte();
            frm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 11;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 10;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 13;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
