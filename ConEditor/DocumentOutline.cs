using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ConEditor
{
    /// <summary>
    /// アウトライン
    /// </summary>
    public class DocumentOutline : IBindingList
    {
        private List<OutlineComponent> components;

        OutlineDefine Define = new EmbeddedOutlineDefine();

        public void Rebuild(Binder binder)
        {
            var comp = new List<OutlineComponent>();
            try
            {
                //まず、すべてのバインダ境界をLevel1アウトラインとする
                CreateBinderBorderOutlineComponents(binder, comp);
                //検索して全部のアウトラインを出す
                CreateOutlineComponents(binder, comp, 0, binder.Document.Length);
                //開始順に並べ替える
                comp.Sort((ca, cb) => ca.BeginAt - cb.BeginAt);
                binder.Document.WatchPatterns.Register(new Sgry.Azuki.WatchPattern(AzukiMarkerForConEdit.ID_OUTLINE, Define.Pattern));
                components = comp;

                InvokeListChanged();
            }
            catch(Exception e)
            {
                Report.Export(e);
            }
        }

        private static void CreateBinderBorderOutlineComponents(Binder binder, List<OutlineComponent> comp)
        {
            foreach (var content in binder)
            {
                var o = new OutlineComponent();
                o.Level = 1;
                o.BeginAt = binder.Document.GetLineHeadIndex(content.LogicalStartLineInDocumnet - 1);
                o.Caption = content.FileNameBody;
                o.Subcaption = "";
                comp.Add(o);
            }
        }

        private void CreateOutlineComponents(Binder binder, List<OutlineComponent> comp, int top, int bottom)
        {
            var result = binder.Document.FindNext(Define.Pattern, top, bottom);
            while (result != null)
            {
                var resultString = binder.Document.GetTextInRange(result.Begin, result.End);
                var o = Define.TextToOutlineComponent(resultString);
                if (!o.IsCaptionOverwriteComponent)
                {
                    o.Level++;
                }
                o.BeginAt = result.Begin;
                comp.Add(o);
                result = binder.Document.FindNext(Define.Pattern, result.End, bottom);
            }
        }

        /// <summary>
        /// アウトラインの調整
        /// </summary>
        /// <param name="contentHead">編集されたコンテントの先頭キャレット（ボーダーの直後）</param>
        /// <param name="contentBottom">編集されたコンテントの末尾キャレット（次のボーダーまたはEOFの直前）</param>
        /// <param name="editHead">編集箇所の先頭</param>
        /// <param name="editBottom">編集箇所の末尾</param>
        /// <param name="modifiedCount">編集による文字数の増減</param>
        public void Modify(Binder binder, int contentHead, int contentBottom, int editHead, int editBottom, int modifiedCount)
        {
            //editBottomを打ち切り条件に使えるはずだけど気にしないよ
            var currentContentList = new List<OutlineComponent>();
            CreateOutlineComponents(binder, currentContentList, contentHead, contentBottom);
            var newList = new List<OutlineComponent>();

            foreach (var component in components)
            {
                if (component.BeginAt < contentHead)
                {
                    //開始がcontentHeadの前のものはそのまま持っておく。
                    newList.Add(component);
                }
                else if (component.BeginAt >= contentBottom)
                {
                    //開始がcontentBottomより後ろのものはmodifiedHeadを足して持っておく。
                    component.BeginAt += modifiedCount;
                    newList.Add(component);
                }
                else if (currentContentList.Count != 0)
                {
                    //それ以外は作り直すので持たない
                    newList.AddRange(currentContentList);
                    currentContentList.Clear();
                }
            }

            components = newList;
            InvokeListChanged();
        }

        public OutlineComponent GetComponentIndexFromCaret(int caret)
        {
            //TODO::そのうちBinarySearchにする
            OutlineComponent comp = null;
            foreach (var component in components)
            {
                if (component.BeginAt > caret) return comp;
                comp = component;
            }
            return comp;

        }

        private void InvokeListChanged()
        {
            if (ListChanged != null)
            {
                var eventArg = new ListChangedEventArgs(ListChangedType.Reset, -1);
                ListChanged(this, eventArg);
            }
        }

        public int Count
        {
            get { return (components == null) ? 0 : components.Count; }
        }
 
        public IEnumerator<OutlineComponent> GetEnumerator()
        {
            return components.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return components.GetEnumerator();
        }



        public void AddIndex(System.ComponentModel.PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public object AddNew()
        {
            throw new NotImplementedException();
        }

        public bool AllowEdit
        {
            get { return false; }
        }

        public bool AllowNew
        {
            get { return false; }
        }

        public bool AllowRemove
        {
            get { return false; }
        }

        public void ApplySort(System.ComponentModel.PropertyDescriptor property, System.ComponentModel.ListSortDirection direction)
        {
            throw new NotImplementedException();
        }

        public int Find(System.ComponentModel.PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted
        {
            get { return true; }
        }

        public event System.ComponentModel.ListChangedEventHandler ListChanged;

        public void RemoveIndex(System.ComponentModel.PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public void RemoveSort()
        {
            throw new NotImplementedException();
        }

        public System.ComponentModel.ListSortDirection SortDirection
        {
            get { return System.ComponentModel.ListSortDirection.Ascending; }
        }

        public System.ComponentModel.PropertyDescriptor SortProperty
        {
            get { throw new NotImplementedException(); }
        }

        public bool SupportsChangeNotification
        {
            get { return true; }
        }

        public bool SupportsSearching
        {
            get { return false; }
        }

        public bool SupportsSorting
        {
            get { return false; }
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public object this[int index]
        {
            get
            {
                return components[index];
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
    }
}
