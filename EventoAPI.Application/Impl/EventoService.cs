using Back.EventoAPI.Application.Interfaces;
using Back.EventoAPI.Domain.Models;
using Back.EventoAPI.Persistence;
using EventoAPI.Application.Helpers;

namespace Back.EventoAPI.Application.Impl;

public class EventoService : IEventoService
{
    private readonly IEventoRepository _repository;

    public EventoService(IEventoRepository repository)
    {
        _repository = repository;
    }
    public async Task<Evento> Add(Evento model)
    {
        try 
        {
            _repository.Add(model);

            if (await _repository.SaveChangesAsync())
            {
                return (await _repository.GetEventosByIdAsync(model.Id))!;
            }

            throw new AppError("Não foi possível adicionar o evento.");
        }
        catch(Exception ex)
        {   
            throw new AppError(ex.Message);
        }
    }

    public async Task<bool> Delete(int id)
    {
        try 
        {
            var evento = await _repository.GetEventosByIdAsync(id);

            if (evento is null)
            {
                throw new AppError($"Não há evento com {id} cadastrado.", 404);
            }

            _repository.Delete(evento);

            return await _repository.SaveChangesAsync();
        
        }
        catch (Exception ex) 
        {   
            var statusCode = 500; 

            if (ex is AppError) 
            {
                statusCode = (ex as AppError)!.StatusCode;
            }
            throw new AppError(ex.Message, statusCode);
        }
    }

    public async Task<IEnumerable<Evento>> GetAllEventosAsync()
    {
        try 
        {
            var eventos = await _repository.GetAllEventosAsync();

            return eventos;

        }
        catch (Exception ex)
        {
            throw new AppError(ex.Message);
        }
    }

    public async Task<IEnumerable<Evento>> GetAllEventosByTemaAsync(string tema)
    {
        try 
        {
            var eventos = await _repository.GetAllEventosByTemaAsync(tema);
            return eventos;
        }
        catch (Exception ex)
        {
            throw new AppError(ex.Message);
        }
    }

    public async Task<Evento> GetEventosByIdAsync(int id)
    {
        try 
        {
            var evento = await _repository.GetEventosByIdAsync(id);
            
            if (evento is null) throw new AppError($"Não há evento com {id} cadastrado.", 404);

            return evento;
        }
        catch (Exception ex)
        {
            var statusCode = 500; 

            if (ex is AppError) 
            {
                statusCode = (ex as AppError)!.StatusCode;
            }
            throw new AppError(ex.Message, statusCode);
            throw new AppError(ex.Message);
        }
    }

    public async Task<Evento> Update(int id, Evento model)
    {
       try 
       {
            var evento = await _repository.GetEventosByIdAsync(id);

            if (evento is null)
            {
                throw new AppError($"Não há evento com {id} cadastrado.", 404);
            }

            model.Id = id;

            _repository.Update(model);

            if (await _repository.SaveChangesAsync())
            {
                return (await _repository.GetEventosByIdAsync(model.Id))!;
            }

            throw new AppError("Não foi possível atualizar o evento.");
       }
       catch (Exception ex) 
       {
            throw new AppError(ex.Message);
       }
    }
}