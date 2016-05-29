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
            this.cmnuBinderContentList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuBinderReload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuBinderUTF8 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.spLR = new System.Windows.Forms.SplitContainer();
            this.tbExplorer = new System.Windows.Forms.TabControl();
            this.tpContent = new System.Windows.Forms.TabPage();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDirty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEncoding = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chActualFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpOutline = new System.Windows.Forms.TabPage();
            this.lstOutline = new System.Windows.Forms.ListBox();
            this.chkOutline = new System.Windows.Forms.CheckBox();
            this.spRLR = new System.Windows.Forms.SplitContainer();
            this.azText = new Sgry.Azuki.WinForms.AzukiControl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblSelectionInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuFineClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFinedNext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFinePrev = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindLast = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFineGoTop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindGoEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindGoTopOfThis = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindGoEndOfThis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFindReplaceFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindReplaceTrailing = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindReplaceAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuBinderContentList.SuspendLayout();
            this.mnuStrip.SuspendLayout();
            this.spLR.Panel1.SuspendLayout();
            this.spLR.Panel2.SuspendLayout();
            this.spLR.SuspendLayout();
            this.tbExplorer.SuspendLayout();
            this.tpContent.SuspendLayout();
            this.tpOutline.SuspendLayout();
            this.spRLR.Panel1.SuspendLayout();
            this.spRLR.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmnuBinderContentList
            // 
            this.cmnuBinderContentList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuBinderReload,
            this.cmnuBinderUTF8});
            this.cmnuBinderContentList.Name = "contextMenu";
            this.cmnuBinderContentList.Size = new System.Drawing.Size(203, 48);
            this.cmnuBinderContentList.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuBinderContentList_Opening);
            // 
            // cmnuBinderReload
            // 
            this.cmnuBinderReload.Name = "cmnuBinderReload";
            this.cmnuBinderReload.Size = new System.Drawing.Size(202, 22);
            this.cmnuBinderReload.Text = "別のエンコードで開きなおす";
            // 
            // cmnuBinderUTF8
            // 
            this.cmnuBinderUTF8.Name = "cmnuBinderUTF8";
            this.cmnuBinderUTF8.Size = new System.Drawing.Size(202, 22);
            this.cmnuBinderUTF8.Text = "UTF-8で保存するようにする";
            this.cmnuBinderUTF8.Click += new System.EventHandler(this.cmnuBinderUTF8_Click);
            // 
            // mnuStrip
            // 
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuFind,
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
            // mnuFind
            // 
            this.mnuFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFindFind,
            this.mnuFineClose,
            this.toolStripMenuItem2,
            this.mnuFinedNext,
            this.mnuFinePrev,
            this.mnuFindFirst,
            this.mnuFindLast,
            this.toolStripMenuItem3,
            this.mnuFindReplaceFirst,
            this.mnuFindReplaceTrailing,
            this.mnuFindReplaceAll,
            this.toolStripMenuItem4,
            this.mnuFindGoTopOfThis,
            this.mnuFindGoEndOfThis,
            this.mnuFineGoTop,
            this.mnuFindGoEnd});
            this.mnuFind.Name = "mnuFind";
            this.mnuFind.Size = new System.Drawing.Size(57, 20);
            this.mnuFind.Text = "検索(&F)";
            this.mnuFind.DropDownOpening += new System.EventHandler(this.mnuFind_DropDownOpening);
            // 
            // mnuFindFind
            // 
            this.mnuFindFind.Name = "mnuFindFind";
            this.mnuFindFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuFindFind.Size = new System.Drawing.Size(267, 22);
            this.mnuFindFind.Text = "検索(&F)";
            this.mnuFindFind.Click += new System.EventHandler(this.mnuFindFind_Click);
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
            this.spLR.Panel1.Controls.Add(this.tbExplorer);
            // 
            // spLR.Panel2
            // 
            this.spLR.Panel2.Controls.Add(this.spRLR);
            this.spLR.Size = new System.Drawing.Size(700, 317);
            this.spLR.SplitterDistance = 191;
            this.spLR.TabIndex = 2;
            // 
            // tbExplorer
            // 
            this.tbExplorer.Controls.Add(this.tpContent);
            this.tbExplorer.Controls.Add(this.tpOutline);
            this.tbExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbExplorer.Location = new System.Drawing.Point(0, 0);
            this.tbExplorer.Name = "tbExplorer";
            this.tbExplorer.SelectedIndex = 0;
            this.tbExplorer.Size = new System.Drawing.Size(191, 317);
            this.tbExplorer.TabIndex = 1;
            // 
            // tpContent
            // 
            this.tpContent.Controls.Add(this.lvFiles);
            this.tpContent.Location = new System.Drawing.Point(4, 22);
            this.tpContent.Name = "tpContent";
            this.tpContent.Padding = new System.Windows.Forms.Padding(3);
            this.tpContent.Size = new System.Drawing.Size(183, 291);
            this.tpContent.TabIndex = 0;
            this.tpContent.Text = "Content";
            this.tpContent.UseVisualStyleBackColor = true;
            // 
            // lvFiles
            // 
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFilename,
            this.chDirty,
            this.chCount,
            this.chEncoding,
            this.chActualFileSize});
            this.lvFiles.ContextMenuStrip = this.cmnuBinderContentList;
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.GridLines = true;
            this.lvFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(3, 3);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(177, 285);
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
            // chEncoding
            // 
            this.chEncoding.Text = "encode";
            // 
            // chActualFileSize
            // 
            this.chActualFileSize.Text = "FileSize";
            // 
            // tpOutline
            // 
            this.tpOutline.Controls.Add(this.lstOutline);
            this.tpOutline.Controls.Add(this.chkOutline);
            this.tpOutline.Location = new System.Drawing.Point(4, 22);
            this.tpOutline.Name = "tpOutline";
            this.tpOutline.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutline.Size = new System.Drawing.Size(183, 291);
            this.tpOutline.TabIndex = 1;
            this.tpOutline.Text = "Outline";
            this.tpOutline.UseVisualStyleBackColor = true;
            // 
            // lstOutline
            // 
            this.lstOutline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOutline.FormattingEnabled = true;
            this.lstOutline.ItemHeight = 12;
            this.lstOutline.Location = new System.Drawing.Point(3, 19);
            this.lstOutline.Name = "lstOutline";
            this.lstOutline.Size = new System.Drawing.Size(177, 269);
            this.lstOutline.TabIndex = 1;
            this.lstOutline.SelectedIndexChanged += new System.EventHandler(this.lstOutline_SelectedIndexChanged);
            // 
            // chkOutline
            // 
            this.chkOutline.AutoSize = true;
            this.chkOutline.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkOutline.Location = new System.Drawing.Point(3, 3);
            this.chkOutline.Name = "chkOutline";
            this.chkOutline.Size = new System.Drawing.Size(177, 16);
            this.chkOutline.TabIndex = 0;
            this.chkOutline.Text = "アウトラインを有効にする";
            this.chkOutline.UseVisualStyleBackColor = true;
            this.chkOutline.CheckedChanged += new System.EventHandler(this.chkOutline_CheckedChanged);
            // 
            // spRLR
            // 
            this.spRLR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spRLR.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spRLR.Location = new System.Drawing.Point(0, 0);
            this.spRLR.Name = "spRLR";
            // 
            // spRLR.Panel1
            // 
            this.spRLR.Panel1.Controls.Add(this.azText);
            this.spRLR.Panel2Collapsed = true;
            this.spRLR.Size = new System.Drawing.Size(505, 317);
            this.spRLR.SplitterDistance = 362;
            this.spRLR.TabIndex = 1;
            // 
            // azText
            // 
            this.azText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.azText.ContextMenuStrip = this.cmnuBinderContentList;
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
            // mnuFineClose
            // 
            this.mnuFineClose.Enabled = false;
            this.mnuFineClose.Name = "mnuFineClose";
            this.mnuFineClose.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.mnuFineClose.Size = new System.Drawing.Size(267, 22);
            this.mnuFineClose.Text = "検索ダイアログを閉じる(&C)";
            this.mnuFineClose.Click += new System.EventHandler(this.mnuFineClose_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(264, 6);
            // 
            // mnuFinedNext
            // 
            this.mnuFinedNext.Name = "mnuFinedNext";
            this.mnuFinedNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuFinedNext.Size = new System.Drawing.Size(267, 22);
            this.mnuFinedNext.Text = "次を検索";
            this.mnuFinedNext.Click += new System.EventHandler(this.mnuFinedNext_Click);
            // 
            // mnuFinePrev
            // 
            this.mnuFinePrev.Name = "mnuFinePrev";
            this.mnuFinePrev.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.mnuFinePrev.Size = new System.Drawing.Size(267, 22);
            this.mnuFinePrev.Text = "前を検索";
            this.mnuFinePrev.Click += new System.EventHandler(this.mnuFinePrev_Click);
            // 
            // mnuFindFirst
            // 
            this.mnuFindFirst.Name = "mnuFindFirst";
            this.mnuFindFirst.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.mnuFindFirst.Size = new System.Drawing.Size(267, 22);
            this.mnuFindFirst.Text = "最初の検索結果";
            this.mnuFindFirst.Click += new System.EventHandler(this.mnuFindFirst_Click);
            // 
            // mnuFindLast
            // 
            this.mnuFindLast.Name = "mnuFindLast";
            this.mnuFindLast.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F3)));
            this.mnuFindLast.Size = new System.Drawing.Size(267, 22);
            this.mnuFindLast.Text = "最後の検索結果";
            this.mnuFindLast.Click += new System.EventHandler(this.mnuFindLast_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(264, 6);
            // 
            // mnuFineGoTop
            // 
            this.mnuFineGoTop.Name = "mnuFineGoTop";
            this.mnuFineGoTop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F7)));
            this.mnuFineGoTop.Size = new System.Drawing.Size(267, 22);
            this.mnuFineGoTop.Text = "先頭";
            this.mnuFineGoTop.Click += new System.EventHandler(this.mnuFineGoTop_Click);
            // 
            // mnuFindGoEnd
            // 
            this.mnuFindGoEnd.Name = "mnuFindGoEnd";
            this.mnuFindGoEnd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F8)));
            this.mnuFindGoEnd.Size = new System.Drawing.Size(267, 22);
            this.mnuFindGoEnd.Text = "末尾";
            this.mnuFindGoEnd.Click += new System.EventHandler(this.mnuFindGoEnd_Click);
            // 
            // mnuFindGoTopOfThis
            // 
            this.mnuFindGoTopOfThis.Name = "mnuFindGoTopOfThis";
            this.mnuFindGoTopOfThis.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuFindGoTopOfThis.Size = new System.Drawing.Size(267, 22);
            this.mnuFindGoTopOfThis.Text = "この文書の先頭";
            this.mnuFindGoTopOfThis.Click += new System.EventHandler(this.mnuFindGoTopOfThis_Click);
            // 
            // mnuFindGoEndOfThis
            // 
            this.mnuFindGoEndOfThis.Name = "mnuFindGoEndOfThis";
            this.mnuFindGoEndOfThis.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mnuFindGoEndOfThis.Size = new System.Drawing.Size(267, 22);
            this.mnuFindGoEndOfThis.Text = "この文書の末尾";
            this.mnuFindGoEndOfThis.Click += new System.EventHandler(this.mnuFindGoEndOfThis_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(264, 6);
            // 
            // mnuFindReplaceFirst
            // 
            this.mnuFindReplaceFirst.Name = "mnuFindReplaceFirst";
            this.mnuFindReplaceFirst.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
            this.mnuFindReplaceFirst.Size = new System.Drawing.Size(267, 22);
            this.mnuFindReplaceFirst.Text = "最初から置換";
            this.mnuFindReplaceFirst.Click += new System.EventHandler(this.mnuFindReplaceFirst_Click);
            // 
            // mnuFindReplaceTrailing
            // 
            this.mnuFindReplaceTrailing.Name = "mnuFindReplaceTrailing";
            this.mnuFindReplaceTrailing.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuFindReplaceTrailing.Size = new System.Drawing.Size(267, 22);
            this.mnuFindReplaceTrailing.Text = "以降を置換";
            this.mnuFindReplaceTrailing.Click += new System.EventHandler(this.mnuFindReplaceTrailing_Click);
            // 
            // mnuFindReplaceAll
            // 
            this.mnuFindReplaceAll.Name = "mnuFindReplaceAll";
            this.mnuFindReplaceAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.mnuFindReplaceAll.Size = new System.Drawing.Size(267, 22);
            this.mnuFindReplaceAll.Text = "すべて置換";
            this.mnuFindReplaceAll.Click += new System.EventHandler(this.mnuFindReplaceAll_Click);
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
            this.cmnuBinderContentList.ResumeLayout(false);
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.spLR.Panel1.ResumeLayout(false);
            this.spLR.Panel2.ResumeLayout(false);
            this.spLR.ResumeLayout(false);
            this.tbExplorer.ResumeLayout(false);
            this.tpContent.ResumeLayout(false);
            this.tpOutline.ResumeLayout(false);
            this.tpOutline.PerformLayout();
            this.spRLR.Panel1.ResumeLayout(false);
            this.spRLR.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmnuBinderContentList;
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
        private System.Windows.Forms.TabControl tbExplorer;
        private System.Windows.Forms.TabPage tpContent;
        private System.Windows.Forms.TabPage tpOutline;
        private System.Windows.Forms.ListBox lstOutline;
        private System.Windows.Forms.CheckBox chkOutline;
        private System.Windows.Forms.ToolStripMenuItem cmnuBinderReload;
        private System.Windows.Forms.ToolStripMenuItem cmnuBinderUTF8;
        private System.Windows.Forms.ToolStripMenuItem mnuFind;
        private System.Windows.Forms.ToolStripMenuItem mnuFindFind;
        private System.Windows.Forms.SplitContainer spRLR;
        private System.Windows.Forms.ToolStripMenuItem mnuFineClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuFinedNext;
        private System.Windows.Forms.ToolStripMenuItem mnuFinePrev;
        private System.Windows.Forms.ToolStripMenuItem mnuFindFirst;
        private System.Windows.Forms.ToolStripMenuItem mnuFindLast;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuFineGoTop;
        private System.Windows.Forms.ToolStripMenuItem mnuFindGoEnd;
        private System.Windows.Forms.ToolStripMenuItem mnuFindGoTopOfThis;
        private System.Windows.Forms.ToolStripMenuItem mnuFindGoEndOfThis;
        private System.Windows.Forms.ToolStripMenuItem mnuFindReplaceFirst;
        private System.Windows.Forms.ToolStripMenuItem mnuFindReplaceTrailing;
        private System.Windows.Forms.ToolStripMenuItem mnuFindReplaceAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    }
}

