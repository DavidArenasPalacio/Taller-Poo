using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
namespace Servicio
{
    public class ProductoService
    {
        //Lista de tipo producto
        public List<Producto> Productos = new List<Producto>();

        //Este metodo agrega el objeto de producto a la lista
        public void Agregar(Producto producto)
        {
            Productos.Add(producto);
        }

        //Este metodo valida si el codigo existe, si existe devuelve el indice donde lo encontro si no devuelve -1
        public int ValidarCodigo(string codigo)
        {
            int index = Productos.FindIndex(producto => producto.Codigo == codigo);
            return index;
        }

        //Este metodo busca un producto  por su codigo
        public string BuscarProducto(string codigo)
        {
            string resultBuscar = "";
            var buscar = Productos.Where(producto => producto.Codigo == codigo).ToList();//Se busca el codigo del producto si fue encontrado de vuelve todas las propiedaes  de ese producto

            if (buscar.Count != 0)//Si la cantidad de elementos que hay en buscar es diferente de cero es que encontro al producto
            {
                foreach (var producto in buscar)//Itera el producto encontrado
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

        //Este Metodo nos permite modificar un producto
        public void ModificarProducto(string codigo)
        {
            int index = ValidarCodigo(codigo);//Validamos el codigo

            if (index != -1)//Si el index no contiene -1 entra a la sentencia
            {
                Console.WriteLine($"Modificar el codigo {Productos[index].Codigo} del producto:  ");
                string Codigo = Console.ReadLine();
                Console.WriteLine($"Modificar el nombre {Productos[index].Nombre} del producto:  ");
                string Nombre = Console.ReadLine();
                Console.WriteLine($"Modificar el precio {Productos[index].Precio} del producto:  ");
                double Precio = double.Parse(Console.ReadLine());
                Console.WriteLine($"Modificar la cantidad {Productos[index].Cantidad} del producto:  ");
                int Cantidad = int.Parse(Console.ReadLine());

                //Modificamos producto mediante su indice
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
