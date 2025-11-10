using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Cobradores.Controles.V2
{
    public partial class FormaPago : Form
    {
        public static string codigovehiculo;
        public static string Costo;
        public static string Forma;
        public FormaPago()
        {
            InitializeComponent();
            Tipo.Text = SAP.Cobradores.RecaudacionV2.TipoVehiculo;
            if (Tipo.Text == "Liviano")
            {
                Costo = SAP.Cobradores.RecaudacionV2.Liviano;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.RecaudacionV2.Liviano)) + " Bs.S";
                codigovehiculo = SAP.Cobradores.RecaudacionV2.IDLiviano;

            }
            if (Tipo.Text == "Microbus")
            {
                Costo = SAP.Cobradores.RecaudacionV2.Microbus;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.RecaudacionV2.Microbus)) + " Bs.S";
                codigovehiculo = SAP.Cobradores.RecaudacionV2.IDMicrobus;
            }
            if (Tipo.Text == "Autobus")
            {
                Costo = SAP.Cobradores.RecaudacionV2.Autobus;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.RecaudacionV2.Autobus)) + " Bs.S";
                codigovehiculo = SAP.Cobradores.RecaudacionV2.IDAutobus;
            }
            if (Tipo.Text == "Carga Liviana")
            {
                Costo = SAP.Cobradores.RecaudacionV2.CargaLiviana;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.RecaudacionV2.CargaLiviana)) + " Bs.S";
                codigovehiculo = SAP.Cobradores.RecaudacionV2.IDCargaliviana;
            }
            if (Tipo.Text == "2 Ejes")
            {
                Costo = SAP.Cobradores.RecaudacionV2.ejes2;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.RecaudacionV2.ejes2)) + " Bs.S";
                codigovehiculo = SAP.Cobradores.RecaudacionV2.IDejes2;
            }
            if (Tipo.Text == "3 Ejes")
            {
                Costo = SAP.Cobradores.RecaudacionV2.ejes3;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.RecaudacionV2.ejes3)) + " Bs.S";
                codigovehiculo = SAP.Cobradores.RecaudacionV2.IDejes3;
            }
            if (Tipo.Text == "4 Ejes")
            {
                Costo = SAP.Cobradores.RecaudacionV2.ejes4;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.RecaudacionV2.ejes4)) + " Bs.S";
                codigovehiculo = SAP.Cobradores.RecaudacionV2.IDejes4;
            }
            if (Tipo.Text == "5 Ejes")
            {
                Costo = SAP.Cobradores.RecaudacionV2.ejes5;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.RecaudacionV2.ejes5)) + " Bs.S";
                codigovehiculo = SAP.Cobradores.RecaudacionV2.IDejes5;
            }
            if (Tipo.Text == "6 Ejes o Mas")
            {
                Costo = SAP.Cobradores.RecaudacionV2.ejes6;
                Tarifa.Text = string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.RecaudacionV2.ejes6)) + " Bs.S";
                codigovehiculo = SAP.Cobradores.RecaudacionV2.IDejes6;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirme operacion, Pago incompleto", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {               
                    SAP.Inicio.acceso = 24;
                    SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
                    frm.ShowDialog();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CargarPago2(int id_user, int id_vehiculo, string fecha, int canal, string modo,int turno)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal,Turno) Values (@iduser,@idvehiculo,@fecha,@modo,'NULL',@canal,@turno)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("modo", modo);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.ExecuteReader();
                cn.Close();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forma = "Efectivo";
            SAP.Cobradores.Controles.V2.Efectivo frm = new SAP.Cobradores.Controles.V2.Efectivo();
            frm.ShowDialog();
            this.Close();
        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0)
            {
                SAP.Inicio.acceso = 21;
                SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
                frm.ShowDialog();
                this.Close();
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                Forma = "Efectivo";
                SAP.Cobradores.Controles.V2.Efectivo frm = new SAP.Cobradores.Controles.V2.Efectivo();
                frm.ShowDialog();
                this.Close();
               
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                Forma = "Punto de Venta";
                SAP.Cobradores.Controles.V2.PDV frm = new SAP.Cobradores.Controles.V2.PDV();
                frm.ShowDialog();
                this.Close();

            }
            if (e.KeyCode == Keys.NumPad3)
            {
                SAP.Cobradores.Controles.V2.Prepagado frm = new SAP.Cobradores.Controles.V2.Prepagado();
                frm.ShowDialog();
                this.Close();
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                try
                {
                    DialogResult resultado = MessageBox.Show("Confirme operacion, Pago incompleto", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        SAP.Inicio.acceso = 24;
                        SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
                        frm.ShowDialog();
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                Forma = "Transferencia";
                SAP.Cobradores.Controles.V2.Transferencia frm = new SAP.Cobradores.Controles.V2.Transferencia();
                frm.ShowDialog();
                this.Close();
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                Forma = "Biopago";
                SAP.Cobradores.Controles.V2.Biopago frm = new SAP.Cobradores.Controles.V2.Biopago();
                frm.ShowDialog();
                this.Close();

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forma = "Punto de Venta";
            SAP.Cobradores.Controles.V2.PDV frm = new SAP.Cobradores.Controles.V2.PDV();
            frm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SAP.Cobradores.Controles.V2.Prepagado frm = new SAP.Cobradores.Controles.V2.Prepagado();
            frm.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Forma = "Transferencia";
            SAP.Cobradores.Controles.V2.Transferencia frm = new SAP.Cobradores.Controles.V2.Transferencia();
            frm.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SAP.Inicio.acceso = 21;
            SAP.Common.WinForms.Autorizacion frm = new SAP.Common.WinForms.Autorizacion();
            frm.ShowDialog();
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Forma = "Especial";
            SAP.Cobradores.Controles.V2.Especial frm = new SAP.Cobradores.Controles.V2.Especial();
            this.Close();
            frm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Forma = "Biopago";
            SAP.Cobradores.Controles.V2.Biopago frm = new SAP.Cobradores.Controles.V2.Biopago();
            frm.ShowDialog();
            this.Close();

        }
    }
}
