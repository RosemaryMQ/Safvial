namespace SAP.Recaudadores.Controles
{
    partial class ConsolidadoCliente
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.consumoClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prepagadoDataSet = new SAP.PrepagadoDataSet();
            this.cobrosGlobalCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cobrosVehiculosCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operacionesCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.consumoClienteTableAdapter = new SAP.PrepagadoDataSetTableAdapters.ConsumoClienteTableAdapter();
            this.operacionesCTableAdapter = new SAP.PrepagadoDataSetTableAdapters.OperacionesCTableAdapter();
            this.cobrosGlobalCTableAdapter = new SAP.PrepagadoDataSetTableAdapters.CobrosGlobalCTableAdapter();
            this.cobrosVehiculosCTableAdapter = new SAP.PrepagadoDataSetTableAdapters.CobrosVehiculosCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.consumoClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prepagadoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobrosGlobalCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobrosVehiculosCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operacionesCBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // consumoClienteBindingSource
            // 
            this.consumoClienteBindingSource.DataMember = "ConsumoCliente";
            this.consumoClienteBindingSource.DataSource = this.prepagadoDataSet;
            // 
            // prepagadoDataSet
            // 
            this.prepagadoDataSet.DataSetName = "PrepagadoDataSet";
            this.prepagadoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cobrosGlobalCBindingSource
            // 
            this.cobrosGlobalCBindingSource.DataMember = "CobrosGlobalC";
            this.cobrosGlobalCBindingSource.DataSource = this.prepagadoDataSet;
            // 
            // cobrosVehiculosCBindingSource
            // 
            this.cobrosVehiculosCBindingSource.DataMember = "CobrosVehiculosC";
            this.cobrosVehiculosCBindingSource.DataSource = this.prepagadoDataSet;
            // 
            // operacionesCBindingSource
            // 
            this.operacionesCBindingSource.DataMember = "OperacionesC";
            this.operacionesCBindingSource.DataSource = this.prepagadoDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource5.Name = "Consolidado";
            reportDataSource5.Value = this.consumoClienteBindingSource;
            reportDataSource6.Name = "Cobrados";
            reportDataSource6.Value = this.cobrosGlobalCBindingSource;
            reportDataSource7.Name = "CobradosDetalle";
            reportDataSource7.Value = this.cobrosVehiculosCBindingSource;
            reportDataSource8.Name = "OperacionesC";
            reportDataSource8.Value = this.operacionesCBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Recaudadores.Controles.Reportes.ReporteCuenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(597, 410);
            this.reportViewer1.TabIndex = 0;
            // 
            // consumoClienteTableAdapter
            // 
            this.consumoClienteTableAdapter.ClearBeforeFill = true;
            // 
            // operacionesCTableAdapter
            // 
            this.operacionesCTableAdapter.ClearBeforeFill = true;
            // 
            // cobrosGlobalCTableAdapter
            // 
            this.cobrosGlobalCTableAdapter.ClearBeforeFill = true;
            // 
            // cobrosVehiculosCTableAdapter
            // 
            this.cobrosVehiculosCTableAdapter.ClearBeforeFill = true;
            // 
            // ConsolidadoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 410);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ConsolidadoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de consolidados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ConsolidadoCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.consumoClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prepagadoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobrosGlobalCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobrosVehiculosCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operacionesCBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private PrepagadoDataSet prepagadoDataSet;
        private System.Windows.Forms.BindingSource consumoClienteBindingSource;
        private PrepagadoDataSetTableAdapters.ConsumoClienteTableAdapter consumoClienteTableAdapter;
        private System.Windows.Forms.BindingSource cobrosVehiculosCBindingSource;
        private System.Windows.Forms.BindingSource cobrosGlobalCBindingSource;
        private System.Windows.Forms.BindingSource operacionesCBindingSource;
        private PrepagadoDataSetTableAdapters.OperacionesCTableAdapter operacionesCTableAdapter;
        private PrepagadoDataSetTableAdapters.CobrosGlobalCTableAdapter cobrosGlobalCTableAdapter;
        private PrepagadoDataSetTableAdapters.CobrosVehiculosCTableAdapter cobrosVehiculosCTableAdapter;
    }
}