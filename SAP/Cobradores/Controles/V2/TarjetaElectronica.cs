using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Cobradores.Controles.V2
{
    public partial class TarjetaElectronica : Form
    {
        public static string DNI ="";
        public static string tarjeta ="";
        public static string saldo = "";
        public static string codigocontrol = "";
        public static double suma = 0;
        public TarjetaElectronica()
        {
            InitializeComponent();
            suma = 0;
            suma =SAP.Cobradores.RecaudacionV2.PromoTarjeta+ SAP.Cobradores.RecaudacionV2.Tarjeta;
            Promo.Text= string.Format("{0:n}", Convert.ToDouble(suma)) + " Bs.S";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                    try
                    {
                        if (CodigoTarjeta.Text != "")
                        {
                            Loading.Visible = true;
                            Panel.Visible = false;
                            Accion.Text = "Conectando con el servicio prepagado...";
                            if (await EsValido(CodigoTarjeta.Text))
                            {
                                Accion.Text = "Validando informacion...";

                                if (await Consulta1(CodigoTarjeta.Text)== false)
                                {

                                    tarjeta = CodigoTarjeta.Text;
                                    saldo = Convert.ToString(SAP.Cobradores.RecaudacionV2.PromoTarjeta);
                                    SAP.Cobradores.Controles.V2.Confirmacion frm = new SAP.Cobradores.Controles.V2.Confirmacion();
                                    frm.ShowDialog();
                                    this.Close();
                                }
                                else
                                {
                                    Panel.Visible = true;
                                    Loading.Visible = false;
                                    MessageBox.Show("La tarjeta ingresada no esta siendo utilizada por otro usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    CodigoTarjeta.Text = "";
                                }

                            }
                            else
                            {
                                Panel.Visible = true;
                                Loading.Visible = false;
                                MessageBox.Show("La tarjeta ingresada no es valida por favor ingrese nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                CodigoTarjeta.Text = "";
                            }

                        }
                        else
                        {
                            Panel.Visible = true;
                            Loading.Visible = false;
                            MessageBox.Show("Debe llenar todos los campos para procesar la solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    catch
                    {
                        Panel.Visible = true;
                        Loading.Visible = false;
                        MessageBox.Show("Error al procesar la solicitud, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    if (CodigoTarjeta.Text != "")
                    {
                        Loading.Visible = true;
                        Panel.Visible = false;
                        Accion.Text = "Conectando con el servicio prepagado...";
                        if (await EsValido(CodigoTarjeta.Text))
                        {
                            Accion.Text = "Validando informacion...";
                           
                            if (await Consulta1(CodigoTarjeta.Text) == false)
                            {

                                tarjeta = CodigoTarjeta.Text;
                                saldo = Convert.ToString(SAP.Cobradores.RecaudacionV2.PromoTarjeta);
                                SAP.Cobradores.Controles.V2.Confirmacion frm = new SAP.Cobradores.Controles.V2.Confirmacion();
                                frm.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                Panel.Visible = true;
                                Loading.Visible = false;
                                MessageBox.Show("La tarjeta ingresada no esta siendo utilizada por otro usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                CodigoTarjeta.Text = "";
                            }

                        }
                        else
                        {
                            Panel.Visible = true;
                            Loading.Visible = false;
                            MessageBox.Show("La tarjeta ingresada no es valida por favor ingrese nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            CodigoTarjeta.Text = "";
                        }

                    }
                    else
                    {
                        Panel.Visible = true;
                        Loading.Visible = false;
                        MessageBox.Show("Debe llenar todos los campos para procesar la solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch(Exception ex)
                {
                    Panel.Visible = true;
                    Loading.Visible = false;
                    MessageBox.Show("Error al procesar la solicitud, intente nuevamente."+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

        }

        private async Task<Boolean> EsValido(string codigo)
        {
            string sql = "Select CodigoCliente FROM ControlTarjeta Where CodigoCliente=@codigo";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("codigo", codigo);
                double val = Convert.ToDouble(await cmd.ExecuteScalarAsync());
                return !(val == 0);
            }
        }
        private void Cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }
        private async Task<Boolean> Consulta1(string codigo)
        {
            Boolean code = false;
            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            await cn.OpenAsync();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select TarjetasCliente.Activa,ControlTarjeta.CodigoControl FROM TarjetasCliente INNER JOIN ControlTarjeta ON TarjetasCliente.CodigoCliente = ControlTarjeta.CodigoCliente Where TarjetasCliente.CodigoCliente=@codigo", cn);
            cmd.Parameters.AddWithValue("codigo", codigo);
            dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
            {
                
                codigocontrol = dr["CodigoControl"].ToString();
                code = Convert.ToBoolean(dr["Activa"].ToString());
            }
            dr.Close();
            cn.Close();
            return code;
        }

        private void Tarjeta_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CodigoTarjeta_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Promo_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
