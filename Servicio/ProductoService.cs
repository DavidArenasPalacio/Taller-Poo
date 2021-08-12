using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modulo;
namespace Servicio
{
    public class ProductoService
    {

         Producto producto = new Producto();

        public void Crear()
        {
            producto.Productos = new List<Producto>();

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
                producto.Productos.Add(producto);
            }

        }
        public int Validar(string codigo)
        {
            int consulta = producto.Productos.FindIndex(c => c.Codigo == codigo);
            return consulta;
        }

        public void Editar(string codigo)
        {
            int index = Validar(codigo);

            if (index != -1)
            {
                Console.WriteLine("aqui se crea un producto");
                Console.WriteLine($"Modificar el codigo { producto.Productos[index].Codigo} del producto:  ");
                string Codigo = Console.ReadLine();
                Console.WriteLine($"Modificar el nombre { producto.Productos[index].Nombre} del producto:  ");
                string Nombre = Console.ReadLine();
                Console.WriteLine($"Modificar el precio { producto.Productos[index].Precio} del producto:  ");
                double Precio = double.Parse(Console.ReadLine());
                Console.WriteLine($"Modificar la cantidad { producto.Productos[index].Cantidad} del producto:  ");
                int Cantidad = int.Parse(Console.ReadLine());

                producto.Productos[index].Codigo = Codigo;
                producto.Productos[index].Nombre = Nombre;
                producto.Productos[index].Cantidad = Cantidad;
                producto.Productos[index].Precio = Precio;

            }
            else
            {
                Console.WriteLine("El producto no existe");
            }

        }

        public List<Producto> Buscar(string codigo)
        {
            var consulta = producto.Productos.Where(producto => producto.Codigo == codigo).ToList();
            return consulta;
        }
    }
}
