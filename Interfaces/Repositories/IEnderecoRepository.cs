using ProAuto.Models;

namespace ProAuto.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {

        public Task<Endereco> Save(Endereco endereco);

    }
}