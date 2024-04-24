namespace SAP.Recaudadores.Controles
{
    partial class ConsumoTarjeta
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.prepagadoDataSet = new SAP.PrepagadoDataSet();
            this.consumoTarjetaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.consumoTarjetaTableAdapter = new SAP.PrepagadoDataSetTableAdapters.ConsumoTarjetaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.prepagadoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.consumoTarjetaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "Consumo";
            reportDataSource2.Value = this.consumoTarjetaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Recaudadores.Controles.Reportes.ConsumoTarjeta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(612, 492);
            this.reportViewer1.TabIndex = 0;
            // 
            // prepagadoDataSet
            // 
            this.prepagadoDataSet.DataSetName = "PrepagadoDataSet";
            this.prepagadoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // consumoTarjetaBindingSource
            // 
            this.consumoTarjetaBindingSource.DataMember = "ConsumoTarjeta";
            this.consumoTarjetaBindingSource.DataSource = this.prepagadoDataSet;
            // 
            // consumoTarjetaTableAdapter
            // 
            this.consumoTarjetaTableAdapter.ClearBeforeFill = true;
            // 
            // ConsumoTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 492);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ConsumoTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsumoTarjeta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ConsumoTarjeta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prepagadoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.consumoTarjetaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource consumoTarjetaBindingSource;
        private PrepagadoDataSet prepagadoDataSet;
        private PrepagadoDataSetTableAdapters.ConsumoTarjetaTableAdapter consumoTarjetaTableAdapter;
    }
}