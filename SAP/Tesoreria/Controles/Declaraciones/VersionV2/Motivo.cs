using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class Motivo : Form
    {
        public Motivo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Observacion.Text != "")
                {
                    if (Observacion.TextLength > 10)
                    {
                        MotivoEdicion(Convert.ToInt32(SAP.Inicio.ID),Observacion.Text, Convert.ToInt32(SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances.declaracion), Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta));
                        SAP.Tesoreria.Controles.Declaraciones.VersionV2.EditarAvance.validador = 1;
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
        private void MotivoEdicion(int usuario, string motivo, int cierre,int cataporte)
        {
            string sql = "Insert into Operacion (ID_Usuario,Operacion,Fecha,Observacion,ID_Cierre,ID_Cataporte) Values (@usuario,'Edicion de Avance',SYSDATETIME(),@motivo,@cierre,@cataporte)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("motivo", motivo);
                cmd.Parameters.AddWithValue("cierre", cierre);
                cmd.Parameters.AddWithValue("cataporte", cataporte);
                cmd.ExecuteReader();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
