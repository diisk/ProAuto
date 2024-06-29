using ProAuto.DTOs;
using ProAuto.Models;

namespace ProAuto.Interfaces.Services
{
    public interface IAssociadoService
    {
        public Task<Associado> Create(CreateAssociadoDTO dto);

        public Task<List<Associado>> FindAll();
        public Task<Associado?> FindById(int id);
        public Task<Associado?> PesquisarAssociado(PesquisarDTO dto);

        public Task<Associado> Atualizar(Associado associado);


    }
}