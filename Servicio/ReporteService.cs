using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio
{
    public class ReporteService
    {

        public string ListarClientes(ClienteService clientes)
        {
            string resultClientes = "";

            if (clientes.Clientes.Count != 0)
            {
                foreach (var cliente in clientes.Clientes)
                {
                    resultClientes += $"Nombre: {cliente.Nombre} Dirección: {cliente.Direccion} Teléfono: {cliente.Telefono} Documento: {cliente.Documento}\n";
                }
            }
            else
            {
                resultClientes = "No hay clientes";
            }
            return resultClientes;
        }

        public string ListarProductos(ProductoService productos)
        {
            string resultProductos = "";

            if (productos.Productos.Count != 0)
            {
                foreach (var producto in productos.Productos)
                {
                    resultProductos += $"Nombre: {producto.Nombre} Precio: {producto.Precio} Cantidad: {producto.Cantidad} Código: {producto.Codigo}\n";
                }
            }
            else
            {
                resultProductos = "No hay productos";
            }
            return resultProductos;
        }


        public string ListarFacturas(FacturaService factura, ClienteService cliente)
        {
            string resultProductos = "";

            var encabezado = factura.RelacionFactura(cliente).ToList();

            if (encabezado.Count != 0)
            {
                foreach (var facturas in encabezado)
                {
                    resultProductos += $"IdFactura: {facturas.IdFactura} IdProducto: {facturas.Documento} Valor: {facturas.Valor}\n";
                }
            }
            else
            {
                resultProductos = "No hay productos";
            }
            return resultProductos;
        }
    }
}
