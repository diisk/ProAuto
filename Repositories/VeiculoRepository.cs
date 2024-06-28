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
    }
}