using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class TarjetasCliente : Form
    {
        public static string codigo;
        public static string codigo1;
        public TarjetasCliente()
        {
            InitializeComponent();
            Cliente.Text = SAP.Recaudadores.Controles.Consulta.nombre;
            try
            {
                ActualizarGrid1();
            }
            catch
            {
                MessageBox.Show("Error al consultar tarjetas reintente mas tarde.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ActualizarGrid1()
        {
            int contador = 0;
            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT TarjetasCliente.CodigoCliente,TarjetasCliente.Reportada,ControlTarjeta.CodigoControl From TarjetasCliente INNER JOIN ControlTarjeta ON TarjetasCliente.CodigoCliente = ControlTarjeta.CodigoCliente WHERE TarjetasCliente.ID_Cliente=@cliente", cn);
            cmd.Parameters.AddWithValue("cliente", Convert.ToInt32(SAP.Recaudadores.Controles.Consulta.ID_Cliente));
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                contador = contador + 1;
                Usuario.Rows.Add(contador,dr["CodigoCliente"].ToString(), dr["Reportada"].ToString(), dr["CodigoControl"].ToString(), "CONSUMO","REPORTAR");
            }
            dr.Close();
        }

        private void Usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name== "anular" && e.RowIndex >= 0)
            {
                SAP.Inicio.acceso = 5;
                DataGridViewRow row = Usuario.Rows[e.RowIndex];
                codigo = Convert.ToString(row.Cells[1].Value);
                SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
                frm.ShowDialog();
                if (SAP.Common.WinForms.Autorizacion.validador == 1)
                {
                    if (Convert.ToBoolean(row.Cells[2].Value) == true)
                    {
                        Anulacion(codigo, 0);
                    }
                    else
                    {
                        Anulacion(codigo, 1);
                    }      
                    SAP.Common.WinForms.Autorizacion.validador = 0;
                    this.Close();
                    SAP.Recaudadores.Controles.TarjetasCliente frm1 = new SAP.Recaudadores.Controles.TarjetasCliente();
                    frm1.ShowDialog();      
                }
            }
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "ver" && e.RowIndex >= 0)
            {
                DataGridViewRow row = Usuario.Rows[e.RowIndex];
                codigo = Convert.ToString(row.Cells[1].Value);
                codigo1 = Convert.ToString(row.Cells[3].Value);
                SAP.Recaudadores.Controles.ConsumoTarjeta frm1 = new SAP.Recaudadores.Controles.ConsumoTarjeta();
                frm1.ShowDialog();
            }

        }
        private void Anulacion(string tarjeta,int condicion)
        {
            string sql = "Update TarjetasCliente Set Reportada=@condicion, Operador=@usuario Where CodigoCliente=@tarjeta";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", SAP.Inicio.ID);
                cmd.Parameters.AddWithValue("tarjeta", tarjeta);
                cmd.Parameters.AddWithValue("condicion", condicion);
                cmd.ExecuteReader();
                return;
            }
        }
    }
}
