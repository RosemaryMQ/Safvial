using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class Buscador : Form
    {
        public static String ID;
        public static String DNI;
        public Buscador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ConsultaCliente(string ci)
        {
            string sql = "Select ID_Cliente FROM Cliente Where CI=@rif";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("rif", ci);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ID = dr["ID_Cliente"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ID = "";
                DNI = Prefijo.Text + rif.Text;
                ConsultaCliente(DNI);
                if (ID != "")
                {
                    SAP.Recaudadores.Controles.Consulta frm = new SAP.Recaudadores.Controles.Consulta();
                    frm.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("DNI no registrado en los sistemas SAFVIAL.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al intentar realizar la consulta intente de nuevo mas tarde."+ex.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
