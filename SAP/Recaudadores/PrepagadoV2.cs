using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores
{
    public partial class PrepagadoV2 : Form
    {
        string hora = DateTime.Now.ToString("d");
        public static String codigo;
        public static String referencia;
        Boolean code;
        string codigotarjeta;
        public PrepagadoV2()
        {
            InitializeComponent();
            Usuario.Text = "USUARIO: " + SAP.Inicio.User + " " + SAP.Inicio.Apellido;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Seguro, que desea cerrar sesión?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    FinSession(Inicio.ID);
                    ControlUser(Inicio.ID, hora);
                    this.Hide();
                    SAP.Inicio frm = new SAP.Inicio();
                    frm.Show();
                }
            }
            catch
            {
                MessageBox.Show("¡Error,al intentar desconectarte del sistema por favor reintente de nuevo!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FinSession(string usuario)
        {
            string sql = "Update Usuarios Set Estado='No Conectado' Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.ExecuteReader();
                return;
            }
        }
        private void ControlUser(string usuario, string fecha)
        {
            string sql = "Insert into ControlUsuario (ID_Usuario,Conexiones) values (@usuario,@fecha)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.ExecuteReader();
                return;
            }
        }
        private void Consulta(string codigo)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select Activa FROM TarjetasCliente Where CodigoCliente=@codigo", cn);
            cmd.Parameters.AddWithValue("codigo", codigo);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                code = Convert.ToBoolean(dr["Activa"].ToString());
            }
            dr.Close();
        }
        private void Consulta1(string codigo)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select TarjetasCliente.Activa,TarjetasCliente.CodigoCliente FROM TarjetasCliente INNER JOIN ControlTarjeta ON TarjetasCliente.CodigoCliente = ControlTarjeta.CodigoCliente Where ControlTarjeta.CodigoControl=@codigo", cn);
            cmd.Parameters.AddWithValue("codigo", Convert.ToInt32(codigo));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                code = Convert.ToBoolean(dr["Activa"].ToString());
                codigotarjeta = dr["CodigoCliente"].ToString();
            }
            dr.Close();
        }
        private void infUsuario(string dni)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select Cliente.CI From Cliente Inner Join TarjetasCliente ON Cliente.ID_Cliente=TarjetasCliente.ID_Cliente WHERE TarjetasCliente.CodigoCliente=@tarjeta", cn);
            cmd.Parameters.AddWithValue("tarjeta", dni);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SAP.Recaudadores.Controles.Buscador.DNI = dr["CI"].ToString();
            }
            dr.Close();
        }
        private void Tarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    if (checkBox1.Checked == false)
                    {
                        if (Tarjeta.Text.Length >= 9)
                        {
                            if (EsValido(Tarjeta.Text))
                            {
                                Consulta(Tarjeta.Text);
                                if (code == true)
                                {
                                    DialogResult result = MessageBox.Show("Tarjeta Asignada ¿Desea Consultar el Usuario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                    {
                                        infUsuario(Tarjeta.Text);
                                        SAP.Recaudadores.Controles.Consulta frm = new SAP.Recaudadores.Controles.Consulta();
                                        frm.Show();
                                        Tarjeta.Text = null;
                                    }
                                    else
                                    {
                                        Tarjeta.Text = null;
                                    }
                                }
                                else if (code == false)
                                {
                                    MessageBox.Show("Tarjeta No Asignada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Tarjeta.Text = "";

                                }
                            }
                            else
                            {
                                MessageBox.Show("Tarjeta, No encontrada en sistemas safvial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Tarjeta.Text = "";

                            }

                        }
                        else
                        {
                            MessageBox.Show("La tarjeta invalida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Tarjeta.Text = "";
                            codigo = "";
                        }
                    }
                    else if (checkBox1.Checked == true)
                    {
                        if (Tarjeta.TextLength >= 1)
                        {
                            if (EsValido1(Tarjeta.Text))
                            {
                                Consulta1(Tarjeta.Text);
                                if (codigotarjeta != "")
                                {
                                    if (code == true)
                                    {
                                        DialogResult result = MessageBox.Show("Tarjeta Asignada ¿Desea Consultar el Usuario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (result == DialogResult.Yes)
                                        {
                                            infUsuario(codigotarjeta);
                                            SAP.Recaudadores.Controles.Consulta frm = new SAP.Recaudadores.Controles.Consulta();
                                            frm.Show();
                                            Tarjeta.Text = null;
                                        }
                                        else
                                        {
                                            Tarjeta.Text = null;
                                            codigotarjeta = null;
                                        }
                                    }
                                    else if (code == false)
                                    {
                                        MessageBox.Show("Tarjeta No Asignada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Tarjeta.Text = "";
                                        codigotarjeta = "";
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("La tarjeta no encontrada en sistemas safvial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Tarjeta.Text = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Codigo de Control, No encontrado en sistemas safvial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Tarjeta.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("El campo de busqueda no puede ser vacio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Tarjeta.Text = "";
                            codigotarjeta = "";
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error al intentar realizar la consulta intente de nuevo mas tarde", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Tarjeta.Text = "";
                }
            }
        }
        private bool EsValido(string codigo)
        {
            string sql = "Select CodigoCliente FROM ControlTarjeta Where CodigoCliente=@codigo";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("codigo", codigo);
                double val = Convert.ToDouble(cmd.ExecuteScalar());
                return !(val == 0);
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
        private void button5_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.Usuario frm = new SAP.Recaudadores.Controles.Usuario();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.RecargaV2 frm = new SAP.Recaudadores.RecargaV2();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.Reporte frm = new SAP.Recaudadores.Controles.Reporte();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.Afiliacion frm = new SAP.Recaudadores.Controles.Afiliacion();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 8;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.Buscador frm = new SAP.Recaudadores.Controles.Buscador();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 7;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
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
            SAP.Recaudadores.SafvialWeb.MenuWeb frm = new SAP.Recaudadores.SafvialWeb.MenuWeb();
            frm.ShowDialog();
        }

        private void PrepagadoV2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 27;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
        }
    }
}
