using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using static System.Console;
using System.IO;

namespace _33streams3
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

            emps.ForEach(e=> WriteLine(e.ToString()));
            WriteLine("Serializar datos de empleados ...");
            FileStream fsEmps = File.Open(ruta, FileMode.Create);
            XmlSerializer xmlEmps = new XmlSerializer(typeof(List<Empleado>));
            xmlEmps.Serialize(fsEmps, emps);
            fsEmps.Close();

            WriteLine("Desserializar datos en el archivo {0}",ruta);
            FileStream fsEmps2 = File.Open(ruta, FileMode.Open);
            XmlSerializer xmlEmps2 = new XmlSerializer(typeof(List<Empleado>));
            List<Empleado> emps2 = (List<Empleado>) xmlEmps2.Deserialize(fsEmps2);
        }
    }
}
