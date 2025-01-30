using System;

namespace Minimal.API.Entities;

public class Diretor
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public ICollection<Filme> Filmes { get; set; } = [];
}
