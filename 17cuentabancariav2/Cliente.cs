using System.Collections.Generic;
namespace _17cuentabancariav2
{
    public class Cliente
    {
        private string nombre;
        private List<CuentaBancaria> cuentas;

        public Cliente(){}

        public Cliente(string nombre){
            this.nombre = nombre;
            cuentas = new List<CuentaBancaria>();
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        
        
        public List<CuentaBancaria> Cuentas()
        {
            return cuentas;
        }

        public void AgregarCuenta(CuentaBancaria cta){
            cuentas.Add(cta);
        }
        
    }
}