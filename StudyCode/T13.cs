using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T13
    {
        #region T13D2
        public void T13D2()
        {
            //用var声明局部变量
            //TODO：使用隐式类型时有一些限制
            //TODO：被声明的变量是一个局部变量，不能为字段(包括静态字段和实例字段)
            //TODO：变量在声明是必须被初始化，因为编译器要根据变量的赋值来推断类型，如果未初始化，编译器也就无法完成推断，C#是静态语言，变量类型位置就会出现编译时错误
            //TODO：变量不能初始化为一个方法组，也不能为一个匿名函数。
            //TODO：变量不能初始化为null，因为null可以隐式的转化为任何引用类型或可空类型，编译器奖不能推断出该变量到底是什么类型。
            //TODO：不能用一个正在声明的变量来初始化隐式类型
            //TODO：不能用var来声明方法中的参数类型
            var stringvariable = "learning hard";
            //stringvariable = 2;
        }
        #endregion
    }
    #region T13D1
    /// <summary>
    /// 自动属性
    /// </summary>
    public class Person1
    {
        //使用自动实现的属性来定义属性
        //定义可读写属性
        public string Name { get; set; }
        //定义只读属性
        public int Age { get;private set; }
    }
    #endregion


}
