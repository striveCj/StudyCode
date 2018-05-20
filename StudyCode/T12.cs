using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T12
    {
        #region T12D1
        public void T12D1()
        {
            Nullable<int> value = 1;
            Console.WriteLine("可控类型有值的输出情况");
            Display(value);

            value = new Nullable<int>();
            Console.WriteLine("可空类型没有值输出的情况：");
            Display(value);
        }

        private static void Display(int? nullable)
        {
            Console.WriteLine($"可空类型是否有值{nullable.HasValue}");
            if (nullable.HasValue)
            {
                Console.WriteLine($"值为{nullable.Value}");
            }
            Console.WriteLine($"GetValueorDefault():{nullable.GetValueOrDefault()}");

            Console.WriteLine($"GetValueOrDefault()重载方法{nullable.GetValueOrDefault(2)}");
            Console.WriteLine($"GetHashCode()方法调用{nullable.GetHashCode()}");
        }
        #endregion

        #region T12D2

        public void T12D2()
        {
            Console.WriteLine("??运算符");
            NullcoalescingOperator();
            Console.ReadKey();
        }
        private static void NullcoalescingOperator()
        {
            int? nullable = null;
            int? nullhasvalue = 1;
            int x = nullable ?? 12;

            int y = nullhasvalue ?? 123;
            Console.WriteLine(x);
            Console.WriteLine(y);

            string strnotnull = "123";
            string strnull = null;

            string result = strnotnull ?? "456";
            string result2 = strnull ?? "12";
            Console.WriteLine(result);
            Console.WriteLine(result2);
        }
        #endregion

        #region T12D3
        public void T12D3()
        {
            BoxedandUnboxed();
            Console.ReadKey();
        }

        private static void BoxedandUnboxed()
        {
            Nullable<int> nullable = 5;
            int? nullablewithoutvalue = null;

            Console.WriteLine($"获取不为null的可空类型的类型:{nullable.GetType()}");

            object obj = nullable;
            Console.WriteLine($"装箱后obj的类型{obj.GetType()}");
            int value = (int)obj;
            Console.WriteLine($"拆箱成非可空变量的情况{value}");

            nullable = (int?)obj;
            Console.WriteLine($"拆箱成非可空变量的情况{nullable}");
            obj = nullablewithoutvalue;
            Console.WriteLine($"对null的可空类型装箱后obj是否为null：{obj == null}");

            nullable = (int?)obj;
            Console.WriteLine($"一个没有值的可空类型装箱后，拆箱成可空变量是否为null：{0}");
        }
        #endregion

        #region T12D4

        delegate void VoteDelegate(string name);
        public void T12D4()
        {
            VoteDelegate votedelegate = new VoteDelegate(new Friend().Vote);
            votedelegate("SomeBody");

            VoteDelegate votedelegate2 = delegate (string nickname)
              {
                  Console.WriteLine($"昵称为：{nickname}也来投票了");
              };
            votedelegate2("EveryOne");
            Console.ReadKey();
        }
        public partial class Friend
        {
            public void Vote(string nickname)
            {
                Console.WriteLine($"昵称为{nickname}来投票了");
            }
        }

        #endregion

        #region T12D5
        delegate void ClosureDelegate();
        public void T12D5()
        {
            closureMethod();
            Console.ReadKey();
        }
        private static void closureMethod()
        {
            string outVariable = "外部变量";
            string capturedVariable = "被捕获的外部变量";
            ClosureDelegate closuredelegate = delegate
            {
                string localvariable = "匿名方法局部变量";
                Console.WriteLine(capturedVariable + " " + localvariable);
            };
            closuredelegate();
        }
        #endregion

        #region T12D6

        public void T12D6()
        {
            ClosureDelegate test = CreateDelegateInstance();
            test();
            Console.ReadKey();       
        }
        private static ClosureDelegate CreateDelegateInstance()
        {
            int count = 1;
            ClosureDelegate closuredelegate = delegate
            {
                Console.WriteLine(count);
                count++;
            };
            closuredelegate();
            return closuredelegate;
        }
        #endregion

        #region T12D7

        public void T12D7()
        {
            FriendByEnumerators firendcollection=new FriendByEnumerators();
            foreach (FriendByEnumerator f in firendcollection)
            {
                Console.WriteLine(f.Name);
            }

            Console.Read();
        }

        public class FriendByEnumerator
        {
            private string _name;

            public string Name
            {
                get { return _name;}
                set { _name = value; }
            }

            public FriendByEnumerator(string name)
            {
                this._name = name;
            }
        }

        public class FriendByEnumerators:IEnumerable
        {
            private readonly FriendByEnumerator[] _friendByEnumerator;

            public FriendByEnumerators()
            {
               _friendByEnumerator=new FriendByEnumerator[]
               {
                   new FriendByEnumerator("张三"),
                   new FriendByEnumerator("李四"),
                   new FriendByEnumerator("王五")
               };
            }
            public FriendByEnumerator this[int index]
            {
                get { return _friendByEnumerator[index]; }
            }
            public int Count
            {
                get { return _friendByEnumerator.Length; }
            }

            public IEnumerator GetEnumerator()
            {
                return new FriendByEnumeratorIterator(this);
            }
        }

        public class FriendByEnumeratorIterator: IEnumerator
        {
            private readonly FriendByEnumerators _friendByEnumerators;
            private int _index;
            private FriendByEnumerator _current;

            internal FriendByEnumeratorIterator(FriendByEnumerators friendcollection)
            {
                this._friendByEnumerators = friendcollection;
                _index = 0;
            }
            public object Current
            {
                get { return this._current; }
            }

            public bool MoveNext()
            {
                if (_index+1>_friendByEnumerators.Count)
                {
                    return false;
                }
                else
                {
                    this._current = _friendByEnumerators[_index];
                    _index++;
                    return true;
                }
            }
            public void Reset()
            {
                _index = 0;
            }
        }

        #endregion

        #region T12D8
        public void T12D8()
        {
            Friend3S firendcollection = new Friend3S();
            foreach (Friend3 f in firendcollection)
            {
                Console.WriteLine(f.Name);
            }

            Console.Read();
        }
        public class Friend3
        {
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public Friend3(string name)
            {
                this._name = name;
            }
        }
        public class Friend3S : IEnumerable
        {
            private readonly Friend3[] _friendByEnumerator;

            public Friend3S()
            {
                _friendByEnumerator = new Friend3[]
                {
                    new Friend3("张三"),
                    new Friend3("李四"),
                    new Friend3("王五")
                };
            }
            public Friend3 this[int index]
            {
                get { return _friendByEnumerator[index]; }
            }
            public int Count
            {
                get { return _friendByEnumerator.Length; }
            }

            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < _friendByEnumerator.Length; i++)
                {
                    yield return _friendByEnumerator[i];
                }
            }
        }
        #endregion
    }
}
