using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Sgry.Azuki;

namespace ConEditor
{
    /// <summary>
    /// バインダー（ファイルの集合体=フォルダ）
    /// </summary>
    public class Binder : IEnumerable<BinderContent>
    {
        #region fields
        /// <summary>
        /// 内容物インデックスリスト（前から順番に整列している）
        /// </summary>
        List<BinderContent> contents;

        BinderConfigulation binderConfig;

        BinderContentOrder binderOrder;

        DocumentOutline outline;

        /// <summary>
        /// 改行コードカウント用のregex
        /// </summary>
        static Regex newLine;

        #endregion
        
        #region constractor

        /// <summary>
        /// コンストラクタ隠蔽
        /// </summary>
        private Binder()
        {
            contents = new List<BinderContent>();
            binderConfig = new BinderConfigulation();
        }

        /// <summary>
        /// バインダを作る（ファクトリメソッド）：あとでLoadしましょう
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Binder CreateBinder(string path)
        {
            //指定したフォルダが存在するかどうか確認する。
            //存在すればそこをワークスペースとする。
            if (Directory.Exists(path) == false)
            {
                return null;
            }
            var binder = new Binder();
            binder.Path = path;
            return binder;
        }


        /// <summary>
        /// 設定ダイアログ用サンプルデータで生成
        /// </summary>
        public static Binder CreateSampleData()
        {
            string[] sample = new string[]{
                            "file1.txt", "あああ\r\nいいい\r\nううう\r\n",
                            "file2.txt", "えええ\r\n",
                            "file3.txt", "おおお\r\n",
            };
            return new Binder(sample);
        }

        /// <summary>
        /// dataからバインダ作成
        /// </summary>
        /// <param name="data"></param>
        private Binder(string[] data)
        {
            var binder = new List<BinderContent>();
            var doc = new Document();
            for (var i = 0; i < data.Length; i += 2)
            {
                var file = data[i];
                var content = data[i + 1];

                var c = new BinderContent
                {
                    Filename = file,
                    Index = binder.Count,
                    Content = content,
                    LogicalStartLineInDocumnet = doc.LineCount,
                };
                var fbody = String.Format("《{0}》\r\n{1}", file, content);
                doc.Replace(fbody, doc.Length, doc.Length);
                binder.Add(c);
                markBinderBorder(doc, c);
            }
            doc.ClearHistory();
            doc.IsReadOnly = true;
            Document = doc;
            contents = binder;
        }

        #endregion

        #region property

        /// <summary>
        /// 保存パス
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// 読み込み完了しているか？
        /// </summary>
        public bool Loaded { get; private set; }

        /// <summary>
        /// ドキュメント
        /// </summary>
        public Document Document { get; private set; }

        private bool enableOutline;
        /// <summary>
        /// アウトラインを有効にするか
        /// </summary>
        public bool EnableOutline
        {
            get { return enableOutline; }
            set
            {
                if (enableOutline != value)
                {
                    enableOutline = value;
                    if (value && Loaded)
                    {   //アウトライン有効にするとき、読み込み済みなら再構築
                        outline = new DocumentOutline();
                        outline.Rebuild(this);
                    }
                    else
                    {
                        outline = null;
                    }
                }
            }
        }

        /// <summary>
        /// アウトラインの取得
        /// </summary>
        public DocumentOutline Outline
        {
            get { return outline; }
        }

        /// <summary>
        /// 内容物の数
        /// </summary>
        public int Count
        {
            get
            {
                return contents.Count;
            }
        }

        /// <summary>
        /// インデクサ（参照のみ）
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public BinderContent this[int index]
        {
            get
            {
                return contents[index];
            }
        }

        /// <summary>
        /// メモリ上でいずれかのファイルが変更されているかを確認する
        /// </summary>
        public bool Dirty
        {
            get
            {
                foreach (var content in contents)
                {
                    if (content.Dirty) return true;
                }
                return false;
            }
        }

        /// <summary>
        /// コンフィグ～
        /// </summary>
        public BinderConfigulation Config
        {
            get
            {
                return binderConfig;
            }
        }

        /// <summary>
        /// 再構築中。Trueのときすべてのボーダー判定はFalseになるし、NotifyReplaceは無視される。
        /// </summary>
        public bool Reconstructing { get; private set; }

        #endregion

        #region public method

        /// <summary>
        /// バインダの全データ読み出し(*.txt)
        /// </summary>
        /// <param name="bindedContents"></param>
        /// <returns></returns>
        public bool Load()
        {
            return Load("*.txt");
        }

        /// <summary>
        /// バインダの全データ読み出し(拡張子指定）
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="bindingContents"></param>
        /// <returns></returns>
        public bool Load(string pattern)
        {
            try
            {
                LoadConfigulation();

                var files = Directory.GetFiles(Path, pattern);
                var sorter = new BinderContentOrder(this);
                var fileBodies = files.Select(x => System.IO.Path.GetFileName(x)).ToArray();
                fileBodies = sorter.Sort(fileBodies);

                var doc = new Document();
                var binder = new List<BinderContent>();

                //全部のファイルを読んでつなぐ
                foreach (var fileBody in fileBodies)
                {
                    var file = System.IO.Path.Combine(Path, fileBody);
                    var c = new BinderContent();
                    c.Filename = file;
                    c.LogicalStartLineInDocumnet = doc.LineCount;
                    var fdata = File.ReadAllBytes(file);
                    c.Encoding = CodePageDetector.DetectEncoding(fdata);
                    var fbody = c.Encoding.GetString(fdata);
                    c.ActualFileSize = fdata.Length;
                    c.Content = fbody;
                    c.Dirty = false;

                    fbody = String.Format("《{0}》\r\n{1}\r\n", file, fbody);
                    doc.Replace(fbody, doc.Length, doc.Length);
                    c.Index = binder.Count;
                    binder.Add(c);

                    //mark
                    markBinderBorder(doc, c);

                }
                doc.ClearHistory();
                Document = doc;
                contents = binder;
                binderOrder = sorter;
                Loaded = true;

                //アウトラインを作る
                if (enableOutline)
                {
                    outline = new DocumentOutline();
                    outline.Rebuild(this);
                }
            }
            catch(Exception e)
            {
                Report.Export(string.Format("Binder Load Error. {0}", Path));
                Report.Export(e);
                Document = null;
                return false;
            }
            return true;
        }

        private static void markBinderBorder(Sgry.Azuki.Document doc, BinderContent c)
        {
            var head = doc.GetLineHeadIndex(c.LogicalStartLineInDocumnet - 1);
            var end = doc.GetLineEndIndexFromCharIndex(head);
            doc.Mark(head, end, AzukiMarkerForConEdit.ID_BindingBorder);
        }

        /// <summary>
        /// コンテンツの再読出し
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public bool ReloadContent(BinderContent content, Encoding encode)
        {
            if (content == null) return false;
            if (contents.Contains(content) == false) return false;
            if (encode == null)
            {
                encode = Encoding.UTF8;
            }
            try
            {
                var fd = File.ReadAllBytes(content.Filename);
                var fs = encode.GetString(fd);
                content.Content = fs;
                content.Encoding = encode;

                var replaceBegin = Document.GetLineHeadIndex(content.LogicalStartLineInDocumnet);   //境界含まないので-1しない
                var replaceEnd = GetContentBottomCaretInDocument(content);
                Document.Replace(fs, replaceBegin, replaceEnd);
            }
            catch(Exception e)
            {
                Report.Export(e);
                return false;
            }
            return true;
        }

        /// <summary>
        /// ファイル名newContentでbeforeThisの前に読み込み
        /// </summary>
        /// <param name="newContent"></param>
        /// <param name="beforeThis"></param>
        public void CreateNewContent(string newContentFullPath, BinderContent beforeThis)
        {
            var newPath = System.IO.Path.Combine(Path, newContentFullPath);
            var newPathU = newPath.ToUpper();
            
            //すでにcontentに含まれていないかチェックする
            foreach (var content in contents)
            {
                if (content.Filename.ToUpper() == newPathU)
                {
                    throw new Exception("既に登録済みのコンテントです。");
                }
            }
            //あれれー？新規のはずなのに？？
            if (File.Exists(newPath))
            {
                throw new Exception("既にファイルが存在しています。");
            }
            //beforeContentがおかしい
            if ((beforeThis != null) && (contents.Contains(beforeThis) == false))
            {
                throw new Exception("before contents error.");  //ユーザー向けメッセージではないので英語...
            }

            try
            {
                Reconstructing = true;

                //新規作成（保存はしないよ)
                var newContent = new BinderContent();
                newContent.Filename = newPath;
                newContent.Content = "";
                newContent.Dirty = true;

                //挿入箇所決め(document)
                var insertCharet = 0;
                if (beforeThis != null)
                {
                    insertCharet = Document.GetLineHeadIndex(beforeThis.LogicalStartLineInDocumnet - 1);
                }
                else
                {
                    insertCharet = Document.Length;
                }
                //挿入(contents)
                if (beforeThis != null)
                {
                    newContent.Index = beforeThis.Index;
                    newContent.LogicalStartLineInDocumnet = beforeThis.LogicalStartLineInDocumnet;
                    contents = insertContent(newContent);
                }
                else
                {
                    newContent.Index = contents.Count;
                    newContent.LogicalStartLineInDocumnet = Document.LineCount; //末尾行インデックスになる
                    contents.Add(newContent);
                }
                //挿入(document)
                var fbody = String.Format("《{0}》\r\n\r\n", newPath);
                Document.Replace(fbody, insertCharet, insertCharet);
                markBinderBorder(Document, newContent);

                //アウトラインを作る
                if (enableOutline)
                {
                    outline = new DocumentOutline();
                    outline.Rebuild(this);
                }

                //イベント
                newContent.Save();
                binderOrder.Save();
                InvokeBinderModifiedEvent();
            }
            catch (Exception e)
            {
                Report.Export(e);
            }
            finally
            {
                Reconstructing = false;
            }
        }

        private List<BinderContent> insertContent(BinderContent newContent)
        {
            var newList = new List<BinderContent>();
            foreach (var content in contents)
            {
                if (content.Index < newContent.Index)
                {
                    newList.Add(content);
                }
                else
                {
                    if (content.Index == newContent.Index)
                    {
                        //丁度beforeのとこ
                        newList.Add(newContent);
                    }
                    //挿入箇所以降は一個ずつずれていく
                    content.Index++;
                    content.LogicalStartLineInDocumnet += 2;   //境界+空行の分ずれる
                    newList.Add(content);
                }
            }
            return newList;
        }

        /// <summary>
        /// indexから始まるtextがバインダの境界を含むか確認する
        /// </summary>
        /// <param name="index">テキストの開始点(Document上のインデックス）</param>
        /// <param name="text">テキスト</param>
        /// <returns></returns>
        public bool isTextIncludeBinderBorder(int index, string text)
        {
            if (text == null) text = "";
            return IsRangeContainsBindrBorder(index, index + text.Length);
        }

        /// <summary>
        /// indexからindexToまでの範囲が境界を含むか確認する
        /// </summary>
        /// <param name="index"></param>
        /// <param name="indexTo"></param>
        /// <returns></returns>
        public bool IsRangeContainsBindrBorder(int index, int indexTo)
        {
            //内容がないときは常に境界の上とする
            if (contents.Count == 0) return true;
            //再構築中は境界に乗らない
            if (Reconstructing) return false;

            if (index > indexTo)
            {
                //swap
                var t = index;
                index = indexTo;
                indexTo = t;
            }

            //境界チェック...
            var lineBegin = Document.GetLineIndexFromCharIndex(index) + 1;
            var lineEnd = Document.GetLineIndexFromCharIndex(indexTo) + 1;
            foreach (var content in contents)
            {
                if ((content.LogicalStartLineInDocumnet >= lineBegin) &&
                    (content.LogicalStartLineInDocumnet <= lineEnd))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// indexから始まるoldTextをnewTextに置換する
        /// </summary>
        /// <param name="index"></param>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        public bool NotifyReplace(int index, string oldText, string newText)
        {
            //境界を含む変更は許可しない
            //↓ここで見るとOutOfRangeが出るのでやめておく
            //if (isTextIncludeBinderBorder(index, oldText) == true) return false;

            //再構築中は通知を無視する
            if (Reconstructing) return true;

            //変更対象コンテントを取得
            var targetContent = GetBinderContentFromCharet(index);
            if (targetContent == null) return false;

            //編集したコンテントの内容を修正
            //コンテント内の編集位置を取得
            var editBegin = index - Document.GetLineHeadIndex(targetContent.LogicalStartLineInDocumnet);
            string c = targetContent.Content;
            var sb = new StringBuilder();
            sb.Append(c.Substring(0, editBegin));
            sb.Append(newText);
            sb.Append(c.Substring(editBegin + oldText.Length));
            targetContent.Content = sb.ToString();

            //開始がLineBegin行より後ろのコンテントは、開始行をLineBeginとLineEndに含まれる改行の差の分だけズラす
            var delLines = CountLine(oldText);
            var addLines = CountLine(newText);
            var lineMods = addLines - delLines;
            if (lineMods != 0)
            {
                //行がずれる時、開始行より後ろの行始まりのコンテンツは全部ずれる
                var lineBegin = Document.GetLineIndexFromCharIndex(index) + 1;
                foreach (var content in contents)
                {
                    if (content.LogicalStartLineInDocumnet >= lineBegin)
                    {
                        content.LogicalStartLineInDocumnet += lineMods;
                    }
                }
            }

            //アウトラインの更新
            if (outline != null)
            {
                var contentHead = Document.GetLineHeadIndex(targetContent.LogicalStartLineInDocumnet);  //バインダを除くので-1しない
                int contentBottom = GetContentBottomCaretInDocument(targetContent);
                outline.Modify(this, contentHead, contentBottom, index, index + newText.Length, newText.Length - oldText.Length);
            }

            //編集したコンテントのダーティーをON
            targetContent.Dirty = true;
            //編集されたよイベント
            InvokeContentModifiedEvent(targetContent.Index);

            return true;
        }

        /// <summary>
        /// targetContentのケツがどこにあるか調べる
        /// </summary>
        /// <param name="targetContent"></param>
        /// <returns></returns>
        private int GetContentBottomCaretInDocument(BinderContent targetContent)
        {
            int contentBottom = 0;
            if (targetContent.Index == contents.Count - 1)
            {
                //最後なら文末
                contentBottom = Document.Length;
            }
            else
            {
                var trailContent = contents[targetContent.Index + 1];
                contentBottom = Document.GetLineHeadIndex(trailContent.LogicalStartLineInDocumnet - 1) - Environment.NewLine.Length;
            }
            return contentBottom;
        }

        /// <summary>
        /// 指定論理行がバインド境界か調べる
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public bool IsBindBorder(int line)
        {
            //再構築中は境界に乗らない
            if (Reconstructing) return false;

            if (contents != null)
            {
                foreach (var content in contents)
                {
                    if (content.LogicalStartLineInDocumnet == line + 1) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 全部のDirtyを保存
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            bool ret = true;
            var savedIndicies = new List<int>();
            foreach (var content in contents)
            {
                ret &= executeSave(savedIndicies, content);
            }
            if (savedIndicies.Count != 0)
            {
                InvokeContentModifiedEvent(savedIndicies);
            }
            return ret;
        }

        /// <summary>
        /// index位置を含むコンテントを保存
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool Save(int index)
        {
            var content = GetBinderContentFromCharet(index);
            if (content != null)
            {
                if (content.Dirty)
                {
                    var ret = content.Save();
                    if (ret)
                    {
                        InvokeContentModifiedEvent(content.Index);
                    }
                    return ret;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// indexFrom～indexToの範囲を含むコンテントを保存
        /// </summary>
        /// <param name="charIndexFrom"></param>
        /// <param name="charIndexTo"></param>
        /// <returns></returns>
        public bool Save(int charIndexFrom, int charIndexTo)
        {
            var firstContent = GetBinderContentFromCharet(charIndexFrom);
            if (firstContent == null) return false;
            var lastContent = GetBinderContentFromCharet(charIndexTo);
            if (lastContent == null) return false;
            bool ret = true;
            bool inRange = false;
            var savedIndicies = new List<int>();
            foreach (var content in contents)
            {
                if (content == lastContent)
                {
                    //最後のやつ
                    ret &= executeSave(savedIndicies, content);
                    break;
                }
                else if (content == firstContent)
                {
                    ret &= executeSave(savedIndicies, content);
                    inRange = true;
                }
                else if (inRange)
                {
                    ret &= executeSave(savedIndicies, content);
                }
            }
            if (savedIndicies.Count != 0)
            {
                InvokeContentModifiedEvent(savedIndicies);
            }
            return ret;
        }

        private static bool executeSave(List<int> savedIndicies, BinderContent content)
        {
            var ret = true;
            if (content.Dirty)
            {
                if (content.Save())
                {
                    savedIndicies.Add(content.Index);
                }
                else { ret = false; }
            }
            return ret;
        }

        public bool SaveConfigulation()
        {
            if (binderConfig != null)
            {
                return BinderConfigulationLoader.Save(Path, binderConfig);
            }
            return true;
        }

        public void LoadConfigulation()
        {
            binderConfig = BinderConfigulationLoader.Load(Path);
            if (binderConfig == null)
            {
                binderConfig = new BinderConfigulation();
            }
        }




        #endregion

        #region private method

        /// <summary>
        /// 選択範囲（の左端）のコンテントを取得
        /// </summary>
        /// <returns></returns>
        public BinderContent GetBinderContentFromSelectionLeft()
        {
            if (contents.Count == 0) return null;   //コンテンツがないときはダメだ
            int b;
            int e;
            Document.GetSelection(out b, out e);
            if (b > e) b = e;
            return GetBinderContentFromCharet(b);
        }

        /// <summary>
        /// 指定論理行からバインダを選ぶ
        /// </summary>
        /// <param name="docLogicalLineIndex"></param>
        /// <returns></returns>
        public BinderContent GetBinderContentFromLine(int docLogicalLineIndex)
        {
            if (contents.Count == 0) return null;   //コンテンツがないときはダメだ
            BinderContent bc = contents.First();
            foreach (var content in contents)
            {
                if (content.LogicalStartLineInDocumnet >= docLogicalLineIndex)
                {
                    return bc;  //超える直前を返す
                }
                bc = content;
            }
            return bc;
        }

        /// <summary>
        /// 指定位置を含むバインダを選ぶ
        /// </summary>
        /// <param name="charetIndex"></param>
        /// <returns></returns>
        public BinderContent GetBinderContentFromCharet(int charetIndex)
        {
            if (contents.Count == 0) return null;   //コンテンツがないときはダメだ

            var lineBegin = Document.GetLineIndexFromCharIndex(charetIndex) + 1;
            return GetBinderContentFromLine(lineBegin);
        }

        /// <summary>
        /// textに含まれる改行を数える
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        int CountLine(string text)
        {
            if (newLine == null)
            {
                newLine = new Regex(@"(\r\n|\r|\n)");
            }
            return newLine.Matches(text).Count;
        }

        #endregion

        #region IEnumerable

        public IEnumerator<BinderContent> GetEnumerator()
        {
            return contents.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return contents.GetEnumerator();
        }

        #endregion

        /// <summary>
        /// バインダが書き換わった(要素の増減、ファイル名の変化等)
        /// </summary>
        public event EventHandler BinderModified;
        /// <summary>
        /// イベント発火
        /// </summary>
        /// <param name="modList"></param>
        private void InvokeBinderModifiedEvent()
        {
            if (BinderModified != null)
            {
                BinderModified(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// 内容が書き換わった(SaveしてDirtyが落ちただけの場合を含む)
        /// </summary>
        public event EventHandler<BinderModifiedEventArgs> ContentModified;
        private void InvokeContentModifiedEvent(IEnumerable<int> modList)
        {
            if (ContentModified != null)
            {
                var arg = new BinderModifiedEventArgs(modList.ToArray());
                ContentModified(this, arg);
            }
        }
        private void InvokeContentModifiedEvent(int[] modList)
        {
            if (ContentModified != null)
            {
                var arg = new BinderModifiedEventArgs(modList);
                ContentModified(this, arg);
            }
        }
        private void InvokeContentModifiedEvent(int modIndex)
        {
            if (ContentModified != null)
            {
                var arg = new BinderModifiedEventArgs(new int[] { modIndex });
                ContentModified(this, arg);
            }
        }
    }

    public class BinderModifiedEventArgs : EventArgs
    {
        public BinderModifiedEventArgs(int[] indicies)
        {
            Indicies = indicies;
        }

        /// <summary>
        /// 書き換わったバインダのインデックスたち
        /// </summary>
        public int[] Indicies { get; private set; }
    }

}
