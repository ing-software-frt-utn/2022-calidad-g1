namespace IDS_TP1_Cliente {
	partial class FormLineas {
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
			this.tableLineas = new System.Windows.Forms.TableLayoutPanel();
			this.btnActualizar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tableLineas
			// 
			this.tableLineas.ColumnCount = 2;
			this.tableLineas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLineas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLineas.Location = new System.Drawing.Point(12, 41);
			this.tableLineas.Name = "tableLineas";
			this.tableLineas.RowCount = 1;
			this.tableLineas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLineas.Size = new System.Drawing.Size(200, 100);
			this.tableLineas.TabIndex = 0;
			// 
			// btnActualizar
			// 
			this.btnActualizar.Location = new System.Drawing.Point(12, 12);
			this.btnActualizar.Name = "btnActualizar";
			this.btnActualizar.Size = new System.Drawing.Size(75, 23);
			this.btnActualizar.TabIndex = 0;
			this.btnActualizar.Text = "Actualizar";
			this.btnActualizar.UseVisualStyleBackColor = true;
			this.btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
			// 
			// FormLineas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(224, 153);
			this.Controls.Add(this.btnActualizar);
			this.Controls.Add(this.tableLineas);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormLineas";
			this.Text = "Lineas de trabajo";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLineas;
		private System.Windows.Forms.Button btnActualizar;
	}
}