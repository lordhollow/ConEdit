using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ConEditor
{
    /// <summary>
    /// 文字コード判定(IMultiLanguage2::DetectInputCodepage使用)
    /// </summary>
    class CodePageDetector
    {
        public static Encoding DefaultEncoding = Encoding.UTF8;

        public static Encoding DetectEncoding(byte[] bytes)
        {
            if ((bytes == null) || (bytes.Length == 0))
            {
                return DefaultEncoding;
            }
            IMultiLanguage2 lang = (IMultiLanguage2)new MultiLanguage();
            int len = bytes.Length;
            DetectEncodingInfo info = new DetectEncodingInfo();
            int scores = 1;

            // bytes to IntPtr
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            IntPtr pbytes = Marshal.UnsafeAddrOfPinnedArrayElement(bytes, 0);

            try
            {
                lang.DetectInputCodepage(0, 0, pbytes, ref len, out info, ref scores);
            }
            catch
            {
                info.nCodePage = (uint)DefaultEncoding.CodePage;
            }
            finally
            {
                if (handle.IsAllocated)
                    handle.Free();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(lang);
            }
            if (info.nCodePage == Encoding.ASCII.CodePage)
            {
                //ASCIIのときはUTF-8にする
                return Encoding.UTF8;
            }
            return Encoding.GetEncoding((int)info.nCodePage);
        }
    }

    public struct DetectEncodingInfo
    {
        public UInt32 nLangID;
        public UInt32 nCodePage;
        public Int32 nDocPercent;
        public Int32 nConfidence;
    };

    [ComImport, Guid("275c23e2-3747-11d0-9fea-00aa003f8646")]
    public class MultiLanguage
    {
    }

    [Guid("DCCFC164-2B38-11D2-B7EC-00C04F8F5D9A"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMultiLanguage2
    {
        void GetNumberOfCodePageInfo();
        void GetCodePageInfo();
        void GetFamilyCodePage();
        void EnumCodePages();
        void GetCharsetInfo();
        void IsConvertible();
        void ConvertString();
        void ConvertStringToUnicode();
        void ConvertStringFromUnicode();
        void ConvertStringReset();
        void GetRfc1766FromLcid();
        void GetLcidFromRfc1766();
        void EnumRfc1766();
        void GetRfc1766Info();
        void CreateConvertCharset();
        void ConvertStringInIStream();
        void ConvertStringToUnicodeEx();
        void ConvertStringFromUnicodeEx();
        void DetectCodepageInIStream();
        void DetectInputCodepage(
            [In] UInt32 dwFlag,
            [In] UInt32 dwPrefWinCodePage,
            [In] IntPtr pSrcStr,
            [In, Out] ref Int32 pcSrcSize,
            [Out] out DetectEncodingInfo lpEncoding,
            [In, Out] ref Int32 pnScores);
        void ValidateCodePage();
        void GetCodePageDescription();
        void IsCodePageInstallable();
        void SetMimeDBSource();
        void GetNumberOfScripts();
        void EnumScripts();
        void ValidateCodePageEx();
    }
}