﻿using DesignPatternsBook_Csharp.DecoratorPattern;
using DesignPatternsBook_Csharp.FacadePattern;
using DesignPatternsBook_Csharp.PrototypePattern;
using DesignPatternsBook_Csharp.ProxyPattern;
using DesignPatternsBook_Csharp.SimpleFactoryPattern;
using DesignPatternsBook_Csharp.StrategyPattern;
using DesignPatternsBook_Csharp.TemplatePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //简单工厂模式 工厂方法模式
            SimpleFactoryPattern();
            //策略模式
            StrategyPattern();
            //装饰模式
            DecoratorPattern();
            //代理模式
            Proxy();
            //原型模式
            Prototype();
            //模板方法模式
            TemplatePattern();
            //外观模式
            FacadePattern();
        }

        public static void SimpleFactoryPattern()
        {
            Operation oper;
            oper = OperationFactory.createOperate("+");
            oper.NumberA = 1;
            oper.NumberB = 2;
            double result = oper.GetResult();
            Console.WriteLine(result);

            IFactory opearFactory = new AddFactory();
            Operation opesr = opearFactory.CreateOperation();
            opesr.NumberA = 1;
            opesr.NumberB = 2;
            double results = opesr.GetResult();


        }

        public static void StrategyPattern()
        {
            Context context;
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();
            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();
            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();
            Console.Read();
        }

        public static void DecoratorPattern()
        {
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();
            d1.SetComponent(c);
            d2.SetComponent(d1);
            d2.Operation();
            Console.Read();
        }

        public static void Proxy()
        {
            Proxy proxy = new Proxy();
            proxy.Request();
            Console.Read();
        }

        public static void Prototype()
        {
            ConcretePrototype1 p1 = new ConcretePrototype1("I");
            ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();
            Console.WriteLine("Cloned:{0}",c1.Id);
            Console.Read();
        }

        public static void TemplatePattern()
        {
            AbstractClass c;
            c = new ConcreteClassA();
            c.TemplateMethod();
            c = new ConcreteClassB();
            c.TemplateMethod();
            Console.Read();
        }

        public static void FacadePattern()
        {
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            Console.Read();
        }
    }
}
