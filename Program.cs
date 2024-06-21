using TesteDeLogica.Services;
using System;

namespace TesteDeLogica
{
    class Program
    {
        static void Main(string[] args)
        {
            Network networkFirstIntance = new Network(10);

            networkFirstIntance.Connect(2, 4);
            networkFirstIntance.Query(2, 4);
            networkFirstIntance.Connect(2, 8);
            networkFirstIntance.Query(2, 8);
            networkFirstIntance.Connect(2, 6);
            networkFirstIntance.Query(2, 6);
            networkFirstIntance.Connect(3, 1);
            networkFirstIntance.Query(3, 1);
            networkFirstIntance.Connect(3, 2);
            networkFirstIntance.Query(3, 2);
            networkFirstIntance.ShowAllElements();

            Network networkSecondIntance = new Network(8);

            networkSecondIntance.Connect(1, 6);
            networkSecondIntance.Query(1, 6);
            networkSecondIntance.Connect(1, 2);
            networkSecondIntance.Query(1, 2);
            networkSecondIntance.Connect(2, 4);
            networkSecondIntance.Query(2, 4);
            networkSecondIntance.Connect(5, 7);
            networkSecondIntance.Query(5, 7);
            networkSecondIntance.ShowAllElements();
        }
    }
}
