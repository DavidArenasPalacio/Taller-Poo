using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
namespace Servicio
{
    public class FacturaService
    {

        
        public List<EncabezadoFactura> encabezadoFacturas = new List<EncabezadoFactura>();

       
        public List<DetalleFactura> detalleFacturas = new List<DetalleFactura>();

        public void Venta(ClienteService cliente, ProductoService producto)
        {
            EncabezadoFactura encabezadoFactura = new EncabezadoFactura();
            
            Console.WriteLine("Ingrese un documento: ");
            long documento = long.Parse(Console.ReadLine());
            int indexCliente = ValidarCliente(cliente, documento);
            if (indexCliente != -1)
            {
                encabezadoFactura.Documento = documento;

                Console.Write("Cantidad de productos: ");
                int cantidad = int.Parse(Console.ReadLine());
                double valor = 0;
                int n = 0;
                while (n < cantidad)
                {
                    DetalleFactura detalleFactura = new DetalleFactura();
                    detalleFactura.IdFactura = encabezadoFactura.NumeroFactura;
                    Console.Write("Ingrese el código del producto: ");
                    string codigo = Console.ReadLine();

                    //  int indexProducto = ValidarProducto(producto, codigo);

                    do
                    {
                        if (ValidarProducto(producto, codigo) < 0)
                        {
                            Console.Write("Ingrese otro código: ");
                            codigo = Console.ReadLine();
                        }

                    } while (ValidarProducto(producto, codigo) < 0);

                    detalleFactura.IdProducto = codigo;

                    Console.Write("Ingrese la cantidad: ");
                    int cant = int.Parse(Console.ReadLine());

                    do
                    {

                        if (cant > 0)
                        {
                            if (cant > producto.Productos[ValidarProducto(producto, codigo)].Cantidad)
                            {
                                Console.Write("Ingrese la cantidad que sea menor o igual que la cantidad del producto: ");
                                cant = int.Parse(Console.ReadLine());
                            }
                        }
                        else
                        {
                            Console.Write("Ingrese la cantidad que sea mayor que cero: ");
                            cant = int.Parse(Console.ReadLine());
                        }
                    } while (cant <= 0 || cant > producto.Productos[ValidarProducto(producto, codigo)].Cantidad);

                    producto.Productos[ValidarProducto(producto, codigo)].Cantidad -= cant;

                    detalleFactura.Cantidad = cant;
                    detalleFactura.Valor = producto.Productos[ValidarProducto(producto, codigo)].Precio * cant;
                    valor += detalleFactura.Valor;

                    detalleFacturas.Add(detalleFactura);
                    n++;
                }

                encabezadoFactura.Valor = valor;
                encabezadoFacturas.Add(encabezadoFactura);
            }
            else
            {
                Console.WriteLine("El cliente no existe");
            }


            var encabezado = RelacionFactura(cliente).ToList();

            foreach (var item in encabezado)
            {
                Console.WriteLine($"IdFactura: {item.IdFactura} IdProducto: {item.Documento} Valor: {item.Valor}");
            }

            var detalle = RelacionDetalle(producto).ToList();
            string resultado = "";
            foreach (var item in detalle)
            {
                resultado += $"IdFactura: {item.IdFactura} IdProducto: {item.IdProducto} Cantidad: {item.Cantidad} Valor: {item.Valor}\n";

            }

            Console.WriteLine(resultado);
        }



        public int ValidarCliente(ClienteService cliente, long documento)
        {
            int index = cliente.Clientes.FindIndex(cliente => cliente.Documento == documento);
            return index;
        }

        public int ValidarProducto(ProductoService producto, string codigo)
        {
            int index = producto.Productos.FindIndex(producto => producto.Codigo == codigo);
            return index;
        }

        public List<EncabezadoDto> RelacionFactura(ClienteService cliente)
        {
            var factura = encabezadoFacturas.Join(
                cliente.Clientes,
                 encabezadoFactura => encabezadoFactura.Documento,
                 cliente => cliente.Documento,
                 (encabezadoFactura, cliente) => new EncabezadoDto
                 {
                     IdFactura = encabezadoFactura.NumeroFactura,
                     Documento = cliente.Documento,
                     Valor = encabezadoFactura.Valor
                 }
                ).ToList();
            return factura;
        }

        public List<DetalleDto> RelacionDetalle(ProductoService producto)
        {
            var productos = producto.Productos.ToList();
            var encabezados = encabezadoFacturas.ToList();
            var detalle = (from detalles in detalleFacturas join encabezado in encabezados on detalles.IdFactura equals encabezado.NumeroFactura join product in productos on detalles.IdProducto equals product.Codigo select new DetalleDto { IdFactura = encabezado.NumeroFactura, IdProducto = product.Codigo, Cantidad = detalles.Cantidad, Valor = detalles.Valor }).ToList();
            return detalle;
        }

        public string BuscarFactura(int numFactura)
        {
            string resultBuscar = "";
            var buscar = detalleFacturas.Where(factura => factura.IdFactura == numFactura).ToList();

            if (buscar.Count != 0)
            {
                foreach (var factura in buscar)
                {
                    resultBuscar += $"idFactura: {factura.IdFactura} idProducto: {factura.IdProducto} Cantidad: {factura.Cantidad} Valor: {factura.Valor}\n";
                }
            }
            else
            {
                resultBuscar = "No se encontro la factura";
            }

            return resultBuscar;
        }



    }
}
