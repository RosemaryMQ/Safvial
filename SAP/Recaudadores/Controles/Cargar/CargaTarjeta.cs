using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SAP.Recaudadores.Controles.Cargar
{
    public partial class CargaTarjeta : Form
    {
        int cantidad = 0;
        public CargaTarjeta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cantidad > 0)
                {
                    Int32 i;
                String codigo;
                DataGridViewCell columna1;
                    //    for (i = 0; i < 1000; i++)
                    //    {
                    //        try
                    //        {
                    //            codigo2++;
                    //            codigo = Convert.ToString(codigo2);
                    //            string sql = "Insert into ClienteTarjeta (CodigoCliente,ID_Cliente,Estatus,ID_Usuario,Apertura) Values ('" + codigo + "','0','Inactivo','0','')";
                    //            SqlConnection cn1 = new SqlConnection(Inicio.conexion2);
                    //            cn1.Open();
                    //            SqlCommand cmd1 = new SqlCommand(sql, cn1);
                    //            cmd1.ExecuteReader();
                    //            cn1.Close();
                    //        }
                    //        catch
                    //        {

                    //        }

                    //    }
                    for (i = 0; i < ListaCode.Rows.Count; i++)
                {
                    try
                    {
                        columna1 = ListaCode.Rows[i].Cells[1];
                        codigo = ((String)columna1.Value);
                        string sql = "Insert into ClienteTarjeta (CodigoCliente,ID_Cliente,Estatus,ID_Usuario,Apertura,Sede) Values ('" + codigo + "','','Inactivo','','','')";
                        SqlConnection cn1 = new SqlConnection(Inicio.conexion2);
                        cn1.Open();
                        SqlCommand cmd1 = new SqlCommand(sql, cn1);
                        cmd1.ExecuteReader();
                        cn1.Close();
                    }
                    catch
                    {

                    }

                }
                //SqlCommand cmd = new SqlCommand("Insert into ClienteTarjeta (CodigoCliente,ID_Cliente,Estatus,ID_Usuario) values (@tarjeta,'','Inactivo','')", cn);
                //foreach (DataGridViewRow row in ListaCode.Rows)
                //{
                //    cmd.Parameters.Clear();
                //    cmd.Parameters.AddWithValue("tarjeta", Convert.ToString(row.Cells["Codigo"].Value));
                //    cmd.ExecuteNonQuery();
                //}
                MessageBox.Show("Tarjetas cargadas sastifactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }//FIN DEL FOR//
                else
                {
                    MessageBox.Show("Disculpe,debe cargar al menos 1 tarjeta para proceder.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            catch
            {
                MessageBox.Show("Ocurrio un error al cargar las tarjetas intente de nuevo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }
        private void Tarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)13)
            {
                if(Tarjeta.Text != "")
                {
                    bool exist = ListaCode.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["Codigo"].Value) == Tarjeta.Text);
                    if (!exist)
                    {
                        cantidad = cantidad + 1;
                        ListaCode.Rows.Add(cantidad, Tarjeta.Text);
                        Tarjeta.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Disculpe, la tarjeta ya fue cargada anteriormente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Tarjeta.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("El campo de codigo de tarjeta  no puede ser vacio.s", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void Tarjeta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
