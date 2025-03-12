using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Minimal.API.DbContexts;
using Minimal.API.Entities;
using Minimal.API.Models;

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

app.MapGet("/diretores/{id}", (
    int id,
    Context context) =>
{
    return context.Diretores
        .Where(diretor => diretor.Id == id)
        .Include(diretor => diretor.Filmes)
        .ToList();
})
.WithOpenApi();

app.MapGet("/filmes", (Context context) =>
{
    return context.Filmes
        .Include(filme => filme.Diretor)
        .OrderByDescending(filme => filme.Ano)
        .ThenBy(filme => filme.Titulo)
        .ToList();
})
.WithOpenApi();

app.MapGet("/filmes/{id}", (
    int id,
    Context context) =>
{
    return context.Filmes
        .Where(filme => filme.Id == id)
        .Include(filme => filme.Diretor)
        .ToList();
})
.WithOpenApi();

app.MapGet("/filmesEF/byName/{titulo}", (
    string titulo,
    Context context) =>
{
    return context.Filmes
        .Where(filme => 
            EF.Functions.Like(filme.Titulo, $"%{titulo}%")
        )
        .Include(filme => filme.Diretor)
        .ToList();
})
.WithOpenApi();

app.MapGet("/filmesLinq/byName/{titulo}", (
    string titulo,
    Context context) =>
{
    return context.Filmes
        .Where(filme => filme.Titulo.Contains(titulo))
        .Include(filme => filme.Diretor)
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

app.MapDelete("/filmes/{filmeId}", (Context context, int filmeId) =>
{
    context.Filmes
        .Where(filme => filme.Id == filmeId)
        .ExecuteDelete<Filme>();
})
.WithOpenApi();

app.MapPatch("/filmesUpdate", (Context context, FilmeUpdate filmeUpdate) =>
{
    var filme = context.Filmes.Find(filmeUpdate.Id);

    if (filme == null) {
        return Results.NotFound("Filme não encontrado!");
    }

    filme.Titulo = filmeUpdate.Titulo;
    filme.Ano = filmeUpdate.Ano;

    context.Filmes.Update(filme);
    context.SaveChanges();

    return Results.Ok($"Filme (ID: {filmeUpdate.Id}) atualizado com sucesso!");
})
.WithOpenApi();

app.MapPatch("/filmesExecuteUpdate", (Context context, FilmeUpdate filmeUpdate) =>
{
    var result = context.Filmes
        .Where(filme => filme.Id == filmeUpdate.Id)
        .ExecuteUpdate(setter => setter
            .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
            .SetProperty(f => f.Ano, filmeUpdate.Ano)
        );
    
    if (result > 0) {
        return Results.Ok($"Total de linha(s) afetada(s): {result}");
    } else {
        return Results.NoContent();
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
