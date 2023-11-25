using System.Text.Json;
using Back.EventoAPI.Application.Impl;
using Back.EventoAPI.Application.Interfaces;
using Back.EventoAPI.Persistence;
using Back.EventoAPI.Persistence.Impl;
using EventoAPI.Application.Helpers;
using EventoAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PopulateDbService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var populateService = scope.ServiceProvider.GetService(typeof(PopulateDbService)) as PopulateDbService;
    populateService?.Populate();
}

app.UseExceptionHandler(options => {

    options.Run(async context => {
        var error = context.Features.Get<AppError>();
        context.Response.Headers.Add("Content-Type", "application/json");
        context.Response.StatusCode = 500;

        if (error is not null)
        {   
            context.Response.StatusCode = error.StatusCode;
            await context.Response.WriteAsync(error.ToString());
        }
        else
        {
            await context.Response.WriteAsync(JsonSerializer.Serialize(new {
                Status = "Error",
                StatusCode = 500, 
                Message = "Ocorreu um erro desconhecido."
            }));
        }

    });

});

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run(); 