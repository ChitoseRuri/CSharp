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
        /// <param name="offset">数组偏移量</param>
        /// <param name="num">要写入的int</param>
        public static void AddToBytes(byte[] buffer, int offset, int num)
        {
            buffer[offset++] = (byte)(num >> 24);
            buffer[offset++] = (byte)(num >> 16);
            buffer[offset++] = (byte)(num >> 8);
            buffer[offset++] = (byte)(num >> 0);
        }

        public static void AddToBytes(byte[] buffer, int offset, string str)
        {
            int length = str.Length;
            for (int i = 0; i != length; ++i)
            {
                buffer[i + offset] = (byte)str[i];
            }
        }
    }
}
