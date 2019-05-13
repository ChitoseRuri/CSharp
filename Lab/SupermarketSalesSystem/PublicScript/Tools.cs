using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR
{
    static class Tools
    {
        /// <summary>
        /// 把一个int放到byte数组里面
        /// </summary>
        /// <param name="buffer">byte数组</param>
        /// <param name="startIndex">数组偏移量</param>
        /// <param name="num">要写入的int</param>
        public static void AddToBytes(byte[] buffer, int startIndex, int num)
        {
            buffer[startIndex++] = (byte)(num >> 24);
            buffer[startIndex++] = (byte)(num >> 16);
            buffer[startIndex++] = (byte)(num >> 8);
            buffer[startIndex++] = (byte)(num >> 0);
        }

        /// <summary>
        /// 把一个string放到byte数组里面
        /// </summary>
        /// <param name="buffer">byte数组</param>
        /// <param name="startIndex">数组偏移量</param>
        /// <param name="str">要写入的字符串</param>
        public static void AddToBytes(byte[] buffer, int startIndex, string str)
        {
            int length = str.Length;
            for (int i = 0; i != length; ++i)
            {
                buffer[i + startIndex] = (byte)str[i];
            }
        }

        /// <summary>
        /// 把byte数组全部导出成string
        /// </summary>
        /// <param name="buffer">byte数组</param>
        /// <returns>导出的string</returns>
        public static string BytesToString(byte[] buffer)
        {
            return System.Text.Encoding.Default.GetString(buffer);
        }

        /// <summary>
        /// 在byte数组中从startIndex开始导出length长度的string
        /// </summary>
        /// <param name="buffer">byte数组</param>
        /// <param name="startIndex">开始的index</param>
        /// <param name="length">字符串长度</param>
        /// <returns>导出的string</returns>
        public static string BytesToString(byte[] buffer, int startIndex, int length)
        {
            StringBuilder stb = new StringBuilder();
            stb.Capacity = length;
            length = startIndex + length;
            while(startIndex < length)
            {
                stb.Append((char)buffer[startIndex++]);
            }
            return stb.ToString();
        }
    }
}
