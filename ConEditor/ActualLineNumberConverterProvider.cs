using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConEditor
{
    class ActualLineNumberConverterProvider
    {

        public Binder Binder { get; set; }

        public LineNoMethod Method { get; set; }

        public bool ShowLineNumber { get { return Method != LineNoMethod.None; } }

        public string LineNumberPad { get { return Method == LineNoMethod.IndividualWithIndex ? "000," : ""; } }

        /// <summary>
        /// DOCのロジカル行から表示文字行数を取得
        /// </summary>
        /// <param name="logicalLineOfDoc"></param>
        /// <returns></returns>
        public string ActualLineNumberConverter(int logicalLineOfDoc)
        {
            if (Binder == null) return "";
            var ret = "";

            switch (Method)
            {
                case LineNoMethod.Total:
                    ret = logicalLineOfDoc.ToString();
                    break;
                case LineNoMethod.TotalIgnoreBorder:
                    ret = getActualLineNo_TotalIgnoreBorder(logicalLineOfDoc);
                    break;
                case LineNoMethod.Individual:
                    ret = getActualLineNo_Individual(logicalLineOfDoc);
                    break;
                case LineNoMethod.IndividualWithIndex:
                    ret = getActualLineNo_IndividualWithIndex(logicalLineOfDoc);
                    break;
                default:
                    //None, default
                    break;
            }
            return ret;
        }

        private string getActualLineNo_TotalIgnoreBorder(int logicalLineOfDoc)
        {
            //contentのindexの分だけずれてる
            var ret = "";
            var content = Binder.GetBinderContentFromLine(logicalLineOfDoc + 1);
            if (content != null)
            {
                var line = content.LineConvert(logicalLineOfDoc);
                if (line <= 0)
                {
                    ret = "";
                }
                else
                {
                    ret = (logicalLineOfDoc - content.Index - 1).ToString();
                }
            }
            return ret;
        }

        private string getActualLineNo_Individual(int logicalLineOfDoc)
        {
            var ret = "";

            var content = Binder.GetBinderContentFromLine(logicalLineOfDoc + 1);
            if (content != null)
            {
                var line = content.LineConvert(logicalLineOfDoc);
                if (line <= 0)
                {
                    ret = "";
                }
                else
                {
                    ret = line.ToString();
                }
            }
            return ret;
        }

        private string getActualLineNo_IndividualWithIndex(int logicalLineOfDoc)
        {
            var ret = "";

            var content = Binder.GetBinderContentFromLine(logicalLineOfDoc + 1);
            if (content != null)
            {
                var line = content.LineConvert(logicalLineOfDoc);
                if (line <= 0)
                {
                    ret = "";
                }
                else
                {
                    ret = (content.Index + 1).ToString() + "," + line.ToString();
                }
            }
            return ret;
        }
    }
}
