


using Back.EventoAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventoAPI.Services;

public class PopulateDbService 
{

    private readonly AppDbContext _context;

    public PopulateDbService(AppDbContext context) => _context = context;

    public void Populate() {}
}