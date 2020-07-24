using System;

namespace JsonChange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }



        /// <summary>
        /// 判断是否为16进制字符
        /// </summary>
        private static bool IsHex(char c)
        {
            return c >= '0' && c <= '9' || c >= 'a' && c <= 'f' || c >= 'A' && c <= 'F';
        }

        /// <summary>
        /// 读取到非空白字符
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="index">开始下标</param>
        /// <returns>非空白字符下标</returns>
        private static void ReadToNonBlankIndex(string text, ref int index)
        {
            while (index < text.Length && char.IsWhiteSpace(text[index])) index++;
        }
    }
}
