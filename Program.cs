using TesteDeLogica.Services;
using System;

namespace TesteDeLogica
{
    class Program
    {
        static void Main(string[] args)
        {
            Network networkFirstTest = new Network(10);

            networkFirstTest.Connect(2, 4);
            networkFirstTest.Query(2, 4);
            networkFirstTest.Connect(2, 8);
            networkFirstTest.Query(2, 8);
            networkFirstTest.Connect(2, 6);
            networkFirstTest.Query(2, 6);
            networkFirstTest.Connect(3, 1);
            networkFirstTest.Query(3, 1);
            networkFirstTest.Connect(3, 2);
            networkFirstTest.Query(3, 2);
            networkFirstTest.Query(1, 8);
            networkFirstTest.Query(5, 3);
            networkFirstTest.ShowAllElements();

            Network networkSecondTest = new Network(8);

            networkSecondTest.Connect(1, 6);
            networkSecondTest.Query(1, 6);
            networkSecondTest.Connect(1, 2);
            networkSecondTest.Query(1, 2);
            networkSecondTest.Connect(2, 4);
            networkSecondTest.Query(2, 4);
            networkSecondTest.Connect(5, 7);
            networkSecondTest.Query(5, 7);
            networkSecondTest.Connect(8, 3);
            networkSecondTest.Query(3, 8);
            networkSecondTest.Query(5, 3);
            networkSecondTest.Query(8, 1);
            networkSecondTest.ShowAllElements();
        }
    }
}
