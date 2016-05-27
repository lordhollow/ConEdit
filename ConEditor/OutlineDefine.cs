using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConEditor
{
    /// <summary>
    /// アウトライン定義。
    /// </summary>
    public abstract class OutlineDefine
    {
        /// <summary>
        /// 判定するためのパターン
        /// </summary>
        public abstract Regex Pattern { get; }

        /// <summary>
        /// テキストをアウトラインの情報に変換
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual OutlineComponent TextToOutlineComponent(string t)
        {
            return MatchedTextToOutlineComponent(Pattern.Match(t));
        }

        /// <summary>
        /// 判定で取り出したパターンからアウトラインの情報を取得する
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public abstract OutlineComponent MatchedTextToOutlineComponent(Match m);
    }

    /// <summary>
    /// 「アウトライン」の構成要素
    /// </summary>
    /// <remarks>
    /// こねでぃたにおけるアウトラインは「始点」の情報だけで管理する。次の始点までがそのアウトライン。
    /// </remarks>
    public class OutlineComponent
    {
        const string OutlineIndent = "　";

        /// <summary>
        /// このアウトラインの開始位置
        /// </summary>
        public int BeginAt { get; set; }
        /// <summary>
        /// アウトラインレベル。1以上。
        /// </summary>
        /// <remarks>
        /// 0以下は特別で、今のアウトラインのキャプションを変更する効果を持つ。
        /// </remarks>
        public int Level { get; set; }
        /// <summary>
        /// キャプション。任意。
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// レベル＋キャプション
        /// </summary>
        public string Text
        {
            get
            {
                if (IsCaptionOverwriteComponent)
                {
                    return string.Format("({0})", Caption);
                }
                else
                {
                    string ret = "";
                    for (var i = 1; i < Level; i++)
                    {
                        ret += OutlineIndent;
                    }
                    //return BeginAt.ToString() + ":" + ret + Caption;
                    return ret + Caption;
                }
            }
        }
        /// <summary>
        /// サブキャプション。任意。
        /// </summary>
        public string Subcaption { get; set; }

        /// <summary>
        /// 今のアウトラインのキャプションを上書きする効果のコンポーネントか？
        /// </summary>
        public bool IsCaptionOverwriteComponent { get { return Level <= 0; } }

        public override string ToString()
        {
            return string.Format("{2}:{0} {1}", Level, Caption, BeginAt);
        }
    }

    /// <summary>
    /// 規定のアウトラインパーサー
    /// </summary>
    /// <remarks>
    /// "!"で始まる行があれば、その後ろをキャプション上書きに使う。
    /// "*"の連続で始まる行があれば、星の数をレベル
    /// </remarks>
    public class EmbeddedOutlineDefine : OutlineDefine
    {
        private static readonly Regex ptn = new Regex(@"^(!|\*+)(.+)$", RegexOptions.Multiline);

        public override Regex Pattern
        {
            get { return ptn; }
        }



        public override OutlineComponent MatchedTextToOutlineComponent(Match m)
        {
            if ((m == null) || (m.Success == false)) return null;
            var ret = new OutlineComponent();
            var g1 = m.Groups[1].Value;
            if (g1 == "!")
            {
                ret.Level = 0;
            }
            else
            {
                ret.Level = g1.Length;
            }
            ret.Caption = m.Groups[2].Value;
            ret.Subcaption = "";// m.Groups[3].Value;
            ret.BeginAt = m.Index;
            return ret;
        }

        public override string ToString()
        {
            return "Default Outline Parser";
        }
    }
}
