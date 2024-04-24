using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace SAP.Recaudadores.Controles
{
    public partial class RecargaV2 : Form
    {
        decimal recarga = 0;
        String FormaPago;
        String ID = SAP.Recaudadores.RecargaV2.ID;
        int Identificador = Convert.ToInt32(SAP.Inicio.ID);
        double resultado = 0;
        int sede = SAP.Inicio.sede;
        public static string NombrePromo = "";
        public static double MontoAdicional = 0;
        public static string TipoOperacion = "";
        public RecargaV2()
        {
            InitializeComponent();
            NombrePromo = "";
            MontoAdicional = 0;
            TipoOperacion = "";
            Nombre.Text = SAP.Recaudadores.RecargaV2.Nombre;
            this.ConsultaC(SAP.Recaudadores.RecargaV2.ID);
            //Saldo.Text = string.Format("{0:n9}", Convert.ToDouble(SAP.Recaudadores.RecargaV2.saldo)) + " Bs.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ConsultaC(string cliente)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT (SUM(ABONADO)-SUM(CONSUMIDO)) AS Saldo FROM (SELECT (Tarifa) AS CONSUMIDO,0 AS ABONADO,Pagos.ID_Cliente FROM Pagos INNER JOIN TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo UNION ALL SELECT 0 AS CONSUMIDO, (Monto)AS ABONADO, V.ID_Cliente FROM Ventas V WHERE FormaPago IN('Recarga PDV', 'Recarga Transf', 'Recarga WEB', 'Exonerada', 'Recarga OP', 'Reintegro','Promo','Recarga OPE','Recarga Efectivo')) AS T WHERE ID_Cliente = @cliente GROUP BY ID_Cliente;", cn);
            cmd.Parameters.AddWithValue("cliente", cliente);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Saldo.Text = string.Format("{0:n9}", Convert.ToDouble(dr["Saldo"])) + " Bs.";
            }
            dr.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (MontoApertura.Text != "")
            {
                DialogResult result = MessageBox.Show("Seguro que el monto anexado es correcto.", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    MontoApertura.Enabled = false;
                    button5.Enabled = true;
                    button1.Enabled = true;
                    button6.Enabled = true;
                    button8.Enabled = true;
                    button9.Enabled = true;
                    recarga = Convert.ToDecimal(MontoApertura.Text);
                }
            }
            else
            {
                MessageBox.Show("El saldo de recarga no puede ser 0 o vacio.", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
         
        }
        private void MontoApertura_TextChanged(object sender, EventArgs e)
        {
            try
            {
                label5.Text = string.Format("{0:n9}", Convert.ToDecimal(MontoApertura.Text));
            }
            catch
            {

            }
        }
        
        private void MontoApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13) && e.KeyChar != (char)44)
            {
                e.Handled = true;
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es punto venta? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {

                FormaPago = "Recarga PDV";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button8.Enabled = false;
                button1.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es operativo peaje? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                FormaPago = "Recarga OP";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button8.Enabled = false;
                button1.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
            }

        }
        private bool Referencia(string referencia)
        {
            string sql = "SELECT Ventas.Referencia From Ventas Where Ventas.Referencia=@referencia";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("referencia", referencia);
                Int64 val = Convert.ToInt64(cmd.ExecuteScalar());
                cn.Close();
                return !(val == 0);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double totalARecargar = totalARecargar = Convert.ToDouble(MontoApertura.Text.Trim());
                double saldoAdicional = 0;
                if (NombrePromo != "")
                {
                    var value = Convert.ToDouble(MontoApertura.Text);
                    switch (TipoOperacion)
                    {
                        case "Porcentaje":

                            saldoAdicional = (value * MontoAdicional) / 100;
                            break;
                        case "Monto Exacto":
                            saldoAdicional = MontoAdicional;
                            break;
                    }
                }
                if (FormaPago == "Recarga Transf")
                {
                    if (!Referencia(referencia.Text) && referencia.Text != "" && Convert.ToDouble(referencia.Text) != 0)
                    {
                        try
                        {
                            CargarPago(Convert.ToString(resultado), Convert.ToInt32(ID));
                            CargarPago1(Identificador, DateTime.Now.ToString("G"), FormaPago, totalARecargar, sede, Convert.ToInt32(ID), referencia.Text);
                            if (saldoAdicional != 0)
                            {
                                CargarPago1(Identificador, DateTime.Now.ToString("G"), "Exonerada", saldoAdicional, sede, Convert.ToInt32(ID), NombrePromo);
                            }
                            MessageBox.Show("Recarga realizada satisfactoriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Error al intentar cargar el pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else if (Referencia(referencia.Text))
                    {
                        DialogResult result1 = MessageBox.Show("La referencia ya se encuentra registrada en el sistema, ¿Desea ver donde fue recargada?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result1 == DialogResult.Yes)
                        {
                            SAP.Recaudadores.PrepagadoV2.referencia = referencia.Text;
                            SAP.Recaudadores.Controles.BuscadorReferencia frm2 = new SAP.Recaudadores.Controles.BuscadorReferencia();
                            frm2.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Referencia invalida, por favor, verifique., verifique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (referencia.Text != "")
                    {
                        try
                        {
                            CargarPago(Convert.ToString(resultado), Convert.ToInt32(ID));
                            CargarPago1(Identificador, DateTime.Now.ToString("G"), FormaPago, totalARecargar, sede, Convert.ToInt32(ID), referencia.Text);
                            if (saldoAdicional != 0)
                            {
                                CargarPago1(Identificador, DateTime.Now.ToString("G"), "Exonerada", saldoAdicional, sede, Convert.ToInt32(ID), NombrePromo);
                            }
                            ActivarTarjetas(ID);
                            MessageBox.Show("Recarga realizada satisfactoriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Error al intentar cargar el pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        if (referencia.Text == "")
                        {
                            MessageBox.Show("el campo de referencia no puede ser vacio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            MessageBox.Show("La referencia ya se encuentra registrada en el sistema, por favor verifique.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Ocurrio un error al intentar cargar la informacion al sistema por favor reintente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void CargarPago(string resultado, int cliente)
        {
            string sql = "Update Cliente Set SaldoDisponible=@resultado Where ID_Cliente=@cliente";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("resultado", resultado);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.ExecuteReader();
                return;
            }
        }
        private void ActivarTarjetas(string cliente)
        {
            string sql = "Update TarjetasCliente Set Bloqueada=0 Where ID_Cliente=@cliente";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CargarPago1(int id_user, string fecha, string Forma, double monto, int sede, int cliente, string referencia)
        {
            string sql = "Insert into Ventas (ID_Usuario,ID_Cliente,FormaPago,Monto,Referencia,Sede,Fecha) Values (@iduser,@cliente,@forma,@monto,@referencia,@sede,@fecha)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.Parameters.AddWithValue("forma", Forma);
                cmd.Parameters.AddWithValue("monto", monto);
                cmd.Parameters.AddWithValue("referencia", referencia);
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.ExecuteReader();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es efectivo? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                FormaPago = "Recarga Efectivo";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button1.Enabled = false;
                button8.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es por transferencia? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                FormaPago = "Recarga Transf";
                button4.Enabled = false;
                button5.Enabled = false;
                button1.Enabled = false;
                button8.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es reintegro? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                FormaPago = "Reintegro";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button1.Enabled = false;
                button8.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.PromocionesSaldo frm = new SAP.Recaudadores.Controles.PromocionesSaldo();
            frm.ShowDialog();
            if (NombrePromo != "")
            {
                var value = Convert.ToDouble(MontoApertura.Text);
                switch (TipoOperacion)
                {
                    case "Porcentaje":
                        label5.Text = string.Format("{0:n9}", value) + " + " + MontoAdicional.ToString() + "%";
                        break;
                    case "Monto Exacto":
                        label5.Text = string.Format("{0:n9}", value) + " + " + MontoAdicional.ToString();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
