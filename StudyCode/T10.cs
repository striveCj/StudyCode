using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    /// <summary>
    /// 值类型和引用类型
    /// </summary>
    public class T10
    {
        #region T10D1-T10D2总结
        //TODO：值类型与引用类型的区别在于实际数据的存储位置，值类型的数据和实际变量都存储在堆栈中；而引用类型则只有变量存储在堆栈中，变量存储的实际数据地址，实际数据存储在与地址相对应的托管堆中
        //TODO：值类型实例总会被分配到它声明的地方，如果声明在局部变量时，它被分配到栈上，而如果声明为引用类型的成员时，则被分配到托管堆上，而引用类型实例总是被分配到托管堆上
        //TODO：值类型与引用类型的区别
        //TODO：1.值类型继承与ValueType，ValueType又继承自System.Object；而引用类型直接继承与System.Object。
        //TODO：2.值类型的内存不受GC控制，作用域结束时，值类型会被操作系统自动释放，从而减少托管堆的压力；而引用类型的内存管理则由GC来完成。
        //TODO：3.通常值类型是具有密封性的，我们不能把值类型作为其他任何类型的基类，而引用类型则一般具有继承性，主要指类和接口。
        //TODO：4.值类型不能为null值(可空类型除外)，它会被初始化为数值0；而引用类型在默认情况下会被初始化为null值，表示不指向托管堆中的任何地址。对值为null的引用类型的任何操作，都会引发NullReferenceExcption异常。
        //TODO：5.由于值类型变量包含其实际数据，因此在默认情况下，值类型之间的参数传递不会影响变量本身；而引用类型变量保存的是数据的引用地址，他们作为参数被传递时，参数会发生改变，从而影响引用类型变量的值。
        #endregion
        /// <summary>
        /// 装箱和拆箱
        /// </summary>
        public void T10D3()
        {
            int i = 3;
            object o = i;
            int y = (int)o;
        }
        #region T10D4
        /// <summary>
        /// 值类型参数的按值传递
        /// </summary>
        public void T10D4()
        {
            int addNum = 1;
            Add(addNum);
            Console.WriteLine($"调用方法后参数的值{addNum}");
            Console.Read();
        }
        public static void Add(int addnum)
        {
            addnum += 1;
            Console.WriteLine($"方法中的值{addnum}");
        }
        #endregion

        #region T10D5
        /// <summary>
        /// 引用类型参数的按值传递
        /// </summary>
        public void T10D5()
        {
            Console.WriteLine("引用类型按值传递的情况");
            RefClass refClass = new RefClass();
            refClass.addNum = 1;
            AddRef(refClass);
            Console.WriteLine($"调用方法后，实参addNum的值为{refClass.addNum}");
        }
        private static void AddRef(RefClass addnumRef)
        {
            addnumRef.addNum += 1;
            Console.WriteLine($"方法中addnum的值为{addnumRef.addNum}");
        }
        #endregion

        #region T10D6
        /// <summary>
        /// string引用类型参数按值传递的特殊情况(string的不可变性)
        /// </summary>
        public void T10D6()
        {
            Console.WriteLine("string类型按值传递的特殊情况");
            string oldStr = "old string";
            ChangeStr(oldStr);
            Console.WriteLine("方法调用后的值为" +oldStr);
            Console.Read();
        }

        private static void ChangeStr(string oldStr)
        {
            oldStr = "New string";
            Console.WriteLine("方法中oldStr的值"+oldStr);
        }
        #endregion

        #region T10D7
        /// <summary>
        /// 值类型和引用类型参数的按引用传递情况
        /// </summary>
        public void T10D7()
        {
            Console.WriteLine("值类型和引用类型参数的按引用传递情况");
            int num = 1;
            string refStr = "Old String";
            ChangeByValue(ref num);
            Console.WriteLine(num);

            ChangeByRef(ref refStr);
            Console.WriteLine(refStr);
            Console.Read();
        }

        private static void ChangeByValue(ref int numValue)
        {
            numValue = 10;
            Console.WriteLine(numValue);
        }

        private static void ChangeByRef(ref string numRef)
        {
            numRef = "new string";
            Console.WriteLine(numRef);
        }
        #endregion
    }
    #region T10D1
    /// <summary>
    /// 引用类型嵌套定义值类型
    /// TODO:引用类型中嵌套定义值类型：如果类的字段类型是值类型，它将作为引用类型实例的一部分，被分配到托管堆中。但局部变量中的值类型，任然会被分配到线程堆栈中
    /// </summary>
    public class NestedValueTypeInRef
    {
        //TODO:valueType作为引用类型的一部分被分配到托管堆上
        private int valueType = 3;
        public void Method()
        {
            //TODO:c被分配到线程堆栈上
            char c = 'c';
        }
    }
    
    #endregion

    #region T10D2
    public class TestClass
    {
        public int x;
        public int y;
    }
    /// <summary>
    /// 值类型中嵌套定义引用类型
    /// TODO:值类型嵌套定义引用类型时，堆栈上将保存该引用类型的引用，而司机的数据则依然保存在托管堆中。
    /// </summary>
    public struct NestedRefTypeInValue
    {
        //TODO:结构体中的字段不能被初始化
        private TestClass classinValueType;
        //TODO:结构体中，不能定义无参的构造函数
        public NestedRefTypeInValue(TestClass t)
        {
            //TODO：在我敲的书中 classinValueType.x赋值是放在classinValueType = t上面的，但是我放上去会报错，通过不了编译
            classinValueType = t;
            classinValueType.x = 3;
            classinValueType.y = 5;
        }
    }
    #endregion

    #region T10D5-class
    public class RefClass
    {
        public int addNum;
    }
    #endregion

}
