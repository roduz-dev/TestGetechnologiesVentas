using ServicioRest.Data;
using ServicioRest.Models;
using ServicioRest.Repositories.Interfaces;

namespace ServicioRest.Repositories.Implementations
{
    public class PersonaRepository : IPersona
    {
        private readonly ApplicationDBContext _context;
        public PersonaRepository(ApplicationDBContext dBContext) 
        {
            _context = dBContext;
        }
        public int CreatePersona(Persona persona)
        {
            int result = -1;
            if(persona == null)
            {
                result = 0;
            }
            else
            {
                _context.Personas.Add(persona);
                _context.SaveChanges();
                result = persona.id;
            }
            return result;
        }

        public int DeletePersona(int id)
        {
            var persona = _context.Personas.FirstOrDefault(p => p.id == id);
            var facturas = _context.Facturas.Where(f => f.id == persona.id);
            if (persona != null)
            {
                if (facturas != null)
                {
                    foreach (var factura in facturas)
                    {
                        _context.Remove(factura);
                    }
                }
                _context.Remove(persona);
                _context.SaveChanges();
                return id;
            }
            return -1;
        }

        public int DeletePersonaByIdentificacion(string identificacion)
        {
            var persona = _context.Personas.FirstOrDefault(p => p.identificacion == identificacion);
            var facturas = _context.Facturas.Where(f => f.personaId == persona.id); 
            if (persona != null)
            {
                if(facturas != null)
                {
                    foreach (var factura in facturas) 
                    {
                        _context.Remove(factura);
                        
                    }
                    _context.SaveChanges();
                }
                _context.Remove(persona);
                _context.SaveChanges();
                return persona.id;
            }
            return -1;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Persona> GetAllPersonas()
        {
            return _context.Personas.ToList();
        }

        public Persona GetPersonaById(int id)
        {
            Persona? persona = _context.Personas.FirstOrDefault(p => p.id == id);
            return persona;
        }

        public Persona GetPersonaByIdentificacion(string identificacion)
        {
            Persona? persona = _context.Personas.FirstOrDefault(p => p.identificacion == identificacion);
            return persona;
        }

        public int UpdatePersona(Persona persona)
        {
            var item = _context.Personas.FirstOrDefault(p => p.id == persona.id);
            if(item != null) 
            {
                item.nombre = persona.nombre;
                item.apellidoPaterno = persona.apellidoPaterno;
                item.apellidoMaterno = persona.apellidoMaterno;
                item.identificacion = persona.identificacion;
                _context.Update(item);
                _context.SaveChanges();
                return item.id;
            }
            return -1;
        }
    }
}
