using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modulo;
namespace Servicio
{
    public class ProductoService
    {
        public List<Producto> Productos { get; set; }

        public Producto producto = new Producto();

        public void Crear()
        {
            Productos = new List<Producto>();

            Console.WriteLine("aqui se crea un producto");
            Console.WriteLine("Ingrese el codigo del producto:  ");
            producto.Codigo = Console.ReadLine();
         

            if (Validar(producto.Codigo) != -1)
            {
                Console.WriteLine("El codigo del producto ya existe");
            }
            else
            {
                Console.WriteLine("Ingrese el nombre del producto:  ");
                producto.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el precio del producto:  ");
                producto.Precio = double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad del producto:  ");
                producto.Cantidad = int.Parse(Console.ReadLine());
                Productos.Add(producto);
            }

        }
        public int Validar(string codigo)
        {
            int consulta = Productos.FindIndex(c => c.Codigo == codigo);
            return consulta;
        }

        public void Editar(string codigo)
        {
            int index = Validar(codigo);

            if (index != -1)
            {
                Console.WriteLine("aqui se crea un producto");
                Console.WriteLine($"Modificar el codigo {Productos[index].Codigo} del producto:  ");
                string Codigo = Console.ReadLine();
                Console.WriteLine($"Modificar el nombre {Productos[index].Nombre} del producto:  ");
                string Nombre = Console.ReadLine();
                Console.WriteLine($"Modificar el precio {Productos[index].Precio} del producto:  ");
                double Precio = double.Parse(Console.ReadLine());
                Console.WriteLine($"Modificar la cantidad {Productos[index].Cantidad} del producto:  ");
                int Cantidad = int.Parse(Console.ReadLine());

                Productos[index].Codigo = Codigo;
                Productos[index].Nombre = Nombre;
                Productos[index].Cantidad = Cantidad;
                Productos[index].Precio = Precio;
        
            }
            else
            {
                Console.WriteLine("El producto no existe");
            }

        }

        public List<Producto> Buscar(string codigo)
        {
          var consulta = Productos.Where(producto => producto.Codigo == codigo).ToList();
            return consulta;
        }
    }
}
