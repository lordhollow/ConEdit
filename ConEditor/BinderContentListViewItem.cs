using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConEditor
{
    public class BinderContentListViewItem : ListViewItem
    {
        /// <summary>
        /// カラムの定義
        /// </summary>
        /// <remarks>
        /// リストビューのカラム定義順(≠表示順)と合わせること。
        /// </remarks>
        enum ColumnIndex
        {
            FileName,
            Dirty,
            Size,
            Encoding,
            ActualFileSize,

            _count
        }

        /// <summary>
        /// 対応するコンテント
        /// </summary>
        BinderContent content;
        /// <summary>
        /// 対応するコンテント
        /// </summary>
        public BinderContent Content { get { return content; } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="content"></param>
        public BinderContentListViewItem(BinderContent content)
        {
            this.content = content;
            
            //0は最初からあるので、それ以外の分を追加
            for (var i = 1; i < (int)ColumnIndex._count; i++)
            {  
                SubItems.Add("");
            }
            //カラムデータのセット
            SubItems[(int)ColumnIndex.FileName].Text = content.FileNameBody;
            SubItems[(int)ColumnIndex.Dirty].Text = getDirtyString(content.Dirty);
            SubItems[(int)ColumnIndex.Encoding].Text = content.Encoding.WebName;
            SubItems[(int)ColumnIndex.ActualFileSize].Text = getSizeString(content.ActualFileSize);
            SubItems[(int)ColumnIndex.Size].Text = getSizeString(content.Content.Length);

        }

        /// <summary>
        /// Dirtyが変わるときに変化するもの(DirtyとSizeとファイルサイズ)を変化させる
        /// </summary>
        public void UpdateDirty()
        {
            SubItems[(int)ColumnIndex.Dirty].Text = getDirtyString(content.Dirty);
            SubItems[(int)ColumnIndex.Size].Text = getSizeString(content.Content.Length);
            SubItems[(int)ColumnIndex.ActualFileSize].Text = getSizeString(content.ActualFileSize);
        }

        /// <summary>
        /// Encodeが変わるときに変化するもの(DirtyとEncodeとSize)を変化させる
        /// </summary>
        public void UpdateEncode()
        {
            SubItems[(int)ColumnIndex.Dirty].Text = getDirtyString(content.Dirty);
            SubItems[(int)ColumnIndex.Size].Text = getSizeString(content.Content.Length);
            SubItems[(int)ColumnIndex.Encoding].Text = content.Encoding.WebName;
        }

        /// <summary>
        /// Dirtyフラグ表示用の文字列を取得する
        /// </summary>
        /// <param name="dirty"></param>
        /// <returns></returns>
        private string getDirtyString(bool dirty)
        {
            return dirty ? "*" : "";
        }

        /// <summary>
        /// サイズ表示用の文字列を取得する
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private string getSizeString(int size)
        {
            return size.ToString();
        }
    }
}
