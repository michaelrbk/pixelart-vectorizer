namespace PixelArtUpScaler
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upScalingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale2xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale3xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale4xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hqx2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hqx3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hqx4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cinzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suavisaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nenhumaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bicubicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilinearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vetorizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vetorizarPixelArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOriImg = new System.Windows.Forms.PictureBox();
            this.pictureBoxDstImg = new System.Windows.Forms.PictureBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExemplo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButtonZoom = new System.Windows.Forms.ToolStripSplitButton();
            this.zoom50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom250ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom500ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom1000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonCopia = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDstImg)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.upScalingToolStripMenuItem,
            this.filtrosToolStripMenuItem,
            this.suavisaçãoToolStripMenuItem,
            this.vetorizaçãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.salvarToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salvarToolStripMenuItem.Text = "Salvar";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // upScalingToolStripMenuItem
            // 
            this.upScalingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scale2xToolStripMenuItem,
            this.scale3xToolStripMenuItem,
            this.scale4xToolStripMenuItem,
            this.hqx2ToolStripMenuItem,
            this.hqx3ToolStripMenuItem,
            this.hqx4ToolStripMenuItem});
            this.upScalingToolStripMenuItem.Name = "upScalingToolStripMenuItem";
            this.upScalingToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.upScalingToolStripMenuItem.Text = "UpScaling";
            // 
            // scale2xToolStripMenuItem
            // 
            this.scale2xToolStripMenuItem.Name = "scale2xToolStripMenuItem";
            this.scale2xToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scale2xToolStripMenuItem.Text = "Scale2x";
            this.scale2xToolStripMenuItem.Click += new System.EventHandler(this.scale2xToolStripMenuItem_Click);
            // 
            // scale3xToolStripMenuItem
            // 
            this.scale3xToolStripMenuItem.Name = "scale3xToolStripMenuItem";
            this.scale3xToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scale3xToolStripMenuItem.Text = "Scale3x";
            this.scale3xToolStripMenuItem.Click += new System.EventHandler(this.scale3xToolStripMenuItem_Click);
            // 
            // scale4xToolStripMenuItem
            // 
            this.scale4xToolStripMenuItem.Name = "scale4xToolStripMenuItem";
            this.scale4xToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scale4xToolStripMenuItem.Text = "Scale4x";
            this.scale4xToolStripMenuItem.Click += new System.EventHandler(this.scale4xToolStripMenuItem_Click);
            // 
            // hqx2ToolStripMenuItem
            // 
            this.hqx2ToolStripMenuItem.Name = "hqx2ToolStripMenuItem";
            this.hqx2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hqx2ToolStripMenuItem.Text = "Hqx2";
            this.hqx2ToolStripMenuItem.Click += new System.EventHandler(this.hqx2ToolStripMenuItem_Click);
            // 
            // hqx3ToolStripMenuItem
            // 
            this.hqx3ToolStripMenuItem.Name = "hqx3ToolStripMenuItem";
            this.hqx3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hqx3ToolStripMenuItem.Text = "Hqx3";
            this.hqx3ToolStripMenuItem.Click += new System.EventHandler(this.hqx3ToolStripMenuItem_Click);
            // 
            // hqx4ToolStripMenuItem
            // 
            this.hqx4ToolStripMenuItem.Name = "hqx4ToolStripMenuItem";
            this.hqx4ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hqx4ToolStripMenuItem.Text = "Hqx4";
            this.hqx4ToolStripMenuItem.Click += new System.EventHandler(this.hqx4ToolStripMenuItem_Click);
            // 
            // filtrosToolStripMenuItem
            // 
            this.filtrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cinzaToolStripMenuItem});
            this.filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            this.filtrosToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.filtrosToolStripMenuItem.Text = "Filtros";
            // 
            // cinzaToolStripMenuItem
            // 
            this.cinzaToolStripMenuItem.Name = "cinzaToolStripMenuItem";
            this.cinzaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cinzaToolStripMenuItem.Text = "Tons de Cinza";
            this.cinzaToolStripMenuItem.Click += new System.EventHandler(this.cinzaToolStripMenuItem_Click);
            // 
            // suavisaçãoToolStripMenuItem
            // 
            this.suavisaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nenhumaToolStripMenuItem,
            this.bicubicaToolStripMenuItem,
            this.bilinearToolStripMenuItem,
            this.altaToolStripMenuItem,
            this.baixaToolStripMenuItem});
            this.suavisaçãoToolStripMenuItem.Name = "suavisaçãoToolStripMenuItem";
            this.suavisaçãoToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.suavisaçãoToolStripMenuItem.Text = "Suavização";
            // 
            // nenhumaToolStripMenuItem
            // 
            this.nenhumaToolStripMenuItem.Checked = true;
            this.nenhumaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nenhumaToolStripMenuItem.Name = "nenhumaToolStripMenuItem";
            this.nenhumaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nenhumaToolStripMenuItem.Text = "Nenhuma";
            this.nenhumaToolStripMenuItem.Click += new System.EventHandler(this.nenhumaToolStripMenuItem_Click);
            // 
            // bicubicaToolStripMenuItem
            // 
            this.bicubicaToolStripMenuItem.Name = "bicubicaToolStripMenuItem";
            this.bicubicaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bicubicaToolStripMenuItem.Text = "Bicubica";
            this.bicubicaToolStripMenuItem.Click += new System.EventHandler(this.bicubicaToolStripMenuItem_Click);
            // 
            // bilinearToolStripMenuItem
            // 
            this.bilinearToolStripMenuItem.Name = "bilinearToolStripMenuItem";
            this.bilinearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bilinearToolStripMenuItem.Text = "Bilinear";
            this.bilinearToolStripMenuItem.Click += new System.EventHandler(this.bilinearToolStripMenuItem_Click);
            // 
            // altaToolStripMenuItem
            // 
            this.altaToolStripMenuItem.Name = "altaToolStripMenuItem";
            this.altaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.altaToolStripMenuItem.Text = "Alta";
            this.altaToolStripMenuItem.Click += new System.EventHandler(this.altaToolStripMenuItem_Click);
            // 
            // baixaToolStripMenuItem
            // 
            this.baixaToolStripMenuItem.Name = "baixaToolStripMenuItem";
            this.baixaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.baixaToolStripMenuItem.Text = "Baixa";
            this.baixaToolStripMenuItem.Click += new System.EventHandler(this.baixaToolStripMenuItem_Click);
            // 
            // vetorizaçãoToolStripMenuItem
            // 
            this.vetorizaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vetorizarPixelArtToolStripMenuItem});
            this.vetorizaçãoToolStripMenuItem.Name = "vetorizaçãoToolStripMenuItem";
            this.vetorizaçãoToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.vetorizaçãoToolStripMenuItem.Text = "Vetorização";
            // 
            // vetorizarPixelArtToolStripMenuItem
            // 
            this.vetorizarPixelArtToolStripMenuItem.Name = "vetorizarPixelArtToolStripMenuItem";
            this.vetorizarPixelArtToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.vetorizarPixelArtToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.vetorizarPixelArtToolStripMenuItem.Text = "Vetorizar PixelArt";
            this.vetorizarPixelArtToolStripMenuItem.Click += new System.EventHandler(this.vetorizarPixelArtToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxOriImg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxDstImg, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 211);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pictureBoxOriImg
            // 
            this.pictureBoxOriImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxOriImg.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxOriImg.Name = "pictureBoxOriImg";
            this.pictureBoxOriImg.Size = new System.Drawing.Size(281, 205);
            this.pictureBoxOriImg.TabIndex = 0;
            this.pictureBoxOriImg.TabStop = false;
            this.pictureBoxOriImg.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxOriImg_Paint);
            // 
            // pictureBoxDstImg
            // 
            this.pictureBoxDstImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDstImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxDstImg.Location = new System.Drawing.Point(340, 3);
            this.pictureBoxDstImg.Name = "pictureBoxDstImg";
            this.pictureBoxDstImg.Size = new System.Drawing.Size(281, 205);
            this.pictureBoxDstImg.TabIndex = 2;
            this.pictureBoxDstImg.TabStop = false;
            this.pictureBoxDstImg.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDstImg_Paint);
            // 
            // toolStrip
            // 
            this.toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonExemplo,
            this.toolStripButtonSave,
            this.toolStripButtonZoomIn,
            this.toolStripButtonZoomOut,
            this.toolStripSplitButtonZoom,
            this.toolStripButtonCopia});
            this.toolStrip.Location = new System.Drawing.Point(3, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(182, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "Abrir";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonExemplo
            // 
            this.toolStripButtonExemplo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExemplo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExemplo.Image")));
            this.toolStripButtonExemplo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExemplo.Name = "toolStripButtonExemplo";
            this.toolStripButtonExemplo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExemplo.Text = "Carregar Imagem Exemplo";
            this.toolStripButtonExemplo.Click += new System.EventHandler(this.toolStripButtonExemplo_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Salvar";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomIn.Image")));
            this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonZoomIn.Text = "+ Zoom";
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.toolStripButtonZoomIn_Click_1);
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomOut.Image")));
            this.toolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonZoomOut.Text = "- Zoom";
            this.toolStripButtonZoomOut.Click += new System.EventHandler(this.toolStripButtonZoomOut_Click_1);
            // 
            // toolStripSplitButtonZoom
            // 
            this.toolStripSplitButtonZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButtonZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom50ToolStripMenuItem,
            this.zoom100ToolStripMenuItem,
            this.zoom250ToolStripMenuItem,
            this.zoom500ToolStripMenuItem,
            this.zoom1000ToolStripMenuItem});
            this.toolStripSplitButtonZoom.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonZoom.Image")));
            this.toolStripSplitButtonZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonZoom.Name = "toolStripSplitButtonZoom";
            this.toolStripSplitButtonZoom.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButtonZoom.Text = "Zoom";
            // 
            // zoom50ToolStripMenuItem
            // 
            this.zoom50ToolStripMenuItem.Name = "zoom50ToolStripMenuItem";
            this.zoom50ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.zoom50ToolStripMenuItem.Text = "Zoom 50%";
            this.zoom50ToolStripMenuItem.Click += new System.EventHandler(this.zoom50ToolStripMenuItem_Click);
            // 
            // zoom100ToolStripMenuItem
            // 
            this.zoom100ToolStripMenuItem.Name = "zoom100ToolStripMenuItem";
            this.zoom100ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.zoom100ToolStripMenuItem.Text = "Zoom 100%";
            this.zoom100ToolStripMenuItem.Click += new System.EventHandler(this.zoom100ToolStripMenuItem_Click);
            // 
            // zoom250ToolStripMenuItem
            // 
            this.zoom250ToolStripMenuItem.Name = "zoom250ToolStripMenuItem";
            this.zoom250ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.zoom250ToolStripMenuItem.Text = "Zoom 250%";
            this.zoom250ToolStripMenuItem.Click += new System.EventHandler(this.zoom250ToolStripMenuItem_Click);
            // 
            // zoom500ToolStripMenuItem
            // 
            this.zoom500ToolStripMenuItem.Name = "zoom500ToolStripMenuItem";
            this.zoom500ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.zoom500ToolStripMenuItem.Text = "Zoom 500%";
            this.zoom500ToolStripMenuItem.Click += new System.EventHandler(this.zoom500ToolStripMenuItem_Click);
            // 
            // zoom1000ToolStripMenuItem
            // 
            this.zoom1000ToolStripMenuItem.Name = "zoom1000ToolStripMenuItem";
            this.zoom1000ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.zoom1000ToolStripMenuItem.Text = "Zoom 1000%";
            this.zoom1000ToolStripMenuItem.Click += new System.EventHandler(this.zoom1000ToolStripMenuItem_Click);
            // 
            // toolStripButtonCopia
            // 
            this.toolStripButtonCopia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopia.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopia.Image")));
            this.toolStripButtonCopia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopia.Name = "toolStripButtonCopia";
            this.toolStripButtonCopia.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopia.Text = "Editar a Imagem de Destino";
            this.toolStripButtonCopia.Click += new System.EventHandler(this.toolStripButtonCopia_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(624, 211);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(624, 282);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 282);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PixelArt UpScaler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDstImg)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxOriImg;
        private System.Windows.Forms.PictureBox pictureBoxDstImg;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;
        private System.Windows.Forms.ToolStripMenuItem upScalingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale2xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale3xToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonZoom;
        private System.Windows.Forms.ToolStripMenuItem zoom50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom250ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom500ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom1000ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale4xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hqx2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hqx3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hqx4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suavisaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nenhumaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bicubicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilinearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopia;
        private System.Windows.Forms.ToolStripMenuItem filtrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cinzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonExemplo;
        private System.Windows.Forms.ToolStripMenuItem vetorizaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vetorizarPixelArtToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

