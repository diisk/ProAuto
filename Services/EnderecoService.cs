using ProAuto.Interfaces.Repositories;
using ProAuto.Interfaces.Services;
using ProAuto.Models;

namespace ProAuto.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Endereco?> Salvar(Endereco endereco)
        {
            return await _enderecoRepository.Save(endereco);
        }
    }
}