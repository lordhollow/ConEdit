using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace ConEditor
{
    /// <summary>
    /// 
    /// </summary>
    public class BinderContentOrder
    {
        /// <summary>
        /// 保存ファイル
        /// </summary>
        const string saveFile = "_oder.xml";

        /// <summary>
        /// 保存ファイルの中身
        /// </summary>
        private List<string> orders;


        /// <summary>
        /// filesを並び替える。
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public void Sort(List<BinderContent> contents)
        {
            //orderの名簿にあるものを前から拾っていく

            //比較用に、filesを大文字にしたもの。
            //var filesUcase = files.Select(x => x.ToUpper()).ToArray();
            var filesUcase = contents.Select(x => x.FileNameBody.ToUpper()).ToArray();

            //順番が規定されている分のリストを作る
            var fixedOrderdList = new List<int>();
            if ((orders != null) && (orders.Count != 0))
            {
                foreach (var order in orders)
                {
                    var o = order.ToUpper();    //大文字で比較する
                    for (int i = 0; i < filesUcase.Length; i++)
                    {
                        if (o == filesUcase[i])
                        {
                            fixedOrderdList.Add(i);
                            filesUcase[i] = null;   //使ったので。
                        }
                    }
                }
            }

            //残ったやつを後ろに並べる
            if (fixedOrderdList.Count != contents.Count)
            {
                int sortHead = fixedOrderdList.Count;
                int sortCount=0;
                for (int i = 0; i < filesUcase.Length; i++)
                {
                    if (filesUcase[i] != null)
                    {
                        fixedOrderdList.Add(i);
                        sortCount++;
                    }
                }
                fixedOrderdList.Sort(sortHead, sortCount, new BinderContentComparer(filesUcase));
            }

            //インデックス降り直し
            for (var i=0; i<contents.Count; i++)
            {
                contents[fixedOrderdList[i]].Index = i;
            }
            //インデックスでソート
            contents.Sort((c1, c2) => c1.Index - c2.Index);
        }

        class BinderContentComparer : IComparer<int>
        {
            string[] filesUcase;
            Regex numgetter = new Regex(@"([^\d]*)(\d+)");

            public BinderContentComparer(string[] filesUcase)
            {
                this.filesUcase = filesUcase;
            }
            public int Compare(int x, int y)
            {
                //x =y なら0, x < y なら-1, x > y なら1を返す。
                var xs = filesUcase[x];
                var ys = filesUcase[y];
                var oxs = xs;
                var oys = ys;

                if (x == y) return 0; //わずかばかり高速化

                //数字の有無を確認する
                var xsm = numgetter.Match(xs);
                var ysm = numgetter.Match(ys);
                var c = StringComparer.CurrentCultureIgnoreCase;

                //どっちかに数字が入ってなかったら単純に比べる
                while (true)
                {
                    if ((!xsm.Success) || (!ysm.Success))
                    {
                        return c.Compare(xs, ys);
                    }
                    else
                    {
                        var d = c.Compare(xsm.Groups[1].Value, ysm.Groups[1].Value);
                        if (d == 0)
                        {
                            //数字も比べる
                            var ix = int.Parse(xsm.Groups[2].Value);
                            var iy = int.Parse(ysm.Groups[2].Value);
                            if (ix == iy)
                            {
                                if (xsm.Groups[2].Value != ysm.Groups[2].Value)
                                {
                                    //評価結果は同じだけど文字が違う（あたまに０）
                                    return c.Compare(xsm.Groups[2].Value, ysm.Groups[2].Value);
                                }
                                else
                                {
                                    //延長戦
                                    xs = oxs.Substring(xsm.Index + xsm.Length);  //使ったとこ削る
                                    ys = oys.Substring(ysm.Index + ysm.Length);  //使ったとこ削る

                                    xsm = xsm.NextMatch();
                                    ysm = ysm.NextMatch();
                                    //continue
                                }
                            }
                            else
                            {
                                return ix - iy;
                            }
                        }
                        else
                        {
                            return d;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 順番がいじられているか？
        /// </summary>
        public bool HasOrder
        {
            get
            {
                return ((orders != null) && (orders.Count != 0));
            }
        }
        
        /// <summary>
        /// 順番リセット
        /// </summary>
        public void Clear()
        {
            orders = new List<string>();
        }

        public bool Load(string BinderPath)
        {
            try
            {
                var SaveFilePath = Path.Combine(BinderPath, saveFile);
                if (File.Exists(SaveFilePath))
                {
                    using (var f = new StreamReader(SaveFilePath))
                    {
                        var ser = new XmlSerializer(typeof(List<string>));
                        orders = ser.Deserialize(f) as List<string>;
                    }
                }
            }
            catch (Exception e)
            {
                Report.Export(e);
            }
            if (orders == null)
            {
                orders = new List<string>();
            }
            return true;
        }

        public bool Save(Binder binder)
        {
            try
            {
                var SaveFilePath = Path.Combine(binder.Path, saveFile);
                if (createOrders(binder) == false)
                {
                    if (File.Exists(SaveFilePath))
                    {
                        File.Delete(SaveFilePath);
                    }
                }
                else
                {
                    using (var f = new StreamWriter(SaveFilePath))
                    {
                        var ser = new XmlSerializer(typeof(List<string>));
                        ser.Serialize(f, orders);
                    }
                }
            }
            catch (Exception e)
            {
                Report.Export(e);
                return false;
            }
            return true; ;
        }

        private bool createOrders(Binder binder)
        {
            //今の並び
            var currentOrder = binder.Select(content => content.FileNameBody).ToList();

            //ストレート並び
            var s = new List<int>();
            for (int i = 0; i < binder.Count; i++)
            {
                s.Add(i);
            }
            var fileUcases = binder.Select(x => x.FileNameBody.ToUpper()).ToArray();
            s.Sort(0, s.Count, new BinderContentComparer(fileUcases));
            var defaultOrder = s.Select(i => binder[i].FileNameBody).ToList();

            //ここでデフォルトのままでいい部分が識別できたらいいのだが・・・
            var same = true;
            for (var i = 0; i < currentOrder.Count; i++)
            {
                if (currentOrder[i] != defaultOrder[i])
                {
                    same = false;
                }
            }
            var newOrder = same ? new List<string>() : currentOrder;

            //変化の判定
            bool changed = false;
            var oldOrder = orders == null ? new List<string>() : orders;
            if (oldOrder.Count == newOrder.Count)
            {
                for (int i = 0; i < oldOrder.Count; i++)
                {
                    if (oldOrder[i].ToUpper() != newOrder[i].ToUpper())
                    {
                        changed = true;
                        break;
                    }
                }
            }
            else
            {
                changed = true;
            }
            orders = newOrder;

            return changed;
        }

#if DEBUG
        public static void Test()
        {
            var t = new BinderContentOrder();
            t.orders = new List<string>();
            t.orders.Add("file_1.txt");
            t.orders.Add("file_4.txt");
            t.orders.Add("file_2.txt");
            t.orders.Add("file_5.txt");

            var origin = new string[]
            {
                "File_1.txt",
                "File_2.txt",
                "File_3.txt",
                "File_4.txt",
                "File_06.txt",
                "File_5.txt",
                "File_6.txt",
                "File_60_2.txt",
                "File_50.txt",
                "gile_60.txt",
                "File_60.txt",
                "File_60_1.txt",
            };
            var contents = origin.Select(x => new BinderContent { Filename = x }).ToList();
            t.Sort(contents);
        }
#endif
    }
}
