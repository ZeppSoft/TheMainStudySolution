using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CommonLib
{
    public static class Threads
    {
        public static void Function()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine();

            Console.WriteLine($"Thread with id {Thread.CurrentThread.ManagedThreadId} completed its work successufuly!");
        }
        public static void JoinTest()
        {
            Console.WriteLine($"Main thread with id {Thread.CurrentThread.ManagedThreadId} started.");

            Thread thread = new Thread(new ThreadStart(Function));
            thread.Start();

            thread.Join();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.Write("-");
            }
            Console.WriteLine();

            Console.WriteLine($"Main thread with id {Thread.CurrentThread.ManagedThreadId} completed its work successufuly!");
        }
        [ThreadStatic]//Now for each thread this field is separated
        static int StaticField = 10;

        public static  void  ChangeStaticField()
        {
            Console.WriteLine($"Thread with id {Thread.CurrentThread.ManagedThreadId} reads StaticField {StaticField} ");
            //StaticField+=StaticField + 1;
            ++StaticField;
            Console.WriteLine($"Thread with id {Thread.CurrentThread.ManagedThreadId} changed StaticField to {StaticField} ");

        }


        public static void StaticFieldAccess()
        {
            Thread t1 = new Thread(new ThreadStart(ChangeStaticField));
            Thread t2 = new Thread(new ThreadStart(ChangeStaticField));
            Thread t3 = new Thread(new ThreadStart(ChangeStaticField));
            Thread t4 = new Thread(new ThreadStart(ChangeStaticField));

            t1.Start();
           
            t2.Start();
            t3.Start();
            t4.Start();



        }
    }
}
