using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    /// <summary>
    /// TODO:扩展方法必须在非泛型静态类中定义
    /// </summary>
    public static class T15
    {
        #region T15D1
        public static void T15D1()
        {
            List<int> source = new List<int>() { 1, 2, 3, 4, 5, 6, 3 };
            int jSums = JSum(source);
            Console.WriteLine("数组的奇数和为：" + jSums);
            Console.Read();
        }

        /// <summary>
        /// 定义扩展方法
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int JSum(this IEnumerable<int> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("输入数组为空");
            }
            int jsum = 0;
            bool flag = false;
            foreach (var current in source)
            {
                if (!flag)
                {
                    jsum += current;
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            return jsum;
        }
        #endregion

        #region T15D2
        public static void T15D3()
        {
            Console.WriteLine("空引用上调用扩展方法演示");

            string s = null;
            Console.WriteLine($"字符串S为空字符串{s.IsNull()}");
            Console.Read();
        }
        public static bool IsNull(this string str)
        {
            return str == null;
        }
        #endregion
    }

}
