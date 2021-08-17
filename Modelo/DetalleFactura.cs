using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class DetalleFactura
    {
        public int IdFactura { get; set; }
        
        public string IdProducto { get; set; }

        public int Cantidad { get; set; }

        public double Valor { get; set; }
    }
}
