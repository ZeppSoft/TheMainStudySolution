using System;

namespace Recursion
{
    class Program
    {
        public static void Recursion(int number)
        {
            number--;

            Console.WriteLine($"First part of app, number = {number}");

            if (number > 0)
                Recursion(number);

            Console.WriteLine($"Second part of app, number = {number}");
        }
        static void Main(string[] args)
        {
            Recursion(2);
        }
    }
}
