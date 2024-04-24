using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Recaudadores.Controles
{
    public partial class ControlUsuarios : Form
    {
        public static String ID_Usuario1;
        public static int ID_Usuario;
        public ControlUsuarios()
        {
            InitializeComponent();
            this.ActualizarGrid1();
        }
        public void ActualizarGrid1()
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select Usuarios.ID_Usuario,Usuarios.Nombre,Usuarios.Apellido,Usuarios.Nickname,Usuarios.Contrasena,Usuarios.Perfil,Usuarios.Turno From Usuarios where ID_Peaje=@peaje AND Perfil='Cobrador' or Perfil='COBRADOR'", cn);
            cmd.Parameters.AddWithValue("peaje", Convert.ToInt32(SAP.Inicio.peaje));
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                Usuario.Rows.Add(dr["ID_Usuario"].ToString(), dr["Nombre"].ToString(), dr["Apellido"].ToString(), dr["Nickname"].ToString(), dr["Contrasena"].ToString(), dr["Perfil"].ToString(), dr["Turno"].ToString(), "Editar");
            }
            dr.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.NuevoUsuario frm = new SAP.Recaudadores.Controles.NuevoUsuario();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Usuario.Rows[e.RowIndex];
            ID_Usuario1 = Convert.ToString(row.Cells[0].Value);
            ID_Usuario = Convert.ToInt32(ID_Usuario1);
            SAP.Recaudadores.Controles.EditarUsuario frm = new SAP.Recaudadores.Controles.EditarUsuario();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.Controles.Cargar.CargaTarjeta frm = new SAP.Recaudadores.Controles.Cargar.CargaTarjeta();
            frm.Show();
        }
    }
}
