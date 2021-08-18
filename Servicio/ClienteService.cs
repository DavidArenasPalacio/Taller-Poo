using System;
using System.Collections.Generic;
using System.Linq;
using Modelo;
namespace Servicio
{
    public class ClienteService
    {
        //Lista de tipo cliente
        public List<Cliente> Clientes = new List<Cliente>();


        //Este metodo agrega el objeto de cliente a la lista
        public void Agregar(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        //Este metodo valida si el documento existe, si existe devuelve el indice donde lo encontro si no devuelve -1
        public int ValidarDocumento(long documento)
        {
            int index = Clientes.FindIndex(cliente => cliente.Documento == documento);
            return index;
        }

        //Este metodo busca un cliente por su documento
        public string BuscarCliente(long documento)
        {
            string resultBuscar = "";
            var buscar = Clientes.Where(cliente => cliente.Documento == documento).ToList();//Se busca el documento del cliente si fue encontrado de vuelve todas las propiedaes  de ese cliente

            if (buscar.Count != 0)//Si la cantidad de elementos que hay en buscar es diferente de cero es que encontro al cliente
            {
                foreach (var cliente in buscar)//Itera el cliente encontrado
                {
                    resultBuscar = $"\nNombre: {cliente.Nombre} \nDocumento: {cliente.Documento} \nTeléfono: {cliente.Telefono} \nDirección: {cliente.Direccion}";
                }

            }
            else
            {
                resultBuscar = "El cliente no existe";
            }

            return resultBuscar;

        }

        //Este Metodo nos permite modificar un cliente
        public void ModificarCliente(long documento)
        {
            int index = ValidarDocumento(documento);//Validamos el documento

            if (index != -1)//Si el index no contiene -1 entra a la sentencia
            {
                Console.Write($"Modificar el nombre {Clientes[index].Nombre} del cliente:  ");
                string nombre = Console.ReadLine();
                Console.Write($"Modificar la dirección {Clientes[index].Direccion} del producto:  ");
                string direccion = Console.ReadLine();
                Console.Write($"Modificar el teléfono {Clientes[index].Telefono} del cliente:  ");
                int telefono = int.Parse(Console.ReadLine());
                Console.Write($"Modificar el documento {Clientes[index].Documento} del cliente:  ");
                int document = int.Parse(Console.ReadLine());
                

                //Modificamos cliente mediante su indice
                Clientes[index].Nombre = nombre;
                Clientes[index].Direccion = direccion;
                Clientes[index].Telefono = telefono;
                Clientes[index].Documento = document;

                Console.WriteLine("Cliente modificado");
            }
            else
            {
                Console.WriteLine("El cliente no existe");
            }
        }

        //Eliminamos un cliente mediante el indice
        public void EliminarCliente(long documento)
        {
            int index = ValidarDocumento(documento);
            if (index != -1)
            {
                Clientes.RemoveAt(index);
                Console.WriteLine("Cliente eliminado");
            }
            else
            {
                Console.WriteLine("El cliente no existe");
            }
        }
    }
}
