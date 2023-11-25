
using Back.EventoAPI.Persistence.Interfaces;

namespace Back.EventoAPI.Persistence.Impl;

public class BaseRepository<T> : IBaseRepository<T> where T: class 
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context) 
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public void DeleteRange(T[] entities)
    {
        _context.RemoveRange(entities);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }
}