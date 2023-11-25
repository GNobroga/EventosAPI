using System.Text.Json.Serialization;

namespace Back.EventoAPI.Domain.Models;

public class Evento 
{   
    public int Id { get; set; }
    
    public string Local { get; set; }

    public DateTime? DataEvento { get; set; }

    public string Tema { get; set; }

    public int QntPessoas { get; set; }

    public string ImageURL { get; set; }

    public string Telefone { get; set; }

    public string Email { get; set; }


    public ICollection<Lote>? Lotes { get; set; }

    public ICollection<RedeSocial>? RedesSociais { get; set; }

    public ICollection<PalestranteEvento>? PalestrantesEventos { get; set; }
}