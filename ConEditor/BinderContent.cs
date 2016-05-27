using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConEditor
{
    /// <summary>
    /// バインダーの内容物（のインデックス）
    /// </summary>
    public class BinderContent
    {
        public BinderContent()
        {
            //NULLよけ
            Content = "";
            Filename = "";
        }

        /// <summary>
        /// インデックス位置
        /// </summary>
        /// <remarks>
        /// Binder以外が書き換えるべきではない
        /// </remarks>
        public int Index { get; set; }

        /// <summary>
        /// ドキュメント全体のこのドキュメントの開始行。この行にはヘッダ情報が入るはず
        /// </summary>
        public int LogicalStartLineInDocumnet { get; set; }

        /// <summary>
        /// このドキュメントのファイル名(フルパス)
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        /// <remarks>
        /// Binder以外が書き換えるべきではない
        /// </remarks>
        public string Content { get; set; }

        /// <summary>
        /// ダーティーフラグ
        /// </summary>
        public bool Dirty { get; set; }

        /// <summary>
        /// 保存時の文字コード
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// ファイルサイズ（保存まで変わらない）
        /// </summary>
        public int ActualFileSize { get; set; }

        /// <summary>
        /// 保存する
        /// </summary>
        public bool Save()
        {
            if (!Dirty) return true;            //きれいなものは保存しない

            try
            {
                File.WriteAllText(Filename, Content, Encoding);
                Dirty = false;
                return true;
            }
            catch (Exception e)
            {
                Report.Export(e);
                return false;
            }
        }

        /// <summary>
        /// ファイル名の本体のみ
        /// </summary>
        public string FileNameBody
        {
            get
            {
                return Path.GetFileName(Filename);
            }
        }

        /// <summary>
        /// documentの論理行をこのコンテントにおける行インデックスにする。バインダ位置が0、その次が1。
        /// </summary>
        /// <param name="logicalLine"></param>
        /// <returns></returns>
        public int LineConvert(int logicalLine)
        {
            return (logicalLine - LogicalStartLineInDocumnet);
        }

        public override string ToString()
        {
            return string.Format("{1}{0}({2}) {3}", Index, Dirty ? "*" : " ", LogicalStartLineInDocumnet, FileNameBody);
        }
    }
}
