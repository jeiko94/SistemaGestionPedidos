//Abstracción y Encapsulación: La capa de lógica de negocio maneja las reglas y validaciones antes de interactuar con la capa de acceso a datos.
using SistemaGestionPedidos.DataAccess;
using SistemaGestionPedidos.Models;
using System.Collections.Generic;
using System;
namespace SistemaGestionPedidos.BusinessLogic
{
    //Clase que maneja la lógica de negocio para productos.
    public class ProductoService
    {
        private ProductoRepository productoRepository;

        //Constructor
        public ProductoService()
        {
            productoRepository = new ProductoRepository();
        }

        //Métodos de negocio

        ///<summary>
        ///Obtiene todos los productos
        ///</summary>>
        public List<Producto> ObtenerProductos()
        {
            return productoRepository.Obtenertodos();
        }

        //Obtiene un producto por su ID
        public Producto ObtenerProductoPorId(int id)
        {
            return productoRepository.ObtenerPorId(id);
        }

        //Agrega un nuevo producto despues de validar
        public void AgregarProducto(Producto producto)
        {
            //Validación: El precio no puede ser negativo
            if (producto.Precio < 0)
            {
                throw new SystemException("El precio no puede ser negativo");
            }
            productoRepository.Agregar(producto);
        }

        //Actualizar un producto existente
        public void ActualizarProducto(Producto producto)
        {
            productoRepository.Actualizar(producto);
        }

        //Eliminamos un producto
        public void EliminarProducto(int id)
        {
            productoRepository.Eliminar(id);
        }

    }
}
