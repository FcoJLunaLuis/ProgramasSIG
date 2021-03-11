using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace _29linq3
{
    class Estudiante{
        public int Matricula{get;set;}
        public string Nombre{get;set;}
        public string Domicilio{get;set;}
        public List<float> Califs{get; set;}

        public override string ToString() => 
        $"Matricula: {Matricula}, Nombre: {Nombre}, Domicilio: {Domicilio}, {string.Join(",",Califs)}";
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Estudiante> estudiantes = new List<Estudiante>(){
                new Estudiante{Matricula=111, Nombre = "Juan Perez",    Domicilio = "Calle principal 123, Zacatecas",   Califs = new List<float>{97,92,81,60}},
                new Estudiante{Matricula=222, Nombre = "Maria Lopez",   Domicilio = "Principal 126, Fresnillo",         Califs = new List<float>{75,84,91,39}},
                new Estudiante{Matricula=111, Nombre = "Rodrigo Mata",  Domicilio = "Av Mexico 42, Rio Grande",         Califs = new List<float>{88,94,65,91}},
                new Estudiante{Matricula=444, Nombre = "Miguel Mejia",  Domicilio = "5 de Mayo 23, Zacatecas",          Califs = new List<float>{70,90,60,40}},
                new Estudiante{Matricula=22, Nombre = "David Monreal", Domicilio = "La loma 666, Fresnillo",           Califs = new List<float>{60,60,60,40}},
                new Estudiante{Matricula=444, Nombre = "Miguel Mejia",  Domicilio = "5 de Mayo 23, Zacatecas",          Califs = new List<float>{70,90,60,40}}
            };

            WriteLine("Todos los estudiantes tal cual estan almacenados en la lista");
            estudiantes.ForEach(e=>WriteLine(e.ToString()));

            var estzac = (from e in estudiantes where e.Domicilio.Contains("Zacatecas") select e).ToList();
            WriteLine($"Estudiantes que son de Zacatecas {0}", estzac.Count());
            estzac.ForEach(e => WriteLine(e.ToString()));

            var estprom = (from e in estudiantes where e.Califs.Average()>=70 orderby e.Nombre select e).ToList();
            WriteLine($"Estudiantes con promedio mayor a 7 ordenados  de forma decendente por nombre {0}", estprom.Count());
            estprom.ForEach(e => WriteLine(e.ToString()+" Promedio: "+e.Califs.Average()));

            var estprom2 = (from e in estudiantes select $"nombre = {e.Nombre} prom={e.Califs.Average()}").ToList();
            WriteLine("Lista de alumnos y sus promedios");
            estprom2.ForEach(e => WriteLine(e));

            var gpoest = (from e in estudiantes group e by e.Matricula);
            WriteLine("Estudiantes agrupados por Matricula");
            foreach(var gpo in gpoest){
                WriteLine(gpo.Key);
                foreach(var est in gpo){
                    WriteLine(est.ToString());
                }
            }

        }
    }
}
