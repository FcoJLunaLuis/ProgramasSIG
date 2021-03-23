using System;
using System.IO;
using static System.Console;

namespace _31streams1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] materias = new string[]{"Programacion","Calculo", "Matematicas", "Quimica", "Fisica","Seguridad","Estadistica"};
            string ruta = Path.Combine(Environment.CurrentDirectory,"materias.txt");
            Console.WriteLine("Escribir y leer datos de un stream de texto");

            StreamWriter fMaterias = File.CreateText(ruta);
            

            WriteLine("Escribir y leer datos de un stream texto\n\n");
            WriteLine("Escribir la lista de materias en el archivo {0}\n",ruta);

            foreach(string m in materias){
                WriteLine("{0}",m);
            }
            fMaterias.Close();
            if(File.Exists(ruta)){
                FileInfo fInfo = new FileInfo(ruta);
                StreamReader fLeer = File.OpenText(ruta);
                //string contenido = File.ReadAllText(ruta);

                string contenido = fLeer.ReadToEnd();
                WriteLine("Leyendo contenido en el archivo {0}", ruta);
                WriteLine("El tamaño del archivo es {0}",fInfo.Length);
                WriteLine("El contenido del archivo es: \n {0}", contenido);
            }else{
                WriteLine("El archivo no existe");
            }
            
            

            

        }
    }
}
