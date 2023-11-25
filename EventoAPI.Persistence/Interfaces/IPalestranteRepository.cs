using Back.EventoAPI.Domain.Models;
using Back.EventoAPI.Persistence.Interfaces;

namespace Back.EventoAPI.Persistence;

public interface IPalestranteRepository : IBaseRepository<Palestrante>
{
    Task<IEnumerable<Palestrante>> GetAllPalestrantesByNomeAsync(string nome);
    Task<IEnumerable<Palestrante>> GetAllPalestrantesAsync();
    Task<Palestrante?> GetPalestrantesByIdAsync(int id);
}