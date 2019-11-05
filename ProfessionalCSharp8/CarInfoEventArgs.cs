using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace ProfessionalCSharp8
{
   public class CarInfoEventArgs:EventArgs
   {
       public CarInfoEventArgs(string car) => Car = car;
        public  string Car { get; set; }

   }

    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;

        public void NewCar(string car)
        {
            Console.WriteLine($"CarDealer,new car{car}");
            NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
        }
    }
}
