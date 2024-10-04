//Creamos un menú principal para navegar entre la gestión de productos, clientes y pedidos.
//Encapsulación: Cada funcionalidad está separada en métodos específicos.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using SistemaGestionPedidos.BusinessLogic;
using SistemaGestionPedidos.Models;

namespace SistemaGestionPedidos
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Instanciamos los servicios
            ProductoService productoService = new ProductoService();
            ClienteService clienteService = new ClienteService();
            PedidoService pedidoService = new PedidoService();

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- Menú principal ---");
                Console.WriteLine("1. Gestionar productos");
                Console.WriteLine("2. Gestionar clientes");
                Console.WriteLine("3. Gestionar pedidos");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Selecciona una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch(opcion)
                {
                    case 1:
                        MenuProductos(productoService);
                        break;
                    case 2:
                        MenuClientes(clienteService);
                        break;
                    case 3:
                        MenuPedidos(pedidoService, clienteService, productoService);
                        break;
                    case 4:
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción invalidad");
                        break;
                }
            }
        }

        //MÉTODOS PARA GESTIONAR PRODUCTOS

        //Menú para gestionar productos
        static void MenuProductos(ProductoService productoService)
        {
            bool volver = false;

            while (!volver)
            {
                Console.WriteLine("\n--- Gestión de productos ---");
                Console.WriteLine("1. Listar productos");
                Console.WriteLine("2. Agregar productos");
                Console.WriteLine("3. Actualizar productos");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Volver al menú principal");
                Console.WriteLine("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ListarProductos(productoService);
                        break;
                    case 2:
                        AgregarProducto(productoService);
                        break;
                    case 3:
                        ActualizarProducto(productoService);
                        break;
                    case 4:
                        EliminarProducto(productoService);
                        break;
                    case 5:
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción invalida.");
                        break;
                }
            }
        }

        //Listar todos los productos disponibles
        static void ListarProductos(ProductoService productoService)
        {
            var productos = productoService.ObtenerProductos();
            Console.WriteLine("\n--- Lista de productos ---");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}");
            }
        }

        //Permite agregar un producto
        static void AgregarProducto(ProductoService productoService)
        {
            Console.WriteLine("\nIngresa el ID  del producto: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngresa el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("\nIngresa el precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Producto nuevoProducto = new Producto { Id = id, Nombre = nombre, Precio = precio };

            try
            {
                productoService.AgregarProducto(nuevoProducto);
                Console.WriteLine("\nProducto agregado exitosamente. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //Permite actualizar un producto existente
        static void ActualizarProducto(ProductoService productoService)
        {
            Console.WriteLine("\nIngres el ID del producto a actualizar: ");
            int id = int.Parse(Console.ReadLine()) ;

            Console.WriteLine("Ingrese el nombre del nuevo producto: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingres el nuevo precio del producto: ");
            decimal precio = decimal.Parse (Console.ReadLine());

            Producto productoActualizado = new Producto { Id = id, Nombre = nombre, Precio = precio };

            try
            {
                productoService.ActualizarProducto(productoActualizado);
                Console.WriteLine("\nProducto actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //Permitir eliminar un producto
        static void EliminarProducto(ProductoService productoService)
        {

            Console.WriteLine("\nIngresa el ID del producto a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                productoService.EliminarProducto(id);
                Console.WriteLine("\nProducto Eliminado con exitosamente.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //MÉTODOS PARA GESTIONAR CLIENTES

        //Menú para gestionar clientes

        static void MenuClientes(ClienteService clienteService)
        {
            bool volver = false;

            while (!volver)
            {
                Console.WriteLine("\n--- Gestión de clientes ---");
                Console.WriteLine("1. Listar clientes");
                Console.WriteLine("2. Agregar clientes");
                Console.WriteLine("3. Actualizar clientes");
                Console.WriteLine("4. Eliminar clientes");
                Console.WriteLine("5. Volver al menú principal");
                Console.WriteLine("Selecciona una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch(opcion)
                {
                    case 1:
                        ListarClientes(clienteService);
                        break;
                    case 2:
                        AgregarCliente(clienteService);
                        break;
                    case 3:
                        ActualizarCliente(clienteService);
                        break;
                    case 4:
                        EliminarCliente(clienteService);
                        break;
                    case 5:
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción invalida");
                        break;
                }
            }
        }

        static void ListarClientes(ClienteService clienteService)
        {
            var clientes = clienteService.ObtenerCliente();
            Console.WriteLine("\n--- Lista de clientes ---");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, Correo: {cliente.Correo}");
            }
        }

        //Permite agregar un nuevo cliente
        static void AgregarCliente(ClienteService clienteService)
        {
            Console.WriteLine("\nIngresa el ID del cliente: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nombre del cliente: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el correo del cliente: ");
            string correo = Console.ReadLine();

            Cliente nuevoCliente = new Cliente { Id = id,  Nombre = nombre, Correo = correo };

            try
            {
                clienteService.AgregarCliente(nuevoCliente);
                Console.WriteLine("\nCliente agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //Permite actualizar un nuevo cliente
        static void ActualizarCliente(ClienteService clienteService)
        {
            Console.WriteLine("\nIngresa el ID del clente a actualizar: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo nombre del cliente: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo correo del cliente: ");
            string correo = Console.ReadLine();

            Cliente clienteActualizado = new Cliente { Id = id, Nombre = nombre, Correo = correo };

            try
            {
                clienteService.ActualizarCliente(clienteActualizado);
                Console.WriteLine("Cliente actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //Permite eliminar un cliente
        static void EliminarCliente(ClienteService clienteService)
        {
            Console.WriteLine("\nIngresa el ID del cliente a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                clienteService.EliminarCliente(id);
                Console.WriteLine("Cliente eliminado exitosamente: ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //MÉTODOS PARA GESTIONAR PEDIDOS

        //Menú para gestionar pedidos
        static void MenuPedidos(PedidoService pedidoService, ClienteService clienteService, ProductoService productoService)
        {
            bool volver = false;

            while (!volver)
            {
                Console.WriteLine("\n --- Gestión de pedidos ---");
                Console.WriteLine("1. Listar pedidos");
                Console.WriteLine("2. Crear pedido");
                Console.WriteLine("3. Eliminar pedido");
                Console.WriteLine("4. Volver al menú principal");
                Console.WriteLine("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch(opcion)
                {
                    case 1:
                        ListarPedidos(pedidoService);
                        break;
                    case 2:
                        CrearPedido(pedidoService, clienteService, productoService);
                        break;
                    case 3:
                        EliminarPedido(pedidoService);
                        break;
                    case 4:
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opcion invalidad.");
                        break;
                }
            }
        }

        //Lista todos los pedidos
        static void ListarPedidos(PedidoService pedidoService)
        {
            var pedidos = pedidoService.ObtenerPedidos();
            Console.WriteLine("\n--- Lista de pedidos ---");
            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"ID Pedido: {pedido.Id}, Cliente: {pedido.cliente.Nombre}, Fecha: {pedido.Fecha}, Total: {pedido.Total}");
                Console.WriteLine("Productos: ");
                foreach(var producto in pedido.Productos)
                {
                    Console.WriteLine($"\tID: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}");
                }
                Console.WriteLine("--------------------------------");
            }
        }

        //Permite crear un nuevo pedido
        static void CrearPedido(PedidoService pedidoService, ClienteService clienteService, ProductoService productoService)
        {
            Console.Write("\nIngrese el ID del cliente: ");
            int idCliente = int.Parse(Console.ReadLine());

            List<int> idsProductos = new List<int>();
            bool agregarProductos = true;

            while (agregarProductos)
            {
                Console.Write("Ingrese el ID del producto a agregar al pedido: ");
                int idProducto = int.Parse(Console.ReadLine());
                idsProductos.Add(idProducto);

                Console.WriteLine("¿Desea agregar otro producto? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    agregarProductos = false;
                }
            }
            try
            {
                pedidoService.CrearPedido(idCliente, idsProductos);
                Console.WriteLine("Pedido creado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //Eliminar un pedido
        static void EliminarPedido(PedidoService pedidoService)
        {
            Console.WriteLine("Ingrese el ID del pedido a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            try 
            {
                pedidoService.EliminarPedido(id);
                Console.WriteLine("Pedido eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }  
    }
}
