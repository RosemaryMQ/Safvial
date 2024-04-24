using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Cobradores.Controles
{
    public partial class Pagos : Form
    {
        String RecibeDato;
        public static String Identificador;
        String Fecha;
        public static string vehiculo;
        public static string tarifa;
        public static string forma;
        public Pagos()
        {
            InitializeComponent();
            RecibeDato = SAP.Cobradores.Recaudadores.TipoVehiculo;
            if (RecibeDato == "Liviano")
            {
                Tipo.Text = RecibeDato;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.Liviano))+" Bs.S";
                Identificador = SAP.Cobradores.Recaudadores.IDLiviano;
            }
            if (RecibeDato == "Microbus")
            {
                Tipo.Text = RecibeDato;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.Microbus)) + " Bs.S";
                Identificador = SAP.Cobradores.Recaudadores.IDMicrobus;
            }
            if (RecibeDato == "Autobus")
            {
                Tipo.Text = RecibeDato;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.Autobus)) + " Bs.S";
                Identificador = SAP.Cobradores.Recaudadores.IDAutobus;
            }
            if (RecibeDato == "Carga Liviana")
            {
                Tipo.Text = RecibeDato;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.CargaLiviana)) + " Bs.S";
                Identificador = SAP.Cobradores.Recaudadores.IDCargaliviana;
            }
            if (RecibeDato == "2 Ejes")
            {
                Tipo.Text = RecibeDato;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.ejes2)) + " Bs.S";
                Identificador = SAP.Cobradores.Recaudadores.IDejes2;

            }
            if (RecibeDato == "3 Ejes")
            {
                Tipo.Text = RecibeDato;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.ejes3)) + " Bs.S";
                Identificador = SAP.Cobradores.Recaudadores.IDejes3;
            }
            if (RecibeDato == "4 Ejes")
            {
                Tipo.Text = RecibeDato;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.ejes4)) + " Bs.S";
                Identificador = SAP.Cobradores.Recaudadores.IDejes4;
            }
            if (RecibeDato == "5 Ejes")
            {
                Tipo.Text = RecibeDato;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.ejes5)) + " Bs.S";
                Identificador = SAP.Cobradores.Recaudadores.IDejes5;
            }
            if (RecibeDato == "6 Ejes o Mas")
            {
                Tipo.Text = RecibeDato;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Recaudadores.ejes6)) + " Bs.S";
                Identificador = SAP.Cobradores.Recaudadores.IDejes6;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
            this.Close();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tarifa = Tarifa.Text;
            vehiculo = Tipo.Text;
            forma = "Efectivo";    
            SAP.Cobradores.Controles.Efectivo.PagoEfectivo frm1 = new SAP.Cobradores.Controles.Efectivo.PagoEfectivo();
            frm1.ShowDialog();
            this.Close();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1)
            {

                tarifa = Tarifa.Text;
                vehiculo = Tipo.Text;
                forma = "Efectivo";
                SAP.Cobradores.Controles.Efectivo.PagoEfectivo frm1 = new SAP.Cobradores.Controles.Efectivo.PagoEfectivo();
                frm1.Show();
                this.Close();
            }
            if (e.KeyCode == Keys.NumPad2)
            {

                tarifa = Tarifa.Text;
                vehiculo = Tipo.Text;
                forma = "Punto de Venta";
                SAP.Cobradores.Controles.PuntoVenta.PuntoVenta frm = new SAP.Cobradores.Controles.PuntoVenta.PuntoVenta();
                frm.Show();
                this.Close();
            }
            if (button3.Enabled == true)
            {
                if (e.KeyCode == Keys.NumPad3)
                {
                    SAP.Cobradores.Controles.SaldoPrepagado.SaldoPrepagado frm = new SAP.Cobradores.Controles.SaldoPrepagado.SaldoPrepagado();
                    frm.Show();
                    this.Close();
                }

            }         
            if (e.KeyCode == Keys.NumPad4)
            {
                try
                {
                    DialogResult resultado = MessageBox.Show("Confirme operacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        Fecha = DateTime.Now.ToString("G");
                        CargarPago2(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(Identificador), Fecha, Convert.ToInt32(SAP.Inicio.Canal));
                        //SAP.Cobradores.Controles.Facturar frm1 = new SAP.Cobradores.Controles.Facturar();
                        //frm1.Show();
                        SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
                        this.Close();
                        frm.Show();
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
                this.Close();
                frm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tarifa = Tarifa.Text;
            vehiculo = Tipo.Text;
            forma = "Punto de Venta";
            SAP.Cobradores.Controles.PuntoVenta.PuntoVenta frm = new SAP.Cobradores.Controles.PuntoVenta.PuntoVenta();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SAP.Cobradores.Controles.SaldoPrepagado.SaldoPrepagado frm = new SAP.Cobradores.Controles.SaldoPrepagado.SaldoPrepagado();
            frm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirme operacion","Confirmacion", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    Fecha = DateTime.Now.ToString("G");
                    CargarPago1(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(Identificador), Fecha, Convert.ToInt32(SAP.Inicio.Canal));
                    SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                    frm1.Show();
                    this.Close();
                }
                
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CargarPago1(int id_user, int id_vehiculo, string fecha, int canal)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal) Values (@iduser,@idvehiculo,@fecha,'Ticket','',@canal)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CargarPago2(int id_user, int id_vehiculo, string fecha, int canal)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal) Values (@iduser,@idvehiculo,@fecha,'Pago Incompleto','',@canal)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.ExecuteReader();
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirme operacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Fecha = DateTime.Now.ToString("G");
                    CargarPago2(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(Identificador), Fecha, Convert.ToInt32(SAP.Inicio.Canal));
                    SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
                    this.Close();
                    frm.Show();
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
