using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Cobradores.Controles.Efectivo
{
    public partial class PagoEfectivo : Form
    {
        String Fecha;
        int Identificador = Convert.ToInt32(SAP.Cobradores.Controles.Pagos.Identificador);
        public PagoEfectivo()
        {
            InitializeComponent();
            Tipo.Text = SAP.Cobradores.Controles.Pagos.vehiculo;
            Tarifa.Text = SAP.Cobradores.Controles.Pagos.tarifa;
        }

        private void MontoApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13) && (e.KeyChar != (char)44))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
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
            try
            {
                        this.Fecha = DateTime.Now.ToString("G");
                        CargarPago(Convert.ToInt32(SAP.Inicio.ID), Identificador, Convert.ToDateTime(Fecha), Convert.ToInt32(SAP.Inicio.Canal));
                        SAP.Cobradores.Recaudadores.recaudacion = SAP.Cobradores.Recaudadores.ConsultaRecaudacion(SAP.Inicio.ID);
                        SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                        frm1.Show();
                        SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
                        frm.Show();
                        this.Close();
            }
             catch
            {
                MessageBox.Show("Error al intentar cargar el pago desea volverlo a intentar", "Advertencia", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
        private void PagoEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Fecha = DateTime.Now.ToString("G");
                    CargarPago(Convert.ToInt32(SAP.Inicio.ID), Identificador, Convert.ToDateTime(Fecha), Convert.ToInt32(SAP.Inicio.Canal));
                    SAP.Cobradores.Recaudadores.recaudacion = SAP.Cobradores.Recaudadores.ConsultaRecaudacion(SAP.Inicio.ID);
                    SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                    frm1.Show();
                    SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
                    frm.Show();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error, al cargar pago por favor intente de nuevo ", "Advertencia", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                SAP.Cobradores.Recaudadores frm = new SAP.Cobradores.Recaudadores();
                this.Close();
                frm.Show();
            }
        }
        private void CargarPago(int id_user, int id_vehiculo, DateTime fecha,int canal)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal) Values (@iduser,@idvehiculo,@fecha,'Efectivo','',@canal)";
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
    }
}
