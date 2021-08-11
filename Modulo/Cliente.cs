using System;

namespace Modulo
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }


        public Cliente()
        {
            ClienteId++;
        }

        public Cliente(int documento, string nombre, string direcion, int telefono)
        {
            ClienteId++;
            Documento = documento;
            Nombre = nombre;
            Direccion = direcion;
            Telefono = telefono;
        }
    }
}
