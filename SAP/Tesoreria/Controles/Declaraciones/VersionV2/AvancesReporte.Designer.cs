namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    partial class AvancesReporte
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
            this.EfectivoS = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sAPDataSet2 = new SAP.SAPDataSet2();
            this.cierresParcialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierresParcialesTableAdapter = new SAP.SAPDataSet2TableAdapters.CierresParcialesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierresParcialesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // EfectivoS
            // 
            this.EfectivoS.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "AvancesUsuario";
            reportDataSource1.Value = this.cierresParcialesBindingSource;
            this.EfectivoS.LocalReport.DataSources.Add(reportDataSource1);
            this.EfectivoS.LocalReport.ReportEmbeddedResource = "SAP.Tesoreria.Controles.Declaraciones.VersionV2.AvancesUsuarios.rdlc";
            this.EfectivoS.Location = new System.Drawing.Point(0, 0);
            this.EfectivoS.Name = "EfectivoS";
            this.EfectivoS.Size = new System.Drawing.Size(609, 455);
            this.EfectivoS.TabIndex = 0;
            // 
            // sAPDataSet2
            // 
            this.sAPDataSet2.DataSetName = "SAPDataSet2";
            this.sAPDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cierresParcialesBindingSource
            // 
            this.cierresParcialesBindingSource.DataMember = "CierresParciales";
            this.cierresParcialesBindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierresParcialesTableAdapter
            // 
            this.cierresParcialesTableAdapter.ClearBeforeFill = true;
            // 
            // AvancesReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 455);
            this.Controls.Add(this.EfectivoS);
            this.Name = "AvancesReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AvancesReporte";
            this.Load += new System.EventHandler(this.AvancesReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierresParcialesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer EfectivoS;
        private System.Windows.Forms.BindingSource cierresParcialesBindingSource;
        private SAPDataSet2 sAPDataSet2;
        private SAPDataSet2TableAdapters.CierresParcialesTableAdapter cierresParcialesTableAdapter;
    }
}