using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T11
    {
        public void T11D1()
        {
            Console.WriteLine(Compare<int>.compareGeneric(3,4));
            Console.WriteLine(Compare<string>.compareGeneric("abc","a"));
            Console.Read();
        }
        #region T11D2
        public static void testGeneric()
        {
            Stopwatch stopwatch = new Stopwatch();
            List<int> genericList = new List<int>();
            stopwatch.Start();
            for (int i = 0; i < 10000000; i++)
            {
                genericList.Add(i);
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}:{ts.Milliseconds/10:00}";
            Console.WriteLine("泛型类型运行时间"+elapsedTime);
        }

        public static void testNonGeneric()
        {
            Stopwatch stopwatch = new Stopwatch();
            ArrayList arraylist = new ArrayList();
            stopwatch.Start();
            for (int i = 0; i < 10000000; i++)
            {
                arraylist.Add(i);
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}:{ts.Milliseconds / 10:00}";
            Console.WriteLine("非泛型类型运行时间" + elapsedTime);
        }

        #endregion

        public void T11D3()
        {
            Type t = typeof(Dictionary<,>);
            Console.WriteLine("是否为开放类型："+t.ContainsGenericParameters);
             t = typeof(Dictionary<int,int>);
            Console.WriteLine("是否为开放类型：" + t.ContainsGenericParameters);
            Console.Read();
        }

        public void T11D4()
        {
            TypeWithStaticField<int>.field = "一";
            TypeWithStaticField<string>.field = "二";
            TypeWithStaticField<Guid>.field = "三";

            NoGenericTypeWithStaticField.field = "非泛型静态类型字段一";
            NoGenericTypeWithStaticField.field = "非泛型静态类型字段二";
            NoGenericTypeWithStaticField.field = "非泛型静态类型字段三";

            NoGenericTypeWithStaticField.OutField();

            TypeWithStaticField<int>.OutField();
            TypeWithStaticField<string>.OutField();
            TypeWithStaticField<Guid>.OutField();
            Console.Read();
        }

        public void T11D5()
        {
            GenericClass<int>.Print();
            GenericClass<string>.Print();

            NonGenericClass.Print();
            NonGenericClass.Print();
            Console.Read();
        }
    }
    #region T11D1
    public class Compare
    {
        public static int compareInt(int int1,int int2)
        {
            if (int1.CompareTo(int2)>0)
            {
                return int1;
            }
            else
            {
                return int2;
            }
        }

        public static string compareString(string str1,string str2)
        {
            if (str1.CompareTo(str2)>0)
            {
                return str1;
            }
            else
            {
                return str2;
            }
        }
    }
    public class Compare<T>where T : IComparable
    {
        public static T compareGeneric(T t1,T t2)
        {
            if (t1.CompareTo(t2)>0)
            {
                return t1;
            }
            else
            {
                return t2;
            }
        }
    }
    #endregion

    #region T11D4
    public static class TypeWithStaticField<T>
    {
        public static string field;
        public static void OutField()
        {
            Console.WriteLine($"{field}:{typeof(T).Name}");
        }
      
    }
    public static class NoGenericTypeWithStaticField
    {
        public static string field;
        public static void OutField()
        {
            Console.WriteLine(field);
        }
    }

    #endregion

    #region T11D5
    public static class GenericClass<T>
    {
        static GenericClass()
        {
            Console.WriteLine($"泛型的静态构造函数被调用，实际类型{typeof(T)}");
        }
        public static void Print()
        {

        }
    }
    public static class NonGenericClass
    {
        static NonGenericClass()
        {
            Console.WriteLine("非泛型的静态构造函数被调用");
        }
        public static void Print()
        {

        }
    }
    #endregion
}
