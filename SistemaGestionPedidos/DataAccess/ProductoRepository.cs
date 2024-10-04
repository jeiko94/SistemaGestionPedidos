//Simulamos una base de datos utilizando una lista en memoria.
//Proveemos métodos para las operaciones CRUD (Crear, Leer, Actualizar, Eliminar).
using SistemaGestionPedidos.Models;
using System.Collections.Generic;

namespace SistemaGestionPedidos.DataAccess
{
    //Clase que simula el acceso a datos para productos.
    public class ProductoRepository
    {
        //Lista que simula la base de datos de productos
        private List<Producto> productos;

        //Constructor
        public ProductoRepository()
        {
            //Inicializamos la lista "tabla" con algunos productos
            productos = new List<Producto>
            {
                new Producto{ Id = 1, Nombre = "Laptop", Precio = 800.000m},
                new Producto{ Id = 2, Nombre = "Celular", Precio = 500.000m},
                new Producto{ Id = 3, Nombre = "Gafas", Precio = 650.000m}
            };
        }

        //Métodos CRUD

        //Obtenemos todos los productos
        public List<Producto> Obtenertodos()
        {
            return productos;
        }

        //Obtenemos un producto por su ID
        public Producto ObtenerPorId(int id)
        {
            return productos.Find(p => p.Id == id);
        }

        //Agregamos un nuemo producto
        public void Agregar(Producto producto)
        {
            productos.Add(producto);
        }

        //Actualizamos un producto existente
        public void Actualizar(Producto producto)
        {
            Producto prodExistente = ObtenerPorId(producto.Id);
            if (prodExistente != null)
            {
                prodExistente.Nombre = producto.Nombre;
                prodExistente.Precio = producto.Precio;
            }
        }

        //Elimina un producto por su ID
        public void Eliminar(int id)
        {
            Producto producto = ObtenerPorId(id);
            if (producto != null)
            {
                productos.Remove(producto);
            }
        }
    }
}
