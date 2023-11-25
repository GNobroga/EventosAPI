using Back.EventoAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.EventoAPI.Persistence.Impl;

public class EventoRepository : BaseRepository<Evento>, IEventoRepository
{
    public EventoRepository(AppDbContext context) : base(context) {}

    public async Task<IEnumerable<Evento>> GetAllEventosAsync()
    {
       return await _context.Eventos.AsQueryable()
        .Include(e => e.Lotes)
        .Include(e => e.RedesSociais)
        .Include(e => e.PalestrantesEventos)
        .ThenInclude(p => p.Palestrante)
        .OrderBy(e => e.Id)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<IEnumerable<Evento>> GetAllEventosByTemaAsync(string tema)
    {
        return await _context.Eventos.AsQueryable()
        .Include(e => e.Lotes)
        .Include(e => e.RedesSociais)
        .Include(e => e.PalestrantesEventos)
        .ThenInclude(p => p.Palestrante)
        .OrderBy(e => e.Id)
        .AsNoTracking()
        .Where(e => e.Tema.ToLower().Contains(tema.ToLower()))
        .ToListAsync();
    }

    public async Task<Evento?> GetEventosByIdAsync(int id)
    {
        return await _context.Eventos.AsQueryable()
        .Include(e => e.Lotes)
        .Include(e => e.RedesSociais)
        .Include(e => e.PalestrantesEventos)
        .ThenInclude(p => p.Palestrante)
        .AsNoTracking()
        .FirstOrDefaultAsync(e => e.Id == id);
    }

}