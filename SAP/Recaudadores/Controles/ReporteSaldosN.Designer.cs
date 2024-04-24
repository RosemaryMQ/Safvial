namespace SAP.Recaudadores.Controles
{
    partial class ReporteSaldosN
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.prepagadoDataSet = new SAP.PrepagadoDataSet();
            this.saldosNegativosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saldosNegativosTableAdapter = new SAP.PrepagadoDataSetTableAdapters.SaldosNegativosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.prepagadoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saldosNegativosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "Clientes";
            reportDataSource3.Value = this.saldosNegativosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Recaudadores.Controles.Reportes.SaldosNegativos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(764, 520);
            this.reportViewer1.TabIndex = 0;
            // 
            // prepagadoDataSet
            // 
            this.prepagadoDataSet.DataSetName = "PrepagadoDataSet";
            this.prepagadoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saldosNegativosBindingSource
            // 
            this.saldosNegativosBindingSource.DataMember = "SaldosNegativos";
            this.saldosNegativosBindingSource.DataSource = this.prepagadoDataSet;
            // 
            // saldosNegativosTableAdapter
            // 
            this.saldosNegativosTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteSaldosN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 520);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteSaldosN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteSaldosN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteSaldosN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prepagadoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saldosNegativosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private PrepagadoDataSet prepagadoDataSet;
        private System.Windows.Forms.BindingSource saldosNegativosBindingSource;
        private PrepagadoDataSetTableAdapters.SaldosNegativosTableAdapter saldosNegativosTableAdapter;
    }
}