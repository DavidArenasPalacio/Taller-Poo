using Modulo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio
{
    public class ReporteService
    {
        Reporte reporte = new Reporte();

        public string ListarClientes()
        {
            string resultado = "";

            foreach (var clientes in reporte.Clientes.Clientes)
            {
                resultado += "";
            }
            return resultado;
        }

        public string ListarProductos()
        {
            string resultado = "";

            foreach (var productos in reporte.Productos.Productos)
            {
                resultado += "";
            }
            return resultado;
        }
    }
}
