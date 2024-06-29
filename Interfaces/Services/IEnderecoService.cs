using ProAuto.Models;

namespace ProAuto.Interfaces.Services
{
    public interface IEnderecoService
    {

        public Task<Endereco?> Salvar(Endereco endereco);


    }
}