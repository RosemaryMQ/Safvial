namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    partial class TabulacionUsuario
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tabulacionVehiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAPDataSet2 = new SAP.SAPDataSet2();
            this.tabulacionFormaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabulacionVehiculoTableAdapter = new SAP.SAPDataSet2TableAdapters.TabulacionVehiculoTableAdapter();
            this.tabulacionFormaTableAdapter = new SAP.SAPDataSet2TableAdapters.TabulacionFormaTableAdapter();
            this.tabulacionUsuarioPrepagadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabulacionTipoPrepagadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabulacionGeneralUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabulacionVehiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabulacionFormaBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulacionUsuarioPrepagadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabulacionTipoPrepagadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabulacionGeneralUsuarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabulacionVehiculoBindingSource
            // 
            this.tabulacionVehiculoBindingSource.DataMember = "TabulacionVehiculo";
            this.tabulacionVehiculoBindingSource.DataSource = this.sAPDataSet2;
            // 
            // sAPDataSet2
            // 
            this.sAPDataSet2.DataSetName = "SAPDataSet2";
            this.sAPDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabulacionFormaBindingSource
            // 
            this.tabulacionFormaBindingSource.DataMember = "TabulacionForma";
            this.tabulacionFormaBindingSource.DataSource = this.sAPDataSet2;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 92;
            reportDataSource1.Name = "ResumenP";
            reportDataSource1.Value = this.tabulacionFormaBindingSource;
            reportDataSource2.Name = "TabulacionUser";
            reportDataSource2.Value = this.tabulacionUsuarioPrepagadoBindingSource;
            reportDataSource3.Name = "TabulacionTipoPrepagado";
            reportDataSource3.Value = this.tabulacionTipoPrepagadoBindingSource;
            reportDataSource4.Name = "TabulacionGeneral";
            reportDataSource4.Value = this.tabulacionGeneralUsuarioBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Tesoreria.Controles.Declaraciones.Tabulacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(816, 433);
            this.reportViewer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(822, 439);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tabulacionVehiculoTableAdapter
            // 
            this.tabulacionVehiculoTableAdapter.ClearBeforeFill = true;
            // 
            // tabulacionFormaTableAdapter
            // 
            this.tabulacionFormaTableAdapter.ClearBeforeFill = true;
            // 
            // tabulacionUsuarioPrepagadoBindingSource
            // 
            this.tabulacionUsuarioPrepagadoBindingSource.DataSource = typeof(SAP.Common.TabulacionUsuarioPrepagado);
            // 
            // tabulacionTipoPrepagadoBindingSource
            // 
            this.tabulacionTipoPrepagadoBindingSource.DataSource = typeof(SAP.Common.TabulacionTipoPrepagado);
            // 
            // tabulacionGeneralUsuarioBindingSource
            // 
            this.tabulacionGeneralUsuarioBindingSource.DataSource = typeof(SAP.Common.TabulacionGeneralUsuario);
            // 
            // TabulacionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 439);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TabulacionUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TabulacionUsuario";
            this.Load += new System.EventHandler(this.TabulacionUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabulacionVehiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabulacionFormaBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabulacionUsuarioPrepagadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabulacionTipoPrepagadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabulacionGeneralUsuarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tabulacionVehiculoBindingSource;
        private SAPDataSet2 sAPDataSet2;
        private System.Windows.Forms.BindingSource tabulacionFormaBindingSource;
        private SAPDataSet2TableAdapters.TabulacionVehiculoTableAdapter tabulacionVehiculoTableAdapter;
        private SAPDataSet2TableAdapters.TabulacionFormaTableAdapter tabulacionFormaTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource tabulacionUsuarioPrepagadoBindingSource;
        private System.Windows.Forms.BindingSource tabulacionTipoPrepagadoBindingSource;
        private System.Windows.Forms.BindingSource tabulacionGeneralUsuarioBindingSource;
    }
}