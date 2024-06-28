using ProAuto.Models;

namespace ProAuto.Interfaces.Services
{
    public interface IVeiculoService
    {

        public Task<Veiculo?> PesquisarVeiculo(String placa);


    }
}