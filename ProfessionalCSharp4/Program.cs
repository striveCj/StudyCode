using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape r=new Shape();
            DrawShape(r);
            Shape1 r1=new Ellipse1();
            DrawShape(r1);

            IBankAccount venusAccount=new SaverAccount();
            IBankAccount jupiterAccount=new SaverAccount();
            venusAccount.PayIn(200);
            venusAccount.Withdraw(100);
            Console.WriteLine(venusAccount.ToString());
            jupiterAccount.PayIn(500);
            jupiterAccount.Withdraw(600);
            jupiterAccount.Withdraw(100);
            Console.WriteLine(jupiterAccount.ToString());
            ITransferBankAccount tAccount=new CurrentAccount();
            tAccount.PayIn(500);
            tAccount.TransferTo(venusAccount, 100);
            Console.WriteLine(venusAccount.ToString());
            Console.WriteLine(tAccount.ToString());

        }

        public static void DrawShape(Shape shape) => shape.Draw();
        public static void DrawShape(Shape1 shape) => shape.Draw();
    }
}
