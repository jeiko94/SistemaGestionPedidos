//La clase Pedido tiene una lista de Productos, un Cliente, una Fecha y un Total.
//El constructor inicializa la lista de productos.
//Abstracción: Representamos un pedido como una entidad con atributos y comportamientos relevantes.
//Encapsulación: Los métodos y propiedades manejan internamente los datos del pedido.

using System.Collections.Generic;
using System;

namespace SistemaGestionPedidos.Models
{
    ///<sumary>
    ///Clase que representa un cliente en el sistema
    ///</sumary>
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente cliente { get; set; }
        public List<Producto> Productos { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        //Constructor
        public Pedido()
        {
            //Inicializamos la lista de productos
            Productos = new List<Producto>();
        }


        ///<sumary>
        ///Calcula el total del pedido sumando los precios de los productos
        ///</sumary>
        public void CalcularTotal()
        {
            Total = 0;
            foreach (var producto in Productos)
            {
                Total += producto.Precio;
            }
        }
    }


}
