using System.ComponentModel.DataAnnotations;
using ProAuto.Helpers;

namespace ProAuto.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        [StringLength(7, MinimumLength = 7, ErrorMessage = Mensagens.ERRO_PLACA_INVALIDA)]
        public String? Placa { get; set; }

        public int AssociadoId { get; set; }

        public Associado? Associado { get; set; }

        public Veiculo() { }

        public Veiculo(int associadoId)
        {
            this.AssociadoId = associadoId;
        }

        public Veiculo(String placa)
        {
            this.Placa = placa;
        }
    }
}