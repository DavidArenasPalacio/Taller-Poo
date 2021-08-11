using System;
using System.Collections.Generic;
using System.Linq;
using Modulo;
namespace Servicio
{
    public class ClienteService
    {
        public List<Cliente> Clientes { get; set; }

        public Cliente clientes = new Cliente();
        public void Crear()
        {

            Clientes = new List<Cliente>();
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
                Clientes.Add(clientes);
            }

        }
        public int Validar(int documento)
        {
            int index = Clientes.FindIndex(c => c.Documento == documento);
            return index;
        }

        public void Editar(int document)
        {
            int index = Validar(document);

            if (index != -1)
            {

                Console.Write($"Modificar el documento {Clientes[index].Documento} del cliente:  ");
                int documento = int.Parse(Console.ReadLine());
                Console.Write($"Modificar el nombre {Clientes[index].Nombre} del cliente:  ");
                string nombre = Console.ReadLine();
                Console.Write($"Modificar la dirección {Clientes[index].Direccion} del cliente:  ");
                string direccion = Console.ReadLine();
                Console.Write($"Modificar el teléfono {Clientes[index].Telefono} del cliente:  ");
                int telefono = int.Parse(Console.ReadLine());


                Clientes[index].Documento = documento;
                Clientes[index].Nombre = nombre;
                Clientes[index].Telefono = telefono;
                Clientes[index].Direccion = direccion;
            }
            else
            {
                Console.WriteLine("El cliente no existe");
            }

        }

        public List<Cliente> Buscar(int documento)
        {
            var consulta = Clientes.Where(cliente => cliente.Documento == documento).ToList();
            return consulta;
        }
    }
}
