using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Cobradores.Controles.V2
{
    public partial class Biopago : Form
    {
        SqlConnection cn = new SqlConnection(Inicio.conexion);
        public Biopago()
        {
            InitializeComponent();
            Tipo.Text = SAP.Cobradores.RecaudacionV2.TipoVehiculo;
            Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Controles.V2.FormaPago.Costo)) + " Bs.";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Accion.Text = "Transmitiendo informacion...";
                SAP.Cobradores.RecaudacionV2.TipoTabulacion = 1;
                if (await CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Cobradores.Controles.V2.FormaPago.Forma, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno)))
                {
                    Accion.Text = "Imprimiendo ticket...";
                    SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                    frm1.Show();
                    this.Close();
                }
                else
                {

                    if (await CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Cobradores.Controles.V2.FormaPago.Forma, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno)))
                    {
                        Accion.Text = "Imprimiendo ticket...";
                        SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                        frm1.Show();
                        this.Close();
                    }
                    else
                    {
                        Accion.Text = "";
                        MessageBox.Show("Error, Falla de conexion con el servidor ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                Accion.Text = "";
                MessageBox.Show("Error, Falla de conexion con el servidor ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task<Boolean> CargarPago(int id_user, int id_vehiculo, string forma, int canal, int turno)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal,Turno) Values (@iduser,@idvehiculo,SYSDATETIME(),@forma,NULL,@canal,@turno)";
            using (SqlConnection cn = new SqlConnection(SAP.Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("turno", turno);
                if (await cmd.ExecuteNonQueryAsync() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        private async void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Accion.Text = "Transmitiendo informacion...";

                    if (await CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Cobradores.Controles.V2.FormaPago.Forma, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno)))
                    {
                        Accion.Text = "Imprimiendo ticket...";
                        SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                        frm1.Show();
                        this.Close();
                    }
                    else
                    {

                        if (await CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Cobradores.Controles.V2.FormaPago.Forma, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno)))
                        {
                            Accion.Text = "Imprimiendo ticket...";
                            SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                            frm1.Show();
                            this.Close();
                        }
                        else
                        {
                            Accion.Text = "";
                            MessageBox.Show("Error, Falla de conexion con el servidor ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    Accion.Text = "";
                    MessageBox.Show("Error, Falla de conexion con el servidor ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
