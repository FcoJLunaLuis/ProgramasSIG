﻿//Programa que calcula el area de un ciruclo
using System;

namespace _2areacirculo
{
    class Program
    {
        static void Main(string[] args)
        {
            double radio, area;
            
            Console.WriteLine("Calculando el area de un circulo\n");
            Console.WriteLine("Dame el radio");
            radio = float.Parse( Console.ReadLine() );
            area = Math.PI * Math.Pow(radio,2);
            Console.WriteLine("El area del ciruclo es {0}",area);
        }
    }
}
