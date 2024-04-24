using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using SAP.Properties;

namespace SAP.Recaudadores.SafvialWeb
{
    public partial class VerOperacion : Form
    {
        public VerOperacion()
        {
            InitializeComponent();
            Nombre.Text = SAP.Recaudadores.SafvialWeb.RecargasAprobadas.nombre;
            monto.Text = SAP.Recaudadores.SafvialWeb.RecargasAprobadas.monto;
            banco.Text = SAP.Recaudadores.SafvialWeb.RecargasAprobadas.banco;
            referencia.Text = SAP.Recaudadores.SafvialWeb.RecargasAprobadas.referencia;
            fecha.Text = SAP.Recaudadores.SafvialWeb.RecargasAprobadas.fecha;
            observacion.Text = SAP.Recaudadores.SafvialWeb.RecargasAprobadas.observacio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            if (SAP.Recaudadores.SafvialWeb.RecargasAprobadas.adjunto != "")
            {
                int id = SAP.Recaudadores.SafvialWeb.RecargasAprobadas.id;

                    var oDocument = await SAP.Recaudadores.SafvialWeb.AprobarRecarga.ObtenerArchivo(id);

                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string folder = path + "/temp/";
                    string fullFilePath = folder + oDocument.Nombre;

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    File.WriteAllBytes(fullFilePath, oDocument.Adjunto);

                    Process.Start(fullFilePath);
            }
            else
            {
                MessageBox.Show("No hay archivo adjunto.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        }
    }
