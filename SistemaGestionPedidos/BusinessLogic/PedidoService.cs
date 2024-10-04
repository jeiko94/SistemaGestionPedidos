//Integración de Entidades: Aquí estamos uniendo productos y clientes para crear pedidos.
//Validaciones: Nos aseguramos de que el cliente y los productos existen antes de crear el pedido.
//Abstracción: La lógica de crear un pedido está encapsulada en el método CrearPedido.

using System;
using System.Collections.Generic;
using SistemaGestionPedidos.DataAccess;
using SistemaGestionPedidos.Models;

namespace SistemaGestionPedidos.BusinessLogic
{
    //Clase que maneja la logica de negocio para pedidos
    public class PedidoService
    {
        private PedidoRepository pedidoRepository;
        private ClienteRepository clienteRepository;
        private ProductoRepository productoRepository;

        //Constructor
        public PedidoService()
        {
            pedidoRepository = new PedidoRepository();
            clienteRepository = new ClienteRepository();
            productoRepository = new ProductoRepository();
        }

        //Métodos de negocio

        //Obtener todos los pedidos
        public List<Pedido> ObtenerPedidos()
        {
            return pedidoRepository.ObtenerTodo();
        }

        //Crear un nuevo pedido
        public void CrearPedido(int idCliente, List<int> idsProductos)
        {
            //Obtener cliente
            Cliente cliente = clienteRepository.ObtenerPorId(idCliente);
            if (cliente == null)
            {
                throw new SystemException("El cliente no existe.");
            }

            //Obtener los productos
            List<Producto> productos = new List<Producto>();
            foreach (int idProducto in idsProductos)
            {
                Producto producto = productoRepository.ObtenerPorId(idProducto);
                if (producto != null)
                {
                    productos.Add(producto);
                }
                else
                {
                    throw new SystemException($"El producto con ID {idProducto} no existe");
                }
            }

            //Creal el pedido
            Pedido pedido = new Pedido
            {
                cliente = cliente,
                Productos = productos,
                Fecha = System.DateTime.Now
            };

            //Calcular el total del pedido
            pedido.CalcularTotal();

            //Agregar el pedido al repositorio
            pedidoRepository.Agregar(pedido);

        }

        //Elimina un pedido por su Id
        public void EliminarPedido(int id)
        {
            pedidoRepository.Eliminar(id);

        }
    }



}
