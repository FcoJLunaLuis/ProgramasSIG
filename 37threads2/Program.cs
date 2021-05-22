using System;
using System.Threading;
namespace _37threads2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 5; i++)
            {
                Thread t = new Thread(Imprime);
                t.Start();
            }
        }
        static void Imprime(object o){
            int s = 0;
            for (int i = 0; i <= 500; i++)
            {
                Console.WriteLine($"Imprime en el thread {o} / {i}");
                s += i;
                Console.WriteLine($"la suma del thread {o} = {s}");
            }
        }
    }
}
