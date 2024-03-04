namespace ServicioRest.Models
{
    public class Factura
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public int personaId { get; set; }

        public Persona? persona { get; set; }

    }
}
