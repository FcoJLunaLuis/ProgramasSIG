namespace _44webscrapping5
{
    public class Libro
    {
        public int LibroId {get;set;}
        public string Url {get;set;}
        public string UrlImagen {get;set;}
        public string Titulo {get;set;}
        public decimal Precio {get;set;}
        public int CategoriaId {get;set;}

        public override string ToString() => $"ID: {LibroId}\nUrl: {Url}\nUrl imagen: {UrlImagen}\nTitulo: {Titulo}\nPrecio: {Precio}\nCategoria ID: {CategoriaId}";
    }
}