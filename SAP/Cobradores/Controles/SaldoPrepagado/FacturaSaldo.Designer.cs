namespace SAP.Cobradores.Controles.SaldoPrepagado
{
    partial class FacturaSaldo
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
            this.prepagadoDataSet = new SAP.PrepagadoDataSet();
            this.facturaPrepagadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturaPrepagadoTableAdapter = new SAP.PrepagadoDataSetTableAdapters.FacturaPrepagadoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.prepagadoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaPrepagadoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Datos";
            reportDataSource1.Value = this.facturaPrepagadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Cobradores.Controles.SaldoPrepagado.FacturaSaldo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(478, 359);
            this.reportViewer1.TabIndex = 0;
            // 
            // prepagadoDataSet
            // 
            this.prepagadoDataSet.DataSetName = "PrepagadoDataSet";
            this.prepagadoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facturaPrepagadoBindingSource
            // 
            this.facturaPrepagadoBindingSource.DataMember = "FacturaPrepagado";
            this.facturaPrepagadoBindingSource.DataSource = this.prepagadoDataSet;
            // 
            // facturaPrepagadoTableAdapter
            // 
            this.facturaPrepagadoTableAdapter.ClearBeforeFill = true;
            // 
            // FacturaSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 359);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FacturaSaldo";
            this.Text = "FacturaSaldo";
            this.Load += new System.EventHandler(this.FacturaSaldo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prepagadoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaPrepagadoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource facturaPrepagadoBindingSource;
        private PrepagadoDataSet prepagadoDataSet;
        private PrepagadoDataSetTableAdapters.FacturaPrepagadoTableAdapter facturaPrepagadoTableAdapter;
    }
}