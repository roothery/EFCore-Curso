using Minimal.Domain.Entities;

namespace Minimal.Repo.Contratos;

public interface IDiretorRepository
{
    Task<IEnumerable<Diretor>> GetDiretoresAsync();
    Task<Diretor> GetDiretorByNameAsync(string name);
    Task<IEnumerable<Diretor>> GetDiretoresByIdAsync(int id);
    Task AddAsync(Diretor diretor);
    Task UpdateAsync(Diretor diretor);
    Task DeleteAsync(int diretorId);
    Task<bool> SaveChangesAsync();
}
