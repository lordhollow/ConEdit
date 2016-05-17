using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;

namespace ConEditor
{
    /// <summary>
    /// 設定
    /// </summary>
    [XmlRoot]
    public class Configulation
    {
        /// <summary>
        /// デフォルト値の設定
        /// </summary>
        public Configulation()
        {
            FontName = "メイリオ";
            FontSize = 10;
            Wordwrap = true;
            Width = 80;
            LineNoMethod = ConEditor.LineNoMethod.Individual;
        }


        /// <summary>
        /// フォント名
        /// </summary>
        [XmlElement("font")]
        public string FontName { get; set; }

        /// <summary>
        /// フォントサイズ
        /// </summary>
        [XmlElement("fontSize")]
        public int FontSize { get; set; }

        /// <summary>
        /// 折り返すかどうか。trueのときwidth幅で折り返し。
        /// </summary>
        [XmlElement("wordwrap")]
        public bool Wordwrap { get; set; }

        /// <summary>
        /// 幅。0(以下)の時はウィンドウサイズに合わせる。それ以外はFontSize*0.5*Width。
        /// </summary>
        [XmlElement("width")]
        public int Width { get; set; }

        /// <summary>
        /// 行番号表示
        /// </summary>
        [XmlElement("lineNo")]
        [DefaultValue(LineNoMethod.Individual)]
        public LineNoMethod LineNoMethod { get; set; }
    }

    /// <summary>
    /// 行番号表示
    /// </summary>
    public enum LineNoMethod
    {
        /// <summary>
        /// なし
        /// </summary>
        None,

        /// <summary>
        /// 全体行
        /// </summary>
        Total,

        /// <summary>
        /// 全体行（バインダ境界除く）
        /// </summary>
        TotalIgnoreBorder,

        /// <summary>
        /// ファイル個別
        /// </summary>
        Individual,

        /// <summary>
        /// ファイル個別（バインダインデックスあり)
        /// </summary>
        IndividualWithIndex,

    }

    public class ConfigulationLoader
    {
        public static Configulation Load(string path)
        {
            try
            {
                var ser = new XmlSerializer(typeof(Configulation));
                using (var f = new System.IO.StreamReader(path))
                {
                    return ser.Deserialize(f) as Configulation;
                }
            }
            catch (Exception e)
            {
                Report.Export(e);
            }
            return null;
        }

        public static bool Save(string path, Configulation conf)
        {
            try
            {
                var ser = new XmlSerializer(typeof(Configulation));
                using (var f = new System.IO.StreamWriter(path))
                {
                    ser.Serialize(f, conf);
                }
                return true;
            }
            catch (Exception e)
            {
                Report.Export(e);
            }
            return false;
        }

        public static string GlobalConfigPath
        {
            get
            {
                return System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "config.xml");
            }
        }
    }


}
