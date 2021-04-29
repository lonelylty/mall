using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Heals.CSX.Mall
{
    public class FileHelper
    {
        /// <summary>
        ///  file convert to Base64 string
        /// </summary>
        /// <param name="fs">Stream</param>
        /// <returns></returns>
        public static String FileToBase64(Stream fs)
        {
            string strRet = null;

            try
            {
                if (fs == null) return null;
                byte[] bt = new byte[fs.Length];
                fs.Read(bt, 0, bt.Length);
                strRet = Convert.ToBase64String(bt);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strRet;
        }

        /// <summary>
        /// Base64 string convert to file
        /// </summary>
        /// <param name="strInput">base64 string</param>
        /// <param name="fileName">path</param>
        /// <returns></returns>
        public static bool Base64ToFileAndSave(string strInput, string fileName)
        {
            bool bTrue = false;

            try
            {
                byte[] buffer = Convert.FromBase64String(strInput);
                FileStream fs = new FileStream(fileName, FileMode.CreateNew);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                bTrue = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bTrue;
        }

        public static string PictureBase64Save(string strInput, string strProductId)
        {
            //Picture path and filename file suffix
            string regexStr = "data:image/(?<key>.*?);base64,";
            Regex r = new Regex(regexStr, RegexOptions.None);
            Match mc = r.Match(strInput);

            var fileSuffix = mc.Groups["key"].Value;
            var fileName = $"{strProductId}-{DateTime.Now.Ticks}.{fileSuffix}";

            var filePath = Path.Combine(MallConsts.MallDomainModuleAppPath, MallConsts.MallPictureSubFolder1,
                MallConsts.MallPictureSubFolder2, MallConsts.MallPictureSubFolder3);

            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

            string newbase = Regex.Replace(strInput, "data:image/.*;base64,", "");

            var file_Path_Name = Path.Combine(filePath, fileName);
            if (File.Exists(file_Path_Name)) File.Delete(file_Path_Name);

            var isSave = Base64ToFileAndSave(newbase, file_Path_Name);

            return isSave ? fileName : "";
        }
    }
}
