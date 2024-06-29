using System.ComponentModel.DataAnnotations;
using ProAuto.Helpers;

namespace ProAuto.DTOs
{
    public record PesquisarDTO
    {
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public String? CPF { get; set; }

        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        [Display(Name = "Placa do Veículo")]
        public String? PlacaVeiculo { get; set; }
    }
}