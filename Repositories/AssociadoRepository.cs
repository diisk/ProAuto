using Microsoft.EntityFrameworkCore;
using ProAuto.Data;
using ProAuto.Interfaces.Repositories;
using ProAuto.Models;

namespace ProAuto.Repositories
{
    public class AssociadoRepository : IAssociadoRepository
    {
        private readonly AppDbContext _context;
        public AssociadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Associado>> FindAll()
        {
            return await _context.Associados.Include(a => a.Veiculos).Include(a => a.Endereco).ToListAsync();
        }

        public async Task<Associado?> FindByCPF(string cpf)
        {
            return await _context.Associados.Include(a => a.Veiculos).SingleOrDefaultAsync(a => a.CPF == cpf);
        }

        public async Task<Associado?> FindById(int id)
        {
            return await _context.Associados.Include(a => a.Endereco).Include(a => a.Veiculos).SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Associado> Save(Associado associado)
        {
            Associado? dbAssociado = await buscarAssociadoExistente(associado);
            if (dbAssociado != null)
            {
                associado.Id = dbAssociado.Id;
                _context.Update(associado);
            }
            else
            {
                await _context.Associados.AddAsync(associado);
            }
            await _context.SaveChangesAsync();
            return associado;
        }

        private async Task<Associado?> buscarAssociadoExistente(Associado associado)
        {
            if (associado.Id > 0) return associado;

            return await FindByCPF(associado.CPF!);

        }
    }
}