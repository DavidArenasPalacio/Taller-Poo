using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
namespace Servicio
{
    public class FacturaService
    {

        //Lista de tipo EncabezadoFactura 
        public List<EncabezadoFactura> encabezadoFacturas = new List<EncabezadoFactura>();

        //Lista de DetalleFactura
        public List<DetalleFactura> detalleFacturas = new List<DetalleFactura>();

        //Crear  una venta
        public void Venta(ClienteService cliente, ProductoService producto, int cont)
        {
            Console.Write("Ingrese un documento: ");
            long documento = long.Parse(Console.ReadLine());
            int indexCliente = ValidarCliente(cliente, documento);

            if (indexCliente != -1)//Verifica si el cliente existe, si existe entra a la sentencia del if
            {
                EncabezadoFactura encabezadoFactura = new EncabezadoFactura();//Invocamos el EncabezadoFactura
                encabezadoFactura.Documento = documento;//Asigana el valor documento
                encabezadoFactura.NumeroFactura = cont;//Asigna el incrementador que pasa por parametro
                Console.Write("Cantidad de productos: ");
                int cantidad = int.Parse(Console.ReadLine());
                double valor = 0;
                int n = 0;
                while (n < cantidad)
                {
                    DetalleFactura detalleFactura = new DetalleFactura();//Instancia de la clase DetalleFactura
                    detalleFactura.IdFactura = encabezadoFactura.NumeroFactura;//Asigna el  número de factura
                    Console.Write("Ingrese el código del producto: ");
                    string codigo = Console.ReadLine();

                    
                    //Valida si el codigo existe, si no existe vuelve a preguntar
                    do
                    {
                        if (ValidarProducto(producto, codigo) < 0)
                        {
                            Console.Write("Ingrese otro código: ");
                            codigo = Console.ReadLine();
                        }else
                        {
                            //Valida si la cantidad que hay en el inventario es 0, si es 0 vuelve a preguntar
                            if (producto.Productos[ValidarProducto(producto, codigo)].Cantidad == 0)
                            {
                                Console.Write("No hay productos ingrese otro código: ");
                                codigo = Console.ReadLine();
                            }
                        }

                    } while (ValidarProducto(producto, codigo) < 0 || producto.Productos[ValidarProducto(producto, codigo)].Cantidad == 0);

                    detalleFactura.IdProducto = codigo;//Asigna el codigo a IdProducto

                    Console.Write("Ingrese la cantidad: ");
                    int cant = int.Parse(Console.ReadLine());

                    //Valida si la cantidad del producto no sea menor que cero o mayor que la cantidad del producto
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

                    producto.Productos[ValidarProducto(producto, codigo)].Cantidad -= cant;//Resta la cantidad ingresado con el del inventario

                    detalleFactura.Cantidad = cant;//Asigna el valor cantidad al detalleFactura
                    detalleFactura.Valor = producto.Productos[ValidarProducto(producto, codigo)].Precio * cant;
                    valor += detalleFactura.Valor;

                    detalleFacturas.Add(detalleFactura);//Agrega a la lista el objeto detalleFactura
                    n++;
                }

                encabezadoFactura.Valor = valor;//Asigna el valor que esta acumulado
                encabezadoFacturas.Add(encabezadoFactura);//Agrega a la lista el objeto encabezadoFactura
            }
            else
            {
                Console.WriteLine("El cliente no existe");
            }


            var encabezado = RelacionFactura(cliente).ToList();

            foreach (var item in encabezado)
            {
                Console.WriteLine($"IdFactura: {item.IdFactura} IdCliente: {item.Documento} Valor: {item.Valor}");
            }

            var detalle = RelacionDetalle(producto).ToList();
            string resultado = "";
            foreach (var item in detalle)
            {
                resultado += $"IdFactura: {item.IdFactura} IdProducto: {item.IdProducto} Cantidad: {item.Cantidad} Valor: {item.Valor}\n";

            }

            Console.WriteLine(resultado);
        }



        //Validamos el cliente por el documento
        public int ValidarCliente(ClienteService cliente, long documento)
        {
            int index = cliente.Clientes.FindIndex(cliente => cliente.Documento == documento);//Si ecuentra el docuemnto en la lista devuelve el indice si no devuelve -1
            return index;
        }

        //Validamos el producto por el codigo
        public int ValidarProducto(ProductoService producto, string codigo)
        {
            int index = producto.Productos.FindIndex(producto => producto.Codigo == codigo);
            return index;
        }

        //Relacionamos las listas encabezadoFacturas y clientes
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

        //Relacionamos las listas detalleFacturas, encabezadoFacturas,  productos
        public List<DetalleDto> RelacionDetalle(ProductoService producto)
        {
            var productos = producto.Productos.ToList();//Convertimos a una lista
            var encabezados = encabezadoFacturas.ToList();
            var detalle = (from detalles in detalleFacturas join encabezado in encabezados on detalles.IdFactura equals encabezado.NumeroFactura join product in productos on detalles.IdProducto equals product.Codigo select new DetalleDto { IdFactura = encabezado.NumeroFactura, IdProducto = product.Codigo, Cantidad = detalles.Cantidad, Valor = detalles.Valor }).ToList();
            return detalle;
        }

        //Buscar una factura por el número
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
