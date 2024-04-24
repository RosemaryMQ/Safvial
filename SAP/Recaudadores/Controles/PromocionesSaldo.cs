using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Recaudadores.Controles
{
    public partial class PromocionesSaldo : Form
    {
        public PromocionesSaldo()
        {
            InitializeComponent();
            this.ActualizarGrid1();
        }

        public void ActualizarGrid1()
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT [Id],[Nombre],[Porcentaje],[Monto],[FechaExpiracion],[FechaVigencia] FROM [SafvialPrepago].[dbo].[PromocionesRecarga] Where FechaExpiracion > SYSDATETIME()", cn);
            dr = cmd.ExecuteReader();
            Promos.Rows.Clear();
            while (dr.Read())
            {
                Promos.Rows.Add(dr["ID"].ToString(), dr["Nombre"].ToString(), dr["Porcentaje"].ToString(), dr["Monto"].ToString(), dr["FechaVigencia"].ToString(), dr["FechaExpiracion"].ToString(), "SELECCIONAR");
            }
            dr.Close();
        }

        private void Promos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Promos.Rows[e.RowIndex];
            DialogResult result = MessageBox.Show("¿Seguro que la promocion a aplicar es:" + Convert.ToString(row.Cells[1].Value) + "? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                SAP.Recaudadores.Controles.RecargaV2.NombrePromo = Convert.ToString(row.Cells[1].Value);
                if (row.Cells[2].Value.ToString().Length > 0)
                {
                    SAP.Recaudadores.Controles.RecargaV2.MontoAdicional = Convert.ToDouble(row.Cells[2].Value);
                    SAP.Recaudadores.Controles.RecargaV2.TipoOperacion = "Porcentaje";
                }
                if (row.Cells[3].Value.ToString().Length > 0)
                {
                    SAP.Recaudadores.Controles.RecargaV2.MontoAdicional = Convert.ToDouble(row.Cells[3].Value);
                    SAP.Recaudadores.Controles.RecargaV2.TipoOperacion = "Monto Exacto";
                }
                this.Close();
            }
        }
    }
}
