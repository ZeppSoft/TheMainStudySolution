using Collections;
using System;
using CommonLib;

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
            #region Synchronization
            //CommonLib.Sync.TrySemaphore();
            //CommonLib.Sync.TryMutex();
            //CommonLib.Sync.TryVolatile();
            #endregion
            #region Threads

            //CommonLib.Threads.StaticFieldAccess();
            // CommonLib.Threads.JoinTest();


            #endregion
            #region Polymprphysm
            // CommonLib.Polymorphysm.TryDynamic();
            //CommonLib.Polymorphysm.TryVersion();

            #endregion
            #region Serialization
            // CommonLib.Serialization.Try2SerializeBit();
            // CommonLib.Serialization.Try2DeSerializeBit();

            // CommonLib.Serialization.Try2SerializeXML();
            // CommonLib.Serialization.Try2DeSerializeXML();
            #endregion
            #region Attributes
            //CommonLib.Attribute.TryAttribute();
            #endregion
            #region Reflection

            //CommonLib.Reflection.GetPrivateField();

            #endregion
            #region XML
            //CommonLib.TryXML.ReadXPath();
            //CommonLib.TryXML.ReadXMLNode();
            //CommonLib.TryXML.ReadXML();
            #endregion
            #region Streams


            //CommonLib.Streams.TryReadFile();
            //Streams.Streams.TryCreateFile();

            //Streams.Streams.TryDirectory();


            #endregion
            #region Collections
            //UserCollectionMod.TryIEqualityComparerHashTable();
            //UserCollectionMod.TryDuplicateHashTable();

            //UserCollectionMod.TryHashTable();

            //GetUserCollection();
            #endregion

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        #region Collections
        public static void GetUserCollection()
        {
            var collection = new UserCollectionMod(); //UserCollection();
          

            collection[0] = new Element(1, 2);
            collection[1] = new Element(3, 4);
            collection[2] = new Element(5, 6);
            collection[3] = new Element(7, 8);

            foreach (Element el in collection)
            {
                Console.WriteLine($"Element A = {el.FieldA} , Element B = {el.FieldB}" );
            }


            Console.WriteLine("Now using enumerator instead of foreach");

            var enumerator = collection.GetEnumerator();

            while(enumerator.MoveNext())
            {
                Element el = enumerator.Current as Element;

                Console.WriteLine($"Element A = {el?.FieldA} , Element B = {el?.FieldB}");
            }

            

        }
        #endregion
    }
}
