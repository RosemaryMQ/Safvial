using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles
{
    public partial class ListaDeclaraciones : Form
    {
        public static String ID_Usuario1;
        public static String fechainicial;
        public static String fechafinal;
        public static int ID_Usuario;
        public static int nroacta;
        public static string turno;
        public static string nombret;
        public static string nombreusuario;
        public ListaDeclaraciones()
        {
            try
            {
                InitializeComponent();
                this.ActualizarGrid1();
            }
            catch
            {
                this.Close();
            }
            
        }
        public void ActualizarGrid1()
        {

            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT ID_Declaracion, Nombre,Apellido,'V'+Nickname as Cedula, FechaInicial, FechaFinal, Declaraciones.ID_Usuario,Turno.Turno FROM Declaraciones INNER JOIN Usuarios ON Declaraciones.ID_Usuario= Usuarios.ID_Usuario INNER JOIN Turno ON Turno.Fecha = Declaraciones.FechaInicial ORDER BY ID_Declaracion DESC", cn);
            dr = cmd.ExecuteReader();
            Declaraciones.Rows.Clear();
            while (dr.Read())
            {
                if (dr["Turno"].ToString()=="1")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "DIURNO", "VER");
                }
                else if(dr["Turno"].ToString() == "2")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "NOCTURNO", "VER");
                }
                else if (dr["Turno"].ToString() == "3")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "COMPLETO 1", "VER");
                }
                else if (dr["Turno"].ToString() == "4")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "COMPLETO 2", "VER");
                }
                else if (dr["Turno"].ToString() == "5")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "TURNO 1", "VER");
                }
                else if (dr["Turno"].ToString() == "6")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "TURNO 2", "VER");
                }
                else if (dr["Turno"].ToString() == "7")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "TURNO 3", "VER");
                }
                else if (dr["Turno"].ToString() == "8")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "Turno 12h 00:00 - 12:00", "VER");
                }
                else if (dr["Turno"].ToString() == "9")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "Turno 12h 12:00 - 23:59", "VER");
                }
            }
            dr.Close();
        }

        private void Declaraciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Declaraciones.Rows[e.RowIndex];
            ID_Usuario1 = Convert.ToString(row.Cells[5].Value);
            fechainicial = Convert.ToString(row.Cells[3].Value);
            fechafinal = Convert.ToString(row.Cells[4].Value);
            ID_Usuario = Convert.ToInt32(ID_Usuario1);
            nroacta = Convert.ToInt32(row.Cells[0].Value);
            nombreusuario = Convert.ToString(row.Cells[1].Value);
            turno = Convert.ToString(row.Cells[6].Value);
            nombret = Convert.ToString(row.Cells[7].Value);
            SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado frm = new SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado();
            frm.ShowDialog();
            row.Cells[6].Value = SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod;
            row.Cells[7].Value = SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno;
        }
        public void ActualizarGrid2(int parametro)
        {
            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr; 
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT ID_Declaracion, Nombre,Apellido,'V'+Nickname as Cedula, FechaInicial, FechaFinal, Declaraciones.ID_Usuario,Turno.Turno FROM Declaraciones INNER JOIN Usuarios ON Declaraciones.ID_Usuario= Usuarios.ID_Usuario INNER JOIN Turno ON Turno.Fecha = Declaraciones.FechaInicial WHERE ID_Declaracion=@id ORDER BY ID_Declaracion DESC", cn);
            cmd.Parameters.AddWithValue("id", parametro);
            dr = cmd.ExecuteReader();
            Declaraciones.Rows.Clear();
            while (dr.Read())
            {
                if (dr["Turno"].ToString() == "1")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "DIURNO", "VER");
                }
                else if (dr["Turno"].ToString() == "2")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "NOCTURNO", "VER");
                }
                else if (dr["Turno"].ToString() == "3")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "COMPLETO 1", "VER");
                }
                else if (dr["Turno"].ToString() == "4")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "COMPLETO 2", "VER");
                }
                else if (dr["Turno"].ToString() == "5")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "TURNO 1", "VER");
                }
                else if (dr["Turno"].ToString() == "6")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "TURNO 2", "VER");
                }
                else if (dr["Turno"].ToString() == "7")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "TURNO 3", "VER");
                }
                else if (dr["Turno"].ToString() == "8")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "Turno 12h 00:00 - 12:00", "VER");
                }
                else if (dr["Turno"].ToString() == "9")
                {
                    Declaraciones.Rows.Add(dr["ID_Declaracion"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["Cedula"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "Turno 12h 12:00 - 23:59", "VER");
                }
            }
            dr.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (acta.Text!="") { 
            this.ActualizarGrid2(Convert.ToInt32(acta.Text));
            if (Declaraciones.Rows.Count==0)
            {
                MessageBox.Show("Numero de acta no encontrado.","Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActualizarGrid1();
            }
            }else
            {
                MessageBox.Show("el campo no puede esta vacio.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActualizarGrid1();
            }
        }

        private void acta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
