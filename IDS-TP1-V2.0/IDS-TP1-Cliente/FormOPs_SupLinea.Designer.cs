namespace IDS_TP1_Cliente {
	partial class FormOPs_SupLinea {
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
			this.dgvOrdenes = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFiltro = new System.Windows.Forms.TextBox();
			this.btnCrear = new System.Windows.Forms.Button();
			this.btnPausar = new System.Windows.Forms.Button();
			this.btnReanudar = new System.Windows.Forms.Button();
			this.btnFinalizar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvOrdenes
			// 
			this.dgvOrdenes.AllowUserToAddRows = false;
			this.dgvOrdenes.AllowUserToDeleteRows = false;
			this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvOrdenes.Location = new System.Drawing.Point(12, 36);
			this.dgvOrdenes.Name = "dgvOrdenes";
			this.dgvOrdenes.ReadOnly = true;
			this.dgvOrdenes.Size = new System.Drawing.Size(906, 387);
			this.dgvOrdenes.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Filtro:";
			// 
			// txtFiltro
			// 
			this.txtFiltro.Location = new System.Drawing.Point(51, 10);
			this.txtFiltro.Name = "txtFiltro";
			this.txtFiltro.Size = new System.Drawing.Size(867, 20);
			this.txtFiltro.TabIndex = 2;
			this.txtFiltro.TextChanged += new System.EventHandler(this.TxtFiltro_TextChanged);
			// 
			// btnCrear
			// 
			this.btnCrear.Location = new System.Drawing.Point(181, 429);
			this.btnCrear.Name = "btnCrear";
			this.btnCrear.Size = new System.Drawing.Size(137, 23);
			this.btnCrear.TabIndex = 3;
			this.btnCrear.Text = "Crear nueva";
			this.btnCrear.UseVisualStyleBackColor = true;
			this.btnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
			// 
			// btnPausar
			// 
			this.btnPausar.Location = new System.Drawing.Point(324, 429);
			this.btnPausar.Name = "btnPausar";
			this.btnPausar.Size = new System.Drawing.Size(137, 23);
			this.btnPausar.TabIndex = 3;
			this.btnPausar.Text = "Pausar orden";
			this.btnPausar.UseVisualStyleBackColor = true;
			this.btnPausar.Click += new System.EventHandler(this.BtnPausar_Click);
			// 
			// btnReanudar
			// 
			this.btnReanudar.Location = new System.Drawing.Point(467, 429);
			this.btnReanudar.Name = "btnReanudar";
			this.btnReanudar.Size = new System.Drawing.Size(137, 23);
			this.btnReanudar.TabIndex = 3;
			this.btnReanudar.Text = "Reanudar orden";
			this.btnReanudar.UseVisualStyleBackColor = true;
			this.btnReanudar.Click += new System.EventHandler(this.BtnReanudar_Click);
			// 
			// btnFinalizar
			// 
			this.btnFinalizar.Location = new System.Drawing.Point(610, 429);
			this.btnFinalizar.Name = "btnFinalizar";
			this.btnFinalizar.Size = new System.Drawing.Size(137, 23);
			this.btnFinalizar.TabIndex = 3;
			this.btnFinalizar.Text = "Finalizar orden";
			this.btnFinalizar.UseVisualStyleBackColor = true;
			this.btnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
			// 
			// FormOPs_SupLinea
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(930, 464);
			this.Controls.Add(this.btnFinalizar);
			this.Controls.Add(this.btnReanudar);
			this.Controls.Add(this.btnPausar);
			this.Controls.Add(this.btnCrear);
			this.Controls.Add(this.txtFiltro);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvOrdenes);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormOPs_SupLinea";
			this.Text = "Ordenes de produccion";
			((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvOrdenes;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFiltro;
		private System.Windows.Forms.Button btnCrear;
		private System.Windows.Forms.Button btnPausar;
		private System.Windows.Forms.Button btnReanudar;
		private System.Windows.Forms.Button btnFinalizar;
	}
}