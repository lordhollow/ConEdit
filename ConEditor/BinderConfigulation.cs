using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ConEditor
{
    /// <summary>
    /// バインダーの設定
    /// </summary>
    [XmlRoot]
    public class BinderConfigulation
    {
        public BinderConfigulation()
        {
            NewFilePattern = new BinderConfigulationAutoNewFilePattern();
            NewFilePattern.Prefix = "file_";
            NewFilePattern.Suffix = "";
            NewFilePattern.MinValue = 1;
        }

        /// <summary>
        /// 自動採番ファイルパターン
        /// </summary>
        [XmlElement("NewFilePattern")]
        public BinderConfigulationAutoNewFilePattern NewFilePattern { get; set; }
    }

    public class BinderConfigulationAutoNewFilePattern
    {
        [XmlAttribute("pre")]
        public string Prefix { get; set; }
        [XmlAttribute("suf")]
        public string Suffix { get; set; }
        [XmlAttribute("min")]
        public UInt32 MinValue { get; set; }
    }

    public class BinderConfigulationLoader
    {
        public static BinderConfigulation Load(string path)
        {
            try
            {
                path = System.IO.Path.Combine(path, BinderConfigulatioName);
                var ser = new XmlSerializer(typeof(BinderConfigulation));
                using (var f = new System.IO.StreamReader(path))
                {
                    return ser.Deserialize(f) as BinderConfigulation;
                }
            }
            catch (Exception e)
            {
                Report.Export(e);
            }
            return null;
        }

        public static bool Save(string path, BinderConfigulation conf)
        {
            try
            {
                path = System.IO.Path.Combine(path, BinderConfigulatioName);
                var ser = new XmlSerializer(typeof(BinderConfigulation));
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

        public static string BinderConfigulatioName
        {
            get { return "binderConfig.xml"; }
        }
    }

}
