using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class BuscadorReferencia : Form
    {
        public BuscadorReferencia()
        {
            InitializeComponent();
            buscador(SAP.Recaudadores.PrepagadoV2.referencia);

        }
        private void buscador(string referencias)
        {
            string sql = "SELECT Cliente.Nombre, Ventas.Monto, Ventas.Referencia, Ventas.Fecha FROM Ventas INNER JOIN Cliente ON Ventas.ID_Cliente = Cliente.ID_Cliente WHERE (Ventas.Referencia = @referencia)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("referencia", referencias);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Nombre.Text = dr["Nombre"].ToString();
                    monto.Text = string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString()));
                    FECHA.Text = dr["Fecha"].ToString();
                    referencia.Text = dr["Referencia"].ToString();
                }
                dr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
