﻿using System;

namespace _25delegados4
{
    
    public delegate T Suma<T>(T p1, T p2);
        class Program
    {
        static void Main(string[] args)
        {
            Suma<int> d1 = Sumar;
            Suma<string> d2 = Concatena;
            //Suma<string> d3 = NoSePuede;
            Console.WriteLine($"La suma es {d1(10,20)}");
            Console.WriteLine($"La concatenacion es {d2("Cepillin"," Se nos fue")}");
            Console.WriteLine($"Diferents tipos de parametros: {NoSePuede("Aun nos queda chabelo", 10)}");
        }

        public static int Sumar(int a, int b) => a+b;
        public static string Concatena(string a, string b) => a+b;

        public static string NoSePuede(string a, int b) => $"{a} - {b.ToString()}";
    }
}
