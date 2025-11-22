namespace SAP.Tesoreria.Controles.Declaraciones
{
    partial class Declaracion
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
            this.declaracionV2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAPDataSet2 = new SAP.SAPDataSet2();
            this.pDVCierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAPDataSet = new SAP.SAPDataSet();
            this.efectivoCierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ticketCierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noPagoCierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoVehiculosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuarioCanalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreBalanceV2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transferenciaCierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreTarjetaExpressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buzonRecaudadorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.declaracionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pDVCierreTableAdapter = new SAP.SAPDataSetTableAdapters.PDVCierreTableAdapter();
            this.efectivoCierreTableAdapter = new SAP.SAPDataSetTableAdapters.EfectivoCierreTableAdapter();
            this.ticketCierreTableAdapter = new SAP.SAPDataSetTableAdapters.TicketCierreTableAdapter();
            this.noPagoCierreTableAdapter = new SAP.SAPDataSetTableAdapters.NoPagoCierreTableAdapter();
            this.tipoVehiculosTableAdapter = new SAP.SAPDataSetTableAdapters.TipoVehiculosTableAdapter();
            this.declaracionTableAdapter = new SAP.SAPDataSetTableAdapters.DeclaracionTableAdapter();
            this.tipoVehiculosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.declaracionV2TableAdapter = new SAP.SAPDataSet2TableAdapters.DeclaracionV2TableAdapter();
            this.tipoVehiculosTableAdapter1 = new SAP.SAPDataSet2TableAdapters.TipoVehiculosTableAdapter();
            this.usuariosTableAdapter = new SAP.SAPDataSet2TableAdapters.UsuariosTableAdapter();
            this.usuarioCanalTableAdapter = new SAP.SAPDataSet2TableAdapters.UsuarioCanalTableAdapter();
            this.cierreBalanceV2TableAdapter = new SAP.SAPDataSet2TableAdapters.CierreBalanceV2TableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Titulos = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.transferenciaCierreTableAdapter = new SAP.SAPDataSet2TableAdapters.TransferenciaCierreTableAdapter();
            this.cierreTarjetaExpressTableAdapter = new SAP.SAPDataSet2TableAdapters.CierreTarjetaExpressTableAdapter();
            this.buzonRecaudadorTableAdapter = new SAP.SAPDataSet2TableAdapters.BuzonRecaudadorTableAdapter();
            this.tableAdapterManager = new SAP.SAPDataSet2TableAdapters.TableAdapterManager();
            this.cierreBiopagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreBiopagoTableAdapter = new SAP.SAPDataSet2TableAdapters.CierreBiopagoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.declaracionV2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDVCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efectivoCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPagoCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoVehiculosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioCanalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBalanceV2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferenciaCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTarjetaExpressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buzonRecaudadorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.declaracionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoVehiculosBindingSource1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBiopagoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // declaracionV2BindingSource
            // 
            this.declaracionV2BindingSource.DataMember = "DeclaracionV2";
            this.declaracionV2BindingSource.DataSource = this.sAPDataSet2;
            // 
            // sAPDataSet2
            // 
            this.sAPDataSet2.DataSetName = "SAPDataSet2";
            this.sAPDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pDVCierreBindingSource
            // 
            this.pDVCierreBindingSource.DataMember = "PDVCierre";
            this.pDVCierreBindingSource.DataSource = this.sAPDataSet;
            // 
            // sAPDataSet
            // 
            this.sAPDataSet.DataSetName = "SAPDataSet";
            this.sAPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // efectivoCierreBindingSource
            // 
            this.efectivoCierreBindingSource.DataMember = "EfectivoCierre";
            this.efectivoCierreBindingSource.DataSource = this.sAPDataSet;
            // 
            // ticketCierreBindingSource
            // 
            this.ticketCierreBindingSource.DataMember = "TicketCierre";
            this.ticketCierreBindingSource.DataSource = this.sAPDataSet;
            // 
            // noPagoCierreBindingSource
            // 
            this.noPagoCierreBindingSource.DataMember = "NoPagoCierre";
            this.noPagoCierreBindingSource.DataSource = this.sAPDataSet;
            // 
            // tipoVehiculosBindingSource
            // 
            this.tipoVehiculosBindingSource.DataMember = "TipoVehiculos";
            this.tipoVehiculosBindingSource.DataSource = this.sAPDataSet;
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "Usuarios";
            this.usuariosBindingSource.DataSource = this.sAPDataSet2;
            // 
            // usuarioCanalBindingSource
            // 
            this.usuarioCanalBindingSource.DataMember = "UsuarioCanal";
            this.usuarioCanalBindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierreBalanceV2BindingSource
            // 
            this.cierreBalanceV2BindingSource.DataMember = "CierreBalanceV2";
            this.cierreBalanceV2BindingSource.DataSource = this.sAPDataSet2;
            // 
            // transferenciaCierreBindingSource
            // 
            this.transferenciaCierreBindingSource.DataMember = "TransferenciaCierre";
            this.transferenciaCierreBindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierreTarjetaExpressBindingSource
            // 
            this.cierreTarjetaExpressBindingSource.DataMember = "CierreTarjetaExpress";
            this.cierreTarjetaExpressBindingSource.DataSource = this.sAPDataSet2;
            // 
            // buzonRecaudadorBindingSource
            // 
            this.buzonRecaudadorBindingSource.DataMember = "BuzonRecaudador";
            this.buzonRecaudadorBindingSource.DataSource = this.sAPDataSet2;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Tesoreria.Controles.Declaraciones.DeclaracionJurada.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(624, 631);
            this.reportViewer1.TabIndex = 0;
            // 
            // declaracionBindingSource
            // 
            this.declaracionBindingSource.DataMember = "Declaracion";
            this.declaracionBindingSource.DataSource = this.sAPDataSet;
            // 
            // pDVCierreTableAdapter
            // 
            this.pDVCierreTableAdapter.ClearBeforeFill = true;
            // 
            // efectivoCierreTableAdapter
            // 
            this.efectivoCierreTableAdapter.ClearBeforeFill = true;
            // 
            // ticketCierreTableAdapter
            // 
            this.ticketCierreTableAdapter.ClearBeforeFill = true;
            // 
            // noPagoCierreTableAdapter
            // 
            this.noPagoCierreTableAdapter.ClearBeforeFill = true;
            // 
            // tipoVehiculosTableAdapter
            // 
            this.tipoVehiculosTableAdapter.ClearBeforeFill = true;
            // 
            // declaracionTableAdapter
            // 
            this.declaracionTableAdapter.ClearBeforeFill = true;
            // 
            // tipoVehiculosBindingSource1
            // 
            this.tipoVehiculosBindingSource1.DataMember = "TipoVehiculos";
            this.tipoVehiculosBindingSource1.DataSource = this.sAPDataSet2;
            // 
            // declaracionV2TableAdapter
            // 
            this.declaracionV2TableAdapter.ClearBeforeFill = true;
            // 
            // tipoVehiculosTableAdapter1
            // 
            this.tipoVehiculosTableAdapter1.ClearBeforeFill = true;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // usuarioCanalTableAdapter
            // 
            this.usuarioCanalTableAdapter.ClearBeforeFill = true;
            // 
            // cierreBalanceV2TableAdapter
            // 
            this.cierreBalanceV2TableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.Titulos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.451613F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.54839F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 687);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Titulos
            // 
            this.Titulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Titulos.AutoSize = true;
            this.Titulos.BackColor = System.Drawing.Color.DimGray;
            this.Titulos.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.Titulos.ForeColor = System.Drawing.Color.White;
            this.Titulos.Location = new System.Drawing.Point(3, 0);
            this.Titulos.Name = "Titulos";
            this.Titulos.Size = new System.Drawing.Size(630, 44);
            this.Titulos.TabIndex = 1042;
            this.Titulos.Text = "CIERRE DE RECAUDADOR";
            this.Titulos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.reportViewer1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 47);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(630, 637);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // transferenciaCierreTableAdapter
            // 
            this.transferenciaCierreTableAdapter.ClearBeforeFill = true;
            // 
            // cierreTarjetaExpressTableAdapter
            // 
            this.cierreTarjetaExpressTableAdapter.ClearBeforeFill = true;
            // 
            // buzonRecaudadorTableAdapter
            // 
            this.buzonRecaudadorTableAdapter.ClearBeforeFill = true;
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
            // cierreBiopagoBindingSource
            // 
            this.cierreBiopagoBindingSource.DataMember = "CierreBiopago";
            this.cierreBiopagoBindingSource.DataSource = this.sAPDataSet2;
            // 
            // cierreBiopagoTableAdapter
            // 
            this.cierreBiopagoTableAdapter.ClearBeforeFill = true;
            // 
            // Declaracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(637, 687);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Declaracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Declaracion";
            this.Load += new System.EventHandler(this.Declaracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.declaracionV2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDVCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efectivoCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPagoCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoVehiculosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioCanalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreBalanceV2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferenciaCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreTarjetaExpressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buzonRecaudadorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.declaracionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoVehiculosBindingSource1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cierreBiopagoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource pDVCierreBindingSource;
        private SAPDataSet sAPDataSet;
        private System.Windows.Forms.BindingSource efectivoCierreBindingSource;
        private System.Windows.Forms.BindingSource ticketCierreBindingSource;
        private System.Windows.Forms.BindingSource noPagoCierreBindingSource;
        private System.Windows.Forms.BindingSource tipoVehiculosBindingSource;
        private System.Windows.Forms.BindingSource declaracionBindingSource;
        private SAPDataSetTableAdapters.PDVCierreTableAdapter pDVCierreTableAdapter;
        private SAPDataSetTableAdapters.EfectivoCierreTableAdapter efectivoCierreTableAdapter;
        private SAPDataSetTableAdapters.TicketCierreTableAdapter ticketCierreTableAdapter;
        private SAPDataSetTableAdapters.NoPagoCierreTableAdapter noPagoCierreTableAdapter;
        private SAPDataSetTableAdapters.TipoVehiculosTableAdapter tipoVehiculosTableAdapter;
        private SAPDataSetTableAdapters.DeclaracionTableAdapter declaracionTableAdapter;
        private System.Windows.Forms.BindingSource declaracionV2BindingSource;
        private SAPDataSet2 sAPDataSet2;
        private SAPDataSet2TableAdapters.DeclaracionV2TableAdapter declaracionV2TableAdapter;
        private System.Windows.Forms.BindingSource tipoVehiculosBindingSource1;
        private SAPDataSet2TableAdapters.TipoVehiculosTableAdapter tipoVehiculosTableAdapter1;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private SAPDataSet2TableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.BindingSource usuarioCanalBindingSource;
        private SAPDataSet2TableAdapters.UsuarioCanalTableAdapter usuarioCanalTableAdapter;
        private System.Windows.Forms.BindingSource cierreBalanceV2BindingSource;
        private SAPDataSet2TableAdapters.CierreBalanceV2TableAdapter cierreBalanceV2TableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label Titulos;
        private System.Windows.Forms.BindingSource transferenciaCierreBindingSource;
        private System.Windows.Forms.BindingSource cierreTarjetaExpressBindingSource;
        private SAPDataSet2TableAdapters.TransferenciaCierreTableAdapter transferenciaCierreTableAdapter;
        private SAPDataSet2TableAdapters.CierreTarjetaExpressTableAdapter cierreTarjetaExpressTableAdapter;
        private System.Windows.Forms.BindingSource buzonRecaudadorBindingSource;
        private SAPDataSet2TableAdapters.BuzonRecaudadorTableAdapter buzonRecaudadorTableAdapter;
        private SAPDataSet2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource cierreBiopagoBindingSource;
        private SAPDataSet2TableAdapters.CierreBiopagoTableAdapter cierreBiopagoTableAdapter;
    }
}