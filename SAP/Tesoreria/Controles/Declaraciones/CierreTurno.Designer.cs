namespace SAP.Tesoreria.Controles.Declaraciones
{
    partial class CierreTurno
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.cierreTurnoV1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAPDataSet2 = new SAP.SAPDataSet2();
            this.cierrePDVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreEfectivoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierrePINCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tarjetaExpressReporte1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tarjetaExpressDataSet = new SAP.TarjetaExpressDataSet();
            this.cierreTransfBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cierreTurnoV1TableAdapter = new SAP.SAPDataSet2TableAdapters.CierreTurnoV1TableAdapter();
            this.cierrePDVTableAdapter = new SAP.SAPDataSet2TableAdapters.CierrePDVTableAdapter();
            this.cierreEfectivoTableAdapter = new SAP.SAPDataSet2TableAdapters.CierreEfectivoTableAdapter();
            this.cierrePINCTableAdapter = new SAP.SAPDataSet2TableAdapters.CierrePINCTableAdapter();
            this.tarjetaExpressReporte1TableAdapter = new SAP.TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte1TableAdapter();
            this.cierreTransfTableAdapter = new SAP.SAPDataSet2TableAdapters.CierreTransfTableAdapter();
            this.buzonTurnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buzonTurnoTableAdapter = new SAP.SAPDataSet2TableAdapters.BuzonTurnoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTurnoV1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePDVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreEfectivoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePINCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTransfBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buzonTurnoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cierreTurnoV1BindingSource
            // 
            this.cierreTurnoV1BindingSource.DataMember = "CierreTurnoV1";
            this.cierreTurnoV1BindingSource.DataSource = this.sAPDataSet2;
            // 
            // sAPDataSet2
            // 
            this.sAPDataSet2.DataSetName = "SAPDataSet2";
            this.sAPDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cierrePDVBindingSource
            // 
            this.cierrePDVBindingSource.DataMember = "CierrePDV";
            this.cierrePDVBindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierreEfectivoBindingSource
            // 
            this.cierreEfectivoBindingSource.DataMember = "CierreEfectivo";
            this.cierreEfectivoBindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierrePINCBindingSource
            // 
            this.cierrePINCBindingSource.DataMember = "CierrePINC";
            this.cierrePINCBindingSource.DataSource = this.sAPDataSet2;
            // 
            // tarjetaExpressReporte1BindingSource
            // 
            this.tarjetaExpressReporte1BindingSource.DataMember = "TarjetaExpressReporte1";
            this.tarjetaExpressReporte1BindingSource.DataSource = this.tarjetaExpressDataSet;
            // 
            // tarjetaExpressDataSet
            // 
            this.tarjetaExpressDataSet.DataSetName = "TarjetaExpressDataSet";
            this.tarjetaExpressDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cierreTransfBindingSource
            // 
            this.cierreTransfBindingSource.DataMember = "CierreTransf";
            this.cierreTransfBindingSource.DataSource = this.sAPDataSet2;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CierreTurno";
            reportDataSource1.Value = this.cierreTurnoV1BindingSource;
            reportDataSource2.Name = "CierrePDV";
            reportDataSource2.Value = this.cierrePDVBindingSource;
            reportDataSource3.Name = "CierreEfectivo";
            reportDataSource3.Value = this.cierreEfectivoBindingSource;
            reportDataSource4.Name = "CierrePINC";
            reportDataSource4.Value = this.cierrePINCBindingSource;
            reportDataSource5.Name = "TarjetaExpress";
            reportDataSource5.Value = this.tarjetaExpressReporte1BindingSource;
            reportDataSource6.Name = "CierreTransf";
            reportDataSource6.Value = this.cierreTransfBindingSource;
            reportDataSource7.Name = "CierreBuzon";
            reportDataSource7.Value = this.buzonTurnoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Tesoreria.Controles.Declaraciones.VersionV2.CierreTurno.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(801, 527);
            this.reportViewer1.TabIndex = 0;
            // 
            // cierreTurnoV1TableAdapter
            // 
            this.cierreTurnoV1TableAdapter.ClearBeforeFill = true;
            // 
            // cierrePDVTableAdapter
            // 
            this.cierrePDVTableAdapter.ClearBeforeFill = true;
            // 
            // cierreEfectivoTableAdapter
            // 
            this.cierreEfectivoTableAdapter.ClearBeforeFill = true;
            // 
            // cierrePINCTableAdapter
            // 
            this.cierrePINCTableAdapter.ClearBeforeFill = true;
            // 
            // tarjetaExpressReporte1TableAdapter
            // 
            this.tarjetaExpressReporte1TableAdapter.ClearBeforeFill = true;
            // 
            // cierreTransfTableAdapter
            // 
            this.cierreTransfTableAdapter.ClearBeforeFill = true;
            // 
            // buzonTurnoBindingSource
            // 
            this.buzonTurnoBindingSource.DataMember = "BuzonTurno";
            this.buzonTurnoBindingSource.DataSource = this.sAPDataSet2;
            // 
            // buzonTurnoTableAdapter
            // 
            this.buzonTurnoTableAdapter.ClearBeforeFill = true;
            // 
            // CierreTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 527);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CierreTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CierreTurno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CierreTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cierreTurnoV1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePDVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreEfectivoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePINCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTransfBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buzonTurnoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cierreTurnoV1BindingSource;
        private SAPDataSet2 sAPDataSet2;
        private System.Windows.Forms.BindingSource cierrePDVBindingSource;
        private System.Windows.Forms.BindingSource cierreEfectivoBindingSource;
        private System.Windows.Forms.BindingSource cierrePINCBindingSource;
        private SAPDataSet2TableAdapters.CierreTurnoV1TableAdapter cierreTurnoV1TableAdapter;
        private SAPDataSet2TableAdapters.CierrePDVTableAdapter cierrePDVTableAdapter;
        private SAPDataSet2TableAdapters.CierreEfectivoTableAdapter cierreEfectivoTableAdapter;
        private SAPDataSet2TableAdapters.CierrePINCTableAdapter cierrePINCTableAdapter;
        private TarjetaExpressDataSet tarjetaExpressDataSet;
        private System.Windows.Forms.BindingSource tarjetaExpressReporte1BindingSource;
        private TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte1TableAdapter tarjetaExpressReporte1TableAdapter;
        private System.Windows.Forms.BindingSource cierreTransfBindingSource;
        private SAPDataSet2TableAdapters.CierreTransfTableAdapter cierreTransfTableAdapter;
        private System.Windows.Forms.BindingSource buzonTurnoBindingSource;
        private SAPDataSet2TableAdapters.BuzonTurnoTableAdapter buzonTurnoTableAdapter;
    }
}