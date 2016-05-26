namespace ConEditor
{
    partial class ConEditorWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileGit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileGitConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileGitCommit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileGitHidtory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.spLR = new System.Windows.Forms.SplitContainer();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDirty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.azText = new Sgry.Azuki.WinForms.AzukiControl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblSelectionInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.chEncoding = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chActualFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuStrip.SuspendLayout();
            this.spLR.Panel1.SuspendLayout();
            this.spLR.Panel2.SuspendLayout();
            this.spLR.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // mnuStrip
            // 
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuSetting});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(700, 24);
            this.mnuStrip.TabIndex = 1;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileSaveall,
            this.toolStripSeparator1,
            this.mnuFileInsert,
            this.mnuFileAdd,
            this.toolStripMenuItem1,
            this.mnuFileGit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(66, 20);
            this.mnuFile.Text = "ファイル(&F)";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(232, 22);
            this.mnuFileOpen.Text = "開く(&O)";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(232, 22);
            this.mnuFileSave.Text = "保存(&S)";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileSaveall
            // 
            this.mnuFileSaveall.Name = "mnuFileSaveall";
            this.mnuFileSaveall.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveall.Size = new System.Drawing.Size(232, 22);
            this.mnuFileSaveall.Text = "すべて保存(&A)";
            this.mnuFileSaveall.Click += new System.EventHandler(this.mnuFileSaveall_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // mnuFileInsert
            // 
            this.mnuFileInsert.Name = "mnuFileInsert";
            this.mnuFileInsert.Size = new System.Drawing.Size(232, 22);
            this.mnuFileInsert.Text = "カーソル位置のファイルの前に追加";
            this.mnuFileInsert.Click += new System.EventHandler(this.mnuFileInsert_Click);
            // 
            // mnuFileAdd
            // 
            this.mnuFileAdd.Name = "mnuFileAdd";
            this.mnuFileAdd.Size = new System.Drawing.Size(232, 22);
            this.mnuFileAdd.Text = "末尾に追加";
            this.mnuFileAdd.Click += new System.EventHandler(this.mnuFileAdd_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(229, 6);
            // 
            // mnuFileGit
            // 
            this.mnuFileGit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileGitConfig,
            this.mnuFileGitCommit,
            this.mnuFileGitHidtory});
            this.mnuFileGit.Name = "mnuFileGit";
            this.mnuFileGit.Size = new System.Drawing.Size(232, 22);
            this.mnuFileGit.Text = "GIT連携(&G)";
            // 
            // mnuFileGitConfig
            // 
            this.mnuFileGitConfig.Name = "mnuFileGitConfig";
            this.mnuFileGitConfig.Size = new System.Drawing.Size(217, 22);
            this.mnuFileGitConfig.Text = "設定(&S)";
            this.mnuFileGitConfig.Click += new System.EventHandler(this.mnuFileGitConfig_Click);
            // 
            // mnuFileGitCommit
            // 
            this.mnuFileGitCommit.Name = "mnuFileGitCommit";
            this.mnuFileGitCommit.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.mnuFileGitCommit.Size = new System.Drawing.Size(217, 22);
            this.mnuFileGitCommit.Text = "保存してコミット";
            this.mnuFileGitCommit.Click += new System.EventHandler(this.mnuFileGitCommit_Click);
            // 
            // mnuFileGitHidtory
            // 
            this.mnuFileGitHidtory.Name = "mnuFileGitHidtory";
            this.mnuFileGitHidtory.Size = new System.Drawing.Size(217, 22);
            this.mnuFileGitHidtory.Text = "履歴(&H)";
            this.mnuFileGitHidtory.Click += new System.EventHandler(this.mnuFileGitHidtory_Click);
            // 
            // mnuSetting
            // 
            this.mnuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettingSetting});
            this.mnuSetting.Name = "mnuSetting";
            this.mnuSetting.Size = new System.Drawing.Size(57, 20);
            this.mnuSetting.Text = "設定(&S)";
            // 
            // mnuSettingSetting
            // 
            this.mnuSettingSetting.Name = "mnuSettingSetting";
            this.mnuSettingSetting.Size = new System.Drawing.Size(112, 22);
            this.mnuSettingSetting.Text = "設定(&S)";
            this.mnuSettingSetting.Click += new System.EventHandler(this.mnuSettingSetting_Click);
            // 
            // spLR
            // 
            this.spLR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spLR.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spLR.Location = new System.Drawing.Point(0, 24);
            this.spLR.Name = "spLR";
            // 
            // spLR.Panel1
            // 
            this.spLR.Panel1.Controls.Add(this.lvFiles);
            // 
            // spLR.Panel2
            // 
            this.spLR.Panel2.Controls.Add(this.azText);
            this.spLR.Size = new System.Drawing.Size(700, 317);
            this.spLR.SplitterDistance = 191;
            this.spLR.TabIndex = 2;
            // 
            // lvFiles
            // 
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFilename,
            this.chDirty,
            this.chCount,
            this.chEncoding,
            this.chActualFileSize});
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.GridLines = true;
            this.lvFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(0, 0);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(191, 317);
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            // 
            // chFilename
            // 
            this.chFilename.DisplayIndex = 1;
            this.chFilename.Text = "file";
            this.chFilename.Width = 85;
            // 
            // chDirty
            // 
            this.chDirty.DisplayIndex = 0;
            this.chDirty.Text = "*";
            this.chDirty.Width = 16;
            // 
            // chCount
            // 
            this.chCount.Text = "count";
            this.chCount.Width = 53;
            // 
            // azText
            // 
            this.azText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.azText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.azText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.azText.DrawingOption = ((Sgry.Azuki.DrawingOption)((((((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsTab) 
            | Sgry.Azuki.DrawingOption.DrawsEol) 
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine) 
            | Sgry.Azuki.DrawingOption.ShowsLineNumber) 
            | Sgry.Azuki.DrawingOption.ShowsHRuler) 
            | Sgry.Azuki.DrawingOption.ShowsDirtBar) 
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
            this.azText.FirstVisibleLine = 0;
            this.azText.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            fontInfo1.Name = "MS UI Gothic";
            fontInfo1.Size = 9;
            fontInfo1.Style = System.Drawing.FontStyle.Regular;
            this.azText.FontInfo = fontInfo1;
            this.azText.ForeColor = System.Drawing.Color.Black;
            this.azText.GetSelectTextFilter = null;
            this.azText.Location = new System.Drawing.Point(0, 0);
            this.azText.Name = "azText";
            this.azText.ScrollPos = new System.Drawing.Point(0, 0);
            this.azText.ShowsHRuler = true;
            this.azText.Size = new System.Drawing.Size(505, 317);
            this.azText.TabIndex = 0;
            this.azText.ViewType = Sgry.Azuki.ViewType.WrappedProportional;
            this.azText.ViewWidth = 4129;
            this.azText.Resize += new System.EventHandler(this.azText_Resize);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSelectionInfo,
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 341);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(700, 23);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblSelectionInfo
            // 
            this.lblSelectionInfo.AutoSize = false;
            this.lblSelectionInfo.Name = "lblSelectionInfo";
            this.lblSelectionInfo.Size = new System.Drawing.Size(128, 18);
            this.lblSelectionInfo.Text = "lblSelectionInfo";
            this.lblSelectionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(557, 18);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "lblStatus";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chEncoding
            // 
            this.chEncoding.Text = "encode";
            // 
            // chActualFileSize
            // 
            this.chActualFileSize.Text = "FileSize";
            // 
            // ConEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 364);
            this.Controls.Add(this.spLR);
            this.Controls.Add(this.mnuStrip);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.mnuStrip;
            this.Name = "ConEditorWindow";
            this.Text = "こねでぃた";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConEditorWindow_FormClosing);
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.spLR.Panel1.ResumeLayout(false);
            this.spLR.Panel2.ResumeLayout(false);
            this.spLR.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveall;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileGit;
        private System.Windows.Forms.ToolStripMenuItem mnuFileGitConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuFileGitCommit;
        private System.Windows.Forms.ToolStripMenuItem mnuFileGitHidtory;
        private System.Windows.Forms.SplitContainer spLR;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader chDirty;
        private System.Windows.Forms.ColumnHeader chFilename;
        private System.Windows.Forms.ColumnHeader chCount;
        private Sgry.Azuki.WinForms.AzukiControl azText;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblSelectionInfo;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuSetting;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileInsert;
        private System.Windows.Forms.ToolStripMenuItem mnuFileAdd;
        private System.Windows.Forms.ColumnHeader chEncoding;
        private System.Windows.Forms.ColumnHeader chActualFileSize;
    }
}

