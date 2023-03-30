namespace IDS_TP1_Cliente {
	partial class FormHermanado {
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
			this.numPrimera = new System.Windows.Forms.NumericUpDown();
			this.numSegunda = new System.Windows.Forms.NumericUpDown();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numPrimera)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSegunda)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Pares de primera:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(213, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Pares de segunda:";
			// 
			// numPrimera
			// 
			this.numPrimera.Location = new System.Drawing.Point(15, 25);
			this.numPrimera.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
			this.numPrimera.Name = "numPrimera";
			this.numPrimera.Size = new System.Drawing.Size(120, 20);
			this.numPrimera.TabIndex = 1;
			// 
			// numSegunda
			// 
			this.numSegunda.Location = new System.Drawing.Point(216, 25);
			this.numSegunda.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
			this.numSegunda.Name = "numSegunda";
			this.numSegunda.Size = new System.Drawing.Size(120, 20);
			this.numSegunda.TabIndex = 1;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Location = new System.Drawing.Point(216, 107);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(120, 23);
			this.btnAceptar.TabIndex = 2;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(15, 107);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(120, 23);
			this.btnCancelar.TabIndex = 2;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
			// 
			// FormHermanado
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(348, 142);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.numSegunda);
			this.Controls.Add(this.numPrimera);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormHermanado";
			this.Text = "Hermanado de calzado";
			((System.ComponentModel.ISupportInitialize)(this.numPrimera)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSegunda)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numPrimera;
		private System.Windows.Forms.NumericUpDown numSegunda;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
	}
}