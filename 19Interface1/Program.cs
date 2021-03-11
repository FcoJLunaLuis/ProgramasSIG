using System;

namespace _19Interface1
{
    class Program
    {
        public interface IAnimal{
            string Nombre{get;set;}
            void Llorar();
        }

        class Perro : IAnimal {
            public Perro(string nombre) => Nombre = nombre;
            public string Nombre{get;set;}

            public void Llorar()=> Console.WriteLine("Woof Woof");
            
        }

        class Gato : IAnimal{
            public Gato(string nombre, string raza) => (Nombre , Raza) = (nombre ,raza);
            public string Nombre{get;set;}
            public string Raza{get;set;}

            public void Llorar()=> Console.WriteLine("Miau Miau");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Primer ejemplo interfaces");
            Perro miperro = new Perro("El Cap");
            Console.WriteLine($"El perro {miperro.Nombre} llora asi:");
            miperro.Llorar();

            Gato migato = new Gato("El Mishi","Siames");
            Console.WriteLine($"\nEl gato {migato.Nombre} de raza {migato.Raza} llora asi:");
            migato.Llorar();
        }
    }
}
