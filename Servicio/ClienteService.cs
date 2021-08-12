using System;
using System.Collections.Generic;
using System.Linq;
using Modulo;
namespace Servicio
{
    public class ClienteService
    {
       

         Cliente clientes = new Cliente();
        public void Crear()
        {

            clientes.Clientes = new List<Cliente>();
            Console.Write("Ingrese el documento del cliente:  ");
            clientes.Documento = int.Parse(Console.ReadLine());

            if (Validar(clientes.Documento) != -1)
            {
                Console.WriteLine("El cliente ya existe");
            }
            else
            { 
                Console.Write("Ingrese el nombre del cliente:  ");
                clientes.Nombre = Console.ReadLine();
                Console.Write("Ingrese la direccion del cliente:  ");
                clientes.Direccion = Console.ReadLine();
                Console.Write("Ingrese el telefono del cliente:  ");
                clientes.Telefono = int.Parse(Console.ReadLine());
                clientes.Clientes.Add(clientes);
            }

        }
        public int Validar(int documento)
        {
            int index = clientes.Clientes.FindIndex(c => c.Documento == documento);
            return index;
        }

        public void Editar(int document)
        {
            int index = Validar(document);

            if (index != -1)
            {

                Console.Write($"Modificar el documento {clientes.Clientes[index].Documento} del cliente:  ");
                int documento = int.Parse(Console.ReadLine());
                Console.Write($"Modificar el nombre {clientes.Clientes[index].Nombre} del cliente:  ");
                string nombre = Console.ReadLine();
                Console.Write($"Modificar la dirección {clientes.Clientes[index].Direccion} del cliente:  ");
                string direccion = Console.ReadLine();
                Console.Write($"Modificar el teléfono {clientes.Clientes[index].Telefono} del cliente:  ");
                int telefono = int.Parse(Console.ReadLine());


                clientes.Clientes[index].Documento = documento;
                clientes.Clientes[index].Nombre = nombre;
                clientes.Clientes[index].Telefono = telefono;
                clientes.Clientes[index].Direccion = direccion;
            }
            else
            {
                Console.WriteLine("El cliente no existe");
            }

        }

        public List<Cliente> Buscar(int documento)
        {
            var consulta = clientes.Clientes.Where(cliente => cliente.Documento == documento).ToList();
            return consulta;
        }
    }
}
