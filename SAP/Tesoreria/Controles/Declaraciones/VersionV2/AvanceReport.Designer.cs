namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    partial class AvanceReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.efectivoCierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAPDataSet = new SAP.SAPDataSet();
            this.pDVCierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noPagoCierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAPDataSet2 = new SAP.SAPDataSet2();
            this.resumenTransfBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tarjetaExpressReporte11BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tarjetaExpressDataSet = new SAP.TarjetaExpressDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.efectivoCierreTableAdapter = new SAP.SAPDataSetTableAdapters.EfectivoCierreTableAdapter();
            this.pDVCierreTableAdapter = new SAP.SAPDataSetTableAdapters.PDVCierreTableAdapter();
            this.noPagoCierreTableAdapter = new SAP.SAPDataSetTableAdapters.NoPagoCierreTableAdapter();
            this.usuariosTableAdapter = new SAP.SAPDataSet2TableAdapters.UsuariosTableAdapter();
            this.resumenTransfTableAdapter = new SAP.SAPDataSet2TableAdapters.ResumenTransfTableAdapter();
            this.tarjetaExpressReporte11TableAdapter = new SAP.TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte11TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.efectivoCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDVCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPagoCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resumenTransfBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte11BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // efectivoCierreBindingSource
            // 
            this.efectivoCierreBindingSource.DataMember = "EfectivoCierre";
            this.efectivoCierreBindingSource.DataSource = this.sAPDataSet;
            // 
            // sAPDataSet
            // 
            this.sAPDataSet.DataSetName = "SAPDataSet";
            this.sAPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pDVCierreBindingSource
            // 
            this.pDVCierreBindingSource.DataMember = "PDVCierre";
            this.pDVCierreBindingSource.DataSource = this.sAPDataSet;
            // 
            // noPagoCierreBindingSource
            // 
            this.noPagoCierreBindingSource.DataMember = "NoPagoCierre";
            this.noPagoCierreBindingSource.DataSource = this.sAPDataSet;
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "Usuarios";
            this.usuariosBindingSource.DataSource = this.sAPDataSet2;
            // 
            // sAPDataSet2
            // 
            this.sAPDataSet2.DataSetName = "SAPDataSet2";
            this.sAPDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // resumenTransfBindingSource
            // 
            this.resumenTransfBindingSource.DataMember = "ResumenTransf";
            this.resumenTransfBindingSource.DataSource = this.sAPDataSet2;
            // 
            // tarjetaExpressReporte11BindingSource
            // 
            this.tarjetaExpressReporte11BindingSource.DataMember = "TarjetaExpressReporte11";
            this.tarjetaExpressReporte11BindingSource.DataSource = this.tarjetaExpressDataSet;
            // 
            // tarjetaExpressDataSet
            // 
            this.tarjetaExpressDataSet.DataSetName = "TarjetaExpressDataSet";
            this.tarjetaExpressDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Efectivo";
            reportDataSource1.Value = this.efectivoCierreBindingSource;
            reportDataSource2.Name = "PDV";
            reportDataSource2.Value = this.pDVCierreBindingSource;
            reportDataSource3.Name = "Incompleto";
            reportDataSource3.Value = this.noPagoCierreBindingSource;
            reportDataSource4.Name = "Usuario";
            reportDataSource4.Value = this.usuariosBindingSource;
            reportDataSource5.Name = "Transfencia";
            reportDataSource5.Value = this.resumenTransfBindingSource;
            reportDataSource6.Name = "TarjetasVendidas";
            reportDataSource6.Value = this.tarjetaExpressReporte11BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Cobradores.Controles.Avance.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(468, 371);
            this.reportViewer1.TabIndex = 0;
            // 
            // efectivoCierreTableAdapter
            // 
            this.efectivoCierreTableAdapter.ClearBeforeFill = true;
            // 
            // pDVCierreTableAdapter
            // 
            this.pDVCierreTableAdapter.ClearBeforeFill = true;
            // 
            // noPagoCierreTableAdapter
            // 
            this.noPagoCierreTableAdapter.ClearBeforeFill = true;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // resumenTransfTableAdapter
            // 
            this.resumenTransfTableAdapter.ClearBeforeFill = true;
            // 
            // tarjetaExpressReporte11TableAdapter
            // 
            this.tarjetaExpressReporte11TableAdapter.ClearBeforeFill = true;
            // 
            // AvanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 371);
            this.Controls.Add(this.reportViewer1);
            this.Name = "AvanceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AvanceReport";
            this.Load += new System.EventHandler(this.AvanceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.efectivoCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDVCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPagoCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resumenTransfBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte11BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource efectivoCierreBindingSource;
        private SAPDataSet sAPDataSet;
        private System.Windows.Forms.BindingSource pDVCierreBindingSource;
        private System.Windows.Forms.BindingSource noPagoCierreBindingSource;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private SAPDataSet2 sAPDataSet2;
        private System.Windows.Forms.BindingSource resumenTransfBindingSource;
        private System.Windows.Forms.BindingSource tarjetaExpressReporte11BindingSource;
        private TarjetaExpressDataSet tarjetaExpressDataSet;
        private SAPDataSetTableAdapters.EfectivoCierreTableAdapter efectivoCierreTableAdapter;
        private SAPDataSetTableAdapters.PDVCierreTableAdapter pDVCierreTableAdapter;
        private SAPDataSetTableAdapters.NoPagoCierreTableAdapter noPagoCierreTableAdapter;
        private SAPDataSet2TableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private SAPDataSet2TableAdapters.ResumenTransfTableAdapter resumenTransfTableAdapter;
        private TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte11TableAdapter tarjetaExpressReporte11TableAdapter;
    }
}