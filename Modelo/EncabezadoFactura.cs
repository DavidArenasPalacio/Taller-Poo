using System;
using System.Collections.Generic;
using System.Text;
namespace Modelo
{
    public class EncabezadoFactura
    {
        public int NumeroFactura { get; set; }
        public long Documento { get; set; }
        public double Valor { get; set; }

        public EncabezadoFactura()
        {
            NumeroFactura++;
        }
    }
}
