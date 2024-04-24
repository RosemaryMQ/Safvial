namespace SAP.Cobradores.Controles.SaldoPrepagado
{
    partial class FacturaPorCobrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.facturaV2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAPDataSet2 = new SAP.SAPDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.facturaV2TableAdapter = new SAP.SAPDataSet2TableAdapters.FacturaV2TableAdapter();
            this.Arduino12 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.facturaV2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // facturaV2BindingSource
            // 
            this.facturaV2BindingSource.DataMember = "FacturaV2";
            this.facturaV2BindingSource.DataSource = this.sAPDataSet2;
            // 
            // sAPDataSet2
            // 
            this.sAPDataSet2.DataSetName = "SAPDataSet2";
            this.sAPDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Datos";
            reportDataSource1.Value = this.facturaV2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(527, 390);
            this.reportViewer1.TabIndex = 0;
            // 
            // facturaV2TableAdapter
            // 
            this.facturaV2TableAdapter.ClearBeforeFill = true;
            // 
            // Arduino12
            // 
            this.Arduino12.PortName = "COM3";
            // 
            // FacturaPorCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 390);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FacturaPorCobrar";
            this.Text = "FacturaPorCobrar";
            this.Load += new System.EventHandler(this.FacturaPorCobrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facturaV2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource facturaV2BindingSource;
        private SAPDataSet2 sAPDataSet2;
        private SAPDataSet2TableAdapters.FacturaV2TableAdapter facturaV2TableAdapter;
        private System.IO.Ports.SerialPort Arduino12;
    }
}