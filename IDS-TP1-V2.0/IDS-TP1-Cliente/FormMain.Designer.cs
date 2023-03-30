namespace IDS_TP1_Cliente {
	partial class FormMain {
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuSistema = new System.Windows.Forms.ToolStripMenuItem();
			this.btnLogin = new System.Windows.Forms.ToolStripMenuItem();
			this.btnLogout = new System.Windows.Forms.ToolStripMenuItem();
			this.menuVer = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOPs = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSemaforos = new System.Windows.Forms.ToolStripMenuItem();
			this.linea1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.linea2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.linea3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.linea4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuGestion = new System.Windows.Forms.ToolStripMenuItem();
			this.modelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.coloresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuInspeccion = new System.Windows.Forms.ToolStripMenuItem();
			this.btnIniciarJornada = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSistema,
            this.menuVer,
            this.menuGestion,
            this.menuInspeccion});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuSistema
			// 
			this.menuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLogin,
            this.btnLogout});
			this.menuSistema.Name = "menuSistema";
			this.menuSistema.Size = new System.Drawing.Size(60, 20);
			this.menuSistema.Text = "Sistema";
			// 
			// btnLogin
			// 
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(180, 22);
			this.btnLogin.Text = "Inicar sesión";
			this.btnLogin.Click += new System.EventHandler(this.IniciarSesion_Click);
			// 
			// btnLogout
			// 
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(180, 22);
			this.btnLogout.Text = "Cerrar sesión";
			this.btnLogout.Click += new System.EventHandler(this.CerrarSesion_Click);
			// 
			// menuVer
			// 
			this.menuVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOPs,
            this.menuSemaforos});
			this.menuVer.Name = "menuVer";
			this.menuVer.Size = new System.Drawing.Size(35, 20);
			this.menuVer.Text = "Ver";
			// 
			// menuOPs
			// 
			this.menuOPs.Name = "menuOPs";
			this.menuOPs.Size = new System.Drawing.Size(198, 22);
			this.menuOPs.Text = "Ordenes de producción";
			this.menuOPs.Click += new System.EventHandler(this.Ordenes_Click);
			// 
			// menuSemaforos
			// 
			this.menuSemaforos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linea1ToolStripMenuItem,
            this.linea2ToolStripMenuItem,
            this.linea3ToolStripMenuItem,
            this.linea4ToolStripMenuItem});
			this.menuSemaforos.Name = "menuSemaforos";
			this.menuSemaforos.Size = new System.Drawing.Size(198, 22);
			this.menuSemaforos.Text = "Semáforos";
			// 
			// linea1ToolStripMenuItem
			// 
			this.linea1ToolStripMenuItem.Name = "linea1ToolStripMenuItem";
			this.linea1ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.linea1ToolStripMenuItem.Text = "Linea 1";
			this.linea1ToolStripMenuItem.Click += new System.EventHandler(this.Linea1ToolStripMenuItem_Click);
			// 
			// linea2ToolStripMenuItem
			// 
			this.linea2ToolStripMenuItem.Name = "linea2ToolStripMenuItem";
			this.linea2ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.linea2ToolStripMenuItem.Text = "Linea 2";
			this.linea2ToolStripMenuItem.Click += new System.EventHandler(this.Linea2ToolStripMenuItem_Click);
			// 
			// linea3ToolStripMenuItem
			// 
			this.linea3ToolStripMenuItem.Name = "linea3ToolStripMenuItem";
			this.linea3ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.linea3ToolStripMenuItem.Text = "Linea 3";
			this.linea3ToolStripMenuItem.Click += new System.EventHandler(this.Linea3ToolStripMenuItem_Click);
			// 
			// linea4ToolStripMenuItem
			// 
			this.linea4ToolStripMenuItem.Name = "linea4ToolStripMenuItem";
			this.linea4ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.linea4ToolStripMenuItem.Text = "Linea 4";
			this.linea4ToolStripMenuItem.Click += new System.EventHandler(this.Linea4ToolStripMenuItem_Click);
			// 
			// menuGestion
			// 
			this.menuGestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modelosToolStripMenuItem,
            this.coloresToolStripMenuItem,
            this.empleadosToolStripMenuItem});
			this.menuGestion.Name = "menuGestion";
			this.menuGestion.Size = new System.Drawing.Size(59, 20);
			this.menuGestion.Text = "Gestion";
			// 
			// modelosToolStripMenuItem
			// 
			this.modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
			this.modelosToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.modelosToolStripMenuItem.Text = "Modelos";
			this.modelosToolStripMenuItem.Click += new System.EventHandler(this.Modelos_Click);
			// 
			// coloresToolStripMenuItem
			// 
			this.coloresToolStripMenuItem.Name = "coloresToolStripMenuItem";
			this.coloresToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.coloresToolStripMenuItem.Text = "Colores";
			this.coloresToolStripMenuItem.Click += new System.EventHandler(this.Colores_Click);
			// 
			// empleadosToolStripMenuItem
			// 
			this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
			this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.empleadosToolStripMenuItem.Text = "Empleados";
			this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.Empleados_Click);
			// 
			// menuInspeccion
			// 
			this.menuInspeccion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIniciarJornada});
			this.menuInspeccion.Name = "menuInspeccion";
			this.menuInspeccion.Size = new System.Drawing.Size(76, 20);
			this.menuInspeccion.Text = "Inspeccion";
			// 
			// btnIniciarJornada
			// 
			this.btnIniciarJornada.Name = "btnIniciarJornada";
			this.btnIniciarJornada.Size = new System.Drawing.Size(149, 22);
			this.btnIniciarJornada.Text = "Iniciar jornada";
			this.btnIniciarJornada.Click += new System.EventHandler(this.IniciarJornada_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1056, 575);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormMain";
			this.Text = "Sistema IDS";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuGestion;
		private System.Windows.Forms.ToolStripMenuItem modelosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem coloresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuVer;
		private System.Windows.Forms.ToolStripMenuItem menuOPs;
		private System.Windows.Forms.ToolStripMenuItem menuSistema;
		private System.Windows.Forms.ToolStripMenuItem btnLogin;
		private System.Windows.Forms.ToolStripMenuItem btnLogout;
		private System.Windows.Forms.ToolStripMenuItem menuSemaforos;
		private System.Windows.Forms.ToolStripMenuItem menuInspeccion;
		private System.Windows.Forms.ToolStripMenuItem btnIniciarJornada;
		private System.Windows.Forms.ToolStripMenuItem linea1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem linea2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem linea3ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem linea4ToolStripMenuItem;
	}
}