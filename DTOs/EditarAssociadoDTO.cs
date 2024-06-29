using ProAuto.Models;

namespace ProAuto.DTOs
{
    public record EditarAssociadoDTO
    {
        public Associado? Associado { get; set; }
        public Endereco? NovoEndereco { get; set; }
        public Veiculo? NovoVeiculo { get; set; }
    }
}