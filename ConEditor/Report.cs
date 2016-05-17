using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConEditor
{
    /// <summary>
    /// レポートクラス
    /// </summary>
    public class Report
    {

        public static void Export(string message)
        {
            Console.WriteLine(message);
        }

        public static void Export(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
