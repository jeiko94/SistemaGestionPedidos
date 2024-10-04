//Creamos la clase Producto con las propiedades Id, Nombre y Precio.
//Encapsulación: Utilizamos propiedades públicas para acceder a los atributos del producto.

namespace SistemaGestionPedidos.Models
{
    ///<sumary>
    ///Clase que representa un producto en el sistema
    ///</sumary>
    public class Producto
    {
        //Propiedades del producto
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
