using System;

namespace Proyecto_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Datos datos = new Datos();
            string opcion = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============  Sistema P.O.S  ==========");
                Console.WriteLine("========  Ferreteria Mi Preferida  ==========");
                Console.WriteLine("*********************************************");
                Console.WriteLine("");
                Console.WriteLine("1...Productos");
                Console.WriteLine("2...Crear Orden de venta");
                Console.WriteLine("3...Clientes");
                Console.WriteLine("4... Reporte de Ventas");
                Console.WriteLine("0... Salir");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        datos.ListarProductos();
                        break;
                    case "2":
                        Console.Clear();
                        datos.CrearOrden();
                        break;
                    case "3":
                        Console.Clear();
                        datos.ListarClientes();
                        break;
                    case "4":
                        Console.Clear();
                        datos.ListarOrdenes();
                        break;                                               
                    default:
                        break;
                }

                if (opcion == "0") {
                    break;
                }
            }
        }
    }
}