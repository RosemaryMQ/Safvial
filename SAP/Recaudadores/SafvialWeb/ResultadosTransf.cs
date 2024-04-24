using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;

namespace SAP.Recaudadores.SafvialWeb
{
    public partial class ResultadosTransf : Form
    {
        int contador = 0;
        Boolean coincidencia=false;
        public ResultadosTransf()
        {
            InitializeComponent();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dir = openFileDialog1.FileName;
                ActualizarGrid1(dir);
            }
        }
        public void ActualizarGrid1(string ruta)
        {
            SqlConnection cn = new SqlConnection(Inicio.conexion2);
            cn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT RecargasWEB.ID_Operacion,Cliente.Nombre,Cliente.CI,RecargasWEB.Monto,RecargasWEB.Banco,RecargasWEB.Referencia,RecargasWEB.Condicion,RecargasWEB.FechaEmision,RecargasWEB.Observacion,RecargasWEB.DNI,RecargasWEB.NombreReal FROM RecargasWEB INNER JOIN Cliente ON RecargasWEB.DNI = Cliente.ID_Cliente WHERE RecargasWEB.Condicion = 'Pendiente' Order by RecargasWEB.Fecha ASC", cn);
            dr = cmd.ExecuteReader();
            Usuario.Rows.Clear();
            while (dr.Read())
            {
                int referencias = 0;
                string referencia="";
                int resultado;
                referencia = dr["Referencia"].ToString();
                referencias = referencia.Length;
                if (referencias > 9)
                {
                    resultado = referencias - 9;
                    referencia = referencia.Substring(resultado, referencias);
                }
                if (dr["Banco"].ToString() == "Banesco")
                {
                    if (referencias < 9)
                    {
                        referencia = string.Format("{0:000000000}", dr["Referencia"].ToString());
                        this.buscarRef(referencia, ruta);
                        if (coincidencia==true)
                        {
                            coincidencia = false;
                            Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), dr["Referencia"].ToString(), dr["Condicion"].ToString(), Convert.ToDateTime(dr["FechaEmision"].ToString()), "Ver Operacion", "Anular", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
                        }
                    }
                    else
                    {
                        this.buscarRef(referencia, ruta);
                        if (coincidencia == true)
                        {
                            coincidencia = false;
                            Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), dr["Referencia"].ToString(), dr["Condicion"].ToString(), Convert.ToDateTime(dr["FechaEmision"].ToString()), "Ver Operacion", "Anular", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
                        }
                    }
                }
                else
                {
                    if (referencias < 9)
                    {
                        referencia = string.Format("{0:000000000}", ruta);
                        this.buscarRef(referencia, ruta);
                        if (coincidencia == true)
                        {
                            coincidencia = false;
                            Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), dr["Referencia"].ToString(), dr["Condicion"].ToString(), Convert.ToDateTime(dr["FechaEmision"].ToString()), "Ver Operacion", "Anular", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
                        }
                    }
                    else
                    {
                        this.buscarRef(referencia, ruta);
                        if (coincidencia == true)
                        {
                            coincidencia = false;
                            Usuario.Rows.Add(dr["ID_Operacion"].ToString(), dr["Nombre"].ToString(), dr["CI"].ToString(), string.Format("{0:n}", Convert.ToDouble(dr["Monto"].ToString())), dr["Banco"].ToString(), dr["Referencia"].ToString(), dr["Condicion"].ToString(), Convert.ToDateTime(dr["FechaEmision"].ToString()), "Ver Operacion", "Anular", dr["Observacion"].ToString(), dr["DNI"].ToString(), dr["NombreReal"].ToString());
                        }
                    }       
                }
            }
            dr.Close();
            cn.Dispose();
        }
        private void buscarRef(string variable, string ruta)
        {
            if (File.ReadAllText(ruta).Contains(variable))
            {
                coincidencia = true;
            }
        }
    }
}
