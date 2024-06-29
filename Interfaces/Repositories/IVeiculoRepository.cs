using ProAuto.Models;

namespace ProAuto.Interfaces.Repositories
{
    public interface IVeiculoRepository
    {
        public Task<Veiculo?> FindByPlaca(String placa);

        public Task<Veiculo> Save(Veiculo veiculo);

    }
}