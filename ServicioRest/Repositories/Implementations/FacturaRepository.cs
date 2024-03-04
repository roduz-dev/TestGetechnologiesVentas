using Microsoft.EntityFrameworkCore;
using ServicioRest.Data;
using ServicioRest.Models;
using ServicioRest.Repositories.Interfaces;
using System.Runtime.InteropServices;

namespace ServicioRest.Repositories.Implementations
{
    public class FacturaRepository : IFactura
    {
        private readonly ApplicationDBContext _context;
        public FacturaRepository(ApplicationDBContext dBContext)
        {
            _context = dBContext;
        }
        public int CreateFactura(Factura factura)
        {
            int result = -1;
            if (factura == null)
            {
                result = 0;
            }
            else
            {
                _context.Facturas.Add(factura);
                _context.SaveChanges();
                result = factura.id;
            }
            return result;
        }

        public int DeleteFactura(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteFacturaByPersona(string identificacion)
        {
            var persona = _context.Personas.FirstOrDefault(p => p.identificacion == identificacion);
            if (persona == null)
            {
                return -1;
            }
            var item = _context.Facturas.FirstOrDefault(p => p.id == persona.id);
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                return item.id;
            }
            return -1;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Factura> GetAllFacturas()
        {
            return _context.Facturas.ToList();
        }

        public IEnumerable<Factura> GetFacturaById(int id)
        {
            IEnumerable<Factura> facturas = _context.Facturas.Include(f=>f.persona).Where(p => p.id == id);
            return facturas;
        }

        public IEnumerable<Factura> GetFacturaByPersona(string identificacion)
        {
            var persona = _context.Personas.FirstOrDefault(p => p.identificacion == identificacion);
            if (persona == null)
            {
                return null;
            }
            IEnumerable<Factura> facturas = _context.Facturas.Include(f => f.persona).Where(p => p.personaId == persona.id);
            return facturas;
        }
       
    }
}
