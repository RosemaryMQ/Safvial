using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;

namespace SAP.Recaudadores.SafvialWeb
{
    public partial class Transferencias : Form
    {
        public static int id;
        public static string nombre;
        public static string dni;
        public static string monto;
        public static string banco;
        public static string referencia;
        public static string fecha;
        public static string observacio;
        public static string adjunto;
        int contador=0;
        Boolean coincidencia=false;
        public Transferencias()
        {
            InitializeComponent();
            this.ActualizarGrid1();
        }

        private void Transferencias_Load(object sender, EventArgs e)
        {

        }
        public void ActualizarGrid1()
        {
            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT RecargasWEB.ID_Operacion,Cliente.Nombre,Cliente.CI,RecargasWEB.Monto,RecargasWEB.Banco,RecargasWEB.Referencia,RecargasWEB.Condicion,RecargasWEB.FechaEmision,RecargasWEB.Observacion,RecargasWEB.DNI,RecargasWEB.NombreReal FROM RecargasWEB INNER JOIN Cliente ON RecargasWEB.DNI = Cliente.ID_Cliente WHERE RecargasWEB.Condicion = 'Pendiente' Order by RecargasWEB.Fecha ASC", cn);
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), dr["Referencia"].ToString(), dr["Condicion"].ToString(), Convert.ToDateTime(dr["FechaEmision"].ToString()), "Ver Operacion", "Anular", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
            }
            dr.Close();
            cn.Dispose();
        }

        private void Usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "pdf" && e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = Usuario.Rows[e.RowIndex];
            //    id = Convert.ToInt32(row.Cells[0].Value);
            //    using (Model.SafvialWebEntities db = new Model.SafvialWebEntities())
            //    {
            //        var oDocument = db.RecargasWEB.Find(id);

            //        string path = AppDomain.CurrentDomain.BaseDirectory;
            //        string folder = path + "/temp/";
            //        string fullFilePath = folder + oDocument.NombreReal;

            //        if (!Directory.Exists(folder))
            //        {
            //            Directory.CreateDirectory(folder);
            //        }
                       

            //        if (!File.Exists(fullFilePath))
            //        {
            //            Directory.Delete(fullFilePath);
            //        }
                        

            //        File.WriteAllBytes(fullFilePath, oDocument.Adjunto);

            //        Process.Start(fullFilePath);

            //    }
            //}
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "Anulacio" && e.RowIndex >= 0)
            {
                DataGridViewRow row = Usuario.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells[0].Value);
                SAP.Recaudadores.SafvialWeb.AnularRecarga frm = new SAP.Recaudadores.SafvialWeb.AnularRecarga();
                frm.ShowDialog();
                this.ActualizarGrid1();
            }
            if (e.ColumnIndex >= 0 && this.Usuario.Columns[e.ColumnIndex].Name == "Aprobar" && e.RowIndex >= 0)
            {
                adjunto = "";
                DataGridViewRow row = Usuario.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells[0].Value);
                nombre = Convert.ToString(row.Cells[1].Value);
                dni = Convert.ToString(row.Cells[11].Value);
                monto = Convert.ToString(row.Cells[3].Value);
                banco = Convert.ToString(row.Cells[4].Value);
                referencia = Convert.ToString(row.Cells[5].Value);
                fecha = Convert.ToString(row.Cells[7].Value);
                observacio = Convert.ToString(row.Cells[10].Value);
                adjunto = Convert.ToString(row.Cells[12].Value);
                SAP.Recaudadores.SafvialWeb.AprobarRecarga frm = new SAP.Recaudadores.SafvialWeb.AprobarRecarga();
                frm.ShowDialog();
                this.ActualizarGrid1();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SAP.Recaudadores.SafvialWeb.ReporteOperaciones frm = new SAP.Recaudadores.SafvialWeb.ReporteOperaciones();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActualizarGrid1();
            }
            catch
            {
                MessageBox.Show("Ocurrio un error, al intentar cargar el cierre intente nuevamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dir = openFileDialog1.FileName;
                this.Verificar(dir);
            }
        }
        int referencias;
        string referenciar;
        string referenciar2 = "";
        private void buscarRef(string variable,string ruta)
        {
            if (File.ReadAllText(ruta).Contains(variable))
            {
                coincidencia = true;
            }
        }
        public void Verificar(string ruta)
        {
            contador = 0;
            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT RecargasWEB.ID_Operacion,Cliente.Nombre,Cliente.CI,RecargasWEB.Monto,RecargasWEB.Banco,RecargasWEB.Referencia,RecargasWEB.Condicion,RecargasWEB.FechaEmision,RecargasWEB.Observacion,RecargasWEB.DNI,RecargasWEB.NombreReal FROM RecargasWEB INNER JOIN Cliente ON RecargasWEB.DNI = Cliente.ID_Cliente WHERE RecargasWEB.Condicion = 'Pendiente' Order by RecargasWEB.Fecha ASC", cn);
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                referenciar = dr["Referencia"].ToString();
                referencias = referenciar.Length;
                if (dr["Banco"].ToString() == "B.O.D")
                {
                    if (referencias < 9)
                    {

                        this.buscarRef(referenciar.PadLeft(9, '0')+"TRANSF. VIA INTERNET", ruta);
                        if (coincidencia == true)
                        {
                            coincidencia = false;
                            Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), referenciar.PadLeft(9, '0'), dr["Condicion"].ToString(), Convert.ToDateTime(dr["FechaEmision"].ToString()), "Ver Operacion", "Anular", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
                        }
                    }
                    else
                    {
                        referenciar2 = referenciar.Substring(0, 8);
                        this.buscarRef(referenciar2 +"TRANSF. VIA INTERNET", ruta);
                        if (coincidencia == true)
                        {
                            coincidencia = false;
                            Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), referenciar2, dr["Condicion"].ToString(), Convert.ToDateTime(dr["FechaEmision"].ToString()), "Ver Operacion", "Anular", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
                        }
                    }
                }
                else
                {
                    if (referencias < 9)
                    {
                        this.buscarRef(referenciar.PadLeft(9, '0')+ "CR CCE TRAN:"+ dr["Banco"].ToString(), ruta);
                        if (coincidencia == true)
                        {
                            coincidencia = false;
                            Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), referenciar.PadLeft(9, '0'), dr["Condicion"].ToString(), Convert.ToDateTime(dr["FechaEmision"].ToString()), "Ver Operacion", "Anular", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
                        }
                    }
                    else if(referencias > 9)      
                    {
                        referenciar2 = referenciar.Substring(0, 8);
                        this.buscarRef(referenciar2+"CR CCE TRAN:"+dr["Banco"].ToString().PadRight(17, ' ').Substring(17), ruta);
                        if (coincidencia == true)
                        {
                            coincidencia = false;
                            Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), referenciar2, dr["Condicion"].ToString(), Convert.ToDateTime(dr["FechaEmision"].ToString()), "Ver Operacion", "Anular", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
                        }
                        else
                        {
                            referenciar2 = referenciar.Substring(referencias-9);
                            this.buscarRef(referenciar2 + "CR CCE TRAN:" + dr["Banco"].ToString().PadRight(17, ' ').Substring(0,17), ruta);
                            if (coincidencia == true)
                            {
                                coincidencia = false;
                                Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), referenciar2, dr["Condicion"].ToString(), Convert.ToDateTime(dr["FechaEmision"].ToString()), "Ver Operacion", "Anular", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
                            }
                        }
                    }
                }
            }
            dr.Close();
            cn.Dispose();
        }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
