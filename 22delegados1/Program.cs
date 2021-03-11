using System;

namespace _22delegados
{
    public delegate void MiDelegado(string msj);
    public class Program{
        static void Main(string[] args){
            MiDelegado d; //Creo una instancia del delegado

            d = Mensaje.Mensaje1;
            d("Juan");

            d= Mensaje.Mensaje2;
            d("Jose");

            d = (string msj) => Console.WriteLine($"{msj} - paga todo que no pare la fiesta");
        }
    
    }
    public class Mensaje{
        public static void Mensaje1(string msj)  => Console.WriteLine($"{msj} - lleva el pastel");
        public static void Mensaje2(string msj)  => Console.WriteLine($"{msj} - Fue culpable, se cancela la fiesta");
    }
}

