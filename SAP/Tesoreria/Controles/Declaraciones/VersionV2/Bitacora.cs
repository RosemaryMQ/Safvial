using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class Bitacora : Form
    {
        public static string operacion = "";
        public static string observacion = "";
        public Bitacora()
        {
            try
            {
                InitializeComponent();
                this.ActualizarGrid1();
            }
            catch
            {
                MessageBox.Show("Error al intentar consultar la informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public void ActualizarGrid1()
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT Operacion.ID_Operacion,Operacion.Observacion,Operacion.Fecha FROM Operacion Where Operacion.ID_Cataporte = @cataporte", cn);
            cmd.Parameters.AddWithValue("cataporte", SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta);
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Observacion"].ToString(), dr["Fecha"].ToString(), "VER");
            }
            dr.Close();
        }

        private void Usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Usuario.Rows[e.RowIndex];
            operacion = Convert.ToString(row.Cells[0].Value);
            observacion = Convert.ToString(row.Cells[1].Value);
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.Operacion frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Operacion();
            frm.ShowDialog();
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            if (Usuario.Rows.Count == 0)
            {
                MessageBox.Show("no hay modificiaciones realizadas a este cataporte", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
