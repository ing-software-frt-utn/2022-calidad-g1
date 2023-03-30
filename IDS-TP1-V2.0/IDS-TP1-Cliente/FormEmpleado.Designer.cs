namespace IDS_TP1_Cliente {
	partial class FormEmpleado {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.numLegajo = new System.Windows.Forms.NumericUpDown();
			this.numDNI = new System.Windows.Forms.NumericUpDown();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.txtApellido = new System.Windows.Forms.TextBox();
			this.dtFecha = new System.Windows.Forms.DateTimePicker();
			this.cmbRol = new System.Windows.Forms.ComboBox();
			this.txtCorreo = new System.Windows.Forms.TextBox();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.txtContraseña = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.txtContraseña2 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numLegajo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDNI)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Legajo:";
			// 
			// numLegajo
			// 
			this.numLegajo.Location = new System.Drawing.Point(145, 7);
			this.numLegajo.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numLegajo.Name = "numLegajo";
			this.numLegajo.Size = new System.Drawing.Size(254, 20);
			this.numLegajo.TabIndex = 1;
			// 
			// numDNI
			// 
			this.numDNI.Location = new System.Drawing.Point(145, 33);
			this.numDNI.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numDNI.Name = "numDNI";
			this.numDNI.Size = new System.Drawing.Size(254, 20);
			this.numDNI.TabIndex = 2;
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(145, 59);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(254, 20);
			this.txtNombre.TabIndex = 3;
			// 
			// txtApellido
			// 
			this.txtApellido.Location = new System.Drawing.Point(145, 85);
			this.txtApellido.Name = "txtApellido";
			this.txtApellido.Size = new System.Drawing.Size(254, 20);
			this.txtApellido.TabIndex = 4;
			// 
			// dtFecha
			// 
			this.dtFecha.Location = new System.Drawing.Point(145, 111);
			this.dtFecha.Name = "dtFecha";
			this.dtFecha.Size = new System.Drawing.Size(254, 20);
			this.dtFecha.TabIndex = 5;
			// 
			// cmbRol
			// 
			this.cmbRol.FormattingEnabled = true;
			this.cmbRol.Items.AddRange(new object[] {
            "Supervisor de calidad",
            "Supervisor de línea",
            "Administrativo"});
			this.cmbRol.Location = new System.Drawing.Point(144, 137);
			this.cmbRol.Name = "cmbRol";
			this.cmbRol.Size = new System.Drawing.Size(255, 21);
			this.cmbRol.TabIndex = 6;
			// 
			// txtCorreo
			// 
			this.txtCorreo.Location = new System.Drawing.Point(144, 164);
			this.txtCorreo.Name = "txtCorreo";
			this.txtCorreo.Size = new System.Drawing.Size(255, 20);
			this.txtCorreo.TabIndex = 7;
			// 
			// txtUsuario
			// 
			this.txtUsuario.Location = new System.Drawing.Point(144, 190);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(255, 20);
			this.txtUsuario.TabIndex = 8;
			// 
			// txtContraseña
			// 
			this.txtContraseña.Location = new System.Drawing.Point(144, 216);
			this.txtContraseña.Name = "txtContraseña";
			this.txtContraseña.PasswordChar = '*';
			this.txtContraseña.Size = new System.Drawing.Size(255, 20);
			this.txtContraseña.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "DNI:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Nombre:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Apellido:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 117);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(109, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Fecha de nacimiento:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 140);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(26, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Rol:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 167);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Correo:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 193);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Usuario:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 219);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "Contraseña:";
			// 
			// btnAceptar
			// 
			this.btnAceptar.Location = new System.Drawing.Point(324, 277);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 23);
			this.btnAceptar.TabIndex = 11;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(12, 277);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 12;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
			// 
			// txtContraseña2
			// 
			this.txtContraseña2.Location = new System.Drawing.Point(144, 242);
			this.txtContraseña2.Name = "txtContraseña2";
			this.txtContraseña2.PasswordChar = '*';
			this.txtContraseña2.Size = new System.Drawing.Size(255, 20);
			this.txtContraseña2.TabIndex = 10;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(12, 245);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(110, 13);
			this.label10.TabIndex = 0;
			this.label10.Text = "Confirmar contraseña:";
			// 
			// FormEmpleado
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(411, 312);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.cmbRol);
			this.Controls.Add(this.dtFecha);
			this.Controls.Add(this.txtApellido);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.txtContraseña2);
			this.Controls.Add(this.txtContraseña);
			this.Controls.Add(this.txtUsuario);
			this.Controls.Add(this.txtCorreo);
			this.Controls.Add(this.numDNI);
			this.Controls.Add(this.numLegajo);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormEmpleado";
			this.Text = "FormEmpleado";
			((System.ComponentModel.ISupportInitialize)(this.numLegajo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDNI)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numLegajo;
		private System.Windows.Forms.NumericUpDown numDNI;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.TextBox txtApellido;
		private System.Windows.Forms.DateTimePicker dtFecha;
		private System.Windows.Forms.ComboBox cmbRol;
		private System.Windows.Forms.TextBox txtCorreo;
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.TextBox txtContraseña;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TextBox txtContraseña2;
		private System.Windows.Forms.Label label10;
	}
}