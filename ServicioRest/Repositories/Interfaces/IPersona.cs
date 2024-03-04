using ServicioRest.Models;

namespace ServicioRest.Repositories.Interfaces
{
    public interface IPersona : IDisposable
    {
        IEnumerable<Persona> GetAllPersonas();
        Persona GetPersonaById(int id);
        Persona GetPersonaByIdentificacion(string identificacion);
        int CreatePersona(Persona persona);
        int UpdatePersona(Persona persona);
        int DeletePersona(int id);
        int DeletePersonaByIdentificacion(string identificacion);


    }
}
