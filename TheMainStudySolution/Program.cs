using System;

namespace TheMainStudySolution
{
    public class Base
    {
        public virtual void Method()
        {
            Console.WriteLine("Method from base class");
        }

        public void NVMethod()
        {
            Console.WriteLine("NW Base");
        }
    }

    public class Derived : Base
    {
        public override void Method()
        {
            Console.WriteLine("Method from derived class");
        }
        public void NVMethod()
        {
            Console.WriteLine("NW Derived");
        }
    }

    public abstract class AbstractClass
    {
        public AbstractClass()
        {
            Console.WriteLine("Abstract constructor");
            Method();
        }

        public abstract void  Method();
    }

    public class ImplementAbstract: AbstractClass
    {
        public override void Method()
        {
            Console.WriteLine("Hello method");
        }
    }

    static class Extension
    {
        public static void TestExtention(this string value, string value2)
        {
            Console.WriteLine(value+" " + value2);
        }
    }







    class Program
    {
        static Program()
        {
            // Console.WriteLine("Hello, world!");

        }
        public const int x = 10;
        //static void HelloWorld()
        //{
        //    string name = string.Empty;

        //    Console.WriteLine($"Please enter your name:");
        //    name = Console.ReadLine();
        //    Console.WriteLine($"Hello, {name}!");
        //}

        static void DerivedMethod()
        {
            Derived c1 = new Derived();
            c1.Method();
            c1.NVMethod();

            Base c2 = c1;
            c2.Method();
            c2.NVMethod();

            Derived c3 = (Derived)c2;
            c3.Method();
            c3.NVMethod();
        }

        public static void GetSingleton()
        {

            var s = SingleTon.GetInstance();
            var s2 = SingleTon.GetInstance();
            var s3 = SingleTon.GetInstance();

            Console.WriteLine(s.GetHashCode());
            Console.WriteLine(s2.GetHashCode());
            Console.WriteLine(s3.GetHashCode());
        }

        static void ExpandMethod()
        {
            Base2Nested b = new Base2Nested();
            b.ExtMethod(20);
        }

        static void CallDelegate()
        {
            var instance = new ForDelegate();

            var del = new StringDelegate(instance.Method);

            var res = del("Viktor");

            Console.WriteLine(res);
        }

        delegate string StringDelegate(string name);
        delegate void StringDelegate2(string name);

        static void Main(string[] args)
        {

            //TODO: trying new VS2019 Preview
            Console.WriteLine($"Please enter your name:");
            name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
