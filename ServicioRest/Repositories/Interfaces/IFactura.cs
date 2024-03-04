using ServicioRest.Models;

namespace ServicioRest.Repositories.Interfaces
{
    public interface IFactura : IDisposable
    {
        IEnumerable<Factura> GetAllFacturas();
        IEnumerable<Factura> GetFacturaById(int id);
        IEnumerable<Factura> GetFacturaByPersona(string identificacion);
        int CreateFactura(Factura factura);
        int DeleteFactura(int id);
        int DeleteFacturaByPersona(string identificacion);
    }
}
