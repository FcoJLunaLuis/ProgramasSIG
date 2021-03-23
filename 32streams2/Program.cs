using System;
using System.IO;
using static System.Console;

namespace _32streams2
{
    class Program
    {
        static string ruta = Path.Combine(Environment.CurrentDirectory,"opciones.bin");
        static void Main(string[] args)
        {
            Console.WriteLine("Lectura de datos en un archivo binario");
            Escribir();
        }

        static void Escribir(){
            WriteLine("Escribiendo datos en un archivo en formato binario");
            BinaryWriter bwOps = new BinaryWriter(File.Open(ruta,FileMode.Create));
            bwOps.Write(1.25f);
            bwOps.Write(@"c:\Temp");
            bwOps.Write(10);
            bwOps.Write(true);
            bwOps.Close();
        }

        static void Leer(){
            float radio;
            string ruta;
            int periodo;
            bool estado;
            WriteLine("Leyendo datos del archivo binario {0}", ruta);
            BinaryReader brOps = new BinaryReader (File.Open(ruta,FileMode.Open));
            radio = brOps.ReadSingle();
            ruta = brOps.ReadString();
            periodo = brOps.ReadInt32();
            estado = brOps.ReadBoolean();

            WriteLine("\nRadio      ={0}",radio);
            WriteLine("\nRuta       ={0}",ruta);
            WriteLine("\nPeriodo    ={0}",periodo);
            WriteLine("\nEstado     ={0}",estado);
            brOps.Close();
        }
    }
}
