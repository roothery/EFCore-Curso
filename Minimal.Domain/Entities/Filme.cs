namespace Minimal.Domain.Entities;

public class Filme
{
    public int Id { get; set; }
    public required string Titulo { get; set; }
    public int Ano { get; set; }
    public int DiretorId { get; set; }

    public Diretor Diretor { get; set; } = null!;
    //public ICollection<Diretor> Diretores { get; set; } = null!;
}
