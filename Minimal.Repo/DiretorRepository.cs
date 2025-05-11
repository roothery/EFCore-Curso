using Microsoft.EntityFrameworkCore;
using Minimal.API.DbContexts;
using Minimal.Domain.Entities;
using Minimal.Repo.Contratos;

namespace Minimal.Repo;

public class DiretorRepository(Context _context) : IDiretorRepository
{
    public Context Context { get; } = _context;

    public IEnumerable<Diretor> GetDiretores()
    {
        return Context.Diretores.Include(diretor => diretor.Filmes).ToList();
    }

    public Diretor GetDiretorByName(string name)
    {
        return Context.Diretores
                .Include(diretor => diretor.Filmes)
                .FirstOrDefault(diretor => diretor.Nome.Contains(name))
                ?? new Diretor { Id = 5555, Nome = "Marina" };
    }

    public IEnumerable<Diretor> GetDiretoresById(int id)
    {
        return Context.Diretores
                .Include(diretor => diretor.Filmes)
                .Where(diretor => diretor.Id == id)
                .ToList();
    }

    public void Add(Diretor diretor)
    {
        Context.Diretores.Add(diretor);
    }

    public void Delete(int diretorId)
    {
        var diretor = Context.Diretores.Find(diretorId);

        if (diretor != null)
            Context.Diretores.Remove(diretor);
    }

    public void Update(Diretor diretorNovo)
    {
        var diretor = Context.Diretores.Find(diretorNovo.Id);

        if (diretor != null)
        {
            diretor.Nome = diretorNovo.Nome;
            if (diretorNovo.Filmes.Count > 0)
            {
                diretor.Filmes.Clear();
                foreach (var filme in diretorNovo.Filmes)
                {
                    diretor.Filmes.Add(filme);
                }
            }
        }
    }

    public bool SaveChanges()
    {
        return Context.SaveChanges() > 0;
    }
}
