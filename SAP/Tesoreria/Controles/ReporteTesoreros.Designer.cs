namespace SAP.Tesoreria.Controles
{
    partial class ReporteTesoreros
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sAPDataSet2 = new SAP.SAPDataSet2();
            this.reporteUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteUserTableAdapter = new SAP.SAPDataSet2TableAdapters.ReporteUserTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteUserBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Tesoreros";
            reportDataSource1.Value = this.reporteUserBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Tesoreria.Controles.Tesoreros.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(376, 309);
            this.reportViewer1.TabIndex = 0;
            // 
            // sAPDataSet2
            // 
            this.sAPDataSet2.DataSetName = "SAPDataSet2";
            this.sAPDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteUserBindingSource
            // 
            this.reporteUserBindingSource.DataMember = "ReporteUser";
            this.reporteUserBindingSource.DataSource = this.sAPDataSet2;
            // 
            // reporteUserTableAdapter
            // 
            this.reporteUserTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteTesoreros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 309);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteTesoreros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteTesoreros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteTesoreros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteUserBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporteUserBindingSource;
        private SAPDataSet2 sAPDataSet2;
        private SAPDataSet2TableAdapters.ReporteUserTableAdapter reporteUserTableAdapter;
    }
}