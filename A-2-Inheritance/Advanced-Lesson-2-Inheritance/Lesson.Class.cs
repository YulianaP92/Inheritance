using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Lesson
    {

        class MyBaseClass
        {
            // virtual auto-implemented property. Overrides can only
            // provide specialized behavior if they implement get and set accessors.
            public virtual string Name { get; set; }

            // ordinary virtual property with backing field
            private int num;

            public virtual int Number
            {
                get { return num; }
                set { num = value; }
            }
        }

        class MyDerivedClass : MyBaseClass
        {
            private string name;

            // Override auto-implemented property with ordinary property
            // to provide specialized accessor behavior.
            public override string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    if (value != String.Empty)
                    {
                        name = value;
                    }
                    else
                    {
                        name = "Unknown";
                    }
                }
            }
        }

        class MyBaseClass2
        {
            protected Dictionary<string, string> arr =
                new Dictionary<string, string>();

            public virtual string this[string key]
            {
                get { return arr[key]; }
                set { arr[key] = value; }
            }
        }

        class MyDerivedClass2 : MyBaseClass2
        {

            public override string this[string key]
            {
                get
                {
                    return base[key.Trim()]; ;
                }
                set
                {
                    base[key.Trim()] = value;
                }
            }
        }

        public abstract class Base1
        {
            public abstract int Z { get; set; }
        }

        public class Derived1 : Base1
        {
            private int _z;
            public override int Z
            {
                get { return 3; }
                set { _z = value; }
            }
        }

        public abstract class Base3
        {
            public abstract string this[string key] { get; set; }
        }

        public class Derived3 : Base3
        {
            protected Dictionary<string, string> arr = new Dictionary<string, string>();

            public override string this[string key]
            {
                get { return arr[key]; }
                set { arr[key] = value; }
            }
        }
    }
}
