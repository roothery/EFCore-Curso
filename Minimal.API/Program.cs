using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Minimal.API.DbContexts;
using Minimal.API.EndpointExtensions;
using Minimal.Repo;
using Minimal.Repo.Contratos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:MinimalApiStr"])
                      .LogTo(Console.WriteLine, LogLevel.Information)
);

builder.Services.AddScoped<IDiretorRepository, DiretorRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Garante que o banco de dados seja criado, se ainda não existir
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<Context>();
//     db.Database.EnsureCreated();
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.DiretoresEndpoints();
app.FilmesEndpoints();

app.Run();
