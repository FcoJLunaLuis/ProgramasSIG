using System;
using static System.Console;
using System.IO;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;

namespace _30archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Trabajando con informacion del sistema, archivos y rutas");
            //UnidadDisco();
            //SistemaArchivos();
            //Directorios();
        }

        static void Archivos(){
            WriteLine("Trabajando con Archivos:");
            var dir = Combine(GetCurrentDirectory(),"datos","archivo");

            string archTexto = Combine(dir,"notas.txt");
            string archRespaldo = Combine(dir,"notas.bak");

            //Revisar si existe la ruta donde estan los archivos
            if(!Exists(dir)){
                CreateDirectory(dir);
            }

            //Revisar si existe el archivo de texto
            WriteLine($"Existe el archivo de texto ? {File.Exists(archTexto)}");
            WriteLine("Creando archivo de texto...");
            StreamWriter txt = File.CreateText(archTexto);
            txt.WriteLine("Saludos desde un archivo de txto creado en C#");
            txt.Close();
            WriteLine($"Existe el archivo de texto ? {File.Exists(archTexto)}");
            //Crear una copia del archivo
            File.Copy(sourceFileName:archRespaldo, destFileName:archRespaldo, overwrite:true);
            WriteLine($"Existe el archivo de respaldo? ? {File.Exists(archRespaldo)}");
            WriteLine("Confirma que el archivo existe, luego presiona <Enter>");
            ReadLine();
            //Borrar el archivo
            File.Delete(archRespaldo);
            WriteLine($"Existe el archivo de respaldo? ? {File.Exists(archRespaldo)}");
            //Leer archivo de texto
            WriteLine($"Leyendo contenido del archivo de texto: {archTexto}");
            StreamReader read = File.OpenText(archTexto);
            WriteLine(read.ReadToEnd());
            read.Close();

            //Info del archivo
            var info = new FileInfo(archTexto);
            WriteLine("Informacion del archivo");
            WriteLine($"El archivo {archTexto}");
            WriteLine($"Nombre del archivo: {GetFileName(archTexto)}, Extencion: {GetExtension(archTexto)}");
            WriteLine($"Contiene {info.Length} bytes");
            WriteLine($"Ultima vez que se acceso: {info.LastAccessTime}");
            WriteLine($"Es de solo lectura ? {info.IsReadOnly}");
            WriteLine($"Fecha de creacion: {info.CreationTime}");

            //Cambiar nombre archivo
            WriteLine("Informacion del archivo");
            string nvoNombre = Combine(dir,"apuntes.txt");
            File.Move(sourceFileName:archTexto, nvoNombre, overwrite:true);
            WriteLine($"Existe el archivo renombrado ? {File.Exists(nvoNombre)}");

        }
        static void Directorios(){
            WriteLine("Trabajando con Directorios:");
            var nvaCarpeta = Combine(GetCurrentDirectory(),"datos","Codigofuente");
            WriteLine($"Trabajando con: {nvaCarpeta}");
            //Revisar si existe
            WriteLine($"El directorio ya existe ? {Exists(nvaCarpeta)}");
            //crear directorio
            WriteLine("Creando directorio");
            WriteLine($"El directorio ya existe ? {Exists(nvaCarpeta)}");
            WriteLine("Confirma que el directorio existe, luego presiona <Enter>");
            ReadLine();
            //Borar directorio
            WriteLine("Borrando el directiorio y su contenido...");
            Delete(nvaCarpeta,recursive:true);
            WriteLine($"El directorio ya existe ? {Exists(nvaCarpeta)}");
        }

        static void UnidadDisco(){
            WriteLine("\n");
            WriteLine("{0, -30}{1,-10}{2,-7} {3,18:N0}","Nombre","Tipo","Formato","Tamaño","Espacio Libre");
            foreach(DriveInfo drive in DriveInfo.GetDrives()){
                if(drive.IsReady){
                    WriteLine("{0, -30}{1,-10}{2,-7} {3,18:N0}",drive.Name,drive.DriveType,drive.DriveFormat,drive.TotalSize);
                }else{
                    WriteLine("{0, -30}{1,-10}",drive.Name, drive.DriveType);
                }
                
            }
        }

        static void SistemaArchivos(){
            WriteLine("\nInformacion del Sistema");
            WriteLine("{0,-33}{1}","Separador de ruta",PathSeparator);
            WriteLine("{0,-33}{1}","Separador de directorios",DirectorySeparatorChar);
            WriteLine("{0,-33}{1}","Directorio actual", GetCurrentDirectory());
            WriteLine("{0,-33}{1}","Directorio del sistema", SystemDirectory);
            WriteLine("{0,-33}{1}","Directorio temporal", GetTempPath());
            WriteLine("{0,-33}{1}","Directorio del sistema", GetFolderPath(SpecialFolder.System));
            WriteLine("{0,-33}{1}","Directorio mis documentos", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33}{1}","Directorio datos de aplicacion", GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33}{1}","Directorio personal", GetFolderPath(SpecialFolder.Personal));
        }
    }
}
