using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class Usuario : Form
    {
        public static String ID;
        public static String Nombre;
        public static String Correo;
        public static String DNI;
        public Usuario()
        {
            InitializeComponent();
        }
        private void ConsultaCliente(string ci)
        {
            string sql = "Select ID_Cliente,Nombre,Correo FROM Cliente Where CI=@rif";
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
                    Nombre = dr["Nombre"].ToString();
                    Correo = dr["Correo"].ToString();
                }
                dr.Close();
                return;
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ID = "";
                DNI = Prefijo.Text + rif.Text;
                ConsultaCliente(DNI);
                if (ID != "")
                {
                    SAP.Recaudadores.Controles.AsignarTarjetasEmpresa frm = new SAP.Recaudadores.Controles.AsignarTarjetasEmpresa();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("DNI no registrado en los sistemas SAFVIAL.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error al intentar realizar la consulta intente de nuevo mas tarde.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
