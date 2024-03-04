using System.ComponentModel.DataAnnotations;

namespace ServicioRest.Models
{
    public class Persona
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        [Required]
        public string identificacion { get; set; }
        //public List<Factura>? facturas { get; set; }

    }
}
