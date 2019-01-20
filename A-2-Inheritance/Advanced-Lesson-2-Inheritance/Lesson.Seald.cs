using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Lesson
    {
        public sealed class MySealedClass
        {
            public int field1;
            public int field2;
        }

        /*public class MyDerivedFromSealedClass: MySealedClass
        {
            public string field3;
        }*/


        public abstract class MyBaseClass1
        {
            public virtual void Method()
            {
                Console.WriteLine("MyBaseClass1");
            }            
        }

        public class MyDerivedClass1: MyBaseClass1
        {
            public sealed override void Method()
            {
                Console.WriteLine("MyDerivedClass1");
            }
        }

        public class MyDerivedDerivedClass1 : MyDerivedClass1
        {
            /*public override void Method()
            {
                Console.WriteLine("MyDerivedDerivedClass1");
            }*/
        }
    }
}
