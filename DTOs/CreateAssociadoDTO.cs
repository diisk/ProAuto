using System.ComponentModel.DataAnnotations;
using ProAuto.Helpers;

namespace ProAuto.DTOs
{
    public record CreateAssociadoDTO
    {
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public String? Nome { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        [RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}",ErrorMessage = Mensagens.ERRO_CPF_INVALIDO)]
        public String? CPF { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        [RegularExpression(@"\(\d{2}\)9?\d{4}\-\d{4}",ErrorMessage = Mensagens.ERRO_TELEFONE_INVALIDO)]
        public String? Telefone { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public String? Cidade { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public String? Estado { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public String? Bairro { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public String? Rua { get; set; }
        public String? Complemento { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public int Numero { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        [Display(Name = "Placa do Veículo")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = Mensagens.ERRO_PLACA_INVALIDA)]
        public String? PlacaVeiculo { get; set; }
    }
}