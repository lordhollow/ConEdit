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
        private const int resultWindow = 5;
        private Binder binder;

        List<SearchResult> results;
        bool constructingResults = false;

        static Regex ptnEscape = new Regex("\r|\n|\t");

        bool condChangeFlag = false;

        public GrepPanel(Binder binder)
        {
            InitializeComponent();
            Status = "";
            this.binder = binder;
            binder.Document.ContentChanged += Document_ContentChanged;
            Restore();

        }

        /// <summary>
        /// 検索結果から何か選んだイベント
        /// </summary>
        public event EventHandler<GrepResultSelectedEventArgs> ResultSelectedChanged;

        /// <summary>
        /// 検索条件が変わったとき～
        /// </summary>
        public event EventHandler ConditionChanged;

        /// <summary>
        /// ステータス
        /// </summary>
        public string Status
        {
            get
            {
                return lblStatus.Text;
            }
            private set
            {
                lblStatus.Text = value;
            }
        }

        /// <summary>
        /// 検索条件
        /// </summary>
        public Regex Condition { get; private set; }

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
        }

        /// <summary>
        /// 変わった結果を通知
        /// </summary>
        private void onConditionChanged()
        {
            if (condChangeFlag == false) return;
            ApplyConditions();
            CreateResult();
            condChangeFlag = false;

            if (ConditionChanged != null)
            {
               ConditionChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 検索を実行する...
        /// </summary>
        private void ApplyConditions()
        {
            string ptn = cmbKeyWord.Text;
            RegexOptions opt = RegexOptions.None;

            if (!chkCaseSensitive.Checked) opt = RegexOptions.IgnoreCase;
            if (!chkRegExp.Checked) ptn = Regex.Escape(ptn);

            if (string.IsNullOrEmpty(ptn))
            {
                Condition = null;
                Status = "";
            }
            else
            {
                try
                {
                    Condition = new Regex(ptn, opt);
                }
                catch
                {
                    Status = "正規表現パターン誤り";
                }
            }
        }

        /// <summary>
        /// 検索結果の構築
        /// </summary>
        private void CreateResult()
        {
            constructingResults = true;

            //検索結果を一回忘れる
            lstResult.Items.Clear();
            results = new List<SearchResult>();

            //検索キーワードなければここで終わり
            if (Condition == null) return;

            //検索結果を一通り調べる
            var result = binder.Document.FindNext(Condition, 0);
            while (result != null)
            {
                //prevString
                string prev = GetPrevString(result);

                //trailingString
                string trailing = GetTrailingString(result);

                //検索結果
                var matched = prev + "《" + escape(binder.Document.GetTextInRange(result.Begin, result.End)) + "》" + trailing;

                results.Add(result);
                lstResult.Items.Add(matched);

                //次へ
                result = binder.Document.FindNext(Condition, result.End);
            }
            constructingResults = false;
        }

        /// <summary>
        /// 検索結果の前の文字列
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private string GetPrevString(SearchResult result)
        {
            var begin = result.Begin - resultWindow;
            if (begin < 0) begin = 0;
            var beginHead = binder.Document.GetLineHeadIndexFromCharIndex(result.Begin);
            if (beginHead > begin) begin = beginHead;
            string prev = "";
            if (begin != result.Begin)
            {
                prev = escape(binder.Document.GetTextInRange(begin, result.Begin));
            }
            return prev;
        }

        /// <summary>
        /// 検索結果の後ろの文字列
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private string GetTrailingString(SearchResult result)
        {
            var end = result.End + resultWindow;
            if (end > binder.Document.Length) end = binder.Document.Length;
            var endTail = binder.Document.GetLineEndIndexFromCharIndex(result.End);
            if (endTail < end) end = endTail;
            string trailing = "";
            if (end != result.End)
            {
                trailing = escape(binder.Document.GetTextInRange(result.End, end));
            }
            return trailing;
        }

        /// <summary>
        /// リストに入れるために加工する
        /// </summary>
        /// <param name="matched"></param>
        /// <returns></returns>
        private string escape(string matched)
        {
            return ptnEscape.Replace(matched, " ");
        }

        #region EventHandler

        /// <summary>
        /// フォーム閉じる時、登録イベントを解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrepWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Backup();
            binder.Document.ContentChanged -= Document_ContentChanged;
        }

        /// <summary>
        /// 入力変えたとき、dirty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbKeyWord_TextChanged(object sender, EventArgs e)
        {
            condChangeFlag = true;
        }

        /// <summary>
        /// Aa変えたとき、dirty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkCaseSensitive_CheckedChanged(object sender, EventArgs e)
        {
            condChangeFlag = true;
        }

        /// <summary>
        /// 正規表現設定切り替えたとき、dirty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRegExp_CheckedChanged(object sender, EventArgs e)
        {
            condChangeFlag = true;
        }

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
            onConditionChanged();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            condChangeFlag = true;
            onConditionChanged();
        }

        private void chkFindAtEdit_CheckedChanged(object sender, EventArgs e)
        {
            //特に何もしない
        }

        private void lstResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (constructingResults) return;
            if (results == null) return;
            var d = lstResult.SelectedIndex;
            if ((d >= 0) && (d < results.Count))
            {
                var result = results[d];

                if (ResultSelectedChanged != null)
                {
                    ResultSelectedChanged(this, new GrepResultSelectedEventArgs(result));
                }
            }
        }

        void Document_ContentChanged(object sender, ContentChangedEventArgs e)
        {
            if (chkFindAtEdit.Checked && Condition != null)
            {
                CreateResult();
            }
        }

        #endregion
    }
}
