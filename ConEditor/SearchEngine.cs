using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Sgry.Azuki;

namespace ConEditor
{
    /// <summary>
    /// 検索エンジン
    /// </summary>
    /// <remarks>
    /// 検索結果を出すところまでが責務。
    /// とりあえず今はフォームと1:1対応する前提で書いている。
    /// エンジン1に対してフォームnを使いたい場合、
    /// Status以外のプロパティの変化でもPropertyChangedを発火させるべき。
    /// </remarks>
    class SearchEngine : System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// 検索結果の前後何文字を抽出するか
        /// </summary>
        private const int resultWindow = 5;

        /// <summary>
        /// 検索結果の前後を抽出したとき行頭や行末に達さなかったときに付与する文字列
        /// </summary>
        private const string attentionLead = "…";

        /// <summary>
        /// 検索対象バインダ
        /// </summary>
        private Binder binder;

        /// <summary>
        /// 検索結果リスト
        /// </summary>
        private List<SearchEngineResult> results = new List<SearchEngineResult>();

        /// <summary>
        /// 検索結果ステータス
        /// </summary>
        string status;

        /// <summary>
        /// 検索結果抽出結果から空白で置換する文字
        /// </summary>
        static Regex ptnEscape = new Regex("\r|\n|\t");

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="binder"></param>
        public SearchEngine(Binder binder)
        {
            Status = "";
            this.binder = binder;
            binder.Document.ContentChanged += Document_ContentChanged;
        }

        /// <summary>
        /// 検索条件が変わったとき～
        /// </summary>
        public event EventHandler ConditionChanged;

        /// <summary>
        /// 自動的に実行したとき(Executeメソッド呼び出し時を除く)
        /// </summary>
        public event EventHandler Executed;

        /// <summary>
        /// ステータス
        /// </summary>
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    InvokePropertyChangedEvent("Status");
                }
            }
        }

        /// <summary>
        /// 検索ターム
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 大小一致
        /// </summary>
        public bool CaseSensitive { get; set; }

        /// <summary>
        /// 正規表現
        /// </summary>
        public bool UseRegExp { get; set; }

        /// <summary>
        /// documentに変更があったとき自動的に再検索するか
        /// </summary>
        public bool ExecuteAtEdit { get; set; }

        /// <summary>
        /// バインダ境界を含む検索結果を無視する
        /// </summary>
        public bool IgnoreContainBorder { get; set; }

        /// <summary>
        /// 検索条件
        /// </summary>
        public Regex Condition { get; private set; }

        /// <summary>
        /// 再建策が必要か？（条件かドキュメントのどちらかが変化した）
        /// </summary>
        public bool NeedUpdate { get; private set; }

        /// <summary>
        /// 検索結果
        /// </summary>
        public IEnumerable<SearchEngineResult> Result
        {
            get { return results; }
        }

        /// <summary>
        /// 検索実行（前と同じ条件なら何もせず-1)
        /// </summary>
        public int Execute()
        {
            if (binder == null) return -1;
            if (!NeedUpdate) return -1;

            ApplyConditions();
            CreateResult();

            NeedUpdate = false;

            if (Executed != null)
            {
                Executed(this, EventArgs.Empty);
            }

            return results.Count;

        }

        /// <summary>
        /// 検索を実行する...
        /// </summary>
        private void ApplyConditions()
        {
            string ptn = Keyword;
            RegexOptions opt = RegexOptions.None;

            if (!CaseSensitive) opt = RegexOptions.IgnoreCase;
            if (!UseRegExp) ptn = Regex.Escape(ptn);

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
                    Condition = null;
                    Status = "正規表現パターン誤り";
                }
            }
            if (ConditionChanged != null)
            {
                ConditionChanged(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// 検索結果の構築
        /// </summary>
        private void CreateResult()
        {
            var timeBegins = DateTime.Now;

            //検索結果を一回忘れる
            var newResults = new List<SearchEngineResult>();

            if (Condition != null)
            {
                //検索結果を一通り調べる
                var result = binder.Document.FindNext(Condition, 0);
                while (result != null)
                {
                    if ((IgnoreContainBorder) && (binder.IsRangeContainsBindrBorder(result.Begin, result.End)))
                    {
                        //次へ
                        result = binder.Document.FindNext(Condition, result.End);
                        continue;
                    }

                    //prevString
                    string prev = GetPrevString(result);

                    //trailingString
                    string trailing = GetTrailingString(result);

                    //検索結果
                    var matched = prev + "《" + escape(binder.Document.GetTextInRange(result.Begin, result.End)) + "》" + trailing;

                    newResults.Add(new SearchEngineResult(matched, result.Begin, result.End));

                    //次へ
                    result = binder.Document.FindNext(Condition, result.End);
                }
            }
            status = string.Format("{0} found({1} ms)", newResults.Count, (DateTime.Now - timeBegins).TotalMilliseconds);
            results = newResults;
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
            if (begin != beginHead)
            {
                prev = attentionLead + prev;
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
            if (end != endTail)
            {
                trailing = trailing + attentionLead;
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

        /// <summary>
        /// 検索対象の内容が変化したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Document_ContentChanged(object sender, ContentChangedEventArgs e)
        {
            NeedUpdate = true;
            if (ExecuteAtEdit)
            {
                Execute();
            }
        }

        /// <summary>
        /// 検索条件が変化したときに発火するイベント
        /// </summary>
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChangedの踏み台
        /// </summary>
        /// <param name="propertyName"></param>
        protected void InvokePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <summary>
    /// 検索結果
    /// </summary>
    public class SearchEngineResult
    {
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="matched"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        public SearchEngineResult(string matched, int begin, int end)
        {
            MatchedText = matched;
            BeginCaret = begin;
            EndCaret = end;
        }

        /// <summary>
        /// 検索適合テキスト（＋前後のコンテキスト）
        /// </summary>
        public string MatchedText { get; private set; }

        /// <summary>
        /// 検索適合テキストの開始位置
        /// </summary>
        public int BeginCaret { get; private set; }

        /// <summary>
        /// 検索適合テキストの終了位置
        /// </summary>
        public int EndCaret { get; private set; }

        /// <summary>
        /// 文字列化(検索適合テキストを返す）
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MatchedText;
        }
    }
}
