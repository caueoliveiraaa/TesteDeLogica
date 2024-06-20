using TesteDeLogica.Services;

namespace TesteDeLogica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program has started!");

            var network = new Network(8);

            Console.WriteLine("Program has ended!");
        }
    }
}
