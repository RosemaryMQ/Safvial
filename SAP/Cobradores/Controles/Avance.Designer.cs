namespace SAP.Cobradores.Controles
{
    partial class Avance
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
            this.usuariosTableAdapter = new SAP.SAPDataSet2TableAdapters.UsuariosTableAdapter();
            this.usuarioCanalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuarioCanalTableAdapter = new SAP.SAPDataSet2TableAdapters.UsuarioCanalTableAdapter();
            this.pDVCierreTableAdapter = new SAP.SAPDataSetTableAdapters.PDVCierreTableAdapter();
            this.noPagoCierreTableAdapter = new SAP.SAPDataSetTableAdapters.NoPagoCierreTableAdapter();
            this.efectivoCierreTableAdapter = new SAP.SAPDataSetTableAdapters.EfectivoCierreTableAdapter();
            this.resumenTransfTableAdapter = new SAP.SAPDataSet2TableAdapters.ResumenTransfTableAdapter();
            this.tarjetaExpressReporte11TableAdapter = new SAP.TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte11TableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.resumenBiopagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resumenBiopagoTableAdapter = new SAP.SAPDataSet2TableAdapters.ResumenBiopagoTableAdapter();
            this.tableAdapterManager = new SAP.SAPDataSet2TableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.efectivoCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDVCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPagoCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resumenTransfBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte11BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioCanalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resumenBiopagoBindingSource)).BeginInit();
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
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Cobradores.Controles.Avance.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(519, 466);
            this.reportViewer1.TabIndex = 0;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // usuarioCanalBindingSource
            // 
            this.usuarioCanalBindingSource.DataMember = "UsuarioCanal";
            this.usuarioCanalBindingSource.DataSource = this.sAPDataSet2;
            // 
            // usuarioCanalTableAdapter
            // 
            this.usuarioCanalTableAdapter.ClearBeforeFill = true;
            // 
            // pDVCierreTableAdapter
            // 
            this.pDVCierreTableAdapter.ClearBeforeFill = true;
            // 
            // noPagoCierreTableAdapter
            // 
            this.noPagoCierreTableAdapter.ClearBeforeFill = true;
            // 
            // efectivoCierreTableAdapter
            // 
            this.efectivoCierreTableAdapter.ClearBeforeFill = true;
            // 
            // resumenTransfTableAdapter
            // 
            this.resumenTransfTableAdapter.ClearBeforeFill = true;
            // 
            // tarjetaExpressReporte11TableAdapter
            // 
            this.tarjetaExpressReporte11TableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // resumenBiopagoBindingSource
            // 
            this.resumenBiopagoBindingSource.DataMember = "ResumenBiopago";
            this.resumenBiopagoBindingSource.DataSource = this.sAPDataSet2;
            // 
            // resumenBiopagoTableAdapter
            // 
            this.resumenBiopagoTableAdapter.ClearBeforeFill = true;
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
            // Avance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 466);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Avance";
            this.Text = "Avance";
            this.Load += new System.EventHandler(this.Avance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.efectivoCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDVCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPagoCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resumenTransfBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressReporte11BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarjetaExpressDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioCanalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resumenBiopagoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SAPDataSet2 sAPDataSet2;
        private System.Windows.Forms.BindingSource pDVCierreBindingSource;
        private SAPDataSet sAPDataSet;
        private System.Windows.Forms.BindingSource noPagoCierreBindingSource;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private System.Windows.Forms.BindingSource usuarioCanalBindingSource;
        private SAPDataSetTableAdapters.PDVCierreTableAdapter pDVCierreTableAdapter;
        private SAPDataSetTableAdapters.NoPagoCierreTableAdapter noPagoCierreTableAdapter;
        private SAPDataSet2TableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private SAPDataSet2TableAdapters.UsuarioCanalTableAdapter usuarioCanalTableAdapter;
        private System.Windows.Forms.BindingSource efectivoCierreBindingSource;
        private SAPDataSetTableAdapters.EfectivoCierreTableAdapter efectivoCierreTableAdapter;
        private System.Windows.Forms.BindingSource resumenTransfBindingSource;
        private System.Windows.Forms.BindingSource tarjetaExpressReporte11BindingSource;
        private TarjetaExpressDataSet tarjetaExpressDataSet;
        private SAPDataSet2TableAdapters.ResumenTransfTableAdapter resumenTransfTableAdapter;
        private TarjetaExpressDataSetTableAdapters.TarjetaExpressReporte11TableAdapter tarjetaExpressReporte11TableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource resumenBiopagoBindingSource;
        private SAPDataSet2TableAdapters.ResumenBiopagoTableAdapter resumenBiopagoTableAdapter;
        private SAPDataSet2TableAdapters.TableAdapterManager tableAdapterManager;
    }
}