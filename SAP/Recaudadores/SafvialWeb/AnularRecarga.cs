using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.SafvialWeb
{
    public partial class AnularRecarga : Form
    {
        public AnularRecarga()
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
                        ActualizarOperacion(Motivo.Text,SAP.Recaudadores.SafvialWeb.Transferencias.id);
                        MessageBox.Show("Anulada Correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void ActualizarOperacion(string motivo, int code)
        {
            string sql = "Update RecargasWeb Set Observacion=@motivo, Condicion='Anulada', FechaSubida=@fecha Where ID_Operacion=@code";
            using (SqlConnection cn = new SqlConnection(Inicio.WEB))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("motivo", motivo);
                cmd.Parameters.AddWithValue("code", code);
                cmd.Parameters.AddWithValue("fecha", DateTime.Now);
                cmd.ExecuteReader();
                return;
            }
        }
    }
}
