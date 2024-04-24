using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAP.Tesoreria.Controles.Auditoria
{
    public partial class ListaDeclaracionesV1: Form
    {
        public ListaDeclaracionesV1()
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
            SqlCommand cmd = new SqlCommand("SELECT Recaudadore.ID,Usuarios.Nombre,Usuarios.Apellido,Declaraciones.FechaInicial, Declaraciones.FechaFinal, Recaudadore.ID_Usuario,Recaudadore.Turno FROM Recaudadore INNER JOIN Declaraciones ON Recaudadore.Fecha = Declaraciones.FechaInicial INNER JOIN Usuarios ON Usuarios.ID_Usuario = Recaudadore.ID_Usuario ORDER BY Recaudadore.ID DESC", cn);
            dr = cmd.ExecuteReader();
            Declaraciones.Rows.Clear();
            while (dr.Read())
            {
                if (dr["Turno"].ToString() == "1")
                {
                    Declaraciones.Rows.Add(dr["ID"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "DIURNO", "VER");
                }
                else
                {
                    Declaraciones.Rows.Add(dr["ID"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "NOCTURNO", "VER");
                }
            }
            dr.Close();
        }

        private void Declaraciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Declaraciones.Rows[e.RowIndex];
            SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1 = Convert.ToString(row.Cells[4].Value);
            SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial = Convert.ToString(row.Cells[2].Value);
            SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal = Convert.ToString(row.Cells[3].Value);
            SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario = Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1);
            SAP.Tesoreria.Controles.ListaDeclaraciones.nroacta = Convert.ToInt32(row.Cells[0].Value);
            SAP.Tesoreria.Controles.ListaDeclaraciones.nombreusuario = Convert.ToString(row.Cells[1].Value);
            SAP.Tesoreria.Controles.ListaDeclaraciones.turno = Convert.ToString(row.Cells[5].Value);
            SAP.Tesoreria.Controles.ListaDeclaraciones.nombret = Convert.ToString(row.Cells[6].Value);
            SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado frm = new SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado();
            frm.ShowDialog();
        }
        public void ActualizarGrid2(int parametro)
        {
            SqlConnection cn = new SqlConnection(Inicio.conexion);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT Recaudadore.ID,Usuarios.Nombre,Usuarios.Apellido,Declaraciones.FechaInicial, Declaraciones.FechaFinal, Recaudadore.ID_Usuario,Recaudadore.Turno FROM Recaudadore INNER JOIN Declaraciones ON Recaudadore.Fecha = Declaraciones.FechaInicial INNER JOIN Usuarios ON Usuarios.ID_Usuario = Recaudadore.ID_Usuario WHERE Recaudadore.ID=@id ORDER BY Recaudadore.ID DESC", cn);
            cmd.Parameters.AddWithValue("id", parametro);
            dr = cmd.ExecuteReader();
            Declaraciones.Rows.Clear();
            while (dr.Read())
            {
                if (dr["Turno"].ToString() == "1")
                {
                    Declaraciones.Rows.Add(dr["ID"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "DIURNO", "VER");
                }
                else
                {
                    Declaraciones.Rows.Add(dr["ID"].ToString(), dr["Nombre"].ToString() + " " + dr["Apellido"].ToString(), dr["FechaInicial"].ToString(), dr["FechaFinal"].ToString(), dr["ID_Usuario"].ToString(), dr["Turno"].ToString(), "NOCTURNO", "VER");
                }
            }
            dr.Close();
        }

        private void acta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)13))
            {
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ActualizarGrid2(Convert.ToInt32(acta.Text));
            if (Declaraciones.Rows.Count == 0)
            {
                MessageBox.Show("Numero de acta no encontrado.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActualizarGrid1();
            }
        }
    }
}
