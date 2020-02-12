using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using Microsoft.International.Converters.PinYinConverter;

namespace RMS
{
    class Common
    {
        /// <summary>
        /// 转换成MD5码
        /// </summary>
        /// <param name="str">明文</param>
        /// <returns></returns>
        public static string GetStringMD5(string str)
        {
            string msg = "";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] buffer = md5.ComputeHash(bytes);
            for (int i = 0; i < buffer.Length; i++)
            {
                msg += buffer[i].ToString("x2");
            }
            return msg;
        }
        
        /// <summary>
        /// 字符串转换成拼音
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        //public static string GetChinesePinYin(string str)
        //{
        //    string pinyin = "";
        //    foreach (char item in str)
        //    {

        //        if (ChineseChar.IsValidChar(item))
        //        {
        //            ChineseChar cc = new ChineseChar(item);

        //            pinyin += cc.Pinyins[0].Trim('1', '2', '3', '4', '5') + " ";

        //            //for (int i = 0; i < cc.PinyinCount; i++)
        //            //{
        //            //    pinyin += cc.Pinyins[i];
        //            //}
        //        }
        //        else
        //        {
        //            pinyin += item + " ";
        //        }
        //    }
        //    return pinyin;
        //}
    }
}
