using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace _28linq2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] frutas = new string[]{"pera", "melon","durazno","manzana", "platano", "kiwi", "naranja", "jicama", "piña"};

            WriteLine("Frutas que inician con la letra m");
            var mfrutas = from f in frutas where f.StartsWith("m") select f;
            foreach(string f in mfrutas){
                Write($"{f} ");
            }
            
            var anfrutas = from f in frutas where f.Contains("an") select f;
            WriteLine($"Frutas que contienen las letras: an {0}", anfrutas.Count());
            foreach(string f in anfrutas){
                Write($"{f} ");
            }

            var frutasa = (from f in frutas where f.EndsWith("a") select f).ToList();
            WriteLine($"Frutas que terminan con la letra: a {0}", frutasa.Count());
            frutasa.ForEach(f => Write($"{f} "));
        }
    }
}
