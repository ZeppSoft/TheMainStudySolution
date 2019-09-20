using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib
{
    public class Class1
    {
        public void Method()
        {
            Console.WriteLine("Class1");
        }
    }

    public class Class2
    {
        public void Method()
        {
            Console.WriteLine("Class2");
        }
    }
    public class Class3
    {
        //public void Method2() //This will break code execution (ad hoc polymorphysm)
        public void Method()
        {
            Console.WriteLine("Class3");
        }
    }

    public class Base
    {
        public virtual void Do()
        {
            Console.WriteLine("1");
        }
    }

    public class Derived : Base
    {
        public override void Do()
        //public new void Do() //Polymorphysm didn`t work

        {
            Console.WriteLine(2);
        }
    }
    public static class Polymorphysm
    {
        public static void  TryVersion()
        {
            Base instance = new Derived();

            instance.Do();
        }

        public static void TryDynamic()
        {
            dynamic instance = new Class1();
            instance.Method();

            instance = new Class2();
            instance.Method();

            instance = new Class3();
            instance.Method();
        }
    }
}
