using System;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace StudyCode
{
    public class T14
    {
        #region T14D1
        /// <summary>
        /// Lambda表达式演变过程
        /// </summary>
        public static void T14D1()
        {
            //TODO:C#1.0中创建委托实例的代码
            Func<string, int> delegatetest1 = new Func<string, int>(Callbackmethod);
            //TODO:C#2.0中用匿名方法来创建委托，此时不需要去额外定义回调方法
            Func<string, int> delegatetest2 = delegate (string text)
               {
                   return text.Length;
               };
            //TODO:C#3.0中用Lambda表达式来创建委托实例
            Func<string, int> delegatetest3 = (string text) => text.Length;
            //TODO:省略参数类型
            Func<string, int> delegatetest4 = (text) => text.Length;
            //省略括号
            Func<string, int> delegatetest= text => text.Length;
            Console.WriteLine($"使用Lambda表达式返回字符串的长度为{delegatetest("jakeChen")}");
            Console.Read();
        }
        /// <summary>
        /// 回调方法
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int Callbackmethod(string text)
        {
            return text.Length;
        }
        #endregion

        #region T14D2
        public static void T14D2()
        {
            //创建一个button实例
            Button button1 = new Button();
            button1.Text = "点击我";
            //用C#2.0中匿名对象的方法来订阅事件
            button1.Click += delegate (object sender, EventArgs e)
              {
                  ReportEvent("click事件", sender, e);
              };
            button1.KeyPress += delegate (object sender, KeyPressEventArgs e)
            {
                ReportEvent("KeyPress事件，即按下事件", sender, e);
            };
            //C#3.0之前，初始化对象时用以下代码
            Form form = new Form();
            form.Name = "在控制台中创建的窗体";
            form.AutoSize = true;
            form.Controls.Add(button1);
            //运行窗体
            Application.Run(form);
        }

        #endregion

        #region T14D3
        public static void T14D3()
        {
            //创建一个button实例
            Button button1 = new Button() { Text = "点击我" };
            //C#3.0采用Lambda表达式的方式来订阅事件
            button1.Click += (sender, e) => ReportEvent("Click事件", sender, e);
            button1.KeyPress += (sender, e) => ReportEvent("KeyPress事件", sender, e);
            //在C#3.0中使用对象初始化器
            Form form = new Form { Name = "在控制台创建窗体", AutoSize = true, Controls = { button1 } };
            //运行窗体
            Application.Run(form);
        }
        #endregion

        #region T14D4
        /// <summary>
        /// 构造"a+b"的表达式树
        /// </summary>
        public static void T14D4()
        {
            //表达式的参数
            ParameterExpression a = Expression.Parameter(typeof(int), "a");
            ParameterExpression b = Expression.Parameter(typeof(int), "b");
            //表达式树的主体部分
            BinaryExpression be = Expression.Add(a, b);
            //构造表达式树
            Expression<Func<int, int, int>> expressionTree = Expression.Lambda<Func<int, int, int>>(be, a, b);
            //分析树结构，获取表达式树的主体部分
            BinaryExpression body = (BinaryExpression)expressionTree.Body;
            //左节点，每个节点本身就是一个表达式对象
            ParameterExpression left = (ParameterExpression)body.Left;
            //右节点
            ParameterExpression right = (ParameterExpression)body.Right;
            //输出表达式树
            Console.WriteLine($"表达式树结构为：{expressionTree}");
            //输出
            Console.WriteLine("表达式树主体为");
            Console.WriteLine(expressionTree.Body);
            Console.WriteLine($"表达式树左节点为：{left.Name}{Environment.NewLine}节点类型为{left.Type}{Environment.NewLine}表达式树右节点为：{right.Name}{Environment.NewLine}节点类型为{right.Type}{Environment.NewLine}");
            Console.Read();
        }
        #endregion

        #region T14D5
        /// <summary>
        /// 构造"a+b"的表达式树 Lambda
        /// </summary>
        public static void T14D5()
        {
            //将Lambda表达式来构造表达式树
            Expression<Func<int, int, int>> expressionTree = (a, b) => a + b;
            //获得表达式树
            Console.WriteLine($"参数1{expressionTree.Parameters[0]},参数2{expressionTree.Parameters[1]}");
            //分析树结构，获取表达式树的主体部分
            BinaryExpression body = (BinaryExpression)expressionTree.Body;
            //左节点，每个节点本身就是一个表达式对象
            ParameterExpression left = (ParameterExpression)body.Left;
            //右节点
            ParameterExpression right = (ParameterExpression)body.Right;
            //输出表达式树
            Console.WriteLine($"表达式树结构为：{expressionTree}");
            //输出
            Console.WriteLine("表达式树主体为");
            Console.WriteLine(expressionTree.Body);
            Console.WriteLine($"表达式树左节点为：{left.Name}{Environment.NewLine}节点类型为{left.Type}{Environment.NewLine}表达式树右节点为：{right.Name}{Environment.NewLine}节点类型为{right.Type}{Environment.NewLine}");
            Console.Read();
        }
        #endregion

        #region T14D6
        public static void T14D6()
        {
            //将Lambda表达式构造成表达式树
            Expression<Func<int, int, int>> expressionTree = (a, b) => a + b;
            //通过调用Compile方法来生成Lambda表达式的委托
            Func<int, int, int> delinstance = expressionTree.Compile();
            //调用委托实例获取结果
            int result = delinstance(2, 3);
            Console.WriteLine($"2,3的和为{result}");
            Console.Read();
        }
        #endregion

        /// <summary>
        /// 记录事件的回调方法
        /// </summary>
        /// <param name="title"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ReportEvent(string title, object sender, EventArgs e)
        {
            Console.WriteLine("发生的事件为：{0}", title);
            Console.WriteLine("发生事件的对象为：{0}", sender);
            Console.WriteLine("发生事件参数为：{0}", e.GetType());
            Console.WriteLine();
        }
    }

}
