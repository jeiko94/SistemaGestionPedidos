//Mantenemos una lista de pedidos y asignamos IDs autoincrementales.
//Encapsulación: Controlamos el acceso y manipulación de los pedidos a través de métodos específicos.
using SistemaGestionPedidos.Models;
using System.Collections.Generic;
namespace SistemaGestionPedidos.DataAccess
{
    //Clase que simula el acceso a datos para pedidos
    public class PedidoRepository
    {
        //Lista que simula la base de datos de pedidos
        private List<Pedido> pedidos;
        private int siguienteId;

        //constructor
        public PedidoRepository()
        {
            pedidos = new List<Pedido>();
            siguienteId = 1; //Inicializamos el ID autoincremental
        }

        //Métodos CRUD

        //Obtenemos todos los pedidos
        public List<Pedido> ObtenerTodo()
        {
            return pedidos;
        }

        //Obtener el pedido por el ID
        public Pedido ObtenerPorId(int id)
        {
            return pedidos.Find(p => p.Id == id);
        }

        //Agregamos un nuevo pedido
        public void Agregar(Pedido pedido)
        {
            pedido.Id = siguienteId++;
            pedidos.Add(pedido);
        }

        //Eliminamos un pedido por el ID
        public void Eliminar(int id)
        {
            Pedido pedido = ObtenerPorId((int)id);
            if (pedido != null)
            {
                pedidos.Remove(pedido);
            }
        }
    }
}
