﻿using DesignPatternsBook_Csharp.AbstractFactoryPattern;
using DesignPatternsBook_Csharp.AdapterPattern;
using DesignPatternsBook_Csharp.BuilderPattern;
using DesignPatternsBook_Csharp.CompositePattern;
using DesignPatternsBook_Csharp.DecoratorPattern;
using DesignPatternsBook_Csharp.FacadePattern;
using DesignPatternsBook_Csharp.MementoPattern;
using DesignPatternsBook_Csharp.PrototypePattern;
using DesignPatternsBook_Csharp.ProxyPattern;
using DesignPatternsBook_Csharp.PublishPattern;
using DesignPatternsBook_Csharp.SimpleFactoryPattern;
using DesignPatternsBook_Csharp.StatePattern;
using DesignPatternsBook_Csharp.StrategyPattern;
using DesignPatternsBook_Csharp.TemplatePattern;
using DesignPatternsBook_Csharp.Iterator;
using DesignPatternsBook_Csharp.SingletonPattern;
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
            //建造者模式
            BuilderPattern();
            //观察者模式
            PublishPattern();
            //抽象工厂模式
            AbstractFactoryPattern();
            //状态模式
            StatePattern();
            //适配器模式
            AdapterPattern();
            //备忘录模式
            MementoPattern();
            //组合模式
            CompositePattern();
            //迭代器模式
            IteratorPattern();
            //单例模式
            SingletonPattern();

        }

        public static void SimpleFactoryPattern()
        {
            Operation oper;
            oper = OperationFactory.createOperate("+");
            oper.NumberA = 1;
            oper.NumberB = 2;
            double result = oper.GetResult();
            Console.WriteLine(result);

            SimpleFactoryPattern.IFactory opearFactory = new AddFactory();
            Operation opesr = opearFactory.CreateOperation();
            opesr.NumberA = 1;
            opesr.NumberB = 2;
            double results = opesr.GetResult();


        }

        public static void StrategyPattern()
        {
            StrategyPattern.Context context;
            context = new StrategyPattern.Context(new ConcreteStrategyA());
            context.ContextInterface();
            context = new StrategyPattern.Context(new ConcreteStrategyB());
            context.ContextInterface();
            context = new StrategyPattern.Context(new ConcreteStrategyC());
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

        public static void BuilderPattern()
        {
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();
            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();
            Console.Read();
        }

        public static void PublishPattern()
        {
            ConcreteSubject s=new ConcreteSubject();
            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));
            s.SubjectState = "ABC";
            s.Notify();
            Console.Read();
        }

        public static void AbstractFactoryPattern()
        {
            User user = new User();
            Department dept = new Department();
            AbstractFactoryPattern.IFactory factory = new AccessFactory();
            IUser iu = factory.CreateUser();
            iu.Insert(user);
            iu.GetUser(1);

            IDepartment id = factory.createDepartment();
            id.Insert(dept);
            id.GetDepartment(1);
            Console.Read();
        }

        public static void StatePattern()
        {
            StatePattern.Context c = new StatePattern.Context(new ConcreteStateA());
            c.Request();
            c.Request();
            c.Request();
            c.Request();
            Console.Read();
        }

        public static void AdapterPattern()
        {
            Target target = new Adapter();
            target.Request();
            Console.Read();
        }

        public static void MementoPattern()
        {
            Originator o = new Originator();
            o.State = "On";
            o.Show();

            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            o.State = "Off";
            o.Show();

            o.SetMemento(c.Memento);
            o.Show();

            Console.Read();
        }

        public static void CompositePattern()
        {
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            root.Add(new Leaf("Leaf xa"));
            root.Add(new Leaf("Leaf xb"));

            root.Add(comp);
            Composite comp2 = new Composite("Composite X");
            comp2.Add(new Leaf("Leaf xya"));
            comp2.Add(new Leaf("Leaf xyb"));
            comp.Add(comp2);

            root.Add(comp2);
            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");

            root.Add(leaf);
            root.Remove(leaf);
            root.Display(1);
            Console.Read();
        }

        public static void IteratorPattern()
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "张三";
            a[1] = "李四";
            a[2] = "王五";
            a[3] = "赵六";
            ConcreteIterator i = new ConcreteIterator(a);
            object item = i.First();
            while (!i.IsDone())
            {
                Console.WriteLine($"{i.CurrentItem()}请先买票");
                i.Next();
            }
            Console.Read();
        }
        public static void SingletonPattern()
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            if (s1==s2)
            {
                Console.WriteLine("两个对象是相同的实例。");
            }
            Console.Read();
        }
    }
}
