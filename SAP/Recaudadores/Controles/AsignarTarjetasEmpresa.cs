using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class AsignarTarjetasEmpresa : Form
    {
        int cantidad = 0;
        double precio;
        double monto;
        Boolean code;
        String asignacion;
        String Formapago;
        String formapago2;
        int cliente = Convert.ToInt32(SAP.Recaudadores.Controles.Usuario.ID);
        int usuario = Convert.ToInt32(SAP.Inicio.ID);
        double saldoAdicionalPromo = 0;
        bool PromoEspecial = false;
        String codigoTarjet;
        public AsignarTarjetasEmpresa()
        {
            InitializeComponent();
            NombreC.Text = "CLIENTE: "+SAP.Recaudadores.Controles.Usuario.Nombre;
            try
            {
                CostoTarjeta();
            }
            catch
            {
                CostoTarjeta();
            }
            
        }
        private void Consulta2(string codigo)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select Activa,ID_Cliente FROM TarjetasCliente Where CodigoCliente=@codigo", cn);
            cmd.Parameters.AddWithValue("codigo", codigo);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                code = Convert.ToBoolean(dr["Activa"].ToString());
                asignacion = dr["ID_Cliente"].ToString();
            }
            dr.Close();

        }
        private bool EsValido1(string codigo)
        {
            string sql = "Select CodigoControl FROM ControlTarjeta Where CodigoControl=@codigo";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("codigo", Convert.ToInt32(codigo));
                double val = Convert.ToDouble(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void Tarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
            if (checkBox1.Checked == false)
            {
                if (e.KeyChar == (char)13)
                {
                    try
                    {
                        if (Tarjeta.Text != "")
                        {
                            bool exist = ListaCode.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["Codigo"].Value) == Tarjeta.Text);
                            if (!exist)
                            {

                                Consulta2(Tarjeta.Text);
                                if (code == false && asignacion == "0")
                                {
                                    cantidad = cantidad + 1;
                                    ListaCode.Rows.Add(cantidad, Tarjeta.Text, "Eliminar");
                                    monto = 0;
                                    monto = precio * cantidad;
                                    Costo.Text = string.Format("{0:n}", monto) + " Bs.S";
                                    Tarjeta.Text = "";
                                    asignacion = "";
                                }
                                else
                                {
                                    if (code == true && asignacion != "")
                                    {
                                        MessageBox.Show("Disculpe la tarjeta ingresada esta siendo usada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        Tarjeta.Text = "";
                                        code = false;
                                        asignacion = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Disculpe la tarjeta ingresada no se encuentra registrada en sistema.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        Tarjeta.Text = "";
                                    }

                                }



                            }
                            else
                            {
                                MessageBox.Show("Disculpe, la tarjeta ya fue cargada anteriormente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Tarjeta.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("El campo de codigo de tarjeta  no puede ser vacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ocurrio un error al validar la tarjeta intente de nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Tarjeta.Text = "";
                    }
                }
            }
            else if (checkBox1.Checked == true)
            {
                if (e.KeyChar == (char)13)
                {
                    try { 
                    if (Tarjeta.Text != "")
                    {
                        if (EsValido1(Tarjeta.Text))
                        {
                            Consulta1(Tarjeta.Text);
                            if (code == false && asignacion == "0")
                            {
                                bool exist = ListaCode.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["Codigo"].Value) == codigoTarjet);
                                if (!exist)
                                {
                                    cantidad = cantidad + 1;
                                    ListaCode.Rows.Add(cantidad, codigoTarjet, "Eliminar");
                                    monto = 0;
                                    monto = precio * cantidad;
                                    Costo.Text = string.Format("{0:n}", monto) + " Bs.S";
                                    Tarjeta.Text = "";
                                    asignacion = "";
                                }
                                else
                                {
                                    MessageBox.Show("Disculpe, la tarjeta ya fue cargada anteriormente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    Tarjeta.Text = "";
                                }
                            }
                            else
                            {
                                if (code == true && asignacion != "")
                                {
                                    MessageBox.Show("Disculpe la tarjeta ingresada esta siendo usada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    Tarjeta.Text = "";
                                    code = false;
                                    asignacion = "";
                                    codigoTarjet = "";
                                }
                                else
                                {
                                    MessageBox.Show("Disculpe la tarjeta ingresada no se encuentra registrada en sistema.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    Tarjeta.Text = "";
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Disculpe, el codigo de tarjeta usado no ha sido encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Tarjeta.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo de codigo de tarjeta  no puede ser vacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                    catch
                {
                    MessageBox.Show("Ocurrio un error al validar la tarjeta intente de nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Tarjeta.Text = "";
                }
            }
            }
        }
        private void Consulta1(string codigo)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select TarjetasCliente.Activa,TarjetasCliente.CodigoCliente,TarjetasCliente.ID_Cliente FROM TarjetasCliente INNER JOIN ControlTarjeta ON TarjetasCliente.CodigoCliente = ControlTarjeta.CodigoCliente Where ControlTarjeta.CodigoControl=@codigo", cn);
            cmd.Parameters.AddWithValue("codigo", Convert.ToInt32(codigo));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                code = Convert.ToBoolean(dr["Activa"].ToString());
                codigoTarjet = dr["CodigoCliente"].ToString();
                asignacion = dr["ID_Cliente"].ToString();
            }
            dr.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        String valor;
        private void CostoTarjeta()
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select TipoVehiculos.Tarifa From TipoVehiculos Where TipoVehiculos.Nombre='Prepagada'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                valor = dr["Tarifa"].ToString();
                precio = Convert.ToDouble(valor);
            }
            dr.Close();

        }

        private void ListaCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ListaCode.Rows[e.RowIndex];
            ListaCode.Rows.Remove(row);
            cantidad = cantidad - 1;
            monto = 0;
            monto = precio * cantidad;
            Costo.Text = string.Format("{0:n}", monto) + " Bs.S";
            Tarjeta.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cantidad >= 1)
            {
                Tarjeta.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button9.Enabled = true;
            }
            else
            {
                MessageBox.Show("Se debe cargar al menos una tarjeta para proceder.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        private void referencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
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
                Formapago = "Tarjeta PDV";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button9.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es transferencia? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Formapago = "Tarjeta Transf";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button9.Enabled = false;
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
                if (Formapago == "Tarjeta Transf")
                {
                    if (!Referencia(referencia.Text) && referencia.Text != "" && Convert.ToDouble(referencia.Text) != 0)
                    {
                        if (cantidad > 0)
                        {
                            Int32 i;
                            String codigo;
                            DataGridViewCell columna1;
                            for (i = 0; i < ListaCode.Rows.Count; i++)
                            {
                                columna1 = ListaCode.Rows[i].Cells[1];
                                codigo = ((String)columna1.Value);
                                CargarTarjeta(Convert.ToInt32(cliente), Convert.ToInt32(usuario), SAP.Inicio.sede, codigo);
                                CargarPago2(codigo, Formapago, referencia.Text, usuario, DateTime.Now.ToString("G"), cliente);

                            }
                            CargarPago(usuario, DateTime.Now.ToString("g"), Formapago, Convert.ToSingle(monto), Convert.ToInt32(SAP.Inicio.sede), cliente, referencia.Text);
                            if (PromoEspecial == true)
                            {
                                double Suma = saldoAdicionalPromo + SAP.Recaudadores.Controles.AfiliacionV3.SaldoAdicional;
                                string refe = "Promocion del: " + Convert.ToString(SAP.Recaudadores.Controles.AfiliacionV3.PromoAdicional) + "%";
                                CargarPago1(usuario, DateTime.Now.ToString("G"), "Exonerada", Convert.ToSingle(Suma), SAP.Inicio.sede, Convert.ToInt32(cliente), refe);
                            }
                            MessageBox.Show("Tarjetas y pago cargado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Disculpe,debe cargar al menos 1 tarjeta para proceder.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                        if (cantidad > 0)
                        {
                            Int32 i;
                            String codigo;
                            DataGridViewCell columna1;
                            for (i = 0; i < ListaCode.Rows.Count; i++)
                            {
                                columna1 = ListaCode.Rows[i].Cells[1];
                                codigo = ((String)columna1.Value);
                                CargarTarjeta(Convert.ToInt32(cliente), Convert.ToInt32(usuario), SAP.Inicio.sede, codigo);
                                CargarPago2(codigo, Formapago, referencia.Text, usuario, DateTime.Now.ToString("G"), cliente);

                            }
                            CargarPago(usuario, DateTime.Now.ToString("g"), Formapago, Convert.ToSingle(monto), Convert.ToInt32(SAP.Inicio.sede), cliente, referencia.Text);
                            if (PromoEspecial == true)
                            {
                                double Suma = saldoAdicionalPromo + SAP.Recaudadores.Controles.AfiliacionV3.SaldoAdicional;
                                string refe = "Promocion del: " + Convert.ToString(SAP.Recaudadores.Controles.AfiliacionV3.PromoAdicional) + "%";
                                CargarPago1(usuario, DateTime.Now.ToString("G"), "Exonerada", Convert.ToSingle(Suma), SAP.Inicio.sede, Convert.ToInt32(cliente), refe);
                            }
                            MessageBox.Show("Tarjetas y pago cargado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Disculpe,debe cargar al menos 1 tarjeta para proceder.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("el campo de referencia no puede ser vacio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }



            }
            catch
            {
                MessageBox.Show("Ocurrio un error al intentar la informacion reintente de nuevo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void CargarTarjeta(int cliente, int user, int sede, string tarjeta)
        {
            string sql = "Update TarjetasCliente Set ID_Cliente=@cliente, ID_Usuario=@usuario, Apertura=@fecha,Sede=@sede, Activa=1 Where CodigoCliente=@tarjeta";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.Parameters.AddWithValue("usuario", user);
                cmd.Parameters.AddWithValue("fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.Parameters.AddWithValue("tarjeta", tarjeta);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CargarPago(int id_user, string fecha, string Forma, float monto, int sede, int cliente, string referencia)
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
        private void CargarPago2(string Tarjeta,string forma,string referencia,int usuario, string fecha, int cliente)
        {
            string sql = "Insert into PagoV2(CodigoTarjeta,FormaPago,Referencia,ID_Usuario,ID_Cliente,Fecha,ID_Sede) Values (@tarjeta,@forma,@referencia,@usuario,@cliente,@fecha,'1');";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("tarjeta", Tarjeta);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("referencia", referencia);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.ExecuteReader();
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.PromocionesPrepagado frm = new SAP.Recaudadores.Controles.PromocionesPrepagado();
            frm.ShowDialog();
            if (SAP.Recaudadores.Controles.AfiliacionV3.NombrePromo != "")
            {
                Formapago = "A.OPE";
                formapago2 = "Recarga OPE";
                monto = 0;
                monto = SAP.Recaudadores.Controles.AfiliacionV3.PrecioTarjeta * cantidad;
                saldoAdicionalPromo = (SAP.Recaudadores.Controles.AfiliacionV3.PrecioTarjeta * SAP.Recaudadores.Controles.AfiliacionV3.PromoAdicional) / 100;
                saldoAdicionalPromo = saldoAdicionalPromo * cantidad;
                monto = monto + SAP.Recaudadores.Controles.AfiliacionV3.SaldoAdicional;
                Costo.Text = string.Format("{0:n}", Convert.ToDouble(monto)) + " Bs.S";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button2.Enabled = false;
                button9.Enabled = false;
                button3.Enabled = true;
                referencia.Enabled = false;
                referencia.Text = SAP.Recaudadores.Controles.AfiliacionV3.NombrePromo;
                PromoEspecial = true;
                referencia.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es Reintegro? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Formapago = "A.Reintegro";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button9.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Tarjeta.UseSystemPasswordChar = false;
            }
            else
            {
                Tarjeta.UseSystemPasswordChar = true;
            }
        }
        private void CargarPago1(int id_user, string fecha, string Forma, float monto, int sede, int cliente, string referencia)
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

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es Reintegro? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Formapago = "Tarjeta Efectivo";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button9.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
            }
        }
    }
 }
