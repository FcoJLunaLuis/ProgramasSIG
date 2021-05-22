using System;
using System.Threading;

namespace _36threads1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name="Thread Principal";
            Thread t1 = new Thread(imprimir);
            Thread t2 = new Thread(imprimir);

            t1.Start();
            t2.Start();
            imprimir();

            Console.WriteLine("Saludos desde Main, se ha terminado la ejecucion");
        }
        static void imprimir(){
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine($"Imprime {i} desde {Thread.CurrentThread.Name}");
        }
    }
    }

    
}
