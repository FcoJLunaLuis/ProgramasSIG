using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;
namespace _27linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[]{10,25,-1,10,0,20,22,65,800,-4,20,20,1000,2000,-233};
            WriteLine("Listado de numeros pares de manera convencional");
            for(int i=0; i<numeros.Length;i++){
                if( (numeros[i]%2) == 0 ){
                    WriteLine(numeros[i]);
                }
            }

            //imprimir pares usando linq
            //1. Crear consulta pára obtener numeros pares
            IEnumerable<int> qrypares = from num in numeros where (num%2) == 0 select num;
            //2. Ejecutar consulta linq
            WriteLine("Listado de numeros pares usando consulta linq");
            foreach(int n in qrypares){
                Write($"{n} ");
            }

            WriteLine("Listado de numeros impares usando consulta linq");
            var qryimpares = from num in numeros where (num%2) != 0 select num;
            foreach(int n in qryimpares){
                Write($"{n} ");
            }

            WriteLine("Listado de numeros entre 20 y 1000 usando linq y el resultado en formato de lista");
            var mayores = (from num in numeros where (num >=20 && num <=1000 ) && num%2 == 0 select num).ToList();
            mayores.ForEach(nameof=> Write($"{n} "));

        }

    }
}
