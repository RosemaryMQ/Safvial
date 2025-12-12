using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles
{
    public partial class Cierre : Form
    {
        public Cierre()
        {

            InitializeComponent();
            try
            {
                this.Consulta();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usuario.Text != "")
            {
                SAP.Tesoreria.TesoreriaV2.id = usuario.Text.Substring(0, 6);
                BuscaTurnoEnCombo();
                buscardor(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.id), Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno));
                buscarCataporte(Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.id), Convert.ToInt32(SAP.Tesoreria.TesoreriaV2.turno));
                SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvanceUser frm = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvanceUser();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos un usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buscardor(int usuario, int turno)
        {
            //rm-->string sql = "Select Turno.ID_Usuario,Usuarios.Nombre,Usuarios.Apellido,Turno.Turno,Turno.Fecha from Turno inner join Usuarios on Turno.ID_Usuario = Usuarios.ID_Usuario WHERE Turno.ID_Usuario=@usuario AND Turno.Finalizado=0 ORDER BY Turno.Fecha DESC";
            string sql = "Select Turno.ID_Usuario,Usuarios.Nombre,Usuarios.Apellido,Turno.Turno,Turno.Fecha from Turno inner join Usuarios on Turno.ID_Usuario = Usuarios.ID_Usuario " +
                "WHERE Turno.ID_Usuario=@usuario AND Turno.Turno=@turno AND Turno.Finalizado=0";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("turno", turno);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SAP.Tesoreria.TesoreriaV2.Identificador = dr["ID_Usuario"].ToString();
                    SAP.Tesoreria.TesoreriaV2.Apertura = dr["Fecha"].ToString();
                    SAP.Tesoreria.TesoreriaV2.Nombre = dr["Nombre"].ToString() + " " + dr["Apellido"].ToString();
                    SAP.Tesoreria.TesoreriaV2.fechaAperturaTurno = (DateTime)dr["Fecha"];
                }
                dr.Close();
                return;
            }
        }
        private void buscarCataporte(int usuario, int turno)
        {
            //rm-->string sql = "SELECT ID_Declaracion FROM Declaraciones WHERE (ID_Usuario = @usuario) AND (Responsable = 0)";
            //string sql = "SELECT ID_Declaracion FROM Declaraciones WHERE (IDTurnoUsuario = @usuario) AND (Responsable = 0)";

            string sql = "SELECT ID_Declaracion FROM Declaraciones A INNER JOIN Turno B ON CONVERT(DATETIME2(0), A.FechaInicial) = CONVERT(DATETIME2(0), B.Fecha) and A.ID_Usuario = B.ID_Usuario " +
                "WHERE (A.ID_Usuario=@usuario) AND (B.Turno=@turno) AND (Responsable=0)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("turno", turno);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta = Convert.ToInt32(dr["ID_Declaracion"]);
                }
                dr.Close();
                return;
            }
        }
        private void Consulta()
        {
            string sql = "Select Distinct Turno.ID_Usuario,Usuarios.Nombre,Usuarios.Apellido,Turno.Turno from Turno inner join Usuarios on Turno.ID_Usuario = Usuarios.ID_Usuario WHERE Turno.Finalizado=0";

            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario.Items.Add(dr["ID_Usuario"].ToString() + "      " + dr["Nombre"].ToString() + " " + dr["Apellido"].ToString() + "   (Turno:" + dr["Turno"].ToString() + " )");

                }
                dr.Close();
                return;
            }
        }

        private void BuscaTurnoEnCombo()
        {
            string textoCompletoSeleccionado = usuario.SelectedItem.ToString();
            string inicioBusqueda = "(Turno:"; // La parte que inicia el segmento
            string finBusqueda = ")";       // La parte que termina el segmento

            if (textoCompletoSeleccionado.Contains(inicioBusqueda))
            {
                // 1. Encontrar el índice donde empieza el número del turno
                int startIndex = textoCompletoSeleccionado.IndexOf(inicioBusqueda) + inicioBusqueda.Length;

                // 2. Encontrar el índice donde termina el segmento (el paréntesis de cierre)
                int endIndex = textoCompletoSeleccionado.IndexOf(finBusqueda, startIndex);

                // 3. Extraer la subcadena que contiene solo el número y quizás un espacio.
                string valorTurnoConEspacio = textoCompletoSeleccionado.Substring(startIndex, endIndex - startIndex);

                // 4. Limpiar el espacio en blanco y convertir a entero
                int idTurno = int.Parse(valorTurnoConEspacio.Trim());
                SAP.Tesoreria.TesoreriaV2.turno = valorTurnoConEspacio.Trim();


            }

        }
        /*
        private void ConsultaUsuario()
        {
            string sql = "Select Nombre,Apellido from Usuarios Where ID_Usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario.Items.Add(dr["ID_Usuario"].ToString() + "      " + dr["Nombre"].ToString() + " " + dr["Apellido"].ToString());
                }
                dr.Close();
                return;
            }
        }
        */
        private void Cierre_Load(object sender, EventArgs e)
        {

        }

        private void usuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
