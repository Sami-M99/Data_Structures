using System;

namespace Recursion_Factorial_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number : ");

            int input = int.Parse(Console.ReadLine());
            var result = Math.FactorialRecursion(input);

            Console.WriteLine($"{input}! = {result}");
        }
    }

}
