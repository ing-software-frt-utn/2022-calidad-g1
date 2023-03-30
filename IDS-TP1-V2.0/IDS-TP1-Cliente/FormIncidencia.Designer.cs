namespace IDS_TP1_Cliente {
	partial class FormIncidencia {
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
			this.lstDefectos = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDefecto = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbHora = new System.Windows.Forms.ComboBox();
			this.cbHoraActual = new System.Windows.Forms.CheckBox();
			this.btnPrimera = new System.Windows.Forms.Button();
			this.rdDerecho = new System.Windows.Forms.RadioButton();
			this.rdIzquierdo = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lstDefectos
			// 
			this.lstDefectos.FormattingEnabled = true;
			this.lstDefectos.Location = new System.Drawing.Point(9, 108);
			this.lstDefectos.Name = "lstDefectos";
			this.lstDefectos.Size = new System.Drawing.Size(394, 251);
			this.lstDefectos.TabIndex = 0;
			this.lstDefectos.SelectedIndexChanged += new System.EventHandler(this.LstDefectos_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 85);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Defectos:";
			// 
			// btnDefecto
			// 
			this.btnDefecto.Location = new System.Drawing.Point(218, 46);
			this.btnDefecto.Name = "btnDefecto";
			this.btnDefecto.Size = new System.Drawing.Size(118, 23);
			this.btnDefecto.TabIndex = 5;
			this.btnDefecto.Text = "Registrar defecto";
			this.btnDefecto.UseVisualStyleBackColor = true;
			this.btnDefecto.Click += new System.EventHandler(this.BtnDefecto_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(90, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Hora:";
			// 
			// cmbHora
			// 
			this.cmbHora.FormattingEnabled = true;
			this.cmbHora.Location = new System.Drawing.Point(129, 12);
			this.cmbHora.Name = "cmbHora";
			this.cmbHora.Size = new System.Drawing.Size(83, 21);
			this.cmbHora.TabIndex = 3;
			// 
			// cbHoraActual
			// 
			this.cbHoraActual.AutoSize = true;
			this.cbHoraActual.Checked = true;
			this.cbHoraActual.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbHoraActual.Location = new System.Drawing.Point(218, 14);
			this.cbHoraActual.Name = "cbHoraActual";
			this.cbHoraActual.Size = new System.Drawing.Size(104, 17);
			this.cbHoraActual.TabIndex = 4;
			this.cbHoraActual.Text = "Usar hora actual";
			this.cbHoraActual.UseVisualStyleBackColor = true;
			this.cbHoraActual.CheckedChanged += new System.EventHandler(this.CbHoraActual_CheckedChanged);
			// 
			// btnPrimera
			// 
			this.btnPrimera.Location = new System.Drawing.Point(55, 46);
			this.btnPrimera.Name = "btnPrimera";
			this.btnPrimera.Size = new System.Drawing.Size(157, 23);
			this.btnPrimera.TabIndex = 5;
			this.btnPrimera.Text = "Registrar par de primera";
			this.btnPrimera.UseVisualStyleBackColor = true;
			this.btnPrimera.Click += new System.EventHandler(this.BtnPrimera_Click);
			// 
			// rdDerecho
			// 
			this.rdDerecho.AutoSize = true;
			this.rdDerecho.Location = new System.Drawing.Point(334, 83);
			this.rdDerecho.Name = "rdDerecho";
			this.rdDerecho.Size = new System.Drawing.Size(66, 17);
			this.rdDerecho.TabIndex = 6;
			this.rdDerecho.Text = "Derecho";
			this.rdDerecho.UseVisualStyleBackColor = true;
			// 
			// rdIzquierdo
			// 
			this.rdIzquierdo.AutoSize = true;
			this.rdIzquierdo.Checked = true;
			this.rdIzquierdo.Location = new System.Drawing.Point(260, 83);
			this.rdIzquierdo.Name = "rdIzquierdo";
			this.rdIzquierdo.Size = new System.Drawing.Size(68, 17);
			this.rdIzquierdo.TabIndex = 6;
			this.rdIzquierdo.TabStop = true;
			this.rdIzquierdo.Text = "Izquierdo";
			this.rdIzquierdo.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(229, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Pie:";
			// 
			// FormIncidencia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 373);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rdIzquierdo);
			this.Controls.Add(this.rdDerecho);
			this.Controls.Add(this.btnPrimera);
			this.Controls.Add(this.btnDefecto);
			this.Controls.Add(this.cbHoraActual);
			this.Controls.Add(this.cmbHora);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstDefectos);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormIncidencia";
			this.Text = "Registro de incidencias";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lstDefectos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDefecto;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbHora;
		private System.Windows.Forms.CheckBox cbHoraActual;
		private System.Windows.Forms.Button btnPrimera;
		private System.Windows.Forms.RadioButton rdDerecho;
		private System.Windows.Forms.RadioButton rdIzquierdo;
		private System.Windows.Forms.Label label2;
	}
}