using Back.EventoAPI.Application.Interfaces;
using Back.EventoAPI.Domain.Models;

namespace Back.EventoAPI.Application.Impl;

public class PalestranteService : IPalestranteService
{
    public Task<Palestrante> Add(Palestrante model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Palestrante>> GetAllPalestrantesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Palestrante>> GetAllPalestrantesByTemaAsync(string tema)
    {
        throw new NotImplementedException();
    }

    public Task<Palestrante?> GetEventosByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Palestrante> Update(int id, Palestrante model)
    {
        throw new NotImplementedException();
    }
}