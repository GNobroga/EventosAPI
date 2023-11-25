using Back.EventoAPI.Domain.Models;

namespace Back.EventoAPI.Application.Interfaces;

public interface IPalestranteService
{
    Task<Palestrante> Add(Palestrante model);

    Task<Palestrante> Update(int id, Palestrante model);

    Task<bool> Delete(int id);

    Task<IEnumerable<Palestrante>> GetAllPalestrantesByTemaAsync(string tema);
    Task<IEnumerable<Palestrante>> GetAllPalestrantesAsync();
    Task<Palestrante?> GetEventosByIdAsync(int id);
}