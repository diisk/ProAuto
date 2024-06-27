using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProAuto.Models
{
    public class Associado
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O nome deve conter no mínimo 1 e no máximo 60 caracteres.")]
        public String? Nome { get; set; }
        [Required]
        [RegularExpression(@"\d{3}\.\d{3}\.\d{3}\-\d{2}",ErrorMessage = "Formato de CPF inválido.")]
        public String? Cpf { get; set; }
        [Required]
        public Veiculo? Veiculo { get; set; }
        [Required]
        public Endereco? Endereco { get; set; }
    }
}