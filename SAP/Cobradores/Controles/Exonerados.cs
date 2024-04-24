using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Cobradores.Controles
{
    public partial class Exonerados : Form
    {
        String TipoVehiculo;
        double aperturo = Convert.ToDouble(SAP.Inicio.Apertura);
        public Exonerados()
        {
            InitializeComponent();
            this.Usuario.Text = SAP.Inicio.User + " " + SAP.Inicio.Apellido;
            this.Turno.Text = SAP.Inicio.Turno;
            this.Canal.Text = SAP.Inicio.Canal;
            this.Apertura.Text = string.Format("{0:n}", aperturo) + " Bs.S";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = (MessageBox.Show("¿Seguro que el vehiculo a ingresar es una AMBULANCIA?", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (resultado == DialogResult.Yes)
                {
                    TipoVehiculo = "Ambulancia";
                    CargarPago(Convert.ToInt32(SAP.Inicio.ID), 10, DateTime.Now.ToString("G"), TipoVehiculo, Convert.ToInt32(SAP.Inicio.Canal));
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = (MessageBox.Show("¿Seguro que el vehiculo a ingresar es POLICIAL?", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (resultado == DialogResult.Yes)
                {
                    TipoVehiculo = "Vehiculo Policial";
                    CargarPago(Convert.ToInt32(SAP.Inicio.ID), 10, DateTime.Now.ToString("G"), TipoVehiculo, Convert.ToInt32(SAP.Inicio.Canal));
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = (MessageBox.Show("¿Seguro que el vehiculo a ingresar es de CARGA ESPECIAL?", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (resultado == DialogResult.Yes)
                {
                    TipoVehiculo = "Carga Especial";
                    CargarPago(Convert.ToInt32(SAP.Inicio.ID), 10, DateTime.Now.ToString("G"), TipoVehiculo, Convert.ToInt32(SAP.Inicio.Canal));
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = (MessageBox.Show("¿Seguro que el vehiculo a ingresar es una GRUA?", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (resultado == DialogResult.Yes)
                {
                    TipoVehiculo = "Grua";
                    CargarPago(Convert.ToInt32(SAP.Inicio.ID), 10, DateTime.Now.ToString("G"), TipoVehiculo, Convert.ToInt32(SAP.Inicio.Canal));
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = (MessageBox.Show("¿Seguro que el vehiculo a ingresar es del CUERPO DE BOMBEROS?", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (resultado == DialogResult.Yes)
                {
                    TipoVehiculo = "Cuerpo de Bomberos";
                    CargarPago(Convert.ToInt32(SAP.Inicio.ID), 10, DateTime.Now.ToString("G"), TipoVehiculo, Convert.ToInt32(SAP.Inicio.Canal));
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CargarPago(int id_user, int id_vehiculo, string fecha, string vehiculo, int canal)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal) Values (@iduser,@idvehiculo,@fecha,'Exonerado',@vehiculo,@canal)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("vehiculo", vehiculo);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.ExecuteReader();
                return;
            }
        }

        private void tableLayoutPanel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.NumPad1)
            {
                try
                {
                    DialogResult resultado = (MessageBox.Show("¿Seguro que el vehiculo a ingresar es una AMBULANCIA?", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (resultado == DialogResult.Yes)
                    {
                        TipoVehiculo = "Ambulancia";
                        CargarPago(Convert.ToInt32(SAP.Inicio.ID), 10, DateTime.Now.ToString("G"), TipoVehiculo, Convert.ToInt32(SAP.Inicio.Canal));
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                try
                {
                    DialogResult resultado = (MessageBox.Show("¿Seguro que el vehiculo a ingresar es POLICIAL?", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (resultado == DialogResult.Yes)
                    {
                        TipoVehiculo = "Vehiculo Policial";
                        CargarPago(Convert.ToInt32(SAP.Inicio.ID), 10, DateTime.Now.ToString("G"), TipoVehiculo, Convert.ToInt32(SAP.Inicio.Canal));
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                try
                {
                    DialogResult resultado = (MessageBox.Show("¿Seguro que el vehiculo a ingresar es de CARGA ESPECIAL?", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (resultado == DialogResult.Yes)
                    {
                        TipoVehiculo = "Carga Especial";
                        CargarPago(Convert.ToInt32(SAP.Inicio.ID), 10, DateTime.Now.ToString("G"), TipoVehiculo, Convert.ToInt32(SAP.Inicio.Canal));
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            if (e.KeyCode == Keys.NumPad4)
            {
                try
                {
                    DialogResult resultado = (MessageBox.Show("¿Seguro que el vehiculo a ingresar es una GRUA?", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (resultado == DialogResult.Yes)
                    {
                        TipoVehiculo = "Grua";
                        CargarPago(Convert.ToInt32(SAP.Inicio.ID), 10, DateTime.Now.ToString("G"), TipoVehiculo, Convert.ToInt32(SAP.Inicio.Canal));
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
                try
                {
                    DialogResult resultado = (MessageBox.Show("¿Seguro que el vehiculo a ingresar es del CUERPO DE BOMBEROS?", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (resultado == DialogResult.Yes)
                    {
                        TipoVehiculo = "Cuerpo de Bomberos";
                        CargarPago(Convert.ToInt32(SAP.Inicio.ID), 10, DateTime.Now.ToString("G"), TipoVehiculo, Convert.ToInt32(SAP.Inicio.Canal));
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error al cargar la informacion a la base de datos intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Conectar();
        }
        private void Conectar()
        {
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                try
                {
                    cn.Open();

                }
                catch
                {
                    cn.Close();
                }
            }
        }
    }
}
