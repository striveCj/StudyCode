using System;
using System.Windows.Forms;

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
        /// <summary>
        /// 记录事件的回调方法
        /// </summary>
        /// <param name="title"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ReportEvent(string title,object sender,EventArgs e)
        {
            Console.WriteLine("发生的事件为：{0}",title);
            Console.WriteLine("发生事件的对象为：{0}",sender);
            Console.WriteLine("发生事件参数为：{0}",e.GetType());
            Console.WriteLine();
        }
        #endregion
    }

}
