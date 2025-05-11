using Minimal.Domain.Entities;

namespace Minimal.Repo.Contratos;

public interface IDiretorRepository
{
    IEnumerable<Diretor> GetDiretores();
    Diretor GetDiretorByName(string name);
    IEnumerable<Diretor> GetDiretoresById(int id);
    void Add(Diretor diretor);
    void Update(Diretor diretor);
    void Delete(int diretorId);
    bool SaveChanges();
}
