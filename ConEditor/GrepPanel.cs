using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Sgry.Azuki;
namespace ConEditor
{
    public partial class GrepPanel : UserControl
    {
        private const int incrementalIntervalMin = 10;
        private Binder binder;
        private bool constructingResults = false;

        public GrepPanel(Binder binder)
        {
            InitializeComponent();
            this.binder = binder;

            SearchEngine = new SearchEngine(binder);
            SearchEngine.ExecuteAtEdit = true;
            SearchEngine.Executed += SearchEngine_Executed;
            Restore();
        }

        private void SearchEngine_Executed(object sender, EventArgs e)
        {
            constructingResults = true;
            lstResult.Items.Clear();
            lstResult.Items.AddRange(SearchEngine.Result.ToArray());
            constructingResults = false;
        }

        public SearchEngine SearchEngine { get; private set; }

        /// <summary>
        /// 検索結果から何か選んだイベント
        /// </summary>
        public event EventHandler<GrepResultSelectedEventArgs> ResultSelectedChanged;

        /// <summary>
        /// インクリメンタルサーチの間隔(min=10ms)
        /// </summary>
        public int IncrementalInterval
        {
            get { return tmIncremental.Interval; }
            set
            {
                if (value <= incrementalIntervalMin)
                {
                    value = incrementalIntervalMin;
                }
                tmIncremental.Interval = value;
            }
        }

        /// <summary>
        /// キーワードのところにフォーカス
        /// </summary>
        public void FocusKeyword()
        {
            cmbKeyWord.Focus();
        }

        /// <summary>
        /// 最初の結果の場所へ
        /// </summary>
        public void SelectFirst()
        {
            if (lstResult.Items.Count != 0)
            {
                lstResult.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 最後の結果の場所へ
        /// </summary>
        public void SelectLast()
        {
            if (lstResult.Items.Count != 0)
            {
                lstResult.SelectedIndex = lstResult.Items.Count - 1;
            }
        }

        /// <summary>
        /// 次の結果の場所へ
        /// </summary>
        public void SelectNext()
        {
            if (lstResult.Items.Count != 0)
            {
                if (lstResult.SelectedIndex != lstResult.Items.Count - 1)
                {
                    lstResult.SelectedIndex++;
                }
                else
                {
                    lstResult.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 前の結果の場所へ
        /// </summary>
        public void SelectPrev()
        {
            if (lstResult.Items.Count != 0)
            {
                if (lstResult.SelectedIndex != 0)
                {
                    lstResult.SelectedIndex--;
                }
                else
                {
                    lstResult.SelectedIndex = lstResult.Items.Count - 1;
                }
            }
        }

        /// <summary>
        /// 履歴と設定のバックアップ
        /// </summary>
        public void Backup()
        {
        }

        /// <summary>
        /// 履歴と設定のレストア
        /// </summary>
        public void Restore()
        {
            SearchEngine.ExecuteAtEdit = true;
            SearchEngine.IgnoreContainBorder = true;
        }

        /// <summary>
        /// 選択されてるリストのところから置換開始。なければ最初から。
        /// </summary>
        public void ReplaceFromHear()
        {
            if (lstResult.Items.Count == 0) return;
            if (lstResult.SelectedIndex >= 0)
            {
                ShowReplaceDialog(false, lstResult.SelectedItem as SearchEngineResult);
            }
            else
            {
                ReplaceFromFirst();
            }
        }

        /// <summary>
        /// 最初から置換開始
        /// </summary>
        public void ReplaceFromFirst()
        {
            if (lstResult.Items.Count == 0) return;
            ShowReplaceDialog(false, lstResult.Items[0] as SearchEngineResult);
        }

        /// <summary>
        /// 全部置換
        /// </summary>
        public void ReplaceAll()
        {
            if (lstResult.Items.Count == 0) return;
            ShowReplaceDialog(true, lstResult.Items[0] as SearchEngineResult);
        }


        #region EventHandler
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIncremental_CheckedChanged(object sender, EventArgs e)
        {
            tmIncremental.Enabled = chkIncremental.Checked;
        }

        private void tmIncremental_Tick(object sender, EventArgs e)
        {
            SearchEngine.Execute();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //ここで履歴保存
            SearchEngine.Execute();
        }
        
        private void lstResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (constructingResults) return;

            var d = lstResult.SelectedIndex;
            if ((d >= 0) && (d < SearchEngine.ResultCount))
            {
                var result = SearchEngine[d];

                if (ResultSelectedChanged != null)
                {
                    ResultSelectedChanged(this, new GrepResultSelectedEventArgs(result));
                }
            }
        }

        private void chkCaseSensitive_CheckedChanged(object sender, EventArgs e)
        {
            SearchEngine.CaseSensitive = chkCaseSensitive.Checked;
        }

        private void chkRegExp_CheckedChanged(object sender, EventArgs e)
        {
            SearchEngine.UseRegExp = chkRegExp.Checked;
        }

        private void cmbKeyWord_TextUpdate(object sender, EventArgs e)
        {
            SearchEngine.Keyword = cmbKeyWord.Text;
        }

        private void cmbKeyWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SearchEngine.Execute();
            }

        }

        private void cmnuResult_Opening(object sender, CancelEventArgs e)
        {
            //検索結果がないか、再建策が必要な時はメニューを出さない
            e.Cancel = (lstResult.Items.Count == 0) | (SearchEngine.NeedUpdate);
            //検索結果のどれも選択されてなければ、個別の置換を出さない
            cmnuReplaceThis.Enabled = (lstResult.SelectedItems.Count != 0);
        }

        private void cmnuReplaceThis_Click(object sender, EventArgs e)
        {
            ReplaceFromHear();
        }

        private void cmnuReplaceAll_Click(object sender, EventArgs e)
        {
            ReplaceAll();
        }

        private void ShowReplaceDialog(bool replaceAll, SearchEngineResult resultBegin)
        {
            if (resultBegin == null) return;
            SearchEngine.BeginReplace();
            var dialog = new ReplaceKeywordInputDialog();
            dialog.ReplaceFrom = resultBegin.MatchedText;
            dialog.ReplaceAllMode = replaceAll;
            dialog.StartPosition = FormStartPosition.CenterParent;
            var replaced = false;
            if (ResultSelectedChanged != null)
            {
                ResultSelectedChanged(this, new GrepResultSelectedEventArgs(resultBegin));
            }
            dialog.FormClosed += (s, a) =>
            {
                SearchEngine.EndReplace();
                if (replaced)
                {
                    SearchEngine.Execute();
                }
            };
            dialog.ReplaceRequired += (s, a) =>
            {
                if (a.ReplaceAll)
                {
                    //全部置換
                    Console.WriteLine("replace all");
                    SearchEngine.ReplaceAllAfter(resultBegin, a.ReplaceTo);
                    dialog.Close();
                    replaced = true;
                }
                else
                {
                    //一戸置換
                    if (!a.Skip)
                    {
                        SearchEngine.Replace(resultBegin, a.ReplaceTo);
                        replaced = true;
                    }
                    if (a.RequireContinue)
                    {
                        resultBegin = processNextReplace(resultBegin, dialog);
                    }
                    else
                    {
                        dialog.Close();
                    }
                }
            };
            dialog.ShowDialog();
        }

        private SearchEngineResult processNextReplace(SearchEngineResult resultBegin, ReplaceKeywordInputDialog dialog)
        {
            var nextIndex = lstResult.Items.IndexOf(resultBegin) + 1;
            if (nextIndex < lstResult.Items.Count)
            {
                resultBegin = lstResult.Items[nextIndex] as SearchEngineResult;
                dialog.ReplaceFrom = resultBegin.MatchedText;
                if (ResultSelectedChanged != null)
                {
                    ResultSelectedChanged(this, new GrepResultSelectedEventArgs(resultBegin));
                }
            }
            else
            {
                dialog.Close();
            }

            return resultBegin;
        }

        #endregion


    }
}
