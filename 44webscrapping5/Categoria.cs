using System.Collections.Generic;
namespace _44webscrapping5
{
    public class Categoria
    {
        public int CategoriaID {get;set;}
        public string Nombre {get;set;}
        public string Url {get;set;}

        public List<Libro> Libros {get;set;}

        public override string ToString() => $"Id:{CategoriaID}\nNombre: {Nombre}\nUrl: {Url}";
    }
}