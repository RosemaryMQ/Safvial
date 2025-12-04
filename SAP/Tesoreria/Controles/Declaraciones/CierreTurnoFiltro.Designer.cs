
namespace SAP.Tesoreria.Controles.Declaraciones
{
    partial class CierreTurnoFiltro
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
            this.cierreBiopagoFiltroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreBiopagoFiltroTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierreBiopagoFiltroTableAdapter();
            this.tableAdapterManager = new SAP.SAPDataSetLocalTableAdapters.TableAdapterManager();
            this.cierreBuzonFiltroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreBuzonFiltroTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierreBuzonFiltroTableAdapter();
            this.cierreEfectivoFiltroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreEfectivoFiltroTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierreEfectivoFiltroTableAdapter();
            this.cierrePDVFiltroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierrePDVFiltroTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierrePDVFiltroTableAdapter();
            this.cierrePINCFiltroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierrePINCFiltroTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierrePINCFiltroTableAdapter();
            this.cierreTransfFiltroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreTransfFiltroTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierreTransfFiltroTableAdapter();
            this.cierreTurnoFiltroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreTurnoFiltroTableAdapter = new SAP.SAPDataSetLocalTableAdapters.CierreTurnoFiltroTableAdapter();
            this.tarjetaExpressDataSet = new SAP.TarjetaExpressDataSet();
            this.tarjetaExpressReporte1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tarjetaExpressReporte1TableAdapter = new SAP.TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte1TableAdapter();
            this.tableAdapterManager1 = new SAP.TarjetaExpressDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSetLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBiopagoFiltroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBuzonFiltroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreEfectivoFiltroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePDVFiltroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePINCFiltroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTransfFiltroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTurnoFiltroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Tesoreria.Controles.Declaraciones.VersionV2.CierreTurnoFiltro.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(674, 454);
            this.reportViewer1.TabIndex = 0;
            // 
            // sAPDataSetLocal
            // 
            this.sAPDataSetLocal.DataSetName = "SAPDataSetLocal";
            this.sAPDataSetLocal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cierreBiopagoFiltroBindingSource
            // 
            this.cierreBiopagoFiltroBindingSource.DataMember = "CierreBiopagoFiltro";
            this.cierreBiopagoFiltroBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierreBiopagoFiltroTableAdapter
            // 
            this.cierreBiopagoFiltroTableAdapter.ClearBeforeFill = true;
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
            // cierreBuzonFiltroBindingSource
            // 
            this.cierreBuzonFiltroBindingSource.DataMember = "CierreBuzonFiltro";
            this.cierreBuzonFiltroBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierreBuzonFiltroTableAdapter
            // 
            this.cierreBuzonFiltroTableAdapter.ClearBeforeFill = true;
            // 
            // cierreEfectivoFiltroBindingSource
            // 
            this.cierreEfectivoFiltroBindingSource.DataMember = "CierreEfectivoFiltro";
            this.cierreEfectivoFiltroBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierreEfectivoFiltroTableAdapter
            // 
            this.cierreEfectivoFiltroTableAdapter.ClearBeforeFill = true;
            // 
            // cierrePDVFiltroBindingSource
            // 
            this.cierrePDVFiltroBindingSource.DataMember = "CierrePDVFiltro";
            this.cierrePDVFiltroBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierrePDVFiltroTableAdapter
            // 
            this.cierrePDVFiltroTableAdapter.ClearBeforeFill = true;
            // 
            // cierrePINCFiltroBindingSource
            // 
            this.cierrePINCFiltroBindingSource.DataMember = "CierrePINCFiltro";
            this.cierrePINCFiltroBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierrePINCFiltroTableAdapter
            // 
            this.cierrePINCFiltroTableAdapter.ClearBeforeFill = true;
            // 
            // cierreTransfFiltroBindingSource
            // 
            this.cierreTransfFiltroBindingSource.DataMember = "CierreTransfFiltro";
            this.cierreTransfFiltroBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierreTransfFiltroTableAdapter
            // 
            this.cierreTransfFiltroTableAdapter.ClearBeforeFill = true;
            // 
            // cierreTurnoFiltroBindingSource
            // 
            this.cierreTurnoFiltroBindingSource.DataMember = "CierreTurnoFiltro";
            this.cierreTurnoFiltroBindingSource.DataSource = this.sAPDataSetLocal;
            // 
            // cierreTurnoFiltroTableAdapter
            // 
            this.cierreTurnoFiltroTableAdapter.ClearBeforeFill = true;
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
            // CierreTurnoFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 454);
            this.Controls.Add(this.reportViewer1);
            this.Name = "CierreTurnoFiltro";
            this.Text = "CierreTurnoFiltro";
            this.Load += new System.EventHandler(this.CierreTurnoFiltro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSetLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBiopagoFiltroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBuzonFiltroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreEfectivoFiltroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePDVFiltroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierrePINCFiltroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTransfFiltroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTurnoFiltroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SAPDataSetLocal sAPDataSetLocal;
        private System.Windows.Forms.BindingSource cierreBiopagoFiltroBindingSource;
        private SAPDataSetLocalTableAdapters.CierreBiopagoFiltroTableAdapter cierreBiopagoFiltroTableAdapter;
        private SAPDataSetLocalTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource cierreBuzonFiltroBindingSource;
        private SAPDataSetLocalTableAdapters.CierreBuzonFiltroTableAdapter cierreBuzonFiltroTableAdapter;
        private System.Windows.Forms.BindingSource cierreEfectivoFiltroBindingSource;
        private SAPDataSetLocalTableAdapters.CierreEfectivoFiltroTableAdapter cierreEfectivoFiltroTableAdapter;
        private System.Windows.Forms.BindingSource cierrePDVFiltroBindingSource;
        private SAPDataSetLocalTableAdapters.CierrePDVFiltroTableAdapter cierrePDVFiltroTableAdapter;
        private System.Windows.Forms.BindingSource cierrePINCFiltroBindingSource;
        private SAPDataSetLocalTableAdapters.CierrePINCFiltroTableAdapter cierrePINCFiltroTableAdapter;
        private System.Windows.Forms.BindingSource cierreTransfFiltroBindingSource;
        private SAPDataSetLocalTableAdapters.CierreTransfFiltroTableAdapter cierreTransfFiltroTableAdapter;
        private System.Windows.Forms.BindingSource cierreTurnoFiltroBindingSource;
        private SAPDataSetLocalTableAdapters.CierreTurnoFiltroTableAdapter cierreTurnoFiltroTableAdapter;
        private TarjetaExpressDataSet tarjetaExpressDataSet;
        private System.Windows.Forms.BindingSource tarjetaExpressReporte1BindingSource;
        private TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte1TableAdapter tarjetaExpressReporte1TableAdapter;
        private TarjetaExpressDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
    }
}