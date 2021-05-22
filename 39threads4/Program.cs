using System;
using System.Threading;

namespace _39threads4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Thread principal ....");
            Thread t1 = new Thread(Metodo1){Name = "Thread 1"};
            Thread t2 = new Thread(Metodo2){Name = "Thread 2"};
            Thread t3 = new Thread(Metodo3){Name = "Thread 3"};
            Console.WriteLine("Terminando Thread principal ....");
        }
        static void Metodo1(){
            Console.WriteLine($"Metodo 1 iniciando usando {Thread.CurrentThread.Name}");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Metodo 1: {i}");
            }
            Console.WriteLine($"Metodo 1 terminado usando {Thread.CurrentThread.Name}");
        }

        static void Metodo2(){
            Console.WriteLine($"Metodo 2 iniciando usando {Thread.CurrentThread.Name}");
                for (int i = 1; i <=5; i++)
                {
                    if(i==3){
                        Console.WriteLine("Iniciando operacion sobre la base de datos.");
                        Thread.Sleep(10000);
                        Console.WriteLine("Operacion sobre la base de datos terminada.");
                    }
                }

            Console.WriteLine($"Metodo 2 terminando usando {Thread.CurrentThread.Name}");
        }

        static void Metodo3(){
            Console.WriteLine($"Metodo 3 iniciando usando {Thread.CurrentThread.Name}");
                for (int i = 1; i <=5; i++)
                {
                    Console.WriteLine($"Metodo 3: {i}");
                }

            Console.WriteLine($"Metodo 3 terminando usando {Thread.CurrentThread.Name}");
        }
    }
}
