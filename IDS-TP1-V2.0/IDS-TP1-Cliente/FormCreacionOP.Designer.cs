namespace IDS_TP1_Cliente {
	partial class FormCreacionOP {
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbLinea = new System.Windows.Forms.ComboBox();
			this.cmbColor = new System.Windows.Forms.ComboBox();
			this.cmbModelo = new System.Windows.Forms.ComboBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Numero:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Linea:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Color:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Modelo:";
			// 
			// cmbLinea
			// 
			this.cmbLinea.DisplayMember = "Numero";
			this.cmbLinea.FormattingEnabled = true;
			this.cmbLinea.Location = new System.Drawing.Point(148, 39);
			this.cmbLinea.Name = "cmbLinea";
			this.cmbLinea.Size = new System.Drawing.Size(303, 21);
			this.cmbLinea.TabIndex = 2;
			// 
			// cmbColor
			// 
			this.cmbColor.DisplayMember = "Descripcion";
			this.cmbColor.FormattingEnabled = true;
			this.cmbColor.Location = new System.Drawing.Point(148, 66);
			this.cmbColor.Name = "cmbColor";
			this.cmbColor.Size = new System.Drawing.Size(303, 21);
			this.cmbColor.TabIndex = 3;
			// 
			// cmbModelo
			// 
			this.cmbModelo.DisplayMember = "Denominacion";
			this.cmbModelo.FormattingEnabled = true;
			this.cmbModelo.Location = new System.Drawing.Point(148, 93);
			this.cmbModelo.Name = "cmbModelo";
			this.cmbModelo.Size = new System.Drawing.Size(303, 21);
			this.cmbModelo.TabIndex = 4;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Location = new System.Drawing.Point(291, 126);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(160, 23);
			this.btnAceptar.TabIndex = 5;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(12, 126);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(160, 23);
			this.btnCancelar.TabIndex = 5;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(148, 10);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(303, 20);
			this.txtNumero.TabIndex = 1;
			// 
			// FormCreacionOP
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(463, 161);
			this.Controls.Add(this.txtNumero);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.cmbModelo);
			this.Controls.Add(this.cmbColor);
			this.Controls.Add(this.cmbLinea);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormCreacionOP";
			this.Text = "Creacion de orden de produccion";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbLinea;
		private System.Windows.Forms.ComboBox cmbColor;
		private System.Windows.Forms.ComboBox cmbModelo;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TextBox txtNumero;
	}
}