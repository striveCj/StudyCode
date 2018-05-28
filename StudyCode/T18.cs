using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Linq.Expressions;
namespace StudyCode
{
    public  class T18
    {
        #region 定义动态类型
        dynamic i = 5;
        #endregion 

        #region 动态类型约束
        //TODO：不能用动态类型作为参数来调用扩展方法，我们可以通过下述两种方式解决这个问题
        public void T18D1()
        {
            var numbers = Enumerable.Range(10, 10);
            dynamic number = 4;
            //TODO：第一种是将动态类型强制转换为正确的类型
            var right1 = numbers.Take((int)number);
            //TODO：第二种是使用静态方法来调用扩展方法
            var right2 = Enumerable.Take(numbers, number);
        }
        //TODO：不能将Lambda表达式定义为动态类型，因为他们之间不存在隐式转换，如果硬要把Lambda表达式定义为动态类型，就需要明确指定委托的类型
        //TODO：Error dynamic lambadarestrict = x => x + 1;
        dynamic rightlambda = (Func<int, int>)(x => x + 1);
        //TODO: 不能调用构造函数和静态方法，因为此时编译器无法指定具体类型
        //TODO: 不能将dynamic关键字用于基类声明，也不能讲dynamic用于类型参数的约束，或作为类型所实现的接口的一部分
        #endregion

        #region 实现自己的动态类型
            /// <summary>
            /// 使用ExpandoObject来实现动态行为
            /// </summary>
        public void T18D2()
        {
            dynamic expand = new ExpandoObject();
            expand.Name = "jakeChen";
            expand.Age = 24;
            expand.Addmethod = (Func<int, int>)(x => x + 1);
            Console.WriteLine($"expand类型的姓名为{expand.Name}年龄为{expand.Age}");
            Console.WriteLine($"调用expand类型的动态绑定的方法{expand.Addmethod(5)}");
            Console.Read();
        }
        /// <summary>
        /// 使用DynamicObject来实现动态行为
        /// </summary>
        public void T18D3()
        {
            dynamic dynamicobj = new DynamicType();
            dynamicobj.CallMethod();
            dynamicobj.Name = "jakeChen";
            dynamicobj.Age = 24;
            Console.Read();
        }
        class DynamicType : DynamicObject
        {
            //TODO:重写TryXXX方法，该方法表示对对象进行动态调用
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                Console.WriteLine($"{binder.Name}方法正在调用");
                result = null;
                return true;
            }

            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                Console.WriteLine($"{binder.Name}属性被设置，设置的值为{value}");
                return true;
            }
        }


        #region T18D4
        public void T18D4()
        {
            dynamic dynamicobj2 = new DynamicType2();
            dynamicobj2.Call();
            Console.Read();
        }

        public class DynamicType2 : IDynamicMetaObjectProvider
        {
            public DynamicMetaObject GetMetaObject(Expression parameter)
            {
                Console.WriteLine("开始获取元数据......");
                return new Metadynamic(parameter, this);
            }
        }
        public class Metadynamic : DynamicMetaObject
        {
            internal Metadynamic(Expression expression, DynamicType2 value):base(expression,BindingRestrictions.Empty,value)
            {

            }
            public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
            {
                DynamicType2 target = (DynamicType2)base.Value;
                Expression self = Expression.Convert(base.Expression, typeof(DynamicType2));
                var restrictions = BindingRestrictions.GetInstanceRestriction(self, target);
                Console.WriteLine(binder.Name+"方法被调用了");
                return new DynamicMetaObject(self, restrictions);
            }
        }

        #endregion
        #endregion

    }
}
