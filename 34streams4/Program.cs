using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using static System.Console;
using System.IO;


namespace _34streams4
{
[Serializable]
    public class Empleado{
        public int Id{get;set;}
        public string Nombre{get;set;}
        public double Salario{get;set;}

        public override string ToString()=>$"Id:{Id,-3}, Nombre:{Nombre,-3}, Salario:{Salario,-3}";
    }
    class Program
    {
        static string ruta = Path.Combine(Environment.CurrentDirectory,"datos.xml");
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Escribir y leer datos en formato XML");
            List<Empleado> emps = new List<Empleado>(){
                new Empleado(){Id=1,Nombre="Juan Perez",Salario=53000},
                new Empleado(){Id=2,Nombre="Maria Lopez",Salario=63000},
                new Empleado(){Id=3,Nombre="Gerardo Jimenez",Salario=75000},
                new Empleado(){Id=4,Nombre="Claudia Reyes",Salario=40000}

            };
            WriteLine("Serializando datos ...");
            StreamWriter swEmps = File.CreateText(ruta);
            JsonSerializer jsonEmp = new JsonSerializer();
            jsonEmp.Serialize(swEmps, emps);

            WriteLine("Desserializando datos ...");
            StreamReader srEmps = File.OpenText(ruta);
            string sEmps = srEmps.ReadToEnd();
            List<Empleado> emps2 = JsonConvert.DeserializeObject<List<Empleado>>(sEmps);

        }
    }
}
