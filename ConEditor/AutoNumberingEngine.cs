using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConEditor
{
    /// <summary>
    /// 自動採番エンジン
    /// </summary>
    public class AutoNumberingEngine
    {
        public AutoNumberingEngine(string prefix, string suffix, UInt32 min)
        {
            if (SetPattern(prefix, suffix))
            {
            }
            SetPattern("file_", "");
            MinValue = min;
        }

        public string Prefix { get; private set; }
        public string Suffix { get; private set; }
        public UInt32 MinValue { get; set; }

        Regex checker;

        public bool SetPattern(string prefix, string suffix)
        {
            var checker = prefix + suffix;
            if (IsValidPattern(checker) == false)
            {
                return false;
            }

            Prefix = prefix;
            Suffix = suffix;
            checker = null;
            return true;
        }

        public bool IsValidPattern(string ptn)
        {
            if (ptn.Contains('\\')
                || ptn.Contains('/')
                || ptn.Contains(':')
                || ptn.Contains('*')
                || ptn.Contains('?')
                || ptn.Contains('"')
                || ptn.Contains('<')
                || ptn.Contains('>')
                || ptn.Contains('|'))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 既に存在する名前のうち、パターンに合致するもので挟まる数字が一番大きいものを探してその値+1の名前を返す
        /// </summary>
        /// <param name="existNames"></param>
        /// <returns></returns>
        public string GetNextName(IEnumerable<string> existNames)
        {
            int max = -1;
            foreach (var name in existNames)
            {
                int num;
                if (getNumberInName(name, out num))
                {
                    if (max < num)
                    {
                        max = num;
                    }
                }
            }
            return string.Format("{0}{1}{2}.txt", Prefix, max + 1, Suffix);
        }

        private bool getNumberInName(string name, out int num)
        {
            if (checker == null)
            {
                checker = new Regex(Regex.Escape(Prefix) + @"(\d+)" + Regex.Escape(Suffix) + ".txt", RegexOptions.IgnoreCase);
            }
            var m = checker.Match(name);
            if (m.Success)
            {
                num = int.Parse(m.Groups[1].Value);
                return true;
            }
            else
            {
                num = 0;
                return false;
            }
        }

    }
}
