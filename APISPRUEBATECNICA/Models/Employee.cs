using System.ComponentModel.DataAnnotations;
using System.Numerics;
 namespace APISPRUEBATECNICA.Models
{
    public class Employee
    {
        [Key]
        public int employeeID { get; set; }

        public int Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Genero { get; set; }
    }
}