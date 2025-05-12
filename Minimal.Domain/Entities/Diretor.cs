using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minimal.Domain.Entities;

public class Diretor
{
    [Key]
    [Column("Diretor_Id")]
    public int Id { get; set; }
    public required string Nome { get; set; }

    public ICollection<DiretorFilme> DiretoresFilmes { get; set; } = null!;
    public ICollection<Filme> Filmes { get; set; } = null!;

    public DiretorDetalhe? DiretorDetalhe { get; set; }
}
