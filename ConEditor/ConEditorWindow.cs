using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sgry.Azuki;

namespace ConEditor
{
    /// <summary>
    /// エディタ１枚のウィンドウ
    /// </summary>
    public partial class ConEditorWindow : Form
    {
        Configulation config;
        ActualLineNumberConverterProvider actualNumberConverter = new ActualLineNumberConverterProvider();

        const string _dbg_file = @"";

        /// <summary>
        /// バインダ（編集中のファイル群）
        /// </summary>
        Binder _binder;
        private Binder binder
        {
            get { return _binder; }
            set
            {
                _binder = value;
                actualNumberConverter.Binder = binder;
            }
        }

        /// <summary>
        /// lvFilesイベント抑止用フラグ
        /// </summary>
        /// <remarks>
        /// lvFilesに自分で（ロジックで）Selectedを設定するときにハンドラが動かないようにTRUEにし、セット後にFALSEに戻すこと。
        /// </remarks>
        bool lvFilesSelfIndexSet = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConEditorWindow()
        {
            InitializeComponent();

            lblSelectionInfo.Text = "";
            lblStatus.Text = "";

            var conf = ConfigulationLoader.Load(ConfigulationLoader.GlobalConfigPath);
            if (conf == null)
            {
                conf = new Configulation();
                ConfigulationLoader.Save(ConfigulationLoader.GlobalConfigPath, conf);
            }
            config = conf;
            ApplyConfigulation();
            azText.ColorScheme = AzukiMarkerForConEdit.ColorScheme;

            //hook to document(binder.Loadで新しいドキュメントになるのでその時には再フックが必要
            azText.Document.BeforeContentChange += doc_BeforeContentChange;
            azText.Document.ContentChanged += doc_ContentChanged;
            azText.Document.SelectionChanged += doc_SelectionChanged;
        }

        /// <summary>
        /// 開く
        /// </summary>
        public void ShowOpenFileDialog()
        {
            //死ぬ前の保存確認
            if (confilmSaveOnExit() == false)
            {
                //保存キャンセルされたら読み込みしない
                return;
            }

            string loadFolder;
            if (string.IsNullOrEmpty(_dbg_file))
            {
                var ofd = new FolderBrowserDialog();
                ofd.ShowNewFolderButton = true;
                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    //フォルダ選択しなかったら読み込まない
                    return;
                }
                loadFolder = ofd.SelectedPath;
            }
            else
            {
                loadFolder = _dbg_file;
            }

            binder = Binder.CreateBinder(loadFolder);
            var result = binder.Load();

            if (binder.Count == 0)
            {
                //編集対象のファイルはなかったが何かあったとき、ここで作業するか確認する
                //binderdef.xml等は除外した方がいいのかもしれない・・・
                if (System.IO.Directory.GetFiles(loadFolder).Length != 0)
                {
                    if (MessageBox.Show("選択したフォルダには編集対象ファイルを確認できませんでしたが、他にファイルが存在します。" + Environment.NewLine
                        + "このフォルダで新規に編集対象ファイルを作成しますか？" + Environment.NewLine
                        + Environment.NewLine
                        + loadFolder, "確認", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        //続けないので戻る
                        return;
                    }
                }
                ShowNewContentDialog(null);
            }

            var doc = binder.Document;
            azText.Document = doc;
            doc.BeforeContentChange += doc_BeforeContentChange;
            doc.ContentChanged += doc_ContentChanged;
            doc.SelectionChanged += doc_SelectionChanged;
            binder.BinderModified += binder_BinderModified;
            binder.ContentModified += binder_ContentModified;
            azText.GetSelectTextFilter = azText_IsCopyableLine;

            lvFiles.Items.Clear();
            for (var i = 0; i < binder.Count; i++)
            {
                var content = binder[i];
                var item = new BinderContentListViewItem(content);
                lvFiles.Items.Add(item);
            }

            binder.EnableOutline = chkOutline.Checked;
            lstOutline.DataSource = binder.Outline;
            lstOutline.DisplayMember = "Text";
        }

        /// <summary>
        /// 新コンテント入力ダイアログ
        /// </summary>
        public void ShowNewContentDialog(BinderContent beforeThis)
        {
            if (binder == null) return;
            var dialog = new NewFileDialog(binder);
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var f = dialog.NewFileName;
            try
            {
                binder.CreateNewContent(f, beforeThis);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void SaveCurrent()
        {
            if (binder == null) return;
            int b;
            int e;
            azText.GetSelection(out b, out e);
            binder.Save(b, e);
        }

        /// <summary>
        /// 全部保存
        /// </summary>
        public void SaveAll()
        {
            if (binder == null) return;
            binder.Save();
        }

        /// <summary>
        /// GIT設定
        /// </summary>
        public void ShowGitConfigDialog()
        {
            if (binder == null) return;
            GitTool.Instance.GitPath = config.GitPath;
            var f = new GitInitDialog(binder.Path);
            f.ShowDialog();
            if (f.GitPath != config.GitPath)
            {
                config.GitPath = f.GitPath;
                ConfigulationLoader.Save(ConfigulationLoader.GlobalConfigPath, config);
            }
        }

        /// <summary>
        /// GITコミット
        /// </summary>
        public void GitCommit()
        {
            if (binder == null) return;
            var f = new GitCommitDialog(binder.Path);
            f.ShowDialog();
        }

        /// <summary>
        /// GIT履歴
        /// </summary>
        public void GitShowHistory()
        {
            if (binder == null) return;
            var f = new GitHistoryDialog(binder.Path);
            f.ShowDialog();
        }

        /// <summary>
        /// 設定
        /// </summary>
        public void ShowConfigDialog()
        {
            var d = new ConfigDialog(config);
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ConfigulationLoader.Save(ConfigulationLoader.GlobalConfigPath, config);
                ApplyConfigulation();
            }
        }

        #region private 

        /// <summary>
        /// 設定を適用する
        /// </summary>
        private void ApplyConfigulation()
        {
            azText.FontInfo = new Sgry.Azuki.FontInfo(config.FontName, config.FontSize, FontStyle.Regular);
            azText.ViewType = config.Wordwrap ? ViewType.WrappedProportional : ViewType.Proportional;
            actualNumberConverter.Binder = binder;
            actualNumberConverter.Method = config.LineNoMethod;
            azText.View.ActualLineNumberConverter = actualNumberConverter.ActualLineNumberConverter;
            azText.View.LineNumberWidthPad = actualNumberConverter.LineNumberPad;
            azText.View.ShowLineNumber = actualNumberConverter.ShowLineNumber;

            if (config.Width <= 0)
            {
                azText.ViewWidth = azText.ClientSize.Width;
            }
            else
            {
                azText.ViewWidth = azText.View.HRulerUnitWidth * config.Width;
            }

        }

        /// <summary>
        /// 死ぬ前の保存確認
        /// </summary>
        private bool confilmSaveOnExit()
        {
            if ((binder != null) && (binder.Dirty))
            {
                var select = MessageBox.Show("すべての変更済みデータを保存しますか？", "確認", MessageBoxButtons.YesNoCancel);
                if (select == DialogResult.Yes)
                {
                    //保存して(ついでにコミットもして)true
                    SaveAll();
                    GitCommit();
                    return true;
                }
                else if (select == DialogResult.No)
                {
                    //保存せずにtrue
                    return true;
                }
                else
                {
                    //キャンセルしたらfalse
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// キャレット位置をコンテンツリストでハイライトする
        /// </summary>
        void selectLvFilesByCaret()
        {
            if (binder == null) return;
            int b;
            int e;
            azText.GetSelection(out b, out e);
            var bc = binder.GetBinderContentFromCharet(b);
            if (bc != null)
            {
                lvFilesSelfIndexSet = true;
                lvFiles.Items[bc.Index].Selected = true;
                lvFilesSelfIndexSet = false;
            }
        }

        void selectLstOutlineByCaret()
        {
            if (binder == null) return;
            if (binder.Outline == null) return;
            int b;
            int e;
            azText.GetSelection(out b, out e);
            var oc = binder.Outline.GetComponentIndexFromCaret(b);
            if (oc != null)
            {
                lvFilesSelfIndexSet = true;
                lstOutline.SelectedItem = oc;
                lvFilesSelfIndexSet = false;
            }
        }



        #endregion

            #region Click Handler

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            ShowOpenFileDialog();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            SaveCurrent();
        }

        private void mnuFileSaveall_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void mnuFileGitConfig_Click(object sender, EventArgs e)
        {
            ShowGitConfigDialog();
        }

        private void mnuFileGitCommit_Click(object sender, EventArgs e)
        {
            SaveAll();
            GitCommit();
        }

        private void mnuFileGitHidtory_Click(object sender, EventArgs e)
        {
            GitShowHistory();
        }

        private void mnuSettingSetting_Click(object sender, EventArgs e)
        {
            ShowConfigDialog();
        }


        private void mnuFileInsert_Click(object sender, EventArgs e)
        {
            if (binder == null) return;
            int b;
            int end;
            azText.GetSelection(out b, out end);
            var bc = binder.GetBinderContentFromCharet(b);
            ShowNewContentDialog(bc);
        }

        private void mnuFileAdd_Click(object sender, EventArgs e)
        {
            ShowNewContentDialog(null);
        }


        #endregion

        #region other handler

        void doc_BeforeContentChange(object sender, Sgry.Azuki.BeforeContentChangeEventArgs e)
        {
            //編集時にバインド境界を無視するための処理
            if (binder == null)
            {
                e.Cancel = true;
                return;
            }
            if (binder.Reconstructing)
            {
                e.Cancel = false;
                return;
            }
            if (binder.isTextIncludeBinderBorder(e.Index, e.OldText) == true)
            {
                e.Cancel = true;
            }
        }

        void doc_ContentChanged(object sender, Sgry.Azuki.ContentChangedEventArgs e)
        {
            //編集内容をバインダに伝える
            if (binder == null) return;
            if (binder.Reconstructing == false)
            {
                binder.NotifyReplace(e.Index, e.OldText, e.NewText);
            }
        }

        void doc_SelectionChanged(object sender, Sgry.Azuki.SelectionChangedEventArgs e)
        {
            //選択範囲の情報を下に表示＆編集中のコンテントをリストでハイライト
            int b;
            int end;
            azText.GetSelection(out b, out end);
            lblSelectionInfo.Text = string.Format("[{0}-{1})", b, end);

            if (binder == null) return;
            if ((binder.Reconstructing == false) && (lvFilesSelfIndexSet == false))
            {
                selectLvFilesByCaret();
                selectLstOutlineByCaret();
            }
        }

        void binder_BinderModified(object sender, EventArgs e)
        {
            lvFilesSelfIndexSet = true;
            lvFiles.Items.Clear();
            for (var i = 0; i < binder.Count; i++)
            {
                var content = binder[i];
                var item = new BinderContentListViewItem(content);
                lvFiles.Items.Add(item);
            }
            lvFilesSelfIndexSet = false;

            selectLvFilesByCaret();
        }

        void binder_ContentModified(object sender, BinderModifiedEventArgs e)
        {
            //リストの表示を修正
            foreach (var index in e.Indicies)
            {
                (lvFiles.Items[index] as BinderContentListViewItem).UpdateDirty();
            }
        }

        private void azText_Resize(object sender, EventArgs e)
        {
            if ((config != null) && (config.Wordwrap) && (config.Width <= 0))
            {
                azText.ViewWidth = azText.ClientSize.Width;
            }
        }

        private bool azText_IsCopyableLine(int lineNo)
        {
            //バインダ境界でなければコピー可能
            if (binder == null) return false;
            return !binder.IsBindBorder(lineNo);
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (binder == null) return;
            if (lvFilesSelfIndexSet) return;

            BinderContent content = null;
            if ((lvFiles.SelectedIndices != null) && (lvFiles.SelectedIndices.Count != 0))
            {
                var lvItem = lvFiles.SelectedItems[0] as BinderContentListViewItem;
                if (lvItem != null)
                {
                    content = lvItem.Content;
                    var caretPos = azText.Document.GetCharIndexFromLineColumnIndex(content.LogicalStartLineInDocumnet, 0);
                    ScrollTo(caretPos, true);
                    return;
                }
            }
            //選択なくなったら末尾へ
            ScrollTo(azText.TextLength, false);
        }

        private void ConEditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (confilmSaveOnExit() == false)
            {
                e.Cancel = true;
            }
        }

        private void chkOutline_CheckedChanged(object sender, EventArgs e)
        {
            if (binder != null)
            {
                binder.EnableOutline = chkOutline.Checked;
                lstOutline.DataSource = binder.Outline;
            }
        }


        #endregion

        private void lstOutline_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (binder == null) return;
            if (lvFilesSelfIndexSet) return;
            if (lstOutline.SelectedIndex >= 0)
            {
                var item = lstOutline.SelectedItem as OutlineComponent;
                if (item != null)
                {
                    ScrollTo(item.BeginAt, true);
                }
            }
        }

        private void ScrollTo(int caret, bool showInTop)
        {
            lvFilesSelfIndexSet = true;
            if (showInTop)
            {
                azText.SetSelection(azText.TextLength, azText.TextLength);
                azText.ScrollToCaret();
            }
            azText.SetSelection(caret, caret);
            azText.ScrollToCaret();
            lvFilesSelfIndexSet = false;
        }
    }
}
