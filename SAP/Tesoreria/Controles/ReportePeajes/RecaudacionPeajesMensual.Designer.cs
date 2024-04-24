namespace SAP.Tesoreria.Controles.ReportePeajes
{
    partial class RecaudacionPeajesMensual
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
            this.efectivoMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAPDataSet2 = new SAP.SAPDataSet2();
            this.pDVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.efectivoEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAPDataSet3 = new SAP.SAPDataSet3();
            this.pDVEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recargasPeajeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prepagadoDataSet = new SAP.PrepagadoDataSet();
            this.recargasPeaje1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.fecha2 = new System.Windows.Forms.DateTimePicker();
            this.button5 = new System.Windows.Forms.Button();
            this.efectivoMTableAdapter = new SAP.SAPDataSet2TableAdapters.EfectivoMTableAdapter();
            this.pDVMTableAdapter = new SAP.SAPDataSet2TableAdapters.PDVMTableAdapter();
            this.efectivoETableAdapter = new SAP.SAPDataSet3TableAdapters.EfectivoETableAdapter();
            this.pDVETableAdapter = new SAP.SAPDataSet3TableAdapters.PDVETableAdapter();
            this.recargasPeajeTableAdapter = new SAP.PrepagadoDataSetTableAdapters.RecargasPeajeTableAdapter();
            this.recargasPeaje1TableAdapter = new SAP.PrepagadoDataSetTableAdapters.RecargasPeaje1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.efectivoMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efectivoEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDVEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recargasPeajeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prepagadoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recargasPeaje1BindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // efectivoMBindingSource
            // 
            this.efectivoMBindingSource.DataMember = "EfectivoM";
            this.efectivoMBindingSource.DataSource = this.sAPDataSet2;
            // 
            // sAPDataSet2
            // 
            this.sAPDataSet2.DataSetName = "SAPDataSet2";
            this.sAPDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pDVMBindingSource
            // 
            this.pDVMBindingSource.DataMember = "PDVM";
            this.pDVMBindingSource.DataSource = this.sAPDataSet2;
            // 
            // efectivoEBindingSource
            // 
            this.efectivoEBindingSource.DataMember = "EfectivoE";
            this.efectivoEBindingSource.DataSource = this.sAPDataSet3;
            // 
            // sAPDataSet3
            // 
            this.sAPDataSet3.DataSetName = "SAPDataSet3";
            this.sAPDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pDVEBindingSource
            // 
            this.pDVEBindingSource.DataMember = "PDVE";
            this.pDVEBindingSource.DataSource = this.sAPDataSet3;
            // 
            // recargasPeajeBindingSource
            // 
            this.recargasPeajeBindingSource.DataMember = "RecargasPeaje";
            this.recargasPeajeBindingSource.DataSource = this.prepagadoDataSet;
            // 
            // prepagadoDataSet
            // 
            this.prepagadoDataSet.DataSetName = "PrepagadoDataSet";
            this.prepagadoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recargasPeaje1BindingSource
            // 
            this.recargasPeaje1BindingSource.DataMember = "RecargasPeaje1";
            this.recargasPeaje1BindingSource.DataSource = this.prepagadoDataSet;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-3, -2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.85342F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.14658F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(932, 522);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EfectivoG";
            reportDataSource1.Value = this.efectivoMBindingSource;
            reportDataSource2.Name = "PDVG";
            reportDataSource2.Value = this.pDVMBindingSource;
            reportDataSource3.Name = "EfectivoE";
            reportDataSource3.Value = this.efectivoEBindingSource;
            reportDataSource4.Name = "PDVE";
            reportDataSource4.Value = this.pDVEBindingSource;
            reportDataSource5.Name = "RecargasG";
            reportDataSource5.Value = this.recargasPeajeBindingSource;
            reportDataSource6.Name = "RecargasE";
            reportDataSource6.Value = this.recargasPeaje1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SAP.Tesoreria.Controles.ReportePeajes.RecaudacionPeaje.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(926, 436);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.RecaudacionPeajes_Load);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.66292F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.45506F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.57303F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.17416F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.99438F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.date1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.fecha2, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.button5, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 445);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.09091F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(926, 74);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(49)))), ((int)(((byte)(65)))));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 74);
            this.label2.TabIndex = 33;
            this.label2.Text = "FECHA INICIAL:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(49)))), ((int)(((byte)(65)))));
            this.label1.Location = new System.Drawing.Point(402, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 74);
            this.label1.TabIndex = 34;
            this.label1.Text = "FECHA LIMITE:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // date1
            // 
            this.date1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.date1.CustomFormat = "dd/MM/yyyy";
            this.date1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date1.Location = new System.Drawing.Point(185, 3);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(211, 26);
            this.date1.TabIndex = 39;
            // 
            // fecha2
            // 
            this.fecha2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fecha2.CustomFormat = "dd/MM/yyyy";
            this.fecha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha2.Location = new System.Drawing.Point(555, 3);
            this.fecha2.Name = "fecha2";
            this.fecha2.Size = new System.Drawing.Size(208, 26);
            this.fecha2.TabIndex = 40;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.AutoSize = true;
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(49)))), ((int)(((byte)(65)))));
            this.button5.FlatAppearance.BorderSize = 3;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Location = new System.Drawing.Point(769, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 68);
            this.button5.TabIndex = 8;
            this.button5.Text = "FILTRAR";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // efectivoMTableAdapter
            // 
            this.efectivoMTableAdapter.ClearBeforeFill = true;
            // 
            // pDVMTableAdapter
            // 
            this.pDVMTableAdapter.ClearBeforeFill = true;
            // 
            // efectivoETableAdapter
            // 
            this.efectivoETableAdapter.ClearBeforeFill = true;
            // 
            // pDVETableAdapter
            // 
            this.pDVETableAdapter.ClearBeforeFill = true;
            // 
            // recargasPeajeTableAdapter
            // 
            this.recargasPeajeTableAdapter.ClearBeforeFill = true;
            // 
            // recargasPeaje1TableAdapter
            // 
            this.recargasPeaje1TableAdapter.ClearBeforeFill = true;
            // 
            // RecaudacionPeajesMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 519);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RecaudacionPeajesMensual";
            this.Text = "RecaudacionPeajesMensual";
            this.Load += new System.EventHandler(this.RecaudacionPeajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.efectivoMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efectivoEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAPDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDVEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recargasPeajeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prepagadoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recargasPeaje1BindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.DateTimePicker fecha2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.BindingSource efectivoMBindingSource;
        private SAPDataSet2 sAPDataSet2;
        private System.Windows.Forms.BindingSource pDVMBindingSource;
        private System.Windows.Forms.BindingSource efectivoEBindingSource;
        private SAPDataSet3 sAPDataSet3;
        private System.Windows.Forms.BindingSource pDVEBindingSource;
        private System.Windows.Forms.BindingSource recargasPeajeBindingSource;
        private PrepagadoDataSet prepagadoDataSet;
        private System.Windows.Forms.BindingSource recargasPeaje1BindingSource;
        private SAPDataSet2TableAdapters.EfectivoMTableAdapter efectivoMTableAdapter;
        private SAPDataSet2TableAdapters.PDVMTableAdapter pDVMTableAdapter;
        private SAPDataSet3TableAdapters.EfectivoETableAdapter efectivoETableAdapter;
        private SAPDataSet3TableAdapters.PDVETableAdapter pDVETableAdapter;
        private PrepagadoDataSetTableAdapters.RecargasPeajeTableAdapter recargasPeajeTableAdapter;
        private PrepagadoDataSetTableAdapters.RecargasPeaje1TableAdapter recargasPeaje1TableAdapter;
    }
}