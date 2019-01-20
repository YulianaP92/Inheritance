using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Lesson
    {
        public static void AbstractExample()
        {
            //var car = new Car2(10, 100, 234324);
            //car.Move(2);
        }

        public abstract class Transport2
        {
            public Transport2()
            {
            }

            public Transport2(double mileage)
            {
                this.Mileage = mileage;
            }

            public double Mileage { get; protected set; }

            public abstract void Move(double km);
        }

        
        public class Car2 : Transport
        {
            public Car2(double consumption, int fuel, int mileage) : base(mileage)
            {
                this.Fuel = fuel;
                this.Consumption = consumption;
            }

            public double Fuel { get; protected set; }
            public double Consumption { get; protected set; }

            public override void Move(double km)
            {
                Fuel -= km * Consumption;
                Console.WriteLine("Car.Move");
            }

            public void FillUp(int liters)
            {
                Fuel += liters;
            }
        }
        
    }
}
