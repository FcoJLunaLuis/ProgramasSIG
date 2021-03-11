using System;
using System.Collections.Generic;

namespace _21interaz3
{
    class Empleado: IComparable<Empleado>, IFormattable{
        public string Paterno{get;set;}
        public string Materno{get;set;}
        public string Nombre{get;set;}
        public double Salario{get;set;}

        public int CompareTo(Empleado emp){
            if(this.Salario < emp.Salario){
                return 1;
            }else if(this.Salario > emp.Salario){
                return -1;
            }
            return 0;
        }

        public override string ToString()=>$"{Nombre,-8} - {Salario,18:C}";

        public string ToString(string formato, IFormatProvider ifp){
            switch(formato){
                case "PMNS": return $"{Paterno,-10} - {Materno,-10} - {Nombre,-10} - {Salario:C}";
                case "NPMS": return $"{Nombre} - {Paterno,-10} - {Materno,-10} - {Salario:C}";
                case "PMN": return $"{Paterno,-10} - {Materno,-10} - {Nombre,-10}";
                default: throw new FormatException("Formato Desconocido");

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa de ejemplo del uso de interfaces integradas en C#");
            List<Empleado> emps = new List<Empleado>{
                new Empleado(){Paterno="Castañeda", Materno="Ramirez", Nombre="Carlos",Salario=1000.5},
                new Empleado(){Paterno="Diaz", Materno="Perez", Nombre="Juan",Salario=1100.24},
                new Empleado(){Paterno="Torres", Materno="Orozco", Nombre="Pedro",Salario=5110.12},
                new Empleado(){Paterno="Arias", Materno="Rivas", Nombre="Luis",Salario=1000.222},
                new Empleado(){Paterno="Carrillo", Materno="Correa", Nombre="Maria",Salario=2110.25}
            };
            Console.WriteLine("\nListado de empleados en el orden del salario ascendente, nombre, salario");
            emps.Sort();
            emps.ForEach(e=>Console.WriteLine(e.ToString()));

            Console.WriteLine("\nListado de empleados en el orden del salario descendente, nombre, salario");
            emps.Reverse();
            emps.ForEach(e=>Console.WriteLine(e.ToString()));

            Console.WriteLine("\nListado de empleados con formato personalizado, paterno, materno, nombre, salario");
            emps.ForEach(e=>Console.WriteLine(e.ToString("PMNS",System.Globalization.CultureInfo.CurrentCulture)));

            Console.WriteLine("\nListado de empleados con formato personalizado, paterno, materno, nombre");
            emps.ForEach(e=>Console.WriteLine(e.ToString("PMN",System.Globalization.CultureInfo.CurrentCulture)));
        }
    }
}
