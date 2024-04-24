namespace SAP.Recaudadores.SafvialWeb
{
    partial class ReporteOperaciones
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
            this.safvialWeb = new SAP.SafvialWeb();
            this.pendientes2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pendientes2TableAdapter = new SAP.SafvialWebTableAdapters.Pendientes2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.safvialWeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendientes2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OperacionesV2";
            reportDataSource1.Value = this.pendientes2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Recaudadores.SafvialWeb.Reportes.OperacionesPendientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(671, 463);
            this.reportViewer1.TabIndex = 0;
            // 
            // safvialWeb
            // 
            this.safvialWeb.DataSetName = "SafvialWeb";
            this.safvialWeb.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pendientes2BindingSource
            // 
            this.pendientes2BindingSource.DataMember = "Pendientes2";
            this.pendientes2BindingSource.DataSource = this.safvialWeb;
            // 
            // pendientes2TableAdapter
            // 
            this.pendientes2TableAdapter.ClearBeforeFill = true;
            // 
            // ReporteOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 463);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteOperaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Operaciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteOperaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.safvialWeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendientes2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SAP.SafvialWeb safvialWeb;
        private System.Windows.Forms.BindingSource pendientes2BindingSource;
        private SafvialWebTableAdapters.Pendientes2TableAdapter pendientes2TableAdapter;
    }
}