using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class AnularOperacion : Form
    {
        float saldo;
        double total;
        string Clientet;
        public AnularOperacion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Motivo.Text != "")
                {
                    if (Motivo.TextLength > 10)
                    {
                            ConsultaUser(SAP.Recaudadores.Controles.OperacionesDiarias.dniuser);
                            this.actualizarweb(Motivo.Text,Clientet, SAP.Recaudadores.Controles.OperacionesDiarias.referencia);
                            MotivoEdicion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(Clientet), DateTime.Now, Motivo.Text, Convert.ToInt32(SAP.Recaudadores.Controles.OperacionesDiarias.id));
                            ActualizarOperacion(SAP.Recaudadores.Controles.OperacionesDiarias.forma, 0, "ANULADA", SAP.Recaudadores.Controles.OperacionesDiarias.id);
                            MessageBox.Show("Actualizado Correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La motivo debe ser mayor a 10 caracteres.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los campos", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            {
                MessageBox.Show("Error intentar actualizar, por favor reintente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ActualizarOperacion(string forma, double monto, string referencia, string codigo)
        {
            string sql = "Update Ventas Set FormaPago=@forma, Monto=@monto, Referencia=@referencia Where ID_Venta=@codigo";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("monto", monto);
                cmd.Parameters.AddWithValue("referencia", referencia);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.ExecuteReader();
                return;
            }
        }
        private void MotivoEdicion(int usuario, int cliente, DateTime fecha, string motivo, int venta)
        {
            string sql = "Insert into Operaciones(ID_Usuario,ID_Cliente,Operacion,Fecha,Observacion,ID_Venta) Values (@usuario,@cliente,'Anulacion Operacion',@fecha,@motivo,@venta);";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("motivo", motivo);
                cmd.Parameters.AddWithValue("venta", venta);
                cmd.ExecuteReader();
                return;
            }
        }
        private void monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }
        private void ActualizarSaldo(string codigo, string saldo)
        {
            string sql = "Update Cliente Set SaldoDisponible=@saldo Where CI=@codigo";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.Parameters.AddWithValue("saldo", saldo);
                cmd.ExecuteReader();
                return;
            }
        }
        private void ConsultaUser(string cliente)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select ID_Cliente,SaldoDisponible From Cliente Where CI=@cliente", cn);
            cmd.Parameters.AddWithValue("cliente", cliente);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                saldo = Convert.ToSingle(dr["SaldoDisponible"].ToString());
                Clientet = dr["ID_Cliente"].ToString();

            }
            dr.Close();
        }
        private void actualizarweb(string motivo, string cliente, string referencia)
        {
            string sql = "Update RecargasWEB Set Condicion='Anulada',Observacion=@motivo,FechaSubida=@fecha Where DNI=@cliente AND Referencia=@ref";
            using (SqlConnection cn = new SqlConnection(Inicio.WEB))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("motivo", motivo);
                cmd.Parameters.AddWithValue("fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.Parameters.AddWithValue("ref", referencia);
                cmd.ExecuteReader();
                return;
            }
        }
    }
}
