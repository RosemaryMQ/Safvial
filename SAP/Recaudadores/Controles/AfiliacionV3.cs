using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace SAP.Recaudadores.Controles
{
    public partial class AfiliacionV3 : Form
    {
        int sede = SAP.Inicio.sede;
        int cantidad = 0;
        double precio;
        double monto;
        double tarjetas;
        Boolean code;
        String asignacion;
        String Formapago;
        int cliente = Convert.ToInt32(SAP.Recaudadores.Controles.Usuario.ID);
        int usuario = Convert.ToInt32(SAP.Inicio.ID);
        String Cedula = SAP.Recaudadores.Controles.Afiliacion.cedula;
        String Nombre = SAP.Recaudadores.Controles.Afiliacion.nombre;
        String SaldoDisponible = SAP.Recaudadores.Controles.Afiliacion.direccion;
        String Telefono = SAP.Recaudadores.Controles.Afiliacion.tlf;
        String Vehiculo = SAP.Recaudadores.Controles.Afiliacion.tipov;
        String Correo = SAP.Recaudadores.Controles.Afiliacion.email;
        int Identificador = Convert.ToInt32(SAP.Inicio.ID);
        String fecha;
        Double resultado;
        Double valor2 = 0;
        String forma = "";
        string iduser = SAP.Inicio.ID;
        string idcliente;
        String formapago2;
        int validador=0;
        int acumulador = 0;
        public static double PrecioTarjeta = 0;
        public static double PromoAdicional = 0;
        public static double SaldoAdicional = 0;
        public static string NombrePromo = "";
        double saldoAdicionalPromo = 0;
        bool PromoEspecial = false;
        String codigoTarjet;
        public AfiliacionV3()
        {
            InitializeComponent();
            Ejecucion.Items.Add("✔ Apertura Usuario...");
            NombreC.Text = "CLIENTE: "+SAP.Recaudadores.Controles.Afiliacion.nombre;
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
        private bool EsValido(string cedula)
        {
            string sql = "Select ID_Cliente FROM Cliente Where CI=@cedula";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cedula", cedula);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
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
        private void Consulta(string cedula)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select ID_Cliente FROM Cliente Where CI=@cedula", cn);
            cmd.Parameters.AddWithValue("cedula", cedula);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idcliente = dr["ID_Cliente"].ToString();

            }
            dr.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                textBox1.Enabled = true;
                button9.Enabled = true;
            }
            else
            {
                MessageBox.Show("Se debe cargar al menos una tarjeta para proceder.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es punto venta? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                valor2 = Convert.ToDouble(textBox1.Text);
                monto = 0;
                tarjetas = 0;
                monto = (precio * cantidad) + valor2;
                tarjetas = precio * cantidad;
                Costo.Text = string.Format("{0:n}", monto) + " Bs.S";
                Formapago = "A.PDV";
                formapago2 = "Recarga PDV";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button2.Enabled = false;
                button9.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
                textBox1.Enabled = false;
                PromoEspecial = false;
                NombrePromo = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es transferencia? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                valor2 = Convert.ToDouble(textBox1.Text);
                monto = 0;
                tarjetas = 0;
                monto = (precio * cantidad) + valor2;
                tarjetas = precio * cantidad;
                Costo.Text = string.Format("{0:n}", monto) + " Bs.S";

                Costo.Text = string.Format("{0:n}", monto) + " Bs.S";
                Formapago = "A.Transferencia";
                formapago2 = "Recarga Transf";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button2.Enabled = false;
                button9.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
                textBox1.Enabled = false;
                PromoEspecial = false;
                NombrePromo = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro de realizar la operacion de afiliacion? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                if (Formapago == "A.Transferencia")
                {
                    if (!Referencia(referencia.Text) && referencia.Text != "" && Convert.ToDouble(referencia.Text) != 0)
                    {
                        validador = 0;
                        button3.Enabled = false;
                        referencia.Enabled = false;
                        if (textBox1.Text != "")
                        {

                            fecha = DateTime.Now.ToString("G");
                            do
                            {
                                if (validador == 0)
                                {
                                    Ejecucion.Items.Add("Creando Usuario...");
                                    try
                                    {
                                        if (!EsValido(SAP.Recaudadores.Controles.Afiliacion.cedula))
                                        {
                                            CargarCliente(SAP.Recaudadores.Controles.Afiliacion.cedula, SAP.Recaudadores.Controles.Afiliacion.nombre, textBox1.Text, Convert.ToInt32(SAP.Inicio.ID), SAP.Recaudadores.Controles.Afiliacion.direccion, SAP.Recaudadores.Controles.Afiliacion.tlf, fecha, SAP.Recaudadores.Controles.Afiliacion.email, SAP.Recaudadores.Controles.Afiliacion.tipov);
                                            validador++;
                                            progressBar1.Increment(15);
                                            Ejecucion.Items.Add("✔ Usuario Creado Correctamente...");
                                        }
                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Crear Usuario...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }

                                }
                                if (validador == 1)
                                {
                                    Ejecucion.Items.Add("Cargando Pago...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        CargarPago1(Convert.ToInt32(iduser), DateTime.Now.ToString("G"), Formapago, Convert.ToDouble(tarjetas), sede, Convert.ToInt32(idcliente), referencia.Text);
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Pago Cargado Correctamente...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Cargar Pago...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 2)
                                {
                                    Ejecucion.Items.Add("Cargando Backup de Pago...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        CargarPago1(Convert.ToInt32(iduser), DateTime.Now.ToString("G"), formapago2, Convert.ToDouble(textBox1.Text), sede, Convert.ToInt32(idcliente), referencia.Text);
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Backup Pago Cargado Correctamente...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Cargar Backup de Pago...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 3)
                                {
                                    Ejecucion.Items.Add("Anexando Tarjetas...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        Usuarioinfo(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Solicitud Confirmada...");
                                        Ejecucion.Items.Add("✔ Procesando...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Solicitud Fallida...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 4)
                                {
                                    Ejecucion.Items.Add("Vinculando Tarjetas...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        if (cantidad > 0)
                                        {
                                            Int32 i;
                                            String codigo;
                                            DataGridViewCell columna1;
                                            for (i = 0; i < ListaCode.Rows.Count; i++)
                                            {
                                                columna1 = ListaCode.Rows[i].Cells[1];
                                                codigo = ((String)columna1.Value);
                                                CargarTarjeta(Convert.ToInt32(idcliente), Convert.ToInt32(usuario), SAP.Inicio.sede, codigo);
                                                CargarPago2(codigo, Formapago, referencia.Text, usuario, DateTime.Now.ToString("G"), Convert.ToInt32(idcliente), sede);

                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("Disculpe,debe cargar al menos 1 tarjeta para proceder.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                        validador++;
                                        progressBar1.Increment(25);
                                        Ejecucion.Items.Add("✔ Tarjetas Asignadas Correctamente...");
                                        Ejecucion.Items.Add("✔ Procesando...");
                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Solicitud Fallida...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                            } while (validador < 5);
                            MessageBox.Show("Tarjetas y pago cargado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            if (textBox1.Text == "")
                                textBox1.Text = "0";

                            fecha = DateTime.Now.ToString("G");
                            do
                            {

                                if (validador == 0)
                                {
                                    Ejecucion.Items.Add("Creando Usuario...");
                                    try
                                    {
                                        if (!EsValido(SAP.Recaudadores.Controles.Afiliacion.cedula))
                                        {
                                            CargarCliente(SAP.Recaudadores.Controles.Afiliacion.cedula, SAP.Recaudadores.Controles.Afiliacion.nombre, textBox1.Text, Convert.ToInt32(SAP.Inicio.ID), SAP.Recaudadores.Controles.Afiliacion.direccion, SAP.Recaudadores.Controles.Afiliacion.tlf, fecha, SAP.Recaudadores.Controles.Afiliacion.email, SAP.Recaudadores.Controles.Afiliacion.tipov);
                                            validador++;
                                            progressBar1.Increment(15);
                                            Ejecucion.Items.Add("✔ Usuario Creado Correctamente...");
                                        }
                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Crear Usuario...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }

                                }
                                if (validador == 1)
                                {
                                    Ejecucion.Items.Add("Cargando Pago...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        CargarPago1(Convert.ToInt32(iduser), DateTime.Now.ToString("G"), Formapago, Convert.ToDouble(tarjetas), sede, Convert.ToInt32(idcliente), referencia.Text);
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Pago Cargado Correctamente...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Cargar Pago...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 2)
                                {
                                    Ejecucion.Items.Add("Cargando Backup de Pago...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        CargarPago1(Convert.ToInt32(iduser), DateTime.Now.ToString("G"), formapago2, Convert.ToDouble(textBox1.Text), sede, Convert.ToInt32(idcliente), referencia.Text);
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Backup Pago Cargado Correctamente...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Cargar Backup de Pago...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 3)
                                {
                                    Ejecucion.Items.Add("Anexando Tarjetas...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        Usuarioinfo(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Solicitud Confirmada...");
                                        Ejecucion.Items.Add("✔ Procesando...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Solicitud Fallida...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 4)
                                {
                                    Ejecucion.Items.Add("Vinculando Tarjetas...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        if (cantidad > 0)
                                        {
                                            Int32 i;
                                            String codigo;
                                            DataGridViewCell columna1;
                                            for (i = 0; i < ListaCode.Rows.Count; i++)
                                            {
                                                columna1 = ListaCode.Rows[i].Cells[1];
                                                codigo = ((String)columna1.Value);
                                                CargarTarjeta(Convert.ToInt32(idcliente), Convert.ToInt32(usuario), SAP.Inicio.sede, codigo);
                                                CargarPago2(codigo, Formapago, referencia.Text, usuario, DateTime.Now.ToString("G"), Convert.ToInt32(idcliente), sede);

                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("Disculpe,debe cargar al menos 1 tarjeta para proceder.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                        validador++;
                                        progressBar1.Increment(25);
                                        Ejecucion.Items.Add("✔ Tarjetas Asignadas Correctamente...");
                                        Ejecucion.Items.Add("✔ Procesando...");
                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Solicitud Fallida...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                            } while (validador < 5);
                            MessageBox.Show("Tarjetas y pago cargado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
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
                        validador = 0;
                        button3.Enabled = false;
                        referencia.Enabled = false;
                        if (textBox1.Text != "")
                        {

                            fecha = DateTime.Now.ToString("G");
                            do
                            {
                                if (validador == 0)
                                {
                                    Ejecucion.Items.Add("Creando Usuario...");
                                    try
                                    {
                                        if (!EsValido(SAP.Recaudadores.Controles.Afiliacion.cedula))
                                        {
                                            CargarCliente(SAP.Recaudadores.Controles.Afiliacion.cedula, SAP.Recaudadores.Controles.Afiliacion.nombre, textBox1.Text, Convert.ToInt32(SAP.Inicio.ID), SAP.Recaudadores.Controles.Afiliacion.direccion, SAP.Recaudadores.Controles.Afiliacion.tlf, fecha, SAP.Recaudadores.Controles.Afiliacion.email, SAP.Recaudadores.Controles.Afiliacion.tipov);
                                            validador++;
                                            progressBar1.Increment(15);
                                            Ejecucion.Items.Add("✔ Usuario Creado Correctamente...");
                                        }
                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Crear Usuario...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }

                                }
                                if (validador == 1)
                                {
                                    Ejecucion.Items.Add("Cargando Pago...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        CargarPago1(Convert.ToInt32(iduser), DateTime.Now.ToString("G"), Formapago, Convert.ToDouble(tarjetas), sede, Convert.ToInt32(idcliente), referencia.Text);
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Pago Cargado Correctamente...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Cargar Pago...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 2)
                                {
                                    Ejecucion.Items.Add("Cargando Backup de Pago...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        CargarPago1(Convert.ToInt32(iduser), DateTime.Now.ToString("G"), formapago2, Convert.ToDouble(textBox1.Text), sede, Convert.ToInt32(idcliente), referencia.Text);
                                        if (PromoEspecial == true)
                                        {
                                            double Suma = Math.Round(saldoAdicionalPromo + SaldoAdicional);
                                            string refe = "Promocion de saldo adicional";
                                            CargarPago1(Convert.ToInt32(iduser), DateTime.Now.ToString("G"), "Exonerada", Suma, sede, Convert.ToInt32(idcliente), refe);
                                        }
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Backup Pago Cargado Correctamente...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Cargar Backup de Pago...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 3)
                                {
                                    Ejecucion.Items.Add("Anexando Tarjetas...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        Usuarioinfo(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Solicitud Confirmada...");
                                        Ejecucion.Items.Add("✔ Procesando...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Solicitud Fallida...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 4)
                                {
                                    Ejecucion.Items.Add("Vinculando Tarjetas...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        if (cantidad > 0)
                                        {
                                            Int32 i;
                                            String codigo;
                                            DataGridViewCell columna1;
                                            for (i = 0; i < ListaCode.Rows.Count; i++)
                                            {
                                                columna1 = ListaCode.Rows[i].Cells[1];
                                                codigo = ((String)columna1.Value);
                                                CargarTarjeta(Convert.ToInt32(idcliente), Convert.ToInt32(usuario), SAP.Inicio.sede, codigo);
                                                CargarPago2(codigo, Formapago, referencia.Text, usuario, DateTime.Now.ToString("G"), Convert.ToInt32(idcliente), sede);

                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("Disculpe,debe cargar al menos 1 tarjeta para proceder.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                        validador++;
                                        progressBar1.Increment(25);
                                        Ejecucion.Items.Add("✔ Tarjetas Asignadas Correctamente...");
                                        Ejecucion.Items.Add("✔ Procesando...");
                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Solicitud Fallida...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                            } while (validador < 5);
                            MessageBox.Show("Tarjetas y pago cargado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            textBox1.Text = "0";
                            fecha = DateTime.Now.ToString("G");
                            do
                            {

                                if (validador == 0)
                                {
                                    Ejecucion.Items.Add("Creando Usuario...");
                                    try
                                    {
                                        if (!EsValido(SAP.Recaudadores.Controles.Afiliacion.cedula))
                                        {
                                            CargarCliente(SAP.Recaudadores.Controles.Afiliacion.cedula, SAP.Recaudadores.Controles.Afiliacion.nombre, textBox1.Text, Convert.ToInt32(SAP.Inicio.ID), SAP.Recaudadores.Controles.Afiliacion.direccion, SAP.Recaudadores.Controles.Afiliacion.tlf, fecha, SAP.Recaudadores.Controles.Afiliacion.email, SAP.Recaudadores.Controles.Afiliacion.tipov);
                                            validador++;
                                            progressBar1.Increment(15);
                                            Ejecucion.Items.Add("✔ Usuario Creado Correctamente...");
                                        }
                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Crear Usuario...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }

                                }
                                if (validador == 1)
                                {
                                    Ejecucion.Items.Add("Cargando Pago...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        CargarPago1(Convert.ToInt32(iduser), DateTime.Now.ToString("G"), Formapago, Convert.ToDouble(tarjetas), sede, Convert.ToInt32(idcliente), referencia.Text);
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Pago Cargado Correctamente...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Cargar Pago...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 2)
                                {
                                    Ejecucion.Items.Add("Cargando Backup de Pago...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        CargarPago1(Convert.ToInt32(iduser), DateTime.Now.ToString("G"), formapago2, Convert.ToSingle(textBox1.Text), sede, Convert.ToInt32(idcliente), referencia.Text);
                                        if (PromoEspecial == true)
                                        {
                                            double Suma = Math.Round(saldoAdicionalPromo + SaldoAdicional);
                                            string refe = "Promocion de saldo adicional";
                                            CargarPago1(Convert.ToInt32(iduser), DateTime.Now.ToString("G"), "Exonerada", Suma, sede, Convert.ToInt32(idcliente), refe);
                                        }
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Backup Pago Cargado Correctamente...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Error al Cargar Backup de Pago...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 3)
                                {
                                    Ejecucion.Items.Add("Anexando Tarjetas...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        Usuarioinfo(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        validador++;
                                        progressBar1.Increment(15);
                                        Ejecucion.Items.Add("✔ Solicitud Confirmada...");
                                        Ejecucion.Items.Add("✔ Procesando...");

                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Solicitud Fallida...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                                if (validador == 4)
                                {
                                    Ejecucion.Items.Add("Vinculando Tarjetas...");
                                    try
                                    {
                                        Consulta(SAP.Recaudadores.Controles.Afiliacion.cedula);
                                        if (cantidad > 0)
                                        {
                                            Int32 i;
                                            String codigo;
                                            DataGridViewCell columna1;
                                            for (i = 0; i < ListaCode.Rows.Count; i++)
                                            {
                                                columna1 = ListaCode.Rows[i].Cells[1];
                                                codigo = ((String)columna1.Value);
                                                CargarTarjeta(Convert.ToInt32(idcliente), Convert.ToInt32(usuario), SAP.Inicio.sede, codigo);
                                                CargarPago2(codigo, Formapago, referencia.Text, usuario, DateTime.Now.ToString("G"), Convert.ToInt32(idcliente), sede);

                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("Disculpe,debe cargar al menos 1 tarjeta para proceder.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                        validador++;
                                        progressBar1.Increment(25);
                                        Ejecucion.Items.Add("✔ Tarjetas Asignadas Correctamente...");
                                        Ejecucion.Items.Add("✔ Procesando...");
                                    }
                                    catch
                                    {
                                        Ejecucion.Items.Add("✘ Solicitud Fallida...");
                                        Ejecucion.Items.Add("Reintentando...");
                                    }
                                }
                            } while (validador < 5);
                            MessageBox.Show("Tarjetas y pago cargado correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("el campo de referencia no puede ser vacio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

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
            if(checkBox1.Checked == false) { 
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
                            if (code == false && asignacion=="0")
                            {
                                cantidad = cantidad + 1;
                                ListaCode.Rows.Add(cantidad, Tarjeta.Text, "Eliminar");
                                monto = 0;
                                tarjetas = 0;
                                monto = precio * cantidad;
                                tarjetas = precio * cantidad;
                                Costo.Text = string.Format("{0:n}", monto) + " Bs.S";
                                Tarjeta.Text = "";
                                asignacion = "";
                            }
                            else
                            {
                                if (code == true && asignacion!="")
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
                                    tarjetas = 0;
                                    monto = precio * cantidad;
                                    tarjetas = precio * cantidad;
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
        private void CargarCliente(string ci, string nombre, string saldo, int usuario, string direccion, string telefono, string fecha, string correo, string tipo)
        {
            string sql = "Insert into Cliente(CI,Nombre,SaldoDisponible,ID_Usuario,Direccion,Telefono,FechaIngreso,Correo,TipoVehiculo,Exonerado) Values (@ci,@nombre,@saldo,@usuario,@direccion,@telefono,@fecha,@correo,@tipo,'No')";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("ci", ci);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("saldo", 0);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("direccion", direccion);
                cmd.Parameters.AddWithValue("telefono", telefono);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("correo", correo);
                cmd.Parameters.AddWithValue("tipo", tipo);
                cmd.ExecuteReader();
                return;
            }

        }
        private void CargarPago1(int id_user, string fecha,string Forma,double monto,int sede,int cliente,string referencia)
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
        private void Usuarioinfo(string cedula)
        {
            string sql = "Select ID_Cliente From Cliente Where CI=@cedula";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cedula", cedula);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    iduser = dr["ID_Cliente"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void CargarPago2(string Tarjeta, string forma, string referencia, int usuario, string fecha, int cliente,int sede)
        {
            string sql = "Insert into PagoV2(CodigoTarjeta,FormaPago,Referencia,ID_Usuario,ID_Cliente,Fecha,ID_Sede) Values (@tarjeta,@forma,@referencia,@usuario,@cliente,@fecha,@sede);";
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
                cmd.Parameters.AddWithValue("sede",sede);
                cmd.ExecuteReader();
                return;
            }
        }

        private void ListaCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ListaCode.Rows[e.RowIndex];
            ListaCode.Rows.Remove(row);
            cantidad = cantidad - 1;
            monto = 0;
            tarjetas = 0;
            monto = (precio * cantidad) + valor2;
            tarjetas = precio * cantidad;
            Costo.Text = string.Format("{0:n}", monto) + " Bs.S";
            Tarjeta.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                valor2 = Convert.ToDouble(textBox1.Text);
                monto = 0;
                tarjetas = 0;
                monto = (precio * cantidad) + valor2;
                tarjetas = precio * cantidad;
                Costo.Text = string.Format("{0:n}", monto) + " Bs.S";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13) && e.KeyChar != (char)44)
            {
                e.Handled = true;
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.PromocionesPrepagado frm = new SAP.Recaudadores.Controles.PromocionesPrepagado();
            frm.ShowDialog();
            if (NombrePromo != "")
            {
                Formapago = "A.OPE";
                formapago2 = "Recarga OPE";
                monto = 0;
                tarjetas = 0;
                tarjetas = PrecioTarjeta * cantidad;
                monto = PrecioTarjeta * cantidad;
                saldoAdicionalPromo = (PrecioTarjeta * PromoAdicional) / 100;
                saldoAdicionalPromo = saldoAdicionalPromo * cantidad;
                monto = monto + SaldoAdicional;
                Costo.Text = string.Format("{0:n}", Convert.ToDouble(monto)) + " Bs.S";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button2.Enabled = false;
                button9.Enabled = false;
                button3.Enabled = true;
                referencia.Enabled = false;
                referencia.Text = NombrePromo;
                PromoEspecial = true;
                textBox1.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es reintegro? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Formapago = "A.Reintegro";
                formapago2 = "Reintegro";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button2.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
                textBox1.Enabled = false;
                PromoEspecial = false;
                NombrePromo = "";
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

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que la forma de pago es efectivo? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Formapago = "A.Efectivo";
                formapago2 = "Recarga Efectivo";
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button2.Enabled = false;
                button9.Enabled = false;
                referencia.Enabled = true;
                button3.Enabled = true;
                textBox1.Enabled = false;
                PromoEspecial = false;
                NombrePromo = "";
            }
        }
    }
}