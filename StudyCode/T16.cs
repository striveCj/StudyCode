using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T16
    {
        private static string xmlString= "<Persons><Person Id='1'></Persons><Name>张三</Name></Persons>"

        #region T16D1
        public static void T16D1()
        {
            List<int> inputArray = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                inputArray.Add(i);
            }
            Console.WriteLine("使用老方法来对集合对象查询，查询结果为：");
            OldQuery(inputArray);
            Console.WriteLine("使用新方法来对集合对象查询，查询结果为：");
            LinqQuery(inputArray);
            Console.Read();
        }
        /// <summary>
        /// 使用foreach返回集合中为偶数的元素
        /// </summary>
        /// <param name="collection"></param>
        public static void OldQuery(List<int> collection)
        {
            //创建用来保存查询结果的集合
            List<int> queryResults = new List<int>();
            foreach (var item in collection)
            {
                //判断元素是偶数的情况
                if (item % 2 == 0)
                {
                    queryResults.Add(item);
                }
            }
            foreach (var item in queryResults)
            {
                Console.WriteLine(item + "  ");
            }
        }
        /// <summary>
        /// 使用linq返回集合中为偶数的元素
        /// </summary>
        /// <param name="collection"></param>
        public static void LinqQuery(List<int> collection)
        {
            //创建查询表达式返回集合为偶数的元素
            var queryResults = from item in collection where item % 2 == 0 select item;
            //输出查询结果
            foreach (var item in queryResults)
            {
                Console.WriteLine(item+"  ");
            }
        }
        #endregion

        
    }
}
