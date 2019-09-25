using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CommonLib
{
    public static class Sync
    {
        static volatile bool stop;

        //static bool stop;
        static void Function()
        {
            int x = 0;

            while (!stop)
            {
                x++;
            }

            Console.WriteLine($"Thread was stopped with x = {x}");

        }
        public static void TryVolatile()
        {
            Thread thread = new Thread(Function);
            thread.Start();
            Thread.Sleep(2000);

            stop = true;
            Console.WriteLine("Main is waiting for second thread");
            thread.Join();
        }

        static Mutex mutex = new Mutex(false, "MyMutex");
        static void MutexFunction()
        {
            mutex.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} entered secret zone.");
            Thread.Sleep(2000);
            mutex.ReleaseMutex();
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} exited secret zone.");


        }

        public static void TryMutex()
        {
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(MutexFunction);
                threads[i].Name = i.ToString();
                threads[i].Start();
            }

        }
        static Semaphore semaphore = new Semaphore(4, 4, "MySemaphore");
        static void SemaphoreFunction()
        {
            semaphore.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} entered secret zone.");
            Thread.Sleep(2000);
            semaphore.Release();
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} exited secret zone.");


        }
        public static void TrySemaphore()
        {
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(SemaphoreFunction);
                threads[i].Name = i.ToString();
                threads[i].Start();
            }

        }
    }
}
