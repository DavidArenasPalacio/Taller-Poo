using System;
using System.Collections.Generic;
using Modelo;
using Servicio;
namespace Taller_POO2
{
    class Program
    {
        static string NombreEmpresa = "AAAA";
        //Instanciamos 
        static ClienteService clienteService = new ClienteService();
        static ProductoService productoService = new ProductoService();
        static FacturaService factura = new FacturaService();
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        //Metodo para el menu principal
        public static void MenuPrincipal()
        {
            bool salir = true;

            while (salir)
            {
                Console.WriteLine($"---------MERCADOS  {NombreEmpresa} ---------");
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
                        ModuloCliente();//Invocamos el modulo cliente
                        break;
                    case 2:
                        ModuloProducto();//Invocamos el modulo producto
                        break;
                    case 3:
                        ModuloVenta();//Invocamos el modulo venta
                        break;
                    case 4:
                        ModuloReporte();//Invocamos el modulo venta
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
            while (salir)
            {
                Console.WriteLine($"--------- MERCADOS  {NombreEmpresa} ---------");
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

                        //Validamos si existe el cliente, si existe volvemos a preguntar
                        do
                        {
                            if (clienteService.ValidarDocumento(documento) != -1)
                            {
                                Console.Write("Ingrese otro documento: ");
                                documento = long.Parse(Console.ReadLine());
                            }

                        } while (clienteService.ValidarDocumento(documento) != -1);

                        cliente.Documento = documento;

                        clienteService.Agregar(cliente);//Agregamos el objeto a la lista
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

                        //Validamos si el codigo existe, si existe volvemos a preguntar
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
            int cont = 0;
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
                        cont++;
                        factura.Venta(clienteService, productoService, cont);
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

        public static void ModuloConfiguracion()
        {

            Console.WriteLine("1. Configurar nombre de la empresa" +
                            "\n2. Llenar informacion");
            Console.WriteLine("Elija una opcion");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)

            {
                case 1:
                    Console.WriteLine("Ingrese nombre de la empresa");
                    NombreEmpresa = Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("Desea crear 10 clientes y 10 productos? Ingrese Si/No");
                    string opcionCrear = Console.ReadLine();
                    if (opcionCrear == "Si")
                    {
                        Cliente cliente1 = new Cliente();
                        cliente1.Documento = 131412314;
                        cliente1.Nombre = "David";
                        cliente1.Direccion = "CRA 132";
                        cliente1.Telefono = 4724356;

                        clienteService.Agregar(cliente1);


                        Cliente cliente2 = new Cliente();
                        cliente2.Documento = 8345632452;
                        cliente2.Nombre = "Manuel";
                        cliente2.Direccion = "CLL 235";
                        cliente2.Telefono = 345346427;

                        clienteService.Agregar(cliente2);


                        Cliente cliente3 = new Cliente();
                        cliente3.Documento = 346587567;
                        cliente3.Nombre = "Cristian";
                        cliente3.Direccion = "CLL 35";
                        cliente3.Telefono = 935632832;

                        clienteService.Agregar(cliente3);


                        Cliente cliente4 = new Cliente();
                        cliente4.Documento = 93489230;
                        cliente4.Nombre = "Juan";
                        cliente4.Direccion = "CLL 13";
                        cliente4.Telefono = 381267215326;

                        clienteService.Agregar(cliente4);


                        Cliente cliente5 = new Cliente();
                        cliente5.Documento = 587366388;
                        cliente5.Nombre = "Sofia";
                        cliente5.Direccion = "CRA 25";
                        cliente5.Telefono = 22457572;

                        clienteService.Agregar(cliente5);


                        Cliente cliente6 = new Cliente();
                        cliente6.Documento = 763635637;
                        cliente6.Nombre = "Gabriela";
                        cliente6.Direccion = "CRA 05";
                        cliente6.Telefono = 12436983;

                        clienteService.Agregar(cliente6);


                        Cliente cliente7 = new Cliente();
                        cliente7.Documento = 98348934287;
                        cliente7.Nombre = "Armando";
                        cliente7.Direccion = "CRA 47";
                        cliente7.Telefono = 873549254;

                        clienteService.Agregar(cliente7);


                        Cliente cliente8 = new Cliente();
                        cliente8.Documento = 2359832582;
                        cliente8.Nombre = "Santiago";
                        cliente8.Direccion = "CLL 02";
                        cliente8.Telefono = 9823489567;

                        clienteService.Agregar(cliente8);


                        Cliente cliente9 = new Cliente();
                        cliente9.Documento = 78235482;
                        cliente9.Nombre = "Samuel";
                        cliente9.Direccion = "CRA 34";
                        cliente9.Telefono = 276257872;

                        clienteService.Agregar(cliente9);


                        Cliente cliente10 = new Cliente();
                        cliente10.Documento = 682589252;
                        cliente10.Nombre = "Samantha";
                        cliente10.Direccion = "CLL 76";
                        cliente10.Telefono = 908154295;

                        clienteService.Agregar(cliente10);



                        Producto producto1 = new Producto();
                        producto1.Codigo = "ASDF-124";
                        producto1.Nombre = "Cafe";
                        producto1.Cantidad = 2;
                        producto1.Precio = 50000;

                        productoService.Agregar(producto1);


                        Producto producto2 = new Producto();
                        producto2.Codigo = "FDXG-36";
                        producto2.Nombre = "Zanahoria";
                        producto2.Cantidad = 6;
                        producto2.Precio = 25000;

                        productoService.Agregar(producto2);


                        Producto producto3 = new Producto();
                        producto3.Codigo = "DFS-546";
                        producto3.Nombre = "Chocolate";
                        producto3.Cantidad = 1;
                        producto3.Precio = 3000;

                        productoService.Agregar(producto3);


                        Producto producto4 = new Producto();
                        producto4.Codigo = "FXJ-54";
                        producto4.Nombre = "Arroz";
                        producto4.Cantidad = 4;
                        producto4.Precio = 12000;

                        productoService.Agregar(producto4);


                        Producto producto5 = new Producto();
                        producto5.Codigo = "ESY-75";
                        producto5.Nombre = "Mandarina";
                        producto5.Cantidad = 12;
                        producto5.Precio = 7000;

                        productoService.Agregar(producto5);


                        Producto producto6 = new Producto();
                        producto6.Codigo = "TRE-234";
                        producto6.Nombre = "Chocolisto";
                        producto6.Cantidad = 20;
                        producto6.Precio = 16000;

                        productoService.Agregar(producto6);


                        Producto producto7 = new Producto();
                        producto7.Codigo = "WIT-45";
                        producto7.Nombre = "Salchicha";
                        producto7.Cantidad = 3;
                        producto7.Precio = 20000;

                        productoService.Agregar(producto7);


                        Producto producto8 = new Producto();
                        producto8.Codigo = "UJX-56";
                        producto8.Nombre = "Arepa";
                        producto8.Cantidad = 10;
                        producto8.Precio = 6000;

                        productoService.Agregar(producto8);


                        Producto producto9 = new Producto();
                        producto9.Codigo = "ASQ-456";
                        producto9.Nombre = "Huevo";
                        producto9.Cantidad = 12;
                        producto9.Precio = 10000;

                        productoService.Agregar(producto9);


                        Producto producto10 = new Producto();
                        producto10.Codigo = "KLI-87";
                        producto10.Nombre = "Jamon";
                        producto10.Cantidad = 4;
                        producto10.Precio = 23000;

                        productoService.Agregar(producto10);
                    }

                    break;

                default:
                    Console.WriteLine($"La opción {opcion} no existe");
                    break;
            }



        }
    }
}
