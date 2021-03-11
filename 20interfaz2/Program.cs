using System;

namespace _20interfaz2
{

    public interface IAnimales{
        void Multicelular();
        void SangreCaliente();
    }

    public interface ICanino{
        void Correr();
        void CuatroPatas();
    }

    public interface IAve{
        void Volar();
        void DosPatas();
    }
    public class Organismo{

        public Organismo(string nombre) => Nombre = nombre;

        public string Nombre {get; set;}
        public void Respiracion() => Console.WriteLine("Respirando..");
        public void Movimiento() => Console.WriteLine("Moviendose..");
        public void Crecimiento() => Console.WriteLine("Creciendo..");
    }

    public class Perro : Organismo, ICanino{
        public Perro (string nombre) : base(nombre){}
        public void Multicelular()=>Console.WriteLine("Multicelualr");
        public void SangreCaliente()=>Console.WriteLine("Sangre caliente Perro");
        public void Correr()=> Console.WriteLine("Corriendo");
        public void CuatroPatas()=>Console.WriteLine("Con cuatro patas Perro");

    }

    public class Perico : Organismo, IAve{
        public Perico (string nombre) : base(nombre){}
        public void Multicelular()=>Console.WriteLine("Multicelualr");
        public void SangreCaliente()=>Console.WriteLine("Sangre caliente perico");
        public void Volar()=> Console.WriteLine("Volando por el cielo compa");
        public void DosPatas()=>Console.WriteLine("");


    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Segundo ejemplo de interfaces");
            Perro miperro = new Perro("Lassie");
            Console.WriteLine($"Mi perro llamado {miperro.Nombre} esta haciendo lo siguiente");
            miperro.Respiracion();
            miperro.Crecimiento();
            miperro.Movimiento();
            miperro.SangreCaliente();
            miperro.Multicelular();
            miperro.CuatroPatas();
            miperro.Correr();

            Perico miperico = new Perico("Sparrow");
            Console.WriteLine($"Mi perico llamado {miperico.Nombre} esta haciendo lo siguiente");
            miperico.Respiracion();
            miperico.Crecimiento();
            miperico.Movimiento();
            miperico.Multicelular();
            miperico.SangreCaliente();
            miperico.Volar();
            miperico.DosPatas();
        }
    }
}
