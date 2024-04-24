namespace SAP.Cobradores.Controles
{
    partial class FacturaV2
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.pagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAPDataSet2 = new SAP.SAPDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pagosTableAdapter = new SAP.SAPDataSet2TableAdapters.PagosTableAdapter();
            this.Arduino = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pagosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // pagosBindingSource
            // 
            this.pagosBindingSource.DataMember = "Pagos";
            this.pagosBindingSource.DataSource = this.sAPDataSet2;
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
            reportDataSource1.Value = this.pagosBindingSource;
            reportDataSource2.Name = "Logo";
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Cobradores.Controles.FacturaV2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(357, 345);
            this.reportViewer1.TabIndex = 0;
            // 
            // pagosTableAdapter
            // 
            this.pagosTableAdapter.ClearBeforeFill = true;
            // 
            // Arduino
            // 
            this.Arduino.PortName = "COM3";
            this.Arduino.RtsEnable = true;
            // 
            // FacturaV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 345);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FacturaV2";
            this.Text = "FacturaV2";
            this.Load += new System.EventHandler(this.FacturaV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pagosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource pagosBindingSource;
        private SAPDataSet2 sAPDataSet2;
        private SAPDataSet2TableAdapters.PagosTableAdapter pagosTableAdapter;
        private System.IO.Ports.SerialPort Arduino;
    }
}