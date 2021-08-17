using System;
using System.Collections.Generic;
using System.Linq;
using Modelo;
namespace Servicio
{
    public class ClienteService
    {
        public List<Cliente> Clientes = new List<Cliente>();


        public void Agregar(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public int ValidarDocumento(long documento)
        {
            int index = Clientes.FindIndex(cliente => cliente.Documento == documento);
            return index;
        }

        public string BuscarCliente(long documento)
        {
            string resultBuscar = "";
            var buscar = Clientes.Where(cliente => cliente.Documento == documento).ToList();

            if (buscar.Count != 0)
            {
                foreach (var cliente in buscar)
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

        public void ModificarCliente(long documento)
        {
            int index = ValidarDocumento(documento);

            if (index != -1)
            {
                Console.Write($"Modificar el nombre {Clientes[index].Nombre} del cliente:  ");
                string nombre = Console.ReadLine();
                Console.Write($"Modificar la dirección {Clientes[index].Direccion} del producto:  ");
                string direccion = Console.ReadLine();
                Console.Write($"Modificar el teléfono {Clientes[index].Telefono} del cliente:  ");
                int telefono = int.Parse(Console.ReadLine());
                Console.Write($"Modificar el documento {Clientes[index].Documento} del cliente:  ");
                int document = int.Parse(Console.ReadLine());

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
