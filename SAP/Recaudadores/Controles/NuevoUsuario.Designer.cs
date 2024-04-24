namespace SAP.Recaudadores.Controles
{
    partial class NuevoUsuario
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
            this.TipoUsuario = new System.Windows.Forms.Label();
            this.Contraseña = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.NickName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Turno = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Apellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TipoUsuario
            // 
            this.TipoUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TipoUsuario.AutoSize = true;
            this.TipoUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoUsuario.Location = new System.Drawing.Point(189, 154);
            this.TipoUsuario.Name = "TipoUsuario";
            this.TipoUsuario.Size = new System.Drawing.Size(84, 19);
            this.TipoUsuario.TabIndex = 1058;
            this.TipoUsuario.Text = "Cobrador";
            this.TipoUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Contraseña
            // 
            this.Contraseña.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Contraseña.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Contraseña.Location = new System.Drawing.Point(135, 267);
            this.Contraseña.MaxLength = 12;
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(267, 27);
            this.Contraseña.TabIndex = 1045;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(10, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 19);
            this.label11.TabIndex = 1057;
            this.label11.Text = "CONTRASEÑA:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(137, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 15);
            this.label10.TabIndex = 1056;
            this.label10.Text = "Formato: V123456789";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NickName
            // 
            this.NickName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NickName.Enabled = false;
            this.NickName.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.NickName.Location = new System.Drawing.Point(135, 220);
            this.NickName.MaxLength = 12;
            this.NickName.Name = "NickName";
            this.NickName.Size = new System.Drawing.Size(267, 27);
            this.NickName.TabIndex = 1044;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(36, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 19);
            this.label7.TabIndex = 1055;
            this.label7.Text = "USUARIO:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Turno
            // 
            this.Turno.BackColor = System.Drawing.SystemColors.Control;
            this.Turno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Turno.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Turno.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Turno.FormattingEnabled = true;
            this.Turno.Items.AddRange(new object[] {
            "ROTATIVO"});
            this.Turno.Location = new System.Drawing.Point(135, 183);
            this.Turno.Name = "Turno";
            this.Turno.Size = new System.Drawing.Size(267, 29);
            this.Turno.TabIndex = 1043;
            this.Turno.Tag = "Seleccione Cuenta";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(44, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 19);
            this.label9.TabIndex = 1054;
            this.label9.Text = "TURNO:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 19);
            this.label5.TabIndex = 1052;
            this.label5.Text = "TIPO DE USUARIO:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DNI
            // 
            this.DNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DNI.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.DNI.Location = new System.Drawing.Point(135, 115);
            this.DNI.MaxLength = 12;
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(267, 27);
            this.DNI.TabIndex = 1042;
            this.DNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DNI_KeyPress);
            this.DNI.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DNI_KeyUp);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(36, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 1051;
            this.label4.Text = "CEDULA:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Apellido
            // 
            this.Apellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Apellido.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Apellido.Location = new System.Drawing.Point(135, 83);
            this.Apellido.MaxLength = 30;
            this.Apellido.Name = "Apellido";
            this.Apellido.Size = new System.Drawing.Size(267, 27);
            this.Apellido.TabIndex = 1041;
            this.Apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Nombre_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 1050;
            this.label3.Text = "APELLIDOS:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Nombre
            // 
            this.Nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nombre.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Nombre.Location = new System.Drawing.Point(135, 51);
            this.Nombre.MaxLength = 30;
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(267, 27);
            this.Nombre.TabIndex = 1040;
            this.Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Nombre_KeyPress);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(49)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(234, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 47);
            this.button1.TabIndex = 1046;
            this.button1.Text = "APERTURAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(49)))), ((int)(((byte)(65)))));
            this.button2.FlatAppearance.BorderSize = 3;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(20, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 47);
            this.button2.TabIndex = 1047;
            this.button2.Text = "CERRAR VENTANA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 1049;
            this.label1.Text = "NOMBRES:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.label2.Location = new System.Drawing.Point(61, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 25);
            this.label2.TabIndex = 1048;
            this.label2.Text = "AGREGAR NUEVO USUARIO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(422, 367);
            this.Controls.Add(this.TipoUsuario);
            this.Controls.Add(this.Contraseña);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.NickName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Turno);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DNI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Apellido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NuevoUsuario";
            this.Text = "Nuevo Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TipoUsuario;
        private System.Windows.Forms.TextBox Contraseña;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox NickName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Turno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DNI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Apellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}