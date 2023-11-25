using Back.EventoAPI.Domain.Models;

namespace Back.EventoAPI.Application.Interfaces;

public interface IEventoService
{
    Task<Evento> Add(Evento model);

    Task<Evento> Update(int id, Evento model);

    Task<bool> Delete(int id);

    Task<IEnumerable<Evento>> GetAllEventosByTemaAsync(string tema);
    Task<IEnumerable<Evento>> GetAllEventosAsync();
    Task<Evento> GetEventosByIdAsync(int id);
}