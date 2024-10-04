//Realizamos validaciones antes de agregar o actualizar un cliente.
//Encapsulación: Ocultamos la complejidad de las operaciones de datos detrás de métodos bien definidos.
using SistemaGestionPedidos.DataAccess;
using SistemaGestionPedidos.Models;
using System.Collections.Generic;
using System;

namespace SistemaGestionPedidos.BusinessLogic
{
    //Clase que maneja la lógica de negocio para cliente.
    public class ClienteService
    {
        private ClienteRepository clienteRepository;

        //Constructor
        public ClienteService()
        {
            clienteRepository = new ClienteRepository();
        }

        //Métodos de negocio

        //Obtenemos todos los clientes
        public List<Cliente> ObtenerCliente()
        {
            return clienteRepository.ObtenerTodos();
        }

        //Obtener un cliente por su ID
        public Cliente ObtenerClientePorId(int id)
        {
            return clienteRepository.ObtenerPorId(id);
        }

        //Agregamos un nuevo cliente despúes de validar
        public void AgregarCliente(Cliente cliente)
        {
            //Validación: El correo electronico es obligatorio
            if (string.IsNullOrEmpty(cliente.Correo))
            {
                throw new SystemException("El correo no puede ser nuelo");
            }

            clienteRepository.Agregar(cliente);
        }

        //Actualizar un cliente
        public void ActualizarCliente(Cliente cliente)
        {
            clienteRepository.Actualizar(cliente);
        }

        //Eliminamos un cliente por su ID
        public void EliminarCliente(int id)
        {
            clienteRepository.Eliminar(id);
        }

    }
}
