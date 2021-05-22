using System;
using HtmlAgilityPack;
using System.IO;
using static System.Console;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace _41websraping2
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseURL = "http://www.uaz.edu.mx";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(baseURL);
            HashSet<Uri> lista = new HashSet<Uri>();
            string ruta = Path.Combine( Environment.CurrentDirectory,"imgs");

            var nodos = doc.DocumentNode.SelectNodes("//img/@src").Select(v=>v.Attributes["src"].Value).Where(v=> v is not null);

            foreach(var n in nodos){
                Uri uri = new Uri(n, UriKind.RelativeOrAbsolute);
                if(!uri.IsAbsoluteUri) uri = new Uri(new Uri(baseURL), uri);
                lista.Add(uri);

            }
            if(Directory.Exists(ruta) )
                Directory.Delete(ruta,true);
            Directory.CreateDirectory(ruta);
            WebClient wc = new WebClient();
            WriteLine("\nDescargando Archivos...");
            foreach (var uri in lista){
                string nomarch = Path.GetFileName(uri.LocalPath);
                string rutades = Path.Combine(ruta,nomarch);
                wc.DownloadFile(uri,rutades);
                WriteLine($"{uri.ToString()} - {rutades}");
            }
        }   
    }
}
