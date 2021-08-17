using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
namespace Servicio
{
    public class ProductoService
    {

        public List<Producto> Productos = new List<Producto>();


        public void Agregar(Producto producto)
        {
            Productos.Add(producto);
        }

        public  int ValidarCodigo(string codigo)
        {
            int index = Productos.FindIndex(producto => producto.Codigo == codigo);
            return index;
        }

        public string BuscarProducto(string codigo)
        {
            string resultBuscar = "";
            var buscar = Productos.Where(producto => producto.Codigo == codigo).ToList();

            if (buscar.Count != 0)
            {
                foreach (var producto in buscar)
                {
                    resultBuscar = $"Código: {producto.Codigo} \nNombre: {producto.Nombre} \nPrecio: {producto.Precio} \nCantidad: {producto.Cantidad}";
                }

            }
            else
            {
                resultBuscar = "El producto no existe";
            }

            return resultBuscar;

        }

        public void ModificarProducto(string codigo)
        {
            int index = ValidarCodigo(codigo);

            if (index != -1)
            {
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

                Console.WriteLine("Producto modificado");
            }
            else
            {
                Console.WriteLine("El producto no existe");
            }
        }


    }
}
