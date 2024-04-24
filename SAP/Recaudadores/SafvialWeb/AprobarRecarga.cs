using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using SAP.Properties;
using System.Threading.Tasks;
using SAP.Recaudadores.SafvialWeb.Model;

namespace SAP.Recaudadores.SafvialWeb
{
    public partial class AprobarRecarga : Form
    {
        Boolean validar = false;
        public AprobarRecarga()
        {
            InitializeComponent();
            Nombre.Text = SAP.Recaudadores.SafvialWeb.Transferencias.nombre;
            monto.Text = SAP.Recaudadores.SafvialWeb.Transferencias.monto;
            banco.Text = SAP.Recaudadores.SafvialWeb.Transferencias.banco;
            label1.Text= SAP.Recaudadores.SafvialWeb.Transferencias.referencia;
            fecha.Text = SAP.Recaudadores.SafvialWeb.Transferencias.fecha;
            observacion.Text = SAP.Recaudadores.SafvialWeb.Transferencias.observacio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AprobarRecarga_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (SAP.Recaudadores.SafvialWeb.Transferencias.adjunto != "")
                {
                        var oDocument = await ObtenerArchivo(SAP.Recaudadores.SafvialWeb.Transferencias.id);

                        string path = AppDomain.CurrentDomain.BaseDirectory;
                        string folder = path + "/temp/";
                        string fullFilePath = folder + oDocument.Nombre;

                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }


                        //if (File.Exists(fullFilePath))
                        //{
                        //    Directory.Delete(fullFilePath);
                        //}


                        File.WriteAllBytes(fullFilePath, oDocument.Adjunto);

                        Process.Start(fullFilePath);
                }
                else
                {
                    MessageBox.Show("No hay archivo adjunto.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se puede abrir el archivo adjunto.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
            DialogResult result = MessageBox.Show("¿Seguro, que desea realizar la recarga?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                   
                    if (OrdenPago.Checked)
                    {
                        this.CargarPago1(SAP.Inicio.ID.Trim(), DateTime.Now.ToString(), "Recarga WEB", Convert.ToDouble(SAP.Recaudadores.SafvialWeb.Transferencias.monto.Trim()), SAP.Inicio.sede, SAP.Recaudadores.SafvialWeb.Transferencias.dni, SAP.Recaudadores.SafvialWeb.Transferencias.referencia);
                        ActualizarOperacion(Motivo.Text, SAP.Recaudadores.SafvialWeb.Transferencias.id);
                        ActivarTarjetas(SAP.Recaudadores.SafvialWeb.Transferencias.dni);
                        MessageBox.Show("Recarga realizada satisfactoriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                    if (!referencia(SAP.Recaudadores.SafvialWeb.Transferencias.referencia))
                    {
                        this.CargarPago1(SAP.Inicio.ID,Convert.ToString(DateTime.Now),"Recarga WEB", Convert.ToDouble(SAP.Recaudadores.SafvialWeb.Transferencias.monto.Trim()),SAP.Inicio.sede,SAP.Recaudadores.SafvialWeb.Transferencias.dni,SAP.Recaudadores.SafvialWeb.Transferencias.referencia);
                        ActualizarOperacion(Motivo.Text, SAP.Recaudadores.SafvialWeb.Transferencias.id);
                        ActivarTarjetas(SAP.Recaudadores.SafvialWeb.Transferencias.dni);
                        MessageBox.Show("Recarga realizada satisfactoriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                     }
                    else
                    {
                        DialogResult result1 = MessageBox.Show("La referencia ya se encuentra registrada en el sistema, ¿Desea ver donde fue recargada?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result1 == DialogResult.Yes)
                        {
                            SAP.Recaudadores.PrepagadoV2.referencia = SAP.Recaudadores.SafvialWeb.Transferencias.referencia;
                            SAP.Recaudadores.Controles.BuscadorReferencia frm2 = new SAP.Recaudadores.Controles.BuscadorReferencia();
                            frm2.Show();
                        }
                        else
                        {
                            this.Close();
                        }  
                    }
            }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error, al intentar cargar el cierre intente nuevamente."+ex.ToString(), "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarOperacion(string motivo, int code)
        {
            string sql = "Update RecargasWeb Set Observacion=@motivo, Condicion='Recargada', FechaSubida=@fecha Where ID_Operacion=@code";
            using (SqlConnection cn = new SqlConnection(Inicio.WEB))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("motivo", motivo);
                cmd.Parameters.AddWithValue("code", code);
                cmd.Parameters.AddWithValue("fecha", DateTime.Now);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CargarPago(string resultado, int cliente)
        {
            string sql = "Update Cliente Set SaldoDisponible=@resultado Where ID_Cliente=@cliente";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("resultado", resultado);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CargarPago1(string id_user, string fecha, string Forma, double monto, int sede, string cliente, string referencia)
        {
            string sql = "Insert into Ventas (ID_Usuario,ID_Cliente,FormaPago,Monto,referencia,Sede,Fecha) Values (@iduser,@cliente,@forma,@monto,@referencia,@sede,@fecha)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.Parameters.AddWithValue("forma", Forma);
                cmd.Parameters.AddWithValue("monto", monto);
                cmd.Parameters.AddWithValue("referencia", referencia);
                cmd.Parameters.AddWithValue("sede", sede);
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.ExecuteReader();
                return;
            }
        }
        private bool referencia(string referencia)
        {
            string sql = "SELECT Ventas.referencia From Ventas Where Ventas.referencia=@referencia";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("referencia", referencia);
                Int64 val = Convert.ToInt64(cmd.ExecuteScalar());
                cn.Close();
                return !(val == 0);
            }
        }
        public static async Task<ArchivoAdjunto> ObtenerArchivo(int id)
        {
            var documento = new ArchivoAdjunto();
            string sql = "select Adjunto, NombreReal from RecargasWEB where ID_Operacion = @id";
            using (SqlConnection cn = new SqlConnection(Inicio.WEB))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("id", id);
                dr = await cmd.ExecuteReaderAsync();
                while (dr.Read())
                {
                    documento.Adjunto = dr["Adjunto"];
                    documento.Nombre = dr["NombreReal"].ToString();
                }
                dr.Close();
                cn.Close();
                return documento;
            }
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private void actualizarweb(string referencia, int codex)
        {
            string sql = "Update RecargasWEB Set referencia=@ref Where ID_Operacion=@referencia";
            using (SqlConnection cn = new SqlConnection(Inicio.WEB))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("referencia", codex);
                cmd.Parameters.AddWithValue("ref", referencia);
                cmd.ExecuteReader();
                return;
            }
        }
        private void ActivarTarjetas(string cliente)
        {
            string sql = "Update TarjetasCliente Set Bloqueada=0 Where ID_Cliente=@cliente";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.ExecuteReader();
                return;
            }
        }
    }
}
