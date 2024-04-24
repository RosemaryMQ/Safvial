namespace SAP.Recaudadores.SafvialWeb
{
    partial class ReporteAprobadasV2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.safvialWeb = new SAP.SafvialWeb();
            this.solicitudesWEB2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.solicitudesWEB2TableAdapter = new SAP.SafvialWebTableAdapters.SolicitudesWEB2TableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.safvialWeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudesWEB2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.94643F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(662, 510);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OperacionesV3";
            reportDataSource1.Value = this.solicitudesWEB2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Recaudadores.SafvialWeb.Reportes.OperacionesPendientes - Copia.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(656, 504);
            this.reportViewer1.TabIndex = 0;
            // 
            // safvialWeb
            // 
            this.safvialWeb.DataSetName = "SafvialWeb";
            this.safvialWeb.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // solicitudesWEB2BindingSource
            // 
            this.solicitudesWEB2BindingSource.DataMember = "SolicitudesWEB2";
            this.solicitudesWEB2BindingSource.DataSource = this.safvialWeb;
            // 
            // solicitudesWEB2TableAdapter
            // 
            this.solicitudesWEB2TableAdapter.ClearBeforeFill = true;
            // 
            // ReporteAprobadasV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReporteAprobadasV2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteAprobadasV2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteAprobadasV2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.safvialWeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudesWEB2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource solicitudesWEB2BindingSource;
        private SAP.SafvialWeb safvialWeb;
        private SafvialWebTableAdapters.SolicitudesWEB2TableAdapter solicitudesWEB2TableAdapter;
    }
}