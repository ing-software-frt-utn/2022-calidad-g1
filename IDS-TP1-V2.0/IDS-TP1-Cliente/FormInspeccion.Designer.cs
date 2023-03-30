namespace IDS_TP1_Cliente {
	partial class FormInspeccion {
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
			this.lblOP = new System.Windows.Forms.Label();
			this.lblModelo = new System.Windows.Forms.Label();
			this.lblColor = new System.Windows.Forms.Label();
			this.lblTurno = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnRegistro = new System.Windows.Forms.Button();
			this.btnDesvincular = new System.Windows.Forms.Button();
			this.btnHermanado = new System.Windows.Forms.Button();
			this.lblTotalPrimera = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lblTotalRep = new System.Windows.Forms.Label();
			this.lblTotalObs = new System.Windows.Forms.Label();
			this.lstIncidencias = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblOP
			// 
			this.lblOP.AutoSize = true;
			this.lblOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOP.Location = new System.Drawing.Point(3, 0);
			this.lblOP.Name = "lblOP";
			this.lblOP.Size = new System.Drawing.Size(150, 34);
			this.lblOP.TabIndex = 1;
			this.lblOP.Text = "Orden de produccion: XXXXXXXXXXX";
			this.lblOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblModelo
			// 
			this.lblModelo.AutoSize = true;
			this.lblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblModelo.Location = new System.Drawing.Point(243, 0);
			this.lblModelo.Name = "lblModelo";
			this.lblModelo.Size = new System.Drawing.Size(161, 17);
			this.lblModelo.TabIndex = 2;
			this.lblModelo.Text = "Modelo: XXXXXXXXXXX";
			this.lblModelo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblColor
			// 
			this.lblColor.AutoSize = true;
			this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblColor.Location = new System.Drawing.Point(483, 0);
			this.lblColor.Name = "lblColor";
			this.lblColor.Size = new System.Drawing.Size(94, 17);
			this.lblColor.TabIndex = 2;
			this.lblColor.Text = "Color: XXXXX";
			this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTurno
			// 
			this.lblTurno.AutoSize = true;
			this.lblTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTurno.Location = new System.Drawing.Point(723, 0);
			this.lblTurno.Name = "lblTurno";
			this.lblTurno.Size = new System.Drawing.Size(106, 17);
			this.lblTurno.TabIndex = 2;
			this.lblTurno.Text = "Turno: XX a XX";
			this.lblTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.lblOP, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblTurno, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblModelo, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblColor, 2, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(960, 42);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// btnRegistro
			// 
			this.btnRegistro.Location = new System.Drawing.Point(807, 403);
			this.btnRegistro.Name = "btnRegistro";
			this.btnRegistro.Size = new System.Drawing.Size(165, 23);
			this.btnRegistro.TabIndex = 4;
			this.btnRegistro.Text = "Registrar incidencias";
			this.btnRegistro.UseVisualStyleBackColor = true;
			this.btnRegistro.Click += new System.EventHandler(this.BtnRegistro_Click);
			// 
			// btnDesvincular
			// 
			this.btnDesvincular.Location = new System.Drawing.Point(12, 403);
			this.btnDesvincular.Name = "btnDesvincular";
			this.btnDesvincular.Size = new System.Drawing.Size(165, 23);
			this.btnDesvincular.TabIndex = 4;
			this.btnDesvincular.Text = "Desvincularse";
			this.btnDesvincular.UseVisualStyleBackColor = true;
			this.btnDesvincular.Click += new System.EventHandler(this.BtnDesvincular_Click);
			// 
			// btnHermanado
			// 
			this.btnHermanado.Location = new System.Drawing.Point(636, 403);
			this.btnHermanado.Name = "btnHermanado";
			this.btnHermanado.Size = new System.Drawing.Size(165, 23);
			this.btnHermanado.TabIndex = 4;
			this.btnHermanado.Text = "Realizar hermanado";
			this.btnHermanado.UseVisualStyleBackColor = true;
			this.btnHermanado.Click += new System.EventHandler(this.BtnHermanado_Click);
			// 
			// lblTotalPrimera
			// 
			this.lblTotalPrimera.AutoSize = true;
			this.lblTotalPrimera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalPrimera.Location = new System.Drawing.Point(3, 0);
			this.lblTotalPrimera.Name = "lblTotalPrimera";
			this.lblTotalPrimera.Size = new System.Drawing.Size(155, 20);
			this.lblTotalPrimera.TabIndex = 5;
			this.lblTotalPrimera.Text = "Pares de primera: 12";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Controls.Add(this.lblTotalPrimera, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblTotalRep, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblTotalObs, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 60);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(960, 35);
			this.tableLayoutPanel2.TabIndex = 6;
			// 
			// lblTotalRep
			// 
			this.lblTotalRep.AutoSize = true;
			this.lblTotalRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalRep.Location = new System.Drawing.Point(643, 0);
			this.lblTotalRep.Name = "lblTotalRep";
			this.lblTotalRep.Size = new System.Drawing.Size(262, 20);
			this.lblTotalRep.TabIndex = 5;
			this.lblTotalRep.Text = "Defectos de reproceso: 4 - (I:1, D:3)";
			// 
			// lblTotalObs
			// 
			this.lblTotalObs.AutoSize = true;
			this.lblTotalObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalObs.Location = new System.Drawing.Point(323, 0);
			this.lblTotalObs.Name = "lblTotalObs";
			this.lblTotalObs.Size = new System.Drawing.Size(274, 20);
			this.lblTotalObs.TabIndex = 5;
			this.lblTotalObs.Text = "Defectos de observado: 12 - (I:5, D:7)";
			// 
			// lstIncidencias
			// 
			this.lstIncidencias.FormattingEnabled = true;
			this.lstIncidencias.Location = new System.Drawing.Point(12, 130);
			this.lstIncidencias.Name = "lstIncidencias";
			this.lstIncidencias.Size = new System.Drawing.Size(960, 264);
			this.lstIncidencias.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(126, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Incidencias encontradas:";
			// 
			// FormInspeccion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 434);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lstIncidencias);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.btnDesvincular);
			this.Controls.Add(this.btnHermanado);
			this.Controls.Add(this.btnRegistro);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "FormInspeccion";
			this.Text = "Inspeccion de calzado";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblOP;
		private System.Windows.Forms.Label lblModelo;
		private System.Windows.Forms.Label lblColor;
		private System.Windows.Forms.Label lblTurno;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btnRegistro;
		private System.Windows.Forms.Button btnDesvincular;
		private System.Windows.Forms.Button btnHermanado;
		private System.Windows.Forms.Label lblTotalPrimera;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label lblTotalRep;
		private System.Windows.Forms.Label lblTotalObs;
		private System.Windows.Forms.ListBox lstIncidencias;
		private System.Windows.Forms.Label label4;
	}
}