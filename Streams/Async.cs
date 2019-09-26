using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CommonLib
{
    [Obsolete]
    public static class Async
    {
        static int Sum(int x, int y)
        {
            Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} now started");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} now ended");

            return x + y;
        }
        public static void TryIAsyncAwait()
        {
            Console.WriteLine($"Main Thread #{Thread.CurrentThread.ManagedThreadId} now started");

            Func<int, int, int> myFunc = new Func<int, int, int>(Sum);

            IAsyncResult result = myFunc.BeginInvoke(1, 3, null, null);

            int sum = myFunc.EndInvoke(result);

            Console.WriteLine($"Sum = {sum}");

            Console.WriteLine($"Main Thread #{Thread.CurrentThread.ManagedThreadId} now ended");

        }
    }
}
