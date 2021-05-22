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

            foreach(var c in categorias){
                db.Categorias.Add(c);
            }
            db.SaveChanges();
        }
    }
}
