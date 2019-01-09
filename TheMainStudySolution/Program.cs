using System;

namespace TheMainStudySolution
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;

            Console.WriteLine($"Please enter your name:");
            name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
