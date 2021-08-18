using System;

namespace Modelo
{
    public class Cliente
    {
        //Propidades  con sus metodos getter and setter
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        public long Documento { get; set; }

        
        public Cliente(){ }

        public Cliente(string nombre, string direccion, long telefono, long documento)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Documento = documento;
        }

    }
}
