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
    public partial class PromocionesPrepagado : Form
    {
        public static bool editarPromo = false;
        public PromocionesPrepagado()
        {
            InitializeComponent();
            this.ActualizarGrid1();
        }
        public void ActualizarGrid1()
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT [ID],[Nombre],[CostoTarjeta],[PorcentajeSaldo],[SaldoAdicional],[FechaExpiracion] FROM PromocionesTaquilla Where FechaExpiracion > SYSDATETIME()", cn);
            dr = cmd.ExecuteReader();
            Promos.Rows.Clear();
            while (dr.Read())
            {
                Promos.Rows.Add(dr["ID"].ToString(), dr["Nombre"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["CostoTarjeta"])), dr["PorcentajeSaldo"].ToString() , string.Format("{0:n}", Convert.ToDouble(dr["SaldoAdicional"])), dr["FechaExpiracion"].ToString(), "SELECCIONAR");
            }
            dr.Close();
        }

        private void Promos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Promos.Rows[e.RowIndex];
            if (!editarPromo)
            {
                DialogResult result = MessageBox.Show("¿Seguro que la promocion a aplicar es:" + Convert.ToString(row.Cells[1].Value) + "? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    SAP.Recaudadores.Controles.AfiliacionV3.NombrePromo = Convert.ToString(row.Cells[1].Value);
                    SAP.Recaudadores.Controles.AfiliacionV3.PrecioTarjeta = Convert.ToDouble(row.Cells[2].Value);
                    SAP.Recaudadores.Controles.AfiliacionV3.PromoAdicional = Convert.ToDouble(row.Cells[3].Value);
                    SAP.Recaudadores.Controles.AfiliacionV3.SaldoAdicional = Convert.ToDouble(row.Cells[4].Value);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No se puede modificar por esta via por favor notifique al personal encargado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
