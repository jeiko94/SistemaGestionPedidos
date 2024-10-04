//Al igual que ProductoRepository, manejamos las operaciones CRUD para clientes.

using SistemaGestionPedidos.Models;
using System.Collections.Generic;

namespace SistemaGestionPedidos.DataAccess
{
    //clase que simula el acceso a datos para clientes
    public class ClienteRepository
    {
        //Lista que simula la base de datos de clientes
        private List<Cliente> clientes;

        //constructor
        public ClienteRepository()
        {
            clientes = new List<Cliente>
            {
                new Cliente {Id = 1,Nombre="Yeisson Villamil", Correo= "jvillamila194@gmail.com"},
                new Cliente{Id= 2, Nombre = "Laura Florez", Correo = "laura2002@gmail.com"}
            };
        }

        //Método CRUD

        //Listados todos nuestros cliente
        public List<Cliente> ObtenerTodos()
        {
            return clientes;
        }

        //Obtenemos un cliente por su ID
        public Cliente ObtenerPorId(int id)
        {
            return clientes.Find(c => c.Id == id);
        }

        //Agregamos un cliente
        public void Agregar(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        //Actualizamos a un cliente 
        public void Actualizar(Cliente cliente)
        {
            Cliente clienteExistente = ObtenerPorId(cliente.Id);
            if (clienteExistente != null)
            {
                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Correo = cliente.Correo;
            }

        }

        //Elimina a un cliente
        public void Eliminar(int id)
        {
            Cliente cliente = ObtenerPorId((int)id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }

    }
}
