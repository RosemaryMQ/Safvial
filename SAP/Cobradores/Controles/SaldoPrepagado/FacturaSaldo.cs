using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace SAP.Cobradores.Controles.SaldoPrepagado
{
    public partial class FacturaSaldo : Form
    {
        string RutaArchivo = "";
        int sede = SAP.Inicio.sede;
        public FacturaSaldo()
        {
            InitializeComponent();

        }

        private void FacturaSaldo_Load(object sender, EventArgs e)
        {

            try
            {
                SAP.Cobradores.Controles.SaldoPrepagado.Aviso frm2 = new SAP.Cobradores.Controles.SaldoPrepagado.Aviso();
                frm2.Show();
                Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Saldo", Convert.ToString(SAP.Cobradores.Controles.SaldoPrepagado.SaldoPrepagado.Resultado));
                this.reportViewer1.LocalReport.SetParameters(frm1);
                this.facturaPrepagadoTableAdapter.Fill(this.prepagadoDataSet.FacturaPrepagado, Convert.ToInt32(SAP.Inicio.ID), sede);
                this.reportViewer1.RefreshReport();
                Export(reportViewer1.LocalReport);
                m_currentPageIndex = 0;
                Print();
                this.Close();
            }
            catch
            {
                DialogResult result = MessageBox.Show("Ocurrio un error al intentar imprimir la factura ¿desea reintentarlo?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    SAP.Cobradores.Controles.SaldoPrepagado.Aviso frm2 = new SAP.Cobradores.Controles.SaldoPrepagado.Aviso();
                    frm2.Show();
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Saldo", Convert.ToString(SAP.Cobradores.Controles.SaldoPrepagado.SaldoPrepagado.Resultado));
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    this.facturaPrepagadoTableAdapter.Fill(this.prepagadoDataSet.FacturaPrepagado, Convert.ToInt32(SAP.Inicio.ID), sede);
                    this.reportViewer1.RefreshReport();
                    Export(reportViewer1.LocalReport);
                    m_currentPageIndex = 0;
                    Print();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
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
             " <PageWidth>2in</PageWidth>" +
             " <PageHeight>150in</PageHeight>" +
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
            foreach (var item in m_streams)
            {
                item.Dispose();
            }
            File.Delete(RutaArchivo);
        }
    }
}
