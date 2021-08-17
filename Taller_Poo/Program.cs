using System;
using System.Collections.Generic;
using Modelo;
using Servicio;
namespace Taller_POO2
{
    class Program
    {
        static ClienteService clienteService = new ClienteService();
        static ProductoService productoService = new ProductoService();
        static FacturaService factura = new FacturaService();
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        public static void MenuPrincipal()
        {
            bool salir = true;

            while (salir)
            {
                Console.WriteLine("---------MERCADOS AAA---------");
                Console.WriteLine("\n1. Módulo de Clientes"
                        + "\n2. Módulo de Productos"
                        + "\n3. Módulo de ventas"
                        + "\n4. Módulo de reportes"
                        + "\n5. Módulo de configuración"
                        + "\n6. Salir");
                Console.Write("Elija una opción: ");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        ModuloCliente();
                        break;
                    case 2:
                        ModuloProducto();
                        break;
                    case 3:
                        ModuloVenta();
                        break;
                    case 4:
                        ModuloReporte();
                        break;
                    case 5:
                        //ModuloConfiguracion();
                        break;
                    case 6:
                        salir = false;
                        break;
                    default:
                        Console.WriteLine($"La opción {opcion} no existe");
                        break;
                }

            }
        }


        public static void ModuloCliente()
        {
            bool salir = true;
            while (salir)
            {
                Console.WriteLine("---------MERCADOS AAA---------");
                Console.WriteLine("Módulo de Clientes");
                Console.WriteLine("\n1. Agregar Cliente"
                        + "\n2. Modificar cliente"
                        + "\n3. Buscar cliente"
                        + "\n4. Eliminar cliente"
                        + "\n5. Salir");
                Console.Write("Elija una opción: ");
                int opcion = int.Parse(Console.ReadLine());
                long documento;
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine();
                        Cliente cliente = new Cliente();

                        Console.WriteLine("******** Crear un nuevo cliente *******");
                        Console.Write("Ingrese el nombre: ");
                        cliente.Nombre = Console.ReadLine();
                        Console.Write("Ingrese la dirección: ");
                        cliente.Direccion = Console.ReadLine();
                        Console.Write("Ingrese el teléfono: ");
                        cliente.Telefono = long.Parse(Console.ReadLine());
                        Console.Write("Ingrese el documento: ");
                        documento = long.Parse(Console.ReadLine());

                        do
                        {
                            if (clienteService.ValidarDocumento(documento) != -1)
                            {
                                Console.Write("Ingrese otro documento: ");
                                documento = long.Parse(Console.ReadLine());
                            }

                        } while (clienteService.ValidarDocumento(documento) != -1);

                        cliente.Documento = documento;

                        clienteService.Agregar(cliente);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("******** Modificar cliente ********");
                        Console.Write("Ingrese un documento: ");
                        documento = long.Parse(Console.ReadLine());
                        clienteService.ModificarCliente(documento);
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("********* Buscar un cliente *********");
                        Console.Write("Ingrese un documento: ");
                        documento = long.Parse(Console.ReadLine());
                        Console.WriteLine(clienteService.BuscarCliente(documento));
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("********* Eliminar un cliente *********");
                        Console.Write("Ingrese un documento: ");
                        documento = long.Parse(Console.ReadLine());
                        clienteService.EliminarCliente(documento);
                        break;
                    case 5:
                        salir = false;
                        break;
                    default:
                        Console.WriteLine($"La opción {opcion} no existe");
                        break;
                }

            }
        }

        public static void ModuloProducto()
        {
            bool salir = true;
            while (salir)
            {
                Console.WriteLine();
                Console.WriteLine("\n1. Agregar producto"
                        + "\n2. Editar producto"
                        + "\n3. buscar productos"
                        + "\n4. Salir");
                Console.Write("Elija un opció: ");
                int opcion = int.Parse(Console.ReadLine());
                string codigo;
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("******** Crear un nuevo producto *******");
                        Console.Write("Ingrese el código: ");
                        codigo = Console.ReadLine();

                        do
                        {
                            if (productoService.ValidarCodigo(codigo) != -1)
                            {
                                Console.Write("Ingrese otro código: ");
                                codigo = Console.ReadLine();
                            }

                        } while (productoService.ValidarCodigo(codigo) != -1);

                        Console.Write("Ingrese el nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el precio: ");
                        double precio = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese la cantidad: ");
                        int cantidad = int.Parse(Console.ReadLine());
                        Producto producto = new Producto(nombre, precio, cantidad, codigo);
                        productoService.Agregar(producto);
                        Console.WriteLine();

                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("******** Modificar un cliente *******");
                        Console.Write("Ingrese el código del producto: ");
                        codigo = Console.ReadLine();
                        productoService.ModificarProducto(codigo);
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("******** Buscar un cliente *******");
                        Console.WriteLine("Ingrese el codigo: ");
                        codigo = Console.ReadLine();

                        Console.WriteLine(productoService.BuscarProducto(codigo));
                        Console.WriteLine();
                        break;
                    case 4:
                        salir = false;
                        break;
                    default:
                        Console.WriteLine($"La opción {opcion} no existe");
                        break;
                }

            }
        }


        public static void ModuloVenta()
        {
            bool salir = true;
          
            while (salir)
            {
                Console.WriteLine();
                Console.WriteLine("********* Venta ********");
                Console.WriteLine("1. Venta" +
                    "\n2. Buscar factura" +
                    "\n3. Salir");
                Console.Write("Elija una opción: ");
                int opcion = int.Parse(Console.ReadLine());
                
                switch (opcion)
                {
                    case 1:
                        factura.Venta(clienteService, productoService);
                        break;
                    case 2:
                        Console.Write("Ingrese el número de la factura: ");
                        int numFactura = int.Parse(Console.ReadLine());
                        Console.WriteLine(factura.BuscarFactura(numFactura));
                        break;
                    case 3:
                        salir = false;
                        break;
                    default:
                        Console.WriteLine($"La opción {opcion} no existe");
                        break;
                }
            }




           

        }


        public static void ModuloReporte()
        {
            bool salir = true;
            ReporteService reporte = new ReporteService();
            while (salir)
            {
                Console.WriteLine();
                Console.WriteLine("1. Listar clientes" +
                    "\n2. Listar productos" +
                    "\n3. Listar facturas" +
                    "\n4. Salir");
                Console.Write("Elija una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine(reporte.ListarClientes(clienteService));
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine(reporte.ListarProductos(productoService));
                        Console.WriteLine();
                        break;
                    case 3:

                        Console.WriteLine();
                        Console.WriteLine(reporte.ListarFacturas(factura, clienteService));
                        Console.WriteLine();

                        break;
                    case 4:
                        salir = false;
                        break;
                    default:
                        Console.WriteLine($"La opción {opcion} no existe");
                        break;
                }
            }
        }
    }
}
