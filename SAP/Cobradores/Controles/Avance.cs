using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using SAP.Properties;

namespace SAP.Cobradores.Controles
{
    public partial class Avance : Form
    {
        string RutaArchivo = "";
        string fecha;
        int sede = SAP.Inicio.sede;
        String canal = SAP.Inicio.Canal;
        DateTime system;
        public Avance()
        {
            InitializeComponent();
            try
            {
                FechaSistema();
                ConsultaEspecial(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal));
            }
            catch
            {

            }
         
        }
        private void ConsultaEspecial(int usuario,int canal)
        {
            string sql = "SELECT   TOP (1) Fecha FROM  Avances WHERE (ID_Usuario = @usuario) ORDER BY Fecha DESC";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fecha = dr["Fecha"].ToString();
                    if (fecha=="")
                    {
                        this.ConsultaEspecial1(usuario,canal);
                    }
                }
                dr.Close();
                return;
            }
        }
        private void FechaSistema()
        {
            string sql = "SELECT SYSDATETIME() as Fecha;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    system = Convert.ToDateTime(dr["Fecha"]);
                }
                dr.Close();
                return;
            }
        }
        private void ConsultaEspecial1(int usuario,int canal)
        {
            string sql = "Select TOP (1) Fecha From Recaudadore Where ID_Usuario=@usuario AND Canal=@canal order by Fecha DESC";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fecha = dr["Fecha"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            var fecha = DateTime.Now.ToString("ddmmyyyyHHmmssfff");
            Stream stream = new FileStream(@"..\..\" + name + fecha + "." + fileNameExtension, FileMode.Create);
            RutaArchivo = @"..\..\" + name + fecha + "." + fileNameExtension;
            m_streams.Add(stream);
            return stream;
        }
        private void Export(LocalReport report)
        {
            string deviceInfo =
             "<DeviceInfo>" +
             " <OutputFormat>EMF</OutputFormat>" +
            " <PageWidth>1.8in</PageWidth>" +
             " <PageHeight>148in</PageHeight>" +
             " <MarginTop>0in</MarginTop>" +
             " <MarginLeft>0in</MarginLeft>" +
             " <MarginRight>0in</MarginRight>" +
             " <MarginBottom>0in</MarginBottom>" +
             "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
            { stream.Position = 0; }
        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            const string printerName = "POS58";
            if (m_streams == null || m_streams.Count == 0)
                return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                MessageBox.Show("Print Error");
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.PrintController = new StandardPrintController();
            printDoc.Print();
            File.Delete(printDoc.DocumentName);
            m_streams = null;
        }

        private void Avance_Load(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Canal", Convert.ToString((int)Settings.Default["Canal"]));
                this.reportViewer1.LocalReport.SetParameters(frm);

                this.efectivoCierreTableAdapter.Efectivo(this.sAPDataSet.EfectivoCierre, Convert.ToInt32(SAP.Inicio.ID),Convert.ToDateTime(fecha), system, "Efectivo");
                this.pDVCierreTableAdapter.PDV(this.sAPDataSet.PDVCierre, Convert.ToInt32(SAP.Inicio.ID), Convert.ToDateTime(fecha), system, "Punto de Venta");
                //this.ticketCierreTableAdapter.Tickets(this.sAPDataSet.TicketCierre, Convert.ToInt32(SAP.Inicio.ID), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma4);
                this.noPagoCierreTableAdapter.NoPago(this.sAPDataSet.NoPagoCierre, Convert.ToInt32(SAP.Inicio.ID), Convert.ToDateTime(fecha), system, "Pago Incompleto");
                //this.exoneradosCierreTableAdapter.Exonerados(this.sAPDataSet.ExoneradosCierre, Convert.ToInt32(SAP.Inicio.ID), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Forma6);
                this.resumenTransfTableAdapter.Fill(this.sAPDataSet2.ResumenTransf, Convert.ToInt32(SAP.Inicio.ID), Convert.ToDateTime(fecha), system, "Transferencia");
                this.resumenBiopagoTableAdapter.Fill(this.sAPDataSet2.ResumenBiopago, Convert.ToInt32(SAP.Inicio.ID), Convert.ToDateTime(fecha), system, "Biopago");
                this.tarjetaExpressReporte11TableAdapter.Fill(this.tarjetaExpressDataSet.TarjetaExpressReporte11, Convert.ToDateTime(fecha), system,SAP.Inicio.sede, Convert.ToInt32(SAP.Inicio.ID));
                this.usuariosTableAdapter.Usuario(this.sAPDataSet2.Usuarios, Convert.ToInt32(SAP.Inicio.ID));


                // --------------------------------------------------------------------------------
                // 3. AGREGAR ESTO: ASIGNACIÓN EXPLÍCITA DE FUENTES DE DATOS
                // (Esto conecta lo que llenaste arriba con los nombres de la imagen que subiste)
                // --------------------------------------------------------------------------------

                // Limpiamos cualquier basura anterior
                this.reportViewer1.LocalReport.DataSources.Clear();

                // Agregamos UNO POR UNO coincidiendo con los nombres de tu imagen:

                // Nombre "Efectivo" en la imagen -> DataTable EfectivoCierre
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Efectivo", (System.Data.DataTable)this.sAPDataSet.EfectivoCierre));

                // Nombre "PDV" en la imagen
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("PDV", (System.Data.DataTable)this.sAPDataSet.PDVCierre));

                // Nombre "Incompleto" en la imagen -> DataTable NoPagoCierre
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Incompleto", (System.Data.DataTable)this.sAPDataSet.NoPagoCierre));

                // Nombre "Usuario" en la imagen
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Usuario", (System.Data.DataTable)this.sAPDataSet2.Usuarios));

                // OJO: En tu imagen dice "Transfencia" (sin la 'r' después de la f). 
                // Debe ser idéntico a la imagen o fallará.
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Transfencia", (System.Data.DataTable)this.sAPDataSet2.ResumenTransf));

                // Nombre "TarjetasVendidas" en la imagen
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TarjetasVendidas", (System.Data.DataTable)this.tarjetaExpressDataSet.TarjetaExpressReporte11));

                // Nombre "Biopago" en la imagen (El nuevo)
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Biopago", (System.Data.DataTable)this.sAPDataSet2.ResumenBiopago));

                // --------------------------------------------------------------------------------



                this.reportViewer1.RefreshReport();
                Export(reportViewer1.LocalReport);
                m_currentPageIndex = 0;
                Print();
                this.avances(Convert.ToInt32(Inicio.ID), Convert.ToInt32(Inicio.Canal));
                this.Close();
            }
            catch
            {
                MessageBox.Show("¡Error al generar el reporte!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
                throw;
            }
        }
        private void avances(int usuario, int canal)
        {
            string sql = "Insert into Avances (ID_Usuario,Canal,Fecha) Values (@usuario,@canal,SYSDATETIME())";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CargarOperacion(int usuario, int canal, string Tarjeta, string operacion, int vehiculo)
        {
            string sql = "Insert into BarreraControl (ID_Usuario,Canal,Tarjeta,Fecha,Operacion,ID_Vehiculo) Values (@iduser,@canal,@tarjeta,SYSDATETIME(),@operacion,@vehiculo)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("tarjeta", Tarjeta);
                cmd.Parameters.AddWithValue("operacion", operacion);
                cmd.Parameters.AddWithValue("vehiculo", vehiculo);
                cmd.ExecuteReader();
                return;
            }
        }



    }
}
