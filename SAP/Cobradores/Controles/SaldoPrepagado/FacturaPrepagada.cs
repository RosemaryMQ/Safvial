using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using SAP.Properties;
using System.IO.Ports;
using SAP.Common;
using System.Threading.Tasks;

namespace SAP.Cobradores.Controles.SaldoPrepagado
{
    public partial class FacturaPrepagada : Form
    {
        string RutaArchivo = "";
        public FacturaPrepagada()
        {
            InitializeComponent();
        }

        private async void FacturaPrepagada_Load(object sender, EventArgs e)
        {
            if (SAP.Cobradores.RecaudacionV2.com != "0")
            {
                try
                {
                    Arduino1.PortName = SAP.Cobradores.RecaudacionV2.com;
                    Arduino1.DtrEnable = false;
                    Arduino1.Open();
                    Arduino1.Write("@" + SAP.Cobradores.RecaudacionV2.vehiculo + "0000");
                    Arduino1.Close();
                }
                catch(Exception ex)
                {
                    var libreria = new LibreriaComun();
                    libreria.ErroLog(ex.Message);
                }
            }
            try
            {
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                Microsoft.Reporting.WinForms.ReportParameter frm7 = new Microsoft.Reporting.WinForms.ReportParameter("Cabezera", SAP.Inicio.Membrete);
                this.reportViewer1.LocalReport.SetParameters(frm7);
                if (SAP.Cobradores.Controles.V2.Prepagado.Exonerado == "Si")
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm4 = new Microsoft.Reporting.WinForms.ReportParameter("Saldo", "Disponible");
                    this.reportViewer1.LocalReport.SetParameters(frm4);
                }
                else
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm4 = new Microsoft.Reporting.WinForms.ReportParameter("Saldo", string.Format("{0:n}", SAP.Cobradores.Controles.V2.Prepagado.total) + " Bs.");
                    this.reportViewer1.LocalReport.SetParameters(frm4);
                }
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString("G"));
                this.reportViewer1.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Tarifa", string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Controles.V2.FormaPago.Costo)) + " Bs.");
                this.reportViewer1.LocalReport.SetParameters(frm1);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("Vehiculo", SAP.Cobradores.RecaudacionV2.TipoVehiculo);
                this.reportViewer1.LocalReport.SetParameters(frm3);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Canal", SAP.Inicio.Canal);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm8 = new Microsoft.Reporting.WinForms.ReportParameter("Logo", "file:\\" + @"" + (string)Settings.Default["Logo"]);
                this.reportViewer1.LocalReport.SetParameters(frm8);
                this.facturaPrepagadoTableAdapter.Fill(this.prepagadoDataSet.FacturaPrepagado, Convert.ToInt32(SAP.Inicio.ID), SAP.Inicio.sede);
                this.reportViewer1.RefreshReport();
                await Export(reportViewer1.LocalReport);
                m_currentPageIndex = 0;
                Settings.Default["Factura"] = (int)Settings.Default["Factura"] + 1;
                Settings.Default.Save();
                await Print();
                SAP.Cobradores.RecaudacionV2.TipoTabulacion = 2;
                this.Close();
            }
            catch (Exception ex)
            {
                var libreria = new LibreriaComun();
                libreria.ErroLog(ex.Message);
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                Microsoft.Reporting.WinForms.ReportParameter frm7 = new Microsoft.Reporting.WinForms.ReportParameter("Cabezera", SAP.Inicio.Membrete);
                this.reportViewer1.LocalReport.SetParameters(frm7);
                if (SAP.Cobradores.Controles.V2.Prepagado.Exonerado == "Si")
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm4 = new Microsoft.Reporting.WinForms.ReportParameter("Saldo", "Disponible");
                    this.reportViewer1.LocalReport.SetParameters(frm4);
                }
                else
                {
                    Microsoft.Reporting.WinForms.ReportParameter frm4 = new Microsoft.Reporting.WinForms.ReportParameter("Saldo", string.Format("{0:n}", SAP.Cobradores.Controles.V2.Prepagado.total) + " Bs.");
                    this.reportViewer1.LocalReport.SetParameters(frm4);
                }
                Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString("G"));
                this.reportViewer1.LocalReport.SetParameters(frm);
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Tarifa", string.Format("{0:n}", Convert.ToDouble(SAP.Cobradores.Controles.V2.FormaPago.Costo)) + " Bs.");
                this.reportViewer1.LocalReport.SetParameters(frm1);
                Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("Vehiculo", SAP.Cobradores.RecaudacionV2.TipoVehiculo);
                this.reportViewer1.LocalReport.SetParameters(frm3);
                Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Canal", SAP.Inicio.Canal);
                this.reportViewer1.LocalReport.SetParameters(frm2);
                Microsoft.Reporting.WinForms.ReportParameter frm8 = new Microsoft.Reporting.WinForms.ReportParameter("Logo", "file:\\" + @"" + (string)Settings.Default["Logo"]);
                this.reportViewer1.LocalReport.SetParameters(frm8);
                this.facturaPrepagadoTableAdapter.Fill(this.prepagadoDataSet.FacturaPrepagado, Convert.ToInt32(SAP.Inicio.ID), SAP.Inicio.sede);
                this.reportViewer1.RefreshReport();
                await Export(reportViewer1.LocalReport);
                m_currentPageIndex = 0;
                Settings.Default["Factura"] = (int)Settings.Default["Factura"] + 1;
                Settings.Default.Save();
                await Print();
                SAP.Cobradores.RecaudacionV2.TipoTabulacion = 2;
                this.Close();
            }
        }
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            var fecha = DateTime.Now.ToString("ddmmyyyyHHmmssffffff");
            Stream stream = new FileStream(@"..\..\" + name + fecha + "." + fileNameExtension, FileMode.OpenOrCreate);
            RutaArchivo = @"..\..\" + name + fecha + "." + fileNameExtension;
            m_streams.Add(stream);
            return stream;
        }
        private async Task Export(LocalReport report)
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
            return;
        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private async Task Print()
        {
            const string printerName = "POS58";
            if (m_streams == null || m_streams.Count == 0)
                return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = printerName;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.PrintController = new StandardPrintController();
            printDoc.Print();
            return;
        }
    }
}
