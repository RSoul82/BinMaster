namespace BinMaster
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbObjModel = new System.Windows.Forms.ComboBox();
            this.cbContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rcOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.editSavedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnObjBrowse = new System.Windows.Forms.Button();
            this.btnModelName = new System.Windows.Forms.Button();
            this.rdo3dsConv = new System.Windows.Forms.RadioButton();
            this.rdoEConv = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkConvTexInObjDir = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbConvTexDir = new System.Windows.Forms.ComboBox();
            this.btnBrowseConvTexDir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbConvObjDir = new System.Windows.Forms.ComboBox();
            this.btnBrowseConvObjDir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkNoResMods = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbResMod = new System.Windows.Forms.ComboBox();
            this.btnBrowseResMod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbGameDir = new System.Windows.Forms.ComboBox();
            this.btnBrowseGameDir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNoTextures = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbTexFormat = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSetTexConvCmd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTexConvCmd = new System.Windows.Forms.ComboBox();
            this.btnBrowseTexConvProg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTexConvProg = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBrowseEto3ds = new System.Windows.Forms.Button();
            this.cbEto3ds = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowseBintoe = new System.Windows.Forms.Button();
            this.cbBintoE = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkAutoSetResourceDir = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbResDir = new System.Windows.Forms.ComboBox();
            this.btnBrowseResDir = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.dlgSelObject = new System.Windows.Forms.OpenFileDialog();
            this.dlgGameDir = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgResMod = new System.Windows.Forms.OpenFileDialog();
            this.dlgConvObjOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgConvTexDir = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgBinToEPath = new System.Windows.Forms.OpenFileDialog();
            this.dlgEto3dsPath = new System.Windows.Forms.OpenFileDialog();
            this.dlgTexConvProgPath = new System.Windows.Forms.OpenFileDialog();
            this.dlgAltResDir = new System.Windows.Forms.FolderBrowserDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.label11 = new System.Windows.Forms.Label();
            this.cbContextMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbObjModel
            // 
            this.cbObjModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbObjModel.ContextMenuStrip = this.cbContextMenu;
            this.cbObjModel.FormattingEnabled = true;
            this.cbObjModel.Location = new System.Drawing.Point(6, 19);
            this.cbObjModel.Name = "cbObjModel";
            this.cbObjModel.Size = new System.Drawing.Size(399, 21);
            this.cbObjModel.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbObjModel, "List of previously chosen model files.");
            // 
            // cbContextMenu
            // 
            this.cbContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rcOpenFolder,
            this.editSavedItemsToolStripMenuItem,
            this.removeAllItemsToolStripMenuItem});
            this.cbContextMenu.Name = "cbContextMenu";
            this.cbContextMenu.Size = new System.Drawing.Size(176, 70);
            // 
            // rcOpenFolder
            // 
            this.rcOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("rcOpenFolder.Image")));
            this.rcOpenFolder.Name = "rcOpenFolder";
            this.rcOpenFolder.Size = new System.Drawing.Size(175, 22);
            this.rcOpenFolder.Text = "Open Folder";
            this.rcOpenFolder.Click += new System.EventHandler(this.rcOpenFolder_Click);
            // 
            // editSavedItemsToolStripMenuItem
            // 
            this.editSavedItemsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editSavedItemsToolStripMenuItem.Image")));
            this.editSavedItemsToolStripMenuItem.Name = "editSavedItemsToolStripMenuItem";
            this.editSavedItemsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.editSavedItemsToolStripMenuItem.Text = "Edit Saved Items...";
            this.editSavedItemsToolStripMenuItem.Click += new System.EventHandler(this.editSavedItemsToolStripMenuItem_Click);
            // 
            // removeAllItemsToolStripMenuItem
            // 
            this.removeAllItemsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeAllItemsToolStripMenuItem.Image")));
            this.removeAllItemsToolStripMenuItem.Name = "removeAllItemsToolStripMenuItem";
            this.removeAllItemsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.removeAllItemsToolStripMenuItem.Text = "Remove All Items...";
            this.removeAllItemsToolStripMenuItem.Click += new System.EventHandler(this.removeAllItemsToolStripMenuItem_Click);
            // 
            // btnObjBrowse
            // 
            this.btnObjBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider1.SetHelpKeyword(this.btnObjBrowse, "");
            this.btnObjBrowse.Location = new System.Drawing.Point(411, 17);
            this.btnObjBrowse.Name = "btnObjBrowse";
            this.helpProvider1.SetShowHelp(this.btnObjBrowse, true);
            this.btnObjBrowse.Size = new System.Drawing.Size(95, 23);
            this.btnObjBrowse.TabIndex = 2;
            this.btnObjBrowse.Text = "Browse File...";
            this.toolTip1.SetToolTip(this.btnObjBrowse, "Choose Model File");
            this.btnObjBrowse.UseVisualStyleBackColor = true;
            this.btnObjBrowse.Click += new System.EventHandler(this.btnObjBrowse_Click);
            // 
            // btnModelName
            // 
            this.btnModelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModelName.Location = new System.Drawing.Point(411, 46);
            this.btnModelName.Name = "btnModelName";
            this.btnModelName.Size = new System.Drawing.Size(95, 23);
            this.btnModelName.TabIndex = 3;
            this.btnModelName.Text = "Model Name...";
            this.toolTip1.SetToolTip(this.btnModelName, "Enter a model name. Bin master will search for it.");
            this.btnModelName.UseVisualStyleBackColor = true;
            this.btnModelName.Click += new System.EventHandler(this.btnModelName_Click);
            // 
            // rdo3dsConv
            // 
            this.rdo3dsConv.AutoSize = true;
            this.rdo3dsConv.Checked = true;
            this.rdo3dsConv.Location = new System.Drawing.Point(6, 46);
            this.rdo3dsConv.Name = "rdo3dsConv";
            this.rdo3dsConv.Size = new System.Drawing.Size(101, 17);
            this.rdo3dsConv.TabIndex = 4;
            this.rdo3dsConv.TabStop = true;
            this.rdo3dsConv.Text = "Convert to *.3ds";
            this.rdo3dsConv.UseVisualStyleBackColor = true;
            // 
            // rdoEConv
            // 
            this.rdoEConv.AutoSize = true;
            this.rdoEConv.Location = new System.Drawing.Point(113, 46);
            this.rdoEConv.Name = "rdoEConv";
            this.rdoEConv.Size = new System.Drawing.Size(90, 17);
            this.rdoEConv.TabIndex = 5;
            this.rdoEConv.Text = "Convert to *.e";
            this.rdoEConv.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 394);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Object/Texture Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkConvTexInObjDir);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbConvTexDir);
            this.groupBox3.Controls.Add(this.btnBrowseConvTexDir);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cbConvObjDir);
            this.groupBox3.Controls.Add(this.btnBrowseConvObjDir);
            this.groupBox3.Location = new System.Drawing.Point(6, 228);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(514, 135);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Folders";
            // 
            // chkConvTexInObjDir
            // 
            this.chkConvTexInObjDir.AutoSize = true;
            this.chkConvTexInObjDir.Location = new System.Drawing.Point(9, 108);
            this.chkConvTexInObjDir.Name = "chkConvTexInObjDir";
            this.chkConvTexInObjDir.Size = new System.Drawing.Size(150, 17);
            this.chkConvTexInObjDir.TabIndex = 19;
            this.chkConvTexInObjDir.Text = "Same as converted object";
            this.chkConvTexInObjDir.UseVisualStyleBackColor = true;
            this.chkConvTexInObjDir.CheckedChanged += new System.EventHandler(this.chkConvTexInObjDir_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Converted Textures Folder";
            // 
            // cbConvTexDir
            // 
            this.cbConvTexDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConvTexDir.ContextMenuStrip = this.cbContextMenu;
            this.cbConvTexDir.FormattingEnabled = true;
            this.cbConvTexDir.Location = new System.Drawing.Point(6, 83);
            this.cbConvTexDir.Name = "cbConvTexDir";
            this.cbConvTexDir.Size = new System.Drawing.Size(399, 21);
            this.cbConvTexDir.TabIndex = 16;
            this.toolTip1.SetToolTip(this.cbConvTexDir, "Folder for converted textures.");
            // 
            // btnBrowseConvTexDir
            // 
            this.btnBrowseConvTexDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseConvTexDir.Location = new System.Drawing.Point(411, 81);
            this.btnBrowseConvTexDir.Name = "btnBrowseConvTexDir";
            this.btnBrowseConvTexDir.Size = new System.Drawing.Size(95, 23);
            this.btnBrowseConvTexDir.TabIndex = 17;
            this.btnBrowseConvTexDir.Text = "Browse Folder...";
            this.btnBrowseConvTexDir.UseVisualStyleBackColor = true;
            this.btnBrowseConvTexDir.Click += new System.EventHandler(this.btnBrowseConvTexDir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Converted Object Folder";
            // 
            // cbConvObjDir
            // 
            this.cbConvObjDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConvObjDir.ContextMenuStrip = this.cbContextMenu;
            this.cbConvObjDir.FormattingEnabled = true;
            this.cbConvObjDir.Location = new System.Drawing.Point(6, 32);
            this.cbConvObjDir.Name = "cbConvObjDir";
            this.cbConvObjDir.Size = new System.Drawing.Size(399, 21);
            this.cbConvObjDir.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cbConvObjDir, "Folder for converted object model.");
            this.cbConvObjDir.SelectedIndexChanged += new System.EventHandler(this.cbConvObjDir_SelectedIndexChanged);
            // 
            // btnBrowseConvObjDir
            // 
            this.btnBrowseConvObjDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseConvObjDir.Location = new System.Drawing.Point(411, 30);
            this.btnBrowseConvObjDir.Name = "btnBrowseConvObjDir";
            this.btnBrowseConvObjDir.Size = new System.Drawing.Size(95, 23);
            this.btnBrowseConvObjDir.TabIndex = 13;
            this.btnBrowseConvObjDir.Text = "Browse Folder...";
            this.btnBrowseConvObjDir.UseVisualStyleBackColor = true;
            this.btnBrowseConvObjDir.Click += new System.EventHandler(this.btnBrowseConvObjDir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkNoResMods);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbResMod);
            this.groupBox2.Controls.Add(this.btnBrowseResMod);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbGameDir);
            this.groupBox2.Controls.Add(this.btnBrowseGameDir);
            this.groupBox2.Location = new System.Drawing.Point(6, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 133);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Object/Texture Locations";
            // 
            // chkNoResMods
            // 
            this.chkNoResMods.AutoSize = true;
            this.chkNoResMods.Location = new System.Drawing.Point(9, 108);
            this.chkNoResMods.Name = "chkNoResMods";
            this.chkNoResMods.Size = new System.Drawing.Size(155, 17);
            this.chkNoResMods.TabIndex = 8;
            this.chkNoResMods.Text = "Only convert original assets";
            this.toolTip1.SetToolTip(this.chkNoResMods, "Don\'t look for any resource packs.");
            this.chkNoResMods.UseVisualStyleBackColor = true;
            this.chkNoResMods.CheckedChanged += new System.EventHandler(this.chkNoResMods_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Resource Mod (e.g ep2.crf/NecroAge.crf etc)";
            // 
            // cbResMod
            // 
            this.cbResMod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbResMod.ContextMenuStrip = this.cbContextMenu;
            this.cbResMod.FormattingEnabled = true;
            this.cbResMod.Location = new System.Drawing.Point(6, 81);
            this.cbResMod.Name = "cbResMod";
            this.cbResMod.Size = new System.Drawing.Size(399, 21);
            this.cbResMod.TabIndex = 9;
            this.toolTip1.SetToolTip(this.cbResMod, "Location of any high-res packs you may have. WARNING: Some models may be too high" +
        " poly to convert.\r\n");
            // 
            // btnBrowseResMod
            // 
            this.btnBrowseResMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseResMod.Location = new System.Drawing.Point(411, 79);
            this.btnBrowseResMod.Name = "btnBrowseResMod";
            this.btnBrowseResMod.Size = new System.Drawing.Size(95, 23);
            this.btnBrowseResMod.TabIndex = 10;
            this.btnBrowseResMod.Text = "Browse File...";
            this.btnBrowseResMod.UseVisualStyleBackColor = true;
            this.btnBrowseResMod.Click += new System.EventHandler(this.btnBrowseResMod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Game/FM Folder";
            // 
            // cbGameDir
            // 
            this.cbGameDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGameDir.ContextMenuStrip = this.cbContextMenu;
            this.cbGameDir.FormattingEnabled = true;
            this.cbGameDir.Location = new System.Drawing.Point(6, 36);
            this.cbGameDir.Name = "cbGameDir";
            this.cbGameDir.Size = new System.Drawing.Size(399, 21);
            this.cbGameDir.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cbGameDir, "Game Installation Folder");
            // 
            // btnBrowseGameDir
            // 
            this.btnBrowseGameDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseGameDir.Location = new System.Drawing.Point(411, 34);
            this.btnBrowseGameDir.Name = "btnBrowseGameDir";
            this.btnBrowseGameDir.Size = new System.Drawing.Size(95, 23);
            this.btnBrowseGameDir.TabIndex = 7;
            this.btnBrowseGameDir.Text = "Browse Folder...";
            this.btnBrowseGameDir.UseVisualStyleBackColor = true;
            this.btnBrowseGameDir.Click += new System.EventHandler(this.btnBrowseGameDir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkNoTextures);
            this.groupBox1.Controls.Add(this.cbObjModel);
            this.groupBox1.Controls.Add(this.btnModelName);
            this.groupBox1.Controls.Add(this.rdoEConv);
            this.groupBox1.Controls.Add(this.btnObjBrowse);
            this.groupBox1.Controls.Add(this.rdo3dsConv);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 77);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Object";
            // 
            // chkNoTextures
            // 
            this.chkNoTextures.AutoSize = true;
            this.chkNoTextures.Location = new System.Drawing.Point(232, 47);
            this.chkNoTextures.Name = "chkNoTextures";
            this.chkNoTextures.Size = new System.Drawing.Size(173, 17);
            this.chkNoTextures.TabIndex = 15;
            this.chkNoTextures.Text = "Don\'t Convert/Extract Textures";
            this.toolTip1.SetToolTip(this.chkNoTextures, "Only convert the object. Useful if you already have all textures in a central loc" +
        "ation.");
            this.chkNoTextures.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Conversion Program Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.cbTexFormat);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.btnSetTexConvCmd);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.cbTexConvCmd);
            this.groupBox5.Controls.Add(this.btnBrowseTexConvProg);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.cbTexConvProg);
            this.groupBox5.Location = new System.Drawing.Point(6, 128);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(514, 169);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Texture Conversion";
            // 
            // cbTexFormat
            // 
            this.cbTexFormat.FormattingEnabled = true;
            this.cbTexFormat.Items.AddRange(new object[] {
            ".png",
            ".gif",
            ".jpg",
            ".bmp",
            ".tga"});
            this.cbTexFormat.Location = new System.Drawing.Point(6, 134);
            this.cbTexFormat.Name = "cbTexFormat";
            this.cbTexFormat.Size = new System.Drawing.Size(121, 21);
            this.cbTexFormat.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cbTexFormat, "Use this to ensure the textures are converted to a format your preferred 3d objec" +
        "t program supports.");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Texture Format";
            // 
            // btnSetTexConvCmd
            // 
            this.btnSetTexConvCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetTexConvCmd.Location = new System.Drawing.Point(413, 82);
            this.btnSetTexConvCmd.Name = "btnSetTexConvCmd";
            this.btnSetTexConvCmd.Size = new System.Drawing.Size(95, 23);
            this.btnSetTexConvCmd.TabIndex = 12;
            this.btnSetTexConvCmd.Text = "New...";
            this.btnSetTexConvCmd.UseVisualStyleBackColor = true;
            this.btnSetTexConvCmd.Click += new System.EventHandler(this.btnSetTexConvCmd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Conversion Command Template";
            // 
            // cbTexConvCmd
            // 
            this.cbTexConvCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTexConvCmd.FormattingEnabled = true;
            this.cbTexConvCmd.Location = new System.Drawing.Point(6, 84);
            this.cbTexConvCmd.Name = "cbTexConvCmd";
            this.cbTexConvCmd.Size = new System.Drawing.Size(399, 21);
            this.cbTexConvCmd.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cbTexConvCmd, "Syntax of the texture conversion command. Use placeholders for file names and tar" +
        "get format.");
            // 
            // btnBrowseTexConvProg
            // 
            this.btnBrowseTexConvProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTexConvProg.Location = new System.Drawing.Point(413, 30);
            this.btnBrowseTexConvProg.Name = "btnBrowseTexConvProg";
            this.btnBrowseTexConvProg.Size = new System.Drawing.Size(95, 23);
            this.btnBrowseTexConvProg.TabIndex = 9;
            this.btnBrowseTexConvProg.Text = "Browse File...";
            this.btnBrowseTexConvProg.UseVisualStyleBackColor = true;
            this.btnBrowseTexConvProg.Click += new System.EventHandler(this.btnBrowseTexConvProg_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Texture Conversion Program";
            // 
            // cbTexConvProg
            // 
            this.cbTexConvProg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTexConvProg.ContextMenuStrip = this.cbContextMenu;
            this.cbTexConvProg.FormattingEnabled = true;
            this.cbTexConvProg.Location = new System.Drawing.Point(6, 32);
            this.cbTexConvProg.Name = "cbTexConvProg";
            this.cbTexConvProg.Size = new System.Drawing.Size(399, 21);
            this.cbTexConvProg.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnBrowseEto3ds);
            this.groupBox4.Controls.Add(this.cbEto3ds);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btnBrowseBintoe);
            this.groupBox4.Controls.Add(this.cbBintoE);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(514, 116);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Object Conversion";
            // 
            // btnBrowseEto3ds
            // 
            this.btnBrowseEto3ds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseEto3ds.Location = new System.Drawing.Point(413, 80);
            this.btnBrowseEto3ds.Name = "btnBrowseEto3ds";
            this.btnBrowseEto3ds.Size = new System.Drawing.Size(95, 23);
            this.btnBrowseEto3ds.TabIndex = 6;
            this.btnBrowseEto3ds.Text = "Browse File...";
            this.btnBrowseEto3ds.UseVisualStyleBackColor = true;
            this.btnBrowseEto3ds.Click += new System.EventHandler(this.btnBrowseEto3ds_Click);
            // 
            // cbEto3ds
            // 
            this.cbEto3ds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEto3ds.ContextMenuStrip = this.cbContextMenu;
            this.cbEto3ds.FormattingEnabled = true;
            this.cbEto3ds.Location = new System.Drawing.Point(6, 82);
            this.cbEto3ds.Name = "cbEto3ds";
            this.cbEto3ds.Size = new System.Drawing.Size(399, 21);
            this.cbEto3ds.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cbEto3ds, "Location of Eto3ds.exe");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Eto3ds";
            // 
            // btnBrowseBintoe
            // 
            this.btnBrowseBintoe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseBintoe.Location = new System.Drawing.Point(413, 30);
            this.btnBrowseBintoe.Name = "btnBrowseBintoe";
            this.btnBrowseBintoe.Size = new System.Drawing.Size(95, 23);
            this.btnBrowseBintoe.TabIndex = 3;
            this.btnBrowseBintoe.Text = "Browse File...";
            this.btnBrowseBintoe.UseVisualStyleBackColor = true;
            this.btnBrowseBintoe.Click += new System.EventHandler(this.btnBrowseBintoe_Click);
            // 
            // cbBintoE
            // 
            this.cbBintoE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBintoE.ContextMenuStrip = this.cbContextMenu;
            this.cbBintoE.FormattingEnabled = true;
            this.cbBintoE.Location = new System.Drawing.Point(6, 32);
            this.cbBintoE.Name = "cbBintoE";
            this.cbBintoE.Size = new System.Drawing.Size(399, 21);
            this.cbBintoE.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cbBintoE, "Location of Bintoe.exe");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "BinToE";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.chkAutoSetResourceDir);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.cbResDir);
            this.tabPage3.Controls.Add(this.btnBrowseResDir);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(526, 368);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Resource Paths";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(8, 79);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(507, 47);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // chkAutoSetResourceDir
            // 
            this.chkAutoSetResourceDir.AutoSize = true;
            this.chkAutoSetResourceDir.Checked = true;
            this.chkAutoSetResourceDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoSetResourceDir.Location = new System.Drawing.Point(8, 13);
            this.chkAutoSetResourceDir.Name = "chkAutoSetResourceDir";
            this.chkAutoSetResourceDir.Size = new System.Drawing.Size(181, 17);
            this.chkAutoSetResourceDir.TabIndex = 12;
            this.chkAutoSetResourceDir.Text = "Auto set from \"Game/FM Folder\"";
            this.chkAutoSetResourceDir.UseVisualStyleBackColor = true;
            this.chkAutoSetResourceDir.CheckedChanged += new System.EventHandler(this.chkAutoSetResourceDir_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Resource Installation Folder";
            // 
            // cbResDir
            // 
            this.cbResDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbResDir.ContextMenuStrip = this.cbContextMenu;
            this.cbResDir.Enabled = false;
            this.cbResDir.FormattingEnabled = true;
            this.cbResDir.Location = new System.Drawing.Point(8, 49);
            this.cbResDir.Name = "cbResDir";
            this.cbResDir.Size = new System.Drawing.Size(406, 21);
            this.cbResDir.TabIndex = 9;
            this.toolTip1.SetToolTip(this.cbResDir, "Game Installation Folder");
            // 
            // btnBrowseResDir
            // 
            this.btnBrowseResDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseResDir.Location = new System.Drawing.Point(420, 47);
            this.btnBrowseResDir.Name = "btnBrowseResDir";
            this.btnBrowseResDir.Size = new System.Drawing.Size(95, 23);
            this.btnBrowseResDir.TabIndex = 10;
            this.btnBrowseResDir.Text = "Browse Folder...";
            this.btnBrowseResDir.UseVisualStyleBackColor = true;
            this.btnBrowseResDir.Click += new System.EventHandler(this.btnBrowseResDir_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnConvert, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 408);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 32);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(290, 3);
            this.btnExit.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(165, 3);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(3, 3, 25, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // dlgSelObject
            // 
            this.dlgSelObject.FileName = "Object or Mesh";
            this.dlgSelObject.Filter = "Object File|*.bin|Mesh File|*.e";
            // 
            // dlgResMod
            // 
            this.dlgResMod.FileName = "openFileDialog1";
            this.dlgResMod.Filter = "CRF files|*.crf|Zip Files|*.zip";
            // 
            // dlgBinToEPath
            // 
            this.dlgBinToEPath.FileName = "BinToE.exe";
            this.dlgBinToEPath.Filter = "EXE file|*.exe";
            // 
            // dlgEto3dsPath
            // 
            this.dlgEto3dsPath.FileName = "Eto3ds.exe";
            this.dlgEto3dsPath.Filter = "EXE file|*.exe";
            // 
            // dlgTexConvProgPath
            // 
            this.dlgTexConvProgPath.FileName = "Eto3ds.exe";
            this.dlgTexConvProgPath.Filter = "EXE file|*.exe";
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "BinMasterHelp.chm";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(411, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Press F1 to Load Help File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 452);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tabControl1);
            this.helpProvider1.SetHelpKeyword(this, "Intro.htm");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bin Master";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cbContextMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbObjModel;
        private System.Windows.Forms.Button btnObjBrowse;
        private System.Windows.Forms.Button btnModelName;
        private System.Windows.Forms.RadioButton rdo3dsConv;
        private System.Windows.Forms.RadioButton rdoEConv;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkNoResMods;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbResMod;
        private System.Windows.Forms.Button btnBrowseResMod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGameDir;
        private System.Windows.Forms.Button btnBrowseGameDir;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbConvObjDir;
        private System.Windows.Forms.Button btnBrowseConvObjDir;
        private System.Windows.Forms.CheckBox chkConvTexInObjDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbConvTexDir;
        private System.Windows.Forms.Button btnBrowseConvTexDir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBrowseEto3ds;
        private System.Windows.Forms.ComboBox cbEto3ds;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowseBintoe;
        private System.Windows.Forms.ComboBox cbBintoE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbTexFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSetTexConvCmd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTexConvCmd;
        private System.Windows.Forms.Button btnBrowseTexConvProg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTexConvProg;
        private System.Windows.Forms.CheckBox chkNoTextures;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkAutoSetResourceDir;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbResDir;
        private System.Windows.Forms.Button btnBrowseResDir;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog dlgSelObject;
        private System.Windows.Forms.FolderBrowserDialog dlgGameDir;
        private System.Windows.Forms.OpenFileDialog dlgResMod;
        private System.Windows.Forms.FolderBrowserDialog dlgConvObjOutput;
        private System.Windows.Forms.FolderBrowserDialog dlgConvTexDir;
        private System.Windows.Forms.OpenFileDialog dlgBinToEPath;
        private System.Windows.Forms.OpenFileDialog dlgEto3dsPath;
        private System.Windows.Forms.OpenFileDialog dlgTexConvProgPath;
        private System.Windows.Forms.FolderBrowserDialog dlgAltResDir;
        private System.Windows.Forms.ContextMenuStrip cbContextMenu;
        private System.Windows.Forms.ToolStripMenuItem rcOpenFolder;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ToolStripMenuItem editSavedItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllItemsToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label label11;
    }
}

