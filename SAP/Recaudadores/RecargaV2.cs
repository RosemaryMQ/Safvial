using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores
{
    public partial class RecargaV2 : Form
    {
        public static String ID;
        public static String Nombre;
        public static String Correo;
        public static String DNI;
        public static String saldo;
        public RecargaV2()
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
        private void ConsultaC(string cliente)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT ROUND(SUM(ABONADO)-SUM(CONSUMIDO),-1) AS Saldo,SUM(ABONADO) as Recargado,SUM(CONSUMIDO)as Consumido,ID_Cliente FROM (SELECT (Tarifa) AS CONSUMIDO,0 AS ABONADO,Pagos.ID_Cliente FROM Pagos INNER JOIN TipoVehiculos on Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo UNION ALL SELECT 0 AS CONSUMIDO, (Monto)AS ABONADO, V.ID_Cliente FROM Ventas V WHERE FormaPago IN('Recarga PDV', 'Recarga Transf', 'Recarga WEB', 'Exonerada', 'Recarga OP')) AS T WHERE ID_Cliente = @cliente GROUP BY ID_Cliente; ", cn);
            cmd.Parameters.AddWithValue("cliente", cliente);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                saldo = dr["Saldo"].ToString();
            }
            dr.Close();
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
                    ConsultaC(ID);
                    SAP.Recaudadores.Controles.RecargaV2 frm = new SAP.Recaudadores.Controles.RecargaV2();
                    frm.ShowDialog();
                    this.Close();
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

        private void rif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
