using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sgry.Azuki;

namespace ConEditor
{
    public static class AzukiMarkerForConEdit
    {
        public const int ID_BindingBorder = 0;
        public const int ID_FindKeyword = 1;

        /// <summary>
        /// テキストに持たせる意味の定義
        /// </summary>
        public static void Registor()
        {
            // バインダ境界
            Marking.Register(new Sgry.Azuki.MarkingInfo(ID_BindingBorder, "BinderBorder", MouseCursor.Arrow));
            // 検索結果
            Marking.Register(new Sgry.Azuki.MarkingInfo(ID_FindKeyword, "FindKeyword", MouseCursor.IBeam));
        }

        /// <summary>
        /// 色塗りの定義
        /// </summary>
        public static ColorScheme ColorScheme
        {
            get
            {
                var s = ColorScheme.Default;    //デフォルトを基準にして決める
                s.SetMarkingDecoration(ID_BindingBorder, new BgColorTextDecoration(System.Drawing.Color.Gray));
                s.SetMarkingDecoration(ID_FindKeyword, new BgColorTextDecoration(System.Drawing.Color.Yellow));
                return s;
            }
        }
    }
}
