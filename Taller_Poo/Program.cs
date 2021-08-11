using System;
using Servicio;
namespace Taller_Poo
{
    class Program
    {

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
                        ModuloConfiguracion();
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
            ClienteService clienteService = new ClienteService();
            while (salir)
            {
                Console.WriteLine("---------MERCADOS AAA---------");
                Console.WriteLine("Módulo de Clientes");
                Console.WriteLine("\n1. Agregar Cliente"
                        + "\n2. Modificar cliente"
                        + "\n3. Buscar cliente"
                        + "\n4. Salir");
                int opcion = int.Parse(Console.ReadLine());
                int documento;
                switch (opcion)
                {
                    case 1:
                        clienteService.Crear();
                        break;
                    case 2:
                        Console.Write("Ingrese un documento: ");
                        documento = int.Parse(Console.ReadLine());
                        clienteService.Editar(documento);
                        break;
                    case 3:
                        Console.Write("Ingrese un documento: ");
                        documento = int.Parse(Console.ReadLine());
                        var buscar = clienteService.Buscar(documento);
                        if (buscar.Count != 0)
                        {
                            foreach (var cliente in buscar)
                            {
                                Console.WriteLine($"Documento: {cliente.Documento} \nNombre: {cliente.Nombre} \nDirección: {cliente.Direccion} \nTelefono: {cliente.Telefono}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El cliente no existe");
                        }
                        
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

        public static void ModuloProducto()
        {

            bool salir = true;
            var productoservice = new ProductoService();
            while (salir)
            {
                Console.WriteLine("---------MERCADOS AAA---------");
                Console.WriteLine("Módulo de Productos");
                Console.WriteLine("\n1. Agregar producto"
                        + "\n2. Editar producto"
                        + "\n3. buscar productos"
                        + "\n4. Salir");
                int seleccion = int.Parse(Console.ReadLine());
                string codigo;


                switch (seleccion)
                {

                    case 1:
                        productoservice.Crear();
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el codigo del producto que desea editar: ");
                        codigo = Console.ReadLine();

                        productoservice.Editar(codigo);

                        break;
                    case 3:

                        Console.WriteLine("Ingrese el codigo del producto que desea buscar");
                        codigo = Console.ReadLine();

                        var buscar = productoservice.Buscar(codigo);

                        if (buscar.Count != 0)
                        {
                            foreach (var item in buscar)
                            {
                                Console.WriteLine("El producto es: " + "[Codigo: " + item.Codigo + " - Nombre: " + item.Nombre + " - Precio: " + item.Precio + " - Cantidad: " + item.Cantidad + "]");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El producto no existe");
                        }

                        
                        break;
                    case 4:
                        salir = false;
                        break;
                    default:
                        Console.WriteLine($"La opción {seleccion} no existe");
                        break;
                }

            }
        }

        public static void ModuloVenta()
        {

        }

        public static void ModuloReporte()
        {
            //FacturaService factura = new FacturaService();
            //factura.Crear();
        }

        public static void ModuloConfiguracion()
        {

        }
    }
}
