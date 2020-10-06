using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Xml.Serialization;

namespace web.App_Code
{
    public class Tool
    {
        /// <summary>
        /// Md5加密算法
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }
            return byte2String;
        }

        public void Serialize<T>(object o)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            string filePath = HttpContext.Current.Server.MapPath("~/config/blogconfig.xml");
            Stream s = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
            xs.Serialize(s, o);
            s.Close();
        }

        public T DeSerialize<T>()
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            string filePath = HttpContext.Current.Server.MapPath("~/config/blogconfig.xml");
            Stream s = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            s.Position = 0;
            T t = (T)xs.Deserialize(s);
            s.Close();
            return t;
        }
    }
}