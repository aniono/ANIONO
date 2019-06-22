using AlgorithmsAndDataStructures;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var combination = new Combination();
            var result = combination.Generate(5, 9);

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
