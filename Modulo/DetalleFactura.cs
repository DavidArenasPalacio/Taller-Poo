using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo
{
   public class DetalleFactura
    {
        public EncabezadoFactura IdFactura { get; }
        public Producto IdProducto { get; }
        public int Cantidad { get; set; }

    }
}
