using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo
{
   public class DetalleFactura
    {
        public EncabezadoFactura idFactura { get; }
        public Producto idProduct { get; }
        public int cantidad { get; set; }

    }
}
