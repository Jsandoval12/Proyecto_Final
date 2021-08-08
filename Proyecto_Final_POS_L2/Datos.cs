using System;
using System.Collections.Generic;
public class Datos
{
    public List<Producto> ListadeProductos { get; set; }
    public List<Cliente> ListadeClientes { get; set; }
    public List<Orden> ListaOrdenes { get; set; }

    public Datos()
    {
        ListadeProductos = new List<Producto>();
        cargarProductos();

        ListadeClientes = new List<Cliente>();
        cargarClientes();

        ListaOrdenes = new List<Orden>();
    }

    private void cargarProductos()
    {
        

        
        Producto p1 = new Producto(1, "Cubeta de Pintura      ",1200);
        ListadeProductos.Add(p1);
        Producto p2 = new Producto(2, "Brocha 1/8             ", 35);
        ListadeProductos.Add(p2);
        Producto p3 = new Producto(3, "Clavos de 1/2          ", 50);
        ListadeProductos.Add(p3);
        Producto p4 = new Producto(4, "Disolbente             ", 150);
        ListadeProductos.Add(p4);
        Producto p5 = new Producto(5, "Tape 2 Pulg            ", 75);
        ListadeProductos.Add(p5);
        Producto p6 = new Producto(6, "Ceramica de marmol     ", 180);
        ListadeProductos.Add(p6);
        Producto p7 = new Producto(7, "Pegamento para piso    ", 230);
        ListadeProductos.Add(p7);
        Producto p8 = new Producto(8, "Pintura en lata        ", 190);
        ListadeProductos.Add(p8);
    }

    private void cargarClientes()
    {
        Cliente c1 = new Cliente(1, "  Jon Bernet    ", " 9578-5689 " );
        ListadeClientes.Add(c1);
        Cliente c2 = new Cliente(2, "  Winter Brown  ", " 3292-7899 ");
        ListadeClientes.Add(c2);
        Cliente c3 = new Cliente(3, "  Jess Noriega  ", " 8695-4578 ");
        ListadeClientes.Add(c3);
        Cliente c4 = new Cliente(4, "  Gerry Parck   ", " 9565-7812 ");
        ListadeClientes.Add(c4);
        
    }


    public void ListarProductos()
    {
        Console.WriteLine("");
        Console.WriteLine("\t'=========================='");
        Console.WriteLine("\t|==========================|");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t|          LISTA           |");
        Console.WriteLine("\t|           DE             |");
        Console.WriteLine("\t|        PRODUCTOS         |");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t'--------------------------'");
        
        
        Console.WriteLine("Codigo  |    Producto              |   Precio");
        Console.WriteLine("►-------------------------------------------◄");
        foreach (var producto in ListadeProductos)
        {
            Console.WriteLine(producto.Codigo + "       | " + producto.Descripcion + "  |    " + producto.Precio);
        }

        Console.ReadLine();
    }

    public void ListarClientes()
    {
        
        Console.WriteLine("");
        Console.WriteLine("\t'=========================='");
        Console.WriteLine("\t|==========================|");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t|          LISTA           |");
        Console.WriteLine("\t|           DE             |");
        Console.WriteLine("\t|         CLIENTES         |");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t'--------------------------'");
        
        Console.WriteLine("Codigo  |    Nombre Cliente       |   Telefono    ");
        Console.WriteLine("►--------------------------------------------◄");
        foreach (var cliente in ListadeClientes)
        {
            Console.WriteLine(cliente.Codigo + "       |   " + cliente.Nombre + "      | " + cliente.Telefono);
        }

        Console.ReadLine();
    }

    public void CrearOrden()
    {
        Console.WriteLine("");
        Console.WriteLine("\t'=========================='");
        Console.WriteLine("\t|==========================|");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t|       NUEVA ORDEN        |");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t'--------------------------'");

        Console.WriteLine("Ingrese el codigo del cliente: ");
        string codigoCliente = Console.ReadLine();

        Cliente cliente = ListadeClientes.Find(c => c.Codigo.ToString() == codigoCliente);        
        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado");
            Console.ReadLine();
            return;
        } else {
            Console.WriteLine("Cliente: " + cliente.Nombre);
            Console.WriteLine("");
        }

        int nuevoCodigo = ListaOrdenes.Count + 1;

        Orden nuevaOrden = new Orden(nuevoCodigo, DateTime.Now, "Naco,Cortes" + nuevoCodigo, cliente );
        ListaOrdenes.Add(nuevaOrden);

        while(true)
        {
            Console.WriteLine("Ingrese el producto: ");
            string codigoProducto = Console.ReadLine();
            Producto producto = ListadeProductos.Find(p => p.Codigo.ToString() == codigoProducto);        
            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado");
                Console.ReadLine();
            } else {
                Console.WriteLine("Producto agregado: " + producto.Descripcion + " con precio de: " + producto.Precio);
                nuevaOrden.AgregarProducto(producto);
            }

            Console.WriteLine("Desea continuar? s/n");
            string continuar = Console.ReadLine();
            if (continuar.ToLower() == "n") {
                break;
            }
        }
        Console.WriteLine("SubTotal de la orden es de:    " + nuevaOrden.SubTotal);
        Console.WriteLine("Impuesto:                      " + nuevaOrden.Impuesto);
        Console.WriteLine("Total de la orden es de:       " + nuevaOrden.Total);
        Console.ReadLine();
    }

    public void ListarOrdenes()
    {
        Console.WriteLine("");
        Console.WriteLine("\t'=========================='");
        Console.WriteLine("\t|==========================|");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t|        LISTADO           |");
        Console.WriteLine("\t|          DE              |");
        Console.WriteLine("\t|        ORDENES           |");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t|                          |");
        Console.WriteLine("\t'--------------------------'");  

        foreach (var orden in ListaOrdenes)
        {
            Console.WriteLine("");
            Console.WriteLine("Codigo    | Fecha ");
            Console.WriteLine(orden.Codigo + "         | "+orden.Fecha);
            Console.WriteLine("");

            Console.WriteLine(""); 
            Console.WriteLine("Descripcion                  | Cantidad         | Precio");
            foreach (var detalle in orden.ListaOrdenDetalle)
            {
                Console.WriteLine("     " + detalle.Producto.Descripcion + " | " + detalle.Cantidad + "                | " + detalle.Precio);
            }
            Console.WriteLine("");
            Console.WriteLine("Subtotal  |   Impuesto    | Total ");
            Console.WriteLine(orden.SubTotal +"      |    " + orden.Impuesto + "     | " + orden.Total);
            Console.WriteLine("");
      
            
            

            Console.WriteLine();
            Console.WriteLine("-----------------UL-------------------");
        } 

        Console.ReadLine();
    }
}