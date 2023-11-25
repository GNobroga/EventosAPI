using Back.EventoAPI.Domain.Models;
using Back.EventoAPI.Persistence.Interfaces;

namespace Back.EventoAPI.Persistence;

public interface IEventoRepository : IBaseRepository<Evento>
{
    Task<IEnumerable<Evento>> GetAllEventosByTemaAsync(string tema);
    Task<IEnumerable<Evento>> GetAllEventosAsync();
    Task<Evento?> GetEventosByIdAsync(int id);
}