namespace IDS_TP1_Cliente {
	partial class FormSemaforos {
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
			this.imgSemaforoR = new System.Windows.Forms.PictureBox();
			this.imgSemaforoO = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblLinea = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblDefectos = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.imgSemaforoR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgSemaforoO)).BeginInit();
			this.SuspendLayout();
			// 
			// imgSemaforoR
			// 
			this.imgSemaforoR.Image = global::IDS_TP1_Cliente.Properties.Resources.semaforo_apagado;
			this.imgSemaforoR.Location = new System.Drawing.Point(16, 60);
			this.imgSemaforoR.Name = "imgSemaforoR";
			this.imgSemaforoR.Size = new System.Drawing.Size(528, 152);
			this.imgSemaforoR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgSemaforoR.TabIndex = 2;
			this.imgSemaforoR.TabStop = false;
			// 
			// imgSemaforoO
			// 
			this.imgSemaforoO.Image = global::IDS_TP1_Cliente.Properties.Resources.semaforo_apagado;
			this.imgSemaforoO.Location = new System.Drawing.Point(16, 278);
			this.imgSemaforoO.Name = "imgSemaforoO";
			this.imgSemaforoO.Size = new System.Drawing.Size(528, 152);
			this.imgSemaforoO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgSemaforoO.TabIndex = 3;
			this.imgSemaforoO.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(199, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(170, 37);
			this.label2.TabIndex = 4;
			this.label2.Text = "Reproceso";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(190, 228);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(189, 37);
			this.label3.TabIndex = 4;
			this.label3.Text = "Observados";
			// 
			// lblLinea
			// 
			this.lblLinea.AutoSize = true;
			this.lblLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLinea.Location = new System.Drawing.Point(688, 9);
			this.lblLinea.Name = "lblLinea";
			this.lblLinea.Size = new System.Drawing.Size(122, 37);
			this.lblLinea.TabIndex = 4;
			this.lblLinea.Text = "Linea #";
			this.lblLinea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(623, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(249, 31);
			this.label4.TabIndex = 4;
			this.label4.Text = "Defectos recientes:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDefectos
			// 
			this.lblDefectos.AutoSize = true;
			this.lblDefectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDefectos.Location = new System.Drawing.Point(683, 154);
			this.lblDefectos.Name = "lblDefectos";
			this.lblDefectos.Size = new System.Drawing.Size(127, 155);
			this.lblDefectos.TabIndex = 4;
			this.lblDefectos.Text = "- XXX (X)\r\n- XXX (X)\r\n- XXX (X)\r\n- XXX (X)\r\n- XXX (X)";
			this.lblDefectos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotal.Location = new System.Drawing.Point(649, 396);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(191, 37);
			this.lblTotal.TabIndex = 4;
			this.lblTotal.Text = "Total: XXXX";
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FormSemaforos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(944, 442);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblDefectos);
			this.Controls.Add(this.lblTotal);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblLinea);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.imgSemaforoO);
			this.Controls.Add(this.imgSemaforoR);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSemaforos";
			this.Text = "Semaforos";
			((System.ComponentModel.ISupportInitialize)(this.imgSemaforoR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgSemaforoO)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox imgSemaforoR;
		private System.Windows.Forms.PictureBox imgSemaforoO;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblLinea;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblDefectos;
		private System.Windows.Forms.Label lblTotal;
	}
}