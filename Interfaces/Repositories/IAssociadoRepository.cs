using ProAuto.Models;

namespace ProAuto.Interfaces.Repositories
{
    public interface IAssociadoRepository
    {
        public Task<Associado> Save(Associado associado);
        public Task<Associado?> FindByCPF(String cpf);
        public Task<List<Associado>> FindAll();
        public Task<Associado?> FindById(int id);
    }
}