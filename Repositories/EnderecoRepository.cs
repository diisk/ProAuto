using ProAuto.Data;
using ProAuto.Interfaces.Repositories;
using ProAuto.Models;

namespace ProAuto.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;
        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Endereco> Save(Endereco endereco)
        {
            if (endereco.Id > 0)
            {
                _context.Enderecos.Update(endereco);
            }
            else
            {
                await _context.Enderecos.AddAsync(endereco);
            }
            await _context.SaveChangesAsync();
            return endereco;
        }
    }
}