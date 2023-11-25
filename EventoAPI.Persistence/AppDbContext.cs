namespace Back.EventoAPI.Persistence;

using Back.EventoAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{

    public DbSet<Evento> Eventos { get; set; }

    public DbSet<Lote> Lotes { get; set; }

    public DbSet<Palestrante> Palestrantes { get; set; }

    public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }

    public DbSet<RedeSocial> RedesSociais { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PalestranteEvento>()
            .HasKey(p => new { p.PalestranteId, p.EventoId });

        modelBuilder.Entity<Evento>()
            .HasMany(e => e.RedesSociais)
            .WithOne(r => r.Evento)
            .OnDelete(DeleteBehavior.Cascade);
    }
}