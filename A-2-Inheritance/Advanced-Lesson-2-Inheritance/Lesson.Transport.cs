using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Lesson
    {

        public static void InheritanceExample()
        {
            Transport transport = new Transport(mileage: 3000);
            Transport car = new Car(consumption: 10, fuel: 50, mileage: 35000);
        }

        public static void ObjectVariablesExample()
        {
            Transport transport;
            Car car;
            transport = new Car(10, 50, 35000);
            car = new Car(10, 50, 35000);

            var fuel = car.Fuel; //все хорошо
            //var consumption = transport.Consumption; //ошибка компиляции

            Transport t2;
            Car c2;
            t2 = car;     //Неявное приведение типов
            c2 = (Car)transport; //Явное приведение типов
        }

        public static void OperatorIsExample()
        {
            Transport transport1, transport2, transport3;
            transport1 = new Car(10, 50, 35000);
            transport2 = new Marine(35000);
            transport3 = new Aircraft(35000);

            bool isTransport1Marine = transport1 is Marine;
            bool isTransport2Marine = transport2 is Marine;
            bool isTransport3Marine = transport3 is Marine;
        }

        public static void OperatorAsExample()
        {
            Transport transport1, transport2, transport3;
            transport1 = new Car(10, 50, 35000);
            transport2 = new Marine(35000);
            transport3 = new Aircraft(35000);

            Marine marine11 = (Marine)transport1;
            Marine marine22 = (Marine)transport2;
            Marine marine33 = (Marine)transport3;

            Marine marine1 = transport1 as Marine;
            Marine marine2 = transport2 as Marine;
            Marine marine3 = transport3 as Marine;
        }

        public static void OperatorSwitchExample()
        {
            Transport transport1, transport2, transport3;
            transport1 = new Car(10, 50, 35000);
            transport2 = new Marine(35000);
            transport3 = new Aircraft(35000);

            foreach (var item in new Transport[] { transport1, transport2, transport3 })
            {
                switch (item)
                {
                    case Car c:
                        Console.Write(c.Fuel);
                        break;
                    case Marine m:
                        Console.Write(m.Draft);
                        break;
                    case Transport t:
                        Console.Write(t.Mileage);
                        break;
                }
            }
        }

        public static void VirtualMethodExample()
        {
            Transport transport1, transport2;
            Car car;
            transport1 = new Transport(35000);
            transport2 = new Car(10, 50, 35000);
            car = new Car(10, 50, 35000);

            Console.WriteLine("***");

            transport1.Move(1);

            Console.WriteLine("***");

            transport2.Move(2);

            Console.WriteLine("***");

            car.Move(3);

            Console.WriteLine("***");
        }

        public class Transport
        {
            public Transport()
            {
            }

            public Transport(double mileage)
            {
                this.Mileage = mileage;
            }

            public double Mileage { get; protected set; }

            public virtual void Move(double km)
            {
                Mileage += km;
                Console.WriteLine($"Transport.Move: {km}");
            }
        }

        public class Marine: Transport
        {
            public double Draft { get; protected set; }

            public Marine()
            {
            }

            public Marine(double mileage)
            {
                this.Mileage = mileage;
            }
        }

        public class Aircraft : Transport
        {
            public Aircraft()
            {
            }

            public Aircraft(double mileage)
            {
                this.Mileage = mileage;
            }
        }

        public class Car: Transport
        {
            public Car(double consumption,
                    int fuel,
                    int mileage) : base(mileage)
            {
                this.Fuel = fuel;
                this.Consumption = consumption;
            }

            public double Fuel { get; protected set; }
            public double Consumption { get; protected set; }

            public override void Move(double km)
            {
                base.Move(km);
                Fuel -= km * Consumption;
                Console.WriteLine($"Car.Move: {km}");
            }

            public void FillUp(int liters)
            {
                Fuel += liters;
            }
        }
    }
}
