using System.ComponentModel.DataAnnotations;
using ProAuto.DTOs;
using ProAuto.Helpers;

namespace ProAuto.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public String? Complemento { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public String? Estado { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public String? Cidade { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public String? Bairro { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public String? Rua { get; set; }
        [Required(ErrorMessage = Mensagens.ERRO_CAMPO_OBRIGATORIO)]
        public int Numero { get; set; }
        public int AssociadoId { get; set; }
        public Associado? Associado { get; set; }

        public Endereco() { }

        public Endereco(CreateAssociadoDTO dto)
        {
            this.Bairro = dto.Bairro;
            this.Cidade = dto.Cidade;
            this.Estado = dto.Estado;
            this.Complemento = dto.Complemento;
            this.Rua = dto.Rua;
            this.Numero = dto.Numero;
        }

        public Endereco(Endereco endereco)
        {
            this.Bairro = endereco.Bairro;
            this.Cidade = endereco.Cidade;
            this.Estado = endereco.Estado;
            this.Complemento = endereco.Complemento;
            this.Rua = endereco.Rua;
            this.Numero = endereco.Numero;
        }
    }
}