
using BestHTTP.SecureProtocol.Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestHTTP.TlsClientExtensions
{
    public class Ja3StringConverter
    {
        private static HashSet<int> CipherSuiteSet=new HashSet<int>();
        private static HashSet<int> NameGroupsSet=new HashSet<int>();
        private static bool RandomState = false;
        //"771,4865-4866-4867-49195-49199-49196-49200-52393-52392-49171-49172-156-157-47-53,5-35-13-65281-0-10-16-17513-43-51-45-27-11-23-18-21,29-23-24,0"
        void Convert(string ja3Str)
        {
           var arrays= ja3Str.Split(',');
            if (arrays.Length != 5)
            {
                throw new ArgumentOutOfRangeException("字符串格式错误");
            }
        }
        /// <summary>
        /// 套件转换
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static List<int> ParseCiphers(string codes= "4865-4866-4867-49195-49199-49196-49200-52393-52392-49171-49172-156-157-47-53")
        {

            if (CipherSuiteSet.Count == 0)
            {
                var fields = typeof(CipherSuite).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                foreach (var field in fields)
                {
                    var value = field.GetValue(null);
                    CipherSuiteSet.Add(System.Convert.ToInt32(value));
                }
            }
           

            if (string.IsNullOrEmpty(codes))
            {
                throw new ArgumentOutOfRangeException("无Cipher套件");
            }
            var arrays=  codes.Split('-');
            var list=new List<int>();
            for (int i = 0; i < arrays.Length; i++)
            {
                if (int.TryParse(arrays[i], out int code))
                {
                    if (CipherSuiteSet.Contains(code))
                    { 
                        list.Add(code);
                    }
                    else
                    {

                        throw new Exception("Not support cipher");
                    }

                }
                else
                {
                    throw new ArgumentException("Cipher错误");
                }
            }
            return list;
        }
        /// <summary>
        /// 椭圆算法转换
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static List<int> ParseSupportedGroups(string codes = "29-23-24")
        {

            if (NameGroupsSet.Count == 0)
            {
                var fields = typeof(NamedGroup).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                foreach (var field in fields)
                {
                    var value = field.GetValue(null);
                    NameGroupsSet.Add(System.Convert.ToInt32(value));
                }
            }


            if (string.IsNullOrEmpty(codes))
            {
                throw new ArgumentOutOfRangeException("无椭圆算法字符");
            }
            var arrays = codes.Split('-');
            var list = new List<int>();
            for (int i = 0; i < arrays.Length; i++)
            {
                if (int.TryParse(arrays[i], out int code))
                {
                    if (NameGroupsSet.Contains(code))
                    {
                        list.Add(code);
                    }
                    else
                    {

                        throw new Exception("Not support nameGroup");
                    }

                }
                else
                {
                    throw new ArgumentException("nameGroup");
                }
            }
            return list;
        }

    }
}
