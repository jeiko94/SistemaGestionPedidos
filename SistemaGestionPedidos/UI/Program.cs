//Creamos un menú principal para navegar entre la gestión de productos, clientes y pedidos.
//Encapsulación: Cada funcionalidad está separada en métodos específicos.

using System;
using System.Collections.Generic;
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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
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

            while (volver)
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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
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
                Console.WriteLine("Producto agregado exitosamente. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //Permite actualizar un producto existente
        static void ActualizarProducto(ProductoService productoService)
        {

        }

    }
}
