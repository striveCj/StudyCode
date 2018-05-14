using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T9
    {

        public void T9D1()
        {
            Bridegroom bridegroom = new Bridegroom();

            Friend f1 = new Friend("张三");
            Friend f2 = new Friend("李四");
            Friend f3 = new Friend("王五");
            bridegroom.MarryEvent += new Bridegroom.MarryHandler(f1.SendMessage);
            bridegroom.MarryEvent += new Bridegroom.MarryHandler(f2.SendMessage);
            bridegroom.OnMarriageComing("发出事件");
            Console.WriteLine("----------------------------");
            bridegroom.MarryEvent -= new Bridegroom.MarryHandler(f2.SendMessage);
            bridegroom.MarryEvent += new Bridegroom.MarryHandler(f3.SendMessage);
            bridegroom.OnMarriageComing("再次发出事件");
            Console.Read();
        }

        public void T9D2()
        {
            BridegroomEvent bridegroom = new BridegroomEvent();

            FriendEvent f1 = new FriendEvent("张三");
            FriendEvent f2 = new FriendEvent("李四");
            FriendEvent f3 = new FriendEvent("王五");
            bridegroom.MarryEvent += new EventHandler(f1.SendMessage);
            bridegroom.MarryEvent += new EventHandler(f2.SendMessage);
            bridegroom.OnMarriageComing("发出事件");
            Console.WriteLine("----------------------------");
            bridegroom.MarryEvent -= new EventHandler(f2.SendMessage);
            bridegroom.MarryEvent += new EventHandler(f3.SendMessage);
            bridegroom.OnMarriageComing("再次发出事件");
            Console.Read();
        }

        public void T9D3()
        {
            BridegroomEventArgs bridegroom = new BridegroomEventArgs();
            FriendEventArgs f1 = new FriendEventArgs("张三");
            FriendEventArgs f2 = new FriendEventArgs("李四");
            FriendEventArgs f3 = new FriendEventArgs("王五");
            bridegroom.MarryEvent += new BridegroomEventArgs.MarryHandler(f1.SendMessage);
            bridegroom.MarryEvent += new BridegroomEventArgs.MarryHandler(f2.SendMessage);
            bridegroom.OnMarriageComing("发出事件");
            Console.WriteLine("----------------------------");
            bridegroom.MarryEvent -= new BridegroomEventArgs.MarryHandler(f2.SendMessage);
            bridegroom.MarryEvent += new BridegroomEventArgs.MarryHandler(f3.SendMessage);
            bridegroom.OnMarriageComing("再次发出事件");
            Console.Read();
        }
    }
    #region T9D1  

    public class Bridegroom
    {
        public delegate void MarryHandler(string name);

        public event MarryHandler MarryEvent;
        
        public void OnMarriageComing(string msg)
        {
            if (MarryEvent!=null)
            {
                MarryEvent(msg);
            }
        }
    }
    public class Friend
    {
        public string Name;
        public Friend(string name)
        {
            Name = name;
        }

        public void SendMessage(string mssage)
        {
            Console.WriteLine(mssage);
            Console.WriteLine(this.Name+"收到");
        }
    }
    #endregion

    #region T9D2
    public class BridegroomEvent
    {

        public event EventHandler MarryEvent;

        public void OnMarriageComing(string msg)
        {
            if (MarryEvent != null)
            {
                Console.WriteLine(msg);
                MarryEvent(this,new EventArgs());
            }
        }
    }
    public class FriendEvent
    {
        public string Name;
        public FriendEvent(string name)
        {
            Name = name;
        }

        public void SendMessage(object s,EventArgs e)
        {
            Console.WriteLine(this.Name + "收到");
        }
    }
    #endregion

    #region T9D3
    public class MarryEventArgs : EventArgs
    {
        public string Message;
        public MarryEventArgs(string msg)
        {
            Message = msg;
        }
    }
    public class BridegroomEventArgs
    {
        public delegate void MarryHandler(object sender,MarryEventArgs e);

        public event MarryHandler MarryEvent;

        public void OnMarriageComing(string msg)
        {
            if (MarryEvent != null)
            {
                MarryEvent(this,new MarryEventArgs(msg));
            }
        }
    }
    public class FriendEventArgs
    {
        public string Name;
        public FriendEventArgs(string name)
        {
            Name = name;
        }

        public void SendMessage(object s, MarryEventArgs e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(this.Name + "收到");
        }
    }
    #endregion

}
