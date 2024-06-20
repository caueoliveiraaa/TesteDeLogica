using TesteDeLogica.Services;
using System;

namespace TesteDeLogica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program has started.");

            var network = new Network(10);

            Console.WriteLine("Program has ended.");
        }
    }
}
