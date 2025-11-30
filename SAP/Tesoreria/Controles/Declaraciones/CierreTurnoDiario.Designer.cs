
namespace SAP.Tesoreria.Controles.Declaraciones
{
    partial class CierreTurnoDiario
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
            this.sAPDataSet2 = new SAP.SAPDataSet2();
            this.buzonTurno1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buzonTurno1TableAdapter = new SAP.SAPDataSet2TableAdapters.BuzonTurno1TableAdapter();
            this.tableAdapterManager = new SAP.SAPDataSet2TableAdapters.TableAdapterManager();
            this.cierreBiopago1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreBiopago1TableAdapter = new SAP.SAPDataSet2TableAdapters.CierreBiopago1TableAdapter();
            this.cierreEfectivo1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreEfectivo1TableAdapter = new SAP.SAPDataSet2TableAdapters.CierreEfectivo1TableAdapter();
            this.cierrePDV1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierrePDV1TableAdapter = new SAP.SAPDataSet2TableAdapters.CierrePDV1TableAdapter();
            this.cierrePINC1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierrePINC1TableAdapter = new SAP.SAPDataSet2TableAdapters.CierrePINC1TableAdapter();
            this.cierreTransf1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreTransf1TableAdapter = new SAP.SAPDataSet2TableAdapters.CierreTransf1TableAdapter();
            this.cierreTurnoV1DiarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreTurnoV1DiarioTableAdapter = new SAP.SAPDataSet2TableAdapters.CierreTurnoV1DiarioTableAdapter();
            this.tarjetaExpressDataSet = new SAP.TarjetaExpressDataSet();
            this.tarjetaExpressReporte1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tarjetaExpressReporte1TableAdapter = new SAP.TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte1TableAdapter();
            this.tableAdapterManager1 = new SAP.TarjetaExpressDataSetTableAdapters.TableAdapterManager();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buzonTurno1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBiopago1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreEfectivo1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePDV1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePINC1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTransf1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTurnoV1DiarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sAPDataSet2
            // 
            this.sAPDataSet2.DataSetName = "SAPDataSet2";
            this.sAPDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buzonTurno1BindingSource
            // 
            this.buzonTurno1BindingSource.DataMember = "BuzonTurno1";
            this.buzonTurno1BindingSource.DataSource = this.sAPDataSet2;
            // 
            // buzonTurno1TableAdapter
            // 
            this.buzonTurno1TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CierresParcialesTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.PeajeTableAdapter = null;
            this.tableAdapterManager.ReporteUserTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SAP.SAPDataSet2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cierreBiopago1BindingSource
            // 
            this.cierreBiopago1BindingSource.DataMember = "CierreBiopago1";
            this.cierreBiopago1BindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierreBiopago1TableAdapter
            // 
            this.cierreBiopago1TableAdapter.ClearBeforeFill = true;
            // 
            // cierreEfectivo1BindingSource
            // 
            this.cierreEfectivo1BindingSource.DataMember = "CierreEfectivo1";
            this.cierreEfectivo1BindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierreEfectivo1TableAdapter
            // 
            this.cierreEfectivo1TableAdapter.ClearBeforeFill = true;
            // 
            // cierrePDV1BindingSource
            // 
            this.cierrePDV1BindingSource.DataMember = "CierrePDV1";
            this.cierrePDV1BindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierrePDV1TableAdapter
            // 
            this.cierrePDV1TableAdapter.ClearBeforeFill = true;
            // 
            // cierrePINC1BindingSource
            // 
            this.cierrePINC1BindingSource.DataMember = "CierrePINC1";
            this.cierrePINC1BindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierrePINC1TableAdapter
            // 
            this.cierrePINC1TableAdapter.ClearBeforeFill = true;
            // 
            // cierreTransf1BindingSource
            // 
            this.cierreTransf1BindingSource.DataMember = "CierreTransf1";
            this.cierreTransf1BindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierreTransf1TableAdapter
            // 
            this.cierreTransf1TableAdapter.ClearBeforeFill = true;
            // 
            // cierreTurnoV1DiarioBindingSource
            // 
            this.cierreTurnoV1DiarioBindingSource.DataMember = "CierreTurnoV1Diario";
            this.cierreTurnoV1DiarioBindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierreTurnoV1DiarioTableAdapter
            // 
            this.cierreTurnoV1DiarioTableAdapter.ClearBeforeFill = true;
            // 
            // tarjetaExpressDataSet
            // 
            this.tarjetaExpressDataSet.DataSetName = "TarjetaExpressDataSet";
            this.tarjetaExpressDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tarjetaExpressReporte1BindingSource
            // 
            this.tarjetaExpressReporte1BindingSource.DataMember = "TarjetaExpressReporte1";
            this.tarjetaExpressReporte1BindingSource.DataSource = this.tarjetaExpressDataSet;
            // 
            // tarjetaExpressReporte1TableAdapter
            // 
            this.tarjetaExpressReporte1TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = SAP.TarjetaExpressDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Tesoreria.Controles.Declaraciones.VersionV2.CierreTurnoDiario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 498);
            this.reportViewer1.TabIndex = 0;
            // 
            // CierreTurnoDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.reportViewer1);
            this.Name = "CierreTurnoDiario";
            this.Text = "CierreTurnoDiario";
            this.Load += new System.EventHandler(this.CierreTurnoDiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buzonTurno1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBiopago1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreEfectivo1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePDV1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePINC1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTransf1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTurnoV1DiarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SAPDataSet2 sAPDataSet2;
        private System.Windows.Forms.BindingSource buzonTurno1BindingSource;
        private SAPDataSet2TableAdapters.BuzonTurno1TableAdapter buzonTurno1TableAdapter;
        private SAPDataSet2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource cierreBiopago1BindingSource;
        private SAPDataSet2TableAdapters.CierreBiopago1TableAdapter cierreBiopago1TableAdapter;
        private System.Windows.Forms.BindingSource cierreEfectivo1BindingSource;
        private SAPDataSet2TableAdapters.CierreEfectivo1TableAdapter cierreEfectivo1TableAdapter;
        private System.Windows.Forms.BindingSource cierrePDV1BindingSource;
        private SAPDataSet2TableAdapters.CierrePDV1TableAdapter cierrePDV1TableAdapter;
        private System.Windows.Forms.BindingSource cierrePINC1BindingSource;
        private SAPDataSet2TableAdapters.CierrePINC1TableAdapter cierrePINC1TableAdapter;
        private System.Windows.Forms.BindingSource cierreTransf1BindingSource;
        private SAPDataSet2TableAdapters.CierreTransf1TableAdapter cierreTransf1TableAdapter;
        private System.Windows.Forms.BindingSource cierreTurnoV1DiarioBindingSource;
        private SAPDataSet2TableAdapters.CierreTurnoV1DiarioTableAdapter cierreTurnoV1DiarioTableAdapter;
        private TarjetaExpressDataSet tarjetaExpressDataSet;
        private System.Windows.Forms.BindingSource tarjetaExpressReporte1BindingSource;
        private TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte1TableAdapter tarjetaExpressReporte1TableAdapter;
        private TarjetaExpressDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}