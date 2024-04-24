using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class Avances : Form
    {
        string Vehiculo;
        double recaudo;
        double efectivo;
        double pdv;
        double tickets;
        double incidencia, credito = 0, debito = 0;
        double contador = 0;
        int indice = 0;
        static public string declaracion;
        private void button2_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.Bitacora frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Bitacora();
            frm.Show();
        }

        public static int validador = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesRealizados();
            frm.Show();
        }
        public Avances()
        {
            InitializeComponent();
            usuario(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1));
            TabulacionTipoPago(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
            TabulacionTesoreria(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
            TabulacionTesoreriaBuzon(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
            indice = 1;
            CargarAvances(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 26;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
            CargarAvances(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validador = 1;
            SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesReporte frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesReporte();
            frm.ShowDialog();
        }
        private void AvancesUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = AvancesUser.Rows[e.RowIndex];
            if (row.Cells["Eliminado"].Value.ToString() == "False")
            {
                declaracion = Convert.ToString(row.Cells[0].Value);
                SAP.Inicio.acceso = 14;
                SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
                frm.ShowDialog();
                CargarAvances(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                TabulacionTipoPago(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                TabulacionTesoreria(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                TabulacionTesoreriaBuzon(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
            }
            else
            {
                MessageBox.Show("El avance que intenta modificar ha sido eliminado anteriormente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void Avances_Load(object sender, EventArgs e)
        {
            
        }
    
        private void TabulacionTipoPago(int usuario, string fecha, string fecha1)
        {
            string sql = "SELECT Pagos.FormaPago,SUM(TipoVehiculos.Tarifa)as Recaudado FROM TipoVehiculos INNER JOIN Pagos ON TipoVehiculos.ID_Vehiculo=Pagos.ID_Vehiculo Where Pagos.ID_Usuario=@usuario AND Pagos.Fecha between @fecha and @fecha1 GROUP BY Pagos.FormaPago;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                dr = cmd.ExecuteReader();
                contador = 0;
                while (dr.Read())
                {
                    Vehiculo = dr["FormaPago"].ToString();
                    recaudo = Convert.ToDouble(dr["Recaudado"].ToString());
                    if (Vehiculo == "Efectivo")
                    {
                        ES.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                        contador = contador + Convert.ToDouble(recaudo);
                    }
                    else if (Vehiculo == "Punto de Venta")
                    {
                        PDVS.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                        contador = contador + Convert.ToDouble(recaudo);
                    }
                    else if (Vehiculo == "Transferencia")
                    {
                        STT.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                        contador = contador + Convert.ToDouble(recaudo);
                    }
                    else if (Vehiculo == "Pago Incompleto")
                    {
                        PGS.Text = string.Format("{0:n}", recaudo) + " Bs.S";
                    }
                    TS.Text = string.Format("{0:n}", contador) + " Bs.S";
                }
                dr.Close();
                return;
            }
        }
        private void TabulacionTesoreria(int usuario, string fecha, string fecha1)
        {
            string sql = "SELECT SUM(CierreBalanceV2.Efectivo) as Efectivo,SUM(CierreBalanceV2.PDV) as PDV,SUM(CierreBalanceV2.Tickets)as Tickets,SUM(CierreBalanceV2.Incidencia) as Incidencia,SUM(CierreBalanceV2.Transferencia) as Transferencia FROM CierreBalanceV2 WHERE CierreBalanceV2.ID_Usuario=@usuario and CierreBalanceV2.Fecha BETWEEN @fecha and @fecha1 AND CierreBalanceV2.Eliminado<>1 AND CierreBalanceV2.Buzon<>1;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Efectivo"].ToString() != "")
                    {
                        efectivo = Convert.ToDouble(dr["Efectivo"].ToString());
                        pdv = Convert.ToDouble(dr["PDV"].ToString());
                        tickets = Convert.ToDouble(dr["Tickets"].ToString());
                        incidencia = Convert.ToDouble(dr["Incidencia"].ToString());
                        ET.Text = string.Format("{0:n}", efectivo) + " Bs.S";
                        PDVT.Text = string.Format("{0:n}", pdv) + " Bs.S";
                        TT.Text = string.Format("{0:n}", tickets) + " Bs.S";
                        TTS.Text = string.Format("{0:n}", Convert.ToDouble(dr["Transferencia"].ToString())) + " Bs.S";
                        contador = (efectivo + pdv + tickets + Convert.ToDouble(dr["Transferencia"].ToString()));
                        TOT.Text = string.Format("{0:n}", contador) + " Bs.S";
                    }
                    else
                    {

                    }  
                }
                dr.Close();
                return;
            }
        }
        private void TabulacionTesoreriaBuzon(int usuario, string fecha, string fecha1)
        {
            string sql = "SELECT SUM(CierreBalanceV2.Efectivo) as Efectivo FROM CierreBalanceV2 WHERE CierreBalanceV2.ID_Usuario=@usuario and CierreBalanceV2.Fecha BETWEEN @fecha and @fecha1 AND CierreBalanceV2.Eliminado<>1 AND CierreBalanceV2.Buzon=1;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Efectivo"].ToString() != "")
                    {
                        double buzon = Convert.ToDouble(dr["Efectivo"].ToString());
                        IT.Text = string.Format("{0:n}", buzon) + " Bs.S";
                        contador += buzon;
                        TOT.Text = string.Format("{0:n}", contador) + " Bs.S";
                    }
                    else
                    {

                    }
                }
                dr.Close();
                return;
            }
        }

        private bool EsValido(string usuario)
        {
            string sql = "SELECT * FROM Usuarios WHERE ID_Usuario = @usuario AND Perfil='Administrador' AND Perfil='ADMINISTRADOR'";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void Avance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                    e.Handled = true;
            }

        }
        private void Avance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)

            {

                TextBox tb = e.Control as TextBox;

                tb.KeyPress += new KeyPressEventHandler(Avance_KeyPress);

            }
        }

        private void BDLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = BDLista.Rows[e.RowIndex];
            if (row.Cells["Eliminado2"].Value.ToString() == "False")
            {
                declaracion = Convert.ToString(row.Cells[0].Value);
                SAP.Inicio.acceso = 14;
                SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
                frm.ShowDialog();
                CargarAvances(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                TabulacionTipoPago(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                TabulacionTesoreria(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                TabulacionTesoreriaBuzon(Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1), SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
            }
            else
            {
                MessageBox.Show("El avance que intenta modificar ha sido eliminado anteriormente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void CargarAvances(int usuario,string fecha, string fecha1)
        {
            try
            {
                SqlConnection cn = new SqlConnection(Inicio.conexion);
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand("SELECT  ID_Cierre, BilleteS05, BilleteS1, BilleteS2, BilleteS5, BilleteS10, BilleteS20, BilleteS50, BilleteS100, BilleteS200, BilleteS500, BilleteS10000, BilleteS20000, BilleteS50000, BilleteS200000,BilleteS500000,BilleteS1000000, Tickets, Efectivo, PDV, Incidencia, ID_Usuario,Transferencia,Eliminado,Buzon,BilleteBD1,BilleteBD5,BilleteBD10,BilleteBD20,BilleteBD50,BilleteBD100,BilleteBD05,BilleteBD025 FROM CierreBalanceV2 WHERE(ID_Usuario = @usuario) AND(Fecha BETWEEN @fecha AND @fecha2)", cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha2", fecha1);
                dr = cmd.ExecuteReader();
                AvancesUser.Rows.Clear();
                BDLista.Rows.Clear();
                while (dr.Read())
                {
                    AvancesUser.Rows.Add(dr["ID_Cierre"].ToString(), dr["BilleteS05"].ToString(), dr["BilleteS1"].ToString(), dr["BilleteS2"].ToString(), dr["BilleteS5"].ToString(), dr["BilleteS10"].ToString(), dr["BilleteS20"].ToString(), dr["BilleteS50"].ToString(), dr["BilleteS100"].ToString(), dr["BilleteS200"].ToString(), dr["BilleteS500"].ToString(), dr["BilleteS10000"].ToString(), dr["BilleteS20000"].ToString(), dr["BilleteS50000"].ToString(), dr["BilleteS200000"].ToString(), dr["BilleteS500000"].ToString(), dr["BilleteS1000000"].ToString(), dr["Eliminado"].ToString(), "EDITAR", dr["Buzon"].ToString());
                    BDLista.Rows.Add(dr["ID_Cierre"].ToString(), dr["BilleteBD025"].ToString(), dr["BilleteBD05"].ToString(), dr["BilleteBD1"].ToString(), dr["BilleteBD5"].ToString(), dr["BilleteBD10"].ToString(), dr["BilleteBD20"].ToString(), dr["BilleteBD50"].ToString(), dr["BilleteBD100"].ToString(), dr["PDV"].ToString(), dr["Incidencia"].ToString(), dr["Transferencia"].ToString(), dr["Eliminado"].ToString(), "EDITAR", dr["Buzon"].ToString());
                }
                dr.Close();
                foreach (DataGridViewRow row in AvancesUser.Rows)
                {
                    if (row.Cells["Buzones"].Value.ToString() == "True")
                    {

                        row.DefaultCellStyle.BackColor = Color.FromArgb(51, 138, 255);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }

                    if (row.Cells["Eliminado"].Value.ToString() == "True")
                    {

                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 98, 98);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }

                }
                foreach (DataGridViewRow row1 in BDLista.Rows)
                {
                    if (row1.Cells["Buzones2"].Value.ToString() == "True")
                    {

                        row1.DefaultCellStyle.BackColor = Color.FromArgb(51, 138, 255);
                        row1.DefaultCellStyle.ForeColor = Color.White;
                    }

                    if (row1.Cells["Eliminado2"].Value.ToString() == "True")
                    {

                        row1.DefaultCellStyle.BackColor = Color.FromArgb(255, 98, 98);
                        row1.DefaultCellStyle.ForeColor = Color.White;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
          
           
        }
        public void usuario(int usuario)
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT  Nombre,Apellido FROM Usuarios WHERE(ID_Usuario = @usuario)", cn);
            cmd.Parameters.AddWithValue("usuario", usuario);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Recaudador.Text = "RECAUDADOR: " + dr["Nombre"].ToString()+" "+dr["Apellido"].ToString();
            }
            dr.Close();

        }
    }
}
