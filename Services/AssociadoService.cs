using ProAuto.DTOs;
using ProAuto.Exceptions;
using ProAuto.Helpers;
using ProAuto.Interfaces.Repositories;
using ProAuto.Interfaces.Services;
using ProAuto.Models;

namespace ProAuto.Services
{
    public class AssociadoService : IAssociadoService
    {
        private readonly IAssociadoRepository _associadoRepository;
        private readonly IVeiculoService _veiculoService;
        public AssociadoService(IAssociadoRepository associadoRepository, IVeiculoService veiculoService)
        {
            _associadoRepository = associadoRepository;
            _veiculoService = veiculoService;
        }
        public async Task<Associado> Create(CreateAssociadoDTO dto)
        {
            if (await _associadoRepository.FindByCPF(Utils.ApenasNumeros(dto.CPF!)) != null)
                throw new RegistrarAssociadoException(Mensagens.ERRO_CPF_CADASTRADO);

            if (await _veiculoService.PesquisarVeiculo(dto.PlacaVeiculo!) != null)
                throw new RegistrarAssociadoException(Mensagens.ERRO_VEICULO_CADASTRADO);


            Endereco endereco = new Endereco(dto);
            List<Veiculo> veiculos = [new Veiculo(dto.PlacaVeiculo!)];
            Associado associado = new Associado(dto, endereco, veiculos);
            await _associadoRepository.Save(associado);
            return associado;
        }

        public async Task<Associado> Atualizar(Associado associado)
        {
            if (associado.Id > 0)
                await _associadoRepository.Save(associado);
            return associado;
        }

        public async Task<List<Associado>> FindAll()
        {
            return await _associadoRepository.FindAll();
        }

        public async Task<Associado?> FindById(int id)
        {
            return await _associadoRepository.FindById(id);
        }

        public async Task<Associado?> PesquisarAssociado(PesquisarDTO dto)
        {
            Associado? associado = await _associadoRepository.FindByCPF(Utils.ApenasNumeros(dto.CPF!));
            if (associado != null && associado.Veiculos!.Any(v => v.Placa == dto.PlacaVeiculo))
                return associado;

            return null;
        }
    }
}