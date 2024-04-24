using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SAP.Cobradores.Controles.V2
{
    public partial class Especial : Form
    {
        public Especial()
        {
            InitializeComponent();
            Tipo.Text = SAP.Cobradores.RecaudacionV2.TipoVehiculo;
            Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Controles.V2.FormaPago.Costo)) + " Bs.S";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task<Boolean> CargarPagoEspecial(int id_user, int id_vehiculo, string forma, int canal, int turno,int cantidad)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal,Turno,Especial) Values (@iduser,@idvehiculo,SYSDATETIME(),@forma,@referencia,@canal,@turno,1)";
            using (SqlConnection cn = new SqlConnection(SAP.Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("referencia", cantidad);
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
                if (referencia.Text!="" && referencia.Text != "0" && referencia.TextLength > 0)
                { 
                Loading.Visible = true;
                Panel.Visible = false;
                Accion.Text = "Transmitiendo informacion...";
               
                if (await CargarPagoEspecial(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Cobradores.Controles.V2.FormaPago.Forma, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno), Convert.ToInt32(referencia.Text)))
                {
                    Accion.Text = "Imprimiendo ticket...";
                    SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                    frm1.Show();
                    this.Close();
                }
                else
                {
                   
                    if (await CargarPagoEspecial(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Cobradores.Controles.V2.FormaPago.Forma, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno), Convert.ToInt32(referencia.Text)))
                    {
                        Accion.Text = "Imprimiendo ticket...";
                        SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                        frm1.Show();
                        this.Close();
                    }
                    else
                    {
                        Panel.Visible = true;
                        Loading.Visible = false;
                        MessageBox.Show("Error, Falla de conexion con el servidor ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                }
                else
                {
                    MessageBox.Show("El campo de referencia no puede estar vacio y debe ser mayor a 0 digitos. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                if (referencia.Text != "" && referencia.Text != "0" && referencia.TextLength > 4)
                {
                    if (await CargarPagoEspecial(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Cobradores.Controles.V2.FormaPago.Forma, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno), Convert.ToInt32(referencia.Text)))
                {
                    Accion.Text = "Imprimiendo ticket...";
                    SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                    frm1.Show();
                    this.Close();
                }
                else
                {
                    Panel.Visible = true;
                    Loading.Visible = false;
                    MessageBox.Show("Error, Falla de conexion con el servidor ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
                else
                {
                    MessageBox.Show("El campo de referencia no puede estar vacio y debe ser mayor a 0 digitos. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void referencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (referencia.Text != "" && referencia.Text != "0" && referencia.TextLength > 0)
                    {
                        Loading.Visible = true;
                        Panel.Visible = false;
                        Accion.Text = "Transmitiendo informacion...";

                        if (await CargarPagoEspecial(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Cobradores.Controles.V2.FormaPago.Forma, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno), Convert.ToInt32(referencia.Text)))
                        {
                            Accion.Text = "Imprimiendo ticket...";
                            SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                            frm1.Show();
                            this.Close();
                        }
                        else
                        {

                            if (await CargarPagoEspecial(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Cobradores.Controles.V2.FormaPago.Forma, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno), Convert.ToInt32(referencia.Text)))
                            {
                                Accion.Text = "Imprimiendo ticket...";
                                SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                                frm1.Show();
                                this.Close();
                            }
                            else
                            {
                                Panel.Visible = true;
                                Loading.Visible = false;
                                MessageBox.Show("Error, Falla de conexion con el servidor ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo de referencia no puede estar vacio y debe ser mayor a 0 digitos. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    if (referencia.Text != "" && referencia.Text != "0" && referencia.TextLength > 0)
                    {
                        if (await CargarPagoEspecial(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), SAP.Cobradores.Controles.V2.FormaPago.Forma, Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno), Convert.ToInt32(referencia.Text)))
                        {
                            Accion.Text = "Imprimiendo ticket...";
                            SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                            frm1.Show();
                            this.Close();
                        }
                        else
                        {
                            Panel.Visible = true;
                            Loading.Visible = false;
                            MessageBox.Show("Error, Falla de conexion con el servidor ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo de referencia no puede estar vacio y debe ser mayor a 0 digitos. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void referencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
    }
}
