using System;
using System.Collections.Generic;

namespace Modulo
{
    public class Cliente
    {
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }

        public List<Cliente> Clientes { get; set; }
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
