using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace StudyCode
{
    public class T16
    {
        private static string xmlString = @"<Persons>
        <Person Id='1'>
            <Name>张三</Name>
            <Age>18</Age>
        </Person>
        <Person Id='2'>
            <Name>李四</Name>
            <Age>18</Age>
        </Person>
        <Person Id='3'>
            <Name>王五</Name>
            <Age>18</Age>
        </Person>
        </Persons>";

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

        #region T16D2
        public static void T16D2()
        {
            Console.WriteLine("使用老方法来对XML文件查询");
            OldLinqToXMLQuery();
            Console.WriteLine("使用linq对XML文件查询");
            UsingLinqLingqtoXML();
            Console.Read();
        }
        /// <summary>
        /// 使用xPath方式来对XML文件进行查询
        /// </summary>
        private static void OldLinqToXMLQuery()
        {
            //导入XML文件
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            //创建查询XML文件的XPath
            string xPath = "/Persons/Person";
            XmlNodeList querynodes = xmlDoc.SelectNodes(xPath);
            //查询Person元素
            foreach (XmlNode node in querynodes)
            {
                foreach (XmlNode childnode in node.ChildNodes)
                {   //查询名字为“李四”的元素
                    if (childnode.InnerXml=="李四")
                    {
                        Console.WriteLine($"姓名为{childnode.InnerXml}Id为{node.Attributes["Id"].Value}");
                    }
                }
            }
        }

        /// <summary>
        /// 使用LINQ的文件来对XML文件进行查询
        /// </summary>
        private static void UsingLinqLingqtoXML()
        {
            //导入XML
            XDocument doc = XDocument.Load(xmlString);
            //创建查询，获取姓名为“李四”的元素
            IEnumerable<XElement> queryResults = from element in doc.Elements("Person")
                                                 where element.Element("Name").Value == "李四"
                                                 select element;
            foreach (var xele in queryResults)
            {
                Console.WriteLine($"姓名为{xele.Element("Name").Value}ID为{xele.Attribute("Id").Value}");
            }
        }        
        #endregion
    }
}
