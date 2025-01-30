using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Minimal.API.DbContexts;
using Minimal.API.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:MinimalApiStr"])
);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options => {
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapGet("/diretores", (Context context) =>
{
    return context.Diretores
        .Include(diretor => diretor.Filmes)
        .ToList();
})
.WithOpenApi();

app.MapPost("/diretores", (Context context, Diretor diretor) =>
{
    context.Diretores.Add(diretor);
    context.SaveChanges();
})
.WithOpenApi();

app.MapPut("/diretores/{diretorId}", (Context context, int diretorId, Diretor novoDiretor) =>
{
    var diretor = context.Diretores.Find(diretorId);
    if (diretor != null)
    {
        diretor.Nome = novoDiretor.Nome;
        if (novoDiretor.Filmes.Count > 0)
        {
            diretor.Filmes.Clear();
            foreach (var filme in novoDiretor.Filmes)
            {
                diretor.Filmes.Add(filme);
            }
        }
        context.SaveChanges();
    }
})
.WithOpenApi();

app.MapDelete("/diretores/{diretorId}", (Context context, int diretorId) =>
{
    var diretor = context.Diretores.Find(diretorId);
    if (diretor != null)
    {
        context.Diretores.Remove(diretor);
        context.SaveChanges();
    }
})
.WithOpenApi();

app.Run();
