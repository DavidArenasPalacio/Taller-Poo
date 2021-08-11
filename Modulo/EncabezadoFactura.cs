using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo
{
    public class EncabezadoFactura
    {
        public int IdFactura { get; set; }
        public Cliente Clientes { get; set; }
        public Producto Productos { get; set; }

        public int Valor { get; set; }


        public EncabezadoFactura()
        {
            IdFactura++;
        }


      

    }
}
