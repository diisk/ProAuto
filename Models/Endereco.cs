using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProAuto.Models
{
    public class Endereco
    {
        public int Id { get; set;}
        public String? Complemento;
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public String? Estado;
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public String? Cidade;
        [Required]
        public String? Bairro;
        [Required]
        public String? Rua;
        [Range(1, int.MaxValue)]
        public int Numero;
    }
}