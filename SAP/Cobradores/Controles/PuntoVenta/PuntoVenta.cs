using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SAP.Cobradores.Controles.PuntoVenta
{
    public partial class PuntoVenta : Form
    {
        String Fecha;
        int Identificador = Convert.ToInt32(SAP.Cobradores.Controles.Pagos.Identificador);
        public PuntoVenta()
        {
            InitializeComponent();
            Tipo.Text = SAP.Cobradores.Controles.Pagos.vehiculo;
            Tarifa.Text = SAP.Cobradores.Controles.Pagos.tarifa;
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
                    CargarPago(Convert.ToInt32(SAP.Inicio.ID), Identificador, Convert.ToDateTime(Fecha), "", Convert.ToInt32(SAP.Inicio.Canal));
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

        private void tableLayoutPanel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    this.Fecha = DateTime.Now.ToString("G");
                    CargarPago(Convert.ToInt32(SAP.Inicio.ID), Identificador, Convert.ToDateTime(Fecha), "", Convert.ToInt32(SAP.Inicio.Canal));
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
        private void CargarPago(int id_user, int id_vehiculo, DateTime fecha, string referencia,int canal)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal) Values (@iduser,@idvehiculo,@fecha,'Punto de Venta',@referencia,@canal)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("referencia", referencia);
                cmd.ExecuteReader();
                return;
            }
        }
    }
}
