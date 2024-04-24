using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SAP.Cobradores.Controles.V2
{
    public partial class Transferencia : Form
    {
        public Transferencia()
        {
            InitializeComponent();
            Tipo.Text = SAP.Cobradores.RecaudacionV2.TipoVehiculo;
            Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Controles.V2.FormaPago.Costo)) + " Bs.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task<Boolean> CargarPago(int id_user, int id_vehiculo, string forma, int canal, int turno)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal,Turno) Values (@iduser,@idvehiculo,SYSDATETIME(),@forma,@referencia,@canal,@turno)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("iduser", id_user);
                    cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                    cmd.Parameters.AddWithValue("forma", forma);
                    cmd.Parameters.AddWithValue("canal", canal);
                    cmd.Parameters.AddWithValue("referencia", referencia.Text);
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

        private void label5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (referencia.Text!="" && referencia.TextLength > 4)
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
                else
                {
                    Accion.Text = "";
                    MessageBox.Show("El campo de referencia no puede estar vacio y debe ser mayor a 4 digitos. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                Accion.Text = "";
                MessageBox.Show("Error, Falla de conexion con el servidor ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void referencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (referencia.Text != "" && referencia.TextLength > 4)
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
                    else
                    {
                        Accion.Text = "";
                        MessageBox.Show("El campo de referencia no puede estar vacio y debe ser mayor a 4 digitos. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
