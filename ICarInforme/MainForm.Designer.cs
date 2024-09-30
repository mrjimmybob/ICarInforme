namespace ICarInformes
{
    partial class fMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecargar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiVerInforme = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.árbolMenúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.árbolInformesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.usuariosInformeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.usuariosÁrbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.tsbRecargar = new System.Windows.Forms.ToolStripButton();
            this.tsbVerInforme = new System.Windows.Forms.ToolStripButton();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tvInformes = new System.Windows.Forms.TreeView();
            this.ilTreeView = new System.Windows.Forms.ImageList(this.components);
            this.bVerInforme = new System.Windows.Forms.Button();
            this.flpParametros = new System.Windows.Forms.FlowLayoutPanel();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.mantenimientoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(865, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRecargar,
            this.toolStripMenuItem3,
            this.tsmiVerInforme,
            this.toolStripMenuItem4,
            this.tsmiSalir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // tsmiRecargar
            // 
            this.tsmiRecargar.Name = "tsmiRecargar";
            this.tsmiRecargar.Size = new System.Drawing.Size(169, 26);
            this.tsmiRecargar.Text = "&Recargar";
            this.tsmiRecargar.Click += new System.EventHandler(this.tsmiRecargar_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(166, 6);
            // 
            // tsmiVerInforme
            // 
            this.tsmiVerInforme.Enabled = false;
            this.tsmiVerInforme.Name = "tsmiVerInforme";
            this.tsmiVerInforme.Size = new System.Drawing.Size(169, 26);
            this.tsmiVerInforme.Text = "&Ver Informe";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(166, 6);
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.Size = new System.Drawing.Size(169, 26);
            this.tsmiSalir.Text = "&Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.árbolMenúToolStripMenuItem,
            this.informesToolStripMenuItem,
            this.árbolInformesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.usuariosInformeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.usuariosÁrbolToolStripMenuItem});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // árbolMenúToolStripMenuItem
            // 
            this.árbolMenúToolStripMenuItem.Name = "árbolMenúToolStripMenuItem";
            this.árbolMenúToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.árbolMenúToolStripMenuItem.Text = "Árbol Menú";
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // árbolInformesToolStripMenuItem
            // 
            this.árbolInformesToolStripMenuItem.Name = "árbolInformesToolStripMenuItem";
            this.árbolInformesToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.árbolInformesToolStripMenuItem.Text = "Árbol - Informes";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // usuariosInformeToolStripMenuItem
            // 
            this.usuariosInformeToolStripMenuItem.Name = "usuariosInformeToolStripMenuItem";
            this.usuariosInformeToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.usuariosInformeToolStripMenuItem.Text = "Usuarios - Informe";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(211, 6);
            // 
            // usuariosÁrbolToolStripMenuItem
            // 
            this.usuariosÁrbolToolStripMenuItem.Name = "usuariosÁrbolToolStripMenuItem";
            this.usuariosÁrbolToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.usuariosÁrbolToolStripMenuItem.Text = "Usuarios - Árbol";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAcercaDe});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // tsmiAcercaDe
            // 
            this.tsmiAcercaDe.Name = "tsmiAcercaDe";
            this.tsmiAcercaDe.Size = new System.Drawing.Size(158, 26);
            this.tsmiAcercaDe.Text = "&Acerca de";
            this.tsmiAcercaDe.Click += new System.EventHandler(this.tsmiAcercaDe_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSalir,
            this.tsbRecargar,
            this.tsbVerInforme});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(865, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSalir
            // 
            this.tsbSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(29, 24);
            this.tsbSalir.Text = "Salir de la aplicación";
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // tsbRecargar
            // 
            this.tsbRecargar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRecargar.Image = ((System.Drawing.Image)(resources.GetObject("tsbRecargar.Image")));
            this.tsbRecargar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRecargar.Name = "tsbRecargar";
            this.tsbRecargar.Size = new System.Drawing.Size(29, 24);
            this.tsbRecargar.Text = "Recargar Informes";
            this.tsbRecargar.Click += new System.EventHandler(this.tsbRecargar_Click);
            // 
            // tsbVerInforme
            // 
            this.tsbVerInforme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbVerInforme.Enabled = false;
            this.tsbVerInforme.Image = ((System.Drawing.Image)(resources.GetObject("tsbVerInforme.Image")));
            this.tsbVerInforme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVerInforme.Name = "tsbVerInforme";
            this.tsbVerInforme.Size = new System.Drawing.Size(29, 24);
            this.tsbVerInforme.Text = "Ver Informe";
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.pbHeader);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 57);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(865, 61);
            this.pHeader.TabIndex = 2;
            // 
            // pbHeader
            // 
            this.pbHeader.BackColor = System.Drawing.Color.Black;
            this.pbHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbHeader.Image = ((System.Drawing.Image)(resources.GetObject("pbHeader.Image")));
            this.pbHeader.Location = new System.Drawing.Point(0, 0);
            this.pbHeader.Name = "pbHeader";
            this.pbHeader.Size = new System.Drawing.Size(865, 61);
            this.pbHeader.TabIndex = 0;
            this.pbHeader.TabStop = false;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 118);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tvInformes);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.bVerInforme);
            this.scMain.Panel2.Controls.Add(this.flpParametros);
            this.scMain.Size = new System.Drawing.Size(865, 527);
            this.scMain.SplitterDistance = 544;
            this.scMain.TabIndex = 3;
            // 
            // tvInformes
            // 
            this.tvInformes.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tvInformes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvInformes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvInformes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tvInformes.FullRowSelect = true;
            this.tvInformes.ImageIndex = 0;
            this.tvInformes.ImageList = this.ilTreeView;
            this.tvInformes.Location = new System.Drawing.Point(0, 0);
            this.tvInformes.Name = "tvInformes";
            this.tvInformes.SelectedImageKey = "dot_red";
            this.tvInformes.Size = new System.Drawing.Size(544, 527);
            this.tvInformes.StateImageList = this.ilTreeView;
            this.tvInformes.TabIndex = 0;
            this.tvInformes.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvInformes_NodeMouseClick);
            // 
            // ilTreeView
            // 
            this.ilTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeView.ImageStream")));
            this.ilTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTreeView.Images.SetKeyName(0, "dot_grey");
            this.ilTreeView.Images.SetKeyName(1, "dot_red");
            this.ilTreeView.Images.SetKeyName(2, "report");
            // 
            // bVerInforme
            // 
            this.bVerInforme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bVerInforme.Enabled = false;
            this.bVerInforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVerInforme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bVerInforme.ImageKey = "report";
            this.bVerInforme.Location = new System.Drawing.Point(91, 453);
            this.bVerInforme.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bVerInforme.Name = "bVerInforme";
            this.bVerInforme.Size = new System.Drawing.Size(213, 64);
            this.bVerInforme.TabIndex = 2;
            this.bVerInforme.Text = "&Ver Informe";
            this.bVerInforme.UseVisualStyleBackColor = true;
            this.bVerInforme.Click += new System.EventHandler(this.bVerInforme_Click);
            // 
            // flpParametros
            // 
            this.flpParametros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpParametros.Location = new System.Drawing.Point(4, 6);
            this.flpParametros.Margin = new System.Windows.Forms.Padding(4);
            this.flpParametros.Name = "flpParametros";
            this.flpParametros.Size = new System.Drawing.Size(300, 437);
            this.flpParametros.TabIndex = 1;
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "Informe");
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 645);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(373, 312);
            this.Name = "fMain";
            this.Text = "Informes I\'Car";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecargar;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem árbolMenúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem árbolInformesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuariosInformeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem usuariosÁrbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAcercaDe;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerInforme;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.ToolStripButton tsbRecargar;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.PictureBox pbHeader;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TreeView tvInformes;
        private System.Windows.Forms.ImageList ilTreeView;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
        private System.Windows.Forms.ToolStripButton tsbVerInforme;
        private System.Windows.Forms.Button bVerInforme;
        private System.Windows.Forms.FlowLayoutPanel flpParametros;
        private System.Windows.Forms.ImageList ilMain;
    }
}

