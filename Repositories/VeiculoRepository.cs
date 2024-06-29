using Microsoft.EntityFrameworkCore;
using ProAuto.Data;
using ProAuto.Interfaces.Repositories;
using ProAuto.Models;

namespace ProAuto.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly AppDbContext _context;
        public VeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Veiculo?> FindByPlaca(string placa)
        {
            return await _context.Veiculos.SingleOrDefaultAsync(v => v.Placa!.ToLower() == placa.ToLower());
        }

        public async Task<Veiculo> Save(Veiculo veiculo)
        {
            Veiculo? dbVeiculo = await buscarVeiculoExistente(veiculo);
            if (dbVeiculo != null)
            {
                veiculo.Id = dbVeiculo.Id;
                _context.Update(veiculo);
            }
            else
            {
                await _context.Veiculos.AddAsync(veiculo);
            }
            await _context.SaveChangesAsync();
            return veiculo;
        }

        private async Task<Veiculo?> buscarVeiculoExistente(Veiculo veiculo)
        {
            if (veiculo.Id > 0) return veiculo;

            return await FindByPlaca(veiculo.Placa!);

        }
    }
}