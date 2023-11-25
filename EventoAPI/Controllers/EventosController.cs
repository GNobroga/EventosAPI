using System.Text.Json;
using Back.EventoAPI.Application.Interfaces;
using Back.EventoAPI.Domain.Models;
using Back.EventoAPI.Persistence;
using EventoAPI.Application.Helpers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace EventoAPI.Controllers;

[Route("api/[controller]")]
[ApiController] 
public class EventosController : ControllerBase
{

    private readonly IEventoService _service;

    public EventosController(IEventoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Evento>>> Get()
    {
        return new ActionResult<IEnumerable<Evento>>(await _service.GetAllEventosAsync());
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Evento>> GetById(int id) 
    {
        return await _service.GetEventosByIdAsync(id);
    }

    [HttpGet("tema")]
    public async Task<ActionResult<IEnumerable<Evento>>> GetByTema(string tema)
    {
        return new ActionResult<IEnumerable<Evento>>(await _service.GetAllEventosByTemaAsync(tema));
    }

    [HttpPost]
    public async Task<ActionResult<Evento>> Post(Evento model) 
    {
        return await _service.Add(model);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Evento>> Put(int id, Evento record) 
    {
        return await _service.Update(id, record);
    }

    [HttpDelete("{id:int}")]
    public async Task<object> Delete(int id) 
    {   
        var deleted = await _service.Delete(id);
        return new { status = "OK", deleted };
    }

}