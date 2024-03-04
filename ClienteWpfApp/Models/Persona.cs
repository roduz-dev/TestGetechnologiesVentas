using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteWpfApp.Models
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
    }
}
