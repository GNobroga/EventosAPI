namespace Back.EventoAPI.Persistence.Interfaces;

public interface IBaseRepository<T> where T: class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void DeleteRange(T[] entities);
    Task<bool> SaveChangesAsync();
}