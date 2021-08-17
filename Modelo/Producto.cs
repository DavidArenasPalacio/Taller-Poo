using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public string Codigo { get; set; }

        public Producto(){}

        public Producto(string nombre, double precio, int cantidad, string codigo)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            Codigo = codigo;
        }

    }
}
