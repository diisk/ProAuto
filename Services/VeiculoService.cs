using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAuto.DTOs;
using ProAuto.Exceptions;
using ProAuto.Helpers;
using ProAuto.Interfaces.Repositories;
using ProAuto.Interfaces.Services;
using ProAuto.Models;

namespace ProAuto.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Veiculo?> PesquisarVeiculo(string placa)
        {
            return await _veiculoRepository.FindByPlaca(placa);
        }
    }
}