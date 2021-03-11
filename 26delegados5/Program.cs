//Ejemplo de un delegado como parametro a un metodo o funcion
using System;

namespace _26delegados5
{
    public delegate void MiDelegado(string msj);
    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d1,d2;
            d1 = A.MetodoA;
            d2 = B.MetodoB;
            d1("Hola Mundo");
            d2("Hola Mundo");

            Invocar(d1);
            Invocar(d2);
        }
        static void Invocar(MiDelegado d){
            d("Llamando desde el invocador");
        }
    }
    
    public class A{
        public static void MetodoA(string msj)=> Console.WriteLine($"Llamando al metodo A de la clase A");
    }
    public class B{
        public static void MetodoB(string msj)=> Console.WriteLine($"Llamando al metodo B de la clase B");
    }
}
