using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace _44webscrapping5
{
    class Program
    {
        static void Main(string[] args)
        {
            if(){

            }
        }

        static void scrapping(){
            ChromeOptions opciones = new ChromeOptions();
            opciones.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(opciones);
            driver.Url= "http://books.toscrape.com/";
            DataContenxtcs db = new DataContenxtcs();

            var ligasCategoria = driver.FindElements(By.XPath("/html/body/div/div/div/aside/div/[2]/ul/li/ul/li/a"));
            List<Categoria> categorias = new List<Categoria>();
            foreach(var l in ligasCategoria){
                Categoria categoria = new Categoria();
                var url = l.GetAttribute("href");
                var i = url.LastIndexOf("_")+1;
                var f = url.LastIndexOf("/")-i;
                categoria.CategoriaID = int.Parse(url.Substring(i,f));
                categoria.Nombre = l.Text;
                categoria.Url = url;
                categorias.Add(categoria);
            }
            //hacemos scrapping de los libros dentro de cada categoria
            List<Libro> libros = new List<Libro>();
            List<string> urlpagina = new List<string>();
            for(int i = 1; i<=50;i++){
                urlpagina.Add($"http://books.toscrape.com/catalogue/page-{i}.html");
            }
            foreach (var urlp in urlpagina)
            {
                driver.Navigate().GoToUrl(urlp);
                List<string> urlLibro = new List<string>();
                var ligaLibro = driver.FindElements(By.XPath("/html/body/div/div/div/div/section/div[2]/ol/li/[1]/article/h3/a"));
                foreach(var l in ligaLibro) urlLibro.Add(l.GetAttribute("href"));
                foreach(var url in urlLibro){
                    driver.Navigate().GoToUrl(url);
                    Libro libro = new Libro();
                    libro.Url = url;
                    libro.UrlImagen = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/article/div[1]/div[1]/div/div/div/div/img")).GetAttribute("src");
                    libro.Titulo = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/article/div[1]/div[2]/h1")).Text;
                    libro.Precio = decimal.Parse(driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/article/div[1]/div[2]/p[1]")).Text.Replace('£',' '));
                    var catidliga = driver.FindElement(By.XPath("/html/body/div/div/ul/li[3]/a")).GetAttribute("href");
                    var i = catidliga.LastIndexOf("_")+1;
                    var f = catidliga.LastIndexOf("/")-1;
                    libro.CategoriaId = int.Parse(catidliga.Substring(i,f));
                    libros.Add(libro);
                }

            }


            foreach(var c in categorias){
                db.Categorias.Add(c);
            }
            foreach(var l in libros){
                db.Libros.Add(l);
            }
            db.SaveChanges();
        }

        
        
    }
}
