using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp3
{
    class Car
    {
        private double parkingTime = 0;
        DateTime inTime;
        DateTime outTime;
        public Car(string carName)
        {

        }
        public void  SetInTime()
        {
            inTime = DateTime.Now;

        }
        public void Park()
        {
            Random random = new Random();
            int parkTi = random.Next(300);
            Console.WriteLine(parkTi);
            Thread.Sleep(parkTi);
        }
        public void SetOutTime()
        {
            outTime = DateTime.Now;
            parkingTime = outTime.Millisecond - inTime.Millisecond;
            Console.WriteLine(parkingTime);
        }
        public void FeeSettle()
        {
            if(parkingTime < 100)
            {
                Console.WriteLine("주차비는 1000원입니다.");
            }
            else if (parkingTime > 100 && parkingTime < 200)
            {
                Console.WriteLine("주차비는 2000원입니다.");
            }
            else if (parkingTime > 200)
            {
                Console.WriteLine("주차비는 3000원입니다.");

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("16하6399");
            car.SetInTime();
            car.Park();
            car.SetOutTime();
            car.FeeSettle();

            Console.ReadKey();
        }
    }
}
