using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Lesson
    {
        public static void ConstructroExamples2()
        {
            //var t1 = new DefaultConstructorExample.Transport();
            //var t2 = new DefaultConstructorExample.Transport1();

            //var fc = new ConstructorInheritanceExample.FuelCar();
            //var fc2 = new ConstructorInheritanceExample2.FuelCar();

            var fc3 = new ConstructorInheritanceExample3.FuelCar(5);
            var fc4 = new ConstructorInheritanceExample3.FuelCar(500, 5, 50);
        }

        public static class DefaultConstructorExample
        {
            public class Transport
            {
                public int Mileage { get; set; }                
            }

            public class Transport1
            {
                public int Mileage { get; set; }

                public Transport1()
                {
                }
            }
        }

        public static class UnavailableDefaultConstructorExample
        {
            public class Transport
            {
                public int Mileage { get; set; }

                public Transport(int mileage)
                {
                    this.Mileage = mileage;
                }
            }

            public class Transport2
            {
                public int Mileage { get; set; }

                public Transport2()
                {
                    this.Mileage = 0;
                }

                public Transport2(int mileage)
                {
                    this.Mileage = mileage;
                }
            }
        }

        public static class ConstructorInheritanceExample
        {
            public class Transport
            {
                public int Mileage { get; set; }

                public Transport()
                {
                    this.Mileage = 0;
                    Console.WriteLine("Transport");               
                }
            }

            public class Car: Transport
            {
                public int Engine { get; set; }

                public Car()
                {
                    this.Engine = 0;
                    Console.WriteLine("Car");
                }                
            }

            public class FuelCar : Car
            {
                public int Fuel { get; set; }

                public FuelCar()
                {
                    this.Fuel = 0;
                    Console.WriteLine("FuelCar");
                }
            }
        }

        public static class ConstructorInheritanceExample2
        {
            public class Transport
            {
                public int Mileage { get; set; }

                public Transport()
                {
                    this.Mileage = 0;
                    Console.WriteLine("Transport");
                }
            }

            public class Car : Transport
            {
                public int Engine { get; set; }

                public Car(int engine)
                {
                    this.Engine = engine;
                    Console.WriteLine("Car");
                }
            }

            public class FuelCar : Car
            {
                public int Fuel { get; set; }

                public FuelCar(): base(0)
                {
                    this.Fuel = 0;
                    Console.WriteLine("FuelCar");
                }
            }
        }

        public static class ConstructorInheritanceExample3
        {
            public class Transport
            {
                public int Mileage { get; set; }

                public Transport()
                {
                    this.Mileage = 0;
                    Console.WriteLine("Transport");
                }

                public Transport(int mileAge)
                {
                    this.Mileage = mileAge;
                    Console.WriteLine("Transport");
                }
            }

            public class Car : Transport
            {
                public int Engine { get; set; }

                public Car(int engine)
                {
                    this.Engine = engine;
                    Console.WriteLine("Car");
                }

                public Car(int mileAge, int engine): base(mileAge)
                {
                    this.Engine = engine;
                    Console.WriteLine("Car");
                }
            }

            public class FuelCar : Car
            {
                public int Fuel { get; set; }

                public FuelCar(int engine) : base(engine)
                {
                    this.Fuel = 0;
                    Console.WriteLine("FuelCar");
                }

                public FuelCar(int mileAge, int engine, int fuel) : base(mileAge, engine)
                {
                    this.Fuel = fuel;
                    Console.WriteLine("FuelCar");
                }
            }
        }

        public static class ConstructorInheritanceExample4
        {
            public class Transport
            {
                public int Mileage { get; set; }

                public Transport(): this(0)
                { 
                }

                public Transport(int mileAge)
                {
                    this.Mileage = mileAge;
                    Console.WriteLine("Transport");
                }
            }

            public class Car : Transport
            {
                public int Engine { get; set; }

                public Car(int engine): this(0, engine)
                {                  
                }

                public Car(int mileAge, int engine) : base(mileAge)
                {
                    this.Engine = engine;
                    Console.WriteLine("Car");
                }
            }

            public class FuelCar : Car
            {
                public int Fuel { get; set; }

                public FuelCar(int engine) : this(0, engine, 0)
                {                    
                }

                public FuelCar(int mileAge, int engine, int fuel) : base(mileAge, engine)
                {
                    this.Fuel = fuel;
                    Console.WriteLine("FuelCar");
                }
            }
        }
    }
}
