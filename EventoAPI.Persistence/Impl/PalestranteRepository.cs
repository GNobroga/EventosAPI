using Back.EventoAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.EventoAPI.Persistence.Impl;

public class PalestranteRepository : BaseRepository<Palestrante>
{
    public PalestranteRepository(AppDbContext context) : base(context) {}

    public async Task<Palestrante?> GetPalestrantesByIdAsync(int id)
    {
        return await _context.Palestrantes.AsQueryable()
        .Include(p => p.RedesSociais)
        .Include(p => p.PalestrantesEventos)
        .ThenInclude(pe => pe.Evento)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Palestrante>> GetAllPalestrantesAsync()
    {
        return await _context.Palestrantes.AsQueryable()
        .Include(p => p.RedesSociais)
        .Include(p => p.PalestrantesEventos)
        .ThenInclude(pe => pe.Evento)
        .OrderBy(p => p.Id)
        .ToListAsync();
    }

    public async Task<IEnumerable<Palestrante>> GetAllPalestrantesByNomeAsync(string nome)
    {
        return await _context.Palestrantes.AsQueryable()
        .Include(p => p.RedesSociais)
        .Include(p => p.PalestrantesEventos)
        .ThenInclude(pe => pe.Evento)
        .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
        .ToListAsync();
    }

}