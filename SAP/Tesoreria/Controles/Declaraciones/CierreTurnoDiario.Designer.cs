
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sAPDataSetLocal = new SAP.SAPDataSetLocal();
            this.cierreTurnoV1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreTurnoV1TableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierreTurnoV1TableAdapter();
            this.tableAdapterManager = new SAP.SAPDataSetLocalTableAdapters.TableAdapterManager();
            this.cierreBiopagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreBiopagoTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierreBiopagoTableAdapter();
            this.buzonTurnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buzonTurnoTableAdapter = new SAP.SAPDataSetLocalTableAdapters.BuzonTurnoTableAdapter();
            this.cierreTransfBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreTransfTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierreTransfTableAdapter();
            this.cierrePDVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierrePDVTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierrePDVTableAdapter();
            this.cierreEfectivoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreEfectivoTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierreEfectivoTableAdapter();
            this.cierrePINCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierrePINCTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierrePINCTableAdapter();
            this.tarjetaExpressDataSet = new SAP.TarjetaExpressDataSet();
            this.tarjetaExpressReporte1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tarjetaExpressReporte1TableAdapter = new SAP.TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte1TableAdapter();
            this.tableAdapterManager1 = new SAP.TarjetaExpressDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSetLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTurnoV1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBiopagoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buzonTurnoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTransfBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePDVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreEfectivoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePINCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Tesoreria.Controles.Declaraciones.VersionV2.CierreTurnoDiario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 518);
            this.reportViewer1.TabIndex = 0;
            // 
            // sAPDataSetLocal
            // 
            this.sAPDataSetLocal.DataSetName = "SAPDataSetLocal";
            this.sAPDataSetLocal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cierreTurnoV1BindingSource
            // 
            this.cierreTurnoV1BindingSource.DataMember = "CierreTurnoV1";
            this.cierreTurnoV1BindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierreTurnoV1TableAdapter
            // 
            this.cierreTurnoV1TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CierreBalanceV2TableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DeclaracionesTableAdapter = null;
            this.tableAdapterManager.TurnoTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SAP.SAPDataSetLocalTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuariosTableAdapter = null;
            // 
            // cierreBiopagoBindingSource
            // 
            this.cierreBiopagoBindingSource.DataMember = "CierreBiopago";
            this.cierreBiopagoBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierreBiopagoTableAdapter
            // 
            this.cierreBiopagoTableAdapter.ClearBeforeFill = true;
            // 
            // buzonTurnoBindingSource
            // 
            this.buzonTurnoBindingSource.DataMember = "BuzonTurno";
            this.buzonTurnoBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // buzonTurnoTableAdapter
            // 
            this.buzonTurnoTableAdapter.ClearBeforeFill = true;
            // 
            // cierreTransfBindingSource
            // 
            this.cierreTransfBindingSource.DataMember = "CierreTransf";
            this.cierreTransfBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierreTransfTableAdapter
            // 
            this.cierreTransfTableAdapter.ClearBeforeFill = true;
            // 
            // cierrePDVBindingSource
            // 
            this.cierrePDVBindingSource.DataMember = "CierrePDV";
            this.cierrePDVBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierrePDVTableAdapter
            // 
            this.cierrePDVTableAdapter.ClearBeforeFill = true;
            // 
            // cierreEfectivoBindingSource
            // 
            this.cierreEfectivoBindingSource.DataMember = "CierreEfectivo";
            this.cierreEfectivoBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierreEfectivoTableAdapter
            // 
            this.cierreEfectivoTableAdapter.ClearBeforeFill = true;
            // 
            // cierrePINCBindingSource
            // 
            this.cierrePINCBindingSource.DataMember = "CierrePINC";
            this.cierrePINCBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierrePINCTableAdapter
            // 
            this.cierrePINCTableAdapter.ClearBeforeFill = true;
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
            // CierreTurnoDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.reportViewer1);
            this.Name = "CierreTurnoDiario";
            this.Text = "CierreTurnoDiario";
            this.Load += new System.EventHandler(this.CierreTurnoDiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSetLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTurnoV1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBiopagoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buzonTurnoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTransfBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePDVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreEfectivoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePINCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SAPDataSetLocal sAPDataSetLocal;
        private System.Windows.Forms.BindingSource cierreTurnoV1BindingSource;
        private SAPDataSetLocalTableAdapters.CierreTurnoV1TableAdapter cierreTurnoV1TableAdapter;
        private SAPDataSetLocalTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource cierreBiopagoBindingSource;
        private SAPDataSetLocalTableAdapters.CierreBiopagoTableAdapter cierreBiopagoTableAdapter;
        private System.Windows.Forms.BindingSource buzonTurnoBindingSource;
        private SAPDataSetLocalTableAdapters.BuzonTurnoTableAdapter buzonTurnoTableAdapter;
        private System.Windows.Forms.BindingSource cierreTransfBindingSource;
        private SAPDataSetLocalTableAdapters.CierreTransfTableAdapter cierreTransfTableAdapter;
        private System.Windows.Forms.BindingSource cierrePDVBindingSource;
        private SAPDataSetLocalTableAdapters.CierrePDVTableAdapter cierrePDVTableAdapter;
        private System.Windows.Forms.BindingSource cierreEfectivoBindingSource;
        private SAPDataSetLocalTableAdapters.CierreEfectivoTableAdapter cierreEfectivoTableAdapter;
        private System.Windows.Forms.BindingSource cierrePINCBindingSource;
        private SAPDataSetLocalTableAdapters.CierrePINCTableAdapter cierrePINCTableAdapter;
        private TarjetaExpressDataSet tarjetaExpressDataSet;
        private System.Windows.Forms.BindingSource tarjetaExpressReporte1BindingSource;
        private TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte1TableAdapter tarjetaExpressReporte1TableAdapter;
        private TarjetaExpressDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
    }
}