using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modulo;
namespace Servicio
{
    public class FacturaService
    {

         EncabezadoFactura encabezadofactura = new EncabezadoFactura();
         DetalleFactura detalleFactura = new DetalleFactura();
         List<int> cliente = new List<int>();
         List<DetalleFactura> detalleFacturas = new List<DetalleFactura>();

        public DateTime Fecha;
        public void Venta()
        {
            Console.Write("Ingrese el documento: ");
            int documento = int.Parse(Console.ReadLine());

          
            if(BuscarCliente(documento).Count != 0)
            {
                Console.WriteLine("El cliente no existe");
            }
            else
            {
                cliente.Add(documento);
                GenerarVenta();
            }
        }


        public void GenerarVenta()
        {
            Console.Write("Ingrese la cantidad de productos a llevar: ");
            int cantidad = int.Parse(Console.ReadLine()); 

            for(int i = 0; i < cantidad; i++)
            {
                Console.WriteLine("Ingrese el código del producto: ");
                string codigo = Console.ReadLine();
                do
                {
                    if (VerificarCodigo(codigo) >= 0)
                    {
                        //cliente.Add(codigo);
                        break;
                    }
                    Console.WriteLine("Ingrese otra vez el código del producto: ");
                     codigo = Console.ReadLine();
                } while (VerificarCodigo(codigo) != -1);
            }


        }

        public void GenerarEF()
        {
            string result = "";
           
        }

        public void GenerarDF()
        {
            string result = "";
            //foreach (var item in Codigo)
            //{
            //    if (item.Productos.Codigo == factura.Productos.Codigo)
            //    {

            //    }

            //}
        }

        public int VerificarCodigo(string codigo)
        {
            int index = detalleFactura.IdProducto.Codigo.IndexOf(codigo);
            return index;
        }

        public List<Cliente> BuscarCliente(int documento)
        {
            var consulta = encabezadofactura.Clientes.Clientes.Where(cliente => cliente.Documento == documento).ToList();
            return consulta;
        }
    }
}
