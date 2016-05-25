using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ConEditor
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            BinderContentOrder.Test();
#endif
            AzukiMarkerForConEdit.Registor();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConEditorWindow());
        }
    }
}
