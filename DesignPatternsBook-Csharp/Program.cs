using DesignPatternsBook_Csharp.AbstractFactoryPattern;
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
using DesignPatternsBook_Csharp.BridgePattern;
using DesignPatternsBook_Csharp.CommandPattern;
using DesignPatternsBook_Csharp.ChainOfResponsibilityPattern;
using DesignPatternsBook_Csharp.MediatorPattern;
using DesignPatternsBook_Csharp.InterpreterPattern;
using DesignPatternsBook_Csharp.FlyweightPattern;
using DesignPatternsBook_Csharp.VisitorPattern;
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
            #region 原则
            //TODO:单一职责原则(SRP),就一个类而言，应该仅有一个引起它变化的原因。
            //TODO:开放-封闭原则,是说软件实体(类、模块、函数等)应该可以扩展但是不可以修改。
            //TODO:依赖倒转原则,A.高层模块不应该依赖底层模块。两个都应该依赖抽象。B.抽象不应该依赖细节。细节应该依赖抽象。
            //TODO:里氏代还原则(LSP),子类必须能够替换掉他们的父类型。

            #endregion

            //简单工厂模式 工厂方法模式
            //TODO:工厂指的是使用一个类来做创造实例的过程
            //TODO:工厂方法模式,定义一个用于创建对象的接口，让子类决定实例化哪一个类。工厂方法使一个类的实例化延迟到其子类。
            SimpleFactoryPattern();
            //策略模式
            //TODO:它定义了算法家族，分别封装起来，让它们之间可以互相替换，此模式让算法的变化，不会影响到使用算法的客户。
            StrategyPattern();
            //装饰模式
            //TODO:动态地给一个对象添加一些额外的职责，就增加功能来说，装饰模式比生成子类更为灵活。
            DecoratorPattern();
            //代理模式
            //TODO:为其他对象提供一种代理以控制对这个对象的访问
            Proxy();
            //原型模式
            //TODO:用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象
            Prototype();
            //模板方法模式
            //TODO:定义一个操作中的算法的骨架，而将一些步骤延迟到子类中。模板方法使得子类可以不改变一个算法的结构即可重新定义该算法的某些特定步骤。
            TemplatePattern();
            //外观模式
            //TODO:为子系统中的一组接口提供一个一致的界面，次模式定义了一个高层接口，这个接口使得这一子系统更加容易使用。
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
            //桥接模式
            BridgePattern();
            //命令模式
            CommandPattern();
            //职责链模式
            ChainOfResponsibilityPattern();
            //中介者模式
            MediatorPattern();
            //解释器模式
            InterpreterPattern();
            //享元模式
            FlyweightPattern();
            //访问者模式
            VisitorPattern();
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

        public static void BridgePattern()
        {
            Abstraction ab = new RefinedAbstraction();
            ab.SetImplementor(new ConcreteImplementorA());
            ab.Operation();
            ab.SetImplementor(new ConcreteImplementorB());
            ab.Operation();

            Console.Read();
        }
        public static void CommandPattern()
        {
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoker i = new Invoker();
            i.SetCommand(c);
            i.ExecuteCommand();
            Console.Read();
        }

        public static void ChainOfResponsibilityPattern()
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler1();
            Handler h3 = new ConcreteHandler1();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };
            foreach (var request in requests)
            {
                h1.HandleRequest(request);
            }
            Console.Read();
        }

        public static void MediatorPattern()
        {
            ConcreteMediator m = new ConcreteMediator();
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            m.Colleague1 = c1;
            m.Colleague2 = c2;
            c1.Send("吃过饭了么?");
            c2.Send("没有呢，你打算请客?");
            Console.Read();

        }

        public static void InterpreterPattern()
        {
            InterpreterPattern.Context context = new InterpreterPattern.Context();
            IList<AbstractExpression> list = new List<AbstractExpression>();
            list.Add(new TerminalExpression());
            list.Add(new NoterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());
            foreach (AbstractExpression exp in list)
            {
                exp.Interprent(context);
            }
            Console.Read();
        }

        public static void FlyweightPattern()
        {
            int extrinsicatate = 22;
            FlyweightFactory f = new FlyweightFactory();

            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicatate);
            Flyweight fy = f.GetFlyweight("Y");
            fx.Operation(--extrinsicatate);
            Flyweight fz = f.GetFlyweight("Z");
            fx.Operation(--extrinsicatate);

            Flyweight uf = new UnsharedConcreteFlyweight();
            uf.Operation(--extrinsicatate);

            Console.Read();
        }

        public static void VisitorPattern()
        {
            ObjectStructure o = new ObjectStructure();
            o.Attach(new ConcreteElementA());
            o.Attach(new ConcreteElementB());

            ConcreteVisittor1 v1 = new ConcreteVisittor1();
            ConcreteVisittor2 v2 = new ConcreteVisittor2();

            o.Accept(v1);
            o.Accept(v2);
        }
    }
}
