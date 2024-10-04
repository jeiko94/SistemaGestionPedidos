//Creamos la clase Cliente con las propiedades Id, Nombre y CorreoElectronico.
//Encapsulación: Las propiedades públicas permiten acceder y modificar los datos del cliente de manera controlada.
namespace SistemaGestionPedidos.Models
{
    ///<sumary>
    ///Clase que representa un cliente en el sistema
    ///</sumary>
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

    }
}
