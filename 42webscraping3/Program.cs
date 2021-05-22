//www.imdb.com/
//www.imdb.com/chart/top
//dotnet add package HtmlAgilityPack --version 1.11.32
//dotnet add package Newtonsoft.Json --version 13.0.1

using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.IO;
using Newtonsoft.Json;

namespace _42webscraping3
{
    class Pelicula{
        public int Posicion {get;set;}
        public string Titulo {get;set;}
        public string Url {get;set;}
        public float rating  {get;set;}
        public int Liberacion {get;set;}
        public string Director {get;set;}

        public override string ToString()=> $"Posicion: {Posicion}\nTitulo: {Titulo}\nUrl: {Url}\nRating: {rating}\nLiberacion: {Liberacion}\nDirector: {Director}";
    }
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "www.imdb.com/";
            string iniUtil = "www.imdb.com/chart/top";
            List<Pelicula> dp = new List<Pelicula>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(iniUtil);

            var tp = doc.DocumentNode.SelectNodes("//div[@id='main']//table//tr");

            foreach(var l in tp){
                Pelicula p = new Pelicula();
                p.Posicion = int.Parse(l.SelectNodes(".//td[@class='posterColumn']//span[@name='rk']").Select(a=>a.Attributes["data-value"].Value).First()) ;
                p.Titulo = l.SelectSingleNode(".//td[@class='titleColumn']//a[@href]").InnerHtml;
                p.rating = float.Parse(l.SelectSingleNode(".//[@class='ratingColum imdbRating']//strong").InnerHtml);
                p.Url = l.SelectSingleNode(".//td[@class='titleColum']//a[@href]").Attributes["href"].Value;
                HtmlDocument doc2 = web.Load(p.Url);
                p.Liberacion = int.Parse(doc2.DocumentNode.SelectSingleNode(".//h1//spam//a").InnerText);
                p.Director = doc2.DocumentNode.SelectSingleNode("//div[@class='credit_summary_item']//a[@href]").InnerHtml;
                WriteLine(p.ToString());
                dp.Add(p);
            }
            //WriteLine(l.InnerHtml);
            WriteLine("\n");
            string ruta = Path.Combine(Environment.CurrentDirectory,"peliculas");
            StreamWriter fs = File.CreateText(ruta + ".json");
            JsonSerializer  json =  new JsonSerializer();
            json.Serialize(fs,dp);
            fs.Close();
        }
    }
}
